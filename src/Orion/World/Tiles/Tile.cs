﻿using Microsoft.Xna.Framework;
using OTAPI.Tile;

namespace Orion.World.Tiles {
    /// <summary>
    /// Provides the base class for a tile.
    /// </summary>
    public abstract class Tile : ITile {
        /// <summary>
        /// Gets or sets the block type.
        /// </summary>
        /// <remarks>This corresponds to OTAPI.Tile.ITile.type.</remarks>
        public abstract BlockType BlockType { get; set; }

        /// <summary>
        /// Gets or sets the wall type.
        /// </summary>
        /// <remarks>This corresponds to OTAPI.Tile.ITile.wall.</remarks>
        public abstract WallType WallType { get; set; }

        /// <summary>
        /// Gets or sets the liquid amount.
        /// </summary>
        /// <remarks>This corresponds to OTAPI.Tile.ITile.liquid.</remarks>
        public abstract byte LiquidAmount { get; set; }

        /// <summary>
        /// Gets or sets the main tile header.
        /// </summary>
        /// <remarks>This corresponds to OTAPI.Tile.ITile.sTileHeader.</remarks>
        public abstract short TileHeader { get; set; }

        /// <summary>
        /// Gets or sets the second tile header.
        /// </summary>
        /// <remarks>This corresponds to OTAPI.Tile.ITile.bTileHeader.</remarks>
        public abstract byte TileHeader2 { get; set; }

        /// <summary>
        /// Gets or sets the third tile header.
        /// </summary>
        /// <remarks>This corresponds to OTAPI.Tile.ITile.bTileHeader2.</remarks>
        public abstract byte TileHeader3 { get; set; }

        /// <summary>
        /// Gets or sets the fourth tile header.
        /// </summary>
        /// <remarks>This corresponds to OTAPI.Tile.ITile.bTileHeader3.</remarks>
        public abstract byte TileHeader4 { get; set; }

        /// <summary>
        /// Gets or sets the block X frame.
        /// </summary>
        /// <remarks>This corresponds to OTAPI.Tile.ITile.frameX.</remarks>
        public abstract short BlockFrameX { get; set; }

        /// <summary>
        /// Gets or sets the block Y frame.
        /// </summary>
        /// <remarks>This corresponds to OTAPI.Tile.ITile.frameY.</remarks>
        public abstract short BlockFrameY { get; set; }

