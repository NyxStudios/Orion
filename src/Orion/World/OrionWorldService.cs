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

using System.Runtime.CompilerServices;
using Orion.Framework;
using Orion.World.Tiles;
using Serilog;

namespace Orion.World {
    internal sealed class OrionWorldService : OrionService, IWorldService {
        private readonly TileCollection _tileCollection;

        public OrionWorldService(OrionKernel kernel, ILogger log) : base(kernel, log) {
            // Check if `Terraria.Main.tile` is already a `TileCollection`. This is only useful in tests, where
            // multiple `OrionWorldService` instances are constructed.
            if (Terraria.Main.tile is TileCollection tileCollection) {
                _tileCollection = tileCollection;
            } else {
                _tileCollection = new TileCollection();
                Terraria.Main.tile = _tileCollection;
            }
        }

        public IWorld World => _tileCollection.World;

        public override void Dispose() { }

        // This class does not implement `IDisposable` as it is a static replacement.
        private class TileCollection : OTAPI.Tile.ITileCollection {
            private IWorld? _world;

            public unsafe OTAPI.Tile.ITile this[int x, int y] {
                get => new TileAdapter(ref World[x, y]);
                set => this[x, y].CopyFrom(value);
            }

            public int Width => Terraria.Main.maxTilesX;
            public int Height => Terraria.Main.maxTilesY;
            public IWorld World {
                get {
                    // Lazily initialize the world so that a world of minimum size can be created.
                    if (_world is null) {
                        _world = new OrionWorld(Terraria.Main.maxTilesX, Terraria.Main.maxTilesY);
                    }

                    return _world;
                }
            }
        }

        // An adapter class to make a `Tile` reference compatible with `OTAPI.Tile.ITile`. Unfortunately, this means we
        // generate a lot of garbage, but this is the best we can really do.
        private sealed unsafe class TileAdapter : OTAPI.Tile.ITile {
            private readonly Tile* _tile;

            public TileAdapter(ref Tile tile) {
                _tile = (Tile*)Unsafe.AsPointer(ref tile);
            }

            public ushort type {
                get => (ushort)_tile->BlockId;
                set => _tile->BlockId = (BlockId)value;
            }

            public ushort wall {
                get => (ushort)_tile->WallId;
                set => _tile->WallId = (WallId)value;
            }

            public byte liquid {
                get => _tile->LiquidAmount;
                set => _tile->LiquidAmount = value;
            }

            public short frameX {
                get => _tile->BlockFrameX;
                set => _tile->BlockFrameX = value;
            }

            public short frameY {
                get => _tile->BlockFrameY;
                set => _tile->BlockFrameY = value;
            }

            public short sTileHeader {
                get => _tile->_sTileHeader;
                set => _tile->_sTileHeader = value;
            }

            public byte bTileHeader {
                get => _tile->_bTileHeader;
                set => _tile->_bTileHeader = value;
            }

            public byte bTileHeader3 {
                get => _tile->_bTileHeader3;
                set => _tile->_bTileHeader3 = value;
            }

            // No-ops since these are never used.
            public int collisionType => 0;
            public byte bTileHeader2 { get => 0; set { } }

            public object Clone() => MemberwiseClone();

            public byte color() => (byte)_tile->BlockColor;
            public void color(byte color) => _tile->BlockColor = (PaintColor)color;
            public bool active() => _tile->IsBlockActive;
            public void active(bool active) => _tile->IsBlockActive = active;
            public bool inActive() => _tile->IsBlockActuated;
            public void inActive(bool inActive) => _tile->IsBlockActuated = inActive;
            public bool nactive() => (sTileHeader & 0x60) == 0x20;
            public bool wire() => _tile->HasRedWire;
            public void wire(bool wire) => _tile->HasRedWire = wire;

            public bool wire2() => _tile->HasBlueWire;
            public void wire2(bool wire2) => _tile->HasBlueWire = wire2;
            public bool wire3() => _tile->HasGreenWire;
            public void wire3(bool wire3) => _tile->HasGreenWire = wire3;
            public bool halfBrick() => _tile->IsBlockHalved;
            public void halfBrick(bool halfBrick) => _tile->IsBlockHalved = halfBrick;
            public bool actuator() => _tile->HasActuator;
            public void actuator(bool actuator) => _tile->HasActuator = actuator;
            public byte slope() => (byte)_tile->Slope;
            public void slope(byte slope) => _tile->Slope = (Slope)slope;

