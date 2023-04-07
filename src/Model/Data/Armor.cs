using System;
using System.Collections.Generic;

namespace D2SLib.Model.Data;

public partial class Armor : DBItem
{
    public long? Minac { get; set; }
    public long? Maxac { get; set; }
    public string? Block { get; set; }
    public long? RArm { get; set; }
    public long? LArm { get; set; }
    public long? Torso { get; set; }
    public long? Legs { get; set; }
    public long? RSpad { get; set; }
    public long? LSpad { get; set; }
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
