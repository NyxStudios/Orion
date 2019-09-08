﻿using System;
using System.ComponentModel;
using Orion.Networking.Packets;

namespace Orion.Networking.Events {
    /// <summary>
    /// Provides data for the <see cref="INetworkService.SendingPacket"/> event.
    /// </summary>
    public sealed class SendingPacketEventArgs : HandledEventArgs {
        private Packet _packet;

        /// <summary>
        /// Gets the packet's receiver.
        /// </summary>
        public Terraria.RemoteClient Receiver { get; }

        /// <summary>
        /// Gets or sets the packet that is being sent.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
        public Packet Packet {
            get => _packet;
            set {
                _packet = value ?? throw new ArgumentNullException(nameof(value));
                MarkPacketAsDirty();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the packet is dirty.
        /// </summary>
        public bool IsPacketDirty { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendingPacketEventArgs"/> class with the specified receiver
        /// and packet.
        /// </summary>
        /// <param name="receiver">The packet's receiver.</param>
        /// <param name="packet">The packet that is being received.</param>
        /// <exception cref="ArgumentNullException">
        /// Either <paramref name="receiver"/> is <c>null</c> or <paramref name="packet"/> is <c>null</c>.
        /// </exception>
        public SendingPacketEventArgs(Terraria.RemoteClient receiver, Packet packet) {
            Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
            _packet = packet ?? throw new ArgumentNullException(nameof(packet));
        }

        /// <summary>
        /// Marks the packet as being dirty.
        /// </summary>
        public void MarkPacketAsDirty() => IsPacketDirty = true;
    }
}
