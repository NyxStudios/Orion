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

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Orion.Entities;
using Orion.World.Tiles;

namespace Orion.World {
    internal sealed unsafe class OrionWorld : AnnotatableObject, IDisposable, IWorld {
        // Store a pointer to the `Tile` array in unmanaged memory so that the array doesn't need to be pinned.
        private readonly unsafe Tile* _tiles;

        public OrionWorld(int width, int height) {
            Debug.Assert(width > 0);
            Debug.Assert(height > 0);

            Width = width;
            Height = height;

            _tiles = (Tile*)Marshal.AllocHGlobal(sizeof(Tile) * width * height);
        }

        ~OrionWorld() {
            Marshal.FreeHGlobal((IntPtr)_tiles);
        }

        public ref Tile this[int x, int y] {
            get {
                Debug.Assert(x >= 0 && x < Width);
                Debug.Assert(y >= 0 && y < Height);

                var offset = y * Width + x;
                return ref _tiles[offset];
            }
        }

        public int Width { get; }
        public int Height { get; }

        public void Dispose() {
            Marshal.FreeHGlobal((IntPtr)_tiles);
            GC.SuppressFinalize(this);
        }
    }
}
