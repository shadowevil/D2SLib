using System;
using System.Collections.Generic;

namespace D2SLib.Model.Data;

public partial class Localization
{
    public long Id { get; set; }

    public string Key { get; set; } = null!;

    public string? EnUs { get; set; }

    public string? ZhTw { get; set; }

    public string? DeDe { get; set; }

    public string? EsEs { get; set; }

    public string? FrFr { get; set; }

    public string? ItIt { get; set; }

    public string? KoKr { get; set; }

    public string? PlPl { get; set; }

    public string? EsMx { get; set; }

    public string? JaJp { get; set; }

    public string? PtBr { get; set; }

    public string? RuRu { get; set; }

    public string? ZhCn { get; set; }
}
