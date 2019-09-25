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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using System.Text;
using Orion.Packets.World.TileEntities;
using Orion.Utils;
using Orion.World.TileEntities;
using Orion.World.Tiles;
using Orion.World.Tiles.Extensions;
using OTAPI.Tile;

namespace Orion.Packets.World.Tiles {
    /// <summary>
    /// Packet sent from the server to the client to set a section of the world. This is sent in response to a
    /// <see cref="SectionRequestPacket"/>.
    /// </summary>
    public sealed class SectionPacket : Packet {
        private bool _isSectionCompressed;
        private int _startTileX;
        private int _startTileY;
        private short _sectionWidth;
        private short _sectionHeight;
        private NetworkTiles _sectionTiles = new NetworkTiles(0, 0);

        private readonly DirtiableList<NetworkTileEntity> _sectionTileEntities = new DirtiableList<NetworkTileEntity>();

        /// <inheritdoc />
        public override bool IsDirty => base.IsDirty || SectionTiles.IsDirty || _sectionTileEntities.IsDirty;

        /// <inheritdoc />
        public override PacketType Type => PacketType.Section;

        /// <summary>
        /// Gets or sets a value indicating whether the section is compressed.
        /// </summary>
        public bool IsSectionCompressed {
            get => _isSectionCompressed;
            set {
                _isSectionCompressed = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the starting tile's X coordinate.
        /// </summary>
        public int StartTileX {
            get => _startTileX;
            set {
                _startTileX = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the starting tile's Y coordinate.
        /// </summary>
        public int StartTileY {
            get => _startTileY;
            set {
                _startTileY = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the section's width.
        /// </summary>
        public short SectionWidth {
            get => _sectionWidth;
            set {
                _sectionWidth = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the section's height.
        /// </summary>
        public short SectionHeight {
            get => _sectionHeight;
            set {
                _sectionHeight = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the section's tiles.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
        public NetworkTiles SectionTiles {
            get => _sectionTiles;
            set {
                _sectionTiles = value ?? throw new ArgumentNullException(nameof(value));
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets the section's tile entities.
        /// </summary>
        public IList<NetworkTileEntity> SectionTileEntities => _sectionTileEntities;

        /// <inheritdoc />
        public override void Clean() {
            base.Clean();
            SectionTiles.Clean();
            _sectionTileEntities.Clean();
        }

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        public override string ToString() =>
            $"{Type}[{SectionWidth}x{SectionHeight} @ ({StartTileX}, {StartTileY}), ...]";

        private protected override void ReadFromReader(BinaryReader reader, PacketContext context) {
            _isSectionCompressed = reader.ReadByte() == 1;
            if (!_isSectionCompressed) {
                ReadFromReaderImpl(reader);
                return;
            }

            using var deflateStream = new DeflateStream(reader.BaseStream, CompressionMode.Decompress, true);
            ReadFromReaderImpl(new BinaryReader(deflateStream, Encoding.UTF8, true));
        }

        private protected override void WriteToWriter(BinaryWriter writer, PacketContext context) {
            writer.Write(_isSectionCompressed);
            if (!_isSectionCompressed) {
                WriteToWriterImpl(writer);
                return;
            }

            var stream = new MemoryStream();
            WriteToWriterImpl(new BinaryWriter(stream, Encoding.UTF8, true));

            var compressedStream = new MemoryStream();
            var deflateStream = new DeflateStream(compressedStream, CompressionMode.Compress, true);
            stream.Position = 0;
            stream.CopyTo(deflateStream);
            deflateStream.Close();

            compressedStream.Position = 0;
            compressedStream.CopyTo(writer.BaseStream);
        }

        private void ReadFromReaderImpl(BinaryReader reader) {
            _startTileX = reader.ReadInt32();
            _startTileY = reader.ReadInt32();
            _sectionWidth = reader.ReadInt16();
            _sectionHeight = reader.ReadInt16();
            _sectionTiles = new NetworkTiles(SectionWidth, SectionHeight);

            ReadTilesFromReaderImpl(reader);
            ReadTileEntitiesFromReaderImpl(reader);
        }

        private void ReadTilesFromReaderImpl(BinaryReader reader) {
            void ReadTile(NetworkTile tile, byte header, byte header2, byte header3) {
                if ((header & 2) == 2) {
                    tile.IsBlockActive = true;

                    tile._blockType = (BlockType)((header & 32) == 32 ? reader.ReadUInt16() : reader.ReadByte());
                    if (tile._blockType.AreFramesImportant()) {
                        tile._blockFrameX = reader.ReadInt16();
                        tile._blockFrameY = reader.ReadInt16();
                    } else {
                        tile._blockFrameX = -1;
                        tile._blockFrameY = -1;
                    }

                    if ((header3 & 8) == 8) {
                        tile.BlockColor = (PaintColor)reader.ReadByte();
                    }
                }

                if ((header & 4) == 4) {
                    tile._wallType = (WallType)reader.ReadByte();
                    if ((header3 & 16) == 16) {
                        tile.WallColor = (PaintColor)reader.ReadByte();
                    }
                }

                var liquidType = (header & 24) >> 3;
                if (liquidType > 0) {
                    tile._liquidAmount = reader.ReadByte();
                    tile.LiquidType = (LiquidType)(liquidType - 1);
                }

                tile.HasRedWire = (header2 & 2) == 2;
                tile.HasBlueWire = (header2 & 4) == 4;
                tile.HasGreenWire = (header2 & 8) == 8;

                // TODO: there was a tileSolid check here, but it doesn't seem necessary?
                var blockShape = (header2 & 112) >> 4;
                if (blockShape != 0) {
                    if (blockShape == 1) {
                        tile.IsBlockHalved = true;
                    } else {
                        tile.Slope = (Slope)(blockShape - 1);
                    }
                }

                tile.HasActuator = (header3 & 2) == 2;
                tile.IsBlockActuated = (header3 & 4) == 4;
                tile.HasYellowWire = (header3 & 32) == 32;
                tile.Clean();
            }

            int ReadRunLength(byte header) => ((header & 192) >> 6) switch {
                0 => 0,
                1 => reader.ReadByte(),
                2 => reader.ReadInt16(),
                _ => throw new InvalidOperationException()
            };

            NetworkTile? previousTile = null;
            var runLength = 0;
            for (int y = 0; y < SectionHeight; ++y) {
                for (int x = 0; x < SectionWidth; ++x) {
                    if (runLength > 0) {
                        --runLength;
                        ((ITile)_sectionTiles._tiles[x, y]).CopyFrom(previousTile);
                        _sectionTiles._tiles[x, y].Clean();
                        continue;
                    }

                    byte header = reader.ReadByte();
                    byte header2 = (header & 1) == 1 ? reader.ReadByte() : (byte)0;
                    byte header3 = (header2 & 1) == 1 ? reader.ReadByte() : (byte)0;

                    ReadTile(_sectionTiles._tiles[x, y], header, header2, header3);
                    runLength = ReadRunLength(header);
                    previousTile = _sectionTiles._tiles[x, y];
                }
            }
        }

        private void ReadTileEntitiesFromReaderImpl(BinaryReader reader) {
            void ReadTileEntities(TileEntityType? typeHint = null) {
                var number = reader.ReadInt16();
                for (var i = 0; i < number; ++i) {
                    _sectionTileEntities._list.Add(NetworkTileEntity.ReadFromReader(reader, true, typeHint));
                }
            }

            ReadTileEntities(TileEntityType.Chest);
            ReadTileEntities(TileEntityType.Sign);
            ReadTileEntities();
        }

        private void WriteToWriterImpl(BinaryWriter writer) {
            writer.Write(_startTileX);
            writer.Write(_startTileY);
            writer.Write(_sectionWidth);
            writer.Write(_sectionHeight);

            WriteTilesToWriterImpl(writer);
            WriteTileEntitiesToWriterImpl(writer);
        }

        private void WriteTilesToWriterImpl(BinaryWriter writer) {
            var buffer = new byte[15];
            var headerIndex = 0;
            byte header = 0;
            var bodyIndex = 0;
            NetworkTile? previousTile = null;
            var runLength = 0;

            void WritePartialTile(NetworkTile tile) {
                header = 0;
                byte header2 = 0;
                byte header3 = 0;

                bodyIndex = 3;
                if (tile.IsBlockActive) {
                    header |= 2;

                    var type = (ushort)tile._blockType;
                    buffer[bodyIndex++] = (byte)type;
                    if (type > byte.MaxValue) {
                        header |= 32;
                        buffer[bodyIndex++] = (byte)(type >> 8);
                    }

                    if (tile._blockType.AreFramesImportant()) {
                        buffer[bodyIndex++] = (byte)tile._blockFrameX;
                        buffer[bodyIndex++] = (byte)(tile._blockFrameX >> 8);
                        buffer[bodyIndex++] = (byte)tile._blockFrameY;
                        buffer[bodyIndex++] = (byte)(tile._blockFrameY >> 8);
                    }

                    if (tile.BlockColor != PaintColor.None) {
                        header3 |= 8;
                        buffer[bodyIndex++] = (byte)tile.BlockColor;
                    }
                }

                if (tile._wallType != WallType.None) {
                    header |= 4;
                    buffer[bodyIndex++] = (byte)tile._wallType;

                    if (tile.WallColor != PaintColor.None) {
                        header3 |= 16;
                        buffer[bodyIndex++] = (byte)tile.WallColor;
                    }
                }

                if (tile.LiquidAmount > 0) {
                    header |= (byte)(((byte)tile.LiquidType + 1) << 3);
                    buffer[bodyIndex++] = tile.LiquidAmount;
                }

                header2 |= (byte)(tile.HasRedWire ? 2 : 0);
                header2 |= (byte)(tile.HasGreenWire ? 4 : 0);
                header2 |= (byte)(tile.HasBlueWire ? 8 : 0);
                header2 |= (byte)(((ITile)tile).blockType() << 4);

                header3 |= (byte)(tile.HasActuator ? 2 : 0);
                header3 |= (byte)(tile.IsBlockActuated ? 4 : 0);
                header3 |= (byte)(tile.HasYellowWire ? 32 : 0);

                headerIndex = 2;
                if (header3 > 0) {
                    header2 |= 1;
                    buffer[headerIndex--] = header3;
                }

                if (header2 > 0) {
                    header |= 1;
                    buffer[headerIndex--] = header2;
                }
            }

            void WriteRunLength() {
                if (runLength > 0) {
                    buffer[bodyIndex++] = (byte)runLength;

                    if (runLength > byte.MaxValue) {
                        header |= 128;
                        buffer[bodyIndex++] = (byte)(runLength >> 8);
                    } else {
                        header |= 64;
                    }
                }

                buffer[headerIndex] = header;
                writer.Write(buffer, headerIndex, bodyIndex - headerIndex);
                runLength = 0;
            }

            for (int y = 0; y < _sectionHeight; ++y) {
                for (int x = 0; x < _sectionWidth; ++x) {
                    var tile = _sectionTiles._tiles[x, y];
                    if (((ITile)tile).isTheSameAs(previousTile)) {
                        ++runLength;
                        continue;
                    }

                    if (previousTile != null) {
                        WriteRunLength();
                    }

                    WritePartialTile(tile);
                    previousTile = tile;
                }
            }

            WriteRunLength();
        }

        private void WriteTileEntitiesToWriterImpl(BinaryWriter writer) {
            var chests = new List<NetworkTileEntity>();
            var signs = new List<NetworkTileEntity>();
            var notChestsOrSigns = new List<NetworkTileEntity>();
            foreach (var tileEntity in _sectionTileEntities) {
                switch (tileEntity) {
                case NetworkChest _:
                    chests.Add(tileEntity);
                    break;
                case NetworkSign _:
                    signs.Add(tileEntity);
                    break;
                default:
                    notChestsOrSigns.Add(tileEntity);
                    break;
                }
            }

            void WriteTileEntities(ICollection<NetworkTileEntity> tileEntities) {
                writer.Write((short)tileEntities.Count);
                foreach (var tileEntity in tileEntities) {
                    tileEntity.WriteToWriter(writer, true);
                }
            }

            WriteTileEntities(chests);
            WriteTileEntities(signs);
            WriteTileEntities(notChestsOrSigns);
        }
    }
}