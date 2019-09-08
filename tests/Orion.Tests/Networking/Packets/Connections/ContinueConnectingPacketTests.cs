﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentAssertions;
using Orion.Networking.Packets;
using Orion.Networking.Packets.Connections;
using Xunit;

namespace Orion.Tests.Networking.Packets.Connections {
    public class ContinueConnectingPacketTests {
        public static readonly byte[] ContinueConnectingBytes = {4, 0, 3, 0};

        [Fact]
        public void ReadFromStream_IsCorrect() {
            using (var stream = new MemoryStream(ContinueConnectingBytes)) {
                var packet = (ContinueConnectingPacket)Packet.ReadFromStream(stream);

                packet.PlayerIndex.Should().Be(0);
            }
        }

        [Fact]
        public void WriteToStream_IsCorrect() {
            using (var stream = new MemoryStream(ContinueConnectingBytes))
            using (var stream2 = new MemoryStream()) {
                var packet = Packet.ReadFromStream(stream);

                packet.WriteToStream(stream2);

                stream2.ToArray().Should().BeEquivalentTo(ContinueConnectingBytes);
            }
        }
    }
}