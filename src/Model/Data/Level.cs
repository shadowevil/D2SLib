using System;
using System.Collections.Generic;

namespace D2SLib.Model.Data;

public partial class Level
{
    public string? Name { get; set; }

    public string? StringName { get; set; }

    public long? Id { get; set; }

    public long? Pal { get; set; }

    public long? Act { get; set; }

    public long? QuestFlag { get; set; }

    public long? QuestFlagEx { get; set; }

    public long? Layer { get; set; }

    public long? SizeX { get; set; }

    public long? SizeY { get; set; }

    public long? SizeXN { get; set; }

    public long? SizeYN { get; set; }

    public long? SizeXH { get; set; }

    public long? SizeYH { get; set; }

    public long? OffsetX { get; set; }

    public long? OffsetY { get; set; }

    public string? Depend { get; set; }

    public long? Teleport { get; set; }

    public string? Rain { get; set; }

    public string? Mud { get; set; }

    public string? NoPer { get; set; }

    public long? Losdraw { get; set; }

    public long? FloorFilter { get; set; }

    public long? BlankScreen { get; set; }

    public string? DrawEdges { get; set; }

    public long? IsInside { get; set; }

    public long? DrlgType { get; set; }

    public long? LevelType { get; set; }

    public long? SubType { get; set; }

    public long? SubTheme { get; set; }

    public long? SubWaypoint { get; set; }

    public long? SubShrine { get; set; }

    public long? Vis0 { get; set; }

    public string? Vis1 { get; set; }

    public string? Vis2 { get; set; }

    public string? Vis3 { get; set; }

    public string? Vis4 { get; set; }

    public string? Vis5 { get; set; }

    public string? Vis6 { get; set; }

    public string? Vis7 { get; set; }

    public long? Warp0 { get; set; }

    public long? Warp1 { get; set; }

    public long? Warp2 { get; set; }

    public long? Warp3 { get; set; }

    public long? Warp4 { get; set; }

    public long? Warp5 { get; set; }

    public long? Warp6 { get; set; }

    public long? Warp7 { get; set; }

    public string? Intensity { get; set; }

    public long? Red { get; set; }

    public long? Green { get; set; }

    public long? Blue { get; set; }

    public string? Portal { get; set; }

    public string? Position { get; set; }

    public long? SaveMonsters { get; set; }

    public string? Quest { get; set; }

    public long? WarpDist { get; set; }

    public long? MonLvl { get; set; }

    public long? MonLvlN { get; set; }

    public long? MonLvlH { get; set; }

    public long? MonLvlEx { get; set; }

    public long? MonLvlExN { get; set; }

    public long? MonLvlExH { get; set; }

    public long? MonDen { get; set; }

    public long? MonDenN { get; set; }

    public long? MonDenH { get; set; }

    public string? MonUmin { get; set; }

    public long? MonUmax { get; set; }

    public long? MonUminN { get; set; }

    public long? MonUmaxN { get; set; }

    public long? MonUminH { get; set; }

    public long? MonUmaxH { get; set; }

    public long? MonWndr { get; set; }

    public string? MonSpcWalk { get; set; }

    public long? NumMon { get; set; }

    public string? Mon1 { get; set; }

    public string? Mon2 { get; set; }

    public string? Mon3 { get; set; }

    public string? Mon4 { get; set; }

    public string? Mon5 { get; set; }

    public string? Mon6 { get; set; }

    public string? Mon7 { get; set; }

    public string? Mon8 { get; set; }

    public long? Mon9 { get; set; }

    public long? Mon10 { get; set; }

    public long? Mon11 { get; set; }

    public long? Mon12 { get; set; }

    public long? Mon13 { get; set; }

    public long? Mon14 { get; set; }

    public long? Mon15 { get; set; }

    public long? Mon16 { get; set; }

    public long? Mon17 { get; set; }

    public long? Mon18 { get; set; }

    public long? Mon19 { get; set; }

