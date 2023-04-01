using System;
using System.Collections.Generic;

namespace D2SLib.Model.Data;

public partial class Book
{
    public string? Name { get; set; }

    public string? ScrollSpellCode { get; set; }

    public string? BookSpellCode { get; set; }

    public long? PSpell { get; set; }

    public long? SpellIcon { get; set; }

    public string? ScrollSkill { get; set; }

    public string? BookSkill { get; set; }

    public long? BaseCost { get; set; }

    public long? CostPerCharge { get; set; }
}
