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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Orion.Core.Buffs;

namespace Orion.Core.Packets.Players {
    /// <summary>
    /// A packet sent to buff a player.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct PlayerBuffPacket : IPacket {
        /// <summary>
        /// Gets or sets the player index.
        /// </summary>
        /// <value>The player index.</value>
        [field: FieldOffset(0)] public byte PlayerIndex { get; set; }

        /// <summary>
        /// Gets or sets the buff ID.
        /// </summary>
        /// <value>The buff ID.</value>
        [field: FieldOffset(1)] public BuffId Id { get; set; }

        /// <summary>
        /// Gets or sets the buff time, in ticks.
        /// </summary>
        /// <value>The buff time, in ticks.</value>
        [field: FieldOffset(3)] public int Ticks { get; set; }

        PacketId IPacket.Id => PacketId.PlayerBuff;

        /// <inheritdoc/>
        public int Read(Span<byte> span, PacketContext context) {
            Unsafe.CopyBlockUnaligned(ref this.AsRefByte(0), ref span[0], 7);
            return 7;
        }

        /// <inheritdoc/>
        public int Write(Span<byte> span, PacketContext context) {
            Unsafe.CopyBlockUnaligned(ref span[0], ref this.AsRefByte(0), 7);
            return 7;
        }
    }
}