            public byte wallColor() => (byte)_tile->WallColor;
            public void wallColor(byte wallColor) => _tile->WallColor = (PaintColor)wallColor;
            public bool lava() => (_tile->_bTileHeader & 0x20) == 0x20;
            public void lava(bool lava) {
                if (lava) {
                    _tile->_bTileHeader = (byte)((_tile->_bTileHeader & 0x9F) | 0x20);
                } else {
                    _tile->_bTileHeader &= 223;
                }
            }
            public bool honey() => (_tile->_bTileHeader & 0x40) == 0x40;
            public void honey(bool honey) {
                if (honey) {
                    _tile->_bTileHeader = (byte)((_tile->_bTileHeader & 0x9F) | 0x40);
                } else {
                    _tile->_bTileHeader &= 191;
                }
            }
            public byte liquidType() => (byte)_tile->Liquid;
            public void liquidType(int liquidType) => _tile->Liquid = (Liquid)liquidType;
            public bool wire4() => _tile->HasYellowWire;
            public void wire4(bool wire4) => _tile->HasYellowWire = wire4;

            public byte frameNumber() => _tile->BlockFrameNumber;
            public void frameNumber(byte frameNumber) => _tile->BlockFrameNumber = frameNumber;
            public bool checkingLiquid() => _tile->IsCheckingLiquid;
            public void checkingLiquid(bool checkingLiquid) => _tile->IsCheckingLiquid = checkingLiquid;
            public bool skipLiquid() => _tile->ShouldSkipLiquid;
            public void skipLiquid(bool skipLiquid) => _tile->ShouldSkipLiquid = skipLiquid;

            public void CopyFrom(OTAPI.Tile.ITile from) {
                if (from is null) {
                    ClearEverything();
                    return;
                }

                if (from is TileAdapter adapter) {
                    Unsafe.CopyBlockUnaligned(_tile, adapter._tile, 13);
                } else {
                    type = from.type;
                    wall = from.wall;
                    liquid = from.liquid;
                    sTileHeader = from.sTileHeader;
                    bTileHeader = from.bTileHeader;
                    bTileHeader3 = from.bTileHeader3;
                    frameX = from.frameX;
                    frameY = from.frameY;
                }
            }

            public bool isTheSameAs(OTAPI.Tile.ITile compTile) {
                if (compTile is null) {
                    return false;
                }

                if (compTile is TileAdapter adapter) {
                    const uint bottomMask = 0b_00000000_11111111_11111111_11111111;
                    var mask = _tile->LiquidAmount == 0 ? bottomMask : bottomMask | ~Tile.LiquidMask;
                    if ((_tile->_header & mask) != (adapter._tile->_header & mask)) {
                        return false;
                    }

                    if (_tile->IsBlockActive) {
                        if (_tile->BlockId != adapter._tile->BlockId) {
                            return false;
                        }

                        if (_tile->BlockId.HasFrames() && _tile->_blockFrames != adapter._tile->_blockFrames) {
                            return false;
                        }
                    }

                    if (_tile->WallId != adapter._tile->WallId || _tile->LiquidAmount != adapter._tile->LiquidAmount) {
                        return false;
                    }
                } else {
                    if (_tile->_sTileHeader != compTile.sTileHeader) {
                        return false;
                    }

                    if (active()) {
                        if (_tile->BlockId != (BlockId)compTile.type) {
                            return false;
                        }

                        if (_tile->BlockId.HasFrames() &&
                                (_tile->BlockFrameX != compTile.frameX || _tile->BlockFrameY != compTile.frameY)) {
                            return false;
                        }
                    }

                    if (_tile->WallId != (WallId)compTile.wall || _tile->LiquidAmount != compTile.liquid) {
                        return false;
                    }

                    if (_tile->LiquidAmount == 0) {
                        if (_tile->WallColor != (PaintColor)compTile.wallColor()) {
                            return false;
                        }

                        if (_tile->HasYellowWire != compTile.wire4()) {
                            return false;
                        }
                    } else if (_tile->_bTileHeader != compTile.bTileHeader) {
                        return false;
                    }
                }

                return true;
            }

