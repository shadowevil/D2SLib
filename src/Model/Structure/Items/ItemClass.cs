using D2SLib.IO;
using D2SLib.Model.Data;
using System.Collections;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json.Serialization;
using Range = D2SLib.Model.Data.Range;

namespace D2SLib.Model.Structure;

public enum ItemLocation : byte
{
    Stored = 0x0,
    Equipped = 0x1,
    Belt = 0x2,
    Buffer = 0x4,
    Socket = 0x6,
}

public enum SlotLocation : byte
{
    None,
    Head,
    Neck,
    Torso,
    RightHand,
    LeftHand,
    RightFinger,
    LeftFinger,
    Waist,
    Feet,
    Gloves,
    SwapRight,
    SwapLeft
}

public enum ItemQuality : byte
{
    Inferior = 0x1,
    Normal,
    Superior,
    Magic,
    Set,
    Rare,
    Unique,
    Craft,
    Tempered
}

public class Item : IDisposable
{
    private InternalBitArray _flags = new(4);

    private ushort? Header { get; set; }

    public IList<bool> Flags
    {
        get => _flags;
        set
        {
            if (value is InternalBitArray flags)
            {
                _flags?.Dispose();
                _flags = flags;
            }
            else
            {
                throw new ArgumentException("Flags were not of expected type.");
            }
        }
    }

    private uint Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string ItemName {
        get
        {
            string rtnStr = "";
            if (isPersonalized) rtnStr = PersonalizedName + "\'s ";

            switch(Quality)
            {
                default:
                    rtnStr += Core.SqlContext.Localizations.Single(x => x.Key == this.Code.Trim()).EnUs ?? "";
                    break;
                case ItemQuality.Set:
                case ItemQuality.Unique:
                    return "";
            }

            return rtnStr;
        }
    }
    public ItemLocation itemLocation { get; set; }
    public SlotLocation itemSlot { get; set; }
    public Point gridPosition { get; set; }
    public Size gridSize { get => new Size((int)Core.SqlContext.GetByCode(this.Code)?.Invwidth!, (int)Core.SqlContext.GetByCode(this.Code)?.Invheight!); }
    private ItemQuality Quality { get; set; }
    public string itemQuality { get => Quality.ToString(); set => Quality = (ItemQuality)Convert.ToInt32(value); }
    public List<Item> SocketedItems { get; set; } = new();
    public List<ItemStatList> StatLists { get; } = new List<ItemStatList>();
    public byte ItemLevel { get; set; }
    public string ItemType
    {
        get
        {
            string type = Core.SqlContext.GetByCode(this.Code)?.Type!;
            return Core.SqlContext.Itemtypes.SingleOrDefault(x => x.Code == type)?.ItemType1 ?? "Not Found";
        }
    }
    public bool IsArmor { get => Core.SqlContext.GetByCode(this.Code) is Armor; }
    public bool IsWeapon { get => Core.SqlContext.GetByCode(this.Code) is Weapon; }
    public bool IsMisc { get => Core.SqlContext.GetByCode(this.Code) is Misc; }
    public bool IsStackable { get => Convert.ToBoolean(Core.SqlContext.GetByCode(this.Code)?.Stackable); }
    public string InvPath
    {
        get
        {
            switch (Quality)
            {
                default:
                    return Core.SqlContext.Itemfilepaths.Single(x => x.Key == this.Code.Trim())?.Filepath ?? "";
                case ItemQuality.Set:
                    return "";
                case ItemQuality.Unique:
                    return "";
            }
        }
    }
    public bool OneHanded { get => Convert.ToBoolean(((Core.SqlContext.GetByCode(this.Code) as Weapon)?._1or2handed)); }
    public bool TwoHanded { get => Convert.ToBoolean(((Core.SqlContext.GetByCode(this.Code) as Weapon)?._2handed)); }
    public Range _1HDamageRange
    {
        get
        {
            return new Range((int)((Core.SqlContext.GetByCode(this.Code) as Weapon)?.Mindam ?? 0),
                (int)((Core.SqlContext.GetByCode(this.Code) as Weapon)?.Maxdam ?? 0));
        }
    }
    public Range _2HDamageRange
    {
        get
        {
            return new Range((int)((Core.SqlContext.GetByCode(this.Code) as Weapon)?._2handmindam ?? 0),
                (int)((Core.SqlContext.GetByCode(this.Code) as Weapon)?._2handmaxdam ?? 0));
        }
    }
    public bool isIdentified { get => _flags[4]; set => _flags[4] = value; }
    public bool isSocketed { get => _flags[11]; set => _flags[11] = value; }
    public bool isNew { get => _flags[13]; set => _flags[13] = value; }
    public bool isEar { get => _flags[16]; set => _flags[16] = value; }
    public bool isStarterItem { get => _flags[17]; set => _flags[17] = value; }
    public bool isCompact { get => _flags[21]; set => _flags[21] = value; }
    public bool isEthereal { get => _flags[22]; set => _flags[22] = value; }
    public bool isPersonalized { get => _flags[24]; set => _flags[24] = value; }
    private string PersonalizedName { get; set; } = string.Empty; //used for personalized or ears
    public bool isRuneword { get => _flags[26]; set => _flags[26] = value; }
    public string[] Category
    {
        get
        {
            List<string> cats = new List<string>();
            string type = Core.SqlContext.GetByCode(this.Code)?.Type!;
            Itemtype? iType = Core.SqlContext.Itemtypes.Single(x => x.Code == type);
            while(iType != null)
            {
                cats.Add(iType.ItemType1 ?? "");
                if (iType.Equiv1 == null) break;
                iType = Core.SqlContext.Itemtypes.Single(x => x.Code == iType.Equiv1);
            }
            return cats.ToArray();
        }
    }
    public uint RunewordId { get; set; }
    public string? Runeword { get; set; }

