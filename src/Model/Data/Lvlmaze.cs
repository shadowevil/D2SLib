using System;
using System.Collections.Generic;

namespace D2SLib.Model.Data;

public partial class Lvlmaze
{
    public string? Name { get; set; }

    public long? Level { get; set; }

    public long? Rooms { get; set; }

    public long? RoomsN { get; set; }

    public long? RoomsH { get; set; }

    public long? SizeX { get; set; }

    public long? SizeY { get; set; }

    public long? Merge { get; set; }
}
