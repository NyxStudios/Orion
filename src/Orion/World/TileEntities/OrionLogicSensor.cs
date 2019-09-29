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

namespace Orion.World.TileEntities {
    internal sealed class OrionLogicSensor : OrionTileEntity<Terraria.GameContent.Tile_Entities.TELogicSensor>,
                                             ILogicSensor {
        public LogicSensorType LogicSensorType {
            get => (LogicSensorType)Wrapped.logicCheck;
            set => Wrapped.logicCheck = (Terraria.GameContent.Tile_Entities.TELogicSensor.LogicCheckType)value;
        }

        public bool IsActivated {
            get => Wrapped.On;
            set => Wrapped.On = value;
        }

        public OrionLogicSensor(Terraria.GameContent.Tile_Entities.TELogicSensor terrariaLogicSensor)
            : base(terrariaLogicSensor) { }
    }
}