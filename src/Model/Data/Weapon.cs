using System;
using System.Collections.Generic;

namespace D2SLib.Model.Data;

public class Range
{
    public int min { get; set; }
    public int max { get; set; }

    public Range(int min, int max)
    {
        this.min = min;
        this.max = max;
    }
}

public partial class Weapon : DBItem
{
    public long? _1or2handed { get; set; }
    public long? _2handed { get; set; }
    public long? _2handmindam { get; set; }
    public long? _2handmaxdam { get; set; }
    public long? Minmisdam { get; set; }
    public long? Maxmisdam { get; set; }
    public long? Rangeadder { get; set; }
    public string? Wclass { get; set; }
    public string? _2handedwclass { get; set; }
    public string? HitClass { get; set; }
    public string? Comment { get; set; }
    public long? AutoPrefix { get; set; }
    public long? DexBonus { get; set; }
    public long? Durability { get; set; }
    public long? MagicLvl { get; set; }
    public string? Normcode { get; set; }
    public string? Quivered { get; set; }
    public string? Setinvfile { get; set; }
    public long? StrBonus { get; set; }
    public string? Ubercode { get; set; }
    public string? Ultracode { get; set; }
}
