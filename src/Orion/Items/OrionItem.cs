﻿using System;
using Orion.Entities;
using Orion.Projectiles;
using Orion.World.Tiles;

namespace Orion.Items {
    internal sealed class OrionItem : OrionEntity<Terraria.Item>, IItem {
        public override string Name {
            get => Wrapped.Name;
            set => Wrapped._nameOverride = value ?? throw new ArgumentNullException(nameof(value));
        }

        public ItemType Type => (ItemType)Wrapped.type;

        public int StackSize {
            get => Wrapped.stack;
            set => Wrapped.stack = value;
        }

        public int MaxStackSize {
            get => Wrapped.maxStack;
            set => Wrapped.maxStack = value;
        }

        public ItemPrefix Prefix => (ItemPrefix)Wrapped.prefix;

        public ItemRarity Rarity {
            get => (ItemRarity)Wrapped.rare;
            set => Wrapped.rare = (int)value;
        }

        public float Scale {
            get => Wrapped.scale;
            set => Wrapped.scale = value;
        }

        public int Value {
            get => Wrapped.value;
            set => Wrapped.value = value;
        }

        public bool IsMeleeWeapon {
            get => Wrapped.melee;
            set => Wrapped.melee = value;
        }

        public bool IsRangedWeapon {
            get => Wrapped.ranged;
            set => Wrapped.ranged = value;
        }

        public bool IsMagicWeapon {
            get => Wrapped.magic;
            set => Wrapped.magic = value;
        }

        public bool IsSummonWeapon {
            get => Wrapped.summon;
            set => Wrapped.summon = value;
        }

        public bool IsThrownWeapon {
            get => Wrapped.thrown;
            set => Wrapped.thrown = value;
        }

        public int Damage {
            get => Wrapped.damage;
            set => Wrapped.damage = value;
        }

        public int UseTime {
            get => Wrapped.useTime;
            set => Wrapped.useTime = value;
        }

        public float ProjectileSpeed {
            get => Wrapped.shootSpeed;
            set => Wrapped.shootSpeed = value;
        }

        public ProjectileType ProjectileType {
            get => (ProjectileType)Wrapped.shoot;
            set => Wrapped.shoot = (int)value;
        }

        public BlockType? BlockType {
            get => Wrapped.createTile >= 0 ? (BlockType)Wrapped.createTile : (BlockType?)null;
            set => Wrapped.createTile = (int?)value ?? -1;
        }

        public WallType? WallType {
            get => Wrapped.createWall >= 0 ? (WallType)Wrapped.createWall : (WallType?)null;
            set => Wrapped.createWall = (int?)value ?? -1;
        }

        public int PickaxePower {
            get => Wrapped.pick;
            set => Wrapped.pick = value;
        }

        public int AxePower {
            get => Wrapped.axe;
            set => Wrapped.axe = value;
        }

        public int HammerPower {
            get => Wrapped.hammer;
            set => Wrapped.hammer = value;
        }

        public int Defense {
            get => Wrapped.defense;
            set => Wrapped.defense = value;
        }

        public bool IsAccessory {
            get => Wrapped.accessory;
            set => Wrapped.accessory = value;
        }

        public OrionItem(Terraria.Item terrariaItem) : base(terrariaItem) { }

        public void ApplyType(ItemType type) => Wrapped.SetDefaults((int)type);
        public void ApplyPrefix(ItemPrefix prefix) => Wrapped.Prefix((int)prefix);
    }
}