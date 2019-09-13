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
using Orion.World.Tiles;
using Xunit;

namespace Orion.Networking.Packets.Modules {
    public class LiquidChangesModuleTests {
        public static readonly byte[] LiquidChangesBytes = {13, 0, 82, 0, 0, 1, 0, 100, 0, 0, 1, 255, 0};

        [Fact]
        public void ReadFromStream_IsCorrect() {
            using (var stream = new MemoryStream(LiquidChangesBytes)) {
                var packet = (ModulePacket)Packet.ReadFromStream(stream, PacketContext.Server);

                packet.Module.Should().BeOfType<LiquidChangesModule>();
                packet.Module.As<LiquidChangesModule>().LiquidChanges.Should().BeEquivalentTo(
                    new LiquidChange(256, 100, 255, LiquidType.Water));
            }
        }

        [Fact]
        public void WriteToStream_IsCorrect() {
            using (var stream = new MemoryStream(LiquidChangesBytes))
            using (var stream2 = new MemoryStream()) {
                var packet = Packet.ReadFromStream(stream, PacketContext.Server);

                packet.WriteToStream(stream2, PacketContext.Client);

                stream2.ToArray().Should().BeEquivalentTo(LiquidChangesBytes);
            }
        }
    }
}