using D2SLib.IO;
using D2SLib.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2SLib.Model.Structure;

public class ItemStatList
{
    private const ushort magicmindam = 52;
    private const ushort item_maxdamage_percent = 17;
    private const ushort firemindam = 48;
    private const ushort lightmindam = 50;
    private const ushort coldmindam = 54;
    private const ushort poisonmindam = 57;

    public List<ItemStat> Stats { get; set; } = new();

    public static ItemStatList Read(IBitReader reader)
    {
        var itemStatList = new ItemStatList();
        ushort id = reader.ReadUInt16(9);
        while (id != 0x1ff)
        {
            itemStatList.Stats.Add(ItemStat.Read(reader, id));
            //https://github.com/ThePhrozenKeep/D2MOO/blob/master/source/D2Common/src/Items/Items.cpp#L7332
            if (id is magicmindam or item_maxdamage_percent or firemindam or lightmindam)
            {
                itemStatList.Stats.Add(ItemStat.Read(reader, (ushort)(id + 1)));
            }
            else if (id is coldmindam or poisonmindam)
            {
                itemStatList.Stats.Add(ItemStat.Read(reader, (ushort)(id + 1)));
                itemStatList.Stats.Add(ItemStat.Read(reader, (ushort)(id + 2)));
            }
            id = reader.ReadUInt16(9);
        }
        return itemStatList;
    }

    public static void Write(IBitWriter writer, ItemStatList itemStatList)
    {
        for (int i = 0; i < itemStatList.Stats.Count; i++)
        {
            var stat = itemStatList.Stats[i];
            var property = ItemStat.GetStatRow(stat);
            ushort id = Convert.ToUInt16(property?.Id ?? 0);
            writer.WriteUInt16(id, 9);
            ItemStat.Write(writer, stat);

            //assume these stats are in order...
            //https://github.com/ThePhrozenKeep/D2MOO/blob/master/source/D2Common/src/Items/Items.cpp#L7332
            if (id is magicmindam or item_maxdamage_percent or firemindam or lightmindam)
            {
                ItemStat.Write(writer, itemStatList.Stats[++i]);
            }
            else if (id is coldmindam or poisonmindam)
            {
                ItemStat.Write(writer, itemStatList.Stats[++i]);
                ItemStat.Write(writer, itemStatList.Stats[++i]);
            }
        }
        writer.WriteUInt16(0x1ff, 9);
    }
}
