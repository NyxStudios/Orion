﻿// Copyright (c) 2015-2019 Pryaxis & Orion Contributors
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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.Xna.Framework;
using Orion.Entities;
using Orion.Networking.Packets.Extensions;

namespace Orion.Networking.Packets.Entities {
    /// <summary>
    /// Packet sent to set instanced item information.
    /// </summary>
    public sealed class InstancedItemInfoPacket : Packet {
        private short _itemIndex;
        private Vector2 _itemPosition;
        private Vector2 _itemVelocity;
        private short _itemStackSize;
        private ItemPrefix _itemPrefix;
        private bool _shouldDisownItem;
        private ItemType _itemType;

        /// <inheritdoc />
        public override PacketType Type => PacketType.InstancedItemInfo;

        /// <summary>
        /// Gets or sets the item index.
        /// </summary>
        public short ItemIndex {
            get => _itemIndex;
            set {
                _itemIndex = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the item's position.
        /// </summary>
        public Vector2 ItemPosition {
            get => _itemPosition;
            set {
                _itemPosition = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the item's velocity.
        /// </summary>
        public Vector2 ItemVelocity {
            get => _itemVelocity;
            set {
                _itemVelocity = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the item's stack size.
        /// </summary>
        public short ItemStackSize {
            get => _itemStackSize;
            set {
                _itemStackSize = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the item's prefix.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
        public ItemPrefix ItemPrefix {
            get => _itemPrefix;
            set {
                _itemPrefix = value ?? throw new ArgumentNullException(nameof(value));
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the item should be disowned.
        /// </summary>
        public bool ShouldDisownItem {
            get => _shouldDisownItem;
            set {
                _shouldDisownItem = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the item's type.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
        public ItemType ItemType {
            get => _itemType;
            set {
                _itemType = value ?? throw new ArgumentNullException(nameof(value));
                _isDirty = true;
            }
        }

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        public override string ToString() =>
            $"{Type}[#={ItemIndex}, {(ItemPrefix != ItemPrefix.None ? ItemPrefix + " " : "")}{ItemType} " +
            $"x{ItemStackSize} @ {ItemPosition}, ...]";

        private protected override void ReadFromReader(BinaryReader reader, PacketContext context) {
            ItemIndex = reader.ReadInt16();
            ItemPosition = reader.ReadVector2();
            ItemVelocity = reader.ReadVector2();
            ItemStackSize = reader.ReadInt16();
            ItemPrefix = ItemPrefix.FromId(reader.ReadByte()) ?? throw new PacketException("Item prefix is invalid.");
            ShouldDisownItem = reader.ReadBoolean();
            ItemType = ItemType.FromId(reader.ReadInt16()) ?? throw new PacketException("Item type is invalid.");
        }

        private protected override void WriteToWriter(BinaryWriter writer, PacketContext context) {
            writer.Write(ItemIndex);
            writer.Write(ItemPosition);
            writer.Write(ItemVelocity);
            writer.Write(ItemStackSize);
            writer.Write((byte)ItemPrefix.Id);
            writer.Write(ShouldDisownItem);
            writer.Write(ItemType.Id);
        }
    }
}