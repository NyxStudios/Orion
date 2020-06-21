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
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Orion.Core.Framework;
using Serilog;

namespace Orion.Core.Events
{
    /// <summary>
    /// Manages events. Provides access to events and event handler registration/deregistration.
    /// </summary>
    [Service(ServiceScope.Singleton)]
    public interface IEventManager
    {
        /// <summary>
        /// Registers the given synchronous event <paramref name="handler"/> for events of type
        /// <typeparamref name="TEvent"/>.
        /// </summary>
        /// <typeparam name="TEvent">The type of event.</typeparam>
        /// <param name="handler">The synchronous event handler to register.</param>
        /// <param name="log">The log to log the registration to.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="handler"/> or <paramref name="log"/> are <see langword="null"/>.
        /// </exception>
        void RegisterHandler<TEvent>(Action<TEvent> handler, ILogger log) where TEvent : Event;

        /// <summary>
        /// Registers the given asynchronous event <paramref name="handler"/> for events of type
        /// <typeparamref name="TEvent"/>.
        /// </summary>
        /// <typeparam name="TEvent">The type of event.</typeparam>
        /// <param name="handler">The asynchronous event handler to register.</param>
        /// <param name="log">The log to log the registration to.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="handler"/> or <paramref name="log"/> are <see langword="null"/>.
        /// </exception>
        void RegisterAsyncHandler<TEvent>(Func<TEvent, Task> handler, ILogger log) where TEvent : Event;

        /// <summary>
        /// Deregisters the given synchronous event <paramref name="handler"/> for events of type
        /// <typeparamref name="TEvent"/>.
        /// </summary>
        /// <typeparam name="TEvent">The type of event.</typeparam>
        /// <param name="handler">The synchronous event handler to deregister.</param>
        /// <param name="log">The log to log the deregistration to.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="handler"/> or <paramref name="log"/> are <see langword="null"/>.
        /// </exception>
        void DeregisterHandler<TEvent>(Action<TEvent> handler, ILogger log) where TEvent : Event;

        /// <summary>
        /// Deregisters the given asynchronous event <paramref name="handler"/> for events of type
        /// <typeparamref name="TEvent"/>.
        /// </summary>
        /// <typeparam name="TEvent">The type of event.</typeparam>
        /// <param name="handler">The asynchronous event handler to deregister.</param>
        /// <param name="log">The log to log the deregistration to.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="handler"/> or <paramref name="log"/> are <see langword="null"/>.
        /// </exception>
        void DeregisterAsyncHandler<TEvent>(Func<TEvent, Task> handler, ILogger log) where TEvent : Event;

        /// <summary>
        /// Raises the given <paramref name="evt"/>, executing all of the event handlers which apply for events of type
        /// <typeparamref name="TEvent"/>.
        /// </summary>
        /// <typeparam name="TEvent">The type of event.</typeparam>
        /// <param name="evt">The event to raise.</param>
        /// <param name="log">The log to log the raising to.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="evt"/> or <paramref name="log"/> are <see langword="null"/>.
        /// </exception>
        void Raise<TEvent>(TEvent evt, ILogger log) where TEvent : Event;
    }

    /// <summary>
    /// Provides extensions for the <see cref="IEventManager"/> interface.
    /// </summary>
    public static class IEventManagerExtensions
    {
        private static readonly MethodInfo _registerHandler =
            typeof(IEventManager).GetMethod(nameof(IEventManager.RegisterHandler))!;
        private static readonly MethodInfo _registerAsyncHandler =
            typeof(IEventManager).GetMethod(nameof(IEventManager.RegisterAsyncHandler))!;
        private static readonly MethodInfo _deregisterHandler =
            typeof(IEventManager).GetMethod(nameof(IEventManager.DeregisterHandler))!;
        private static readonly MethodInfo _deregisterAsyncHandler =
            typeof(IEventManager).GetMethod(nameof(IEventManager.DeregisterAsyncHandler))!;

        /// <summary>
        /// Registers all of the instance methods marked with <see cref="EventHandlerAttribute"/> as event handlers in
        /// the given <paramref name="obj"/>.
        /// </summary>
        /// <param name="eventManager">The event manager.</param>
        /// <param name="obj">The object whose instance methods should be registered.</param>
        /// <param name="log">The log to log the registrations to.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="obj"/> or <paramref name="log"/> are <see langword="null"/>.
        /// </exception>
        public static void RegisterHandlers(this IEventManager eventManager, object obj, ILogger log) =>
            InvokeHandlers(eventManager, obj, log, _registerHandler, _registerAsyncHandler);

        /// <summary>
        /// Deregisters all of the instance methods marked with <see cref="EventHandlerAttribute"/> as event handlers in
        /// the given <paramref name="obj"/>.
        /// </summary>
        /// <param name="eventManager">The event manager.</param>
        /// <param name="obj">The object whose instance methods should be deregistered.</param>
        /// <param name="log">The log to log the deregistrations to.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="obj"/> or <paramref name="log"/> are <see langword="null"/>.
        /// </exception>
        public static void DeregisterHandlers(this IEventManager eventManager, object obj, ILogger log) =>
            InvokeHandlers(eventManager, obj, log, _deregisterHandler, _deregisterAsyncHandler);

        private static void InvokeHandlers(
            IEventManager eventManager, object obj, ILogger log, MethodInfo method, MethodInfo asyncMethod)
        {
            if (eventManager is null)
            {
                throw new ArgumentNullException(nameof(eventManager));
            }

            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (log is null)
            {
                throw new ArgumentNullException(nameof(log));
            }

            foreach (var handlerMethod in obj
                .GetType()
                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => m.GetCustomAttribute<EventHandlerAttribute>() != null))
            {
                var parameters = handlerMethod.GetParameters();
                if (parameters.Length != 1)
                {
                    // Not localized because this string is developer-facing.
                    log.Warning("Skipping method {HandlerMethod}: does not have one parameter", handlerMethod);
                    continue;
                }

                var eventType = parameters[0].ParameterType;
                if (!eventType.IsSubclassOf(typeof(Event)))
                {
                    // Not localized because this string is developer-facing.
                    log.Warning(
                        "Skipping method {HandlerMethod}: parameter type not derived from `Event`", handlerMethod);
                    continue;
                }

                var returnType = handlerMethod.ReturnType;
                if (returnType == typeof(void))
                {
                    var handlerType = typeof(Action<>).MakeGenericType(eventType);
                    var handler = handlerMethod.CreateDelegate(handlerType, obj);
                    method.MakeGenericMethod(eventType).Invoke(eventManager, new object[] { handler, log });
                }
                else if (returnType == typeof(Task))
                {
                    var handlerType = typeof(Func<,>).MakeGenericType(eventType, typeof(Task));
                    var handler = handlerMethod.CreateDelegate(handlerType, obj);
                    asyncMethod.MakeGenericMethod(eventType).Invoke(eventManager, new object[] { handler, log });
                }
                else
                {
                    // Not localized because this string is developer-facing.
                    log.Warning(
                        "Skipping method {HandlerMethod}: return type is `{ReturnType}`", handlerMethod, returnType);
                }
            }
        }
    }
}
