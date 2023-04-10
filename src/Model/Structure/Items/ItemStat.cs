using D2SLib.IO;
using D2SLib.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2SLib.Model.Structure;

public class ItemStat
{
    public ushort? Id { get; set; }
    public string Stat { get; set; } = string.Empty;
    public int? SkillTab { get; set; }
    public int? SkillId { get; set; }
    public int? SkillLevel { get; set; }
    public int? MaxCharges { get; set; }
    public int? Param { get; set; }
    public int Value { get; set; }

    public static ItemStat Read(IBitReader reader, ushort id)
    {
        var itemStat = new ItemStat();
        var property = Core.SqlContext.ItemStatCost_GetById(id);
        if (property == null)
        {
            throw new Exception($"No ItemStatCost record found for id: {id} at bit {reader.Position - 9}");
        }
        itemStat.Id = id;
        itemStat.Stat = property.Stat ?? "";
        int saveParamBitCount = Convert.ToInt32(property.SaveParamBits);
        int encode = Convert.ToInt32(property.Encode);
        if (saveParamBitCount != 0)
        {
            int saveParam = reader.ReadInt32(saveParamBitCount);
            //todo is there a better way to identify skill tab stats.
            switch (property.Descfunc)
            {
                case 14: //+[value] to [skilltab] Skill Levels ([class] Only) : stat id 188
                    itemStat.SkillTab = saveParam & 0x7;
                    itemStat.SkillLevel = (saveParam >> 3) & 0x1fff;
                    break;
                default:
                    break;
            }
            switch (encode)
            {
                case 2: //chance to cast skill
                case 3: //skill charges
                    itemStat.SkillLevel = saveParam & 0x3f;
                    itemStat.SkillId = (saveParam >> 6) & 0x3ff;
                    break;
                case 1:
                case 4: //by times
                default:
                    itemStat.Param = saveParam;
                    break;
            }
        }
        int saveBits = reader.ReadInt32((int)(property.SaveBits ?? 0));
        saveBits -= Convert.ToInt32(property.SaveAdd);
        switch (encode)
        {
            case 3: //skill charges
                itemStat.MaxCharges = (saveBits >> 8) & 0xff;
                itemStat.Value = saveBits & 0xff;
                break;
            default:
                itemStat.Value = saveBits;
                break;
        }
        return itemStat;
    }

    public static void Write(IBitWriter writer, ItemStat stat)
    {
        var property = GetStatRow(stat);
        if (property is null)
        {
            throw new ArgumentException($"No ItemStatCost record found for id: {stat.Id}", nameof(stat));
        }
        int saveParamBitCount = Convert.ToInt32(property.SaveParamBits);
        int encode = Convert.ToInt32(property.SaveParamBits ?? 0);
        if (saveParamBitCount != 0)
        {
            if (stat.Param != null)
            {
                writer.WriteInt32((int)stat.Param, saveParamBitCount);
            }
            else
            {
                int saveParamBits = 0;
                switch (property.Descfunc)
                {
                    case 14: //+[value] to [skilltab] Skill Levels ([class] Only) : stat id 188
                        saveParamBits |= (stat.SkillTab ?? 0 & 0x7);
                        saveParamBits |= ((stat.SkillLevel ?? 0 & 0x1fff) << 3);
                        break;
                    default:
                        break;
                }
                switch (encode)
                {
                    case 2: //chance to cast skill
                    case 3: //skill charges
                        saveParamBits |= (stat.SkillLevel ?? 0 & 0x3f);
                        saveParamBits |= ((stat.SkillId ?? 0 & 0x3ff) << 6);
                        break;
                    case 4: //by times
                    case 1:
                    default:
                        break;
                }
                //always use param if it is there.
                if (stat.Param != null)
                {
                    saveParamBits = (int)stat.Param;
                }
                writer.WriteInt32(saveParamBits, saveParamBitCount);
            }
        }
        int saveBits = stat.Value;
        saveBits += Convert.ToInt32(property.SaveAdd);
        switch (encode)
        {
            case 3: //skill charges
                saveBits &= 0xff;
                saveBits |= ((stat.MaxCharges ?? 0 & 0xff) << 8);
                break;
            default:
                break;
        }
        writer.WriteInt32(saveBits, (int)(property.SaveBits ?? 0));
    }

    public static Itemstatcost? GetStatRow(ItemStat stat)
    {
        return stat.Id is ushort statId
            ? Core.SqlContext.ItemStatCost_GetById(statId)
            : Core.SqlContext.ItemStatCost_GetByStat(stat.Stat);
    }
}