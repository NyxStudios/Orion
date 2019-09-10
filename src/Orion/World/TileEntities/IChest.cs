﻿using System;
using Orion.Items;

namespace Orion.World.TileEntities {
    /// <summary>
    /// Provides a wrapper around a Terraria.Chest.
    /// </summary>
    public interface IChest : ITileEntity {
        /// <summary>
        /// Gets or sets the chest's name.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
        string Name { get; set; }

        /// <summary>
        /// Gets the chest items.
        /// </summary>
        IItemList Items { get; }
    }
}