    private string? Version { get; set; }
    public byte Page { get; set; }
    private byte EarLevel { get; set; }
    private byte NumberOfSocketedItems { get; set; }
    private byte TotalNumberOfSockets { get; set; }
    private bool HasMultipleGraphics { get; set; }
    private byte GraphicId { get; set; }
    private bool IsAutoAffix { get; set; }
    private ushort AutoAffixId { get; set; } //?
    private uint FileIndex { get; set; }
    public ushort[] MagicPrefixIds { get; set; } = new ushort[3];
    public ushort[] MagicSuffixIds { get; set; } = new ushort[3];
    public ushort RarePrefixId { get; set; }
    public ushort RareSuffixId { get; set; }
    public bool HasRealmData { get; set; }
    public uint[] RealmData { get; set; } = new uint[3];
    public ushort Armor { get; set; }
    public ushort MaxDurability { get; set; }
    public ushort Durability { get; set; }
    public ushort Quantity { get; set; }
    public byte SetItemMask { get; set; }

    public void Write(IBitWriter writer, uint version)
    {
        if (version <= 0x60)
        {
            writer.WriteUInt16(Header ?? 0x4D4A);
        }
        WriteCompact(writer, this, version);
        if (!isCompact)
        {
            WriteComplete(writer, this, version);
        }
        writer.Align();
        for (int i = 0; i < NumberOfSocketedItems; i++)
        {
            SocketedItems[i].Write(writer, version);
        }
    }

    public static Item Read(ReadOnlySpan<byte> bytes, uint version)
    {
        using var reader = new BitReader(bytes);
        return Read(reader, version);
    }

    public static Item Read(IBitReader reader, uint version)
    {
        var item = new Item();
        if (version <= 0x60)
        {
            item.Header = reader.ReadUInt16();
        }
        ReadCompact(reader, item, version);
        if (!item.isCompact)
        {
            ReadComplete(reader, item, version);
        }
        reader.Align();
        for (int i = 0; i < item.NumberOfSocketedItems; i++)
        {
            item.SocketedItems.Add(Read(reader, version));
        }
        return item;
    }

    public static byte[] Write(Item item, uint version)
    {
        using var writer = new BitWriter();
        item.Write(writer, version);
        return writer.ToArray();
    }


    private static string ReadPlayerName(IBitReader reader)
    {
        Span<char> name = stackalloc char[15];
        for (int i = 0; i < name.Length; i++)
        {
            if (D2S.Instance?.Header.Version > 0x61)
            {
                name[i] = (char)reader.ReadByte(8);
            }
            else
            {
                name[i] = (char)reader.ReadByte(7);
            }
            if (name[i].Equals((char)0x00))
            {
                break;
            }
        }
        return new string(name).Trim((char)0x00);
    }

