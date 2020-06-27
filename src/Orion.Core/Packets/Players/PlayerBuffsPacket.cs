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
using System.Runtime.InteropServices;
using Orion.Core.Buffs;

namespace Orion.Core.Packets.Players
{
    /// <summary>
    /// A packet sent to set a player's buffs.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 45)]
    public sealed class PlayerBuffsPacket : IPacket
    {
        [FieldOffset(0)] private byte _bytes;
        [FieldOffset(1)] private BuffId _buffIds;

        /// <summary>
        /// Gets or sets the player index.
        /// </summary>
        /// <value>The player index.</value>
        [field: FieldOffset(0)] public byte PlayerIndex { get; set; }

        /// <summary>
        /// Gets the buff IDs.
        /// </summary>
        /// <value>The buff IDs.</value>
        public unsafe Span<BuffId> Ids => MemoryMarshal.CreateSpan(ref _buffIds, 22);

        PacketId IPacket.Id => PacketId.PlayerBuffs;

        int IPacket.ReadBody(Span<byte> span, PacketContext context) => span.Read(ref _bytes, 45);
        int IPacket.WriteBody(Span<byte> span, PacketContext context) => span.Write(ref _bytes, 45);
    }
}