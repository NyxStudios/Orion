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
using System.Diagnostics.CodeAnalysis;
using Orion.World.Signs;
using Xunit;

namespace Orion.World.TileEntities {
    [SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "Testing")]
    public class OrionSignTests {
        [Fact]
        public void IsActive_Get_ReturnsFalse() {
            var sign = new OrionSign(null);

            Assert.False(sign.IsActive);
        }

        [Fact]
        public void IsActive_Get_True() {
            var terrariaSign = new Terraria.Sign();
            var sign = new OrionSign(terrariaSign);

            Assert.True(sign.IsActive);
        }

        [Fact]
        public void Index_Get() {
            var terrariaSign = new Terraria.Sign();
            var sign = new OrionSign(1, terrariaSign);

            Assert.Equal(1, sign.Index);
        }

        [Fact]
        public void X_Get_IsActive() {
            var terrariaSign = new Terraria.Sign { x = 256, y = 100, text = "test" };
            var sign = new OrionSign(terrariaSign);

            Assert.Equal(256, sign.X);
        }

        [Fact]
        public void X_Get_IsNotActive() {
            var sign = new OrionSign(null);

            Assert.Equal(0, sign.X);
        }

        [Fact]
        public void X_Set_IsActive() {
            var terrariaSign = new Terraria.Sign();
            var sign = new OrionSign(terrariaSign);

            sign.X = 256;

            Assert.Equal(256, terrariaSign.x);
        }

        [Fact]
        public void X_Set_IsNotActive() {
            var sign = new OrionSign(null);

            sign.X = 0;
        }

        [Fact]
        public void Y_Get_IsActive() {
            var terrariaSign = new Terraria.Sign { x = 256, y = 100, text = "test" };
            var sign = new OrionSign(terrariaSign);

            Assert.Equal(100, sign.Y);
        }

        [Fact]
        public void Y_Get_IsNotActive() {
            var sign = new OrionSign(null);

            Assert.Equal(0, sign.Y);
        }

        [Fact]
        public void Y_Set_IsActive() {
            var terrariaSign = new Terraria.Sign();
            var sign = new OrionSign(terrariaSign);

            sign.Y = 100;

            Assert.Equal(100, terrariaSign.y);
        }

        [Fact]
        public void Y_Set_IsNotActive() {
            var sign = new OrionSign(null);

            sign.Y = 0;
        }

        [Fact]
        public void Text_Get_IsActive() {
            var terrariaSign = new Terraria.Sign { x = 256, y = 100, text = "test" };
            var sign = new OrionSign(terrariaSign);

            Assert.Equal("test", sign.Text);
        }

        [Fact]
        public void Text_Get_IsNotActive() {
            var sign = new OrionSign(null);

            Assert.Equal("", sign.Text);
        }

        [Fact]
        public void Text_SetNullValue_ThrowsArgumentNullException() {
            var terrariaSign = new Terraria.Sign();
            var sign = new OrionSign(terrariaSign);

            Assert.Throws<ArgumentNullException>(() => sign.Text = null!);
        }

        [Fact]
        public void Text_Set_IsActive() {
            var terrariaSign = new Terraria.Sign();
            var sign = new OrionSign(terrariaSign);

            sign.Text = "test";

            Assert.Equal("test", terrariaSign.text);
        }

        [Fact]
        public void Text_Set_IsNotActive() {
            var sign = new OrionSign(null);

            sign.Text = "";
        }
    }
}