﻿using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Orion.World.Events;
using Orion.World.TileEntities;
using Orion.World.Tiles;
using OTAPI;
using OTAPI.Tile;
using TDS = Terraria.DataStructures;
using TGCTE = Terraria.GameContent.Tile_Entities;

namespace Orion.World {
    internal sealed unsafe class OrionWorldService : OrionService, IWorldService, ITileCollection {
        private readonly IChestService _chestService;
        private readonly ISignService _signService;
        private byte* _tilesPtr = null;

        [ExcludeFromCodeCoverage]
        public override string Author => "Pryaxis";

        [ExcludeFromCodeCoverage]
        public override string Name => "Orion World Service";

        public string WorldName {
            get => Terraria.Main.worldName;
            set => Terraria.Main.worldName = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int WorldWidth => Terraria.Main.maxTilesX;
        public int WorldHeight => Terraria.Main.maxTilesY;

        public Tile this[int x, int y] {
            get => new OrionTile(_tilesPtr + OrionTile.ByteCount * ((WorldWidth + 1) * y + x));
            set => ((ITileCollection)this)[x, y] = value;
        }

        int ITileCollection.Width => WorldWidth;
        int ITileCollection.Height => WorldHeight;

        ITile ITileCollection.this[int x, int y] {
            get => this[x, y];
            set {
                var location = new OrionTile(_tilesPtr + OrionTile.ByteCount * ((WorldWidth + 1) * y + x));
                ((ITile)location).CopyFrom(value);
            }
        }

        public double Time {
            get => Terraria.Main.time;
            set => Terraria.Main.time = value;
        }

        public bool IsDaytime {
            get => Terraria.Main.dayTime;
            set => Terraria.Main.dayTime = value;
        }

        public bool IsHardmode {
            get => Terraria.Main.hardMode;
            set => Terraria.Main.hardMode = value;
        }

        public bool IsExpertMode {
            get => Terraria.Main.expertMode;
            set => Terraria.Main.expertMode = value;
        }

        public InvasionType CurrentInvasion => (InvasionType)Terraria.Main.invasionType;

        public event EventHandler<CheckingHalloweenEventArgs> CheckingHalloween;
        public event EventHandler<CheckingChristmasEventArgs> CheckingChristmas;
        public event EventHandler<LoadingWorldEventArgs> LoadingWorld;
        public event EventHandler<LoadedWorldEventArgs> LoadedWorld;
        public event EventHandler<SavingWorldEventArgs> SavingWorld;
        public event EventHandler<SavedWorldEventArgs> SavedWorld;
        public event EventHandler<StartingHardmodeEventArgs> StartingHardmode;
        public event EventHandler<StartedHardmodeEventArgs> StartedHardmode;
        public event EventHandler<UpdatingHardmodeTileEventArgs> UpdatingHardmodeTile;

        public OrionWorldService(IChestService chestService, ISignService signService) {
            Debug.Assert(chestService != null, $"{nameof(chestService)} should not be null.");
            Debug.Assert(signService != null, $"{nameof(signService)} should not be null.");

            _chestService = chestService;
            _signService = signService;

            Hooks.Tile.CreateCollection = () => {
                // Allocate with AllocHGlobal so that the memory is pre-pinned.
                _tilesPtr = (byte*)Marshal.AllocHGlobal(OrionTile.ByteCount * (WorldWidth + 1) * (WorldHeight + 1));
                return this;
            };

            // Force the tile collection to be this instance.
            if (Terraria.Main.tile == null || Terraria.Main.tile != this) {
                Terraria.Main.tile = Hooks.Tile.CreateCollection();
            }

            Hooks.Game.Halloween = HalloweenHandler;
            Hooks.Game.Christmas = ChristmasHandler;
            Hooks.World.IO.PreLoadWorld = PreLoadWorldHandler;
            Hooks.World.IO.PostLoadWorld = PostLoadWorldHandler;
            Hooks.World.IO.PreSaveWorld = PreSaveWorldHandler;
            Hooks.World.IO.PostSaveWorld = PostSaveWorldHandler;
            Hooks.World.PreHardmode = PreHardmodeHandler;
            Hooks.World.PostHardmode = PostHardmodeHandler;
            Hooks.World.HardmodeTileUpdate = HardmodeTileUpdateHandler;
        }

        protected override void Dispose(bool disposeManaged) {
            Terraria.Main.tile = null;
            Marshal.FreeHGlobal((IntPtr)_tilesPtr);

            if (!disposeManaged) {
                return;
            }

            Hooks.Tile.CreateCollection = null;
            Hooks.Game.Halloween = null;
            Hooks.Game.Christmas = null;
            Hooks.World.IO.PreLoadWorld = null;
            Hooks.World.IO.PostLoadWorld = null;
            Hooks.World.IO.PreSaveWorld = null;
            Hooks.World.IO.PostSaveWorld = null;
            Hooks.World.PreHardmode = null;
            Hooks.World.PostHardmode = null;
            Hooks.World.HardmodeTileUpdate = null;
        }

        public bool StartInvasion(InvasionType invasionType) {
            Terraria.Main.StartInvasion((int)invasionType);
            return CurrentInvasion == invasionType;
        }

        public ITargetDummy AddTargetDummy(int x, int y) {
            if (TDS.TileEntity.ByPosition.ContainsKey(new TDS.Point16(x, y))) {
                return null;
            }

            var targetDummyIndex = TGCTE.TETrainingDummy.Place(x, y);
            return new OrionTargetDummy((TGCTE.TETrainingDummy)TDS.TileEntity.ByID[targetDummyIndex]);
        }

        public IItemFrame AddItemFrame(int x, int y) {
            if (TDS.TileEntity.ByPosition.ContainsKey(new TDS.Point16(x, y))) {
                return null;
            }

            var itemFrameIndex = TGCTE.TEItemFrame.Place(x, y);
            return new OrionItemFrame((TGCTE.TEItemFrame)TDS.TileEntity.ByID[itemFrameIndex]);
        }

        public ILogicSensor AddLogicSensor(int x, int y) {
            if (TDS.TileEntity.ByPosition.ContainsKey(new TDS.Point16(x, y))) {
                return null;
            }

            var logicSensor = TGCTE.TELogicSensor.Place(x, y);
            return new OrionLogicSensor((TGCTE.TELogicSensor)TDS.TileEntity.ByID[logicSensor]);
        }

        public ITileEntity GetTileEntity(int x, int y) {
            ITileEntity GetTerrariaTileEntity() {
                if (!TDS.TileEntity.ByPosition.TryGetValue(new TDS.Point16(x, y), out var terrariaTileEntity)) {
                    return null;
                }

                switch (terrariaTileEntity) {
                case TGCTE.TETrainingDummy trainingDummy: return new OrionTargetDummy(trainingDummy);
                case TGCTE.TEItemFrame itemFrame: return new OrionItemFrame(itemFrame);
                case TGCTE.TELogicSensor logicSensor: return new OrionLogicSensor(logicSensor);
                default: return null;
                }
            }

            return _chestService.GetChest(x, y) ?? _signService.GetSign(x, y) ?? GetTerrariaTileEntity();
        }

        public bool RemoveTileEntity(ITileEntity tileEntity) {
            bool RemoveTerrariaTileEntity() {
                // We use the & operator here instead of && since we always need to execute both operands.
                return TDS.TileEntity.ByPosition.Remove(new TDS.Point16(tileEntity.X, tileEntity.Y)) &
                       TDS.TileEntity.ByID.Remove(tileEntity.Index);
            }

            switch (tileEntity) {
            case IChest chest: return _chestService.RemoveChest(chest);
            case ISign sign: return _signService.RemoveSign(sign);
            default: return RemoveTerrariaTileEntity();
            }
        }

        public void SaveWorld() => Terraria.IO.WorldFile.saveWorld();
        

        private HookResult HalloweenHandler() {
            var args = new CheckingHalloweenEventArgs();
            CheckingHalloween?.Invoke(this, args);

            return args.Handled ? HookResult.Cancel : HookResult.Continue;
        }

        private HookResult ChristmasHandler() {
            var args = new CheckingChristmasEventArgs();
            CheckingChristmas?.Invoke(this, args);

            return args.Handled ? HookResult.Cancel : HookResult.Continue;
        }

        private HookResult PreLoadWorldHandler(ref bool loadFromCloud) {
            var args = new LoadingWorldEventArgs();
            LoadingWorld?.Invoke(this, args);

            return args.Handled ? HookResult.Cancel : HookResult.Continue;
        }

        private void PostLoadWorldHandler(bool loadFromCloud) {
            var args = new LoadedWorldEventArgs();
            LoadedWorld?.Invoke(this, args);
        }

        private HookResult PreSaveWorldHandler(ref bool useCloudSaving, ref bool resetTime) {
            var args = new SavingWorldEventArgs {ShouldResetTime = resetTime};
            SavingWorld?.Invoke(this, args);
            
            return args.Handled ? HookResult.Cancel : HookResult.Continue;
        }

        private void PostSaveWorldHandler(bool useCloudSaving, bool resetTime) {
            var args = new SavedWorldEventArgs {ShouldResetTime = resetTime};
            SavedWorld?.Invoke(this, args);
        }

        private HookResult PreHardmodeHandler() {
            var args = new StartingHardmodeEventArgs();
            StartingHardmode?.Invoke(this, args);

            return args.Handled ? HookResult.Cancel : HookResult.Continue;
        }

        private void PostHardmodeHandler() {
            var args = new StartedHardmodeEventArgs();
            StartedHardmode?.Invoke(this, args);
        }

        private HardmodeTileUpdateResult HardmodeTileUpdateHandler(int x, int y, ref ushort type) {
            var args = new UpdatingHardmodeTileEventArgs(x, y, (BlockType)type);
            UpdatingHardmodeTile?.Invoke(this, args);

            type = (ushort)args.BlockType;
            return args.Handled ? HardmodeTileUpdateResult.Cancel : HardmodeTileUpdateResult.Continue;
        }
    }
}