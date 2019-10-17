﻿// Copyright (c) 2019 Pryaxis & Orion Contributors
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
using Orion.Packets;
using Orion.Utils;

namespace Orion.Events.Players {
    /// <summary>
    /// Provides data for packet-related events.
    /// </summary>
    public abstract class PacketEventArgs : EventArgs, IDirtiable {
        private Packet _packet;
        private bool _isDirty;

        /// <inheritdoc/>
        public bool IsDirty => _isDirty || Packet.IsDirty;

        /// <summary>
        /// Gets or sets the packet involved in the event.
        /// </summary>
        /// <value>The packet involved in the event.</value>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
        public Packet Packet {
            get => _packet;
            set {
                _packet = value ?? throw new ArgumentNullException(nameof(value));
                _isDirty = true;
            }
        }

        private protected PacketEventArgs(Packet packet) {
            _packet = packet ?? throw new ArgumentNullException(nameof(packet));
        }

        /// <inheritdoc/>
        public void Clean() {
            _isDirty = false;
            Packet.Clean();
        }
    }
}