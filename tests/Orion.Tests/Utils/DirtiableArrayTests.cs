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
using FluentAssertions;
using Moq;
using Orion.Events;
using Xunit;

namespace Orion.Utils {
    public class DirtiableArrayTests {
        [Fact]
        public void Ctor_NegativeCount_ThrowsArgumentOutOfRangeException() {
            Func<DirtiableArray<int>> func = () => new DirtiableArray<int>(-1);

            func.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TIsIDirtiable_IsCorrect() {
            var isDirty = true;
            var mockDirtiable = new Mock<IDirtiable>();
            mockDirtiable.Setup(d => d.IsDirty).Returns(() => isDirty);
            mockDirtiable.Setup(d => d.Clean()).Callback(() => isDirty = false);
            var array = new DirtiableArray<IDirtiable>(1);
            array[0] = mockDirtiable.Object;

            array.ShouldBeDirty();

            mockDirtiable.VerifyGet(d => d.IsDirty);
            mockDirtiable.Verify(d => d.Clean());
            mockDirtiable.VerifyNoOtherCalls();
        }

        [Fact]
        public void Count_IsCorrect() {
            var array = new DirtiableArray<int>(100);

            array.Count.Should().Be(100);
        }

        [Fact]
        public void GetItem_IsCorrect() {
            var array = new DirtiableArray<int>(1);

            array[0].Should().Be(0);
        }

        [Fact]
        public void GetItem_NullElement_DoesNotAllowNull_ThrowsInvalidOperationException() {
            var array = new DirtiableArray<string>(1);
            Func<string> func = () => array[0];

            func.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void SetItem_MarksAsDirty() {
            var array = new DirtiableArray<int>(1);

            array[0] = 100;

            array.ShouldBeDirty();
        }

        [Fact]
        public void SetItem_NullValue_DoesNotAllowNull_ThrowsArgumentNullException() {
            var array = new DirtiableArray<string>(1);
            Action action = () => array[0] = null;

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetItem_NullValue_AllowsNull_IsCorrect() {
            var array = new DirtiableArray<string>(1, true);

            array[0] = null;

            array[0].Should().BeNull();
        }

        [Fact]
        public void GetEnumerator_IsCorrect() {
            var array = new DirtiableArray<int>(1);
            array[0] = 1;

            array.Should().BeEquivalentTo(1);
        }
    }
}