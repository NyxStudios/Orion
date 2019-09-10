﻿namespace Orion.Players {
    /// <summary>
    /// Specifies the type of a buff.
    /// </summary>

    // TODO: work on better names.
    public enum BuffType : byte {
#pragma warning disable 1591
        None = 0,
        ObsidianSkin = 1,
        Regeneration = 2,
        Swiftness = 3,
        Gills = 4,
        Ironskin = 5,
        ManaRegeneration = 6,
        MagicPower = 7,
        Featherfall = 8,
        Spelunker = 9,
        Invisibility = 10,
        Shine = 11,
        NightOwl = 12,
        Battle = 13,
        Thorns = 14,
        WaterWalking = 15,
        Archery = 16,
        Hunter = 17,
        Gravitation = 18,
        ShadowOrb = 19,
        Poisoned = 20,
        PotionSickness = 21,
        Darkness = 22,
        Cursed = 23,
        OnFire = 24,
        Tipsy = 25,
        WellFed = 26,
        FairyBlue = 27,
        Werewolf = 28,
        Clairvoyance = 29,
        Bleeding = 30,
        Confused = 31,
        Slow = 32,
        Weak = 33,
        Merfolk = 34,
        Silenced = 35,
        BrokenArmor = 36,
        Horrified = 37,
        TheTongue = 38,
        CursedInferno = 39,
        PetBunny = 40,
        BabyPenguin = 41,
        PetTurtle = 42,
        PaladinsShield = 43,
        Frostburn = 44,
        BabyEater = 45,
        Chilled = 46,
        Frozen = 47,
        Honey = 48,
        Pygmies = 49,
        BabySkeletronHead = 50,
        BabyHornet = 51,
        TikiSpirit = 52,
        PetLizard = 53,
        PetParrot = 54,
        BabyTruffle = 55,
        PetSapling = 56,
        Wisp = 57,
        RapidHealing = 58,
        ShadowDodge = 59,
        LeafCrystal = 60,
        BabyDinosaur = 61,
        IceBarrier = 62,
        Panic = 63,
        BabySlime = 64,
        EyeballSpring = 65,
        BabySnowman = 66,
        Burning = 67,
        Suffocation = 68,
        Ichor = 69,
        Venom = 70,
        WeaponImbueVenom = 71,
        Midas = 72,
        WeaponImbueCursedFlames = 73,
        WeaponImbueFire = 74,
        WeaponImbueGold = 75,
        WeaponImbueIchor = 76,
        WeaponImbueNanites = 77,
        WeaponImbueConfetti = 78,
        WeaponImbuePoison = 79,
        Blackout = 80,
        PetSpider = 81,
        Squashling = 82,
        Ravens = 83,
        BlackCat = 84,
        CursedSapling = 85,
        WaterCandle = 86,
        Campfire = 87,
        ChaosState = 88,
        HeartLamp = 89,
        Rudolph = 90,
        Puppy = 91,
        BabyGrinch = 92,
        AmmoBox = 93,
        ManaSickness = 94,
        BeetleEndurance1 = 95,
        BeetleEndurance2 = 96,
        BeetleEndurance3 = 97,
        BeetleMight1 = 98,
        BeetleMight2 = 99,
        BeetleMight3 = 100,
        FairyRed = 101,
        FairyGreen = 102,
        Wet = 103,
        Mining = 104,
        Heartreach = 105,
        Calm = 106,
        Builder = 107,
        Titan = 108,
        Flipper = 109,
        Summoning = 110,
        Dangersense = 111,
        AmmoReservation = 112,
        Lifeforce = 113,
        Endurance = 114,
        Rage = 115,
        Inferno = 116,
        Wrath = 117,
        MinecartLeft = 118,
        Lovestruck = 119,
        Stinky = 120,
        Fishing = 121,
        Sonar = 122,
        Crate = 123,
        Warmth = 124,
        HornetMinion = 125,
        ImpMinion = 126,
        ZephyrFish = 127,
        BunnyMount = 128,
        PigronMount = 129,
        SlimeMount = 130,
        TurtleMount = 131,
        BeeMount = 132,
        SpiderMinion = 133,
        TwinEyesMinion = 134,
        PirateMinion = 135,
        MiniMinotaur = 136,
        Slimed = 137,
        MinecartRight = 138,
        SharknadoMinion = 139,
        UFOMinion = 140,
        UFOMount = 141,
        DrillMount = 142,
        ScutlixMount = 143,
        Electrified = 144,
        MoonLeech = 145,
        Sunflower = 146,
        MonsterBanner = 147,
        Rabies = 148,
        Webbed = 149,
        Bewitched = 150,
        SoulDrain = 151,
        MagicLantern = 152,
        ShadowFlame = 153,
        BabyFaceMonster = 154,
        CrimsonHeart = 155,
        Stoned = 156,
        PeaceCandle = 157,
        StarInBottle = 158,
        Sharpened = 159,
        Dazed = 160,
        DeadlySphere = 161,
        UnicornMount = 162,
        Obstructed = 163,
        VortexDebuff = 164,
        DryadsWard = 165,
        MinecartRightMech = 166,
        MinecartLeftMech = 167,
        CuteFishronMount = 168,
        BoneJavelin = 169,
        SolarShield1 = 170,
        SolarShield2 = 171,
        SolarShield3 = 172,
        NebulaUpLife1 = 173,
        NebulaUpLife2 = 174,
        NebulaUpLife3 = 175,
        NebulaUpMana1 = 176,
        NebulaUpMana2 = 177,
        NebulaUpMana3 = 178,
        NebulaUpDmg1 = 179,
        NebulaUpDmg2 = 180,
        NebulaUpDmg3 = 181,
        StardustMinion = 182,
        StardustMinionBleed = 183,
        MinecartLeftWood = 184,
        MinecartRightWood = 185,
        DryadsWardDebuff = 186,
        StardustGuardianMinion = 187,
        StardustDragonMinion = 188,
        Daybreak = 189,
        SuspiciousTentacle = 190,
        CompanionCube = 191,
        SugarRush = 192,
        BasiliskMount = 193,
        WindPushed = 194,
        WitheredArmor = 195,
        WitheredWeapon = 196,
        OgreSpit = 197,
        ParryDamageBuff = 198,
        NoBuilding = 199,
        PetDD2Gato = 200,
        PetDD2Ghost = 201,
        PetDD2Dragon = 202,
        BetsysCurse = 203,
        Oiled = 204,
        BallistaPanic = 205,
#pragma warning restore 1591
    }
}