    public long? Mon20 { get; set; }

    public long? Mon21 { get; set; }

    public long? Mon22 { get; set; }

    public long? Mon23 { get; set; }

    public long? Mon24 { get; set; }

    public long? Mon25 { get; set; }

    public long? Rangedspawn { get; set; }

    public string? Nmon1 { get; set; }

    public string? Nmon2 { get; set; }

    public string? Nmon3 { get; set; }

    public string? Nmon4 { get; set; }

    public string? Nmon5 { get; set; }

    public string? Nmon6 { get; set; }

    public string? Nmon7 { get; set; }

    public string? Nmon8 { get; set; }

    public string? Nmon9 { get; set; }

    public string? Nmon10 { get; set; }

    public long? Nmon11 { get; set; }

    public long? Nmon12 { get; set; }

    public long? Nmon13 { get; set; }

    public long? Nmon14 { get; set; }

    public long? Nmon15 { get; set; }

    public long? Nmon16 { get; set; }

    public long? Nmon17 { get; set; }

    public long? Nmon18 { get; set; }

    public long? Nmon19 { get; set; }

    public long? Nmon20 { get; set; }

    public long? Nmon21 { get; set; }

    public long? Nmon22 { get; set; }

    public long? Nmon23 { get; set; }

    public long? Nmon24 { get; set; }

    public long? Nmon25 { get; set; }

    public string? Umon1 { get; set; }

    public string? Umon2 { get; set; }

    public string? Umon3 { get; set; }

    public string? Umon4 { get; set; }

    public string? Umon5 { get; set; }

    public string? Umon6 { get; set; }

    public string? Umon7 { get; set; }

    public string? Umon8 { get; set; }

    public long? Umon9 { get; set; }

    public long? Umon10 { get; set; }

    public long? Umon11 { get; set; }

    public long? Umon12 { get; set; }

    public long? Umon13 { get; set; }

    public long? Umon14 { get; set; }

    public long? Umon15 { get; set; }

    public long? Umon16 { get; set; }

    public long? Umon17 { get; set; }

    public long? Umon18 { get; set; }

    public long? Umon19 { get; set; }

    public long? Umon20 { get; set; }

    public long? Umon21 { get; set; }

    public long? Umon22 { get; set; }

    public long? Umon23 { get; set; }

    public long? Umon24 { get; set; }

    public long? Umon25 { get; set; }

    public string? Cmon1 { get; set; }

    public string? Cmon2 { get; set; }

    public string? Cmon3 { get; set; }

    public string? Cmon4 { get; set; }

    public long? Cpct1 { get; set; }

    public long? Cpct2 { get; set; }

    public long? Cpct3 { get; set; }

    public long? Cpct4 { get; set; }

    public long? Camt1 { get; set; }

    public long? Camt2 { get; set; }

    public long? Camt3 { get; set; }

    public long? Camt4 { get; set; }

    public string? Themes { get; set; }

    public long? SoundEnv { get; set; }

    public long? Waypoint { get; set; }

    public string? LevelName { get; set; }

    public string? LevelWarp { get; set; }

    public string? LevelEntry { get; set; }

    public long? ObjGrp0 { get; set; }

    public long? ObjGrp1 { get; set; }

    public long? ObjGrp2 { get; set; }

    public long? ObjGrp3 { get; set; }

    public string? ObjGrp4 { get; set; }

    public string? ObjGrp5 { get; set; }

    public string? ObjGrp6 { get; set; }

    public string? ObjGrp7 { get; set; }

    public long? ObjPrb0 { get; set; }

    public long? ObjPrb1 { get; set; }

    public long? ObjPrb2 { get; set; }

    public long? ObjPrb3 { get; set; }

    public string? ObjPrb4 { get; set; }

    public string? ObjPrb5 { get; set; }

    public string? ObjPrb6 { get; set; }

    public string? ObjPrb7 { get; set; }

    public string? LevelGroup { get; set; }
}