    private static void WritePlayerName(IBitWriter writer, string name)
    {
        var nameChars = name.AsSpan().TrimEnd('\0');
        Span<byte> bytes = stackalloc byte[nameChars.Length];
        int byteCount = Encoding.ASCII.GetBytes(nameChars, bytes);
        bytes = bytes[..byteCount];
        for (int i = 0; i < bytes.Length; i++)
        {
            if(D2S.Instance?.Header.Version > 0x61) writer.WriteByte(bytes[i], 8);
            else writer.WriteByte(bytes[i], 7);
        }
        if (D2S.Instance?.Header.Version > 0x61) writer.WriteByte((byte)'\0', 8);
        else writer.WriteByte((byte)'\0', 7);
    }

    private static void ReadCompact(IBitReader reader, Item item, uint version)
    {
        Span<byte> bytes = stackalloc byte[4];
        reader.ReadBytes(bytes);
        item.Flags = new InternalBitArray(bytes);
        if (version <= 0x60)
        {
            item.Version = Convert.ToString(reader.ReadUInt16(10), 10);
        }
        else if (version >= 0x61)
        {
            item.Version = Convert.ToString(reader.ReadUInt16(3), 2);
        }
        item.itemLocation = (ItemLocation)reader.ReadByte(3);
        item.itemSlot = (SlotLocation)reader.ReadByte(4);
        item.gridPosition = new Point(reader.ReadByte(4), reader.ReadByte(4));
        item.Page = reader.ReadByte(3);
        if (item.isEar)
        {
            item.FileIndex = reader.ReadByte(3);
            item.EarLevel = reader.ReadByte(7);
            item.PersonalizedName = ReadPlayerName(reader);
        }
        else
        {
            item.Code = string.Empty;
            if (version <= 0x60)
            {
                item.Code = reader.ReadString(4);
            }
            else if (version >= 0x61)
            {
                for (int i = 0; i < 4; i++)
                {
                    item.Code += Core.SqlContext.ItemCodeTree.DecodeChar(reader);
                }
            }
            item.NumberOfSocketedItems = reader.ReadByte(item.isCompact ? 1 : 3);
        }
    }

    private static void WriteCompact(IBitWriter writer, Item item, uint version)
    {
        if (item.Flags is not InternalBitArray flags)
        {
            flags = new InternalBitArray(32)
            {
                [04] = item.isIdentified,
                [11] = item.isSocketed,
                [13] = item.isNew,
                [16] = item.isEar,
                [17] = item.isStarterItem,
                [21] = item.isCompact,
                [22] = item.isEthereal,
                [24] = item.isPersonalized,
                [26] = item.isRuneword
            };
        }
        writer.WriteBits(flags);
        if (version <= 0x60)
        {
            //todo. how do we handle 1.15 version to 1.14. maybe this should be a string
            writer.WriteUInt16(Convert.ToUInt16(item.Version, 10), 10);
        }
        else if (version >= 0x61)
        {
            writer.WriteUInt16(Convert.ToUInt16(item.Version, 2), 3);
        }
        writer.WriteByte((byte)item.itemLocation, 3);
        writer.WriteByte((byte)item.itemSlot, 4);
        writer.WriteByte((byte)item.gridPosition.X, 4);
        writer.WriteByte((byte)item.gridPosition.Y, 4);
        writer.WriteByte(item.Page, 3);
        if (item.isEar)
        {
            writer.WriteUInt32(item.FileIndex, 3);
            writer.WriteByte(item.EarLevel, 7);
            WritePlayerName(writer, item.PersonalizedName);
        }
        else
        {
            var itemCode = item.Code.PadRight(4, ' ');
            Span<byte> code = stackalloc byte[itemCode.Length];
            Encoding.ASCII.GetBytes(itemCode, code);
            if (version <= 0x60)
            {
                writer.WriteBytes(code);
            }
            else if (version >= 0x61)
            {
                var codeTree = Core.SqlContext.ItemCodeTree;
                for (int i = 0; i < 4; i++)
                {
                    using var bits = codeTree.EncodeChar((char)code[i]);
                    foreach (bool bit in bits)
                    {
                        writer.WriteBit(bit);
                    }
                }
            }
            writer.WriteByte(item.NumberOfSocketedItems, item.isCompact ? 1 : 3);
        }
    }

