﻿// Copyright (c) 2020 Pryaxis & Orion Contributors
// 
// This file is part of Orion.
// 
// Orion is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Orion is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Orion.  If not, see <https://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ninject;
using Ninject.Extensions.NamedScope;
using Orion.Events;
using Orion.Events.Server;
using Orion.Framework;
using Orion.Properties;
using Serilog;

namespace Orion {
    /// <summary>
    /// Represents Orion's core logic. Provides methods to manipulate Orion plugins and events.
    /// </summary>
    public sealed class OrionKernel : IDisposable {
        private static readonly MethodInfo _registerHandler =
            typeof(OrionKernel).GetMethod(nameof(RegisterHandler));
        private static readonly MethodInfo _deregisterHandler =
            typeof(OrionKernel).GetMethod(nameof(DeregisterHandler));

        private readonly ILogger _log;

        private readonly IKernel _kernel = new StandardKernel();

        private readonly ISet<Type> _serviceTypes = new HashSet<Type>();
        private readonly IDictionary<Type, Type> _serviceBindings = new Dictionary<Type, Type>();
        private readonly ISet<Type> _pluginTypes = new HashSet<Type>();
        private readonly Dictionary<string, OrionPlugin> _plugins = new Dictionary<string, OrionPlugin>();

        private readonly IDictionary<Type, object> _eventHandlerCollections = new Dictionary<Type, object>();
        private readonly IDictionary<object, IList<(Type eventType, object handler)>> _handlerRegistrations =
            new Dictionary<object, IList<(Type eventType, object handler)>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="OrionKernel"/> class with the specified <paramref name="log"/>.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <exception cref="ArgumentNullException"><paramref name="log"/> is <see langword="null"/>.</exception>
        public OrionKernel(ILogger log) {
            if (log is null) {
                throw new ArgumentNullException(nameof(log));
            }

            _log = log.ForContext("Name", "orion-kernel");

            // Bind `OrionKernel` to this instance so that services/plugins retrieve this instance.
            _kernel.Bind<OrionKernel>().ToConstant(this);

            // Bind `ILogger` so that services/plugins retrieve specific logs.
            _kernel
                .Bind<ILogger>()
                .ToMethod(ctx => {
                    var type = ctx.Request.Target.Member.ReflectedType;
                    var name =
                        type.GetCustomAttribute<BindingAttribute?>()?.Name ??
                        type.GetCustomAttribute<PluginAttribute?>()?.Name ??
                        type.Name;
                    return log.ForContext("Name", name);
                })
                .InTransientScope();

            OTAPI.Hooks.Game.PreInitialize += PreInitializeHandler;
            OTAPI.Hooks.Game.Started += StartedHandler;
            OTAPI.Hooks.Game.PreUpdate += PreUpdateHandler;
            OTAPI.Hooks.Command.Process += ProcessHandler;
        }

        /// <summary>
        /// Gets a read-only mapping from plugin names to plugins.
        /// </summary>
        /// <value>A read-only mapping from plugin names to plugins.</value>
        public IReadOnlyDictionary<string, OrionPlugin> Plugins => _plugins;

        /// <summary>
        /// Disposes the kernel, releasing any resources associated with it.
        /// </summary>
        public void Dispose() {
            _kernel.Dispose();

            OTAPI.Hooks.Game.PreInitialize -= PreInitializeHandler;
            OTAPI.Hooks.Game.Started -= StartedHandler;
            OTAPI.Hooks.Game.PreUpdate -= PreUpdateHandler;
            OTAPI.Hooks.Command.Process -= ProcessHandler;
        }

        /// <summary>
        /// Loads services, service bindings, and plugins from the given <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <exception cref="ArgumentNullException"><paramref name="assembly"/> is <see langword="null"/>.</exception>
        public void LoadFrom(Assembly assembly) {
            if (assembly is null) {
                throw new ArgumentNullException(nameof(assembly));
            }

            var types = assembly.DefinedTypes;
            var exportedTypes = assembly.ExportedTypes;
            static bool HasAttribute<TAttribute>(Type type) where TAttribute : Attribute =>
                Attribute.IsDefined(type, typeof(TAttribute));

            // Load all exported service types from the assembly.
            _serviceTypes.UnionWith(exportedTypes.Where(HasAttribute<ServiceAttribute>));

            // Load all service binding types from the assembly.
            foreach (var thisBindingType in types.Where(HasAttribute<BindingAttribute>)) {
                var thisAttribute = thisBindingType.GetCustomAttribute<BindingAttribute>();

                foreach (var interfaceType in thisBindingType.GetInterfaces().Where(_serviceTypes.Contains)) {
                    if (!_serviceBindings.TryGetValue(interfaceType, out var currentBindingType)) {
                        // If no binding currently exists, then add this binding.
                        _serviceBindings[interfaceType] = thisBindingType;
                    } else {
                        // If this binding has a higher priority than the current binding, then replace the current
                        // binding with this binding.
                        var currentAttribute = currentBindingType.GetCustomAttribute<BindingAttribute>();
                        if (thisAttribute.Priority > currentAttribute.Priority) {
                            _serviceBindings[interfaceType] = thisBindingType;
                        }
                    }
                }
            }

            // Load all exported plugin types from the assembly.
            foreach (var pluginType in exportedTypes.Where(HasAttribute<PluginAttribute>)) {
                _pluginTypes.Add(pluginType);

                var pluginName = pluginType.GetCustomAttribute<PluginAttribute>().Name;
                _log.Information(Resources.Kernel_LoadedPlugin, pluginName);
            }
        }

