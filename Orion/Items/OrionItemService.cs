﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Orion.Framework;
using Orion.Items.Events;
using OTAPI;

namespace Orion.Items {
    /// <summary>
    /// Orion's implementation of <see cref="IItemService"/>.
    /// </summary>
    internal sealed class OrionItemService : OrionService, IItemService {
        private readonly IItem[] _items;

        /// <inheritdoc />
        public override string Author => "Pryaxis";

        /// <inheritdoc />
        public override string Name => "Orion Item Service";

        /// <inheritdoc />
        public int Count => Terraria.Main.maxItems;

        /// <inheritdoc />
        public IItem this[int index] {
            get {
                if (index < 0 || index >= Count) {
                    throw new IndexOutOfRangeException(nameof(index));
                }

                if (_items[index]?.WrappedItem != Terraria.Main.item[index]) {
                    _items[index] = new OrionItem(Terraria.Main.item[index]);
                }

                var item = _items[index];
                Debug.Assert(item != null, $"{nameof(item)} should not be null.");
                Debug.Assert(item.WrappedItem != null, $"{nameof(item.WrappedItem)} should not be null.");
                return item;
            }
        }

        /// <inheritdoc />
        public event EventHandler<ItemSettingDefaultsEventArgs> ItemSettingDefaults;

        /// <inheritdoc />
        public event EventHandler<ItemSetDefaultsEventArgs> ItemSetDefaults;

        /// <inheritdoc />
        public event EventHandler<ItemUpdatingEventArgs> ItemUpdating;

        /// <inheritdoc />
        public event EventHandler<ItemUpdatedEventArgs> ItemUpdated;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrionItemService"/> class.
        /// </summary>
        public OrionItemService() {
            _items = new IItem[Terraria.Main.maxItems];

            Hooks.Item.PreSetDefaultsById = PreSetDefaultsByIdHandler;
            Hooks.Item.PostSetDefaultsById = PostSetDefaultsByIdHandler;
            Hooks.Item.PreUpdate = PreUpdateHandler;
            Hooks.Item.PostUpdate = PostUpdateHandler;
        }

        /// <inheritdoc />
        public IEnumerator<IItem> GetEnumerator() {
            for (var i = 0; i < Count; ++i) {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public IItem SpawnItem(ItemType type, Vector2 position, int stackSize = 1,
                               ItemPrefix prefix = ItemPrefix.None) {
            // We need to force the item to spawn without caching it.
            var oldItemCache = Terraria.Item.itemCaches[(int)type];
            Terraria.Item.itemCaches[(int)type] = -1;

            var itemIndex = Terraria.Item.NewItem(position, Vector2.Zero, (int)type,
                                                  stackSize, prefixGiven: (int)prefix);

            Debug.Assert(itemIndex >= 0 && itemIndex < Count, $"{nameof(itemIndex)} should have been a valid index.");

            Terraria.Item.itemCaches[(int)type] = oldItemCache;
            return this[itemIndex];
        }

        private HookResult PreSetDefaultsByIdHandler(Terraria.Item terrariaItem, ref int type,
                                                     ref bool noMaterialCheck) {
            var item = new OrionItem(terrariaItem);
            var settingDefaultsArgs = new ItemSettingDefaultsEventArgs(item, (ItemType)type);
            ItemSettingDefaults?.Invoke(this, settingDefaultsArgs);

            type = (int)settingDefaultsArgs.Type;
            return settingDefaultsArgs.Handled ? HookResult.Cancel : HookResult.Continue;
        }

        private void PostSetDefaultsByIdHandler(Terraria.Item terrariaItem, ref int type, ref bool noMaterialCheck) {
            var item = new OrionItem(terrariaItem);
            var setDefaultsArgs = new ItemSetDefaultsEventArgs(item);
            ItemSetDefaults?.Invoke(this, setDefaultsArgs);
        }

        private HookResult PreUpdateHandler(Terraria.Item terrariaItem, ref int i) {
            var item = new OrionItem(terrariaItem);
            var updatingArgs = new ItemUpdatingEventArgs(item);
            ItemUpdating?.Invoke(this, updatingArgs);

            return updatingArgs.Handled ? HookResult.Cancel : HookResult.Continue;
        }

        private void PostUpdateHandler(Terraria.Item terrariaItem, int i) {
            var item = new OrionItem(terrariaItem);
            var updatedArgs = new ItemUpdatedEventArgs(item);
            ItemUpdated?.Invoke(this, updatedArgs);
        }
    }
}
