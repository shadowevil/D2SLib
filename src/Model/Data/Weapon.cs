using System;
using System.Collections.Generic;

namespace D2SLib.Model.Data;

public partial class Weapon
{
    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Type2 { get; set; }

    public string? Code { get; set; }

    public string? Alternategfx { get; set; }

    public string? Namestr { get; set; }

    public string? Version { get; set; }

    public string? Compactsave { get; set; }

    public long? Rarity { get; set; }

    public long? Spawnable { get; set; }

    public string? Transmogrify { get; set; }

    public string? TmogType { get; set; }

    public string? TmogMin { get; set; }

    public string? TmogMax { get; set; }

    public long? Mindam { get; set; }

    public long? Maxdam { get; set; }

    public string? _1or2handed { get; set; }

    public string? _2handed { get; set; }

    public string? _2handmindam { get; set; }

    public string? _2handmaxdam { get; set; }

    public string? Minmisdam { get; set; }

    public string? Maxmisdam { get; set; }

    public long? Rangeadder { get; set; }

    public long? Speed { get; set; }

    public long? StrBonus { get; set; }

    public string? DexBonus { get; set; }

    public long? Reqstr { get; set; }

    public long? Reqdex { get; set; }

    public long? Durability { get; set; }

    public string? Nodurability { get; set; }

    public long? Level { get; set; }

    public string? ShowLevel { get; set; }

    public long? Levelreq { get; set; }

    public long? Cost { get; set; }

    public long? GambleCost { get; set; }

    public string? MagicLvl { get; set; }

    public string? AutoPrefix { get; set; }

    public string? Normcode { get; set; }

    public string? Ubercode { get; set; }

    public string? Ultracode { get; set; }

    public string? Wclass { get; set; }

    public string? _2handedwclass { get; set; }

    public long? Component { get; set; }

    public string? HitClass { get; set; }

    public long? Invwidth { get; set; }

    public long? Invheight { get; set; }

    public string? Stackable { get; set; }

    public string? Minstack { get; set; }

    public string? Maxstack { get; set; }

    public string? Spawnstack { get; set; }

    public string? Flippyfile { get; set; }

    public string? Invfile { get; set; }

    public string? Uniqueinvfile { get; set; }

    public string? Setinvfile { get; set; }

    public long? Hasinv { get; set; }

    public long? Gemsockets { get; set; }

    public string? Gemapplytype { get; set; }

    public string? Comment { get; set; }

    public string? Useable { get; set; }

    public string? Dropsound { get; set; }

    public long? Dropsfxframe { get; set; }

    public string? Usesound { get; set; }

    public string? Unique { get; set; }

    public string? Transparent { get; set; }

    public long? Transtbl { get; set; }

    public string? Quivered { get; set; }

    public string? Lightradius { get; set; }

    public string? Belt { get; set; }

    public string? Quest { get; set; }

    public string? Questdiffcheck { get; set; }

    public string? Missiletype { get; set; }

    public long? Durwarning { get; set; }

    public string? Qntwarning { get; set; }

    public string? Gemoffset { get; set; }

    public long? Bitfield1 { get; set; }

    public string? CharsiMin { get; set; }

    public string? CharsiMax { get; set; }

    public string? CharsiMagicMin { get; set; }

    public string? CharsiMagicMax { get; set; }

    public long? CharsiMagicLvl { get; set; }

    public string? GheedMin { get; set; }

    public string? GheedMax { get; set; }

    public string? GheedMagicMin { get; set; }

    public string? GheedMagicMax { get; set; }

    public long? GheedMagicLvl { get; set; }

    public string? AkaraMin { get; set; }

    public string? AkaraMax { get; set; }

    public string? AkaraMagicMin { get; set; }

    public string? AkaraMagicMax { get; set; }

    public long? AkaraMagicLvl { get; set; }

    public string? FaraMin { get; set; }

    public string? FaraMax { get; set; }

    public string? FaraMagicMin { get; set; }

    public string? FaraMagicMax { get; set; }

    public long? FaraMagicLvl { get; set; }

    public string? LysanderMin { get; set; }

    public string? LysanderMax { get; set; }

    public string? LysanderMagicMin { get; set; }

    public string? LysanderMagicMax { get; set; }

    public long? LysanderMagicLvl { get; set; }

    public string? DrognanMin { get; set; }

    public string? DrognanMax { get; set; }

    public string? DrognanMagicMin { get; set; }

    public string? DrognanMagicMax { get; set; }

    public long? DrognanMagicLvl { get; set; }

    public string? HratliMin { get; set; }

    public string? HratliMax { get; set; }

    public string? HratliMagicMin { get; set; }

    public string? HratliMagicMax { get; set; }

    public long? HratliMagicLvl { get; set; }

    public string? AlkorMin { get; set; }

    public string? AlkorMax { get; set; }

    public string? AlkorMagicMin { get; set; }

    public string? AlkorMagicMax { get; set; }

    public long? AlkorMagicLvl { get; set; }

    public string? OrmusMin { get; set; }

    public string? OrmusMax { get; set; }

    public string? OrmusMagicMin { get; set; }

    public string? OrmusMagicMax { get; set; }

    public long? OrmusMagicLvl { get; set; }

    public string? ElzixMin { get; set; }

    public string? ElzixMax { get; set; }

    public string? ElzixMagicMin { get; set; }

    public string? ElzixMagicMax { get; set; }

    public long? ElzixMagicLvl { get; set; }

    public string? AshearaMin { get; set; }

    public string? AshearaMax { get; set; }

    public string? AshearaMagicMin { get; set; }

    public string? AshearaMagicMax { get; set; }

    public long? AshearaMagicLvl { get; set; }

    public string? CainMin { get; set; }

    public string? CainMax { get; set; }

    public string? CainMagicMin { get; set; }

    public string? CainMagicMax { get; set; }

    public long? CainMagicLvl { get; set; }

    public string? HalbuMin { get; set; }

    public string? HalbuMax { get; set; }

    public string? HalbuMagicMin { get; set; }

    public string? HalbuMagicMax { get; set; }

    public long? HalbuMagicLvl { get; set; }

    public string? JamellaMin { get; set; }

    public string? JamellaMax { get; set; }

    public string? JamellaMagicMin { get; set; }

    public string? JamellaMagicMax { get; set; }

    public long? JamellaMagicLvl { get; set; }

    public string? LarzukMin { get; set; }

    public string? LarzukMax { get; set; }

    public string? LarzukMagicMin { get; set; }

    public string? LarzukMagicMax { get; set; }

    public long? LarzukMagicLvl { get; set; }

    public string? AnyaMin { get; set; }

    public string? AnyaMax { get; set; }

    public string? AnyaMagicMin { get; set; }

    public string? AnyaMagicMax { get; set; }

    public long? AnyaMagicLvl { get; set; }

    public string? MalahMin { get; set; }

    public string? MalahMax { get; set; }

    public string? MalahMagicMin { get; set; }

    public string? MalahMagicMax { get; set; }

    public long? MalahMagicLvl { get; set; }

    public long? Transform { get; set; }

    public long? InvTrans { get; set; }

    public string? SkipName { get; set; }

    public string? NightmareUpgrade { get; set; }

    public string? HellUpgrade { get; set; }

    public long? Nameable { get; set; }

    public string? PermStoreItem { get; set; }

    public string? Diablocloneweight { get; set; }
}
