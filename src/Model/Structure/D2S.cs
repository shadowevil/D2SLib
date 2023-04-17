using D2SLib.IO;
using CommunityToolkit.HighPerformance.Buffers;
using System.Diagnostics;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace D2SLib.Model.Structure;

public sealed class D2S : IDisposable
{
    public static D2S? Instance { get; private set; }

    public string SaveFilePath { get; private set; }

    public void SaveCharacter(bool backup = true)
    {
        if(backup) 
            if (File.Exists(SaveFilePath)) 
                File.Move(SaveFilePath, SaveFilePath + ".bak", true);

        File.WriteAllBytes(SaveFilePath, Core.WriteD2S(this));
    }

    public void SaveJsonCharacter(string path)
    {
        File.WriteAllText(path, JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings
                                                                                        {
                                                                                            NullValueHandling = NullValueHandling.Ignore,
                                                                                        }));
    }

    //public Dictionary<int, byte[]> missingBytes = new Dictionary<int, byte[]>();

    private D2S(IBitReader reader, string path)
    {
        Instance = this;
        SaveFilePath = path;
        Header = Header.Read(reader);
        ActiveWeapon = reader.ReadUInt32();
        if (Header.Version > 0x61) reader.Seek(267);
        Name = reader.ReadString(16);
        if (Header.Version > 0x61) reader.Seek(36);
        Status = Status.Read(reader.ReadByte());
        Progression = Progression.ReadProgressionByte(reader);
        active_arms = reader.ReadUInt16();
        ClassId = reader.ReadByte();
        reader.ReadBytes(2);
        Level = reader.ReadByte();
        Created = reader.ReadUInt32();
        LastPlayed = reader.ReadUInt32();
        reader.ReadBytes(4);
        AssignedSkills = Enumerable.Range(0, 16).Select(_ => Skill.Read(reader)).ToArray();
        LeftSkill = Skill.Read(reader);
        RightSkill = Skill.Read(reader);
        LeftSwapSkill = Skill.Read(reader);
        RightSwapSkill = Skill.Read(reader);
        Appearances = Appearances.Read(reader);
        Difficulty = Difficulties.Read(reader);
        MapId = reader.ReadUInt32();
        reader.ReadBytes(2);
        Mercenary = Mercenary.Read(reader);
        if (Header.Version > 0x61) reader.ReadBytes(144);
        else RealmData = reader.ReadBytes(140);
        Quests = QuestsSection.Read(reader);
        Waypoints = WaypointsSection.Read(reader);
        NPCDialog = NPCDialogSection.Read(reader);
        Attributes = Attributes.Read(reader);

        ClassSkills = ClassSkills.Read(reader, ClassId);
        PlayerItemList = ItemList.Read(reader, Header.Version);
        PlayerCorpses = CorpseList.Read(reader, Header.Version);

        if (Status.IsExpansion)
        {
            MercenaryItemList = MercenaryItemList.Read(reader, Mercenary, Header.Version);
            Golem = Golem.Read(reader, Header.Version);
        }
    }

    //0x0000
    public Header Header { get; set; }
    //0x0010
    private uint ActiveWeapon { get; set; }
    //0x0014 sizeof(16)
    public string Name { get; set; }
    public void ChangeName(string value)
    {
        SaveFilePath = Directory.GetParent(SaveFilePath) + "\\" + value + Path.GetExtension(SaveFilePath);
        Name = value;
    }

    //0x0024
    public Status Status { get; set; }
    //0x0025
    public Progression Progression { get; set; }
    //0x0026
    private ushort active_arms { get; set; }
    //0x0028
    public Core.Classes CharacterClass => (Core.Classes)ClassId;
    public byte ClassId { get; set; }
    //0x0029 [unk = 0x10, 0x1E]
    public byte Level { get; set; }
    //0x002c
    public uint Created { get; set; }
    //0x0030
    public uint LastPlayed { get; set; }
    //0x0038
    private Skill[] AssignedSkills { get; set; }
    //0x0078
    private Skill LeftSkill { get; set; }
    //0x007c
    private Skill RightSkill { get; set; }
    //0x0080
    private Skill LeftSwapSkill { get; set; }
    //0x0084
    private Skill RightSwapSkill { get; set; }
    //0x0088 [char menu appearance]
    private Appearances Appearances { get; set; }
    //0x00a8
    public Difficulties Difficulty { get; set; }
    //0x00ab
    public uint MapId { get; set; }
    //0x00b1
    public Mercenary Mercenary { get; set; }
    //0x00bf [unk = 0x0] (server related data)
    private byte[]? RealmData { get; set; }
    //0x014b
    public QuestsSection Quests { get; set; }
    //0x0279
    public WaypointsSection Waypoints { get; set; }
    //0x02c9
    private NPCDialogSection NPCDialog { get; set; }
    //0x2fc
    public Attributes Attributes { get; set; }
    public ClassSkills ClassSkills { get; set; }
    public ItemList PlayerItemList { get; set; }
    public CorpseList PlayerCorpses { get; set; }
    public MercenaryItemList? MercenaryItemList { get; set; }
    public Golem? Golem { get; set; }

    public void Write(IBitWriter writer)
    {
        Header.Write(writer);
        writer.WriteUInt32(ActiveWeapon);
        if (Header.Version < 0x61) writer.WriteString(Name, 16);
        else writer.WriteBytes(new byte[16]);
        Status.Write(writer);
        Progression.Write(writer);
        //Unk0x0026
        writer.WriteUInt16(active_arms);
        writer.WriteByte(ClassId);
        //Unk0x0029
        writer.WriteBytes(stackalloc byte[] { 0x10, 0x1e });
        writer.WriteByte(Level);
        writer.WriteUInt32(Created);
        writer.WriteUInt32(LastPlayed);
        //Unk0x0034
        writer.WriteBytes(stackalloc byte[] { 0xff, 0xff, 0xff, 0xff });
        for (int i = 0; i < 16; i++)
        {
            AssignedSkills[i].Write(writer);
        }
        LeftSkill.Write(writer);
        RightSkill.Write(writer);
        LeftSwapSkill.Write(writer);
        RightSwapSkill.Write(writer);
        Appearances.Write(writer);
        Difficulty.Write(writer);
        writer.WriteUInt32(MapId);
        //0x00af [unk = 0x0, 0x0]
        writer.WriteBytes(new byte[2]);
        Mercenary.Write(writer);
        if (Header.Version > 0x61)
        {
            writer.WriteBytes(new byte[76]);
            writer.WriteString(Name, 16);
            writer.WriteBytes(new byte[52]);
        }
        else
        {
            //0x00bf [unk = 0x0] (server related data)
            writer.WriteBytes(new byte[140]);
            writer.WriteUInt32(0x1);
        }
        Quests.Write(writer);
        Waypoints.Write(writer);
        NPCDialog.Write(writer);
        Attributes.Write(writer);
        ClassSkills.Write(writer);
        PlayerItemList.Write(writer, Header.Version);
        PlayerCorpses.Write(writer, Header.Version);
        if (Status.IsExpansion)
        {
            MercenaryItemList?.Write(writer, Mercenary, Header.Version);
            Golem?.Write(writer, Header.Version);
        }
    }

    public static D2S Read(ReadOnlySpan<byte> bytes, string path)
    {
        using var reader = new BitReader(bytes);
        var d2s = new D2S(reader, path);
        Debug.Assert(reader.Position == (bytes.Length * 8));
        return d2s;
    }

    public static MemoryOwner<byte> WritePooled(D2S d2s)
    {
        using var writer = new BitWriter();
        d2s.Write(writer);
        var bytes = writer.ToPooledArray();
        Header.Fix(bytes.Span);
        return bytes;
    }

    public static byte[] Write(D2S d2s)
    {
        using var writer = new BitWriter();
        d2s.Write(writer);
        byte[] bytes = writer.ToArray();
        Header.Fix(bytes);
        return bytes;
    }

    public void Dispose()
    {
        Waypoints.Dispose();
        Status.Dispose();
        Quests.Dispose();
        PlayerItemList.Dispose();
        PlayerCorpses.Dispose();
        MercenaryItemList?.Dispose();
    }
}