            public void ClearEverything() => Unsafe.InitBlockUnaligned(_tile, 0, 13);
            public void ClearMetadata() => Unsafe.InitBlockUnaligned(((byte*)_tile) + 4, 0, 9);
            public void ClearTile() {
                var mask = Tile.SlopeMask | Tile.IsBlockHalvedMask | Tile.IsBlockActiveMask | Tile.IsBlockActuatedMask;
                _tile->_header &= ~mask;
            }
            public void Clear(Terraria.DataStructures.TileDataType types) {
                if (types == Terraria.DataStructures.TileDataType.All) {
                    ClearEverything();
                    return;
                }

                if ((types & Terraria.DataStructures.TileDataType.Tile) != 0) {
                    _tile->BlockId = BlockId.Dirt;
                    _tile->IsBlockActive = false;
                    _tile->_blockFrames = 0;
                }

                if ((types & Terraria.DataStructures.TileDataType.TilePaint) != 0) {
                    _tile->BlockColor = PaintColor.None;
                }

                if ((types & Terraria.DataStructures.TileDataType.Wall) != 0) {
                    _tile->WallId = WallId.None;
                }

                if ((types & Terraria.DataStructures.TileDataType.WallPaint) != 0) {
                    _tile->WallColor = PaintColor.None;
                }

                if ((types & Terraria.DataStructures.TileDataType.Liquid) != 0) {
                    var mask = Tile.LiquidMask | Tile.IsCheckingLiquidMask;
                    _tile->LiquidAmount = 0;
                    _tile->_header &= ~mask;
                }

                if ((types & Terraria.DataStructures.TileDataType.Wiring) != 0) {
                    var mask =
                        Tile.HasRedWireMask | Tile.HasBlueWireMask | Tile.HasGreenWireMask | Tile.HasYellowWireMask;
                    _tile->_header &= ~mask;
                }

                if ((types & Terraria.DataStructures.TileDataType.Actuator) != 0) {
                    var mask = Tile.HasActuatorMask | Tile.IsBlockActuatedMask;
                    _tile->_header &= ~mask;
                }

                if ((types & Terraria.DataStructures.TileDataType.Slope) != 0) {
                    var mask = Tile.SlopeMask | Tile.IsBlockHalvedMask;
                    _tile->_header &= ~mask;
                }
            }

            public void ResetToType(ushort type) {
                ClearMetadata();
                this.type = type;
                _tile->IsBlockActive = true;
            }

            public bool topSlope() => IsSlope(Slope.TopRight, Slope.TopLeft);
            public bool bottomSlope() => IsSlope(Slope.BottomRight, Slope.BottomLeft);
            public bool leftSlope() => IsSlope(Slope.TopLeft, Slope.BottomLeft);
            public bool rightSlope() => IsSlope(Slope.TopRight, Slope.BottomRight);
            public bool HasSameSlope(OTAPI.Tile.ITile tile) =>
                (_tile->_sTileHeader & 29696) == (tile.sTileHeader & 29696);

            public int blockType() {
                if (halfBrick()) {
                    return 1;
                }

                var slope = this.slope();
                return slope > 0 ? slope + 1 : 0;
            }

            // No-ops since these are never used.
            public Microsoft.Xna.Framework.Color actColor(Microsoft.Xna.Framework.Color oldColor) => default;
            public void actColor(ref Microsoft.Xna.Framework.Vector3 oldColor) { }
            public byte wallFrameNumber() => 0;
            public void wallFrameNumber(byte wallFrameNumber) { }
            public int wallFrameX() => 0;
            public void wallFrameX(int wallFrameX) { }
            public int wallFrameY() => 0;
            public void wallFrameY(int wallFrameY) { }

            private bool IsSlope(Slope slope1, Slope slope2) {
                var slope = (Slope)this.slope();
                return slope == slope1 || slope == slope2;
            }
        }
    }
}
