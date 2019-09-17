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
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.Xna.Framework;
using Orion.Entities;
using Orion.Networking.Packets.Extensions;
using Orion.Utils;

namespace Orion.Networking.Packets.Npcs {
    /// <summary>
    /// Packet sent from the server to the client to set NPC information.
    /// </summary>
    public sealed class NpcInfoPacket : Packet {
        private readonly float[] _npcAiValues = new float[Terraria.NPC.maxAI];
        private short _npcIndex;
        private Vector2 _npcPosition;
        private Vector2 _npcVelocity;
        private ushort _npcTargetIndex;
        private bool _npcHorizontalDirection;
        private bool _npcVerticalDirection;
        private bool _npcSpriteDirection;
        private bool _isNpcAtMaxHealth;
        private NpcType _npcType = NpcType.None;
        private byte _npcNumberOfHealthBytes;
        private int _npcHealth;
        private byte _npcReleaserPlayerIndex;

        /// <summary>
        /// Gets or sets the NPC index.
        /// </summary>
        public short NpcIndex {
            get => _npcIndex;
            set {
                _npcIndex = value;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the NPC's position.
        /// </summary>
        public Vector2 NpcPosition {
            get => _npcPosition;
            set {
                _npcPosition = value;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the NPC's velocity.
        /// </summary>
        public Vector2 NpcVelocity {
            get => _npcVelocity;
            set {
                _npcVelocity = value;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the NPC's target index.
        /// </summary>

        // TODO: convert this to a specific type
        public ushort NpcTargetIndex {
            get => _npcTargetIndex;
            set {
                _npcTargetIndex = value;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the horizontal direction of the NPC.
        /// </summary>
        public bool NpcHorizontalDirection {
            get => _npcHorizontalDirection;
            set {
                _npcHorizontalDirection = value;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the vertical direction of the NPC.
        /// </summary>
        public bool NpcVerticalDirection {
            get => _npcVerticalDirection;
            set {
                _npcVerticalDirection = value;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets the NPC's AI values.
        /// </summary>
        public IArray<float> NpcAiValues { get; }

        /// <summary>
        /// Gets or sets a value indicating the direction of the NPC sprite.
        /// </summary>
        public bool NpcSpriteDirection {
            get => _npcSpriteDirection;
            set {
                _npcSpriteDirection = value;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or set a value indicating whether the NPC is at maximum health.
        /// </summary>
        public bool IsNpcAtMaxHealth {
            get => _isNpcAtMaxHealth;
            set {
                _isNpcAtMaxHealth = value;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the NPC's type.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
        public NpcType NpcType {
            get => _npcType;
            set {
                _npcType = value ?? throw new ArgumentNullException(nameof(value));
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the number of bytes that represent the NPC's health.
        /// </summary>
        public byte NpcNumberOfHealthBytes {
            get => _npcNumberOfHealthBytes;
            set {
                _npcNumberOfHealthBytes = value;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the NPC's health.
        /// </summary>
        public int NpcHealth {
            get => _npcHealth;
            set {
                _npcHealth = value;
                IsDirty = true;
            }
        }

        /// <summary>
        /// Gets or sets the NPC's releaser player index.
        /// </summary>
        public byte NpcReleaserPlayerIndex {
            get => _npcReleaserPlayerIndex;
            set {
                _npcReleaserPlayerIndex = value;
                IsDirty = true;
            }
        }

        /// <inheritdoc />
        public override PacketType Type => PacketType.NpcInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="NpcInfoPacket"/> class.
        /// </summary>
        public NpcInfoPacket() {
            NpcAiValues = new AiValueArray(this);
        }

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        public override string ToString() => $"{Type}[#={NpcIndex}, {NpcType} @ {NpcPosition}, ...]";

        private protected override void ReadFromReader(BinaryReader reader, PacketContext context) {
            _npcIndex = reader.ReadInt16();
            _npcPosition = reader.ReadVector2();
            _npcVelocity = reader.ReadVector2();

            var targetIndex = reader.ReadUInt16();
            _npcTargetIndex = targetIndex != ushort.MaxValue ? targetIndex : (ushort)0;

            Terraria.BitsByte header = reader.ReadByte();
            _npcHorizontalDirection = header[0];
            _npcVerticalDirection = header[1];
            if (header[2]) _npcAiValues[0] = reader.ReadSingle();
            if (header[3]) _npcAiValues[1] = reader.ReadSingle();
            if (header[4]) _npcAiValues[2] = reader.ReadSingle();
            if (header[5]) _npcAiValues[3] = reader.ReadSingle();
            _npcSpriteDirection = header[6];
            _isNpcAtMaxHealth = header[7];

            _npcType = NpcType.FromId(reader.ReadInt16()) ?? throw new PacketException("NPC type is invalid.");

            if (!IsNpcAtMaxHealth) {
                _npcNumberOfHealthBytes = reader.ReadByte();
                switch (NpcNumberOfHealthBytes) {
                case 2:
                    _npcHealth = reader.ReadInt16();
                    break;
                case 4:
                    _npcHealth = reader.ReadInt32();
                    break;
                default:
                    _npcHealth = reader.ReadSByte();
                    break;
                }
            }

            if (NpcType.IsCatchable) {
                NpcReleaserPlayerIndex = reader.ReadByte();
            }
        }

        private protected override void WriteToWriter(BinaryWriter writer, PacketContext context) {
            writer.Write(NpcIndex);
            writer.Write(NpcPosition);
            writer.Write(NpcVelocity);
            writer.Write(NpcTargetIndex);

            Terraria.BitsByte header = 0;
            header[0] = NpcHorizontalDirection;
            header[1] = NpcVerticalDirection;
            header[2] = NpcAiValues[0] != 0;
            header[3] = NpcAiValues[1] != 0;
            header[4] = NpcAiValues[2] != 0;
            header[5] = NpcAiValues[3] != 0;
            header[6] = NpcSpriteDirection;
            header[7] = IsNpcAtMaxHealth;

            writer.Write(header);
            if (header[2]) writer.Write(NpcAiValues[0]);
            if (header[3]) writer.Write(NpcAiValues[1]);
            if (header[4]) writer.Write(NpcAiValues[2]);
            if (header[5]) writer.Write(NpcAiValues[3]);

            writer.Write(NpcType.Id);

            if (!IsNpcAtMaxHealth) {
                writer.Write(NpcNumberOfHealthBytes);
                switch (NpcNumberOfHealthBytes) {
                case 4:
                    writer.Write(NpcHealth);
                    break;
                case 2:
                    writer.Write((short)NpcHealth);
                    break;
                default:
                    writer.Write((byte)NpcHealth);
                    break;
                }
            }

            if (NpcType.IsCatchable) {
                writer.Write(NpcReleaserPlayerIndex);
            }
        }

        private class AiValueArray : IArray<float> {
            private readonly NpcInfoPacket _packet;

            public float this[int index] {
                get => _packet._npcAiValues[index];
                set {
                    _packet._npcAiValues[index] = value;
                    _packet.IsDirty = true;
                }
            }

            public int Count => _packet._npcAiValues.Length;

            public AiValueArray(NpcInfoPacket packet) {
                _packet = packet;
            }

            public IEnumerator<float> GetEnumerator() {
                for (var i = 0; i < Count; ++i) {
                    yield return this[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