    private static void ReadComplete(IBitReader reader, Item item, uint version)
    {
        item.Id = reader.ReadUInt32();
        item.ItemLevel = reader.ReadByte(7);
        item.Quality = (ItemQuality)reader.ReadByte(4);
        item.HasMultipleGraphics = reader.ReadBit();
        if (item.HasMultipleGraphics)
        {
            item.GraphicId = reader.ReadByte(3);
        }
        item.IsAutoAffix = reader.ReadBit();
        if (item.IsAutoAffix)
        {
            item.AutoAffixId = reader.ReadUInt16(11);
        }
        switch (item.Quality)
        {
            case ItemQuality.Normal:
                break;
            case ItemQuality.Inferior:
            case ItemQuality.Superior:
                item.FileIndex = reader.ReadUInt16(3);
                break;
            case ItemQuality.Magic:
                item.MagicPrefixIds[0] = reader.ReadUInt16(11);
                item.MagicSuffixIds[0] = reader.ReadUInt16(11);
                break;
            case ItemQuality.Rare:
            case ItemQuality.Craft:
                item.RarePrefixId = reader.ReadUInt16(8);
                item.RareSuffixId = reader.ReadUInt16(8);
                for (int i = 0; i < 3; i++)
                {
                    if (reader.ReadBit())
                    {
                        item.MagicPrefixIds[i] = reader.ReadUInt16(11);
                    }
                    if (reader.ReadBit())
                    {
                        item.MagicSuffixIds[i] = reader.ReadUInt16(11);
                    }
                }
                break;
            case ItemQuality.Set:
            case ItemQuality.Unique:
                item.FileIndex = reader.ReadUInt16(12);
                break;
        }
        ushort propertyLists = 0;
        if (item.isRuneword)
        {
            item.RunewordId = reader.ReadUInt16(12);
            uint tmpRuneId = item.RunewordId;
            if (tmpRuneId < 75) tmpRuneId -= 26;
            else tmpRuneId -= 25;
            item.Runeword = Core.SqlContext.Runes.Single(x => x.Name!.Substring(8) == tmpRuneId.ToString())?.RuneName!;
            if (item.RunewordId == 2718) item.RunewordId = 48;
            propertyLists |= (ushort)(1 << (reader.ReadUInt16(4) + 1));
        }
        if (item.isPersonalized)
        {
            item.PersonalizedName = ReadPlayerName(reader);
        }
        var trimmedCode = item.Code.AsSpan().TrimEnd();
        if (trimmedCode.SequenceEqual("tbk") || trimmedCode.SequenceEqual("ibk"))
        {
            item.MagicSuffixIds[0] = reader.ReadByte(5);
        }
        item.HasRealmData = reader.ReadBit();
        if (item.HasRealmData)
        {
            //reader.ReadBits(96);
            reader.AdvanceBits(96);
        }
        if (item.IsArmor)
        {
            item.Armor = (ushort)(reader.ReadUInt16(11) + Convert.ToUInt32(Core.SqlContext.ItemStatCost_GetByStat("armorclass")?.SaveAdd ?? "0"));
        }
        if (item.IsArmor || item.IsWeapon)
        {
            var maxDurabilityStat = Core.SqlContext.ItemStatCost_GetByStat("maxdurability");
            var durabilityStat = Core.SqlContext.ItemStatCost_GetByStat("maxdurability");
            item.MaxDurability = (ushort)(reader.ReadUInt16(Convert.ToUInt16(maxDurabilityStat?.SaveBits ?? 0)) + Convert.ToUInt16(maxDurabilityStat?.SaveAdd ?? "0"));
            if (item.MaxDurability > 0)
            {
                item.Durability = (ushort)(reader.ReadUInt16(Convert.ToUInt16(durabilityStat?.SaveBits ?? 0)) + Convert.ToUInt16(durabilityStat?.SaveAdd ?? "0"));
                //what is this?
                reader.ReadBit();
            }
        }
        if (item.IsStackable)
        {
            item.Quantity = reader.ReadUInt16(9);
        }
        if (item.isSocketed)
        {
            item.TotalNumberOfSockets = reader.ReadByte(4);
        }
        item.SetItemMask = 0;
        if (item.Quality == ItemQuality.Set)
        {
            item.SetItemMask = reader.ReadByte(5);
            propertyLists |= item.SetItemMask;
        }
        item.StatLists.Add(ItemStatList.Read(reader));
        for (int i = 1; i <= 64; i <<= 1)
        {
            if ((propertyLists & i) != 0)
            {
                item.StatLists.Add(ItemStatList.Read(reader));
            }
        }
    }

