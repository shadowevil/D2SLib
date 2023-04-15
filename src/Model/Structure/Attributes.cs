using D2SLib.IO;

namespace D2SLib.Model.Structure;

//variable size. depends on # of attributes
public class Attributes
{
    private ushort? Header { get; set; }
    private Dictionary<string, int> Stats { get; } = new Dictionary<string, int>();

    public ulong Strength
    {
        get => (ushort)Stats.Single(x => x.Key == "strength").Value;
        set {
            if (value >= 1023) value = 1023;
            if (value < 0) value = 0;
            if (!Stats.ContainsKey("strength")) Stats.Add("strength", 0);
            Stats["strength"] = (int)value;
        }
    }

    public ulong Energy
    {
        get => (ushort)Stats.Single(x => x.Key == "energy").Value;
        set
        {
            if (value >= 1023) value = 1023;
            if (value < 0) value = 0;
            if (!Stats.ContainsKey("energy")) Stats.Add("energy", 0);
            Stats["energy"] = (int)value;
        }
    }

    public ulong Dexterity
    {
        get => (ushort)Stats.Single(x => x.Key == "dexterity").Value;
        set
        {
            if (value >= 1023) value = 1023;
            if (value < 0) value = 0;
            if (!Stats.ContainsKey("dexterity")) Stats.Add("dexterity", 0);
            Stats["dexterity"] = (int)value;
        }
    }

    public ulong Vitality
    {
        get => (ushort)Stats.Single(x => x.Key == "vitality").Value;
        set
        {
            if (value >= 1023) value = 1023;
            if (value < 0) value = 0;
            if (!Stats.ContainsKey("vitality")) Stats.Add("vitality", 0);
            Stats["vitality"] = (int)value;
        }
    }

    public int MaxHP => Stats["maxhp"];
    public ulong HP
    {
        get => (ushort)Stats.Single(x => x.Key == "maxhp").Value;
        set
        {
            if (value >= 8191) value = 8191;
            if (value < ushort.MinValue) value = ushort.MinValue;
            if (!Stats.ContainsKey("hitpoints")) Stats.Add("hitpoints", 0);
            if (!Stats.ContainsKey("maxhp")) Stats.Add("maxhp", 0);
            Stats["maxhp"] = (int)value;
            Stats["hitpoints"] = (int)value;
        }
    }

    public int MaxMana => Stats["maxmana"];
    public ulong Mana
    {
        get => (ushort)Stats.Single(x => x.Key == "maxmana").Value;
        set
        {
            if (value >= 8191) value = 8191;
            if (value < ushort.MinValue) value = ushort.MinValue;
            if (!Stats.ContainsKey("mana")) Stats.Add("mana", 0);
            if (!Stats.ContainsKey("maxmana")) Stats.Add("maxmana", 0);
            Stats["maxmana"] = (int)value;
            Stats["mana"] = (int)value;
        }
    }

    public int MaxStamina => Stats["maxstamina"];
    public ulong Stamina
    {
        get => (ushort)Stats.Single(x => x.Key == "stamina").Value;
        set
        {
            if (value >= 8191) value = 8191;
            if (value < ushort.MinValue) value = ushort.MinValue;
            if (!Stats.ContainsKey("stamina")) Stats.Add("stamina", 0);
            if (!Stats.ContainsKey("maxstamina")) Stats.Add("maxstamina", 0);
            Stats["maxstamina"] = (int)value;
            Stats["stamina"] = (int)value;
        }
    }

    public uint Experience
    {
        get
        {
            if (Stats.ContainsKey("experience"))
            {
                return (uint)Stats["experience"];
            }
            else
            {
                return 0;
            }
        }
    }

    public long Level
    {
        get => (ushort)Stats.Single(x => x.Key == "level").Value;
        set
        {
            if (value >= 99) value = 99;
            if (value <= 1) value = 1;
            if (!Stats.ContainsKey("level")) Stats.Add("level", 1);
            if (!Stats.ContainsKey("experience")) Stats.Add("experience", 0);
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

    public ulong Gold
    {
        get => (ulong)Stats.FirstOrDefault(x => x.Key == "gold").Value;
        set
        {
            int maxgold = (int)Level * 10000;
            if (value >= (ulong)maxgold) value = (ulong)maxgold;
            if (value < 0) value = 0;
            if (!Stats.ContainsKey("gold")) Stats.Add("gold", 0);
            Stats["gold"] = (int)value;
        }
    }

    public ulong StashGold
    {
        get => (ulong)Stats.FirstOrDefault(x => x.Key == "goldbank").Value;
        set
        {
            if (value >= 2500000) value = 2500000;
            if (value < 0) value = 0;
            if (!Stats.ContainsKey("goldbank")) Stats.Add("goldbank", 0);
            Stats["goldbank"] = (int)value;
        }
    }

    public ulong StatPoints
    {
        get => (ulong)Stats.FirstOrDefault(x => x.Key == "statpts").Value;
        set
        {
            if (value >= 1023) value = 1023;
            if (value < 0) value = 0;
            if (!Stats.ContainsKey("statpts")) Stats.Add("statpts", 0);
            Stats["statpts"] = (int)value;
        }
    }
    public ulong SkillPoints
    {
        get => (ulong)Stats.FirstOrDefault(x => x.Key == "newskills").Value;
        set
        {
            if (value >= 255) value = 255;
            if (value < 0) value = 0;
            if (!Stats.ContainsKey("newskills")) Stats.Add("newskills", 0);
            Stats["newskills"] = (int)value;
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
            int attribute = reader.ReadInt32(Convert.ToInt32(property?.CsvBits ?? 0));
            int valShift = Convert.ToInt32(Convert.ToInt32(property?.ValShift ?? 0));
            if (valShift > 0)
            {
                attribute >>= valShift;
            }
            attributes.Stats.Add(property?.Stat ?? string.Empty, attribute);
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
            writer.WriteUInt16((ushort)(property?.Id ?? 0), 9);
            int attribute = entry.Value;
            int valShift = Convert.ToInt32(property?.ValShift ?? 0);
            if (valShift > 0)
            {
                attribute <<= valShift;
            }
            writer.WriteInt32(attribute, Convert.ToInt32(property?.CsvBits ?? 0));
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
