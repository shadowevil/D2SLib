using D2SLib.IO;

namespace D2SLib.Model.Save;

//variable size. depends on # of attributes
public class Attributes
{
    public ushort? Header { get; set; }
    public Dictionary<string, int> Stats { get; } = new Dictionary<string, int>();

    public static Attributes Read(IBitReader reader)
    {
        var attributes = new Attributes
        {
            Header = reader.ReadUInt16()
        };
        ushort id = reader.ReadUInt16(9);
        while (id != 0x1ff)
        {
            var property = Core.SqlContext.GetById(id);
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
            var property = Core.SqlContext.GetByStat(entry.Key);
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