    private static void WriteComplete(IBitWriter writer, Item item, uint version)
    {
        writer.WriteUInt32(item.Id);
        writer.WriteByte(item.ItemLevel, 7);
        writer.WriteByte((byte)item.Quality, 4);
        writer.WriteBit(item.HasMultipleGraphics);
        if (item.HasMultipleGraphics)
        {
            writer.WriteByte(item.GraphicId, 3);
        }
        writer.WriteBit(item.IsAutoAffix);
        if (item.IsAutoAffix)
        {
            writer.WriteUInt16(item.AutoAffixId, 11);
        }
        switch (item.Quality)
        {
            case ItemQuality.Normal:
                break;
            case ItemQuality.Inferior:
            case ItemQuality.Superior:
                writer.WriteUInt32(item.FileIndex, 3);
                break;
            case ItemQuality.Magic:
                writer.WriteUInt16(item.MagicPrefixIds[0], 11);
                writer.WriteUInt16(item.MagicSuffixIds[0], 11);
                break;
            case ItemQuality.Rare:
            case ItemQuality.Craft:
                writer.WriteUInt16(item.RarePrefixId, 8);
                writer.WriteUInt16(item.RareSuffixId, 8);
                for (int i = 0; i < 3; i++)
                {
                    bool hasPrefix = item.MagicPrefixIds[i] > 0;
                    bool hasSuffix = item.MagicSuffixIds[i] > 0;
                    writer.WriteBit(hasPrefix);
                    if (hasPrefix)
                    {
                        writer.WriteUInt16(item.MagicPrefixIds[i], 11);
                    }
                    writer.WriteBit(hasSuffix);
                    if (hasSuffix)
                    {
                        writer.WriteUInt16(item.MagicSuffixIds[i], 11);
                    }
                }
                break;
            case ItemQuality.Set:
            case ItemQuality.Unique:
                writer.WriteUInt32(item.FileIndex, 12);
                break;
        }
        ushort propertyLists = 0;
        if (item.isRuneword)
        {
            writer.WriteUInt32(item.RunewordId, 12);
            propertyLists |= 1 << 6;
            writer.WriteUInt16(5, 4);
        }
        if (item.isPersonalized)
        {
            WritePlayerName(writer, item.PersonalizedName);
        }
        var trimmedCode = item.Code.AsSpan().Trim();
        if (trimmedCode.SequenceEqual("tbk") || trimmedCode.SequenceEqual("ibk"))
        {
            writer.WriteUInt16(item.MagicSuffixIds[0], 5);
        }
        writer.WriteBit(item.HasRealmData);
        if (item.HasRealmData)
        {
            //todo 96 bits
        }
        if (item.IsArmor)
        {
            writer.WriteUInt16((ushort)(item.Armor - Convert.ToUInt32(Core.SqlContext.ItemStatCost_GetByStat("armorclass")?.SaveAdd ?? "0")), 11);
        }
        if (item.IsArmor || item.IsWeapon)
        {
            var maxDurabilityStat = Core.SqlContext.ItemStatCost_GetByStat("maxdurability");
            var durabilityStat = Core.SqlContext.ItemStatCost_GetByStat("maxdurability");
            writer.WriteUInt16((ushort)(item.MaxDurability - Convert.ToUInt32(maxDurabilityStat?.SaveAdd ?? "0")), Convert.ToInt32(maxDurabilityStat?.SaveBits ?? 0));
            if (item.MaxDurability > 0)
            {
                writer.WriteUInt16((ushort)(item.MaxDurability - Convert.ToUInt32(durabilityStat?.SaveAdd ?? "0")), Convert.ToInt32(durabilityStat?.SaveBits ?? 0));
                ////what is this?
                writer.WriteBit(false);
            }
        }
        if (item.IsStackable)
        {
            writer.WriteUInt16(item.Quantity, 9);
        }
        if (item.isSocketed)
        {
            writer.WriteByte(item.TotalNumberOfSockets, 4);
        }
        if (item.Quality == ItemQuality.Set)
        {
            writer.WriteByte(item.SetItemMask, 5);
            propertyLists |= item.SetItemMask;
        }
        ItemStatList.Write(writer, item.StatLists[0]);
        int idx = 1;
        for (int i = 1; i <= 64; i <<= 1)
        {
            if ((propertyLists & i) != 0)
            {
                ItemStatList.Write(writer, item.StatLists[idx++]);
            }
        }
    }

    public void Dispose()
    {
        Interlocked.Exchange(ref _flags!, null)?.Dispose();
        foreach (var item in SocketedItems)
        {
            item?.Dispose();
        }
        SocketedItems.Clear();
    }
}
