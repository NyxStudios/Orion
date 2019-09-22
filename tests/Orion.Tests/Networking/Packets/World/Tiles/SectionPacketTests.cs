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
using Orion.Networking.World.TileEntities;
using Orion.Networking.World.Tiles;
using Xunit;

namespace Orion.Networking.Packets.World.Tiles {
    public class SectionPacketTests {
        [Fact]
        public void SetDefaultableProperties_MarkAsDirty() {
            var packet = new SectionPacket();

            packet.ShouldHaveDefaultablePropertiesMarkAsDirty();
        }

        [Fact]
        public void SectionTiles_SetItem_MarksAsDirty() {
            var packet = new SectionPacket();
            packet.SectionTiles = new NetworkTiles(1, 1);
            packet.ShouldBeDirty();

            packet.SectionTiles[0, 0] = new NetworkTile();

            packet.ShouldBeDirty();
        }

        [Fact]
        public void SetSectionTiles_NullValue_ThrowsArgumentNullException() {
            var packet = new SectionPacket();
            Action action = () => packet.SectionTiles = null;

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SectionTileEntities_Count_IsCorrect() {
            var packet = new SectionPacket();
            packet.SectionTileEntities.Add(new NetworkChest());

            packet.SectionTileEntities.Count.Should().Be(1);
        }

        [Fact]
        public void SectionTileEntities_IsReadOnly_IsCorrect() {
            var packet = new SectionPacket();

            packet.SectionTileEntities.IsReadOnly.Should().BeFalse();
        }

        [Fact]
        public void SectionTileEntities_MarksAsDirty() {
            var packet = new SectionPacket();
            var chest = new NetworkChest();

            packet.SectionTileEntities.Add(chest);
            packet.ShouldBeDirty();
            packet.SectionTileEntities.Remove(chest);
            packet.ShouldBeDirty();
            packet.SectionTileEntities.Insert(0, chest);
            packet.ShouldBeDirty();
            packet.SectionTileEntities.RemoveAt(0);
            packet.ShouldBeDirty();
            packet.SectionTileEntities.Add(chest);
            packet.ShouldBeDirty();
            packet.SectionTileEntities[0] = chest;
            packet.ShouldBeDirty();
            packet.SectionTileEntities.Clear();
            packet.ShouldBeDirty();
        }

        private static readonly byte[] Bytes = {
            254, 7, 10, 1, 109, 87, 189, 143, 28, 73, 21, 175, 170, 254, 152, 158, 153, 253, 152, 237, 195, 189, 235,
            51, 8, 99, 6, 123, 56, 77, 96, 144, 88, 7, 67, 48, 106, 208, 178, 23, 64, 2, 18, 163, 11, 64, 66, 156, 124,
            32, 52, 194, 123, 119, 66, 66, 103, 100, 132, 137, 78, 66, 68, 4, 142, 208, 5, 54, 100, 78, 173, 203, 87,
            228, 151, 238, 95, 177, 34, 198, 188, 143, 223, 235, 170, 26, 159, 45, 117, 245, 171, 122, 245, 222, 239,
            253, 222, 71, 207, 126, 48, 115, 110, 233, 157, 251, 143, 251, 135, 123, 242, 135, 31, 135, 170, 115, 151,
            110, 253, 79, 172, 243, 80, 45, 221, 198, 173, 63, 13, 149, 115, 215, 110, 125, 136, 253, 192, 114, 231,
            214, 199, 44, 95, 67, 190, 114, 235, 17, 244, 27, 236, 255, 153, 247, 123, 185, 231, 232, 159, 234, 145,
            220, 133, 170, 39, 57, 84, 91, 210, 14, 213, 134, 239, 120, 232, 212, 108, 227, 74, 118, 59, 177, 212, 211,
            13, 126, 146, 253, 39, 81, 34, 235, 7, 124, 99, 43, 86, 59, 182, 112, 204, 242, 18, 242, 82, 208, 136, 220,
            68, 239, 130, 254, 49, 246, 37, 154, 14, 168, 28, 238, 155, 94, 15, 36, 151, 130, 68, 173, 72, 108, 1, 183,
            31, 179, 172, 177, 245, 132, 2, 152, 124, 134, 240, 6, 175, 75, 139, 197, 91, 100, 91, 104, 92, 138, 15,
            137, 161, 73, 25, 114, 192, 184, 1, 22, 138, 124, 202, 171, 203, 152, 95, 34, 118, 97, 116, 132, 253, 145,
            97, 222, 10, 166, 13, 235, 120, 196, 243, 73, 140, 199, 1, 105, 103, 209, 77, 17, 85, 130, 113, 99, 24, 59,
            216, 150, 179, 107, 187, 63, 2, 210, 38, 34, 145, 44, 60, 134, 182, 241, 52, 141, 178, 232, 117, 145, 147,
            101, 140, 103, 132, 92, 52, 49, 135, 178, 142, 145, 179, 139, 52, 55, 29, 248, 88, 198, 92, 89, 238, 124,
            172, 158, 165, 176, 171, 49, 110, 145, 161, 75, 120, 218, 198, 155, 99, 228, 241, 34, 238, 27, 110, 203,
            235, 21, 56, 92, 102, 53, 226, 80, 99, 221, 78, 157, 94, 199, 90, 30, 35, 59, 137, 237, 30, 121, 49, 207, 3,
            214, 4, 185, 213, 226, 54, 227, 71, 80, 54, 59, 254, 199, 56, 207, 208, 111, 98, 62, 77, 47, 171, 109, 151,
            225, 54, 30, 165, 186, 199, 89, 28, 143, 210, 14, 89, 102, 86, 173, 227, 58, 84, 169, 228, 118, 20, 89, 73,
            42, 37, 68, 54, 4, 227, 163, 236, 52, 143, 123, 138, 172, 36, 61, 25, 17, 88, 157, 88, 79, 247, 113, 127,
            12, 4, 23, 17, 145, 131, 61, 211, 91, 14, 136, 151, 200, 68, 111, 179, 167, 142, 181, 156, 221, 30, 35, 158,
            139, 148, 245, 109, 214, 45, 121, 125, 93, 163, 91, 114, 166, 109, 38, 198, 105, 101, 243, 100, 152, 115,
            23, 59, 93, 51, 137, 221, 217, 197, 59, 37, 186, 161, 194, 124, 157, 160, 42, 66, 204, 154, 206, 148, 14,
            30, 229, 212, 199, 190, 239, 178, 122, 119, 195, 105, 202, 191, 245, 81, 30, 25, 245, 64, 17, 59, 226, 82,
            176, 72, 60, 147, 52, 222, 109, 54, 191, 151, 89, 63, 119, 168, 47, 201, 239, 163, 108, 250, 100, 245, 149,
            216, 50, 31, 85, 100, 197, 225, 91, 145, 96, 78, 122, 163, 219, 233, 13, 97, 254, 34, 178, 36, 214, 39, 54,
            129, 182, 177, 23, 61, 238, 148, 208, 169, 118, 59, 213, 13, 117, 209, 101, 95, 150, 30, 115, 242, 10, 156,
            109, 108, 234, 14, 61, 96, 147, 148, 242, 245, 251, 47, 217, 243, 200, 195, 52, 237, 120, 203, 117, 18, 251,
            56, 139, 217, 170, 171, 206, 114, 155, 77, 135, 30, 108, 219, 116, 232, 179, 170, 223, 130, 7, 203, 174,
            203, 154, 178, 68, 160, 85, 30, 224, 221, 79, 253, 223, 233, 184, 164, 245, 51, 172, 153, 204, 37, 18, 63,
            6, 219, 157, 49, 99, 3, 112, 248, 228, 55, 233, 240, 178, 33, 212, 103, 77, 155, 124, 252, 11, 236, 26, 33,
            190, 84, 255, 45, 252, 183, 238, 13, 89, 239, 36, 109, 101, 195, 63, 25, 123, 54, 62, 100, 61, 8, 183, 152,
            192, 112, 171, 149, 231, 92, 158, 167, 204, 200, 47, 222, 252, 108, 185, 228, 35, 17, 127, 194, 116, 25,
            123, 218, 98, 63, 44, 1, 37, 201, 111, 184, 243, 71, 207, 54, 104, 105, 117, 73, 36, 23, 113, 198, 6, 31,
            74, 203, 134, 95, 25, 110, 157, 11, 194, 247, 52, 233, 137, 148, 190, 59, 14, 170, 149, 160, 90, 9, 170,
            149, 160, 90, 183, 254, 101, 250, 213, 191, 76, 234, 242, 10, 189, 246, 84, 128, 188, 116, 161, 16, 66, 10,
            33, 100, 216, 127, 234, 6, 130, 37, 212, 151, 216, 117, 119, 191, 240, 115, 169, 139, 47, 60, 147, 87, 150,
            229, 238, 206, 144, 77, 124, 58, 194, 3, 1, 250, 160, 117, 198, 69, 171, 92, 180, 59, 146, 139, 37, 252,
            198, 79, 180, 236, 67, 179, 1, 63, 173, 176, 208, 130, 31, 147, 210, 119, 225, 100, 46, 194, 124, 120, 63,
            165, 231, 250, 231, 22, 183, 80, 250, 74, 162, 47, 78, 229, 249, 59, 217, 249, 83, 194, 202, 210, 61, 19,
            32, 202, 194, 51, 211, 196, 126, 207, 156, 189, 43, 118, 222, 61, 143, 118, 94, 137, 157, 226, 60, 241, 194,
            251, 189, 156, 122, 108, 9, 136, 226, 126, 232, 67, 85, 220, 14, 231, 175, 67, 36, 251, 25, 29, 107, 193,
            180, 178, 20, 51, 210, 242, 154, 128, 22, 116, 183, 67, 2, 146, 29, 114, 244, 153, 3, 190, 151, 130, 219,
            114, 154, 67, 126, 32, 165, 243, 64, 74, 231, 213, 80, 168, 115, 77, 199, 124, 71, 226, 155, 79, 113, 243,
            206, 11, 57, 161, 91, 159, 84, 124, 247, 111, 252, 148, 176, 72, 120, 47, 119, 253, 12, 177, 104, 7, 61, 53,
            201, 62, 153, 101, 154, 32, 206, 99, 154, 46, 39, 207, 86, 92, 145, 112, 42, 7, 167, 146, 224, 83, 57, 56,
            101, 179, 159, 255, 55, 208, 249, 231, 117, 193, 207, 19, 122, 174, 127, 82, 204, 124, 239, 137, 173, 147,
            222, 249, 179, 23, 193, 211, 210, 135, 73, 112, 125, 184, 71, 44, 234, 252, 222, 162, 136, 204, 42, 65, 223,
            72, 52, 191, 173, 218, 193, 197, 169, 60, 231, 195, 187, 228, 160, 164, 76, 77, 200, 107, 235, 30, 78, 200,
            173, 44, 39, 188, 156, 63, 252, 81, 113, 159, 60, 143, 207, 92, 120, 171, 118, 43, 90, 138, 58, 132, 218, 5,
            6, 65, 82, 115, 246, 92, 214, 49, 237, 210, 226, 117, 121, 91, 224, 121, 178, 173, 213, 66, 49, 189, 106,
            221, 78, 129, 173, 11, 169, 146, 113, 239, 202, 62, 236, 147, 238, 249, 235, 119, 4, 205, 184, 247, 62, 132,
            222, 143, 206, 136, 97, 178, 54, 85, 163, 141, 250, 135, 228, 201, 113, 65, 235, 183, 197, 213, 30, 53, 25,
            9, 7, 122, 54, 82, 118, 196, 228, 68, 76, 142, 122, 95, 244, 161, 81, 173, 154, 236, 170, 9, 31, 166, 180,
            30, 169, 97, 218, 90, 113, 100, 181, 231, 195, 146, 37, 217, 85, 63, 135, 186, 189, 82, 15, 51, 243, 234,
            69, 213, 139, 58, 191, 31, 209, 123, 33, 215, 124, 96, 210, 14, 121, 191, 166, 107, 131, 11, 175, 134, 72,
            121, 85, 13, 222, 56, 26, 93, 23, 108, 42, 148, 234, 166, 96, 107, 170, 52, 168, 126, 71, 143, 238, 169, 83,
            98, 92, 44, 31, 65, 172, 193, 217, 62, 153, 47, 234, 197, 138, 236, 5, 90, 72, 169, 246, 164, 183, 42, 97,
            149, 177, 118, 180, 142, 132, 181, 69, 136, 196, 194, 245, 55, 64, 37, 184, 135, 249, 144, 132, 89, 34, 244,
            17, 220, 133, 179, 197, 138, 241, 23, 228, 73, 161, 142, 224, 168, 82, 35, 135, 36, 54, 209, 102, 73, 186,
            124, 122, 44, 80, 93, 0, 225, 115, 68, 80, 36, 174, 42, 100, 139, 25, 157, 24, 53, 124, 188, 96, 175, 114,
            92, 33, 169, 199, 64, 180, 71, 251, 172, 126, 64, 122, 141, 92, 243, 172, 234, 235, 23, 188, 212, 130, 217,
            227, 166, 58, 154, 145, 124, 132, 148, 113, 44, 165, 148, 246, 66, 82, 201, 250, 39, 176, 60, 165, 189, 6,
            150, 9, 204, 10, 244, 112, 91, 178, 233, 125, 48, 92, 75, 54, 212, 116, 194, 226, 161, 132, 164, 30, 138,
            179, 231, 84, 14, 154, 36, 182, 192, 121, 208, 242, 185, 137, 96, 11, 189, 24, 224, 146, 161, 77, 216, 238,
            208, 131, 149, 220, 85, 26, 106, 212, 93, 45, 212, 83, 198, 37, 155, 82, 30, 35, 120, 110, 89, 92, 16, 33,
            11, 193, 88, 38, 174, 42, 37, 104, 52, 224, 83, 142, 11, 129, 239, 217, 87, 137, 178, 45, 146, 66, 245, 32,
            165, 2, 34, 183, 26, 89, 43, 193, 237, 1, 180, 36, 14, 13, 167, 70, 10, 1, 134, 194, 102, 18, 20, 206, 219,
            22, 57, 174, 220, 28, 250, 80, 139, 183, 214, 94, 96, 178, 185, 37, 204, 107, 1, 150, 164, 144, 20, 82, 35,
            253, 204, 249, 89, 141, 134, 14, 228, 20, 236, 129, 167, 16, 231, 86, 45, 225, 112, 206, 245, 238, 9, 74,
            213, 242, 49, 179, 4, 106, 62, 3, 216, 157, 218, 200, 64, 73, 46, 20, 142, 214, 213, 33, 42, 239, 8, 174,
            44, 162, 22, 190, 188, 212, 191, 250, 177, 218, 98, 185, 26, 12, 162, 212, 247, 184, 123, 109, 47, 176, 16,
            172, 149, 13, 80, 3, 91, 85, 188, 197, 181, 87, 69, 178, 143, 208, 139, 95, 225, 28, 43, 200, 113, 172, 204,
            58, 22, 168, 77, 47, 54, 127, 75, 73, 171, 16, 110, 109, 190, 45, 145, 149, 116, 148, 51, 245, 194, 242,
            170, 232, 145, 185, 155, 136, 187, 65, 167, 214, 82, 170, 158, 173, 25, 189, 48, 119, 19, 197, 59, 171, 211,
            106, 169, 20, 68, 13, 16, 7, 58, 91, 66, 116, 205, 226, 125, 88, 26, 163, 15, 70, 66, 114, 230, 4, 83, 232,
            6, 15, 66, 197, 123, 15, 44, 6, 245, 48, 177, 239, 130, 206, 195, 14, 223, 50, 92, 159, 162, 57, 166, 195,
            124, 82, 66, 91, 12, 202, 51, 191, 242, 80, 125, 7, 145, 239, 89, 54, 23, 73, 169, 45, 117, 25, 127, 137,
            57, 190, 123, 194, 225, 169, 41, 182, 254, 125, 155, 126, 106, 3, 49, 180, 202, 193, 93, 30, 11, 108, 127,
            40, 109, 251, 4, 120, 88, 146, 161, 79, 111, 114, 235, 91, 160, 151, 109, 13, 245, 244, 86, 109, 53, 155,
            216, 71, 2, 56, 228, 49, 183, 102, 228, 166, 81, 207, 251, 72, 2, 79, 83, 80, 193, 83, 95, 113, 232, 229,
            239, 161, 164, 91, 155, 246, 26, 223, 158, 138, 7, 195, 84, 95, 112, 161, 132, 27, 176, 63, 1, 120, 105,
            112, 241, 32, 65, 168, 229, 175, 225, 240, 14, 2, 193, 167, 106, 134, 192, 65, 240, 184, 30, 44, 73, 100,
            234, 224, 171, 17, 134, 217, 151, 57, 38, 227, 132, 141, 31, 43, 17, 26, 152, 245, 234, 55, 45, 43, 184,
            182, 143, 26, 146, 227, 133, 252, 122, 104, 130, 123, 237, 47, 102, 255, 246, 147, 31, 124, 240, 254, 135,
            31, 221, 254, 25, 61, 254, 231, 63, 166, 13, 199, 255, 159, 208, 203, 244, 167, 191, 121, 184, 189, 253, 17,
            159, 126, 183, 116, 242, 167, 211, 135, 179, 231, 178, 58, 207, 203, 199, 36, 125, 253, 192, 253, 202, 59,
            250, 177, 231, 254, 50, 251, 151, 255, 53, 253, 217, 65, 175, 127, 165, 215, 247, 221, 255, 1
        };

        [Fact]
        public void ReadFromStream_IsCorrect() {
            using (var stream = new MemoryStream(Bytes)) {
                var packet = (SectionPacket)Packet.ReadFromStream(stream, PacketContext.Server);

                packet.IsSectionCompressed.Should().BeTrue();
                packet.StartTileX.Should().Be(4200);
                packet.StartTileY.Should().Be(300);
                packet.SectionWidth.Should().Be(200);
                packet.SectionHeight.Should().Be(150);
                packet.SectionTileEntities.Should().HaveCount(7);
            }
        }

        [Fact]
        public void DeserializeAndSerialize_SamePacket() {
            using (var stream = new MemoryStream(Bytes))
            using (var stream2 = new MemoryStream())
            using (var stream3 = new MemoryStream()) {
                var packet = (SectionPacket)Packet.ReadFromStream(stream, PacketContext.Server);

                packet.WriteToStream(stream2, PacketContext.Server);

                stream2.Position = 0;
                var packet2 = (SectionPacket)Packet.ReadFromStream(stream2, PacketContext.Server);

                packet2.WriteToStream(stream3, PacketContext.Server);

                stream2.ToArray().Should().BeEquivalentTo(stream3.ToArray());
            }
        }
    }
}
