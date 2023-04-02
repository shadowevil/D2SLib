using System;
using System.Collections.Generic;
using D2SLib.Model.Huffman;
using Microsoft.EntityFrameworkCore;

namespace D2SLib.Model.Data;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    private HuffmanTree? _itemCodeTree = null;
    internal HuffmanTree ItemCodeTree
    {
        get => _itemCodeTree ??= InitializeHuffmanTree();
        set => _itemCodeTree = value;
    }

    private HuffmanTree InitializeHuffmanTree()
    {
        var itemCodeTree = new HuffmanTree();
        itemCodeTree.Build();
        return itemCodeTree;
    }

    public T? GetByCode<T>(string code)
    {
        if (default(T) is Armor)
        {
            return (T?)(object?)Armors.FirstOrDefault(x => x.Code == code.Trim());
        }
        else if (default(T) is Weapon)
        {
            return (T?)(object?)Weapons.FirstOrDefault(x => x.Code == code.Trim());
        }
        else if (default(T) is Misc)
        {
            return (T?)(object?)Miscs.FirstOrDefault(x => x.Code == code.Trim());
        }
        return default(T);
    }

    public bool IsArmor(string code) => Armors.Where(x => x.Code == code.Trim()).FirstOrDefault() is not null;
    public bool IsWeapon(string code) => Weapons.Where(x => x.Code == code.Trim()).FirstOrDefault() is not null;
    public bool IsMisc(string code) => Miscs.Where(x => x.Code == code.Trim()).FirstOrDefault() is not null;

    public Itemstatcost GetByStat(string stat)
    {
        return Itemstatcosts.First(x => x.Stat == stat);
    }

    public Itemstatcost GetById(ushort id)
    {
        return Itemstatcosts.First(x => x.Id == id);
    }







    public virtual DbSet<Actinfo> Actinfos { get; set; }

    public virtual DbSet<Armor> Armors { get; set; }

    public virtual DbSet<Armtype> Armtypes { get; set; }

    public virtual DbSet<Automagic> Automagics { get; set; }

    public virtual DbSet<Belt> Belts { get; set; }

    public virtual DbSet<Bodyloc> Bodylocs { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Charstat> Charstats { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Compcode> Compcodes { get; set; }

    public virtual DbSet<Composit> Composits { get; set; }

    public virtual DbSet<Cubemain> Cubemains { get; set; }

    public virtual DbSet<Cubemod> Cubemods { get; set; }

    public virtual DbSet<Difficultylevel> Difficultylevels { get; set; }

    public virtual DbSet<Elemtype> Elemtypes { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Gamble> Gambles { get; set; }

    public virtual DbSet<Gem> Gems { get; set; }

    public virtual DbSet<Hireling> Hirelings { get; set; }

    public virtual DbSet<Hirelingdesc> Hirelingdescs { get; set; }

    public virtual DbSet<Hitclass> Hitclasses { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Itemratio> Itemratios { get; set; }

    public virtual DbSet<Itemstatcost> Itemstatcosts { get; set; }

    public virtual DbSet<Itemtype> Itemtypes { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<Levelgroup> Levelgroups { get; set; }

    public virtual DbSet<Localization> Localizations { get; set; }

    public virtual DbSet<Lowqualityitem> Lowqualityitems { get; set; }

    public virtual DbSet<Lvlmaze> Lvlmazes { get; set; }

    public virtual DbSet<Lvlprest> Lvlprests { get; set; }

    public virtual DbSet<Lvlsub> Lvlsubs { get; set; }

    public virtual DbSet<Lvltype> Lvltypes { get; set; }

    public virtual DbSet<Lvlwarp> Lvlwarps { get; set; }

    public virtual DbSet<Magicprefix> Magicprefixes { get; set; }

    public virtual DbSet<Magicsuffix> Magicsuffixes { get; set; }

    public virtual DbSet<Misc> Miscs { get; set; }

    public virtual DbSet<Misscalc> Misscalcs { get; set; }

    public virtual DbSet<Missile> Missiles { get; set; }

    public virtual DbSet<Npc> Npcs { get; set; }

    public virtual DbSet<Overlay> Overlays { get; set; }

    public virtual DbSet<Pettype> Pettypes { get; set; }

    public virtual DbSet<Playerclass> Playerclasses { get; set; }

    public virtual DbSet<Plrmode> Plrmodes { get; set; }

    public virtual DbSet<Plrtype> Plrtypes { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<Qualityitem> Qualityitems { get; set; }

    public virtual DbSet<Rareprefix> Rareprefixes { get; set; }

    public virtual DbSet<Raresuffix> Raresuffixes { get; set; }

    public virtual DbSet<Rune> Runes { get; set; }

    public virtual DbSet<Set> Sets { get; set; }

    public virtual DbSet<Setitem> Setitems { get; set; }

    public virtual DbSet<Shrine> Shrines { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Skillcalc> Skillcalcs { get; set; }

    public virtual DbSet<Skilldesc> Skilldescs { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Storepage> Storepages { get; set; }

    public virtual DbSet<Superunique> Superuniques { get; set; }

    public virtual DbSet<Treasureclassex> Treasureclassexes { get; set; }

    public virtual DbSet<Uniqueappellation> Uniqueappellations { get; set; }

    public virtual DbSet<Uniqueitem> Uniqueitems { get; set; }

    public virtual DbSet<Uniqueprefix> Uniqueprefixes { get; set; }

    public virtual DbSet<Uniquesuffix> Uniquesuffixes { get; set; }

    public virtual DbSet<Weapon> Weapons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\ShadowEvil\\Desktop\\D2R Source\\Database\\database.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actinfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("actinfo");

            entity.Property(e => e.Act).HasColumnName("act");
            entity.Property(e => e.Classlevelrangeend)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("classlevelrangeend");
            entity.Property(e => e.Classlevelrangestart)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("classlevelrangestart");
            entity.Property(e => e.Commonactcof)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("commonactcof");
            entity.Property(e => e.Maxnpcitemlevel).HasColumnName("maxnpcitemlevel");
            entity.Property(e => e.Start)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("start");
            entity.Property(e => e.Town)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("town");
            entity.Property(e => e.WanderingMonsterPopulateChance).HasColumnName("wanderingMonsterPopulateChance");
            entity.Property(e => e.WanderingMonsterRegionTotal).HasColumnName("wanderingMonsterRegionTotal");
            entity.Property(e => e.WanderingPopulateRandomChance).HasColumnName("wanderingPopulateRandomChance");
            entity.Property(e => e.Wanderingnpcrange)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("wanderingnpcrange");
            entity.Property(e => e.Wanderingnpcstart)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("wanderingnpcstart");
            entity.Property(e => e.Waypoint1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("waypoint1");
            entity.Property(e => e.Waypoint2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("waypoint2");
            entity.Property(e => e.Waypoint3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("waypoint3");
            entity.Property(e => e.Waypoint4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("waypoint4");
            entity.Property(e => e.Waypoint5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("waypoint5");
            entity.Property(e => e.Waypoint6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("waypoint6");
            entity.Property(e => e.Waypoint7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("waypoint7");
            entity.Property(e => e.Waypoint8)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("waypoint8");
            entity.Property(e => e.Waypoint9)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("waypoint9");
        });

        modelBuilder.Entity<Armor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("armor");

            entity.Property(e => e.Alternategfx)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("alternategfx");
            entity.Property(e => e.AutoPrefix).HasColumnName("auto_prefix");
            entity.Property(e => e.Belt)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("belt");
            entity.Property(e => e.Bitfield1).HasColumnName("bitfield1");
            entity.Property(e => e.Block)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("block");
            entity.Property(e => e.Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("code");
            entity.Property(e => e.Compactsave)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("compactsave");
            entity.Property(e => e.Component).HasColumnName("component");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Diablocloneweight).HasColumnName("diablocloneweight");
            entity.Property(e => e.Dropsfxframe).HasColumnName("dropsfxframe");
            entity.Property(e => e.Dropsound)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dropsound");
            entity.Property(e => e.Durability).HasColumnName("durability");
            entity.Property(e => e.Durwarning).HasColumnName("durwarning");
            entity.Property(e => e.Flippyfile)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("flippyfile");
            entity.Property(e => e.GambleCost).HasColumnName("gamble_cost");
            entity.Property(e => e.Gemapplytype).HasColumnName("gemapplytype");
            entity.Property(e => e.Gemoffset)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("gemoffset");
            entity.Property(e => e.Gemsockets).HasColumnName("gemsockets");
            entity.Property(e => e.Hasinv).HasColumnName("hasinv");
            entity.Property(e => e.HellUpgrade).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Invfile)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("invfile");
            entity.Property(e => e.Invheight).HasColumnName("invheight");
            entity.Property(e => e.Invwidth).HasColumnName("invwidth");
            entity.Property(e => e.LArm).HasColumnName("lArm");
            entity.Property(e => e.LSpad).HasColumnName("lSPad");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Levelreq).HasColumnName("levelreq");
            entity.Property(e => e.Lightradius)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("lightradius");
            entity.Property(e => e.MagicLvl).HasColumnName("magic_lvl");
            entity.Property(e => e.Maxac).HasColumnName("maxac");
            entity.Property(e => e.Maxdam)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("maxdam");
            entity.Property(e => e.Maxstack).HasColumnName("maxstack");
            entity.Property(e => e.Minac).HasColumnName("minac");
            entity.Property(e => e.Mindam)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mindam");
            entity.Property(e => e.Minstack).HasColumnName("minstack");
            entity.Property(e => e.Missiletype)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("missiletype");
            entity.Property(e => e.Name)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("name");
            entity.Property(e => e.Namestr)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("namestr");
            entity.Property(e => e.NightmareUpgrade).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Nodurability)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("nodurability");
            entity.Property(e => e.Normcode)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("normcode");
            entity.Property(e => e.PermStoreItem).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Qntwarning)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("qntwarning");
            entity.Property(e => e.Quest).HasColumnName("quest");
            entity.Property(e => e.Questdiffcheck).HasColumnName("questdiffcheck");
            entity.Property(e => e.Quivered)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("quivered");
            entity.Property(e => e.RArm).HasColumnName("rArm");
            entity.Property(e => e.RSpad).HasColumnName("rSPad");
            entity.Property(e => e.Rarity).HasColumnName("rarity");
            entity.Property(e => e.Reqdex)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("reqdex");
            entity.Property(e => e.Reqstr).HasColumnName("reqstr");
            entity.Property(e => e.Setinvfile)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("setinvfile");
            entity.Property(e => e.ShowLevel).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.SkipName).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Spawnable).HasColumnName("spawnable");
            entity.Property(e => e.Spawnstack).HasColumnName("spawnstack");
            entity.Property(e => e.Speed)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("speed");
            entity.Property(e => e.Stackable).HasColumnName("stackable");
            entity.Property(e => e.TmogMax).HasColumnName("TMogMax");
            entity.Property(e => e.TmogMin).HasColumnName("TMogMin");
            entity.Property(e => e.TmogType)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("TMogType");
            entity.Property(e => e.Transmogrify).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Transparent)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("transparent");
            entity.Property(e => e.Transtbl).HasColumnName("transtbl");
            entity.Property(e => e.Type)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("type");
            entity.Property(e => e.Type2).HasColumnName("type2");
            entity.Property(e => e.Ubercode)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("ubercode");
            entity.Property(e => e.Ultracode)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("ultracode");
            entity.Property(e => e.Unique)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("unique");
            entity.Property(e => e.Uniqueinvfile)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("uniqueinvfile");
            entity.Property(e => e.Useable)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("useable");
            entity.Property(e => e.Usesound)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("usesound");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        modelBuilder.Entity<Armtype>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("armtype");

            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Token).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Automagic>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("automagic");

            entity.Property(e => e.Add)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("add");
            entity.Property(e => e.Class).HasColumnName("class");
            entity.Property(e => e.Classlevelreq).HasColumnName("classlevelreq");
            entity.Property(e => e.Classspecific).HasColumnName("classspecific");
            entity.Property(e => e.Etype1).HasColumnName("etype1");
            entity.Property(e => e.Etype2).HasColumnName("etype2");
            entity.Property(e => e.Etype3).HasColumnName("etype3");
            entity.Property(e => e.Etype4).HasColumnName("etype4");
            entity.Property(e => e.Etype5).HasColumnName("etype5");
            entity.Property(e => e.Frequency).HasColumnName("frequency");
            entity.Property(e => e.Group).HasColumnName("group");
            entity.Property(e => e.Itype1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype1");
            entity.Property(e => e.Itype2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype2");
            entity.Property(e => e.Itype3).HasColumnName("itype3");
            entity.Property(e => e.Itype4).HasColumnName("itype4");
            entity.Property(e => e.Itype5).HasColumnName("itype5");
            entity.Property(e => e.Itype6).HasColumnName("itype6");
            entity.Property(e => e.Itype7).HasColumnName("itype7");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Levelreq).HasColumnName("levelreq");
            entity.Property(e => e.Maxlevel).HasColumnName("maxlevel");
            entity.Property(e => e.Mod1code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod1code");
            entity.Property(e => e.Mod1max).HasColumnName("mod1max");
            entity.Property(e => e.Mod1min).HasColumnName("mod1min");
            entity.Property(e => e.Mod1param).HasColumnName("mod1param");
            entity.Property(e => e.Mod2code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod2code");
            entity.Property(e => e.Mod2max).HasColumnName("mod2max");
            entity.Property(e => e.Mod2min).HasColumnName("mod2min");
            entity.Property(e => e.Mod2param).HasColumnName("mod2param");
            entity.Property(e => e.Mod3code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod3code");
            entity.Property(e => e.Mod3max).HasColumnName("mod3max");
            entity.Property(e => e.Mod3min).HasColumnName("mod3min");
            entity.Property(e => e.Mod3param).HasColumnName("mod3param");
            entity.Property(e => e.Multiply)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("multiply");
            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Rare).HasColumnName("rare");
            entity.Property(e => e.Spawnable).HasColumnName("spawnable");
            entity.Property(e => e.Transformcolor)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("transformcolor");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        modelBuilder.Entity<Belt>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("belts");

            entity.Property(e => e.Box10bottom).HasColumnName("box10bottom");
            entity.Property(e => e.Box10left).HasColumnName("box10left");
            entity.Property(e => e.Box10right).HasColumnName("box10right");
            entity.Property(e => e.Box10top).HasColumnName("box10top");
            entity.Property(e => e.Box11bottom).HasColumnName("box11bottom");
            entity.Property(e => e.Box11left).HasColumnName("box11left");
            entity.Property(e => e.Box11right).HasColumnName("box11right");
            entity.Property(e => e.Box11top).HasColumnName("box11top");
            entity.Property(e => e.Box12bottom).HasColumnName("box12bottom");
            entity.Property(e => e.Box12left).HasColumnName("box12left");
            entity.Property(e => e.Box12right).HasColumnName("box12right");
            entity.Property(e => e.Box12top).HasColumnName("box12top");
            entity.Property(e => e.Box13bottom).HasColumnName("box13bottom");
            entity.Property(e => e.Box13left).HasColumnName("box13left");
            entity.Property(e => e.Box13right).HasColumnName("box13right");
            entity.Property(e => e.Box13top).HasColumnName("box13top");
            entity.Property(e => e.Box14bottom).HasColumnName("box14bottom");
            entity.Property(e => e.Box14left).HasColumnName("box14left");
            entity.Property(e => e.Box14right).HasColumnName("box14right");
            entity.Property(e => e.Box14top).HasColumnName("box14top");
            entity.Property(e => e.Box15bottom).HasColumnName("box15bottom");
            entity.Property(e => e.Box15left).HasColumnName("box15left");
            entity.Property(e => e.Box15right).HasColumnName("box15right");
            entity.Property(e => e.Box15top).HasColumnName("box15top");
            entity.Property(e => e.Box16bottom).HasColumnName("box16bottom");
            entity.Property(e => e.Box16left).HasColumnName("box16left");
            entity.Property(e => e.Box16right).HasColumnName("box16right");
            entity.Property(e => e.Box16top).HasColumnName("box16top");
            entity.Property(e => e.Box1bottom).HasColumnName("box1bottom");
            entity.Property(e => e.Box1left).HasColumnName("box1left");
            entity.Property(e => e.Box1right).HasColumnName("box1right");
            entity.Property(e => e.Box1top).HasColumnName("box1top");
            entity.Property(e => e.Box2bottom).HasColumnName("box2bottom");
            entity.Property(e => e.Box2left).HasColumnName("box2left");
            entity.Property(e => e.Box2right).HasColumnName("box2right");
            entity.Property(e => e.Box2top).HasColumnName("box2top");
            entity.Property(e => e.Box3bottom).HasColumnName("box3bottom");
            entity.Property(e => e.Box3left).HasColumnName("box3left");
            entity.Property(e => e.Box3right).HasColumnName("box3right");
            entity.Property(e => e.Box3top).HasColumnName("box3top");
            entity.Property(e => e.Box4bottom).HasColumnName("box4bottom");
            entity.Property(e => e.Box4left).HasColumnName("box4left");
            entity.Property(e => e.Box4right).HasColumnName("box4right");
            entity.Property(e => e.Box4top).HasColumnName("box4top");
            entity.Property(e => e.Box5bottom).HasColumnName("box5bottom");
            entity.Property(e => e.Box5left).HasColumnName("box5left");
            entity.Property(e => e.Box5right).HasColumnName("box5right");
            entity.Property(e => e.Box5top).HasColumnName("box5top");
            entity.Property(e => e.Box6bottom).HasColumnName("box6bottom");
            entity.Property(e => e.Box6left).HasColumnName("box6left");
            entity.Property(e => e.Box6right).HasColumnName("box6right");
            entity.Property(e => e.Box6top).HasColumnName("box6top");
            entity.Property(e => e.Box7bottom).HasColumnName("box7bottom");
            entity.Property(e => e.Box7left).HasColumnName("box7left");
            entity.Property(e => e.Box7right).HasColumnName("box7right");
            entity.Property(e => e.Box7top).HasColumnName("box7top");
            entity.Property(e => e.Box8bottom).HasColumnName("box8bottom");
            entity.Property(e => e.Box8left).HasColumnName("box8left");
            entity.Property(e => e.Box8right).HasColumnName("box8right");
            entity.Property(e => e.Box8top).HasColumnName("box8top");
            entity.Property(e => e.Box9bottom).HasColumnName("box9bottom");
            entity.Property(e => e.Box9left).HasColumnName("box9left");
            entity.Property(e => e.Box9right).HasColumnName("box9right");
            entity.Property(e => e.Box9top).HasColumnName("box9top");
            entity.Property(e => e.DefaultItemCodeCol1).HasColumnName("defaultItemCodeCol1");
            entity.Property(e => e.DefaultItemCodeCol2).HasColumnName("defaultItemCodeCol2");
            entity.Property(e => e.DefaultItemCodeCol3).HasColumnName("defaultItemCodeCol3");
            entity.Property(e => e.DefaultItemCodeCol4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("defaultItemCodeCol4");
            entity.Property(e => e.DefaultItemTypeCol1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("defaultItemTypeCol1");
            entity.Property(e => e.DefaultItemTypeCol2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("defaultItemTypeCol2");
            entity.Property(e => e.DefaultItemTypeCol3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("defaultItemTypeCol3");
            entity.Property(e => e.DefaultItemTypeCol4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("defaultItemTypeCol4");
            entity.Property(e => e.Name)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("name");
            entity.Property(e => e.Numboxes).HasColumnName("numboxes");
        });

        modelBuilder.Entity<Bodyloc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("bodylocs");

            entity.Property(e => e.BodyLocation)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Body_Location");
            entity.Property(e => e.Code).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("books");

            entity.Property(e => e.BookSkill).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.BookSpellCode).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.PSpell).HasColumnName("pSpell");
            entity.Property(e => e.ScrollSkill).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ScrollSpellCode).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Charstat>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("charstats");

            entity.Property(e => e.BaseWclass)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("baseWClass");
            entity.Property(e => e.Class)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("class");
            entity.Property(e => e.Comment).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Dex).HasColumnName("dex");
            entity.Property(e => e.Hpadd).HasColumnName("hpadd");
            entity.Property(e => e.Int).HasColumnName("int");
            entity.Property(e => e.Item1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item1");
            entity.Property(e => e.Item10)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item10");
            entity.Property(e => e.Item10count)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item10count");
            entity.Property(e => e.Item10loc).HasColumnName("item10loc");
            entity.Property(e => e.Item10quality).HasColumnName("item10quality");
            entity.Property(e => e.Item1count).HasColumnName("item1count");
            entity.Property(e => e.Item1loc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item1loc");
            entity.Property(e => e.Item1quality).HasColumnName("item1quality");
            entity.Property(e => e.Item2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item2");
            entity.Property(e => e.Item2count).HasColumnName("item2count");
            entity.Property(e => e.Item2loc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item2loc");
            entity.Property(e => e.Item2quality).HasColumnName("item2quality");
            entity.Property(e => e.Item3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item3");
            entity.Property(e => e.Item3count).HasColumnName("item3count");
            entity.Property(e => e.Item3loc).HasColumnName("item3loc");
            entity.Property(e => e.Item3quality).HasColumnName("item3quality");
            entity.Property(e => e.Item4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item4");
            entity.Property(e => e.Item4count).HasColumnName("item4count");
            entity.Property(e => e.Item4loc).HasColumnName("item4loc");
            entity.Property(e => e.Item4quality).HasColumnName("item4quality");
            entity.Property(e => e.Item5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item5");
            entity.Property(e => e.Item5count).HasColumnName("item5count");
            entity.Property(e => e.Item5loc).HasColumnName("item5loc");
            entity.Property(e => e.Item5quality).HasColumnName("item5quality");
            entity.Property(e => e.Item6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item6");
            entity.Property(e => e.Item6count)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item6count");
            entity.Property(e => e.Item6loc).HasColumnName("item6loc");
            entity.Property(e => e.Item6quality).HasColumnName("item6quality");
            entity.Property(e => e.Item7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item7");
            entity.Property(e => e.Item7count)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item7count");
            entity.Property(e => e.Item7loc).HasColumnName("item7loc");
            entity.Property(e => e.Item7quality).HasColumnName("item7quality");
            entity.Property(e => e.Item8)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item8");
            entity.Property(e => e.Item8count)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item8count");
            entity.Property(e => e.Item8loc).HasColumnName("item8loc");
            entity.Property(e => e.Item8quality).HasColumnName("item8quality");
            entity.Property(e => e.Item9)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item9");
            entity.Property(e => e.Item9count)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item9count");
            entity.Property(e => e.Item9loc).HasColumnName("item9loc");
            entity.Property(e => e.Item9quality).HasColumnName("item9quality");
            entity.Property(e => e.Skill1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Skill_1");
            entity.Property(e => e.Skill10).HasColumnName("Skill_10");
            entity.Property(e => e.Skill2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Skill_2");
            entity.Property(e => e.Skill3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Skill_3");
            entity.Property(e => e.Skill4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Skill_4");
            entity.Property(e => e.Skill5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Skill_5");
            entity.Property(e => e.Skill6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Skill_6");
            entity.Property(e => e.Skill7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Skill_7");
            entity.Property(e => e.Skill8)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Skill_8");
            entity.Property(e => e.Skill9)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Skill_9");
            entity.Property(e => e.Stamina).HasColumnName("stamina");
            entity.Property(e => e.StartSkill).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Str).HasColumnName("str");
            entity.Property(e => e.StrAllSkills).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.StrClassOnly).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.StrSkillTab1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.StrSkillTab2).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.StrSkillTab3).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Vit).HasColumnName("vit");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("colors");

            entity.Property(e => e.Code).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.TransformColor)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Transform_Color");
        });

        modelBuilder.Entity<Compcode>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("compcode");

            entity.Property(e => e.Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("code");
            entity.Property(e => e.Component)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("component");
        });

        modelBuilder.Entity<Composit>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("composit");

            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Token).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Cubemain>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("cubemain");

            entity.Property(e => e.BIlvl).HasColumnName("b_ilvl");
            entity.Property(e => e.BLvl).HasColumnName("b_lvl");
            entity.Property(e => e.BMod1).HasColumnName("b_mod_1");
            entity.Property(e => e.BMod1Chance).HasColumnName("b_mod_1_chance");
            entity.Property(e => e.BMod1Max).HasColumnName("b_mod_1_max");
            entity.Property(e => e.BMod1Min).HasColumnName("b_mod_1_min");
            entity.Property(e => e.BMod1Param).HasColumnName("b_mod_1_param");
            entity.Property(e => e.BMod2).HasColumnName("b_mod_2");
            entity.Property(e => e.BMod2Chance).HasColumnName("b_mod_2_chance");
            entity.Property(e => e.BMod2Max).HasColumnName("b_mod_2_max");
            entity.Property(e => e.BMod2Min).HasColumnName("b_mod_2_min");
            entity.Property(e => e.BMod2Param).HasColumnName("b_mod_2_param");
            entity.Property(e => e.BMod3).HasColumnName("b_mod_3");
            entity.Property(e => e.BMod3Chance).HasColumnName("b_mod_3_chance");
            entity.Property(e => e.BMod3Max).HasColumnName("b_mod_3_max");
            entity.Property(e => e.BMod3Min).HasColumnName("b_mod_3_min");
            entity.Property(e => e.BMod3Param).HasColumnName("b_mod_3_param");
            entity.Property(e => e.BMod4).HasColumnName("b_mod_4");
            entity.Property(e => e.BMod4Chance).HasColumnName("b_mod_4_chance");
            entity.Property(e => e.BMod4Max).HasColumnName("b_mod_4_max");
            entity.Property(e => e.BMod4Min).HasColumnName("b_mod_4_min");
            entity.Property(e => e.BMod4Param).HasColumnName("b_mod_4_param");
            entity.Property(e => e.BMod5).HasColumnName("b_mod_5");
            entity.Property(e => e.BMod5Chance).HasColumnName("b_mod_5_chance");
            entity.Property(e => e.BMod5Max).HasColumnName("b_mod_5_max");
            entity.Property(e => e.BMod5Min).HasColumnName("b_mod_5_min");
            entity.Property(e => e.BMod5Param).HasColumnName("b_mod_5_param");
            entity.Property(e => e.BPlvl).HasColumnName("b_plvl");
            entity.Property(e => e.CIlvl).HasColumnName("c_ilvl");
            entity.Property(e => e.CLvl).HasColumnName("c_lvl");
            entity.Property(e => e.CMod1).HasColumnName("c_mod_1");
            entity.Property(e => e.CMod1Chance).HasColumnName("c_mod_1_chance");
            entity.Property(e => e.CMod1Max).HasColumnName("c_mod_1_max");
            entity.Property(e => e.CMod1Min).HasColumnName("c_mod_1_min");
            entity.Property(e => e.CMod1Param).HasColumnName("c_mod_1_param");
            entity.Property(e => e.CMod2).HasColumnName("c_mod_2");
            entity.Property(e => e.CMod2Chance).HasColumnName("c_mod_2_chance");
            entity.Property(e => e.CMod2Max).HasColumnName("c_mod_2_max");
            entity.Property(e => e.CMod2Min).HasColumnName("c_mod_2_min");
            entity.Property(e => e.CMod2Param).HasColumnName("c_mod_2_param");
            entity.Property(e => e.CMod3).HasColumnName("c_mod_3");
            entity.Property(e => e.CMod3Chance).HasColumnName("c_mod_3_chance");
            entity.Property(e => e.CMod3Max).HasColumnName("c_mod_3_max");
            entity.Property(e => e.CMod3Min).HasColumnName("c_mod_3_min");
            entity.Property(e => e.CMod3Param).HasColumnName("c_mod_3_param");
            entity.Property(e => e.CMod4).HasColumnName("c_mod_4");
            entity.Property(e => e.CMod4Chance).HasColumnName("c_mod_4_chance");
            entity.Property(e => e.CMod4Max).HasColumnName("c_mod_4_max");
            entity.Property(e => e.CMod4Min).HasColumnName("c_mod_4_min");
            entity.Property(e => e.CMod4Param).HasColumnName("c_mod_4_param");
            entity.Property(e => e.CMod5).HasColumnName("c_mod_5");
            entity.Property(e => e.CMod5Chance).HasColumnName("c_mod_5_chance");
            entity.Property(e => e.CMod5Max).HasColumnName("c_mod_5_max");
            entity.Property(e => e.CMod5Min).HasColumnName("c_mod_5_min");
            entity.Property(e => e.CMod5Param).HasColumnName("c_mod_5_param");
            entity.Property(e => e.CPlvl).HasColumnName("c_plvl");
            entity.Property(e => e.Class).HasColumnName("class");
            entity.Property(e => e.Description)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("description");
            entity.Property(e => e.Enabled).HasColumnName("enabled");
            entity.Property(e => e.Eol)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("eol");
            entity.Property(e => e.FirstLadderSeason).HasColumnName("firstLadderSeason");
            entity.Property(e => e.Ilvl).HasColumnName("ilvl");
            entity.Property(e => e.Input1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("input_1");
            entity.Property(e => e.Input2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("input_2");
            entity.Property(e => e.Input3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("input_3");
            entity.Property(e => e.Input4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("input_4");
            entity.Property(e => e.Input5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("input_5");
            entity.Property(e => e.Input6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("input_6");
            entity.Property(e => e.Input7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("input_7");
            entity.Property(e => e.LastLadderSeason).HasColumnName("lastLadderSeason");
            entity.Property(e => e.Lvl).HasColumnName("lvl");
            entity.Property(e => e.MinDiff).HasColumnName("min_diff");
            entity.Property(e => e.Mod1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod_1");
            entity.Property(e => e.Mod1Chance).HasColumnName("mod_1_chance");
            entity.Property(e => e.Mod1Max).HasColumnName("mod_1_max");
            entity.Property(e => e.Mod1Min).HasColumnName("mod_1_min");
            entity.Property(e => e.Mod1Param).HasColumnName("mod_1_param");
            entity.Property(e => e.Mod2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod_2");
            entity.Property(e => e.Mod2Chance).HasColumnName("mod_2_chance");
            entity.Property(e => e.Mod2Max).HasColumnName("mod_2_max");
            entity.Property(e => e.Mod2Min).HasColumnName("mod_2_min");
            entity.Property(e => e.Mod2Param).HasColumnName("mod_2_param");
            entity.Property(e => e.Mod3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod_3");
            entity.Property(e => e.Mod3Chance).HasColumnName("mod_3_chance");
            entity.Property(e => e.Mod3Max).HasColumnName("mod_3_max");
            entity.Property(e => e.Mod3Min).HasColumnName("mod_3_min");
            entity.Property(e => e.Mod3Param).HasColumnName("mod_3_param");
            entity.Property(e => e.Mod4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod_4");
            entity.Property(e => e.Mod4Chance).HasColumnName("mod_4_chance");
            entity.Property(e => e.Mod4Max).HasColumnName("mod_4_max");
            entity.Property(e => e.Mod4Min).HasColumnName("mod_4_min");
            entity.Property(e => e.Mod4Param).HasColumnName("mod_4_param");
            entity.Property(e => e.Mod5).HasColumnName("mod_5");
            entity.Property(e => e.Mod5Chance).HasColumnName("mod_5_chance");
            entity.Property(e => e.Mod5Max).HasColumnName("mod_5_max");
            entity.Property(e => e.Mod5Min).HasColumnName("mod_5_min");
            entity.Property(e => e.Mod5Param).HasColumnName("mod_5_param");
            entity.Property(e => e.Numinputs).HasColumnName("numinputs");
            entity.Property(e => e.Op).HasColumnName("op");
            entity.Property(e => e.Output)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("output");
            entity.Property(e => e.OutputB).HasColumnName("output_b");
            entity.Property(e => e.OutputC).HasColumnName("output_c");
            entity.Property(e => e.Param).HasColumnName("param");
            entity.Property(e => e.Plvl).HasColumnName("plvl");
            entity.Property(e => e.Value).HasColumnName("value");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        modelBuilder.Entity<Cubemod>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("cubemod");

            entity.Property(e => e.Code).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.CubeModifierType)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cube_modifier_type");
        });

        modelBuilder.Entity<Difficultylevel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("difficultylevels");

            entity.Property(e => e.MercenaryDamagePercentVsboss).HasColumnName("MercenaryDamagePercentVSBoss");
            entity.Property(e => e.MercenaryDamagePercentVsmercenary).HasColumnName("MercenaryDamagePercentVSMercenary");
            entity.Property(e => e.MercenaryDamagePercentVsplayer).HasColumnName("MercenaryDamagePercentVSPlayer");
            entity.Property(e => e.MonsterCedamagePercent).HasColumnName("MonsterCEDamagePercent");
            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.PetDamagePercentVsplayer).HasColumnName("PetDamagePercentVSPlayer");
            entity.Property(e => e.PlayerDamagePercentVsmercenary).HasColumnName("PlayerDamagePercentVSMercenary");
            entity.Property(e => e.PlayerDamagePercentVsplayer).HasColumnName("PlayerDamagePercentVSPlayer");
            entity.Property(e => e.PlayerDamagePercentVsprimeEvil).HasColumnName("PlayerDamagePercentVSPrimeEvil");
            entity.Property(e => e.PlayerHitReactBufferVsmonster).HasColumnName("PlayerHitReactBufferVSMonster");
            entity.Property(e => e.PlayerHitReactBufferVsplayer).HasColumnName("PlayerHitReactBufferVSPlayer");
            entity.Property(e => e.PrimeEvilDamagePercentVsmercenary).HasColumnName("PrimeEvilDamagePercentVSMercenary");
            entity.Property(e => e.PrimeEvilDamagePercentVspet).HasColumnName("PrimeEvilDamagePercentVSPet");
            entity.Property(e => e.PrimeEvilDamagePercentVsplayer).HasColumnName("PrimeEvilDamagePercentVSPlayer");
        });

        modelBuilder.Entity<Elemtype>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("elemtypes");

            entity.Property(e => e.Code).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ElementalType)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Elemental_Type");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("events");

            entity.Property(e => e.Description)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("description");
            entity.Property(e => e.Event1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("event");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("experience");
        });

        modelBuilder.Entity<Gamble>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("gamble");

            entity.Property(e => e.Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Gem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("gems");

            entity.Property(e => e.Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("code");
            entity.Property(e => e.HelmMod1Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("helmMod1Code");
            entity.Property(e => e.HelmMod1Max).HasColumnName("helmMod1Max");
            entity.Property(e => e.HelmMod1Min).HasColumnName("helmMod1Min");
            entity.Property(e => e.HelmMod1Param)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("helmMod1Param");
            entity.Property(e => e.HelmMod2Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("helmMod2Code");
            entity.Property(e => e.HelmMod2Max)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("helmMod2Max");
            entity.Property(e => e.HelmMod2Min)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("helmMod2Min");
            entity.Property(e => e.HelmMod2Param)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("helmMod2Param");
            entity.Property(e => e.HelmMod3Code).HasColumnName("helmMod3Code");
            entity.Property(e => e.HelmMod3Max)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("helmMod3Max");
            entity.Property(e => e.HelmMod3Min)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("helmMod3Min");
            entity.Property(e => e.HelmMod3Param)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("helmMod3Param");
            entity.Property(e => e.Letter)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("letter");
            entity.Property(e => e.Name)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("name");
            entity.Property(e => e.ShieldMod1Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("shieldMod1Code");
            entity.Property(e => e.ShieldMod1Max).HasColumnName("shieldMod1Max");
            entity.Property(e => e.ShieldMod1Min).HasColumnName("shieldMod1Min");
            entity.Property(e => e.ShieldMod1Param)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("shieldMod1Param");
            entity.Property(e => e.ShieldMod2Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("shieldMod2Code");
            entity.Property(e => e.ShieldMod2Max)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("shieldMod2Max");
            entity.Property(e => e.ShieldMod2Min)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("shieldMod2Min");
            entity.Property(e => e.ShieldMod2Param)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("shieldMod2Param");
            entity.Property(e => e.ShieldMod3Code).HasColumnName("shieldMod3Code");
            entity.Property(e => e.ShieldMod3Max)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("shieldMod3Max");
            entity.Property(e => e.ShieldMod3Min)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("shieldMod3Min");
            entity.Property(e => e.ShieldMod3Param)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("shieldMod3Param");
            entity.Property(e => e.Transform).HasColumnName("transform");
            entity.Property(e => e.WeaponMod1Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("weaponMod1Code");
            entity.Property(e => e.WeaponMod1Max).HasColumnName("weaponMod1Max");
            entity.Property(e => e.WeaponMod1Min).HasColumnName("weaponMod1Min");
            entity.Property(e => e.WeaponMod1Param)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("weaponMod1Param");
            entity.Property(e => e.WeaponMod2Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("weaponMod2Code");
            entity.Property(e => e.WeaponMod2Max).HasColumnName("weaponMod2Max");
            entity.Property(e => e.WeaponMod2Min).HasColumnName("weaponMod2Min");
            entity.Property(e => e.WeaponMod2Param)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("weaponMod2Param");
            entity.Property(e => e.WeaponMod3Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("weaponMod3Code");
            entity.Property(e => e.WeaponMod3Max)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("weaponMod3Max");
            entity.Property(e => e.WeaponMod3Min)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("weaponMod3Min");
            entity.Property(e => e.WeaponMod3Param)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("weaponMod3Param");
        });

        modelBuilder.Entity<Hireling>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("hireling");

            entity.Property(e => e.Ar).HasColumnName("AR");
            entity.Property(e => e.ArLvl).HasColumnName("AR/Lvl");
            entity.Property(e => e.ChancePerLvl1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ChancePerLvl2).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ChancePerLvl3).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.DefLvl).HasColumnName("Def/Lvl");
            entity.Property(e => e.DexLvl).HasColumnName("Dex/Lvl");
            entity.Property(e => e.DmgLvl).HasColumnName("Dmg/Lvl");
            entity.Property(e => e.DmgMax).HasColumnName("Dmg-Max");
            entity.Property(e => e.DmgMin).HasColumnName("Dmg-Min");
            entity.Property(e => e.Equivalentcharclass)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("equivalentcharclass");
            entity.Property(e => e.ExpLvl).HasColumnName("Exp/Lvl");
            entity.Property(e => e.HireDesc).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Hireling1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Hireling");
            entity.Property(e => e.Hp).HasColumnName("HP");
            entity.Property(e => e.HpLvl).HasColumnName("HP/Lvl");
            entity.Property(e => e.NameFirst).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.NameLast).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ResistColdLvl).HasColumnName("ResistCold/Lvl");
            entity.Property(e => e.ResistFireLvl).HasColumnName("ResistFire/Lvl");
            entity.Property(e => e.ResistLightningLvl).HasColumnName("ResistLightning/Lvl");
            entity.Property(e => e.ResistPoisonLvl).HasColumnName("ResistPoison/Lvl");
            entity.Property(e => e.Resurrectcostdivisor).HasColumnName("resurrectcostdivisor");
            entity.Property(e => e.Resurrectcostmax).HasColumnName("resurrectcostmax");
            entity.Property(e => e.Resurrectcostmultiplier).HasColumnName("resurrectcostmultiplier");
            entity.Property(e => e.Skill1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Skill2).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Skill3).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.StrLvl).HasColumnName("Str/Lvl");
            entity.Property(e => e.SubType).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Hirelingdesc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("hirelingdesc");

            entity.Property(e => e.AlternateVoice).HasColumnName("alternateVoice");
            entity.Property(e => e.Eol)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("eol");
            entity.Property(e => e.HcIdx).HasColumnName("hcIdx");
            entity.Property(e => e.Id)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("id");
        });

        modelBuilder.Entity<Hitclass>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("hitclass");

            entity.Property(e => e.Code).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.HitClass1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Hit_Class");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("inventory");

            entity.Property(e => e.BeltBottom).HasColumnName("beltBottom");
            entity.Property(e => e.BeltHeight).HasColumnName("beltHeight");
            entity.Property(e => e.BeltLeft).HasColumnName("beltLeft");
            entity.Property(e => e.BeltRight).HasColumnName("beltRight");
            entity.Property(e => e.BeltTop).HasColumnName("beltTop");
            entity.Property(e => e.BeltWidth).HasColumnName("beltWidth");
            entity.Property(e => e.Class)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("class");
            entity.Property(e => e.FeetBottom).HasColumnName("feetBottom");
            entity.Property(e => e.FeetHeight).HasColumnName("feetHeight");
            entity.Property(e => e.FeetLeft).HasColumnName("feetLeft");
            entity.Property(e => e.FeetRight).HasColumnName("feetRight");
            entity.Property(e => e.FeetTop).HasColumnName("feetTop");
            entity.Property(e => e.FeetWidth).HasColumnName("feetWidth");
            entity.Property(e => e.GlovesBottom).HasColumnName("glovesBottom");
            entity.Property(e => e.GlovesHeight).HasColumnName("glovesHeight");
            entity.Property(e => e.GlovesLeft).HasColumnName("glovesLeft");
            entity.Property(e => e.GlovesRight).HasColumnName("glovesRight");
            entity.Property(e => e.GlovesTop).HasColumnName("glovesTop");
            entity.Property(e => e.GlovesWidth).HasColumnName("glovesWidth");
            entity.Property(e => e.GridBottom).HasColumnName("gridBottom");
            entity.Property(e => e.GridBoxHeight).HasColumnName("gridBoxHeight");
            entity.Property(e => e.GridBoxWidth).HasColumnName("gridBoxWidth");
            entity.Property(e => e.GridLeft).HasColumnName("gridLeft");
            entity.Property(e => e.GridRight).HasColumnName("gridRight");
            entity.Property(e => e.GridTop).HasColumnName("gridTop");
            entity.Property(e => e.GridX).HasColumnName("gridX");
            entity.Property(e => e.GridY).HasColumnName("gridY");
            entity.Property(e => e.HeadBottom).HasColumnName("headBottom");
            entity.Property(e => e.HeadHeight).HasColumnName("headHeight");
            entity.Property(e => e.HeadLeft).HasColumnName("headLeft");
            entity.Property(e => e.HeadRight).HasColumnName("headRight");
            entity.Property(e => e.HeadTop).HasColumnName("headTop");
            entity.Property(e => e.HeadWidth).HasColumnName("headWidth");
            entity.Property(e => e.InvBottom).HasColumnName("invBottom");
            entity.Property(e => e.InvLeft).HasColumnName("invLeft");
            entity.Property(e => e.InvRight).HasColumnName("invRight");
            entity.Property(e => e.InvTop).HasColumnName("invTop");
            entity.Property(e => e.LArmBottom).HasColumnName("lArmBottom");
            entity.Property(e => e.LArmHeight).HasColumnName("lArmHeight");
            entity.Property(e => e.LArmLeft).HasColumnName("lArmLeft");
            entity.Property(e => e.LArmRight).HasColumnName("lArmRight");
            entity.Property(e => e.LArmTop).HasColumnName("lArmTop");
            entity.Property(e => e.LArmWidth).HasColumnName("lArmWidth");
            entity.Property(e => e.LHandBottom).HasColumnName("lHandBottom");
            entity.Property(e => e.LHandHeight).HasColumnName("lHandHeight");
            entity.Property(e => e.LHandLeft).HasColumnName("lHandLeft");
            entity.Property(e => e.LHandRight).HasColumnName("lHandRight");
            entity.Property(e => e.LHandTop).HasColumnName("lHandTop");
            entity.Property(e => e.LHandWidth).HasColumnName("lHandWidth");
            entity.Property(e => e.NeckBottom).HasColumnName("neckBottom");
            entity.Property(e => e.NeckHeight).HasColumnName("neckHeight");
            entity.Property(e => e.NeckLeft).HasColumnName("neckLeft");
            entity.Property(e => e.NeckRight).HasColumnName("neckRight");
            entity.Property(e => e.NeckTop).HasColumnName("neckTop");
            entity.Property(e => e.NeckWidth).HasColumnName("neckWidth");
            entity.Property(e => e.RArmBottom).HasColumnName("rArmBottom");
            entity.Property(e => e.RArmHeight).HasColumnName("rArmHeight");
            entity.Property(e => e.RArmLeft).HasColumnName("rArmLeft");
            entity.Property(e => e.RArmRight).HasColumnName("rArmRight");
            entity.Property(e => e.RArmTop).HasColumnName("rArmTop");
            entity.Property(e => e.RArmWidth).HasColumnName("rArmWidth");
            entity.Property(e => e.RHandBottom).HasColumnName("rHandBottom");
            entity.Property(e => e.RHandHeight).HasColumnName("rHandHeight");
            entity.Property(e => e.RHandLeft).HasColumnName("rHandLeft");
            entity.Property(e => e.RHandRight).HasColumnName("rHandRight");
            entity.Property(e => e.RHandTop).HasColumnName("rHandTop");
            entity.Property(e => e.RHandWidth).HasColumnName("rHandWidth");
            entity.Property(e => e.TorsoBottom).HasColumnName("torsoBottom");
            entity.Property(e => e.TorsoHeight).HasColumnName("torsoHeight");
            entity.Property(e => e.TorsoLeft).HasColumnName("torsoLeft");
            entity.Property(e => e.TorsoRight).HasColumnName("torsoRight");
            entity.Property(e => e.TorsoTop).HasColumnName("torsoTop");
            entity.Property(e => e.TorsoWidth).HasColumnName("torsoWidth");
        });

        modelBuilder.Entity<Itemratio>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("itemratio");

            entity.Property(e => e.ClassSpecific)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Class_Specific");
            entity.Property(e => e.Function).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Itemstatcost>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("itemstatcost");

            entity.Property(e => e.Advdisplay).HasColumnName("advdisplay");
            entity.Property(e => e.CsvBits).HasColumnName("CSvBits");
            entity.Property(e => e.CsvParam).HasColumnName("CSvParam");
            entity.Property(e => e.CsvSigned)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("CSvSigned");
            entity.Property(e => e.Damagerelated).HasColumnName("damagerelated");
            entity.Property(e => e.Descfunc).HasColumnName("descfunc");
            entity.Property(e => e.Descpriority).HasColumnName("descpriority");
            entity.Property(e => e.Descstr2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("descstr2");
            entity.Property(e => e.Descstrneg)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("descstrneg");
            entity.Property(e => e.Descstrpos)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("descstrpos");
            entity.Property(e => e.Descval).HasColumnName("descval");
            entity.Property(e => e.Dgrp).HasColumnName("dgrp");
            entity.Property(e => e.Dgrpfunc).HasColumnName("dgrpfunc");
            entity.Property(e => e.Dgrpstr2).HasColumnName("dgrpstr2");
            entity.Property(e => e.Dgrpstrneg)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dgrpstrneg");
            entity.Property(e => e.Dgrpstrpos)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dgrpstrpos");
            entity.Property(e => e.Dgrpval).HasColumnName("dgrpval");
            entity.Property(e => e.Direct).HasColumnName("direct");
            entity.Property(e => e.Eol)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("eol");
            entity.Property(e => e.FCallback).HasColumnName("fCallback");
            entity.Property(e => e.FMin).HasColumnName("fMin");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Itemevent1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itemevent1");
            entity.Property(e => e.Itemevent2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itemevent2");
            entity.Property(e => e.Itemeventfunc1).HasColumnName("itemeventfunc1");
            entity.Property(e => e.Itemeventfunc2).HasColumnName("itemeventfunc2");
            entity.Property(e => e.Keepzero).HasColumnName("keepzero");
            entity.Property(e => e.Maxstat)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("maxstat");
            entity.Property(e => e.Op).HasColumnName("op");
            entity.Property(e => e.OpBase)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("op_base");
            entity.Property(e => e.OpParam).HasColumnName("op_param");
            entity.Property(e => e.OpStat1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("op_stat1");
            entity.Property(e => e.OpStat2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("op_stat2");
            entity.Property(e => e.OpStat3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("op_stat3");
            entity.Property(e => e.SaveAdd)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Save_Add");
            entity.Property(e => e.SaveBits).HasColumnName("Save_Bits");
            entity.Property(e => e.SaveParamBits).HasColumnName("Save_Param_Bits");
            entity.Property(e => e.SendBits).HasColumnName("Send_Bits");
            entity.Property(e => e.SendOther).HasColumnName("Send_Other");
            entity.Property(e => e.SendParamBits).HasColumnName("Send_Param_Bits");
            entity.Property(e => e.Stat).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Stuff).HasColumnName("stuff");
            entity.Property(e => e._109SaveAdd)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("1.09-Save_Add");
            entity.Property(e => e._109SaveBits).HasColumnName("1.09-Save_Bits");
        });

        modelBuilder.Entity<Itemtype>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("itemtypes");

            entity.Property(e => e.AutoStack).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Beltable).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Body).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.BodyLoc1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.BodyLoc2).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Class).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Code).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Eol)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("eol");
            entity.Property(e => e.Equiv1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Equiv2).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.InvGfx1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.InvGfx2).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.InvGfx3).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.InvGfx4).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.InvGfx5).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.InvGfx6).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ItemType1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("ItemType");
            entity.Property(e => e.MaxSockets1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.MaxSockets2).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.MaxSockets3).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Normal).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Quiver).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ReEquip).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Reload).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Repair).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Shoots).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.StaffMods).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.StorePage).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Throwable).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.TreasureClass).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.VarInvGfx).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("levels");

            entity.Property(e => e.Camt1).HasColumnName("camt1");
            entity.Property(e => e.Camt2).HasColumnName("camt2");
            entity.Property(e => e.Camt3).HasColumnName("camt3");
            entity.Property(e => e.Camt4).HasColumnName("camt4");
            entity.Property(e => e.Cmon1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cmon1");
            entity.Property(e => e.Cmon2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cmon2");
            entity.Property(e => e.Cmon3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cmon3");
            entity.Property(e => e.Cmon4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cmon4");
            entity.Property(e => e.Cpct1).HasColumnName("cpct1");
            entity.Property(e => e.Cpct2).HasColumnName("cpct2");
            entity.Property(e => e.Cpct3).HasColumnName("cpct3");
            entity.Property(e => e.Cpct4).HasColumnName("cpct4");
            entity.Property(e => e.Depend).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.DrawEdges).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Intensity).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.LevelEntry).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.LevelGroup).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.LevelName).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.LevelWarp).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Losdraw).HasColumnName("LOSDraw");
            entity.Property(e => e.Mon1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mon1");
            entity.Property(e => e.Mon10).HasColumnName("mon10");
            entity.Property(e => e.Mon11).HasColumnName("mon11");
            entity.Property(e => e.Mon12).HasColumnName("mon12");
            entity.Property(e => e.Mon13).HasColumnName("mon13");
            entity.Property(e => e.Mon14).HasColumnName("mon14");
            entity.Property(e => e.Mon15).HasColumnName("mon15");
            entity.Property(e => e.Mon16).HasColumnName("mon16");
            entity.Property(e => e.Mon17).HasColumnName("mon17");
            entity.Property(e => e.Mon18).HasColumnName("mon18");
            entity.Property(e => e.Mon19).HasColumnName("mon19");
            entity.Property(e => e.Mon2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mon2");
            entity.Property(e => e.Mon20).HasColumnName("mon20");
            entity.Property(e => e.Mon21).HasColumnName("mon21");
            entity.Property(e => e.Mon22).HasColumnName("mon22");
            entity.Property(e => e.Mon23).HasColumnName("mon23");
            entity.Property(e => e.Mon24).HasColumnName("mon24");
            entity.Property(e => e.Mon25).HasColumnName("mon25");
            entity.Property(e => e.Mon3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mon3");
            entity.Property(e => e.Mon4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mon4");
            entity.Property(e => e.Mon5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mon5");
            entity.Property(e => e.Mon6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mon6");
            entity.Property(e => e.Mon7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mon7");
            entity.Property(e => e.Mon8)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mon8");
            entity.Property(e => e.Mon9).HasColumnName("mon9");
            entity.Property(e => e.MonDenH).HasColumnName("MonDen(H)");
            entity.Property(e => e.MonDenN).HasColumnName("MonDen(N)");
            entity.Property(e => e.MonLvlExH).HasColumnName("MonLvlEx(H)");
            entity.Property(e => e.MonLvlExN).HasColumnName("MonLvlEx(N)");
            entity.Property(e => e.MonLvlH).HasColumnName("MonLvl(H)");
            entity.Property(e => e.MonLvlN).HasColumnName("MonLvl(N)");
            entity.Property(e => e.MonSpcWalk).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.MonUmax).HasColumnName("MonUMax");
            entity.Property(e => e.MonUmaxH).HasColumnName("MonUMax(H)");
            entity.Property(e => e.MonUmaxN).HasColumnName("MonUMax(N)");
            entity.Property(e => e.MonUmin)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("MonUMin");
            entity.Property(e => e.MonUminH).HasColumnName("MonUMin(H)");
            entity.Property(e => e.MonUminN).HasColumnName("MonUMin(N)");
            entity.Property(e => e.Mud).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Nmon1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("nmon1");
            entity.Property(e => e.Nmon10)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("nmon10");
            entity.Property(e => e.Nmon11).HasColumnName("nmon11");
            entity.Property(e => e.Nmon12).HasColumnName("nmon12");
            entity.Property(e => e.Nmon13).HasColumnName("nmon13");
            entity.Property(e => e.Nmon14).HasColumnName("nmon14");
            entity.Property(e => e.Nmon15).HasColumnName("nmon15");
            entity.Property(e => e.Nmon16).HasColumnName("nmon16");
            entity.Property(e => e.Nmon17).HasColumnName("nmon17");
            entity.Property(e => e.Nmon18).HasColumnName("nmon18");
            entity.Property(e => e.Nmon19).HasColumnName("nmon19");
            entity.Property(e => e.Nmon2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("nmon2");
            entity.Property(e => e.Nmon20).HasColumnName("nmon20");
            entity.Property(e => e.Nmon21).HasColumnName("nmon21");
            entity.Property(e => e.Nmon22).HasColumnName("nmon22");
            entity.Property(e => e.Nmon23).HasColumnName("nmon23");
            entity.Property(e => e.Nmon24).HasColumnName("nmon24");
            entity.Property(e => e.Nmon25).HasColumnName("nmon25");
            entity.Property(e => e.Nmon3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("nmon3");
            entity.Property(e => e.Nmon4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("nmon4");
            entity.Property(e => e.Nmon5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("nmon5");
            entity.Property(e => e.Nmon6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("nmon6");
            entity.Property(e => e.Nmon7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("nmon7");
            entity.Property(e => e.Nmon8)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("nmon8");
            entity.Property(e => e.Nmon9)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("nmon9");
            entity.Property(e => e.NoPer).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ObjGrp4).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ObjGrp5).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ObjGrp6).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ObjGrp7).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ObjPrb4).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ObjPrb5).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ObjPrb6).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ObjPrb7).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Portal).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Position).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Quest).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Rain).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Rangedspawn).HasColumnName("rangedspawn");
            entity.Property(e => e.SizeXH).HasColumnName("SizeX(H)");
            entity.Property(e => e.SizeXN).HasColumnName("SizeX(N)");
            entity.Property(e => e.SizeYH).HasColumnName("SizeY(H)");
            entity.Property(e => e.SizeYN).HasColumnName("SizeY(N)");
            entity.Property(e => e.StringName).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Themes).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Umon1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("umon1");
            entity.Property(e => e.Umon10).HasColumnName("umon10");
            entity.Property(e => e.Umon11).HasColumnName("umon11");
            entity.Property(e => e.Umon12).HasColumnName("umon12");
            entity.Property(e => e.Umon13).HasColumnName("umon13");
            entity.Property(e => e.Umon14).HasColumnName("umon14");
            entity.Property(e => e.Umon15).HasColumnName("umon15");
            entity.Property(e => e.Umon16).HasColumnName("umon16");
            entity.Property(e => e.Umon17).HasColumnName("umon17");
            entity.Property(e => e.Umon18).HasColumnName("umon18");
            entity.Property(e => e.Umon19).HasColumnName("umon19");
            entity.Property(e => e.Umon2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("umon2");
            entity.Property(e => e.Umon20).HasColumnName("umon20");
            entity.Property(e => e.Umon21).HasColumnName("umon21");
            entity.Property(e => e.Umon22).HasColumnName("umon22");
            entity.Property(e => e.Umon23).HasColumnName("umon23");
            entity.Property(e => e.Umon24).HasColumnName("umon24");
            entity.Property(e => e.Umon25).HasColumnName("umon25");
            entity.Property(e => e.Umon3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("umon3");
            entity.Property(e => e.Umon4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("umon4");
            entity.Property(e => e.Umon5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("umon5");
            entity.Property(e => e.Umon6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("umon6");
            entity.Property(e => e.Umon7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("umon7");
            entity.Property(e => e.Umon8)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("umon8");
            entity.Property(e => e.Umon9).HasColumnName("umon9");
            entity.Property(e => e.Vis1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Vis2).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Vis3).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Vis4).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Vis5).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Vis6).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Vis7).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Levelgroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("levelgroups");

            entity.Property(e => e.GroupName).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.StringName).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Localization>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Key });

            entity.ToTable("localization");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Key).HasColumnType("TEXT(30)");
            entity.Property(e => e.DeDe)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("deDE");
            entity.Property(e => e.EnUs)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("enUS");
            entity.Property(e => e.EsEs)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("esES");
            entity.Property(e => e.EsMx)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("esMX");
            entity.Property(e => e.FrFr)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("frFR");
            entity.Property(e => e.ItIt)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itIT");
            entity.Property(e => e.JaJp)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("jaJP");
            entity.Property(e => e.KoKr)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("koKR");
            entity.Property(e => e.PlPl)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("plPL");
            entity.Property(e => e.PtBr)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("ptBR");
            entity.Property(e => e.RuRu)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("ruRU");
            entity.Property(e => e.ZhCn)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("zhCN");
            entity.Property(e => e.ZhTw)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("zhTW");
        });

        modelBuilder.Entity<Lowqualityitem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("lowqualityitems");

            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Lvlmaze>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("lvlmaze");

            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.RoomsH).HasColumnName("Rooms(H)");
            entity.Property(e => e.RoomsN).HasColumnName("Rooms(N)");
        });

        modelBuilder.Entity<Lvlprest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("lvlprest");

            entity.Property(e => e.Animate).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.AutoMap).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.File1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.File2).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.File3).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.File4).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.File5).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.File6).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.LevelId).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Logicals).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Outdoors).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.PopPad).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Pops).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Scan).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Lvlsub>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("lvlsub");

            entity.Property(e => e.CheckAll).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.File).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Lvltype>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("lvltypes");

            entity.Property(e => e.File1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_1");
            entity.Property(e => e.File10)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_10");
            entity.Property(e => e.File11)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_11");
            entity.Property(e => e.File12)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_12");
            entity.Property(e => e.File13)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_13");
            entity.Property(e => e.File14)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_14");
            entity.Property(e => e.File15)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_15");
            entity.Property(e => e.File16)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_16");
            entity.Property(e => e.File17)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_17");
            entity.Property(e => e.File18)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_18");
            entity.Property(e => e.File19)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_19");
            entity.Property(e => e.File2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_2");
            entity.Property(e => e.File20)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_20");
            entity.Property(e => e.File21)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_21");
            entity.Property(e => e.File22)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_22");
            entity.Property(e => e.File23)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_23");
            entity.Property(e => e.File24)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_24");
            entity.Property(e => e.File25)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_25");
            entity.Property(e => e.File26)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_26");
            entity.Property(e => e.File27)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_27");
            entity.Property(e => e.File28)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_28");
            entity.Property(e => e.File29)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_29");
            entity.Property(e => e.File3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_3");
            entity.Property(e => e.File30)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_30");
            entity.Property(e => e.File31)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_31");
            entity.Property(e => e.File32)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_32");
            entity.Property(e => e.File4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_4");
            entity.Property(e => e.File5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_5");
            entity.Property(e => e.File6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_6");
            entity.Property(e => e.File7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_7");
            entity.Property(e => e.File8)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_8");
            entity.Property(e => e.File9)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("File_9");
            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Lvlwarp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("lvlwarp");

            entity.Property(e => e.Direction).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.NoInteract).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.SelectDx).HasColumnName("SelectDX");
            entity.Property(e => e.SelectDy).HasColumnName("SelectDY");
        });

        modelBuilder.Entity<Magicprefix>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("magicprefix");

            entity.Property(e => e.Add)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("add");
            entity.Property(e => e.Class).HasColumnName("class");
            entity.Property(e => e.Classlevelreq).HasColumnName("classlevelreq");
            entity.Property(e => e.Classspecific)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("classspecific");
            entity.Property(e => e.Etype1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("etype1");
            entity.Property(e => e.Etype2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("etype2");
            entity.Property(e => e.Etype3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("etype3");
            entity.Property(e => e.Etype4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("etype4");
            entity.Property(e => e.Etype5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("etype5");
            entity.Property(e => e.Frequency).HasColumnName("frequency");
            entity.Property(e => e.Group).HasColumnName("group");
            entity.Property(e => e.Itype1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype1");
            entity.Property(e => e.Itype2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype2");
            entity.Property(e => e.Itype3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype3");
            entity.Property(e => e.Itype4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype4");
            entity.Property(e => e.Itype5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype5");
            entity.Property(e => e.Itype6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype6");
            entity.Property(e => e.Itype7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype7");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Levelreq).HasColumnName("levelreq");
            entity.Property(e => e.Maxlevel).HasColumnName("maxlevel");
            entity.Property(e => e.Mod1code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod1code");
            entity.Property(e => e.Mod1max).HasColumnName("mod1max");
            entity.Property(e => e.Mod1min).HasColumnName("mod1min");
            entity.Property(e => e.Mod1param).HasColumnName("mod1param");
            entity.Property(e => e.Mod2code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod2code");
            entity.Property(e => e.Mod2max).HasColumnName("mod2max");
            entity.Property(e => e.Mod2min).HasColumnName("mod2min");
            entity.Property(e => e.Mod2param)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod2param");
            entity.Property(e => e.Mod3code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod3code");
            entity.Property(e => e.Mod3max).HasColumnName("mod3max");
            entity.Property(e => e.Mod3min).HasColumnName("mod3min");
            entity.Property(e => e.Mod3param).HasColumnName("mod3param");
            entity.Property(e => e.Multiply)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("multiply");
            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Rare).HasColumnName("rare");
            entity.Property(e => e.Spawnable).HasColumnName("spawnable");
            entity.Property(e => e.Transformcolor)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("transformcolor");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        modelBuilder.Entity<Magicsuffix>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("magicsuffix");

            entity.Property(e => e.Add)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("add");
            entity.Property(e => e.Class)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("class");
            entity.Property(e => e.Classlevelreq).HasColumnName("classlevelreq");
            entity.Property(e => e.Classspecific).HasColumnName("classspecific");
            entity.Property(e => e.Etype1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("etype1");
            entity.Property(e => e.Etype2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("etype2");
            entity.Property(e => e.Etype3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("etype3");
            entity.Property(e => e.Etype4).HasColumnName("etype4");
            entity.Property(e => e.Etype5).HasColumnName("etype5");
            entity.Property(e => e.Frequency).HasColumnName("frequency");
            entity.Property(e => e.Group).HasColumnName("group");
            entity.Property(e => e.Itype1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype1");
            entity.Property(e => e.Itype2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype2");
            entity.Property(e => e.Itype3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype3");
            entity.Property(e => e.Itype4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype4");
            entity.Property(e => e.Itype5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype5");
            entity.Property(e => e.Itype6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype6");
            entity.Property(e => e.Itype7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype7");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Levelreq).HasColumnName("levelreq");
            entity.Property(e => e.Maxlevel).HasColumnName("maxlevel");
            entity.Property(e => e.Mod1code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod1code");
            entity.Property(e => e.Mod1max).HasColumnName("mod1max");
            entity.Property(e => e.Mod1min).HasColumnName("mod1min");
            entity.Property(e => e.Mod1param).HasColumnName("mod1param");
            entity.Property(e => e.Mod2code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod2code");
            entity.Property(e => e.Mod2max).HasColumnName("mod2max");
            entity.Property(e => e.Mod2min).HasColumnName("mod2min");
            entity.Property(e => e.Mod2param).HasColumnName("mod2param");
            entity.Property(e => e.Mod3code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod3code");
            entity.Property(e => e.Mod3max).HasColumnName("mod3max");
            entity.Property(e => e.Mod3min).HasColumnName("mod3min");
            entity.Property(e => e.Mod3param).HasColumnName("mod3param");
            entity.Property(e => e.Multiply)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("multiply");
            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Rare).HasColumnName("rare");
            entity.Property(e => e.Spawnable).HasColumnName("spawnable");
            entity.Property(e => e.Transformcolor)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("transformcolor");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        modelBuilder.Entity<Misc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("misc");

            entity.Property(e => e.Alternategfx)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("alternategfx");
            entity.Property(e => e.Autobelt)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("autobelt");
            entity.Property(e => e.Belt)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("belt");
            entity.Property(e => e.BetterGem).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Bitfield1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("bitfield1");
            entity.Property(e => e.Calc1).HasColumnName("calc1");
            entity.Property(e => e.Calc2).HasColumnName("calc2");
            entity.Property(e => e.Calc3).HasColumnName("calc3");
            entity.Property(e => e.Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("code");
            entity.Property(e => e.Compactsave).HasColumnName("compactsave");
            entity.Property(e => e.Component).HasColumnName("component");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Cstate1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cstate1");
            entity.Property(e => e.Cstate2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cstate2");
            entity.Property(e => e.Diablocloneweight).HasColumnName("diablocloneweight");
            entity.Property(e => e.Dropsfxframe).HasColumnName("dropsfxframe");
            entity.Property(e => e.Dropsound)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dropsound");
            entity.Property(e => e.Durwarning)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("durwarning");
            entity.Property(e => e.Flippyfile)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("flippyfile");
            entity.Property(e => e.GambleCost).HasColumnName("gamble_cost");
            entity.Property(e => e.Gemapplytype)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("gemapplytype");
            entity.Property(e => e.Gemoffset)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("gemoffset");
            entity.Property(e => e.Gemsockets)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("gemsockets");
            entity.Property(e => e.Hasinv)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("hasinv");
            entity.Property(e => e.HellUpgrade).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.InvTrans).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Invfile)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("invfile");
            entity.Property(e => e.Invheight).HasColumnName("invheight");
            entity.Property(e => e.Invwidth).HasColumnName("invwidth");
            entity.Property(e => e.Len).HasColumnName("len");
            entity.Property(e => e.Level)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("level");
            entity.Property(e => e.Levelreq)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("levelreq");
            entity.Property(e => e.Lightradius)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("lightradius");
            entity.Property(e => e.Maxdam).HasColumnName("maxdam");
            entity.Property(e => e.Maxstack)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("maxstack");
            entity.Property(e => e.Mindam).HasColumnName("mindam");
            entity.Property(e => e.Minstack)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("minstack");
            entity.Property(e => e.Missiletype)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("missiletype");
            entity.Property(e => e.Multibuy).HasColumnName("multibuy");
            entity.Property(e => e.Name)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("name");
            entity.Property(e => e.Namestr)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("namestr");
            entity.Property(e => e.NightmareUpgrade).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Nodurability).HasColumnName("nodurability");
            entity.Property(e => e.PSpell).HasColumnName("pSpell");
            entity.Property(e => e.Qntwarning)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("qntwarning");
            entity.Property(e => e.Quest).HasColumnName("quest");
            entity.Property(e => e.Questdiffcheck).HasColumnName("questdiffcheck");
            entity.Property(e => e.Rarity).HasColumnName("rarity");
            entity.Property(e => e.Reqdex).HasColumnName("reqdex");
            entity.Property(e => e.Reqstr).HasColumnName("reqstr");
            entity.Property(e => e.ShowLevel).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.SkipName).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Spawnable).HasColumnName("spawnable");
            entity.Property(e => e.Spawnstack)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("spawnstack");
            entity.Property(e => e.Speed)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("speed");
            entity.Property(e => e.Spelldesc).HasColumnName("spelldesc");
            entity.Property(e => e.Spelldesccalc).HasColumnName("spelldesccalc");
            entity.Property(e => e.Spelldesccolor).HasColumnName("spelldesccolor");
            entity.Property(e => e.Spelldescstr)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("spelldescstr");
            entity.Property(e => e.Spelldescstr2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("spelldescstr2");
            entity.Property(e => e.Spellicon).HasColumnName("spellicon");
            entity.Property(e => e.Stackable)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("stackable");
            entity.Property(e => e.Stat1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("stat1");
            entity.Property(e => e.Stat2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("stat2");
            entity.Property(e => e.Stat3).HasColumnName("stat3");
            entity.Property(e => e.State)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("state");
            entity.Property(e => e.TmogMax).HasColumnName("TMogMax");
            entity.Property(e => e.TmogMin).HasColumnName("TMogMin");
            entity.Property(e => e.TmogType)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("TMogType");
            entity.Property(e => e.Transform).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Transmogrify).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Transparent)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("transparent");
            entity.Property(e => e.Transtbl).HasColumnName("transtbl");
            entity.Property(e => e.Type)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("type");
            entity.Property(e => e.Type2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("type2");
            entity.Property(e => e.Unique)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("unique");
            entity.Property(e => e.Uniqueinvfile)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("uniqueinvfile");
            entity.Property(e => e.Useable)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("useable");
            entity.Property(e => e.Usesound)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("usesound");
            entity.Property(e => e.Version)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("version");
        });

        modelBuilder.Entity<Misscalc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("misscalc");

            entity.Property(e => e.Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("description");
        });

        modelBuilder.Entity<Missile>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("missiles");

            entity.Property(e => e.Activate).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Animrate).HasColumnName("animrate");
            entity.Property(e => e.CHitPar1).HasColumnName("cHitPar1");
            entity.Property(e => e.CHitPar2).HasColumnName("cHitPar2");
            entity.Property(e => e.CHitPar3).HasColumnName("cHitPar3");
            entity.Property(e => e.CelFile).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ChitCalc1).HasColumnName("CHitCalc1");
            entity.Property(e => e.ClientCalc1Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("client_calc_1_desc");
            entity.Property(e => e.ClientHitCalc1Desc).HasColumnName("client_hit_calc1_desc");
            entity.Property(e => e.ClientHitParam1Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("client_hit_param1_desc");
            entity.Property(e => e.ClientHitParam2Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("client_hit_param2_desc");
            entity.Property(e => e.ClientHitParam3Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("client_hit_param3_desc");
            entity.Property(e => e.ClientParam1Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("client_param1_desc");
            entity.Property(e => e.ClientParam2Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("client_param2_desc");
            entity.Property(e => e.ClientParam3Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("client_param3_desc");
            entity.Property(e => e.ClientParam4Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("client_param4_desc");
            entity.Property(e => e.ClientParam5Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("client_param5_desc");
            entity.Property(e => e.CltCalc1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.CltHitSubMissile1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.CltHitSubMissile2).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.CltHitSubMissile3).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.CltHitSubMissile4).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.CltSubMissile1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.CltSubMissile2).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.CltSubMissile3).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.DParam1).HasColumnName("dParam1");
            entity.Property(e => e.DParam2).HasColumnName("dParam2");
            entity.Property(e => e.DamageCalc1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("damage_calc_1");
            entity.Property(e => e.DamageParam1Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("damage_param1_desc");
            entity.Property(e => e.DamageParam2Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("damage_param2_desc");
            entity.Property(e => e.DmgCalc1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.EdmgSymPerCalc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("EDmgSymPerCalc");
            entity.Property(e => e.Elen).HasColumnName("ELen");
            entity.Property(e => e.ElevLen1).HasColumnName("ELevLen1");
            entity.Property(e => e.ElevLen2).HasColumnName("ELevLen2");
            entity.Property(e => e.ElevLen3).HasColumnName("ELevLen3");
            entity.Property(e => e.Emax).HasColumnName("EMax");
            entity.Property(e => e.Emin).HasColumnName("EMin");
            entity.Property(e => e.Eol)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("eol");
            entity.Property(e => e.Etype)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("EType");
            entity.Property(e => e.ExplosionMissile).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Half2Hsrc).HasColumnName("Half2HSrc");
            entity.Property(e => e.HitSound).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.HitSubMissile1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.InitSteps).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.MaxElev1).HasColumnName("MaxELev1");
            entity.Property(e => e.MaxElev2).HasColumnName("MaxELev2");
            entity.Property(e => e.MaxElev3).HasColumnName("MaxELev3");
            entity.Property(e => e.MaxElev4).HasColumnName("MaxELev4");
            entity.Property(e => e.MaxElev5).HasColumnName("MaxELev5");
            entity.Property(e => e.MinElev1).HasColumnName("MinELev1");
            entity.Property(e => e.MinElev2).HasColumnName("MinELev2");
            entity.Property(e => e.MinElev3).HasColumnName("MinELev3");
            entity.Property(e => e.MinElev4).HasColumnName("MinELev4");
            entity.Property(e => e.MinElev5).HasColumnName("MinELev5");
            entity.Property(e => e.Missile1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Missile");
            entity.Property(e => e.PCltDoFunc).HasColumnName("pCltDoFunc");
            entity.Property(e => e.PCltHitFunc).HasColumnName("pCltHitFunc");
            entity.Property(e => e.PSrvDmgFunc).HasColumnName("pSrvDmgFunc");
            entity.Property(e => e.PSrvDoFunc).HasColumnName("pSrvDoFunc");
            entity.Property(e => e.PSrvHitFunc).HasColumnName("pSrvHitFunc");
            entity.Property(e => e.Param1Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("param1_desc");
            entity.Property(e => e.Param2Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("param2_desc");
            entity.Property(e => e.Param3Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("param3_desc");
            entity.Property(e => e.Param4Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("param4_desc");
            entity.Property(e => e.Param5Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("param5_desc");
            entity.Property(e => e.ProgOverlay).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ProgSound).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.SHitPar1).HasColumnName("sHitPar1");
            entity.Property(e => e.SHitPar2).HasColumnName("sHitPar2");
            entity.Property(e => e.SHitPar3).HasColumnName("sHitPar3");
            entity.Property(e => e.ServerHitCalc1Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("server_hit_calc_1_desc");
            entity.Property(e => e.ServerHitParam1Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("server_hit_param1_desc");
            entity.Property(e => e.ServerHitParam2Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("server_hit_param2_desc");
            entity.Property(e => e.ServerHitParam3Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("server_hit_param3_desc");
            entity.Property(e => e.ShitCalc1).HasColumnName("SHitCalc1");
            entity.Property(e => e.Skill).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.SrvCalc1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.SrvCalc1Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("srv_calc_1_desc");
            entity.Property(e => e.SubMissile1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.SubMissile2).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.TravelSound).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Xoffset).HasColumnName("xoffset");
            entity.Property(e => e.Yoffset).HasColumnName("yoffset");
            entity.Property(e => e.Zoffset).HasColumnName("zoffset");
        });

        modelBuilder.Entity<Npc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("npc");

            entity.Property(e => e.BuyMult).HasColumnName("buy_mult");
            entity.Property(e => e.MaxBuy).HasColumnName("max_buy");
            entity.Property(e => e.MaxBuyH).HasColumnName("max_buy_(H)");
            entity.Property(e => e.MaxBuyN).HasColumnName("max_buy_(N)");
            entity.Property(e => e.Npc1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("npc");
            entity.Property(e => e.QuestbuymultA).HasColumnName("questbuymult_A");
            entity.Property(e => e.QuestbuymultB).HasColumnName("questbuymult_B");
            entity.Property(e => e.QuestbuymultC).HasColumnName("questbuymult_C");
            entity.Property(e => e.QuestflagA).HasColumnName("questflag_A");
            entity.Property(e => e.QuestflagB).HasColumnName("questflag_B");
            entity.Property(e => e.QuestflagC).HasColumnName("questflag_C");
            entity.Property(e => e.QuestrepmultA).HasColumnName("questrepmult_A");
            entity.Property(e => e.QuestrepmultB).HasColumnName("questrepmult_B");
            entity.Property(e => e.QuestrepmultC).HasColumnName("questrepmult_C");
            entity.Property(e => e.QuestsellmultA).HasColumnName("questsellmult_A");
            entity.Property(e => e.QuestsellmultB).HasColumnName("questsellmult_B");
            entity.Property(e => e.QuestsellmultC).HasColumnName("questsellmult_C");
            entity.Property(e => e.RepMult).HasColumnName("rep_mult");
            entity.Property(e => e.SellMult).HasColumnName("sell_mult");
        });

        modelBuilder.Entity<Overlay>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("overlay");

            entity.Property(e => e.Character).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Filename).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Height1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Height2).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Height3).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Height4).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.InitRadius).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.LocalBlood).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.LoopWaitTime).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Overlay1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("overlay");
            entity.Property(e => e.PreDraw).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Radius).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Version)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("version");
            entity.Property(e => e.Xoffset).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Yoffset).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e._1ofN).HasColumnName("1ofN");
        });

        modelBuilder.Entity<Pettype>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("pettype");

            entity.Property(e => e.Automap).HasColumnName("automap");
            entity.Property(e => e.Baseicon)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("baseicon");
            entity.Property(e => e.Basemax)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("basemax");
            entity.Property(e => e.Drawhp).HasColumnName("drawhp");
            entity.Property(e => e.Group).HasColumnName("group");
            entity.Property(e => e.Icontype).HasColumnName("icontype");
            entity.Property(e => e.Mclass1).HasColumnName("mclass1");
            entity.Property(e => e.Mclass2).HasColumnName("mclass2");
            entity.Property(e => e.Mclass3).HasColumnName("mclass3");
            entity.Property(e => e.Mclass4).HasColumnName("mclass4");
            entity.Property(e => e.Micon1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("micon1");
            entity.Property(e => e.Micon2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("micon2");
            entity.Property(e => e.Micon3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("micon3");
            entity.Property(e => e.Micon4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("micon4");
            entity.Property(e => e.Name)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("name");
            entity.Property(e => e.Partysend).HasColumnName("partysend");
            entity.Property(e => e.PetType1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("pet_type");
            entity.Property(e => e.Range).HasColumnName("range");
            entity.Property(e => e.Unsummon).HasColumnName("unsummon");
            entity.Property(e => e.Warp).HasColumnName("warp");
        });

        modelBuilder.Entity<Playerclass>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("playerclass");

            entity.Property(e => e.Code).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.PlayerClass1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Player_Class");
        });

        modelBuilder.Entity<Plrmode>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("plrmode");

            entity.Property(e => e.Code).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Token).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Plrtype>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("plrtype");

            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Token).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("properties");

            entity.Property(e => e.Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("code");
            entity.Property(e => e.Eol)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("eol");
            entity.Property(e => e.Func1).HasColumnName("func1");
            entity.Property(e => e.Func2).HasColumnName("func2");
            entity.Property(e => e.Func3).HasColumnName("func3");
            entity.Property(e => e.Func4).HasColumnName("func4");
            entity.Property(e => e.Func5).HasColumnName("func5");
            entity.Property(e => e.Func6).HasColumnName("func6");
            entity.Property(e => e.Func7).HasColumnName("func7");
            entity.Property(e => e.Max).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Min).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Notes).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Parameter).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Set1).HasColumnName("set1");
            entity.Property(e => e.Set2).HasColumnName("set2");
            entity.Property(e => e.Set3).HasColumnName("set3");
            entity.Property(e => e.Set4).HasColumnName("set4");
            entity.Property(e => e.Set5).HasColumnName("set5");
            entity.Property(e => e.Set6).HasColumnName("set6");
            entity.Property(e => e.Set7).HasColumnName("set7");
            entity.Property(e => e.Stat1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("stat1");
            entity.Property(e => e.Stat2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("stat2");
            entity.Property(e => e.Stat3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("stat3");
            entity.Property(e => e.Stat4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("stat4");
            entity.Property(e => e.Stat5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("stat5");
            entity.Property(e => e.Stat6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("stat6");
            entity.Property(e => e.Stat7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("stat7");
            entity.Property(e => e.Tooltip).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Val1).HasColumnName("val1");
            entity.Property(e => e.Val2).HasColumnName("val2");
            entity.Property(e => e.Val3).HasColumnName("val3");
            entity.Property(e => e.Val4).HasColumnName("val4");
            entity.Property(e => e.Val5).HasColumnName("val5");
            entity.Property(e => e.Val6).HasColumnName("val6");
            entity.Property(e => e.Val7).HasColumnName("val7");
        });

        modelBuilder.Entity<Qualityitem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("qualityitems");

            entity.Property(e => e.Armor)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("armor");
            entity.Property(e => e.Belt)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("belt");
            entity.Property(e => e.Boots)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("boots");
            entity.Property(e => e.Bow).HasColumnName("bow");
            entity.Property(e => e.Gloves)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("gloves");
            entity.Property(e => e.Mod1code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod1code");
            entity.Property(e => e.Mod1max).HasColumnName("mod1max");
            entity.Property(e => e.Mod1min).HasColumnName("mod1min");
            entity.Property(e => e.Mod1param)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod1param");
            entity.Property(e => e.Mod2code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod2code");
            entity.Property(e => e.Mod2max).HasColumnName("mod2max");
            entity.Property(e => e.Mod2min).HasColumnName("mod2min");
            entity.Property(e => e.Mod2param)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("mod2param");
            entity.Property(e => e.Scepter).HasColumnName("scepter");
            entity.Property(e => e.Shield)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("shield");
            entity.Property(e => e.Staff).HasColumnName("staff");
            entity.Property(e => e.Wand).HasColumnName("wand");
            entity.Property(e => e.Weapon).HasColumnName("weapon");
        });

        modelBuilder.Entity<Rareprefix>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rareprefix");

            entity.Property(e => e.Etype1).HasColumnName("etype1");
            entity.Property(e => e.Etype2).HasColumnName("etype2");
            entity.Property(e => e.Etype3).HasColumnName("etype3");
            entity.Property(e => e.Etype4).HasColumnName("etype4");
            entity.Property(e => e.Itype1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype1");
            entity.Property(e => e.Itype2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype2");
            entity.Property(e => e.Itype3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype3");
            entity.Property(e => e.Itype4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype4");
            entity.Property(e => e.Itype5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype5");
            entity.Property(e => e.Itype6).HasColumnName("itype6");
            entity.Property(e => e.Itype7).HasColumnName("itype7");
            entity.Property(e => e.Name)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("name");
            entity.Property(e => e.Version)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("version");
        });

        modelBuilder.Entity<Raresuffix>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("raresuffix");

            entity.Property(e => e.Etype1).HasColumnName("etype1");
            entity.Property(e => e.Etype2).HasColumnName("etype2");
            entity.Property(e => e.Etype3).HasColumnName("etype3");
            entity.Property(e => e.Etype4).HasColumnName("etype4");
            entity.Property(e => e.Itype1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype1");
            entity.Property(e => e.Itype2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype2");
            entity.Property(e => e.Itype3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype3");
            entity.Property(e => e.Itype4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype4");
            entity.Property(e => e.Itype5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype5");
            entity.Property(e => e.Itype6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype6");
            entity.Property(e => e.Itype7).HasColumnName("itype7");
            entity.Property(e => e.Name)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("name");
            entity.Property(e => e.Version)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("version");
        });

        modelBuilder.Entity<Rune>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("runes");

            entity.Property(e => e.Complete).HasColumnName("complete");
            entity.Property(e => e.Eol)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("eol");
            entity.Property(e => e.Etype1).HasColumnName("etype1");
            entity.Property(e => e.Etype2).HasColumnName("etype2");
            entity.Property(e => e.Etype3).HasColumnName("etype3");
            entity.Property(e => e.FirstLadderSeason).HasColumnName("firstLadderSeason");
            entity.Property(e => e.Itype1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype1");
            entity.Property(e => e.Itype2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype2");
            entity.Property(e => e.Itype3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itype3");
            entity.Property(e => e.Itype4).HasColumnName("itype4");
            entity.Property(e => e.Itype5).HasColumnName("itype5");
            entity.Property(e => e.Itype6).HasColumnName("itype6");
            entity.Property(e => e.LastLadderSeason).HasColumnName("lastLadderSeason");
            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.PatchRelease).HasColumnName("Patch_Release");
            entity.Property(e => e.Rune1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Rune2).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Rune3).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Rune4).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Rune5).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Rune6).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.RuneName)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Rune_Name");
            entity.Property(e => e.RunesUsed).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.T1code1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("T1Code1");
            entity.Property(e => e.T1code2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("T1Code2");
            entity.Property(e => e.T1code3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("T1Code3");
            entity.Property(e => e.T1code4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("T1Code4");
            entity.Property(e => e.T1code5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("T1Code5");
            entity.Property(e => e.T1code6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("T1Code6");
            entity.Property(e => e.T1code7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("T1Code7");
            entity.Property(e => e.T1max1).HasColumnName("T1Max1");
            entity.Property(e => e.T1max2).HasColumnName("T1Max2");
            entity.Property(e => e.T1max3).HasColumnName("T1Max3");
            entity.Property(e => e.T1max4).HasColumnName("T1Max4");
            entity.Property(e => e.T1max5).HasColumnName("T1Max5");
            entity.Property(e => e.T1max6).HasColumnName("T1Max6");
            entity.Property(e => e.T1max7).HasColumnName("T1Max7");
            entity.Property(e => e.T1min1).HasColumnName("T1Min1");
            entity.Property(e => e.T1min2).HasColumnName("T1Min2");
            entity.Property(e => e.T1min3).HasColumnName("T1Min3");
            entity.Property(e => e.T1min4).HasColumnName("T1Min4");
            entity.Property(e => e.T1min5).HasColumnName("T1Min5");
            entity.Property(e => e.T1min6).HasColumnName("T1Min6");
            entity.Property(e => e.T1min7).HasColumnName("T1Min7");
            entity.Property(e => e.T1param1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("T1Param1");
            entity.Property(e => e.T1param2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("T1Param2");
            entity.Property(e => e.T1param3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("T1Param3");
            entity.Property(e => e.T1param4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("T1Param4");
            entity.Property(e => e.T1param5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("T1Param5");
            entity.Property(e => e.T1param6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("T1Param6");
            entity.Property(e => e.T1param7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("T1Param7");
        });

        modelBuilder.Entity<Set>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("sets");

            entity.Property(e => e.Eol)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("eol");
            entity.Property(e => e.Fcode1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("FCode1");
            entity.Property(e => e.Fcode2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("FCode2");
            entity.Property(e => e.Fcode3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("FCode3");
            entity.Property(e => e.Fcode4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("FCode4");
            entity.Property(e => e.Fcode5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("FCode5");
            entity.Property(e => e.Fcode6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("FCode6");
            entity.Property(e => e.Fcode7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("FCode7");
            entity.Property(e => e.Fcode8)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("FCode8");
            entity.Property(e => e.Fmax1).HasColumnName("FMax1");
            entity.Property(e => e.Fmax2).HasColumnName("FMax2");
            entity.Property(e => e.Fmax3).HasColumnName("FMax3");
            entity.Property(e => e.Fmax4).HasColumnName("FMax4");
            entity.Property(e => e.Fmax5).HasColumnName("FMax5");
            entity.Property(e => e.Fmax6).HasColumnName("FMax6");
            entity.Property(e => e.Fmax7).HasColumnName("FMax7");
            entity.Property(e => e.Fmax8).HasColumnName("FMax8");
            entity.Property(e => e.Fmin1).HasColumnName("FMin1");
            entity.Property(e => e.Fmin2).HasColumnName("FMin2");
            entity.Property(e => e.Fmin3).HasColumnName("FMin3");
            entity.Property(e => e.Fmin4).HasColumnName("FMin4");
            entity.Property(e => e.Fmin5).HasColumnName("FMin5");
            entity.Property(e => e.Fmin6).HasColumnName("FMin6");
            entity.Property(e => e.Fmin7).HasColumnName("FMin7");
            entity.Property(e => e.Fmin8).HasColumnName("FMin8");
            entity.Property(e => e.Fparam1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("FParam1");
            entity.Property(e => e.Fparam2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("FParam2");
            entity.Property(e => e.Fparam3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("FParam3");
            entity.Property(e => e.Fparam4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("FParam4");
            entity.Property(e => e.Fparam5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("FParam5");
            entity.Property(e => e.Fparam6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("FParam6");
            entity.Property(e => e.Fparam7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("FParam7");
            entity.Property(e => e.Fparam8).HasColumnName("FParam8");
            entity.Property(e => e.Index)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("index");
            entity.Property(e => e.Name)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("name");
            entity.Property(e => e.Pcode2a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("PCode2a");
            entity.Property(e => e.Pcode2b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("PCode2b");
            entity.Property(e => e.Pcode3a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("PCode3a");
            entity.Property(e => e.Pcode3b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("PCode3b");
            entity.Property(e => e.Pcode4a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("PCode4a");
            entity.Property(e => e.Pcode4b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("PCode4b");
            entity.Property(e => e.Pcode5a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("PCode5a");
            entity.Property(e => e.Pcode5b).HasColumnName("PCode5b");
            entity.Property(e => e.Pmax2a).HasColumnName("PMax2a");
            entity.Property(e => e.Pmax2b).HasColumnName("PMax2b");
            entity.Property(e => e.Pmax3a).HasColumnName("PMax3a");
            entity.Property(e => e.Pmax3b).HasColumnName("PMax3b");
            entity.Property(e => e.Pmax4a).HasColumnName("PMax4a");
            entity.Property(e => e.Pmax4b).HasColumnName("PMax4b");
            entity.Property(e => e.Pmax5a).HasColumnName("PMax5a");
            entity.Property(e => e.Pmax5b).HasColumnName("PMax5b");
            entity.Property(e => e.Pmin2a).HasColumnName("PMin2a");
            entity.Property(e => e.Pmin2b).HasColumnName("PMin2b");
            entity.Property(e => e.Pmin3a).HasColumnName("PMin3a");
            entity.Property(e => e.Pmin3b).HasColumnName("PMin3b");
            entity.Property(e => e.Pmin4a).HasColumnName("PMin4a");
            entity.Property(e => e.Pmin4b).HasColumnName("PMin4b");
            entity.Property(e => e.Pmin5a).HasColumnName("PMin5a");
            entity.Property(e => e.Pmin5b).HasColumnName("PMin5b");
            entity.Property(e => e.Pparam2a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("PParam2a");
            entity.Property(e => e.Pparam2b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("PParam2b");
            entity.Property(e => e.Pparam3a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("PParam3a");
            entity.Property(e => e.Pparam3b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("PParam3b");
            entity.Property(e => e.Pparam4a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("PParam4a");
            entity.Property(e => e.Pparam4b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("PParam4b");
            entity.Property(e => e.Pparam5a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("PParam5a");
            entity.Property(e => e.Pparam5b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("PParam5b");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        modelBuilder.Entity<Setitem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("setitems");

            entity.Property(e => e.AddFunc).HasColumnName("add_func");
            entity.Property(e => e.Amax1a).HasColumnName("amax1a");
            entity.Property(e => e.Amax1b).HasColumnName("amax1b");
            entity.Property(e => e.Amax2a).HasColumnName("amax2a");
            entity.Property(e => e.Amax2b).HasColumnName("amax2b");
            entity.Property(e => e.Amax3a).HasColumnName("amax3a");
            entity.Property(e => e.Amax3b).HasColumnName("amax3b");
            entity.Property(e => e.Amax4a).HasColumnName("amax4a");
            entity.Property(e => e.Amax4b).HasColumnName("amax4b");
            entity.Property(e => e.Amax5a).HasColumnName("amax5a");
            entity.Property(e => e.Amax5b).HasColumnName("amax5b");
            entity.Property(e => e.Amin1a).HasColumnName("amin1a");
            entity.Property(e => e.Amin1b).HasColumnName("amin1b");
            entity.Property(e => e.Amin2a).HasColumnName("amin2a");
            entity.Property(e => e.Amin2b).HasColumnName("amin2b");
            entity.Property(e => e.Amin3a).HasColumnName("amin3a");
            entity.Property(e => e.Amin3b).HasColumnName("amin3b");
            entity.Property(e => e.Amin4a).HasColumnName("amin4a");
            entity.Property(e => e.Amin4b).HasColumnName("amin4b");
            entity.Property(e => e.Amin5a).HasColumnName("amin5a");
            entity.Property(e => e.Amin5b).HasColumnName("amin5b");
            entity.Property(e => e.Apar1a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("apar1a");
            entity.Property(e => e.Apar1b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("apar1b");
            entity.Property(e => e.Apar2a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("apar2a");
            entity.Property(e => e.Apar2b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("apar2b");
            entity.Property(e => e.Apar3a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("apar3a");
            entity.Property(e => e.Apar3b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("apar3b");
            entity.Property(e => e.Apar4a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("apar4a");
            entity.Property(e => e.Apar4b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("apar4b");
            entity.Property(e => e.Apar5a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("apar5a");
            entity.Property(e => e.Apar5b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("apar5b");
            entity.Property(e => e.Aprop1a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aprop1a");
            entity.Property(e => e.Aprop1b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aprop1b");
            entity.Property(e => e.Aprop2a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aprop2a");
            entity.Property(e => e.Aprop2b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aprop2b");
            entity.Property(e => e.Aprop3a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aprop3a");
            entity.Property(e => e.Aprop3b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aprop3b");
            entity.Property(e => e.Aprop4a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aprop4a");
            entity.Property(e => e.Aprop4b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aprop4b");
            entity.Property(e => e.Aprop5a)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aprop5a");
            entity.Property(e => e.Aprop5b)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aprop5b");
            entity.Property(e => e.Chrtransform)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("chrtransform");
            entity.Property(e => e.CostAdd).HasColumnName("cost_add");
            entity.Property(e => e.CostMult).HasColumnName("cost_mult");
            entity.Property(e => e.Diablocloneweight).HasColumnName("diablocloneweight");
            entity.Property(e => e.Dropsfxframe).HasColumnName("dropsfxframe");
            entity.Property(e => e.Dropsound).HasColumnName("dropsound");
            entity.Property(e => e.Eol)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("eol");
            entity.Property(e => e.Flippyfile).HasColumnName("flippyfile");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Index)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("index");
            entity.Property(e => e.Invfile).HasColumnName("invfile");
            entity.Property(e => e.Invtransform)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("invtransform");
            entity.Property(e => e.Item)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item");
            entity.Property(e => e.ItemName).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Lvl).HasColumnName("lvl");
            entity.Property(e => e.LvlReq).HasColumnName("lvl_req");
            entity.Property(e => e.Max1).HasColumnName("max1");
            entity.Property(e => e.Max2).HasColumnName("max2");
            entity.Property(e => e.Max3).HasColumnName("max3");
            entity.Property(e => e.Max4).HasColumnName("max4");
            entity.Property(e => e.Max5).HasColumnName("max5");
            entity.Property(e => e.Max6).HasColumnName("max6");
            entity.Property(e => e.Max7).HasColumnName("max7");
            entity.Property(e => e.Max8).HasColumnName("max8");
            entity.Property(e => e.Max9).HasColumnName("max9");
            entity.Property(e => e.Min1).HasColumnName("min1");
            entity.Property(e => e.Min2).HasColumnName("min2");
            entity.Property(e => e.Min3).HasColumnName("min3");
            entity.Property(e => e.Min4).HasColumnName("min4");
            entity.Property(e => e.Min5).HasColumnName("min5");
            entity.Property(e => e.Min6).HasColumnName("min6");
            entity.Property(e => e.Min7).HasColumnName("min7");
            entity.Property(e => e.Min8).HasColumnName("min8");
            entity.Property(e => e.Min9).HasColumnName("min9");
            entity.Property(e => e.Par1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par1");
            entity.Property(e => e.Par2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par2");
            entity.Property(e => e.Par3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par3");
            entity.Property(e => e.Par4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par4");
            entity.Property(e => e.Par5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par5");
            entity.Property(e => e.Par6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par6");
            entity.Property(e => e.Par7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par7");
            entity.Property(e => e.Par8)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par8");
            entity.Property(e => e.Par9)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par9");
            entity.Property(e => e.Prop1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop1");
            entity.Property(e => e.Prop2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop2");
            entity.Property(e => e.Prop3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop3");
            entity.Property(e => e.Prop4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop4");
            entity.Property(e => e.Prop5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop5");
            entity.Property(e => e.Prop6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop6");
            entity.Property(e => e.Prop7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop7");
            entity.Property(e => e.Prop8)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop8");
            entity.Property(e => e.Prop9)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop9");
            entity.Property(e => e.Rarity).HasColumnName("rarity");
            entity.Property(e => e.Set)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("set");
            entity.Property(e => e.Usesound).HasColumnName("usesound");
        });

        modelBuilder.Entity<Shrine>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("shrines");

            entity.Property(e => e.DurationInFrames).HasColumnName("Duration_in_frames");
            entity.Property(e => e.Effect).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Effectclass).HasColumnName("effectclass");
            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Rarity).HasColumnName("rarity");
            entity.Property(e => e.ResetTimeInMinutes).HasColumnName("reset_time_in_minutes");
            entity.Property(e => e.ShrineType)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Shrine_Type");
            entity.Property(e => e.StringName).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.StringPhrase).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("skills");

            entity.Property(e => e.Aibonus).HasColumnName("aibonus");
            entity.Property(e => e.Aitype).HasColumnName("aitype");
            entity.Property(e => e.Alwayshit).HasColumnName("alwayshit");
            entity.Property(e => e.Anim)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("anim");
            entity.Property(e => e.Attackrank)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("attackrank");
            entity.Property(e => e.Aura).HasColumnName("aura");
            entity.Property(e => e.Auraevent1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("auraevent1");
            entity.Property(e => e.Auraevent2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("auraevent2");
            entity.Property(e => e.Auraevent3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("auraevent3");
            entity.Property(e => e.Auraeventfunc1).HasColumnName("auraeventfunc1");
            entity.Property(e => e.Auraeventfunc2).HasColumnName("auraeventfunc2");
            entity.Property(e => e.Auraeventfunc3).HasColumnName("auraeventfunc3");
            entity.Property(e => e.Aurafilter).HasColumnName("aurafilter");
            entity.Property(e => e.Auralencalc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("auralencalc");
            entity.Property(e => e.Aurarangecalc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aurarangecalc");
            entity.Property(e => e.Aurastat1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aurastat1");
            entity.Property(e => e.Aurastat2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aurastat2");
            entity.Property(e => e.Aurastat3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aurastat3");
            entity.Property(e => e.Aurastat4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aurastat4");
            entity.Property(e => e.Aurastat5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aurastat5");
            entity.Property(e => e.Aurastat6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aurastat6");
            entity.Property(e => e.Aurastatcalc1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aurastatcalc1");
            entity.Property(e => e.Aurastatcalc2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aurastatcalc2");
            entity.Property(e => e.Aurastatcalc3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aurastatcalc3");
            entity.Property(e => e.Aurastatcalc4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aurastatcalc4");
            entity.Property(e => e.Aurastatcalc5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aurastatcalc5");
            entity.Property(e => e.Aurastatcalc6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aurastatcalc6");
            entity.Property(e => e.Aurastate)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("aurastate");
            entity.Property(e => e.Auratargetstate)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("auratargetstate");
            entity.Property(e => e.Calc1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("calc1");
            entity.Property(e => e.Calc1Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("calc1_desc");
            entity.Property(e => e.Calc2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("calc2");
            entity.Property(e => e.Calc2Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("calc2_desc");
            entity.Property(e => e.Calc3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("calc3");
            entity.Property(e => e.Calc3Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("calc3_desc");
            entity.Property(e => e.Calc4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("calc4");
            entity.Property(e => e.Calc4Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("calc4_desc");
            entity.Property(e => e.Calc5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("calc5");
            entity.Property(e => e.Calc5Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("calc5_desc");
            entity.Property(e => e.Calc6).HasColumnName("calc6");
            entity.Property(e => e.Calc6Desc).HasColumnName("calc6_desc");
            entity.Property(e => e.Castoverlay)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("castoverlay");
            entity.Property(e => e.Charclass)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("charclass");
            entity.Property(e => e.Cltcalc1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cltcalc1");
            entity.Property(e => e.Cltcalc1Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cltcalc1_desc");
            entity.Property(e => e.Cltcalc2).HasColumnName("cltcalc2");
            entity.Property(e => e.Cltcalc2Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cltcalc2_desc");
            entity.Property(e => e.Cltcalc3).HasColumnName("cltcalc3");
            entity.Property(e => e.Cltcalc3Desc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cltcalc3_desc");
            entity.Property(e => e.Cltdofunc).HasColumnName("cltdofunc");
            entity.Property(e => e.Cltmissile)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cltmissile");
            entity.Property(e => e.Cltmissilea)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cltmissilea");
            entity.Property(e => e.Cltmissileb)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cltmissileb");
            entity.Property(e => e.Cltmissilec)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cltmissilec");
            entity.Property(e => e.Cltmissiled)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cltmissiled");
            entity.Property(e => e.Cltoverlaya)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cltoverlaya");
            entity.Property(e => e.Cltoverlayb)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cltoverlayb");
            entity.Property(e => e.Cltprgfunc1).HasColumnName("cltprgfunc1");
            entity.Property(e => e.Cltprgfunc2).HasColumnName("cltprgfunc2");
            entity.Property(e => e.Cltprgfunc3).HasColumnName("cltprgfunc3");
            entity.Property(e => e.Cltstfunc).HasColumnName("cltstfunc");
            entity.Property(e => e.Cltstopfunc).HasColumnName("cltstopfunc");
            entity.Property(e => e.CostAdd).HasColumnName("cost_add");
            entity.Property(e => e.CostMult).HasColumnName("cost_mult");
            entity.Property(e => e.Decquant).HasColumnName("decquant");
            entity.Property(e => e.DmgSymPerCalc).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Dosound)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dosound");
            entity.Property(e => e.DosoundA)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dosound_a");
            entity.Property(e => e.DosoundB)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dosound_b");
            entity.Property(e => e.Durability).HasColumnName("durability");
            entity.Property(e => e.EdmgSymPerCalc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("EDmgSymPerCalc");
            entity.Property(e => e.Elen).HasColumnName("ELen");
            entity.Property(e => e.ElenSymPerCalc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("ELenSymPerCalc");
            entity.Property(e => e.ElevLen1).HasColumnName("ELevLen1");
            entity.Property(e => e.ElevLen2).HasColumnName("ELevLen2");
            entity.Property(e => e.ElevLen3).HasColumnName("ELevLen3");
            entity.Property(e => e.Emax).HasColumnName("EMax");
            entity.Property(e => e.EmaxLev1).HasColumnName("EMaxLev1");
            entity.Property(e => e.EmaxLev2).HasColumnName("EMaxLev2");
            entity.Property(e => e.EmaxLev3).HasColumnName("EMaxLev3");
            entity.Property(e => e.EmaxLev4).HasColumnName("EMaxLev4");
            entity.Property(e => e.EmaxLev5).HasColumnName("EMaxLev5");
            entity.Property(e => e.Emin).HasColumnName("EMin");
            entity.Property(e => e.EminLev1).HasColumnName("EMinLev1");
            entity.Property(e => e.EminLev2).HasColumnName("EMinLev2");
            entity.Property(e => e.EminLev3).HasColumnName("EMinLev3");
            entity.Property(e => e.EminLev4).HasColumnName("EMinLev4");
            entity.Property(e => e.EminLev5).HasColumnName("EMinLev5");
            entity.Property(e => e.Enhanceable).HasColumnName("enhanceable");
            entity.Property(e => e.Eol)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("eol");
            entity.Property(e => e.Etype)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("EType");
            entity.Property(e => e.Etypea1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("etypea1");
            entity.Property(e => e.Etypea2).HasColumnName("etypea2");
            entity.Property(e => e.Etypeb1).HasColumnName("etypeb1");
            entity.Property(e => e.Etypeb2).HasColumnName("etypeb2");
            entity.Property(e => e.Finishing).HasColumnName("finishing");
            entity.Property(e => e.Globaldelay).HasColumnName("globaldelay");
            entity.Property(e => e.Immediate).HasColumnName("immediate");
            entity.Property(e => e.Interrupt).HasColumnName("interrupt");
            entity.Property(e => e.ItemCastOverlay).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.ItemCastSound).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Itypea1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itypea1");
            entity.Property(e => e.Itypea2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itypea2");
            entity.Property(e => e.Itypea3).HasColumnName("itypea3");
            entity.Property(e => e.Itypeb1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itypeb1");
            entity.Property(e => e.Itypeb2).HasColumnName("itypeb2");
            entity.Property(e => e.Itypeb3).HasColumnName("itypeb3");
            entity.Property(e => e.Leftskill)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("leftskill");
            entity.Property(e => e.Lob).HasColumnName("lob");
            entity.Property(e => e.Localdelay).HasColumnName("localdelay");
            entity.Property(e => e.Lvlmana)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("lvlmana");
            entity.Property(e => e.Mana).HasColumnName("mana");
            entity.Property(e => e.Manashift).HasColumnName("manashift");
            entity.Property(e => e.Maxlvl).HasColumnName("maxlvl");
            entity.Property(e => e.Minmana).HasColumnName("minmana");
            entity.Property(e => e.Monanim)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("monanim");
            entity.Property(e => e.Noammo).HasColumnName("noammo");
            entity.Property(e => e.Param10Description2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Param10_Description2");
            entity.Property(e => e.Param11Description)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Param11_Description");
            entity.Property(e => e.Param12Description).HasColumnName("Param12_Description");
            entity.Property(e => e.Param1Description)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Param1_Description");
            entity.Property(e => e.Param2Description)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Param2_Description");
            entity.Property(e => e.Param3Description)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Param3_Description");
            entity.Property(e => e.Param4Description)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Param4_Description");
            entity.Property(e => e.Param5Description)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Param5_Description");
            entity.Property(e => e.Param6Description)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Param6_Description");
            entity.Property(e => e.Param7Description)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Param7_Description");
            entity.Property(e => e.Param8Description)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Param8_Description");
            entity.Property(e => e.Param9Description)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Param9_Description");
            entity.Property(e => e.Passive).HasColumnName("passive");
            entity.Property(e => e.Passivecalc1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivecalc1");
            entity.Property(e => e.Passivecalc10)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivecalc10");
            entity.Property(e => e.Passivecalc2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivecalc2");
            entity.Property(e => e.Passivecalc3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivecalc3");
            entity.Property(e => e.Passivecalc4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivecalc4");
            entity.Property(e => e.Passivecalc5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivecalc5");
            entity.Property(e => e.Passivecalc6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivecalc6");
            entity.Property(e => e.Passivecalc7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivecalc7");
            entity.Property(e => e.Passivecalc8)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivecalc8");
            entity.Property(e => e.Passivecalc9)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivecalc9");
            entity.Property(e => e.Passiveitype)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passiveitype");
            entity.Property(e => e.Passivereqweaponcount).HasColumnName("passivereqweaponcount");
            entity.Property(e => e.Passivestat1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivestat1");
            entity.Property(e => e.Passivestat10)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivestat10");
            entity.Property(e => e.Passivestat2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivestat2");
            entity.Property(e => e.Passivestat3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivestat3");
            entity.Property(e => e.Passivestat4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivestat4");
            entity.Property(e => e.Passivestat5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivestat5");
            entity.Property(e => e.Passivestat6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivestat6");
            entity.Property(e => e.Passivestat7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivestat7");
            entity.Property(e => e.Passivestat8)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivestat8");
            entity.Property(e => e.Passivestat9)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivestat9");
            entity.Property(e => e.Passivestate)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("passivestate");
            entity.Property(e => e.Perdelay).HasColumnName("perdelay");
            entity.Property(e => e.Periodic).HasColumnName("periodic");
            entity.Property(e => e.Petmax)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("petmax");
            entity.Property(e => e.Pettype)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("pettype");
            entity.Property(e => e.Prgcalc1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prgcalc1");
            entity.Property(e => e.Prgcalc2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prgcalc2");
            entity.Property(e => e.Prgcalc3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prgcalc3");
            entity.Property(e => e.Prgchargesconsumed).HasColumnName("prgchargesconsumed");
            entity.Property(e => e.Prgchargestocast)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prgchargestocast");
            entity.Property(e => e.Prgdam).HasColumnName("prgdam");
            entity.Property(e => e.Prgoverlay)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prgoverlay");
            entity.Property(e => e.Prgsound)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prgsound");
            entity.Property(e => e.Prgstack).HasColumnName("prgstack");
            entity.Property(e => e.Progressive).HasColumnName("progressive");
            entity.Property(e => e.Range)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("range");
            entity.Property(e => e.Repeat).HasColumnName("repeat");
            entity.Property(e => e.Reqdex).HasColumnName("reqdex");
            entity.Property(e => e.Reqint).HasColumnName("reqint");
            entity.Property(e => e.Reqlevel).HasColumnName("reqlevel");
            entity.Property(e => e.Reqskill1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("reqskill1");
            entity.Property(e => e.Reqskill2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("reqskill2");
            entity.Property(e => e.Reqskill3).HasColumnName("reqskill3");
            entity.Property(e => e.Reqstr).HasColumnName("reqstr");
            entity.Property(e => e.Reqvit).HasColumnName("reqvit");
            entity.Property(e => e.Restrict).HasColumnName("restrict");
            entity.Property(e => e.Rightskill).HasColumnName("rightskill");
            entity.Property(e => e.Scroll).HasColumnName("scroll");
            entity.Property(e => e.SearchEnemyXy).HasColumnName("SearchEnemyXY");
            entity.Property(e => e.SearchOpenXy).HasColumnName("SearchOpenXY");
            entity.Property(e => e.Seqinput).HasColumnName("seqinput");
            entity.Property(e => e.Seqnum).HasColumnName("seqnum");
            entity.Property(e => e.Seqtrans)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("seqtrans");
            entity.Property(e => e.Skill1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("skill");
            entity.Property(e => e.Skilldesc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("skilldesc");
            entity.Property(e => e.Skpoints).HasColumnName("skpoints");
            entity.Property(e => e.Srvdofunc).HasColumnName("srvdofunc");
            entity.Property(e => e.Srvmissile)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("srvmissile");
            entity.Property(e => e.Srvmissilea)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("srvmissilea");
            entity.Property(e => e.Srvmissileb)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("srvmissileb");
            entity.Property(e => e.Srvmissilec)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("srvmissilec");
            entity.Property(e => e.Srvoverlay)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("srvoverlay");
            entity.Property(e => e.Srvprgfunc1).HasColumnName("srvprgfunc1");
            entity.Property(e => e.Srvprgfunc2).HasColumnName("srvprgfunc2");
            entity.Property(e => e.Srvprgfunc3).HasColumnName("srvprgfunc3");
            entity.Property(e => e.Srvstfunc).HasColumnName("srvstfunc");
            entity.Property(e => e.Srvstopfunc).HasColumnName("srvstopfunc");
            entity.Property(e => e.Startmana).HasColumnName("startmana");
            entity.Property(e => e.State1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.State2).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Stsound)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("stsound");
            entity.Property(e => e.Stsoundclass)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("stsoundclass");
            entity.Property(e => e.Stsounddelay).HasColumnName("stsounddelay");
            entity.Property(e => e.Stsuccessonly).HasColumnName("stsuccessonly");
            entity.Property(e => e.Summode)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("summode");
            entity.Property(e => e.Summon)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("summon");
            entity.Property(e => e.Sumoverlay)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("sumoverlay");
            entity.Property(e => e.Sumsk1calc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("sumsk1calc");
            entity.Property(e => e.Sumsk2calc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("sumsk2calc");
            entity.Property(e => e.Sumsk3calc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("sumsk3calc");
            entity.Property(e => e.Sumsk4calc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("sumsk4calc");
            entity.Property(e => e.Sumsk5calc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("sumsk5calc");
            entity.Property(e => e.Sumskill1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("sumskill1");
            entity.Property(e => e.Sumskill2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("sumskill2");
            entity.Property(e => e.Sumskill3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("sumskill3");
            entity.Property(e => e.Sumskill4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("sumskill4");
            entity.Property(e => e.Sumskill5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("sumskill5");
            entity.Property(e => e.Sumumod).HasColumnName("sumumod");
            entity.Property(e => e.Tgtoverlay)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("tgtoverlay");
            entity.Property(e => e.Tgtsound)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("tgtsound");
            entity.Property(e => e.ToHitCalc).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.UseServerMissilesOnRemoteClients).HasColumnName("useServerMissilesOnRemoteClients");
            entity.Property(e => e.Usemanaondo).HasColumnName("usemanaondo");
            entity.Property(e => e.Warp).HasColumnName("warp");
            entity.Property(e => e.Weaponsnd).HasColumnName("weaponsnd");
            entity.Property(e => e.Weapsel).HasColumnName("weapsel");
        });

        modelBuilder.Entity<Skillcalc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("skillcalc");

            entity.Property(e => e.Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Skilldesc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("skilldesc");

            entity.Property(e => e.DdamCalc1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("ddam_calc1");
            entity.Property(e => e.DdamCalc2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("ddam_calc2");
            entity.Property(e => e.Descatt).HasColumnName("descatt");
            entity.Property(e => e.Desccalca1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desccalca1");
            entity.Property(e => e.Desccalca2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desccalca2");
            entity.Property(e => e.Desccalca3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desccalca3");
            entity.Property(e => e.Desccalca4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desccalca4");
            entity.Property(e => e.Desccalca5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desccalca5");
            entity.Property(e => e.Desccalca6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desccalca6");
            entity.Property(e => e.Desccalcb1).HasColumnName("desccalcb1");
            entity.Property(e => e.Desccalcb2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desccalcb2");
            entity.Property(e => e.Desccalcb3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desccalcb3");
            entity.Property(e => e.Desccalcb4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desccalcb4");
            entity.Property(e => e.Desccalcb5).HasColumnName("desccalcb5");
            entity.Property(e => e.Desccalcb6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desccalcb6");
            entity.Property(e => e.Descdam).HasColumnName("descdam");
            entity.Property(e => e.Descline1).HasColumnName("descline1");
            entity.Property(e => e.Descline2).HasColumnName("descline2");
            entity.Property(e => e.Descline3).HasColumnName("descline3");
            entity.Property(e => e.Descline4).HasColumnName("descline4");
            entity.Property(e => e.Descline5).HasColumnName("descline5");
            entity.Property(e => e.Descline6).HasColumnName("descline6");
            entity.Property(e => e.Descmissile1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("descmissile1");
            entity.Property(e => e.Descmissile2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("descmissile2");
            entity.Property(e => e.Descmissile3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("descmissile3");
            entity.Property(e => e.Desctexta1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desctexta1");
            entity.Property(e => e.Desctexta2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desctexta2");
            entity.Property(e => e.Desctexta3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desctexta3");
            entity.Property(e => e.Desctexta4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desctexta4");
            entity.Property(e => e.Desctexta5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desctexta5");
            entity.Property(e => e.Desctexta6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desctexta6");
            entity.Property(e => e.Desctextb1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desctextb1");
            entity.Property(e => e.Desctextb2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desctextb2");
            entity.Property(e => e.Desctextb3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desctextb3");
            entity.Property(e => e.Desctextb4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desctextb4");
            entity.Property(e => e.Desctextb5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("desctextb5");
            entity.Property(e => e.Desctextb6).HasColumnName("desctextb6");
            entity.Property(e => e.Dsc2calca1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2calca1");
            entity.Property(e => e.Dsc2calca2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2calca2");
            entity.Property(e => e.Dsc2calca3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2calca3");
            entity.Property(e => e.Dsc2calca4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2calca4");
            entity.Property(e => e.Dsc2calca5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2calca5");
            entity.Property(e => e.Dsc2calcb1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2calcb1");
            entity.Property(e => e.Dsc2calcb2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2calcb2");
            entity.Property(e => e.Dsc2calcb3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2calcb3");
            entity.Property(e => e.Dsc2calcb4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2calcb4");
            entity.Property(e => e.Dsc2calcb5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2calcb5");
            entity.Property(e => e.Dsc2line1).HasColumnName("dsc2line1");
            entity.Property(e => e.Dsc2line2).HasColumnName("dsc2line2");
            entity.Property(e => e.Dsc2line3).HasColumnName("dsc2line3");
            entity.Property(e => e.Dsc2line4).HasColumnName("dsc2line4");
            entity.Property(e => e.Dsc2line5).HasColumnName("dsc2line5");
            entity.Property(e => e.Dsc2texta1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2texta1");
            entity.Property(e => e.Dsc2texta2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2texta2");
            entity.Property(e => e.Dsc2texta3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2texta3");
            entity.Property(e => e.Dsc2texta4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2texta4");
            entity.Property(e => e.Dsc2texta5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2texta5");
            entity.Property(e => e.Dsc2textb1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2textb1");
            entity.Property(e => e.Dsc2textb2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2textb2");
            entity.Property(e => e.Dsc2textb3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc2textb3");
            entity.Property(e => e.Dsc2textb4).HasColumnName("dsc2textb4");
            entity.Property(e => e.Dsc2textb5).HasColumnName("dsc2textb5");
            entity.Property(e => e.Dsc3calca1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3calca1");
            entity.Property(e => e.Dsc3calca2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3calca2");
            entity.Property(e => e.Dsc3calca3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3calca3");
            entity.Property(e => e.Dsc3calca4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3calca4");
            entity.Property(e => e.Dsc3calca5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3calca5");
            entity.Property(e => e.Dsc3calca6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3calca6");
            entity.Property(e => e.Dsc3calca7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3calca7");
            entity.Property(e => e.Dsc3calcb1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3calcb1");
            entity.Property(e => e.Dsc3calcb2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3calcb2");
            entity.Property(e => e.Dsc3calcb3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3calcb3");
            entity.Property(e => e.Dsc3calcb4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3calcb4");
            entity.Property(e => e.Dsc3calcb5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3calcb5");
            entity.Property(e => e.Dsc3calcb6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3calcb6");
            entity.Property(e => e.Dsc3calcb7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3calcb7");
            entity.Property(e => e.Dsc3line1).HasColumnName("dsc3line1");
            entity.Property(e => e.Dsc3line2).HasColumnName("dsc3line2");
            entity.Property(e => e.Dsc3line3).HasColumnName("dsc3line3");
            entity.Property(e => e.Dsc3line4).HasColumnName("dsc3line4");
            entity.Property(e => e.Dsc3line5).HasColumnName("dsc3line5");
            entity.Property(e => e.Dsc3line6).HasColumnName("dsc3line6");
            entity.Property(e => e.Dsc3line7).HasColumnName("dsc3line7");
            entity.Property(e => e.Dsc3texta1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3texta1");
            entity.Property(e => e.Dsc3texta2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3texta2");
            entity.Property(e => e.Dsc3texta3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3texta3");
            entity.Property(e => e.Dsc3texta4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3texta4");
            entity.Property(e => e.Dsc3texta5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3texta5");
            entity.Property(e => e.Dsc3texta6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3texta6");
            entity.Property(e => e.Dsc3texta7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3texta7");
            entity.Property(e => e.Dsc3textb1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3textb1");
            entity.Property(e => e.Dsc3textb2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3textb2");
            entity.Property(e => e.Dsc3textb3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3textb3");
            entity.Property(e => e.Dsc3textb4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3textb4");
            entity.Property(e => e.Dsc3textb5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3textb5");
            entity.Property(e => e.Dsc3textb6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dsc3textb6");
            entity.Property(e => e.Dsc3textb7).HasColumnName("dsc3textb7");
            entity.Property(e => e.Eol)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("eol");
            entity.Property(e => e.ItemProcDesclineCount).HasColumnName("item_proc_descline_count");
            entity.Property(e => e.ItemProcText)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("item_proc_text");
            entity.Property(e => e.P1dmelem)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("p1dmelem");
            entity.Property(e => e.P1dmmax)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("p1dmmax");
            entity.Property(e => e.P1dmmin)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("p1dmmin");
            entity.Property(e => e.P2dmelem)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("p2dmelem");
            entity.Property(e => e.P2dmmax)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("p2dmmax");
            entity.Property(e => e.P2dmmin)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("p2dmmin");
            entity.Property(e => e.P3dmelem)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("p3dmelem");
            entity.Property(e => e.P3dmmax)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("p3dmmax");
            entity.Property(e => e.P3dmmin)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("p3dmmin");
            entity.Property(e => e.Skilldesc1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("skilldesc");
            entity.Property(e => e.StrAlt)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("str_alt");
            entity.Property(e => e.StrLong)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("str_long");
            entity.Property(e => e.StrName)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("str_name");
            entity.Property(e => e.StrShort)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("str_short");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("states");

            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Armblue).HasColumnName("armblue");
            entity.Property(e => e.Armred).HasColumnName("armred");
            entity.Property(e => e.Attblue).HasColumnName("attblue");
            entity.Property(e => e.Attred).HasColumnName("attred");
            entity.Property(e => e.Aura).HasColumnName("aura");
            entity.Property(e => e.Bossinv).HasColumnName("bossinv");
            entity.Property(e => e.Bossstaydeath).HasColumnName("bossstaydeath");
            entity.Property(e => e.Canstack).HasColumnName("canstack");
            entity.Property(e => e.Castoverlay)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("castoverlay");
            entity.Property(e => e.Cltactivefunc).HasColumnName("cltactivefunc");
            entity.Property(e => e.Cltevent)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("cltevent");
            entity.Property(e => e.Clteventfunc).HasColumnName("clteventfunc");
            entity.Property(e => e.Colorpri).HasColumnName("colorpri");
            entity.Property(e => e.Colorshift).HasColumnName("colorshift");
            entity.Property(e => e.Curable).HasColumnName("curable");
            entity.Property(e => e.Curse).HasColumnName("curse");
            entity.Property(e => e.Damblue).HasColumnName("damblue");
            entity.Property(e => e.Damred).HasColumnName("damred");
            entity.Property(e => e.Disguise).HasColumnName("disguise");
            entity.Property(e => e.Eol)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("eol");
            entity.Property(e => e.Exp).HasColumnName("exp");
            entity.Property(e => e.Gfxclass).HasColumnName("gfxclass");
            entity.Property(e => e.Gfxtype).HasColumnName("gfxtype");
            entity.Property(e => e.Green).HasColumnName("green");
            entity.Property(e => e.Group).HasColumnName("group");
            entity.Property(e => e.Hide).HasColumnName("hide");
            entity.Property(e => e.Hidedead).HasColumnName("hidedead");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Itemtrans)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itemtrans");
            entity.Property(e => e.Itemtype)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("itemtype");
            entity.Property(e => e.Life).HasColumnName("life");
            entity.Property(e => e.LightB).HasColumnName("light-b");
            entity.Property(e => e.LightG).HasColumnName("light-g");
            entity.Property(e => e.LightR).HasColumnName("light-r");
            entity.Property(e => e.Meleeonly).HasColumnName("meleeonly");
            entity.Property(e => e.Missile)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("missile");
            entity.Property(e => e.Monstaydeath).HasColumnName("monstaydeath");
            entity.Property(e => e.Noclear).HasColumnName("noclear");
            entity.Property(e => e.Nooverlays).HasColumnName("nooverlays");
            entity.Property(e => e.Nosend).HasColumnName("nosend");
            entity.Property(e => e.Notondead).HasColumnName("notondead");
            entity.Property(e => e.Offsound)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("offsound");
            entity.Property(e => e.Onsound)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("onsound");
            entity.Property(e => e.Overlay1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("overlay1");
            entity.Property(e => e.Overlay2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("overlay2");
            entity.Property(e => e.Overlay3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("overlay3");
            entity.Property(e => e.Overlay4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("overlay4");
            entity.Property(e => e.Pgsv).HasColumnName("pgsv");
            entity.Property(e => e.Pgsvoverlay)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("pgsvoverlay");
            entity.Property(e => e.Plrstaydeath).HasColumnName("plrstaydeath");
            entity.Property(e => e.Rcblue).HasColumnName("rcblue");
            entity.Property(e => e.Rcred).HasColumnName("rcred");
            entity.Property(e => e.Remfunc).HasColumnName("remfunc");
            entity.Property(e => e.Remhit).HasColumnName("remhit");
            entity.Property(e => e.Removerlay)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("removerlay");
            entity.Property(e => e.Restrict).HasColumnName("restrict");
            entity.Property(e => e.Rfblue).HasColumnName("rfblue");
            entity.Property(e => e.Rfred).HasColumnName("rfred");
            entity.Property(e => e.Rlblue).HasColumnName("rlblue");
            entity.Property(e => e.Rlred).HasColumnName("rlred");
            entity.Property(e => e.Rpblue).HasColumnName("rpblue");
            entity.Property(e => e.Rpred).HasColumnName("rpred");
            entity.Property(e => e.Setfunc).HasColumnName("setfunc");
            entity.Property(e => e.Shatter).HasColumnName("shatter");
            entity.Property(e => e.Skill)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("skill");
            entity.Property(e => e.Srvactivefunc).HasColumnName("srvactivefunc");
            entity.Property(e => e.Stambarblue).HasColumnName("stambarblue");
            entity.Property(e => e.Stat)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("stat");
            entity.Property(e => e.State1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("state");
            entity.Property(e => e.SunderResReduce).HasColumnName("sunder-res-reduce");
            entity.Property(e => e.Sunderfull).HasColumnName("sunderfull");
            entity.Property(e => e.Transform).HasColumnName("transform");
            entity.Property(e => e.Udead).HasColumnName("udead");
        });

        modelBuilder.Entity<Storepage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("storepage");

            entity.Property(e => e.Code).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.StorePage1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Store_Page");
        });

        modelBuilder.Entity<Superunique>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("superuniques");

            entity.Property(e => e.Class).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Eol)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("eol");
            entity.Property(e => e.HcIdx).HasColumnName("hcIdx");
            entity.Property(e => e.Mod3).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.MonSound).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Stacks).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Superunique1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Superunique");
            entity.Property(e => e.Tc)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("TC");
            entity.Property(e => e.TcDesecrated)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("TC_Desecrated");
            entity.Property(e => e.TcH)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("TC(H)");
            entity.Property(e => e.TcHDesecrated)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("TC(H)_Desecrated");
            entity.Property(e => e.TcN)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("TC(N)");
            entity.Property(e => e.TcNDesecrated)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("TC(N)_Desecrated");
            entity.Property(e => e.UtransH).HasColumnName("Utrans(H)");
            entity.Property(e => e.UtransN).HasColumnName("Utrans(N)");
        });

        modelBuilder.Entity<Treasureclassex>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("treasureclassex");

            entity.Property(e => e.Eol)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("eol");
            entity.Property(e => e.FirstLadderSeason).HasColumnName("firstLadderSeason");
            entity.Property(e => e.Group).HasColumnName("group");
            entity.Property(e => e.Item1).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Item2).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Item3).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Item4).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Item5).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Item6).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Item7).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Item8).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Item9).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.LastLadderSeason).HasColumnName("lastLadderSeason");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.NoAlwaysSpawn).HasColumnName("noAlwaysSpawn");
            entity.Property(e => e.NoDrop).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.TreasureClass)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("Treasure_Class");
            entity.Property(e => e.TreasureClassDropChance).HasColumnType("float");
        });

        modelBuilder.Entity<Uniqueappellation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("uniqueappellation");

            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Uniqueitem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("uniqueitems");

            entity.Property(e => e.Carry1).HasColumnName("carry1");
            entity.Property(e => e.Chrtransform)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("chrtransform");
            entity.Property(e => e.Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("code");
            entity.Property(e => e.CostAdd).HasColumnName("cost_add");
            entity.Property(e => e.CostMult).HasColumnName("cost_mult");
            entity.Property(e => e.Diablocloneweight).HasColumnName("diablocloneweight");
            entity.Property(e => e.Dropsfxframe).HasColumnName("dropsfxframe");
            entity.Property(e => e.Dropsound)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dropsound");
            entity.Property(e => e.Enabled).HasColumnName("enabled");
            entity.Property(e => e.Eol)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("eol");
            entity.Property(e => e.FirstLadderSeason).HasColumnName("firstLadderSeason");
            entity.Property(e => e.Flippyfile)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("flippyfile");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Index)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("index");
            entity.Property(e => e.Invfile)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("invfile");
            entity.Property(e => e.Invtransform)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("invtransform");
            entity.Property(e => e.ItemName).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.LastLadderSeason).HasColumnName("lastLadderSeason");
            entity.Property(e => e.Lvl).HasColumnName("lvl");
            entity.Property(e => e.LvlReq).HasColumnName("lvl_req");
            entity.Property(e => e.Max1).HasColumnName("max1");
            entity.Property(e => e.Max10).HasColumnName("max10");
            entity.Property(e => e.Max11).HasColumnName("max11");
            entity.Property(e => e.Max12).HasColumnName("max12");
            entity.Property(e => e.Max2).HasColumnName("max2");
            entity.Property(e => e.Max3).HasColumnName("max3");
            entity.Property(e => e.Max4).HasColumnName("max4");
            entity.Property(e => e.Max5).HasColumnName("max5");
            entity.Property(e => e.Max6).HasColumnName("max6");
            entity.Property(e => e.Max7).HasColumnName("max7");
            entity.Property(e => e.Max8).HasColumnName("max8");
            entity.Property(e => e.Max9).HasColumnName("max9");
            entity.Property(e => e.Min1).HasColumnName("min1");
            entity.Property(e => e.Min10).HasColumnName("min10");
            entity.Property(e => e.Min11).HasColumnName("min11");
            entity.Property(e => e.Min12).HasColumnName("min12");
            entity.Property(e => e.Min2).HasColumnName("min2");
            entity.Property(e => e.Min3).HasColumnName("min3");
            entity.Property(e => e.Min4).HasColumnName("min4");
            entity.Property(e => e.Min5).HasColumnName("min5");
            entity.Property(e => e.Min6).HasColumnName("min6");
            entity.Property(e => e.Min7).HasColumnName("min7");
            entity.Property(e => e.Min8).HasColumnName("min8");
            entity.Property(e => e.Min9).HasColumnName("min9");
            entity.Property(e => e.Nolimit).HasColumnName("nolimit");
            entity.Property(e => e.Par1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par1");
            entity.Property(e => e.Par10)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par10");
            entity.Property(e => e.Par11)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par11");
            entity.Property(e => e.Par12)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par12");
            entity.Property(e => e.Par2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par2");
            entity.Property(e => e.Par3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par3");
            entity.Property(e => e.Par4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par4");
            entity.Property(e => e.Par5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par5");
            entity.Property(e => e.Par6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par6");
            entity.Property(e => e.Par7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par7");
            entity.Property(e => e.Par8)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par8");
            entity.Property(e => e.Par9)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("par9");
            entity.Property(e => e.Prop1)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop1");
            entity.Property(e => e.Prop10)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop10");
            entity.Property(e => e.Prop11)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop11");
            entity.Property(e => e.Prop12)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop12");
            entity.Property(e => e.Prop2)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop2");
            entity.Property(e => e.Prop3)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop3");
            entity.Property(e => e.Prop4)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop4");
            entity.Property(e => e.Prop5)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop5");
            entity.Property(e => e.Prop6)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop6");
            entity.Property(e => e.Prop7)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop7");
            entity.Property(e => e.Prop8)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop8");
            entity.Property(e => e.Prop9)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("prop9");
            entity.Property(e => e.Rarity).HasColumnName("rarity");
            entity.Property(e => e.Usesound)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("usesound");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        modelBuilder.Entity<Uniqueprefix>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("uniqueprefix");

            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Uniquesuffix>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("uniquesuffix");

            entity.Property(e => e.Name).HasColumnType("MEDIUMTEXT");
        });

        modelBuilder.Entity<Weapon>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("weapons");

            entity.Property(e => e.Alternategfx)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("alternategfx");
            entity.Property(e => e.AutoPrefix).HasColumnName("auto_prefix");
            entity.Property(e => e.Belt)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("belt");
            entity.Property(e => e.Bitfield1).HasColumnName("bitfield1");
            entity.Property(e => e.Code)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("code");
            entity.Property(e => e.Comment)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("comment");
            entity.Property(e => e.Compactsave).HasColumnName("compactsave");
            entity.Property(e => e.Component).HasColumnName("component");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Diablocloneweight).HasColumnName("diablocloneweight");
            entity.Property(e => e.Dropsfxframe).HasColumnName("dropsfxframe");
            entity.Property(e => e.Dropsound)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("dropsound");
            entity.Property(e => e.Durability).HasColumnName("durability");
            entity.Property(e => e.Durwarning).HasColumnName("durwarning");
            entity.Property(e => e.Flippyfile)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("flippyfile");
            entity.Property(e => e.GambleCost).HasColumnName("gamble_cost");
            entity.Property(e => e.Gemapplytype)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("gemapplytype");
            entity.Property(e => e.Gemoffset)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("gemoffset");
            entity.Property(e => e.Gemsockets).HasColumnName("gemsockets");
            entity.Property(e => e.Hasinv).HasColumnName("hasinv");
            entity.Property(e => e.HellUpgrade).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.HitClass)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("hit_class");
            entity.Property(e => e.Invfile)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("invfile");
            entity.Property(e => e.Invheight).HasColumnName("invheight");
            entity.Property(e => e.Invwidth).HasColumnName("invwidth");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Levelreq).HasColumnName("levelreq");
            entity.Property(e => e.Lightradius)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("lightradius");
            entity.Property(e => e.MagicLvl).HasColumnName("magic_lvl");
            entity.Property(e => e.Maxdam).HasColumnName("maxdam");
            entity.Property(e => e.Maxmisdam).HasColumnName("maxmisdam");
            entity.Property(e => e.Maxstack).HasColumnName("maxstack");
            entity.Property(e => e.Mindam).HasColumnName("mindam");
            entity.Property(e => e.Minmisdam).HasColumnName("minmisdam");
            entity.Property(e => e.Minstack).HasColumnName("minstack");
            entity.Property(e => e.Missiletype)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("missiletype");
            entity.Property(e => e.Name)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("name");
            entity.Property(e => e.Namestr)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("namestr");
            entity.Property(e => e.NightmareUpgrade).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Nodurability).HasColumnName("nodurability");
            entity.Property(e => e.Normcode)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("normcode");
            entity.Property(e => e.PermStoreItem).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Qntwarning)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("qntwarning");
            entity.Property(e => e.Quest).HasColumnName("quest");
            entity.Property(e => e.Questdiffcheck).HasColumnName("questdiffcheck");
            entity.Property(e => e.Quivered)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("quivered");
            entity.Property(e => e.Rangeadder).HasColumnName("rangeadder");
            entity.Property(e => e.Rarity).HasColumnName("rarity");
            entity.Property(e => e.Reqdex).HasColumnName("reqdex");
            entity.Property(e => e.Reqstr).HasColumnName("reqstr");
            entity.Property(e => e.Setinvfile)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("setinvfile");
            entity.Property(e => e.ShowLevel).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.SkipName).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Spawnable).HasColumnName("spawnable");
            entity.Property(e => e.Spawnstack).HasColumnName("spawnstack");
            entity.Property(e => e.Speed).HasColumnName("speed");
            entity.Property(e => e.Stackable).HasColumnName("stackable");
            entity.Property(e => e.TmogMax).HasColumnName("TMogMax");
            entity.Property(e => e.TmogMin).HasColumnName("TMogMin");
            entity.Property(e => e.TmogType)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("TMogType");
            entity.Property(e => e.Transmogrify).HasColumnType("MEDIUMTEXT");
            entity.Property(e => e.Transparent)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("transparent");
            entity.Property(e => e.Transtbl).HasColumnName("transtbl");
            entity.Property(e => e.Type)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("type");
            entity.Property(e => e.Type2).HasColumnName("type2");
            entity.Property(e => e.Ubercode)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("ubercode");
            entity.Property(e => e.Ultracode)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("ultracode");
            entity.Property(e => e.Unique)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("unique");
            entity.Property(e => e.Uniqueinvfile)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("uniqueinvfile");
            entity.Property(e => e.Useable)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("useable");
            entity.Property(e => e.Usesound)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("usesound");
            entity.Property(e => e.Version)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("version");
            entity.Property(e => e.Wclass)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("wclass");
            entity.Property(e => e._1or2handed).HasColumnName("1or2handed");
            entity.Property(e => e._2handed).HasColumnName("2handed");
            entity.Property(e => e._2handedwclass)
                .HasColumnType("MEDIUMTEXT")
                .HasColumnName("2handedwclass");
            entity.Property(e => e._2handmaxdam).HasColumnName("2handmaxdam");
            entity.Property(e => e._2handmindam).HasColumnName("2handmindam");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
