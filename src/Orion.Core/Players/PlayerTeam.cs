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

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Orion.Core.DataStructures;

namespace Orion.Core.Players {
    /// <summary>
    /// Specifies a player's team.
    /// </summary>
    public enum PlayerTeam : byte {
        /// <summary>
        /// Indicates no team.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates the red team.
        /// </summary>
        Red = 1,

        /// <summary>
        /// Indicates the green team.
        /// </summary>
        Green = 2,

        /// <summary>
        /// Indicates the blue team.
        /// </summary>
        Blue = 3,

        /// <summary>
        /// Indicates the yellow team.
        /// </summary>
        Yellow = 4,

        /// <summary>
        /// Indicates the pink team.
        /// </summary>
        Pink = 5
    }

    /// <summary>
    /// Provides extensions for the <see cref="PlayerTeam"/> enumeration.
    /// </summary>
    public static class PlayerTeamExtensions {
        private static readonly IDictionary<PlayerTeam, Color3> _colors = new Dictionary<PlayerTeam, Color3> {
            [PlayerTeam.Red] = new Color3(0xda, 0x3b, 0x3b),
            [PlayerTeam.Green] = new Color3(0x3b, 0xda, 0x55),
            [PlayerTeam.Blue] = new Color3(0x3b, 0x95, 0xda),
            [PlayerTeam.Yellow] = new Color3(0xf2, 0xdd, 0x64),
            [PlayerTeam.Pink] = new Color3(0xe0, 0x64, 0xf2)
        };

        /// <summary>
        /// Returns the color of the <paramref name="team"/>.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <returns>The color of the <paramref name="team"/>.</returns>
        [Pure]
        public static Color3 Color(this PlayerTeam team) =>
            _colors.TryGetValue(team, out var color) ? color : Color3.White;
    }
}