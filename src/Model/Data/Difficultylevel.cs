using System;
using System.Collections.Generic;

namespace D2SLib.Model.Data;

public partial class Difficultylevel
{
    public string? Name { get; set; }

    public long? ResistPenalty { get; set; }

    public long? ResistPenaltyNonExpansion { get; set; }

    public long? DeathExpPenalty { get; set; }

    public long? MonsterSkillBonus { get; set; }

    public long? MonsterFreezeDivisor { get; set; }

    public long? MonsterColdDivisor { get; set; }

    public long? AiCurseDivisor { get; set; }

    public long? LifeStealDivisor { get; set; }

    public long? ManaStealDivisor { get; set; }

    public long? UniqueDamageBonus { get; set; }

    public long? ChampionDamageBonus { get; set; }

    public long? PlayerDamagePercentVsplayer { get; set; }

    public long? PlayerDamagePercentVsmercenary { get; set; }

    public long? PlayerDamagePercentVsprimeEvil { get; set; }

    public long? PlayerHitReactBufferVsplayer { get; set; }

    public long? PlayerHitReactBufferVsmonster { get; set; }

    public long? MercenaryDamagePercentVsplayer { get; set; }

    public long? MercenaryDamagePercentVsmercenary { get; set; }

    public long? MercenaryDamagePercentVsboss { get; set; }

    public long? MercenaryMaxStunLength { get; set; }

    public long? PrimeEvilDamagePercentVsplayer { get; set; }

    public long? PrimeEvilDamagePercentVsmercenary { get; set; }

    public long? PrimeEvilDamagePercentVspet { get; set; }

    public long? PetDamagePercentVsplayer { get; set; }

    public long? MonsterCedamagePercent { get; set; }

    public long? MonsterFireEnchantExplosionDamagePercent { get; set; }

    public long? StaticFieldMin { get; set; }

    public long? GambleRare { get; set; }

    public long? GambleSet { get; set; }

    public long? GambleUnique { get; set; }

    public long? GambleUber { get; set; }

    public long? GambleUltra { get; set; }
}
