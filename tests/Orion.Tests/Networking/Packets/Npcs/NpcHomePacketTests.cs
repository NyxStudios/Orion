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

using System.IO;
using FluentAssertions;
using Xunit;

namespace Orion.Networking.Packets.Npcs {
    public class NpcHomePacketTests {
        public static readonly byte[] NpcHomeBytes = {10, 0, 60, 0, 0, 0, 1, 100, 0, 0};

        [Fact]
        public void ReadFromStream_IsCorrect() {
            using (var stream = new MemoryStream(NpcHomeBytes)) {
                var packet = (NpcHomePacket)Packet.ReadFromStream(stream, PacketContext.Server);

                packet.NpcIndex.Should().Be(0);
                packet.NpcHomeX.Should().Be(256);
                packet.NpcHomeY.Should().Be(100);
                packet.IsNpcHomeless.Should().BeFalse();
            }
        }

        [Fact]
        public void WriteToStream_IsCorrect() {
            using (var stream = new MemoryStream(NpcHomeBytes))
            using (var stream2 = new MemoryStream()) {
                var packet = Packet.ReadFromStream(stream, PacketContext.Server);

                packet.WriteToStream(stream2, PacketContext.Server);

                stream2.ToArray().Should().BeEquivalentTo(NpcHomeBytes);
            }
        }
    }
}