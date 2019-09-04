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

        public override string Author => "Pryaxis";
        public override string Name => "Orion Item Service";

        public int Count => Terraria.Main.maxItems;

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

        public event EventHandler<SettingItemDefaultsEventArgs> SettingItemDefaults;
        public event EventHandler<SetItemDefaultsEventArgs> SetItemDefaults;
        public event EventHandler<UpdatingItemEventArgs> UpdatingItem;
        public event EventHandler<UpdatedItemEventArgs> UpdatedItem;

        public OrionItemService() {
            _items = new IItem[Terraria.Main.maxItems];

            Hooks.Item.PreSetDefaultsById = PreSetDefaultsByIdHandler;
            Hooks.Item.PostSetDefaultsById = PostSetDefaultsByIdHandler;
            Hooks.Item.PreUpdate = PreUpdateHandler;
            Hooks.Item.PostUpdate = PostUpdateHandler;
        }

        protected override void Dispose(bool disposeManaged) {
            Hooks.Item.PreSetDefaultsById = null;
            Hooks.Item.PostSetDefaultsById = null;
            Hooks.Item.PreUpdate = null;
            Hooks.Item.PostUpdate = null;
        }

        public IEnumerator<IItem> GetEnumerator() {
            for (var i = 0; i < Count; ++i) {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IItem SpawnItem(ItemType type, Vector2 position, int stackSize = 1,
                               ItemPrefix prefix = ItemPrefix.None) {
            // We need to force the item to spawn without caching it.
            var oldItemCache = Terraria.Item.itemCaches[(int)type];
            Terraria.Item.itemCaches[(int)type] = -1;

            var itemIndex = Terraria.Item.NewItem(position, Vector2.Zero, (int)type,
                                                  stackSize, prefixGiven: (int)prefix);

            Debug.Assert(itemIndex >= 0 && itemIndex < Count, $"{nameof(itemIndex)} should be a valid index.");

            Terraria.Item.itemCaches[(int)type] = oldItemCache;
            return this[itemIndex];
        }


        private HookResult PreSetDefaultsByIdHandler(Terraria.Item terrariaItem, ref int type,
                                                     ref bool noMaterialCheck) {
            var item = new OrionItem(terrariaItem);
            var args = new SettingItemDefaultsEventArgs(item, (ItemType)type);
            SettingItemDefaults?.Invoke(this, args);

            type = (int)args.Type;
            return args.Handled ? HookResult.Cancel : HookResult.Continue;
        }

        private void PostSetDefaultsByIdHandler(Terraria.Item terrariaItem, ref int type, ref bool noMaterialCheck) {
            var item = new OrionItem(terrariaItem);
            var args = new SetItemDefaultsEventArgs(item);
            SetItemDefaults?.Invoke(this, args);
        }

        private HookResult PreUpdateHandler(Terraria.Item terrariaItem, ref int i) {
            var item = new OrionItem(terrariaItem);
            var args = new UpdatingItemEventArgs(item);
            UpdatingItem?.Invoke(this, args);

            return args.Handled ? HookResult.Cancel : HookResult.Continue;
        }

        private void PostUpdateHandler(Terraria.Item terrariaItem, int i) {
            var item = new OrionItem(terrariaItem);
            var args = new UpdatedItemEventArgs(item);
            UpdatedItem?.Invoke(this, args);
        }
    }
}