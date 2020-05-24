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
using System.Diagnostics.CodeAnalysis;
using Orion.Packets.DataStructures;
using Xunit;

namespace Orion.Packets.Server {
    [SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "Testing")]
    public class ServerDisconnectPacketTests {
        public static readonly byte[] Bytes = {
            21, 0, 2, 2, 15, 67, 76, 73, 46, 75, 105, 99, 107, 77, 101, 115, 115, 97, 103, 101, 0
        };

        [Fact]
        public void Reason_SetNullValue_ThrowsArgumentNullException() {
            var packet = new ServerDisconnectPacket();

            Assert.Throws<ArgumentNullException>(() => packet.Reason = null!);
        }

        [Fact]
        public void Reason_Set_Get() {
            var packet = new ServerDisconnectPacket();

            packet.Reason = new NetworkText(NetworkTextMode.Localized, "CLI.KickMessage");

            Assert.Equal(new NetworkText(NetworkTextMode.Localized, "CLI.KickMessage"), packet.Reason);
        }

        [Fact]
        public void Read() {
            var packet = new ServerDisconnectPacket();
            packet.Read(Bytes.AsSpan(IPacket.HeaderSize..), PacketContext.Server);

            Assert.Equal(new NetworkText(NetworkTextMode.Localized, "CLI.KickMessage"), packet.Reason);
        }

        [Fact]
        public void RoundTrip() {
            TestUtils.RoundTrip<ServerDisconnectPacket>(Bytes.AsSpan(IPacket.HeaderSize..), PacketContext.Server);
        }
    }
}