        /// <summary>
        /// Gets or sets the block's color.
        /// </summary>
        /// <remarks>This value is usually stored as bits 0-4 of <see cref="TileHeader"/>.</remarks>
        public PaintColor BlockColor {
            get => (PaintColor)((ITile)this).color();
            set => ((ITile)this).color((byte)value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the block is active.
        /// </summary>
        /// <remarks>This value is usually stored as bit 5 of <see cref="TileHeader"/>.</remarks>
        public bool IsBlockActive {
            get => ((ITile)this).active();
            set => ((ITile)this).active(value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the block is acutuated.
        /// </summary>
        /// <remarks>This value is usually stored as bit 6 of <see cref="TileHeader"/>.</remarks>
        public bool IsBlockActuated {
            get => ((ITile)this).inActive();
            set => ((ITile)this).inActive(value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the tile has red wire.
        /// </summary>
        /// <remarks>This value is usually stored as bit 7 of <see cref="TileHeader"/>.</remarks>
        public bool HasRedWire {
            get => ((ITile)this).wire();
            set => ((ITile)this).wire(value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the tile has blue wire.
        /// </summary>
        /// <remarks>This value is usually stored as bit 8 of <see cref="TileHeader"/>.</remarks>
        public bool HasBlueWire {
            get => ((ITile)this).wire2();
            set => ((ITile)this).wire2(value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the tile has green wire.
        /// </summary>
        /// <remarks>This value is usually stored as bit 9 of <see cref="TileHeader"/>.</remarks>
        public bool HasGreenWire {
            get => ((ITile)this).wire3();
            set => ((ITile)this).wire3(value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the block is halved.
        /// </summary>
        /// <remarks>This value is usually stored as bit 10 of <see cref="TileHeader"/>.</remarks>
        public bool IsBlockHalved {
            get => ((ITile)this).halfBrick();
            set => ((ITile)this).halfBrick(value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the tile has an actuator.
        /// </summary>
        /// <remarks>This value is usually stored as bit 11 of <see cref="TileHeader"/>.</remarks>
        public bool HasActuator {
            get => ((ITile)this).actuator();
            set => ((ITile)this).actuator(value);
        }

        /// <summary>
        /// Gets or sets the slope type.
        /// </summary>
        /// <remarks>This value is usually stored as bits 12-14 of <see cref="TileHeader"/>.</remarks>
        public SlopeType SlopeType {
            get => (SlopeType)((ITile)this).slope();
            set => ((ITile)this).slope((byte)value);
        }

        /// <summary>
        /// Gets or sets the wall's color.
        /// </summary>
        /// <remarks>This value is usually stored as bits 0-4 of <see cref="TileHeader2"/>.</remarks>
        public PaintColor WallColor {
            get => (PaintColor)((ITile)this).wallColor();
            set => ((ITile)this).wallColor((byte)value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the liquid is lava.
        /// </summary>
        /// <remarks>This value is usually stored as bit 5 of <see cref="TileHeader2"/>.</remarks>
        public bool IsLava {
            get => ((ITile)this).lava();
            set => ((ITile)this).lava(value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the liquid is honey.
        /// </summary>
        /// <remarks>This value is usually stored as bit 6 of <see cref="TileHeader2"/>.</remarks>
        public bool IsHoney {
            get => ((ITile)this).honey();
            set => ((ITile)this).honey(value);
        }

        /// <summary>
        /// Gets or sets the liquid type.
        /// </summary>
        /// <remarks>This value is usually stored as bits 5-6 of <see cref="TileHeader2"/>.</remarks>
        public LiquidType LiquidType {
            get => (LiquidType)((ITile)this).liquidType();
            set => ((ITile)this).liquidType((int)value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the tile has yellow wire.
        /// </summary>
        /// <remarks>This value is usually stored as bit 7 of <see cref="TileHeader2"/>.</remarks>
        public bool HasYellowWire {
            get => ((ITile)this).wire4();
            set => ((ITile)this).wire4(value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the tile is checking liquid.
        /// </summary>
        /// <remarks>This value is usually stored as bit 3 of <see cref="TileHeader4"/>.</remarks>
        public bool IsCheckingLiquid {
            get => ((ITile)this).checkingLiquid();
            set => ((ITile)this).checkingLiquid(value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the tile should skip liquids.
        /// </summary>
        /// <remarks>This value is usually stored as bit 4 of <see cref="TileHeader4"/>.</remarks>
        public bool ShouldSkipLiquid {
            get => ((ITile)this).skipLiquid();
            set => ((ITile)this).skipLiquid(value);
        }

        #region ITile implementation

        int ITile.collisionType {
            get {
                if (!((ITile)this).active()) return 0;
                if (((ITile)this).halfBrick()) return 2;

                if (((ITile)this).slope() > 0) {
                    return (2 + ((ITile)this).slope());
                }

                if (Terraria.Main.tileSolid[((ITile)this).type] && !Terraria.Main.tileSolidTop[((ITile)this).type]) {
                    return 1;
                }

                return -1;
            }
        }

        ushort ITile.type {
            get => (ushort)BlockType;
            set => BlockType = (BlockType)value;
        }

        byte ITile.wall {
            get => (byte)WallType;
            set => WallType = (WallType)value;
        }

        byte ITile.liquid {
            get => LiquidAmount;
            set => LiquidAmount = value;
        }

        short ITile.sTileHeader {
            get => TileHeader;
            set => TileHeader = value;
        }

        byte ITile.bTileHeader {
            get => TileHeader2;
            set => TileHeader2 = value;
        }

        byte ITile.bTileHeader2 {
            get => TileHeader3;
            set => TileHeader3 = value;
        }

        byte ITile.bTileHeader3 {
            get => TileHeader4;
            set => TileHeader4 = value;
        }

        short ITile.frameX {
            get => BlockFrameX;
            set => BlockFrameX = value;
        }

        short ITile.frameY {
            get => BlockFrameY;
            set => BlockFrameY = value;
        }

        object ITile.Clone() {
            return MemberwiseClone();
        }

        void ITile.ClearEverything() {
            ((ITile)this).type = 0;
            ((ITile)this).wall = 0;
            ((ITile)this).liquid = 0;
            ((ITile)this).sTileHeader = 0;
            ((ITile)this).bTileHeader = 0;
            ((ITile)this).bTileHeader2 = 0;
            ((ITile)this).bTileHeader3 = 0;
            ((ITile)this).frameX = 0;
            ((ITile)this).frameY = 0;
        }

        void ITile.ClearTile() {
            ((ITile)this).slope(0);
            ((ITile)this).halfBrick(false);
            ((ITile)this).active(false);
        }

        void ITile.CopyFrom(ITile from) {
            ((ITile)this).type = from.type;
            ((ITile)this).wall = from.wall;
            ((ITile)this).liquid = from.liquid;
            ((ITile)this).sTileHeader = from.sTileHeader;
            ((ITile)this).bTileHeader = from.bTileHeader;
            ((ITile)this).bTileHeader2 = from.bTileHeader2;
            ((ITile)this).bTileHeader3 = from.bTileHeader3;
            ((ITile)this).frameX = from.frameX;
            ((ITile)this).frameY = from.frameY;
        }

        bool ITile.isTheSameAs(ITile compTile) {
            if (compTile == null) return false;
            if (((ITile)this).sTileHeader != compTile.sTileHeader) return false;

            if (((ITile)this).active()) {
                if (((ITile)this).type != compTile.type) return false;

                if (Terraria.Main.tileFrameImportant[((ITile)this).type] &&
                    (((ITile)this).frameX != compTile.frameX || ((ITile)this).frameY != compTile.frameY)) {
                    return false;
                }
            }

            if (((ITile)this).wall != compTile.wall || ((ITile)this).liquid != compTile.liquid) {
                return false;
            }

            if (compTile.liquid == 0) {
                if (((ITile)this).wallColor() != compTile.wallColor()) return false;
                if (((ITile)this).wire4() != compTile.wire4()) return false;
            } else if (((ITile)this).bTileHeader != compTile.bTileHeader) {
                return false;
            }

            return true;
        }

        int ITile.blockType() {
            if (((ITile)this).halfBrick()) return 1;

            int num = ((ITile)this).slope();
            if (num > 0) {
                num++;
            }

            return num;
        }

        void ITile.liquidType(int liquidType) {
            if (liquidType == 0) {
                ((ITile)this).bTileHeader &= 159;
                return;
            }

            if (liquidType == 1) {
                ((ITile)this).lava(true);
                return;
            }

            if (liquidType == 2) {
                ((ITile)this).honey(true);
            }
        }

        byte ITile.liquidType() => (byte)((((ITile)this).bTileHeader & 96) >> 5);

        bool ITile.nactive() {
            int num = (((ITile)this).sTileHeader & 96);
            return num == 32;
        }

        // ReSharper disable once ParameterHidesMember
        void ITile.ResetToType(ushort type) {
            ((ITile)this).liquid = 0;
            ((ITile)this).sTileHeader = 32;
            ((ITile)this).bTileHeader = 0;
            ((ITile)this).bTileHeader2 = 0;
            ((ITile)this).bTileHeader3 = 0;
            ((ITile)this).frameX = 0;
            ((ITile)this).frameY = 0;
            ((ITile)this).type = type;
        }

        void ITile.ClearMetadata() {
            ((ITile)this).liquid = 0;
            ((ITile)this).sTileHeader = 0;
            ((ITile)this).bTileHeader = 0;
            ((ITile)this).bTileHeader2 = 0;
            ((ITile)this).bTileHeader3 = 0;
            ((ITile)this).frameX = 0;
            ((ITile)this).frameY = 0;
        }

        const double ActNum = 0.4;

        Color ITile.actColor(Color oldColor) {
            if (!((ITile)this).inActive()) return oldColor;

            return new Color
            (
                (byte)(ActNum * oldColor.R),
                (byte)(ActNum * oldColor.G),
                (byte)(ActNum * oldColor.B),
                oldColor.A
            );
        }

        bool ITile.topSlope() {
            byte b = ((ITile)this).slope();
            return b == 1 || b == 2;
        }

        bool ITile.bottomSlope() {
            byte b = ((ITile)this).slope();
            return b == 3 || b == 4;
        }

        bool ITile.leftSlope() {
            byte b = ((ITile)this).slope();
            return b == 2 || b == 4;
        }

        bool ITile.rightSlope() {
            byte b = ((ITile)this).slope();
            return b == 1 || b == 3;
        }

        bool ITile.HasSameSlope(ITile tile) => (((ITile)this).sTileHeader & 29696) == (tile.sTileHeader & 29696);
        byte ITile.wallColor() => (byte)(((ITile)this).bTileHeader & 31);

        void ITile.wallColor(byte wallColor) {
            if (wallColor > 30) {
                wallColor = 30;
            }

            ((ITile)this).bTileHeader = (byte)((((ITile)this).bTileHeader & 224) | wallColor);
        }

        bool ITile.lava() => (((ITile)this).bTileHeader & 32) == 32;

        void ITile.lava(bool lava) {
            if (lava) {
                ((ITile)this).bTileHeader = (byte)((((ITile)this).bTileHeader & 159) | 32);
                return;
            }

            ((ITile)this).bTileHeader &= 223;
        }

        bool ITile.honey() => (((ITile)this).bTileHeader & 64) == 64;

        void ITile.honey(bool honey) {
            if (honey) {
                ((ITile)this).bTileHeader = (byte)((((ITile)this).bTileHeader & 159) | 64);
                return;
            }

            ((ITile)this).bTileHeader &= 191;
        }

        bool ITile.wire4() => (((ITile)this).bTileHeader & 128) == 128;

        void ITile.wire4(bool wire4) {
            if (wire4) {
                ((ITile)this).bTileHeader |= 128;
                return;
            }

            ((ITile)this).bTileHeader &= 127;
        }

        int ITile.wallFrameX() => ((((ITile)this).bTileHeader2 & 15) * 36);

        void ITile.wallFrameX(int wallFrameX) {
            ((ITile)this).bTileHeader2 = (byte)((((ITile)this).bTileHeader2 & 240) | (wallFrameX / 36 & 15));
        }

        byte ITile.frameNumber() => (byte)((((ITile)this).bTileHeader2 & 48) >> 4);

        void ITile.frameNumber(byte frameNumber) {
            ((ITile)this).bTileHeader2 = (byte)((((ITile)this).bTileHeader2 & 207) | (frameNumber & 3) << 4);
        }

        byte ITile.wallFrameNumber() => (byte)((((ITile)this).bTileHeader2 & 192) >> 6);

        void ITile.wallFrameNumber(byte wallFrameNumber) {
            ((ITile)this).bTileHeader2 = (byte)((((ITile)this).bTileHeader2 & 63) | (wallFrameNumber & 3) << 6);
        }

        int ITile.wallFrameY() => ((((ITile)this).bTileHeader3 & 7) * 36);

        void ITile.wallFrameY(int wallFrameY) =>
            ((ITile)this).bTileHeader3 = (byte)((((ITile)this).bTileHeader3 & 248) | (wallFrameY / 36 & 7));

        bool ITile.checkingLiquid() => (((ITile)this).bTileHeader3 & 8) == 8;

        void ITile.checkingLiquid(bool checkingLiquid) {
            if (checkingLiquid) {
                ((ITile)this).bTileHeader3 |= 8;
                return;
            }

            ((ITile)this).bTileHeader3 &= 247;
        }

        bool ITile.skipLiquid() => (((ITile)this).bTileHeader3 & 16) == 16;

        void ITile.skipLiquid(bool skipLiquid) {
            if (skipLiquid) {
                ((ITile)this).bTileHeader3 |= 16;
                return;
            }

            ((ITile)this).bTileHeader3 &= 239;
        }

        byte ITile.color() => (byte)(((ITile)this).sTileHeader & 31);

        void ITile.color(byte color) {
            if (color > 30) {
                color = 30;
            }

            ((ITile)this).sTileHeader = (short)((((ITile)this).sTileHeader & 65504) | color);
        }

        bool ITile.active() => (((ITile)this).sTileHeader & 32) == 32;

        void ITile.active(bool active) {
            if (active) {
                ((ITile)this).sTileHeader |= 32;
                return;
            }

            ((ITile)this).sTileHeader = (short)(((ITile)this).sTileHeader & 65503);
        }

        bool ITile.inActive() => (((ITile)this).sTileHeader & 64) == 64;

        void ITile.inActive(bool inActive) {
            if (inActive) {
                ((ITile)this).sTileHeader |= 64;
                return;
            }

            ((ITile)this).sTileHeader = (short)(((ITile)this).sTileHeader & 65471);
        }

        bool ITile.wire() => (((ITile)this).sTileHeader & 128) == 128;

        void ITile.wire(bool wire) {
            if (wire) {
                ((ITile)this).sTileHeader |= 128;
                return;
            }

            ((ITile)this).sTileHeader = (short)(((ITile)this).sTileHeader & 65407);
        }

        bool ITile.wire2() => (((ITile)this).sTileHeader & 256) == 256;

        void ITile.wire2(bool wire2) {
            if (wire2) {
                ((ITile)this).sTileHeader |= 256;
                return;
            }

            ((ITile)this).sTileHeader = (short)(((ITile)this).sTileHeader & 65279);
        }

        bool ITile.wire3() => (((ITile)this).sTileHeader & 512) == 512;

        void ITile.wire3(bool wire3) {
            if (wire3) {
                ((ITile)this).sTileHeader |= 512;
                return;
            }

            ((ITile)this).sTileHeader = (short)(((ITile)this).sTileHeader & 65023);
        }

        bool ITile.halfBrick() => (((ITile)this).sTileHeader & 1024) == 1024;

        void ITile.halfBrick(bool halfBrick) {
            if (halfBrick) {
                ((ITile)this).sTileHeader |= 1024;
                return;
            }

            ((ITile)this).sTileHeader = (short)(((ITile)this).sTileHeader & 64511);
        }

        bool ITile.actuator() => (((ITile)this).sTileHeader & 2048) == 2048;

        void ITile.actuator(bool actuator) {
            if (actuator) {
                ((ITile)this).sTileHeader |= 2048;
                return;
            }

            ((ITile)this).sTileHeader = (short)(((ITile)this).sTileHeader & 63487);
        }

        byte ITile.slope() => (byte)((((ITile)this).sTileHeader & 28672) >> 12);

        void ITile.slope(byte slope) {
            ((ITile)this).sTileHeader = (short)((((ITile)this).sTileHeader & 36863) | (slope & 7) << 12);
        }

        #endregion
    }
}
