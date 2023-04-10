using D2SLib.IO;

namespace D2SLib.Model.Structure;

public sealed class ItemList : IDisposable
{
    private ItemList(ushort header, ushort count)
    {
        Header = header;
        NumberOfItems = count;
        Items = new List<Item>(count);
    }

    private ushort? Header { get; set; }
    private ushort NumberOfItems { get; set; }
    public List<Item> Items { get; }

    public void Write(IBitWriter writer, uint version)
    {
        writer.WriteUInt16(Header ?? 0x4D4A);
        writer.WriteUInt16(NumberOfItems);
        for (int i = 0; i < NumberOfItems; i++)
        {
            Items[i].Write(writer, version);
        }
    }

    public static ItemList Read(IBitReader reader, uint version)
    {
        var itemList = new ItemList(
            header: reader.ReadUInt16(),
            count: reader.ReadUInt16()
        );
        for (int i = 0; i < itemList.NumberOfItems; i++)
        {
            itemList.Items.Add(Item.Read(reader, version));
        }
        return itemList;
    }

    [Obsolete("Try the non-allocating overload!")]
    public static byte[] Write(ItemList itemList, uint version)
    {
        using var writer = new BitWriter();
        itemList.Write(writer, version);
        return writer.ToArray();
    }

    public void Dispose()
    {
        foreach (var item in Items)
        {
            item?.Dispose();
        }
        Items.Clear();
    }
}
