﻿// ReSharper disable InconsistentNaming

namespace Orion.Npcs {
    /// <summary>
    /// Specifies an NPC's type.
    /// </summary>
    public enum NpcType : short {
#pragma warning disable 1591
        BigHornetStingy = -65,
        LittleHornetStingy = -64,
        BigHornetSpikey = -63,
        LittleHornetSpikey = -62,
        BigHornetLeafy = -61,
        LittleHornetLeafy = -60,
        BigHornetHoney = -59,
        LittleHornetHoney = -58,
        BigHornetFatty = -57,
        LittleHornetFatty = -56,
        BigRainZombie = -55,
        SmallRainZombie = -54,
        BigPantlessSkeleton = -53,
        SmallPantlessSkeleton = -52,
        BigMisassembledSkeleton = -51,
        SmallMisassembledSkeleton = -50,
        BigHeadacheSkeleton = -49,
        SmallHeadacheSkeleton = -48,
        BigSkeleton = -47,
        SmallSkeleton = -46,
        BigFemaleZombie = -45,
        SmallFemaleZombie = -44,
        DemonEye2 = -43,
        PurpleEye2 = -42,
        GreenEye2 = -41,
        DialatedEye2 = -40,
        SleepyEye2 = -39,
        CataractEye2 = -38,
        BigTwiggyZombie = -37,
        SmallTwiggyZombie = -36,
        BigSwampZombie = -35,
        SmallSwampZombie = -34,
        BigSlimedZombie = -33,
        SmallSlimedZombie = -32,
        BigPincushionZombie = -31,
        SmallPincushionZombie = -30,
        BigBaldZombie = -29,
        SmallBaldZombie = -28,
        BigZombie = -27,
        SmallZombie = -26,
        BigCrimslime = -25,
        LittleCrimslime = -24,
        BigCrimera = -23,
        LittleCrimera = -22,
        GiantMossHornet = -21,
        BigMossHornet = -20,
        LittleMossHornet = -19,
        TinyMossHornet = -18,
        BigStinger = -17,
        LittleStinger = -16,
        HeavySkeleton = -15,
        BigBoned = -14,
        ShortBones = -13,
        BigEater = -12,
        LittleEater = -11,
        JungleSlime = -10,
        YellowSlime = -9,
        RedSlime = -8,
        PurpleSlime = -7,
        BlackSlime = -6,
        BabySlime = -5,
        Pinky = -4,
        GreenSlime = -3,
        Slimer2 = -2,
        Slimeling = -1,
        None = 0,
        BlueSlime = 1,
        DemonEye = 2,
        Zombie = 3,
        EyeofCthulhu = 4,
        ServantofCthulhu = 5,
        EaterofSouls = 6,
        DevourerHead = 7,
        DevourerBody = 8,
        DevourerTail = 9,
        GiantWormHead = 10,
        GiantWormBody = 11,
        GiantWormTail = 12,
        EaterofWorldsHead = 13,
        EaterofWorldsBody = 14,
        EaterofWorldsTail = 15,
        MotherSlime = 16,
        Merchant = 17,
        Nurse = 18,
        ArmsDealer = 19,
        Dryad = 20,
        Skeleton = 21,
        Guide = 22,
        MeteorHead = 23,
        FireImp = 24,
        BurningSphere = 25,
        GoblinPeon = 26,
        GoblinThief = 27,
        GoblinWarrior = 28,
        GoblinSorcerer = 29,
        ChaosBall = 30,
        AngryBones = 31,
        DarkCaster = 32,
        WaterSphere = 33,
        CursedSkull = 34,
        SkeletronHead = 35,
        SkeletronHand = 36,
        OldMan = 37,
        Demolitionist = 38,
        BoneSerpentHead = 39,
        BoneSerpentBody = 40,
        BoneSerpentTail = 41,
        Hornet = 42,
        ManEater = 43,
        UndeadMiner = 44,
        Tim = 45,
        Bunny = 46,
        CorruptBunny = 47,
        Harpy = 48,
        CaveBat = 49,
        KingSlime = 50,
        JungleBat = 51,
        DoctorBones = 52,
        TheGroom = 53,
        Clothier = 54,
        Goldfish = 55,
        Snatcher = 56,
        CorruptGoldfish = 57,
        Piranha = 58,
        LavaSlime = 59,
        Hellbat = 60,
        Vulture = 61,
        Demon = 62,
        BlueJellyfish = 63,
        PinkJellyfish = 64,
        Shark = 65,
        VoodooDemon = 66,
        Crab = 67,
        DungeonGuardian = 68,
        Antlion = 69,
        SpikeBall = 70,
        DungeonSlime = 71,
        BlazingWheel = 72,
        GoblinScout = 73,
        Bird = 74,
        Pixie = 75,
        None2 = 76,
        ArmoredSkeleton = 77,
        Mummy = 78,
        DarkMummy = 79,
        LightMummy = 80,
        CorruptSlime = 81,
        Wraith = 82,
        CursedHammer = 83,
        EnchantedSword = 84,
        Mimic = 85,
        Unicorn = 86,
        WyvernHead = 87,
        WyvernLegs = 88,
        WyvernBody = 89,
        WyvernBody2 = 90,
        WyvernBody3 = 91,
        WyvernTail = 92,
        GiantBat = 93,
        Corruptor = 94,
        DiggerHead = 95,
        DiggerBody = 96,
        DiggerTail = 97,
        SeekerHead = 98,
        SeekerBody = 99,
        SeekerTail = 100,
        Clinger = 101,
        AnglerFish = 102,
        GreenJellyfish = 103,
        Werewolf = 104,
        BoundGoblin = 105,
        BoundWizard = 106,
        GoblinTinkerer = 107,
        Wizard = 108,
        Clown = 109,
        SkeletonArcher = 110,
        GoblinArcher = 111,
        VileSpit = 112,
        WallofFlesh = 113,
        WallofFleshEye = 114,
        TheHungry = 115,
        TheHungryII = 116,
        LeechHead = 117,
        LeechBody = 118,
        LeechTail = 119,
        ChaosElemental = 120,
        Slimer = 121,
        Gastropod = 122,
        BoundMechanic = 123,
        Mechanic = 124,
        Retinazer = 125,
        Spazmatism = 126,
        SkeletronPrime = 127,
        PrimeCannon = 128,
        PrimeSaw = 129,
        PrimeVice = 130,
        PrimeLaser = 131,
        BaldZombie = 132,
        WanderingEye = 133,
        TheDestroyer = 134,
        TheDestroyerBody = 135,
        TheDestroyerTail = 136,
        IlluminantBat = 137,
        IlluminantSlime = 138,
        Probe = 139,
        PossessedArmor = 140,
        ToxicSludge = 141,
        SantaClaus = 142,
        SnowmanGangsta = 143,
        MisterStabby = 144,
        SnowBalla = 145,
        None3 = 146,
        IceSlime = 147,
        Penguin = 148,
        PenguinBlack = 149,
        IceBat = 150,
        Lavabat = 151,
        GiantFlyingFox = 152,
        GiantTortoise = 153,
        IceTortoise = 154,
        Wolf = 155,
        RedDevil = 156,
        Arapaima = 157,
        VampireBat = 158,
        Vampire = 159,
        Truffle = 160,
        ZombieEskimo = 161,
        Frankenstein = 162,
        BlackRecluse = 163,
        WallCreeper = 164,
        WallCreeperWall = 165,
        SwampThing = 166,
        UndeadViking = 167,
        CorruptPenguin = 168,
        IceElemental = 169,
        PigronCorruption = 170,
        PigronHallow = 171,
        RuneWizard = 172,
        Crimera = 173,
        Herpling = 174,
        AngryTrapper = 175,
        MossHornet = 176,
        Derpling = 177,
        Steampunker = 178,
        CrimsonAxe = 179,
        PigronCrimson = 180,
        FaceMonster = 181,
        FloatyGross = 182,
        Crimslime = 183,
        SpikedIceSlime = 184,
        SnowFlinx = 185,
        PincushionZombie = 186,
        SlimedZombie = 187,
        SwampZombie = 188,
        TwiggyZombie = 189,
        CataractEye = 190,
        SleepyEye = 191,
        DialatedEye = 192,
        GreenEye = 193,
        PurpleEye = 194,
        LostGirl = 195,
        Nymph = 196,
        ArmoredViking = 197,
        Lihzahrd = 198,
        LihzahrdCrawler = 199,
        FemaleZombie = 200,
        HeadacheSkeleton = 201,
        MisassembledSkeleton = 202,
        PantlessSkeleton = 203,
        SpikedJungleSlime = 204,
        Moth = 205,
        IcyMerman = 206,
        DyeTrader = 207,
        PartyGirl = 208,
        Cyborg = 209,
        Bee = 210,
        BeeSmall = 211,
        PirateDeckhand = 212,
        PirateCorsair = 213,
        PirateDeadeye = 214,
        PirateCrossbower = 215,
        PirateCaptain = 216,
        CochinealBeetle = 217,
        CyanBeetle = 218,
        LacBeetle = 219,
        SeaSnail = 220,
        Squid = 221,
        QueenBee = 222,
        ZombieRaincoat = 223,
        FlyingFish = 224,
        UmbrellaSlime = 225,
        FlyingSnake = 226,
        Painter = 227,
        WitchDoctor = 228,
        Pirate = 229,
        GoldfishWalker = 230,
        HornetFatty = 231,
        HornetHoney = 232,
        HornetLeafy = 233,
        HornetSpikey = 234,
        HornetStingy = 235,
        JungleCreeper = 236,
        JungleCreeperWall = 237,
        BlackRecluseWall = 238,
        BloodCrawler = 239,
        BloodCrawlerWall = 240,
        BloodFeeder = 241,
        BloodJelly = 242,
        IceGolem = 243,
        RainbowSlime = 244,
        Golem = 245,
        GolemHead = 246,
        GolemFistLeft = 247,
        GolemFistRight = 248,
        GolemHeadFree = 249,
        AngryNimbus = 250,
        Eyezor = 251,
        Parrot = 252,
        Reaper = 253,
        ZombieMushroom = 254,
        ZombieMushroomHat = 255,
        FungoFish = 256,
        AnomuraFungus = 257,
        MushiLadybug = 258,
        FungiBulb = 259,
        GiantFungiBulb = 260,
        FungiSpore = 261,
        Plantera = 262,
        PlanterasHook = 263,
        PlanterasTentacle = 264,
        Spore = 265,
        BrainofCthulhu = 266,
        Creeper = 267,
        IchorSticker = 268,
        RustyArmoredBonesAxe = 269,
        RustyArmoredBonesFlail = 270,
        RustyArmoredBonesSword = 271,
        RustyArmoredBonesSwordNoArmor = 272,
        BlueArmoredBones = 273,
        BlueArmoredBonesMace = 274,
        BlueArmoredBonesNoPants = 275,
        BlueArmoredBonesSword = 276,
        HellArmoredBones = 277,
        HellArmoredBonesSpikeShield = 278,
        HellArmoredBonesMace = 279,
        HellArmoredBonesSword = 280,
        RaggedCaster = 281,
        RaggedCasterOpenCoat = 282,
        Necromancer = 283,
        NecromancerArmored = 284,
        DiabolistRed = 285,
        DiabolistWhite = 286,
        BoneLee = 287,
        DungeonSpirit = 288,
        GiantCursedSkull = 289,
        Paladin = 290,
        SkeletonSniper = 291,
        TacticalSkeleton = 292,
        SkeletonCommando = 293,
        AngryBonesBig = 294,
        AngryBonesBigMuscle = 295,
        AngryBonesBigHelmet = 296,
        BirdBlue = 297,
        BirdRed = 298,
        Squirrel = 299,
        Mouse = 300,
        Raven = 301,
        SlimeMasked = 302,
        BunnySlimed = 303,
        HoppinJack = 304,
        Scarecrow1 = 305,
        Scarecrow2 = 306,
        Scarecrow3 = 307,
        Scarecrow4 = 308,
        Scarecrow5 = 309,
        Scarecrow6 = 310,
        Scarecrow7 = 311,
        Scarecrow8 = 312,
        Scarecrow9 = 313,
        Scarecrow10 = 314,
        HeadlessHorseman = 315,
        Ghost = 316,
        DemonEyeOwl = 317,
        DemonEyeSpaceship = 318,
        ZombieDoctor = 319,
        ZombieSuperman = 320,
        ZombiePixie = 321,
        SkeletonTopHat = 322,
        SkeletonAstonaut = 323,
        SkeletonAlien = 324,
        MourningWood = 325,
        Splinterling = 326,
        Pumpking = 327,
        PumpkingBlade = 328,
        Hellhound = 329,
        Poltergeist = 330,
        ZombieXmas = 331,
        ZombieSweater = 332,
        SlimeRibbonWhite = 333,
        SlimeRibbonYellow = 334,
        SlimeRibbonGreen = 335,
        SlimeRibbonRed = 336,
        BunnyXmas = 337,
        ZombieElf = 338,
        ZombieElfBeard = 339,
        ZombieElfGirl = 340,
        PresentMimic = 341,
        GingerbreadMan = 342,
        Yeti = 343,
        Everscream = 344,
        IceQueen = 345,
        SantaNK1 = 346,
        ElfCopter = 347,
        Nutcracker = 348,
        NutcrackerSpinning = 349,
        ElfArcher = 350,
        Krampus = 351,
        Flocko = 352,
        Stylist = 353,
        WebbedStylist = 354,
        Firefly = 355,
        Butterfly = 356,
        Worm = 357,
        LightningBug = 358,
        Snail = 359,
        GlowingSnail = 360,
        Frog = 361,
        Duck = 362,
        Duck2 = 363,
        DuckWhite = 364,
        DuckWhite2 = 365,
        ScorpionBlack = 366,
        Scorpion = 367,
        TravellingMerchant = 368,
        Angler = 369,
        DukeFishron = 370,
        DetonatingBubble = 371,
        Sharkron = 372,
        Sharkron2 = 373,
        TruffleWorm = 374,
        TruffleWormDigger = 375,
        SleepingAngler = 376,
        Grasshopper = 377,
        ChatteringTeethBomb = 378,
        CultistArcherBlue = 379,
        CultistArcherWhite = 380,
        BrainScrambler = 381,
        RayGunner = 382,
        MartianOfficer = 383,
        ForceBubble = 384,
        GrayGrunt = 385,
        MartianEngineer = 386,
        MartianTurret = 387,
        MartianDrone = 388,
        GigaZapper = 389,
        ScutlixRider = 390,
        Scutlix = 391,
        MartianSaucer = 392,
        MartianSaucerTurret = 393,
        MartianSaucerCannon = 394,
        MartianSaucerCore = 395,
        MoonLordHead = 396,
        MoonLordHand = 397,
        MoonLordCore = 398,
        MartianProbe = 399,
        MoonLordFreeEye = 400,
        MoonLordLeechBlob = 401,
        StardustWormHead = 402,
        StardustWormBody = 403,
        StardustWormTail = 404,
        StardustCellBig = 405,
        StardustCellSmall = 406,
        StardustJellyfishBig = 407,
        StardustJellyfishSmall = 408,
        StardustSpiderBig = 409,
        StardustSpiderSmall = 410,
        StardustSoldier = 411,
        SolarCrawltipedeHead = 412,
        SolarCrawltipedeBody = 413,
        SolarCrawltipedeTail = 414,
        SolarDrakomire = 415,
        SolarDrakomireRider = 416,
        SolarSroller = 417,
        SolarCorite = 418,
        SolarSolenian = 419,
        NebulaBrain = 420,
        NebulaHeadcrab = 421,
        NebulaBeast = 423,
        NebulaSoldier = 424,
        VortexRifleman = 425,
        VortexHornetQueen = 426,
        VortexHornet = 427,
        VortexLarva = 428,
        VortexSoldier = 429,
        ArmedZombie = 430,
        ArmedZombieEskimo = 431,
        ArmedZombiePincussion = 432,
        ArmedZombieSlimed = 433,
        ArmedZombieSwamp = 434,
        ArmedZombieTwiggy = 435,
        ArmedZombieCenx = 436,
        CultistTablet = 437,
        CultistDevote = 438,
        CultistBoss = 439,
        CultistBossClone = 440,
        GoldBird = 442,
        GoldBunny = 443,
        GoldButterfly = 444,
        GoldFrog = 445,
        GoldGrasshopper = 446,
        GoldMouse = 447,
        GoldWorm = 448,
        BoneThrowingSkeleton = 449,
        BoneThrowingSkeleton2 = 450,
        BoneThrowingSkeleton3 = 451,
        BoneThrowingSkeleton4 = 452,
        SkeletonMerchant = 453,
        CultistDragonHead = 454,
        CultistDragonBody1 = 455,
        CultistDragonBody2 = 456,
        CultistDragonBody3 = 457,
        CultistDragonBody4 = 458,
        CultistDragonTail = 459,
        Butcher = 460,
        CreatureFromTheDeep = 461,
        Fritz = 462,
        Nailhead = 463,
        CrimsonBunny = 464,
        CrimsonGoldfish = 465,
        Psycho = 466,
        DeadlySphere = 467,
        DrManFly = 468,
        ThePossessed = 469,
        CrimsonPenguin = 470,
        GoblinSummoner = 471,
        ShadowFlameApparition = 472,
        BigMimicCorruption = 473,
        BigMimicCrimson = 474,
        BigMimicHallow = 475,
        BigMimicJungle = 476,
        Mothron = 477,
        MothronEgg = 478,
        MothronSpawn = 479,
        Medusa = 480,
        GreekSkeleton = 481,
        GraniteGolem = 482,
        GraniteFlyer = 483,
        EnchantedNightcrawler = 484,
        Grubby = 485,
        Sluggy = 486,
        Buggy = 487,
        TargetDummy = 488,
        BloodZombie = 489,
        Drippler = 490,
        PirateShip = 491,
        PirateShipCannon = 492,
        LunarTowerStardust = 493,
        Crawdad = 494,
        Crawdad2 = 495,
        GiantShelly = 496,
        GiantShelly2 = 497,
        Salamander = 498,
        Salamander2 = 499,
        Salamander3 = 500,
        Salamander4 = 501,
        Salamander5 = 502,
        Salamander6 = 503,
        Salamander7 = 504,
        Salamander8 = 505,
        Salamander9 = 506,
        LunarTowerNebula = 507,
        LunarTowerVortex = 422,
        TaxCollector = 441,
        WalkingAntlion = 508,
        FlyingAntlion = 509,
        DuneSplicerHead = 510,
        DuneSplicerBody = 511,
        DuneSplicerTail = 512,
        TombCrawlerHead = 513,
        TombCrawlerBody = 514,
        TombCrawlerTail = 515,
        SolarFlare = 516,
        LunarTowerSolar = 517,
        SolarSpearman = 518,
        SolarGoop = 519,
        MartianWalker = 520,
        AncientCultistSquidhead = 521,
        AncientLight = 522,
        AncientDoom = 523,
        DesertGhoul = 524,
        DesertGhoulCorruption = 525,
        DesertGhoulCrimson = 526,
        DesertGhoulHallow = 527,
        DesertLamiaLight = 528,
        DesertLamiaDark = 529,
        DesertScorpionWalk = 530,
        DesertScorpionWall = 531,
        DesertBeast = 532,
        DesertDjinn = 533,
        DemonTaxCollector = 534,
        SlimeSpiked = 535,
        TheBride = 536,
        SandSlime = 537,
        SquirrelRed = 538,
        SquirrelGold = 539,
        PartyBunny = 540,
        SandElemental = 541,
        SandShark = 542,
        SandsharkCorrupt = 543,
        SandsharkCrimson = 544,
        SandsharkHallow = 545,
        Tumbleweed = 546,
        DD2AttackerTest = 547,
        DD2EterniaCrystal = 548,
        DD2LanePortal = 549,
        DD2Bartender = 550,
        DD2Betsy = 551,
        DD2GoblinT1 = 552,
        DD2GoblinT2 = 553,
        DD2GoblinT3 = 554,
        DD2GoblinBomberT1 = 555,
        DD2GoblinBomberT2 = 556,
        DD2GoblinBomberT3 = 557,
        DD2WyvernT1 = 558,
        DD2WyvernT2 = 559,
        DD2WyvernT3 = 560,
        DD2JavelinstT1 = 561,
        DD2JavelinstT2 = 562,
        DD2JavelinstT3 = 563,
        DD2DarkMageT1 = 564,
        DD2DarkMageT3 = 565,
        DD2SkeletonT1 = 566,
        DD2SkeletonT3 = 567,
        DD2WitherBeastT2 = 568,
        DD2WitherBeastT3 = 569,
        DD2DrakinT2 = 570,
        DD2DrakinT3 = 571,
        DD2KoboldWalkerT2 = 572,
        DD2KoboldWalkerT3 = 573,
        DD2KoboldFlyerT2 = 574,
        DD2KoboldFlyerT3 = 575,
        DD2OgreT2 = 576,
        DD2OgreT3 = 577,
        DD2LightningBugT3 = 578,
        BartenderUnconscious = 579,
#pragma warning restore 1591
    }
}