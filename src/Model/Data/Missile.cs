using System;
using System.Collections.Generic;

namespace D2SLib.Model.Data;

public partial class Missile
{
    public string? Missile1 { get; set; }

    public long? Id { get; set; }

    public long? PCltDoFunc { get; set; }

    public long? PCltHitFunc { get; set; }

    public long? PSrvDoFunc { get; set; }

    public long? PSrvHitFunc { get; set; }

    public long? PSrvDmgFunc { get; set; }

    public string? SrvCalc1 { get; set; }

    public string? SrvCalc1Desc { get; set; }

    public long? Param1 { get; set; }

    public string? Param1Desc { get; set; }

    public long? Param2 { get; set; }

    public string? Param2Desc { get; set; }

    public long? Param3 { get; set; }

    public string? Param3Desc { get; set; }

    public long? Param4 { get; set; }

    public string? Param4Desc { get; set; }

    public long? Param5 { get; set; }

    public string? Param5Desc { get; set; }

    public string? CltCalc1 { get; set; }

    public string? ClientCalc1Desc { get; set; }

    public long? CltParam1 { get; set; }

    public string? ClientParam1Desc { get; set; }

    public long? CltParam2 { get; set; }

    public string? ClientParam2Desc { get; set; }

    public long? CltParam3 { get; set; }

    public string? ClientParam3Desc { get; set; }

    public long? CltParam4 { get; set; }

    public string? ClientParam4Desc { get; set; }

    public long? CltParam5 { get; set; }

    public string? ClientParam5Desc { get; set; }

    public long? ShitCalc1 { get; set; }

    public string? ServerHitCalc1Desc { get; set; }

    public long? SHitPar1 { get; set; }

    public string? ServerHitParam1Desc { get; set; }

    public long? SHitPar2 { get; set; }

    public string? ServerHitParam2Desc { get; set; }

    public long? SHitPar3 { get; set; }

    public string? ServerHitParam3Desc { get; set; }

    public long? ChitCalc1 { get; set; }

    public long? ClientHitCalc1Desc { get; set; }

    public long? CHitPar1 { get; set; }

    public string? ClientHitParam1Desc { get; set; }

    public long? CHitPar2 { get; set; }

    public string? ClientHitParam2Desc { get; set; }

    public long? CHitPar3 { get; set; }

    public string? ClientHitParam3Desc { get; set; }

    public string? DmgCalc1 { get; set; }

    public string? DamageCalc1 { get; set; }

    public long? DParam1 { get; set; }

    public string? DamageParam1Desc { get; set; }

    public long? DParam2 { get; set; }

    public string? DamageParam2Desc { get; set; }

    public long? Vel { get; set; }

    public long? MaxVel { get; set; }

    public long? VelLev { get; set; }

    public long? Accel { get; set; }

    public long? Range { get; set; }

    public long? LevRange { get; set; }

    public long? Light { get; set; }

    public long? Flicker { get; set; }

    public long? Red { get; set; }

    public long? Green { get; set; }

    public long? Blue { get; set; }

    public string? InitSteps { get; set; }

    public string? Activate { get; set; }

    public long? LoopAnim { get; set; }

    public string? CelFile { get; set; }

    public long? Animrate { get; set; }

    public long? AnimLen { get; set; }

    public long? AnimSpeed { get; set; }

    public long? RandStart { get; set; }

    public long? SubLoop { get; set; }

    public long? SubStart { get; set; }

    public long? SubStop { get; set; }

    public long? CollideType { get; set; }

    public long? CollideKill { get; set; }

    public long? CollideFriend { get; set; }

    public long? LastCollide { get; set; }

    public long? Collision { get; set; }

    public long? ClientCol { get; set; }

    public long? ClientSend { get; set; }

    public long? NextHit { get; set; }

    public long? NextDelay { get; set; }

    public long? Xoffset { get; set; }

    public long? Yoffset { get; set; }

    public long? Zoffset { get; set; }

    public long? Size { get; set; }

    public long? SrcTown { get; set; }

    public long? CltSrcTown { get; set; }

    public long? CanDestroy { get; set; }

    public long? ToHit { get; set; }

    public long? AlwaysExplode { get; set; }

    public long? Explosion { get; set; }

    public long? Town { get; set; }

    public long? NoUniqueMod { get; set; }

    public long? NoMultiShot { get; set; }

    public long? Holy { get; set; }

    public long? CanSlow { get; set; }

    public long? ReturnFire { get; set; }

    public long? GetHit { get; set; }

    public long? SoftHit { get; set; }

    public long? KnockBack { get; set; }

    public long? Trans { get; set; }

    public long? Pierce { get; set; }

    public long? MissileSkill { get; set; }

    public string? Skill { get; set; }

    public long? ResultFlags { get; set; }

    public long? HitFlags { get; set; }

    public long? HitShift { get; set; }

    public long? ApplyMastery { get; set; }

    public long? SrcDamage { get; set; }

    public long? Half2Hsrc { get; set; }

    public long? SrcMissDmg { get; set; }

    public long? MinDamage { get; set; }

    public long? MinLevDam1 { get; set; }

    public long? MinLevDam2 { get; set; }

    public long? MinLevDam3 { get; set; }

    public long? MinLevDam4 { get; set; }

    public long? MinLevDam5 { get; set; }

    public long? MaxDamage { get; set; }

    public long? MaxLevDam1 { get; set; }

    public long? MaxLevDam2 { get; set; }

    public long? MaxLevDam3 { get; set; }

    public long? MaxLevDam4 { get; set; }

    public long? MaxLevDam5 { get; set; }

    public long? DmgSymPerCalc { get; set; }

    public string? Etype { get; set; }

    public long? Emin { get; set; }

    public long? MinElev1 { get; set; }

    public long? MinElev2 { get; set; }

    public long? MinElev3 { get; set; }

    public long? MinElev4 { get; set; }

    public long? MinElev5 { get; set; }

    public long? Emax { get; set; }

    public long? MaxElev1 { get; set; }

    public long? MaxElev2 { get; set; }

    public long? MaxElev3 { get; set; }

    public long? MaxElev4 { get; set; }

    public long? MaxElev5 { get; set; }

    public string? EdmgSymPerCalc { get; set; }

    public long? Elen { get; set; }

    public long? ElevLen1 { get; set; }

    public long? ElevLen2 { get; set; }

    public long? ElevLen3 { get; set; }

    public long? HitClass { get; set; }

    public long? NumDirections { get; set; }

    public long? LocalBlood { get; set; }

    public long? DamageRate { get; set; }

    public string? TravelSound { get; set; }

    public string? HitSound { get; set; }

    public string? ProgSound { get; set; }

    public string? ProgOverlay { get; set; }

    public string? ExplosionMissile { get; set; }

    public string? SubMissile1 { get; set; }

    public string? SubMissile2 { get; set; }

    public long? SubMissile3 { get; set; }

    public string? HitSubMissile1 { get; set; }

    public long? HitSubMissile2 { get; set; }

    public long? HitSubMissile3 { get; set; }

    public long? HitSubMissile4 { get; set; }

    public string? CltSubMissile1 { get; set; }

    public string? CltSubMissile2 { get; set; }

    public string? CltSubMissile3 { get; set; }

    public string? CltHitSubMissile1 { get; set; }

    public string? CltHitSubMissile2 { get; set; }

    public string? CltHitSubMissile3 { get; set; }

    public string? CltHitSubMissile4 { get; set; }

    public string? Eol { get; set; }
}
