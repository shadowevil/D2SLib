using System;
using System.Collections.Generic;

namespace D2SLib.Model.Data;

public partial class Lvlwarp
{
    public string? Name { get; set; }

    public long? Id { get; set; }

    public long? SelectX { get; set; }

    public long? SelectY { get; set; }

    public long? SelectDx { get; set; }

    public long? SelectDy { get; set; }

    public long? ExitWalkX { get; set; }

    public long? ExitWalkY { get; set; }

    public long? OffsetX { get; set; }

    public long? OffsetY { get; set; }

    public long? LitVersion { get; set; }

    public long? Tiles { get; set; }

    public string? NoInteract { get; set; }

    public string? Direction { get; set; }

    public long? UniqueId { get; set; }
}
