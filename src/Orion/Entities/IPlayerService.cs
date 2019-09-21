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

using Orion.Events;
using Orion.Events.Entities;
using Orion.Utils;

namespace Orion.Entities {
    /// <summary>
    /// Represents a player service. Provides access to player-related events and methods.
    /// </summary>
    public interface IPlayerService : IReadOnlyArray<IPlayer> {
        /// <summary>
        /// Gets or sets the event handlers that run when a player connects. This event can be canceled.
        /// </summary>
        EventHandlerCollection<PlayerConnectEventArgs> PlayerConnect { get; set; }

        /// <summary>
        /// Gets or sets the event handlers that run when a player disconnects.
        /// </summary>
        EventHandlerCollection<PlayerDisconnectEventArgs> PlayerDisconnect { get; set; }
    }
}
