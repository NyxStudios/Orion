﻿using System.IO;

namespace Orion.Networking.Packets {
    /// <summary>
    /// Packet sent to the client to update a player's status.
    /// </summary>
    public sealed class UpdatePlayerStatusPacket : Packet {
        /// <summary>
        /// Gets or sets the player index.
        /// </summary>
        public byte PlayerIndex { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player is active.
        /// </summary>
        public bool IsActive { get; set; }

        private protected override void ReadFromReader(BinaryReader reader, ushort packetLength) {
            PlayerIndex = reader.ReadByte();
            IsActive = reader.ReadByte() == 1;
        }

        private protected override void WriteToWriter(BinaryWriter writer) {
            writer.Write(PlayerIndex);
            writer.Write(IsActive);
        }
    }
}