using System;
using System.Collections.Generic;

namespace D2SLib.Model.Data;

public partial class Missile
{
    public string? Missile1 { get; set; }

    public long? Id { get; set; }

    public long? PCltDoFunc { get; set; }

    public string? PCltHitFunc { get; set; }

    public long? PSrvDoFunc { get; set; }

    public string? PSrvHitFunc { get; set; }

    public string? PSrvDmgFunc { get; set; }

    public string? SrvCalc1 { get; set; }

    public string? SrvCalc1Desc { get; set; }

    public string? Param1 { get; set; }

    public string? Param1Desc { get; set; }

    public string? Param2 { get; set; }

    public string? Param2Desc { get; set; }

    public string? Param3 { get; set; }

    public string? Param3Desc { get; set; }

    public string? Param4 { get; set; }

    public string? Param4Desc { get; set; }

    public string? Param5 { get; set; }

    public string? Param5Desc { get; set; }

    public string? CltCalc1 { get; set; }

    public string? ClientCalc1Desc { get; set; }

    public string? CltParam1 { get; set; }

    public string? ClientParam1Desc { get; set; }

    public string? CltParam2 { get; set; }

    public string? ClientParam2Desc { get; set; }

    public string? CltParam3 { get; set; }

    public string? ClientParam3Desc { get; set; }

    public string? CltParam4 { get; set; }

    public string? ClientParam4Desc { get; set; }

    public string? CltParam5 { get; set; }

    public string? ClientParam5Desc { get; set; }

    public string? ShitCalc1 { get; set; }

    public string? ServerHitCalc1Desc { get; set; }

    public string? SHitPar1 { get; set; }

    public string? ServerHitParam1Desc { get; set; }

    public string? SHitPar2 { get; set; }

    public string? ServerHitParam2Desc { get; set; }

    public string? SHitPar3 { get; set; }

    public string? ServerHitParam3Desc { get; set; }

    public string? ChitCalc1 { get; set; }

    public string? ClientHitCalc1Desc { get; set; }

    public string? CHitPar1 { get; set; }

    public string? ClientHitParam1Desc { get; set; }

    public string? CHitPar2 { get; set; }

    public string? ClientHitParam2Desc { get; set; }

    public string? CHitPar3 { get; set; }

    public string? ClientHitParam3Desc { get; set; }

    public string? DmgCalc1 { get; set; }

    public string? DamageCalc1 { get; set; }

    public string? DParam1 { get; set; }

    public string? DamageParam1Desc { get; set; }

    public string? DParam2 { get; set; }

    public string? DamageParam2Desc { get; set; }

    public long? Vel { get; set; }

    public long? MaxVel { get; set; }

    public string? VelLev { get; set; }

    public string? Accel { get; set; }

    public long? Range { get; set; }

    public string? LevRange { get; set; }

    public string? Light { get; set; }

    public string? Flicker { get; set; }

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

    public string? RandStart { get; set; }

    public string? SubLoop { get; set; }

    public string? SubStart { get; set; }

    public string? SubStop { get; set; }

    public long? CollideType { get; set; }

    public string? CollideKill { get; set; }

    public string? CollideFriend { get; set; }

    public long? LastCollide { get; set; }

    public string? Collision { get; set; }

    public string? ClientCol { get; set; }

    public string? ClientSend { get; set; }

    public string? NextHit { get; set; }

    public string? NextDelay { get; set; }

    public string? Xoffset { get; set; }

    public string? Yoffset { get; set; }

    public string? Zoffset { get; set; }

    public long? Size { get; set; }

    public string? SrcTown { get; set; }

    public string? CltSrcTown { get; set; }

    public string? CanDestroy { get; set; }

    public string? ToHit { get; set; }

    public string? AlwaysExplode { get; set; }

    public string? Explosion { get; set; }

    public string? Town { get; set; }

    public string? NoUniqueMod { get; set; }

    public string? NoMultiShot { get; set; }

    public string? Holy { get; set; }

    public long? CanSlow { get; set; }

    public string? ReturnFire { get; set; }

    public string? GetHit { get; set; }

    public string? SoftHit { get; set; }

    public string? KnockBack { get; set; }

    public long? Trans { get; set; }

    public string? Pierce { get; set; }

    public string? MissileSkill { get; set; }

    public string? Skill { get; set; }

    public string? ResultFlags { get; set; }

    public string? HitFlags { get; set; }

    public long? HitShift { get; set; }

    public string? ApplyMastery { get; set; }

    public string? SrcDamage { get; set; }

    public string? Half2Hsrc { get; set; }

    public string? SrcMissDmg { get; set; }

    public string? MinDamage { get; set; }

    public string? MinLevDam1 { get; set; }

    public string? MinLevDam2 { get; set; }

    public string? MinLevDam3 { get; set; }

    public string? MinLevDam4 { get; set; }

    public string? MinLevDam5 { get; set; }

    public string? MaxDamage { get; set; }

    public string? MaxLevDam1 { get; set; }

    public string? MaxLevDam2 { get; set; }

    public string? MaxLevDam3 { get; set; }

    public string? MaxLevDam4 { get; set; }

    public string? MaxLevDam5 { get; set; }

    public string? DmgSymPerCalc { get; set; }

    public string? Etype { get; set; }

    public string? Emin { get; set; }

    public string? MinElev1 { get; set; }

    public string? MinElev2 { get; set; }

    public string? MinElev3 { get; set; }

    public string? MinElev4 { get; set; }

    public string? MinElev5 { get; set; }

    public string? Emax { get; set; }

    public string? MaxElev1 { get; set; }

    public string? MaxElev2 { get; set; }

    public string? MaxElev3 { get; set; }

    public string? MaxElev4 { get; set; }

    public string? MaxElev5 { get; set; }

    public string? EdmgSymPerCalc { get; set; }

    public string? Elen { get; set; }

    public string? ElevLen1 { get; set; }

    public string? ElevLen2 { get; set; }

    public string? ElevLen3 { get; set; }

    public string? HitClass { get; set; }

    public long? NumDirections { get; set; }

    public string? LocalBlood { get; set; }

    public string? DamageRate { get; set; }

    public string? TravelSound { get; set; }

    public string? HitSound { get; set; }

    public string? ProgSound { get; set; }

    public string? ProgOverlay { get; set; }

    public string? ExplosionMissile { get; set; }

    public string? SubMissile1 { get; set; }

    public string? SubMissile2 { get; set; }

    public string? SubMissile3 { get; set; }

    public string? HitSubMissile1 { get; set; }

    public string? HitSubMissile2 { get; set; }

    public string? HitSubMissile3 { get; set; }

    public string? HitSubMissile4 { get; set; }

    public string? CltSubMissile1 { get; set; }

    public string? CltSubMissile2 { get; set; }

    public string? CltSubMissile3 { get; set; }

    public string? CltHitSubMissile1 { get; set; }

    public string? CltHitSubMissile2 { get; set; }

    public string? CltHitSubMissile3 { get; set; }

    public string? CltHitSubMissile4 { get; set; }

    public string? Eol { get; set; }
}
