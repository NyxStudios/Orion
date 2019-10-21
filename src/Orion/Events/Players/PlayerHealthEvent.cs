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
using Orion.Packets.Players;
using Orion.Players;
using Orion.Utils;

namespace Orion.Events.Players {
    /// <summary>
    /// An event that occurs when a player updates their health. This event can be canceled and modified.
    /// </summary>
    [EventArgs("player-health")]
    public sealed class PlayerHealthEvent : PlayerEvent, ICancelable, IDirtiable {
        private readonly PlayerHealthPacket _packet;

        /// <inheritdoc/>
        public bool IsDirty => _packet.IsDirty;

        /// <inheritdoc/>
        public string? CancellationReason { get; set; }

        /// <summary>
        /// Gets or sets the player's health.
        /// </summary>
        /// <value>The player's health.</value>
        public short Health {
            get => _packet.Health;
            set => _packet.Health = value;
        }

        /// <summary>
        /// Gets or sets the player's maximum health.
        /// </summary>
        /// <value>The player's maximum health.</value>
        public short MaxHealth {
            get => _packet.MaxHealth;
            set => _packet.MaxHealth = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerHealthEvent"/> class with the specified player and
        /// packet.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="packet">The packet.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="player"/> or <paramref name="packet"/> are <see langword="null"/>.
        /// </exception>
        public PlayerHealthEvent(IPlayer player, PlayerHealthPacket packet) : base(player) {
            _packet = packet ?? throw new ArgumentNullException(nameof(packet));
        }

        /// <inheritdoc/>
        public void Clean() => _packet.Clean();
    }
}
