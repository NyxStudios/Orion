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
using System.Linq;
using Orion.Events;

namespace Orion.Utils {
    /// <summary>
    /// Represents a dirtiable list of objects.
    /// </summary>
    /// <typeparam name="T">The type of element.</typeparam>
    public sealed class DirtiableList<T> : IList<T>, IDirtiable {
        private readonly IList<T> _list = new List<T>();
        private bool _isDirty;

        private static bool ContainsDirtiableElements => typeof(IDirtiable).IsAssignableFrom(typeof(T));

        /// <inheritdoc />
        public int Count => _list.Count;

        /// <inheritdoc />
        public bool IsReadOnly => false;

        /// <inheritdoc />
        public bool IsDirty =>
            _isDirty || ContainsDirtiableElements && this.Cast<IDirtiable>().Any(d => d?.IsDirty == true);

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException">
        /// The list does not allow <c>null</c> elements and <paramref name="value"/> is <c>null</c>.
        /// </exception>
        public T this[int index] {
            get => _list[index];
            set {
                if (!AllowsNull && value == null) throw new ArgumentNullException(nameof(value));

                _list[index] = value;
                _isDirty = true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the list allows <c>null</c> elements.
        /// </summary>
        public bool AllowsNull { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirtiableList{T}"/> class with the specified option to allow
        /// <c>null</c> elements.
        /// </summary>
        /// <param name="allowsNull">A value indicating whether to allow <c>null</c> elements.</param>
        public DirtiableList(bool allowsNull = false) {
            AllowsNull = allowsNull;
        }

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException">
        /// The list does not allow <c>null</c> elements and <paramref name="item"/> is <c>null</c>.
        /// </exception>
        public void Add(T item) {
            if (!AllowsNull && item == null) throw new ArgumentNullException(nameof(item));

            _list.Add(item);
            _isDirty = true;
        }

        /// <inheritdoc />
        public void Clear() {
            _list.Clear();
            _isDirty = true;
        }

        /// <inheritdoc />
        public bool Contains(T item) => _list.Contains(item);

        /// <inheritdoc />
        public void CopyTo(T[] array, int arrayIndex) {
            _list.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc />
        public bool Remove(T item) {
            var result = _list.Remove(item);
            _isDirty = true;
            return result;
        }

        /// <inheritdoc />
        public int IndexOf(T item) => _list.IndexOf(item);

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException">
        /// The list does not allow <c>null</c> elements and <paramref name="item"/> is <c>null</c>.
        /// </exception>
        public void Insert(int index, T item) {
            if (!AllowsNull && item == null) throw new ArgumentNullException(nameof(item));

            _list.Insert(index, item);
            _isDirty = true;
        }

        /// <inheritdoc />
        public void RemoveAt(int index) {
            _list.RemoveAt(index);
            _isDirty = true;
        }

        /// <inheritdoc />
        public void Clean() {
            _isDirty = false;
            if (!ContainsDirtiableElements) return;

            foreach (var dirtiable in this.Cast<IDirtiable>()) {
                dirtiable?.Clean();
            }
        }
    }
}