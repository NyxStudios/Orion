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
using Orion.Entities;

namespace Orion.Events.Entities {
    /// <summary>
    /// Provides data for the <see cref="IPlayerService.PlayerDisconnect"/> event.
    /// </summary>
    public sealed class PlayerDisconnectEventArgs : PlayerEventArgs {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerDisconnectEventArgs"/> class with the specified player.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <exception cref="ArgumentNullException"><paramref name="player"/> is <c>null</c>.</exception>
        public PlayerDisconnectEventArgs(IPlayer player) : base(player) { }
    }
}