        /// <summary>
        /// Initializes the loaded service bindings and plugins.
        /// </summary>
        public void Initialize() {
            // Initialize the service bindings.
            foreach (var kvp in _serviceBindings) {
                var serviceType = kvp.Key;
                var bindingType = kvp.Value;
                var binding = _kernel.Bind(serviceType).To(bindingType);

                var scope = serviceType.GetCustomAttribute<ServiceAttribute>().Scope;
                _ = scope switch {
                    ServiceScope.Singleton => binding.InSingletonScope(),
                    ServiceScope.Transient => binding.InTransientScope(),
                    ServiceScope.Parent => binding.InParentScope(),

                    // Not localized because this string is developer-facing.
                    _ => throw new InvalidOperationException("Invalid service scope")
                };

                // Eagerly request singleton-scoped services so that an instance always exists.
                if (scope == ServiceScope.Singleton) {
                    _kernel.Get(serviceType);
                }
            }

            // Initialize the plugin bindings.
            foreach (var pluginType in _pluginTypes) {
                _kernel.Bind(pluginType).ToSelf().InSingletonScope();
            }

            // Initialize the plugins.
            foreach (var plugin in _pluginTypes.Select(t => (OrionPlugin)_kernel.Get(t))) {
                plugin.Initialize();

                var pluginType = plugin.GetType();
                var attribute = pluginType.GetCustomAttribute<PluginAttribute>();
                var pluginName = attribute.Name;
                _plugins[pluginName] = plugin;

                var pluginVersion = pluginType.Assembly.GetName().Version;
                var pluginAuthor = attribute.Author;
                _log.Information(Resources.Kernel_InitializedPlugin, pluginName, pluginVersion, pluginAuthor);
            }
        }

        /// <summary>
        /// Unloads the plugin with the given <paramref name="pluginName"/>. Returns a value indicating success.
        /// </summary>
        /// <param name="pluginName">The plugin name.</param>
        /// <returns><see langword="true"/> if the plugin was unloaded; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="pluginName"/> is <see langword="null"/>.</exception>
        public bool UnloadPlugin(string pluginName) {
            if (pluginName is null) {
                throw new ArgumentNullException(nameof(pluginName));
            }

            if (!_plugins.TryGetValue(pluginName, out var plugin)) {
                return false;
            }

            _plugins.Remove(pluginName);
            plugin.Dispose();
            _kernel.Unbind(plugin.GetType());

            _log.Information(Resources.Kernel_UnloadedPlugin, pluginName);
            return true;
        }

        /// <summary>
        /// Registers the given event <paramref name="handler"/>.
        /// </summary>
        /// <typeparam name="TEvent">The type of event.</typeparam>
        /// <param name="handler">The event handler.</param>
        /// <param name="log">The logger to log to.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="handler"/> or <paramref name="log"/> are <see langword="null"/>.
        /// </exception>
        public void RegisterHandler<TEvent>(Action<TEvent> handler, ILogger log) where TEvent : Event {
            if (handler is null) {
                throw new ArgumentNullException(nameof(handler));
            }

            if (log is null) {
                throw new ArgumentNullException(nameof(log));
            }

            GetEventHandlerCollection<TEvent>().RegisterHandler(handler, log);
        }

