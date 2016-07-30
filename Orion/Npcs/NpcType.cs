﻿using System;

namespace Orion.Npcs
{
	/// <summary>
	/// Specifies the type of an <see cref="INpc"/> instance.
	/// </summary>
	public struct NpcType : IEquatable<NpcType>
	{
#pragma warning disable 1591
		public static NpcType AncientCultistSquidhead => (NpcType)521;
		public static NpcType AncientDoom => (NpcType)523;
		public static NpcType AncientLight => (NpcType)522;
		public static NpcType Angler => (NpcType)369;
		public static NpcType AnglerFish => (NpcType)102;
		public static NpcType AngryBones => (NpcType)31;
		public static NpcType AngryBonesBig => (NpcType)294;
		public static NpcType AngryBonesBigHelmet => (NpcType)296;
		public static NpcType AngryBonesBigMuscle => (NpcType)295;
		public static NpcType AngryNimbus => (NpcType)250;
		public static NpcType AngryTrapper => (NpcType)175;
		public static NpcType AnomuraFungus => (NpcType)257;
		public static NpcType Antlion => (NpcType)69;
		public static NpcType Arapaima => (NpcType)157;
		public static NpcType ArmedZombie => (NpcType)430;
		public static NpcType ArmedZombieCenx => (NpcType)436;
		public static NpcType ArmedZombieEskimo => (NpcType)431;
		public static NpcType ArmedZombiePincussion => (NpcType)432;
		public static NpcType ArmedZombieSlimed => (NpcType)433;
		public static NpcType ArmedZombieSwamp => (NpcType)434;
		public static NpcType ArmedZombieTwiggy => (NpcType)435;
		public static NpcType ArmoredSkeleton => (NpcType)77;
		public static NpcType ArmoredViking => (NpcType)197;
		public static NpcType ArmsDealer => (NpcType)19;
		public static NpcType BabySlime => (NpcType)(-5);
		public static NpcType BaldZombie => (NpcType)132;
		public static NpcType Bee => (NpcType)210;
		public static NpcType BeeSmall => (NpcType)211;
		public static NpcType BigBaldZombie => (NpcType)(-29);
		public static NpcType BigBoned => (NpcType)(-14);
		public static NpcType BigCrimera => (NpcType)(-23);
		public static NpcType BigCrimslime => (NpcType)(-25);
		public static NpcType BigEater => (NpcType)(-12);
		public static NpcType BigFemaleZombie => (NpcType)(-45);
		public static NpcType BigHeadacheSkeleton => (NpcType)(-49);
		public static NpcType BigHornetFatty => (NpcType)(-57);
		public static NpcType BigHornetHoney => (NpcType)(-59);
		public static NpcType BigHornetLeafy => (NpcType)(-61);
		public static NpcType BigHornetSpikey => (NpcType)(-63);
		public static NpcType BigHornetStingy => (NpcType)(-65);
		public static NpcType BigMimicCorruption => (NpcType)473;
		public static NpcType BigMimicCrimson => (NpcType)474;
		public static NpcType BigMimicHallow => (NpcType)475;
		public static NpcType BigMimicJungle => (NpcType)476;
		public static NpcType BigMisassembledSkeleton => (NpcType)(-51);
		public static NpcType BigMossHornet => (NpcType)(-20);
		public static NpcType BigPantlessSkeleton => (NpcType)(-53);
		public static NpcType BigPincushionZombie => (NpcType)(-31);
		public static NpcType BigRainZombie => (NpcType)(-55);
		public static NpcType BigSkeleton => (NpcType)(-47);
		public static NpcType BigSlimedZombie => (NpcType)(-33);
		public static NpcType BigStinger => (NpcType)(-17);
		public static NpcType BigSwampZombie => (NpcType)(-35);
		public static NpcType BigTwiggyZombie => (NpcType)(-37);
		public static NpcType BigZombie => (NpcType)(-27);
		public static NpcType Bird => (NpcType)74;
		public static NpcType BirdBlue => (NpcType)297;
		public static NpcType BirdRed => (NpcType)298;
		public static NpcType BlackRecluse => (NpcType)163;
		public static NpcType BlackRecluseWall => (NpcType)238;
		public static NpcType BlackSlime => (NpcType)(-6);
		public static NpcType BlazingWheel => (NpcType)72;
		public static NpcType BloodCrawler => (NpcType)239;
		public static NpcType BloodCrawlerWall => (NpcType)240;
		public static NpcType BloodFeeder => (NpcType)241;
		public static NpcType BloodJelly => (NpcType)242;
		public static NpcType BloodZombie => (NpcType)489;
		public static NpcType BlueArmoredBones => (NpcType)273;
		public static NpcType BlueArmoredBonesMace => (NpcType)274;
		public static NpcType BlueArmoredBonesNoPants => (NpcType)275;
		public static NpcType BlueArmoredBonesSword => (NpcType)276;
		public static NpcType BlueJellyfish => (NpcType)63;
		public static NpcType BlueSlime => (NpcType)1;
		public static NpcType BoneLee => (NpcType)287;
		public static NpcType BoneSerpentBody => (NpcType)40;
		public static NpcType BoneSerpentHead => (NpcType)39;
		public static NpcType BoneSerpentTail => (NpcType)41;
		public static NpcType BoneThrowingSkeleton => (NpcType)449;
		public static NpcType BoneThrowingSkeleton2 => (NpcType)450;
		public static NpcType BoneThrowingSkeleton3 => (NpcType)451;
		public static NpcType BoneThrowingSkeleton4 => (NpcType)452;
		public static NpcType BoundGoblin => (NpcType)105;
		public static NpcType BoundMechanic => (NpcType)123;
		public static NpcType BoundWizard => (NpcType)106;
		public static NpcType BrainofCthulhu => (NpcType)266;
		public static NpcType BrainScrambler => (NpcType)381;
		public static NpcType Buggy => (NpcType)487;
		public static NpcType Bunny => (NpcType)46;
		public static NpcType BunnySlimed => (NpcType)303;
		public static NpcType BunnyXmas => (NpcType)337;
		public static NpcType BurningSphere => (NpcType)25;
		public static NpcType Butcher => (NpcType)460;
		public static NpcType Butterfly => (NpcType)356;
		public static NpcType CataractEye => (NpcType)190;
		public static NpcType CataractEye2 => (NpcType)(-38);
		public static NpcType CaveBat => (NpcType)49;
		public static NpcType ChaosBall => (NpcType)30;
		public static NpcType ChaosElemental => (NpcType)120;
		public static NpcType ChatteringTeethBomb => (NpcType)378;
		public static NpcType Clinger => (NpcType)101;
		public static NpcType Clothier => (NpcType)54;
		public static NpcType Clown => (NpcType)109;
		public static NpcType CochinealBeetle => (NpcType)217;
		public static NpcType CorruptBunny => (NpcType)47;
		public static NpcType CorruptGoldfish => (NpcType)57;
		public static NpcType Corruptor => (NpcType)94;
		public static NpcType CorruptPenguin => (NpcType)168;
		public static NpcType CorruptSlime => (NpcType)81;
		public static NpcType Crab => (NpcType)67;
		public static NpcType Crawdad => (NpcType)494;
		public static NpcType Crawdad2 => (NpcType)495;
		public static NpcType CreatureFromTheDeep => (NpcType)461;
		public static NpcType Creeper => (NpcType)267;
		public static NpcType Crimera => (NpcType)173;
		public static NpcType Crimslime => (NpcType)183;
		public static NpcType CrimsonAxe => (NpcType)179;
		public static NpcType CrimsonBunny => (NpcType)464;
		public static NpcType CrimsonGoldfish => (NpcType)465;
		public static NpcType CrimsonPenguin => (NpcType)470;
		public static NpcType CultistArcherBlue => (NpcType)379;
		public static NpcType CultistArcherWhite => (NpcType)380;
		public static NpcType CultistBoss => (NpcType)439;
		public static NpcType CultistBossClone => (NpcType)440;
		public static NpcType CultistDevote => (NpcType)438;
		public static NpcType CultistDragonBody1 => (NpcType)455;
		public static NpcType CultistDragonBody2 => (NpcType)456;
		public static NpcType CultistDragonBody3 => (NpcType)457;
		public static NpcType CultistDragonBody4 => (NpcType)458;
		public static NpcType CultistDragonHead => (NpcType)454;
		public static NpcType CultistDragonTail => (NpcType)459;
		public static NpcType CultistTablet => (NpcType)437;
		public static NpcType CursedHammer => (NpcType)83;
		public static NpcType CursedSkull => (NpcType)34;
		public static NpcType CyanBeetle => (NpcType)218;
		public static NpcType Cyborg => (NpcType)209;
		public static NpcType DarkCaster => (NpcType)32;
		public static NpcType DarkMummy => (NpcType)79;
		public static NpcType DeadlySphere => (NpcType)467;
		public static NpcType Demolitionist => (NpcType)38;
		public static NpcType Demon => (NpcType)62;
		public static NpcType DemonEye => (NpcType)2;
		public static NpcType DemonEye2 => (NpcType)(-43);
		public static NpcType DemonEyeOwl => (NpcType)317;
		public static NpcType DemonEyeSpaceship => (NpcType)318;
		public static NpcType DemonTaxCollector => (NpcType)534;
		public static NpcType Derpling => (NpcType)177;
		public static NpcType DesertBeast => (NpcType)532;
		public static NpcType DesertDjinn => (NpcType)533;
		public static NpcType DesertGhoul => (NpcType)524;
		public static NpcType DesertGhoulCorruption => (NpcType)525;
		public static NpcType DesertGhoulCrimson => (NpcType)526;
		public static NpcType DesertGhoulHallow => (NpcType)527;
		public static NpcType DesertLamiaDark => (NpcType)529;
		public static NpcType DesertLamiaLight => (NpcType)528;
		public static NpcType DesertScorpionWalk => (NpcType)530;
		public static NpcType DesertScorpionWall => (NpcType)531;
		public static NpcType DetonatingBubble => (NpcType)371;
		public static NpcType DevourerBody => (NpcType)8;
		public static NpcType DevourerHead => (NpcType)7;
		public static NpcType DevourerTail => (NpcType)9;
		public static NpcType DiabolistRed => (NpcType)285;
		public static NpcType DiabolistWhite => (NpcType)286;
		public static NpcType DialatedEye => (NpcType)192;
		public static NpcType DialatedEye2 => (NpcType)(-40);
		public static NpcType DiggerBody => (NpcType)96;
		public static NpcType DiggerHead => (NpcType)95;
		public static NpcType DiggerTail => (NpcType)97;
		public static NpcType DoctorBones => (NpcType)52;
		public static NpcType Drippler => (NpcType)490;
		public static NpcType DrManFly => (NpcType)468;
		public static NpcType Dryad => (NpcType)20;
		public static NpcType Duck => (NpcType)362;
		public static NpcType Duck2 => (NpcType)363;
		public static NpcType DuckWhite => (NpcType)364;
		public static NpcType DuckWhite2 => (NpcType)365;
		public static NpcType DukeFishron => (NpcType)370;
		public static NpcType DuneSplicerBody => (NpcType)511;
		public static NpcType DuneSplicerHead => (NpcType)510;
		public static NpcType DuneSplicerTail => (NpcType)512;
		public static NpcType DungeonGuardian => (NpcType)68;
		public static NpcType DungeonSlime => (NpcType)71;
		public static NpcType DungeonSpirit => (NpcType)288;
		public static NpcType DyeTrader => (NpcType)207;
		public static NpcType EaterofSouls => (NpcType)6;
		public static NpcType EaterofWorldsBody => (NpcType)14;
		public static NpcType EaterofWorldsHead => (NpcType)13;
		public static NpcType EaterofWorldsTail => (NpcType)15;
		public static NpcType ElfArcher => (NpcType)350;
		public static NpcType ElfCopter => (NpcType)347;
		public static NpcType EnchantedNightcrawler => (NpcType)484;
		public static NpcType EnchantedSword => (NpcType)84;
		public static NpcType Everscream => (NpcType)344;
		public static NpcType EyeofCthulhu => (NpcType)4;
		public static NpcType Eyezor => (NpcType)251;
		public static NpcType FaceMonster => (NpcType)181;
		public static NpcType FemaleZombie => (NpcType)200;
		public static NpcType Firefly => (NpcType)355;
		public static NpcType FireImp => (NpcType)24;
		public static NpcType FloatyGross => (NpcType)182;
		public static NpcType Flocko => (NpcType)352;
		public static NpcType FlyingAntlion => (NpcType)509;
		public static NpcType FlyingFish => (NpcType)224;
		public static NpcType FlyingSnake => (NpcType)226;
		public static NpcType ForceBubble => (NpcType)384;
		public static NpcType Frankenstein => (NpcType)162;
		public static NpcType Fritz => (NpcType)462;
		public static NpcType Frog => (NpcType)361;
		public static NpcType FungiBulb => (NpcType)259;
		public static NpcType FungiSpore => (NpcType)261;
		public static NpcType FungoFish => (NpcType)256;
		public static NpcType Gastropod => (NpcType)122;
		public static NpcType Ghost => (NpcType)316;
		public static NpcType GiantBat => (NpcType)93;
		public static NpcType GiantCursedSkull => (NpcType)289;
		public static NpcType GiantFlyingFox => (NpcType)152;
		public static NpcType GiantFungiBulb => (NpcType)260;
		public static NpcType GiantMossHornet => (NpcType)(-21);
		public static NpcType GiantShelly => (NpcType)496;
		public static NpcType GiantShelly2 => (NpcType)497;
		public static NpcType GiantTortoise => (NpcType)153;
		public static NpcType GiantWormBody => (NpcType)11;
		public static NpcType GiantWormHead => (NpcType)10;
		public static NpcType GiantWormTail => (NpcType)12;
		public static NpcType GigaZapper => (NpcType)389;
		public static NpcType GingerbreadMan => (NpcType)342;
		public static NpcType GlowingSnail => (NpcType)360;
		public static NpcType GoblinArcher => (NpcType)111;
		public static NpcType GoblinPeon => (NpcType)26;
		public static NpcType GoblinScout => (NpcType)73;
		public static NpcType GoblinSorcerer => (NpcType)29;
		public static NpcType GoblinSummoner => (NpcType)471;
		public static NpcType GoblinThief => (NpcType)27;
		public static NpcType GoblinTinkerer => (NpcType)107;
		public static NpcType GoblinWarrior => (NpcType)28;
		public static NpcType GoldBird => (NpcType)442;
		public static NpcType GoldBunny => (NpcType)443;
		public static NpcType GoldButterfly => (NpcType)444;
		public static NpcType Goldfish => (NpcType)55;
		public static NpcType GoldfishWalker => (NpcType)230;
		public static NpcType GoldFrog => (NpcType)445;
		public static NpcType GoldGrasshopper => (NpcType)446;
		public static NpcType GoldMouse => (NpcType)447;
		public static NpcType GoldWorm => (NpcType)448;
		public static NpcType Golem => (NpcType)245;
		public static NpcType GolemFistLeft => (NpcType)247;
		public static NpcType GolemFistRight => (NpcType)248;
		public static NpcType GolemHead => (NpcType)246;
		public static NpcType GolemHeadFree => (NpcType)249;
		public static NpcType GraniteFlyer => (NpcType)483;
		public static NpcType GraniteGolem => (NpcType)482;
		public static NpcType Grasshopper => (NpcType)377;
		public static NpcType GrayGrunt => (NpcType)385;
		public static NpcType GreekSkeleton => (NpcType)481;
		public static NpcType GreenEye => (NpcType)193;
		public static NpcType GreenEye2 => (NpcType)(-41);
		public static NpcType GreenJellyfish => (NpcType)103;
		public static NpcType GreenSlime => (NpcType)(-3);
		public static NpcType Grubby => (NpcType)485;
		public static NpcType Guide => (NpcType)22;
		public static NpcType Harpy => (NpcType)48;
		public static NpcType HeadacheSkeleton => (NpcType)201;
		public static NpcType HeadlessHorseman => (NpcType)315;
		public static NpcType HeavySkeleton => (NpcType)(-15);
		public static NpcType HellArmoredBones => (NpcType)277;
		public static NpcType HellArmoredBonesMace => (NpcType)279;
		public static NpcType HellArmoredBonesSpikeShield => (NpcType)278;
		public static NpcType HellArmoredBonesSword => (NpcType)280;
		public static NpcType Hellbat => (NpcType)60;
		public static NpcType Hellhound => (NpcType)329;
		public static NpcType Herpling => (NpcType)174;
		public static NpcType HoppinJack => (NpcType)304;
		public static NpcType Hornet => (NpcType)42;
		public static NpcType HornetFatty => (NpcType)231;
		public static NpcType HornetHoney => (NpcType)232;
		public static NpcType HornetLeafy => (NpcType)233;
		public static NpcType HornetSpikey => (NpcType)234;
		public static NpcType HornetStingy => (NpcType)235;
		public static NpcType IceBat => (NpcType)150;
		public static NpcType IceElemental => (NpcType)169;
		public static NpcType IceGolem => (NpcType)243;
		public static NpcType IceQueen => (NpcType)345;
		public static NpcType IceSlime => (NpcType)147;
		public static NpcType IceTortoise => (NpcType)154;
		public static NpcType IchorSticker => (NpcType)268;
		public static NpcType IcyMerman => (NpcType)206;
		public static NpcType IlluminantBat => (NpcType)137;
		public static NpcType IlluminantSlime => (NpcType)138;
		public static NpcType JungleBat => (NpcType)51;
		public static NpcType JungleCreeper => (NpcType)236;
		public static NpcType JungleCreeperWall => (NpcType)237;
		public static NpcType JungleSlime => (NpcType)(-10);
		public static NpcType KingSlime => (NpcType)50;
		public static NpcType Krampus => (NpcType)351;
		public static NpcType LacBeetle => (NpcType)219;
		public static NpcType Lavabat => (NpcType)151;
		public static NpcType LavaSlime => (NpcType)59;
		public static NpcType LeechBody => (NpcType)118;
		public static NpcType LeechHead => (NpcType)117;
		public static NpcType LeechTail => (NpcType)119;
		public static NpcType LightMummy => (NpcType)80;
		public static NpcType LightningBug => (NpcType)358;
		public static NpcType Lihzahrd => (NpcType)198;
		public static NpcType LihzahrdCrawler => (NpcType)199;
		public static NpcType LittleCrimera => (NpcType)(-22);
		public static NpcType LittleCrimslime => (NpcType)(-24);
		public static NpcType LittleEater => (NpcType)(-11);
		public static NpcType LittleHornetFatty => (NpcType)(-56);
		public static NpcType LittleHornetHoney => (NpcType)(-58);
		public static NpcType LittleHornetLeafy => (NpcType)(-60);
		public static NpcType LittleHornetSpikey => (NpcType)(-62);
		public static NpcType LittleHornetStingy => (NpcType)(-64);
		public static NpcType LittleMossHornet => (NpcType)(-19);
		public static NpcType LittleStinger => (NpcType)(-16);
		public static NpcType LostGirl => (NpcType)195;
		public static NpcType LunarTowerNebula => (NpcType)507;
		public static NpcType LunarTowerSolar => (NpcType)517;
		public static NpcType LunarTowerStardust => (NpcType)493;
		public static NpcType LunarTowerVortex => (NpcType)422;
		public static NpcType ManEater => (NpcType)43;
		public static NpcType MartianDrone => (NpcType)388;
		public static NpcType MartianEngineer => (NpcType)386;
		public static NpcType MartianOfficer => (NpcType)383;
		public static NpcType MartianProbe => (NpcType)399;
		public static NpcType MartianSaucer => (NpcType)392;
		public static NpcType MartianSaucerCannon => (NpcType)394;
		public static NpcType MartianSaucerCore => (NpcType)395;
		public static NpcType MartianSaucerTurret => (NpcType)393;
		public static NpcType MartianTurret => (NpcType)387;
		public static NpcType MartianWalker => (NpcType)520;
		public static NpcType Mechanic => (NpcType)124;
		public static NpcType Medusa => (NpcType)480;
		public static NpcType Merchant => (NpcType)17;
		public static NpcType MeteorHead => (NpcType)23;
		public static NpcType Mimic => (NpcType)85;
		public static NpcType MisassembledSkeleton => (NpcType)202;
		public static NpcType MisterStabby => (NpcType)144;
		public static NpcType MoonLordCore => (NpcType)398;
		public static NpcType MoonLordFreeEye => (NpcType)400;
		public static NpcType MoonLordHand => (NpcType)397;
		public static NpcType MoonLordHead => (NpcType)396;
		public static NpcType MoonLordLeechBlob => (NpcType)401;
		public static NpcType MossHornet => (NpcType)176;
		public static NpcType Moth => (NpcType)205;
		public static NpcType MotherSlime => (NpcType)16;
		public static NpcType Mothron => (NpcType)477;
		public static NpcType MothronEgg => (NpcType)478;
		public static NpcType MothronSpawn => (NpcType)479;
		public static NpcType MourningWood => (NpcType)325;
		public static NpcType Mouse => (NpcType)300;
		public static NpcType Mummy => (NpcType)78;
		public static NpcType MushiLadybug => (NpcType)258;
		public static NpcType Nailhead => (NpcType)463;
		public static NpcType NebulaBeast => (NpcType)423;
		public static NpcType NebulaBrain => (NpcType)420;
		public static NpcType NebulaHeadcrab => (NpcType)421;
		public static NpcType NebulaSoldier => (NpcType)424;
		public static NpcType Necromancer => (NpcType)283;
		public static NpcType NecromancerArmored => (NpcType)284;
		public static NpcType None => (NpcType)0;
		public static NpcType None2 => (NpcType)76;
		public static NpcType None3 => (NpcType)146;
		public static NpcType Nurse => (NpcType)18;
		public static NpcType Nutcracker => (NpcType)348;
		public static NpcType NutcrackerSpinning => (NpcType)349;
		public static NpcType Nymph => (NpcType)196;
		public static NpcType OldMan => (NpcType)37;
		public static NpcType Painter => (NpcType)227;
		public static NpcType Paladin => (NpcType)290;
		public static NpcType PantlessSkeleton => (NpcType)203;
		public static NpcType Parrot => (NpcType)252;
		public static NpcType PartyBunny => (NpcType)540;
		public static NpcType PartyGirl => (NpcType)208;
		public static NpcType Penguin => (NpcType)148;
		public static NpcType PenguinBlack => (NpcType)149;
		public static NpcType PigronCorruption => (NpcType)170;
		public static NpcType PigronCrimson => (NpcType)180;
		public static NpcType PigronHallow => (NpcType)171;
		public static NpcType PincushionZombie => (NpcType)186;
		public static NpcType PinkJellyfish => (NpcType)64;
		public static NpcType Pinky => (NpcType)(-4);
		public static NpcType Piranha => (NpcType)58;
		public static NpcType Pirate => (NpcType)229;
		public static NpcType PirateCaptain => (NpcType)216;
		public static NpcType PirateCorsair => (NpcType)213;
		public static NpcType PirateCrossbower => (NpcType)215;
		public static NpcType PirateDeadeye => (NpcType)214;
		public static NpcType PirateDeckhand => (NpcType)212;
		public static NpcType PirateShip => (NpcType)491;
		public static NpcType PirateShipCannon => (NpcType)492;
		public static NpcType Pixie => (NpcType)75;
		public static NpcType Plantera => (NpcType)262;
		public static NpcType PlanterasHook => (NpcType)263;
		public static NpcType PlanterasTentacle => (NpcType)264;
		public static NpcType Poltergeist => (NpcType)330;
		public static NpcType PossessedArmor => (NpcType)140;
		public static NpcType PresentMimic => (NpcType)341;
		public static NpcType PrimeCannon => (NpcType)128;
		public static NpcType PrimeLaser => (NpcType)131;
		public static NpcType PrimeSaw => (NpcType)129;
		public static NpcType PrimeVice => (NpcType)130;
		public static NpcType Probe => (NpcType)139;
		public static NpcType Psycho => (NpcType)466;
		public static NpcType Pumpking => (NpcType)327;
		public static NpcType PumpkingBlade => (NpcType)328;
		public static NpcType PurpleEye => (NpcType)194;
		public static NpcType PurpleEye2 => (NpcType)(-42);
		public static NpcType PurpleSlime => (NpcType)(-7);
		public static NpcType QueenBee => (NpcType)222;
		public static NpcType RaggedCaster => (NpcType)281;
		public static NpcType RaggedCasterOpenCoat => (NpcType)282;
		public static NpcType RainbowSlime => (NpcType)244;
		public static NpcType Raven => (NpcType)301;
		public static NpcType RayGunner => (NpcType)382;
		public static NpcType Reaper => (NpcType)253;
		public static NpcType RedDevil => (NpcType)156;
		public static NpcType RedSlime => (NpcType)(-8);
		public static NpcType Retinazer => (NpcType)125;
		public static NpcType RuneWizard => (NpcType)172;
		public static NpcType RustyArmoredBonesAxe => (NpcType)269;
		public static NpcType RustyArmoredBonesFlail => (NpcType)270;
		public static NpcType RustyArmoredBonesSword => (NpcType)271;
		public static NpcType RustyArmoredBonesSwordNoArmor => (NpcType)272;
		public static NpcType Salamander => (NpcType)498;
		public static NpcType Salamander2 => (NpcType)499;
		public static NpcType Salamander3 => (NpcType)500;
		public static NpcType Salamander4 => (NpcType)501;
		public static NpcType Salamander5 => (NpcType)502;
		public static NpcType Salamander6 => (NpcType)503;
		public static NpcType Salamander7 => (NpcType)504;
		public static NpcType Salamander8 => (NpcType)505;
		public static NpcType Salamander9 => (NpcType)506;
		public static NpcType SandSlime => (NpcType)537;
		public static NpcType SantaClaus => (NpcType)142;
		public static NpcType SantaNK1 => (NpcType)346;
		public static NpcType Scarecrow1 => (NpcType)305;
		public static NpcType Scarecrow10 => (NpcType)314;
		public static NpcType Scarecrow2 => (NpcType)306;
		public static NpcType Scarecrow3 => (NpcType)307;
		public static NpcType Scarecrow4 => (NpcType)308;
		public static NpcType Scarecrow5 => (NpcType)309;
		public static NpcType Scarecrow6 => (NpcType)310;
		public static NpcType Scarecrow7 => (NpcType)311;
		public static NpcType Scarecrow8 => (NpcType)312;
		public static NpcType Scarecrow9 => (NpcType)313;
		public static NpcType Scorpion => (NpcType)367;
		public static NpcType ScorpionBlack => (NpcType)366;
		public static NpcType Scutlix => (NpcType)391;
		public static NpcType ScutlixRider => (NpcType)390;
		public static NpcType SeaSnail => (NpcType)220;
		public static NpcType SeekerBody => (NpcType)99;
		public static NpcType SeekerHead => (NpcType)98;
		public static NpcType SeekerTail => (NpcType)100;
		public static NpcType ServantofCthulhu => (NpcType)5;
		public static NpcType ShadowFlameApparition => (NpcType)472;
		public static NpcType Shark => (NpcType)65;
		public static NpcType Sharkron => (NpcType)372;
		public static NpcType Sharkron2 => (NpcType)373;
		public static NpcType ShortBones => (NpcType)(-13);
		public static NpcType Skeleton => (NpcType)21;
		public static NpcType SkeletonAlien => (NpcType)324;
		public static NpcType SkeletonArcher => (NpcType)110;
		public static NpcType SkeletonAstonaut => (NpcType)323;
		public static NpcType SkeletonCommando => (NpcType)293;
		public static NpcType SkeletonMerchant => (NpcType)453;
		public static NpcType SkeletonSniper => (NpcType)291;
		public static NpcType SkeletonTopHat => (NpcType)322;
		public static NpcType SkeletronHand => (NpcType)36;
		public static NpcType SkeletronHead => (NpcType)35;
		public static NpcType SkeletronPrime => (NpcType)127;
		public static NpcType SleepingAngler => (NpcType)376;
		public static NpcType SleepyEye => (NpcType)191;
		public static NpcType SleepyEye2 => (NpcType)(-39);
		public static NpcType SlimedZombie => (NpcType)187;
		public static NpcType Slimeling => (NpcType)(-1);
		public static NpcType SlimeMasked => (NpcType)302;
		public static NpcType Slimer => (NpcType)121;
		public static NpcType Slimer2 => (NpcType)(-2);
		public static NpcType SlimeRibbonGreen => (NpcType)335;
		public static NpcType SlimeRibbonRed => (NpcType)336;
		public static NpcType SlimeRibbonWhite => (NpcType)333;
		public static NpcType SlimeRibbonYellow => (NpcType)334;
		public static NpcType SlimeSpiked => (NpcType)535;
		public static NpcType Sluggy => (NpcType)486;
		public static NpcType SmallBaldZombie => (NpcType)(-28);
		public static NpcType SmallFemaleZombie => (NpcType)(-44);
		public static NpcType SmallHeadacheSkeleton => (NpcType)(-48);
		public static NpcType SmallMisassembledSkeleton => (NpcType)(-50);
		public static NpcType SmallPantlessSkeleton => (NpcType)(-52);
		public static NpcType SmallPincushionZombie => (NpcType)(-30);
		public static NpcType SmallRainZombie => (NpcType)(-54);
		public static NpcType SmallSkeleton => (NpcType)(-46);
		public static NpcType SmallSlimedZombie => (NpcType)(-32);
		public static NpcType SmallSwampZombie => (NpcType)(-34);
		public static NpcType SmallTwiggyZombie => (NpcType)(-36);
		public static NpcType SmallZombie => (NpcType)(-26);
		public static NpcType Snail => (NpcType)359;
		public static NpcType Snatcher => (NpcType)56;
		public static NpcType SnowBalla => (NpcType)145;
		public static NpcType SnowFlinx => (NpcType)185;
		public static NpcType SnowmanGangsta => (NpcType)143;
		public static NpcType SolarCorite => (NpcType)418;
		public static NpcType SolarCrawltipedeBody => (NpcType)413;
		public static NpcType SolarCrawltipedeHead => (NpcType)412;
		public static NpcType SolarCrawltipedeTail => (NpcType)414;
		public static NpcType SolarDrakomire => (NpcType)415;
		public static NpcType SolarDrakomireRider => (NpcType)416;
		public static NpcType SolarFlare => (NpcType)516;
		public static NpcType SolarGoop => (NpcType)519;
		public static NpcType SolarSolenian => (NpcType)419;
		public static NpcType SolarSpearman => (NpcType)518;
		public static NpcType SolarSroller => (NpcType)417;
		public static NpcType Spazmatism => (NpcType)126;
		public static NpcType SpikeBall => (NpcType)70;
		public static NpcType SpikedIceSlime => (NpcType)184;
		public static NpcType SpikedJungleSlime => (NpcType)204;
		public static NpcType Splinterling => (NpcType)326;
		public static NpcType Spore => (NpcType)265;
		public static NpcType Squid => (NpcType)221;
		public static NpcType Squirrel => (NpcType)299;
		public static NpcType SquirrelGold => (NpcType)539;
		public static NpcType SquirrelRed => (NpcType)538;
		public static NpcType StardustCellBig => (NpcType)405;
		public static NpcType StardustCellSmall => (NpcType)406;
		public static NpcType StardustJellyfishBig => (NpcType)407;
		public static NpcType StardustJellyfishSmall => (NpcType)408;
		public static NpcType StardustSoldier => (NpcType)411;
		public static NpcType StardustSpiderBig => (NpcType)409;
		public static NpcType StardustSpiderSmall => (NpcType)410;
		public static NpcType StardustWormBody => (NpcType)403;
		public static NpcType StardustWormHead => (NpcType)402;
		public static NpcType StardustWormTail => (NpcType)404;
		public static NpcType Steampunker => (NpcType)178;
		public static NpcType Stylist => (NpcType)353;
		public static NpcType SwampThing => (NpcType)166;
		public static NpcType SwampZombie => (NpcType)188;
		public static NpcType TacticalSkeleton => (NpcType)292;
		public static NpcType TargetDummy => (NpcType)488;
		public static NpcType TaxCollector => (NpcType)441;
		public static NpcType TheBride => (NpcType)536;
		public static NpcType TheDestroyer => (NpcType)134;
		public static NpcType TheDestroyerBody => (NpcType)135;
		public static NpcType TheDestroyerTail => (NpcType)136;
		public static NpcType TheGroom => (NpcType)53;
		public static NpcType TheHungry => (NpcType)115;
		public static NpcType TheHungryII => (NpcType)116;
		public static NpcType ThePossessed => (NpcType)469;
		public static NpcType Tim => (NpcType)45;
		public static NpcType TinyMossHornet => (NpcType)(-18);
		public static NpcType TombCrawlerBody => (NpcType)514;
		public static NpcType TombCrawlerHead => (NpcType)513;
		public static NpcType TombCrawlerTail => (NpcType)515;
		public static NpcType ToxicSludge => (NpcType)141;
		public static NpcType TravellingMerchant => (NpcType)368;
		public static NpcType Truffle => (NpcType)160;
		public static NpcType TruffleWorm => (NpcType)374;
		public static NpcType TruffleWormDigger => (NpcType)375;
		public static NpcType TwiggyZombie => (NpcType)189;
		public static NpcType UmbrellaSlime => (NpcType)225;
		public static NpcType UndeadMiner => (NpcType)44;
		public static NpcType UndeadViking => (NpcType)167;
		public static NpcType Unicorn => (NpcType)86;
		public static NpcType Vampire => (NpcType)159;
		public static NpcType VampireBat => (NpcType)158;
		public static NpcType VileSpit => (NpcType)112;
		public static NpcType VoodooDemon => (NpcType)66;
		public static NpcType VortexHornet => (NpcType)427;
		public static NpcType VortexHornetQueen => (NpcType)426;
		public static NpcType VortexLarva => (NpcType)428;
		public static NpcType VortexRifleman => (NpcType)425;
		public static NpcType VortexSoldier => (NpcType)429;
		public static NpcType Vulture => (NpcType)61;
		public static NpcType WalkingAntlion => (NpcType)508;
		public static NpcType WallCreeper => (NpcType)164;
		public static NpcType WallCreeperWall => (NpcType)165;
		public static NpcType WallofFlesh => (NpcType)113;
		public static NpcType WallofFleshEye => (NpcType)114;
		public static NpcType WanderingEye => (NpcType)133;
		public static NpcType WaterSphere => (NpcType)33;
		public static NpcType WebbedStylist => (NpcType)354;
		public static NpcType Werewolf => (NpcType)104;
		public static NpcType WitchDoctor => (NpcType)228;
		public static NpcType Wizard => (NpcType)108;
		public static NpcType Wolf => (NpcType)155;
		public static NpcType Worm => (NpcType)357;
		public static NpcType Wraith => (NpcType)82;
		public static NpcType WyvernBody => (NpcType)89;
		public static NpcType WyvernBody2 => (NpcType)90;
		public static NpcType WyvernBody3 => (NpcType)91;
		public static NpcType WyvernHead => (NpcType)87;
		public static NpcType WyvernLegs => (NpcType)88;
		public static NpcType WyvernTail => (NpcType)92;
		public static NpcType YellowSlime => (NpcType)(-9);
		public static NpcType Yeti => (NpcType)343;
		public static NpcType Zombie => (NpcType)3;
		public static NpcType ZombieDoctor => (NpcType)319;
		public static NpcType ZombieElf => (NpcType)338;
		public static NpcType ZombieElfBeard => (NpcType)339;
		public static NpcType ZombieElfGirl => (NpcType)340;
		public static NpcType ZombieEskimo => (NpcType)161;
		public static NpcType ZombieMushroom => (NpcType)254;
		public static NpcType ZombieMushroomHat => (NpcType)255;
		public static NpcType ZombiePixie => (NpcType)321;
		public static NpcType ZombieRaincoat => (NpcType)223;
		public static NpcType ZombieSuperman => (NpcType)320;
		public static NpcType ZombieSweater => (NpcType)332;
		public static NpcType ZombieXmas => (NpcType)331;
#pragma warning restore 1591

