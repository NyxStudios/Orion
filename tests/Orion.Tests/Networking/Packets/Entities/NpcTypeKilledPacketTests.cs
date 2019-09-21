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
using System.IO;
using FluentAssertions;
using Orion.Entities;
using Xunit;

namespace Orion.Networking.Packets.Entities {
    public class NpcTypeKilledPacketTests {
        [Fact]
        public void SetNpcTypeKilled_MarksAsDirty() {
            var packet = new NpcTypeKilledPacket();
            packet.NpcTypeKilled = NpcType.BlueSlime;

            packet.ShouldBeDirty();
        }

        [Fact]
        public void SetNpcTypeKilled_NullValue_ThrowsArgumentNullException() {
            var packet = new NpcTypeKilledPacket();
            Action action = () => packet.NpcTypeKilled = null;

            action.Should().Throw<ArgumentNullException>();
        }

        public static readonly byte[] Bytes = {5, 0, 97, 1, 0};
        public static readonly byte[] InvalidNpcTypeBytes = {5, 0, 97, 255, 127};

        [Fact]
        public void ReadFromStream_IsCorrect() {
            using (var stream = new MemoryStream(Bytes)) {
                var packet = (NpcTypeKilledPacket)Packet.ReadFromStream(stream, PacketContext.Server);

                packet.NpcTypeKilled.Should().BeSameAs(NpcType.BlueSlime);
            }
        }

        [Fact]
        public void ReadFromStream_InvalidNpcType_ThrowsPacketException() {
            using (var stream = new MemoryStream(InvalidNpcTypeBytes)) {
                Func<Packet> func = () => Packet.ReadFromStream(stream, PacketContext.Server);

                func.Should().Throw<PacketException>();
            }
        }

        [Fact]
        public void WriteToStream_IsCorrect() {
            Bytes.ShouldDeserializeAndSerializeSamePacket();
        }
    }
}