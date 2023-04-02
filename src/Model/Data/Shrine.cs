using System;
using System.Collections.Generic;

namespace D2SLib.Model.Data;

public partial class Shrine
{
    public string? Name { get; set; }

    public string? ShrineType { get; set; }

    public string? Effect { get; set; }

    public long? Code { get; set; }

    public long? Arg0 { get; set; }

    public long? Arg1 { get; set; }

    public long? DurationInFrames { get; set; }

    public long? ResetTimeInMinutes { get; set; }

    public long? Rarity { get; set; }

    public string? StringName { get; set; }

    public string? StringPhrase { get; set; }

    public long? Effectclass { get; set; }

    public long? LevelMin { get; set; }
}
