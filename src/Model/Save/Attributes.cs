using D2SLib.IO;

namespace D2SLib.Model.Save;

//variable size. depends on # of attributes
public class Attributes
{
    private ushort? Header { get; set; }
    private Dictionary<string, int> Stats { get; } = new Dictionary<string, int>();

    public ushort Strength
    {
        get => (ushort)Stats.Single(x => x.Key == "strength").Value;
        set {
            if (value >= 1024) value = 1024;
            if (value < 0) value = 0;
            Stats["strength"] = (int)value;
        }
    }

    public ushort Energy
    {
        get => (ushort)Stats.Single(x => x.Key == "energy").Value;
        set
        {
            if (value >= 1024) value = 1024;
            if (value < 0) value = 0;
            Stats["energy"] = (int)value;
        }
    }

    public ushort Dexterity
    {
        get => (ushort)Stats.Single(x => x.Key == "dexterity").Value;
        set
        {
            if (value >= 1024) value = 1024;
            if (value < 0) value = 0;
            Stats["dexterity"] = (int)value;
        }
    }

    public ushort Vitality
    {
        get => (ushort)Stats.Single(x => x.Key == "vitality").Value;
        set
        {
            if (value >= 1024) value = 1024;
            if (value < 0) value = 0;
            Stats["vitality"] = (int)value;
        }
    }

    public ushort HP
    {
        get => (ushort)Stats.Single(x => x.Key == "maxhp").Value;
        set
        {
            if (value >= 1024) value = 1024;
            if (value < 0) value = 0;
            Stats["maxhp"] = (int)value;
            Stats["hitpoints"] = (int)value;
        }
    }

    public ushort Mana
    {
        get => (ushort)Stats.Single(x => x.Key == "maxmana").Value;
        set
        {
            if (value >= 1024) value = 1024;
            if (value < 0) value = 0;
            Stats["maxmana"] = (int)value;
            Stats["mana"] = (int)value;
        }
    }

    public ushort Stamina
    {
        get => (ushort)Stats.Single(x => x.Key == "stamina").Value;
        set
        {
            if (value >= 1024) value = 1024;
            if (value < 0) value = 0;
            Stats["maxstamina"] = (int)value;
            Stats["stamina"] = (int)value;
        }
    }

    public ushort Level
    {
        get => (ushort)Stats.Single(x => x.Key == "level").Value;
        set
        {
            if (value >= 99) value = 99;
            if (value <= 1) value = 1;
            Stats["level"] = (int)value;
            D2S.Instance!.Level = (byte)value;
            switch (D2S.Instance?.ClassId)
            {
                case 0x00:
                    Stats["experience"] = (int)Core.SqlContext.Experiences.Single(x => x.Level == value).Amazon!;
                    break;
                case 0x01:
                    Stats["experience"] = (int)Core.SqlContext.Experiences.Single(x => x.Level == value).Sorceress!;
                    break;
                case 0x02:
                    Stats["experience"] = (int)Core.SqlContext.Experiences.Single(x => x.Level == value).Necromancer!;
                    break;
                case 0x03:
                    Stats["experience"] = (int)Core.SqlContext.Experiences.Single(x => x.Level == value).Paladin!;
                    break;
                case 0x04:
                    Stats["experience"] = (int)Core.SqlContext.Experiences.Single(x => x.Level == value).Barbarian!;
                    break;
                case 0x05:
                    Stats["experience"] = (int)Core.SqlContext.Experiences.Single(x => x.Level == value).Druid!;
                    break;
                case 0x06:
                    Stats["experience"] = (int)Core.SqlContext.Experiences.Single(x => x.Level == value).Assassin!;
                    break;
            }
        }
    }

    public int Gold
    {
        get => Stats.FirstOrDefault(x => x.Key == "gold").Value;
        set
        {
            int maxgold = Level * 10000;
            if (value >= maxgold) value = maxgold;
            if (value < 0) value = 0;
            if (!Stats.ContainsKey("gold")) Stats.Add("gold", 0);
            Stats["gold"] = value;
        }
    }

    public int StashGold
    {
        get => Stats.FirstOrDefault(x => x.Key == "goldbank").Value;
        set
        {
            if (value >= 2500000) value = 2500000;
            if (value < 0) value = 0;
            if (!Stats.ContainsKey("goldbank")) Stats.Add("goldbank", 0);
            Stats["goldbank"] = value;
        }
    }

    public static Attributes Read(IBitReader reader)
    {
        var attributes = new Attributes
        {
            Header = reader.ReadUInt16()
        };
        ushort id = reader.ReadUInt16(9);
        while (id != 0x1ff)
        {
            var property = Core.SqlContext.ItemStatCost_GetById(id);
            int attribute = reader.ReadInt32(Convert.ToInt32(property.CsvBits ?? 0));
            int valShift = Convert.ToInt32(Convert.ToInt32(property.ValShift ?? 0));
            if (valShift > 0)
            {
                attribute >>= valShift;
            }
            attributes.Stats.Add(property.Stat ?? string.Empty, attribute);
            id = reader.ReadUInt16(9);
        }
        reader.Align();
        return attributes;
    }

    public void Write(IBitWriter writer)
    {
        writer.WriteUInt16(Header ?? 0x6667);
        foreach (var entry in Stats)
        {
            var property = Core.SqlContext.ItemStatCost_GetByStat(entry.Key);
            writer.WriteUInt16((ushort)(property.Id ?? 0), 9);
            int attribute = entry.Value;
            int valShift = Convert.ToInt32(property.ValShift ?? 0);
            if (valShift > 0)
            {
                attribute <<= valShift;
            }
            writer.WriteInt32(attribute, Convert.ToInt32(property.CsvBits ?? 0));
        }
        writer.WriteUInt16(0x1ff, 9);
        writer.Align();
    }

    [Obsolete("Try the non-allocating overload!")]
    public static byte[] Write(Attributes attributes)
    {
        using var writer = new BitWriter();
        attributes.Write(writer);
        return writer.ToArray();
    }
}
