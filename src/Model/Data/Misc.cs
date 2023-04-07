using D2SLib.Model.Save;
using System;
using System.Collections.Generic;

namespace D2SLib.Model.Data;

public partial class Misc : DBItem
{
    public string? Autobelt { get; set; }
    public long? Spellicon { get; set; }
    public long? PSpell { get; set; }
    public string? State { get; set; }
    public string? Cstate1 { get; set; }
    public string? Cstate2 { get; set; }
    public long? Len { get; set; }
    public string? Stat1 { get; set; }
    public long? Calc1 { get; set; }
    public string? Stat2 { get; set; }
    public long? Calc2 { get; set; }
    public long? Stat3 { get; set; }
    public long? Calc3 { get; set; }
    public long? Spelldesc { get; set; }
    public string? Spelldescstr { get; set; }
    public string? Spelldescstr2 { get; set; }
    public long? Spelldesccalc { get; set; }
    public long? Spelldesccolor { get; set; }
    public string? BetterGem { get; set; }
    public long? Multibuy { get; set; }
}