		/// <summary>
		/// Determines if two <see cref="NpcType"/> instances are equal.
		/// </summary>
		/// <param name="type1">The first <see cref="NpcType"/> instance.</param>
		/// <param name="type2">The second <see cref="NpcType"/> instance.</param>
		/// <returns>true if <paramref name="type1"/> equals <paramref name="type2"/>, false otherwise.</returns>
		public static bool operator ==(NpcType type1, NpcType type2) => type1.Equals(type2);

		/// <summary>
		/// Converts a <see cref="NpcType"/> instance into its integer representation.
		/// </summary>
		/// <param name="type">The <see cref="NpcType"/> instance.</param>
		public static explicit operator int(NpcType type) => type._type;

		/// <summary>
		/// Converts an integer into its <see cref="NpcType"/> representation.
		/// </summary>
		/// <param name="i">The integer.</param>
		public static explicit operator NpcType(int i) => new NpcType(i);

		/// <summary>
		/// Determines if two <see cref="NpcType"/> instances are not equal.
		/// </summary>
		/// <param name="type1">The first <see cref="NpcType"/> instance.</param>
		/// <param name="type2">The second <see cref="NpcType"/> instance.</param>
		/// <returns>
		/// true if <paramref name="type1"/> does not equal <paramref name="type2"/>, false otherwise.
		/// </returns>
		public static bool operator !=(NpcType type1, NpcType type2) => !type1.Equals(type2);

		private readonly int _type;

		/// <summary>
		/// Initializes a new instance of the <see cref="NpcType"/> structure with the specified NPC
		/// type.
		/// </summary>
		/// <param name="type">The NPC type.</param>
		public NpcType(int type)
		{
			_type = type;
		}

		/// <summary>
		/// Determines if this instance equals another <see cref="NpcType"/> instance.
		/// </summary>
		/// <param name="other">The other <see cref="NpcType"/> instance.</param>
		/// <returns>true if this instance equals <paramref name="other"/>, false otherwise.</returns>
		public bool Equals(NpcType other) => _type == other._type;

		/// <summary>
		/// Determines if this instance equals another object instance.
		/// </summary>
		/// <param name="obj">The other object instance.</param>
		/// <returns>true if this instance equals <paramref name="obj"/>, false otherwise.</returns>
		public override bool Equals(object obj) => obj is NpcType && Equals((NpcType)obj);

		/// <summary>
		/// Gets the hash code for this instance.
		/// </summary>
		/// <returns>The hash code for this instance.</returns>
		public override int GetHashCode() => _type;

		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString() => $"{_type}";
	}
}