        /// <summary>
        /// Registers all of the methods marked with <see cref="EventHandlerAttribute"/> as event handlers in the given
        /// <paramref name="handlerObject"/>.
        /// </summary>
        /// <param name="handlerObject">The handler object.</param>
        /// <param name="log">The logger to log to.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="handlerObject"/> contains a method marked with <see cref="EventHandlerAttribute"/> which is
        /// not of the correct form.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="handlerObject"/> or <paramref name="log"/> are <see langword="null"/>.
        /// </exception>
        public void RegisterHandlers(object handlerObject, ILogger log) {
            if (handlerObject is null) {
                throw new ArgumentNullException(nameof(handlerObject));
            }

            if (log is null) {
                throw new ArgumentNullException(nameof(log));
            }

            var registrations = _handlerRegistrations[handlerObject] = new List<(Type eventType, object handler)>();
            foreach (var method in handlerObject
                    .GetType()
                    .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
                if (method.GetCustomAttribute<EventHandlerAttribute>() is null) {
                    continue;
                }

                var parameters = method.GetParameters();
                if (parameters.Length != 1) {
                    // Not localized because this string is developer-facing.
                    throw new ArgumentException(
                        $"Method `{method.Name}` does not have exactly one argument", nameof(handlerObject));
                }

                var eventType = parameters[0].ParameterType;
                if (!eventType.IsSubclassOf(typeof(Event))) {
                    // Not localized because this string is developer-facing.
                    throw new ArgumentException(
                        $"Method `{method.Name}` does not have an argument of type derived from `Event`",
                        nameof(handlerObject));
                }

                // Register the handler.
                var handlerType = typeof(Action<>).MakeGenericType(eventType);
                var handler = method.CreateDelegate(handlerType, handlerObject);
                _registerHandler.MakeGenericMethod(eventType).Invoke(this, new object[] { handler, log });
                registrations.Add((eventType, handler));
            }
        }

        /// <summary>
        /// Deregisters the given event <paramref name="handler"/>. Returns a value indicating success.
        /// </summary>
        /// <typeparam name="TEvent">The type of event.</typeparam>
        /// <param name="handler">The event handler.</param>
        /// <param name="log">The logger to log to.</param>
        /// <returns>
        /// <see langword="true"/> if the event handler was successfully deregistered; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="handler"/> or <paramref name="log"/> are <see langword="null"/>.
        /// </exception>
        public bool DeregisterHandler<TEvent>(Action<TEvent> handler, ILogger log) where TEvent : Event {
            if (handler is null) {
                throw new ArgumentNullException(nameof(handler));
            }

            if (log is null) {
                throw new ArgumentNullException(nameof(log));
            }

            return GetEventHandlerCollection<TEvent>().DeregisterHandler(handler, log);
        }

        /// <summary>
        /// Deregisters all of the methods marked with <see cref="EventHandlerAttribute"/> as event handlers in the
        /// given <paramref name="handlerObject"/>. Returns a value indicating success.
        /// </summary>
        /// <param name="handlerObject">The handler object.</param>
        /// <param name="log">The logger to log to.</param>
        /// <returns>
        /// <see langword="true"/> if the event handlers were successfully deregistered; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="handlerObject"/> or <paramref name="log"/> are <see langword="null"/>.
        /// </exception>
        public bool DeregisterHandlers(object handlerObject, ILogger log) {
            if (handlerObject is null) {
                throw new ArgumentNullException(nameof(handlerObject));
            }

            if (log is null) {
                throw new ArgumentNullException(nameof(log));
            }

            if (!_handlerRegistrations.TryGetValue(handlerObject, out var registrations)) {
                return false;
            }

            _handlerRegistrations.Remove(handlerObject);
            foreach (var (eventType, handler) in registrations) {
                _deregisterHandler.MakeGenericMethod(eventType).Invoke(this, new object[] { handler, log });
            }
            return true;
        }

        /// <summary>
        /// Raises <paramref name="evt"/>.
        /// </summary>
        /// <typeparam name="TEvent">The type of event.</typeparam>
        /// <param name="evt">The event to raise.</param>
        /// <param name="log">The logger to log to.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="evt"/> or <paramref name="log"/> are <see langword="null"/>.
        /// </exception>
        public void Raise<TEvent>(TEvent evt, ILogger log) where TEvent : Event {
            if (evt is null) {
                throw new ArgumentNullException(nameof(evt));
            }

            if (log is null) {
                throw new ArgumentNullException(nameof(log));
            }

            GetEventHandlerCollection<TEvent>().Raise(evt, log);
        }

        // Helper method for retrieving an `EventHandlerCollection<TEvent>`.
        private EventHandlerCollection<TEvent> GetEventHandlerCollection<TEvent>() where TEvent : Event {
            var type = typeof(TEvent);
            if (!_eventHandlerCollections.TryGetValue(type, out var collection)) {
                collection = new EventHandlerCollection<TEvent>();
                _eventHandlerCollections[type] = collection;
            }

            return (EventHandlerCollection<TEvent>)collection;
        }

        private void PreInitializeHandler() {
            var evt = new ServerInitializeEvent();
            Raise(evt, _log);
        }

        private void StartedHandler() {
            var evt = new ServerStartEvent();
            Raise(evt, _log);
        }

        private void PreUpdateHandler(ref Microsoft.Xna.Framework.GameTime _) {
            var evt = new ServerTickEvent();
            Raise(evt, _log);
        }

        private OTAPI.HookResult ProcessHandler(string _, string input) {
            var evt = new ServerCommandEvent(input);
            Raise(evt, _log);
            return evt.IsCanceled() ? OTAPI.HookResult.Cancel : OTAPI.HookResult.Continue;
        }
    }
}
