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

namespace Orion.Framework {
    /// <summary>
    /// Controls the scope of a service.
    /// </summary>
    public enum ServiceScope {
        /// <summary>
        /// Indicates that the service should have singleton scope: i.e., only one object is ever constructed.
        /// </summary>
        Singleton,

        /// <summary>
        /// Indicates that the service should have transient scope: i.e., a new object is constructed each time, and the
        /// lifetime of the service is not managed.
        /// </summary>
        Transient
    }
}
