//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

//--------------------------------------------------------------------------
// Sounds
//--------------------------------------------------------------------------

datablock SFXProfile(LurkerWandFireSound)
{
   filename = "art/sound/weapons/lurkerWand/fire_magic_spell1.ogg";
   description = AudioClose3D;
   preload = true;
};

/*
datablock SFXPlayList(LurkerWandFireSoundList)
{
   // Use a looped description so the list playback will loop.
   description = "AudioClosest3D";
   random = "StrictRandom";
   loopMode = "Single";
   numSlotsToPlay = "1";
   track[0] = "LurkerWandFire1";
   track[1] = "LurkerWandFire2";
   track[2] = "LurkerWandFire3";
   track[2] = "LurkerWandFire4";
   // pitchScaleVariance[0] = "-0.2 0.2";
   // volumeScaleVariance[0] = "-0.3 0";
   // volumeScaleVariance[1] = "-0.3 0";
   // pitchScaleVariance[1] = "-0.1 0.2";
   // volumeScaleVariance[2] = "-0.3 0";
   // pitchScaleVariance[2] = "0 0.2";
   // volumeScaleVariance[3] = "-0.3 0";
   // pitchScaleVariance[3] = "0 0.2";
};

datablock SFXProfile(LurkerWandFire1)
{
   filename = "art/sound/weapons/lurkerWand/fire_magic_spell1.ogg";
   description = AudioClose3D;
   preload = true;
};

datablock SFXProfile(LurkerWandFire2)
{
   filename = "art/sound/weapons/lurkerWand/fire_magic_spell2.ogg";
   description = AudioClose3D;
   preload = true;
};

datablock SFXProfile(LurkerWandFire3)
{
   filename = "art/sound/weapons/lurkerWand/fire_magic_spell3.ogg";
   description = AudioClose3D;
   preload = true;
};

datablock SFXProfile(LurkerWandFire4)
{
   filename = "art/sound/weapons/lurkerWand/fire_magic_spell4.ogg";
   description = AudioClose3D;
   preload = true;
};
*/

/*
datablock SFXProfile(LurkerWandFireStopSound)
{
   filename = "art/sound/weapons/D_32P_01_end.wav";
   description = AudioClose3D;
   preload = true;
};
*/

datablock SFXProfile(LurkerWandReloadSound)
{
   filename = "art/sound/weapons/lurkerWand/magic_reload.ogg";
   description = AudioClosest3D;
   preload = true;
};

/* unused
datablock SFXProfile(LurkerWandIdleSound)
{
   filename = "art/sound/weapons/wpn_lurker_idle";
   description = AudioClose3D;
   preload = true;
};
*/
datablock SFXProfile(LurkerWandSwitchinSound)
{
   filename = "art/sound/weapons/wpn_lurker_switchin";
   description = AudioClosest3D;
   preload = true;
};

datablock SFXProfile(LurkerWandGrenadeFireSound)
{
   filename = "art/sound/weapons/wpn_lurker_grenadelaunch";
   description = AudioClose3D;
   preload = true;
};
/*
datablock SFXPlayList(LurkerWandFireSoundList)
{
   // Use a looped description so the list playback will loop.
   description = AudioClose3D;

   track[ 0 ] = LurkerWandFireSound;
};
*/
datablock SFXProfile(MachineGunDryFire)
{
   filename = "art/sound/weapons/lurkerWand/fire_magic_spell2.ogg";
   description = AudioClosest3D;
   preload = true;
};

datablock SFXProfile(PaintballImpactSound1)
{
   filename = "art/sound/weapons/paintball/paintball_impact_1.wav";
   description = AudioClose3D;
   preload = true;
};

datablock SFXProfile(PaintballImpactSound2)
{
   filename = "art/sound/weapons/paintball/paintball_impact_2.wav";
   description = AudioClose3D;
   preload = true;
};

datablock SFXProfile(PaintballImpactSound3)
{
   filename = "art/sound/weapons/paintball/paintball_impact_3.wav";
   description = AudioClose3D;
   preload = true;
};

datablock SFXPlayList(PaintballImpactSoundList)
{
   description = "AudioClosest3D";
   random = "StrictRandom";
   loopMode = "Single";
   numSlotsToPlay = "1";
   track[0] = "PaintballImpactSound1";
   track[1] = "PaintballImpactSound2";
   track[2] = "PaintballImpactSound3";
   pitchScaleVariance[0] = "-0.2 0.2";
   volumeScaleVariance[0] = "-0.3 0";
   volumeScaleVariance[1] = "-0.3 0";
   pitchScaleVariance[1] = "-0.1 0.2";
   volumeScaleVariance[2] = "-0.3 0";
   pitchScaleVariance[2] = "0 0.2";
};

// ----------------------------------------------------------------------------
// Particles
// ----------------------------------------------------------------------------

datablock ParticleData(LurkerWandSmoke)
{
   textureName          = "art/particles/smoke";
   dragCoefficient      = 0;
   gravityCoefficient   = "-0.8";
   windCoefficient      = 0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = "400";
   lifetimeVarianceMS   = "100";
   spinRandomMin = -180.0;
   spinRandomMax =  180.0;
   useInvAlpha   = true;

   colors[0]     = "0.996078 0.996078 0.996078 0.556";
   colors[1]     = "0.905882 0.905882 0.905882 0.456";
   colors[2]     = "0.8 0.8 0.8 0.307";
   colors[3]     = "0.996078 0.996078 0.996078 0.245";

   sizes[0]      = "0.35";
   sizes[1]      = "0.595129";
   sizes[2]      = "0.9";
   sizes[3]      = "1.2";

   times[0]      = "0.208333";
   times[1]      = "0.395833";
   times[2]      = "0.645833";
   times[3]      = "0.9375";
   animTexName = "art/particles/smoke";
};

datablock ParticleEmitterData(LurkerWandSmokeEmitter)
{
   ejectionPeriodMS = 20;
   periodVarianceMS = 10;
   ejectionVelocity = "0";
   velocityVariance = "0";
   thetaMin         = "0";
   thetaMax         = "0";
   lifetimeMS       = 250;
   particles = "LurkerWandSmoke";
   ambientFactor = "0.5";
   blendStyle = "NORMAL";
   softParticles = "0";
   originalName = "LurkerWandSmokeEmitter";
   alignParticles = "0";
   orientParticles = "0";
};

datablock ParticleData(PaintDustBlue)
{
   textureName          = "art/particles/impactDrops.png";
   dragCoefficient      = "0.957967";
   gravityCoefficient   = "0.197803";
   windCoefficient      = 0;
   inheritedVelFactor   = "0";
   constantAcceleration = "0";
   lifetimeMS           = "200";
   lifetimeVarianceMS   = "100";
   spinRandomMin = -180.0;
   spinRandomMax =  180.0;
   useInvAlpha   = true;

   colors[0]     = "0 0.102362 0.677165 1";
   colors[1]     = "0.102362 0.204724 0.677165 1";
   colors[2]     = "0.141732 0.299213 0.677165 1";

   sizes[0]      = "0.4";
   sizes[1]      = "0.7";
   sizes[2]      = "1.1";

   times[0]      = "0.1";
   times[1]      = "0.494118";
   times[2]      = "1.0";
   animTexName = "art/particles/impactDrops.png";
};

datablock ParticleEmitterData(PaintExplosionBlueEmitter)
{
   ejectionPeriodMS = 20;
   periodVarianceMS = 10;
   ejectionVelocity = "1";
   velocityVariance = 1.0;
   thetaMin         = 0.0;
   thetaMax         = 180.0;
   lifetimeMS       = 250;
   particles = "PaintDustBlue";
   blendStyle = "NORMAL";
   ambientFactor = "0.5";
};

//-----------------------------------------------------------------------------
// Explosion
//-----------------------------------------------------------------------------

datablock ExplosionData(PaintExplosionBlue)
{
   soundProfile = PaintballImpactSoundList;
   lifeTimeMS = 65;

   // Volume particles
   particleEmitter = PaintExplosionBlueEmitter;
   particleDensity = 4;
   particleRadius = 0.3;

   // Point emission
   emitter[0] = BulletDirtSprayEmitter;
   emitter[1] = BulletDirtSprayEmitter;
   emitter[2] = BulletDirtRocksEmitter;
};

//-----------------------------------------------------------------------------
// Projectile Object
//-----------------------------------------------------------------------------

datablock ProjectileData( LurkerWandProjectile )
{
   projectileShapeName = "art/shapes/weapons/paintball/paintball_blue.dts";

   directDamage        = 20;
   radiusDamage        = 0;
   damageRadius        = 0;
   areaImpulse         = 0.5;
   impactForce         = 1;
   damageType          = $DamageType::Rifle;

   //   explosion           = BulletExplosion;
   //   waterExplosion      = BulletWaterExplosion;
   //   playerExplosion     = PlayerBloodExplosion;
   //   decal               = BulletHoleDecal;
   explosion           = PaintExplosionBlue;
   decal               = bluePaintSplatterDecal;

   //particleEmitter     = "BulletTrailEmitter";
   particleWaterEmitter = "UWBulletTrailEmitter";

   Splash              = BulletSplash;
   muzzleVelocity      = 600;
   velInheritFactor    = 0;

   armingDelay         = 0; // How long it should not detonate on impact
   lifetime            = 500; // How long the projectile should exist before deleting itself
   fadeDelay           = 0; // Brief Amount of time, in milliseconds, before the projectile begins to fade out.

   bounceElasticity    = 0;
   bounceFriction      = 0;
   isBallistic         = false;
   bounceElasticity    = 0;
   bounceFriction      = 0;
   gravityMod          = 1;

   lightDesc           = "";
};

//-----------------------------------------------------------------------------
// Ammo Item
//-----------------------------------------------------------------------------

datablock ItemData(LurkerWandClip : DefaultClip)
{
   // Dynamic properties defined by the scripts
   pickUpName = 'Lurker Wand magazine';
};

datablock ItemData(LurkerWandAmmo : DefaultAmmo)
{
   pickUpName = 'Lurker Wand ammo';
   clip = LurkerWandClip;
};

//--------------------------------------------------------------------------
// Weapon Item.  This is the item that exists in the world, i.e. when it's
// been dropped, thrown or is acting as re-spawnable item.  When the weapon
// is mounted onto a shape, the LurkerWandWeaponImage is used.
//-----------------------------------------------------------------------------

datablock ItemData(LurkerWand : DefaultWeapon)
{
   // Basic Item properties
   shapeFile = "art/shapes/weapons/lurkerWand/lurkerWand.dts";

   // Dynamic properties defined by the scripts
   pickUpName = 'Lurker Wand';
   image = LurkerWandWeaponImage;
   reticle = "crossHair";
};

datablock ShapeBaseImageData(LurkerWandWeaponImage)
{
   // Basic Item properties
   shapeFile = "art/shapes/weapons/lurkerWand/lurkerWand.dts";
   shapeFileFP = "art/shapes/weapons/lurkerWand/lurkerWand.dts";

   emap = true;
   computeCRC = false;

   imageAnimPrefix = "Rifle";
   imageAnimPrefixFP = "Rifle";

   // Specify mount point & offset for 3rd person, and eye offset
   // for first person rendering.
   mountPoint = 0; 
   firstPerson = true;
   useEyeNode = true;
   //   eyeOffset = "-0.3 -0.4 -0.4";
   // animateOnServer = true;
   //   cloakable = true;
   
   // When firing from a point offset from the eye, muzzle correction
   // will adjust the muzzle vector to point to the eye LOS point.
   // Since this weapon doesn't actually fire from the muzzle point,
   // we need to turn this off.
   correctMuzzleVector = true;
   correctMuzzleVectorTP = true;

   // Add the WeaponImage namespace as a parent, WeaponImage namespace
   // provides some hooks into the inventory system.
   class = "WeaponImage";
   className = "WeaponImage";

   // Projectiles and Ammo.
   item = LurkerWand;
   ammo = LurkerWandAmmo;
   clip = LurkerWandClip;
   ironSight = LurkerWandIronSightImage;

   projectile = LurkerWandProjectile;
   projectileType = Projectile;
   projectileSpread = "0.02";
   projectileNum = 1;

   // casing = BulletShell;
   // shellExitDir        = "1.0 0.3 1.0";
   // shellExitOffset     = "0.15 -0.56 -0.1";
   // shellExitVariance   = 15.0;
   // shellVelocity       = 3.0;

   lightType = "WeaponFireLight";
   lightColor = "0.992126 0.968504 0.708661 1";
   lightRadius = "3.5";
   lightDuration = "100";
   lightBrightness = 1;

   shakeCamera = true;
   camShakeFreq = "4 4 4";
   camShakeAmp = "3 3 3";
   camShakeDuration = "0.5";
   camShakeRadius = "1.2";

   useRemainderDT = true;

   stateName[0]                     = "Preactivate";
   stateTransitionOnLoaded[0]       = "Activate";
   stateTransitionOnNoAmmo[0]       = "NoAmmo";

   stateName[1]                     = "Activate";
   stateTransitionGeneric0In[1]     = "SprintEnter";
   stateTransitionOnTimeout[1]      = "Ready";
   stateTimeoutValue[1]             = 0.5;
   stateSequence[1]                 = "switch_in";
   stateSound[1]                    = LurkerWandSwitchinSound;

   stateName[2]                     = "Ready";
   stateTransitionGeneric0In[2]     = "SprintEnter";
   stateTransitionOnMotion[2]       = "ReadyMotion";
   stateTransitionOnTimeout[2]      = "ReadyFidget";
   stateTimeoutValue[2]             = 10;
   stateWaitForTimeout[2]           = false;
   stateScaleAnimation[2]           = false;
   stateScaleAnimationFP[2]         = false;
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateTransitionOnTriggerDown[2]  = "Fire";
   stateSequence[2]                 = "idle";

   stateName[3]                     = "ReadyFidget";
   stateTransitionGeneric0In[3]     = "SprintEnter";
   stateTransitionOnMotion[3]       = "ReadyMotion";
   stateTransitionOnTimeout[3]      = "Ready";
   stateTimeoutValue[3]             = 6;
   stateWaitForTimeout[3]           = false;
   stateTransitionOnNoAmmo[3]       = "NoAmmo";
   stateTransitionOnTriggerDown[3]  = "Fire";
   stateSequence[3]                 = "idle_fidget1";

   stateName[4]                     = "ReadyMotion";
   stateTransitionGeneric0In[4]     = "SprintEnter";
   stateTransitionOnNoMotion[4]     = "Ready";
   stateWaitForTimeout[4]           = false;
   stateScaleAnimation[4]           = false;
   stateScaleAnimationFP[4]         = false;
   stateSequenceTransitionIn[4]     = true;
   stateSequenceTransitionOut[4]    = true;
   stateTransitionOnNoAmmo[4]       = "NoAmmo";
   stateTransitionOnTriggerDown[4]  = "Fire";
   stateSequence[4]                 = "run";

   stateName[5]                     = "Fire";
   stateTransitionGeneric0In[5]     = "FireStop";
   stateTransitionOnTimeout[5]      = "NewRound";
   stateTransitionOnTriggerUp[5]    = "FireStop";
   stateTimeoutValue[5]             = 0.11;
   stateFire[5]                     = true;
   stateRecoil[5]                   = "";
   stateAllowImageChange[5]         = false;
   stateSequence[5]                 = "fire";
   stateScaleAnimation[5]           = false;
   stateSequenceNeverTransition[5]  = true;
   stateSequenceRandomFlash[5]      = true;
   stateScript[5]                   = "onFire";
   stateSound[5]                    = LurkerWandFireSound;
   //   stateEmitter[5]                  = GunFireSmokeEmitter;
   stateEmitterTime[5]              = 0.025;
   stateTransitionOnNoAmmo[5]       = "FireStop";
   stateEjectShell[5]               = true;

   stateName[6]                     = "NewRound";
   stateTransitionOnTimeout[6]      = "Fire";
   stateWaitForTimeout[6]           = true;
   stateTimeoutValue[6]             = 0.02;
   stateTransitionGeneric0In[6]     = "FireStop";

   stateName[7]                     = "NoAmmo";
   stateTransitionGeneric0In[7]     = "SprintEnter";
   stateTransitionOnMotion[7]       = "NoAmmoMotion";
   stateTimeoutValue[7]             = 0.1;
   stateSequence[7]                 = "idle";
   stateScaleAnimation[7]           = false;
   stateScaleAnimationFP[7]         = false;
   stateTransitionOnTriggerDown[7]  = "DryFire";
   
   stateName[8]                     = "NoAmmoMotion";
   stateTransitionGeneric0In[8]     = "SprintEnter";
   stateTransitionOnNoMotion[8]     = "NoAmmo";
   stateWaitForTimeout[8]           = false;
   stateScaleAnimation[8]           = false;
   stateScaleAnimationFP[8]         = false;
   stateSequenceTransitionIn[8]     = true;
   stateSequenceTransitionOut[8]    = true;
   stateTransitionOnTriggerDown[8]  = "DryFire";
   stateSequence[8]                 = "run";

   stateName[9]                     = "DryFire";
   stateTransitionGeneric0In[9]     = "SprintEnter";
   stateTransitionOnMotion[9]       = "NoAmmoMotion";
   stateWaitForTimeout[9]           = true;
   stateTimeoutValue[9]             = 0.25;
   stateSequence[9]                 = "idle";
   stateScript[9]                   = "onDryFire";
   stateTransitionOnTimeout[9]      = "NoAmmo";
   stateSound[9]                    = MachineGunDryFire;

   stateName[10]                     = "ReloadClip";
   stateTransitionOnTimeout[10]      = "ReloadFinish";
   stateWaitForTimeout[10]           = true;
   stateScaleAnimation[10]           = false;
   stateScaleAnimationFP[10]         = false;
   stateTimeoutValue[10]             = 3.0;
   stateReload[10]                   = true;
   stateSequence[10]                 = "reload";
   stateShapeSequence[10]            = "Reload";
   stateScaleShapeSequence[10]       = true;
   stateSound[10]                    = LurkerWandReloadSound;
   stateAllowImageChange[10]         = false;  

   stateName[11]                    = "SprintEnter";
   stateTransitionGeneric0Out[11]   = "SprintExit";
   stateTransitionOnTimeout[11]     = "Sprinting";
   stateWaitForTimeout[11]          = false;
   stateTimeoutValue[11]            = 0.5;
   stateWaitForTimeout[11]          = false;
   stateScaleAnimation[11]          = false;
   stateScaleAnimationFP[11]        = false;
   stateSequenceTransitionIn[11]    = true;
   stateSequenceTransitionOut[11]   = true;
   stateAllowImageChange[11]        = false;
   stateSequence[11]                = "sprint";

   stateName[12]                    = "Sprinting";
   stateTransitionGeneric0Out[12]   = "SprintExit";
   stateWaitForTimeout[12]          = false;
   stateScaleAnimation[12]          = false;
   stateScaleAnimationFP[12]        = false;
   stateSequenceTransitionIn[12]    = true;
   stateSequenceTransitionOut[12]   = true;
   stateAllowImageChange[12]        = false;
   stateSequence[12]                = "sprint";
   
   stateName[13]                    = "SprintExit";
   stateTransitionGeneric0In[13]    = "SprintEnter";
   stateTransitionOnTimeout[13]     = "Ready";
   stateWaitForTimeout[13]          = false;
   stateTimeoutValue[13]            = 0.35;
   stateSequenceTransitionIn[13]    = true;
   stateSequenceTransitionOut[13]   = true;
   stateAllowImageChange[13]        = false;
   stateSequence[13]                = "sprint";

   stateName[14]                     = "FireStop";  
   stateScript[14]                   = "onFireStop";  
   stateSound[14]                    = LurkerWandFireStopSound;  
   stateTimeoutValue[14]             = 0.1;  
   stateWaitForTimeout[14]           = true;  
   stateTransitionOnTimeout[14]      = "Ready";    
   stateTransitionOnTriggerDown[14]  = "Fire";  
   stateTransitionOnNoAmmo[14]       = "NoAmmo"; 
   stateTransitionGeneric0In[14]     = "Ready";

   stateName[15]                     = "ReloadFinish";
   stateTimeoutValue[15]             = 0.1;
   stateTransitionOnAmmo[15]         = "Ready";
   stateScript[15]                   = "onReloadFinish";    
};

datablock ShapeBaseImageData( LurkerWandIronSightImage : LurkerWandWeaponImage )
{
   firstPerson = false;
   useEyeNode = false;
   animateOnServer = false;
   useEyeOffset = true;
   //eyeOffset = "-0.147 -0.225 0.025";
   eyeOffset = "-0.161 -0.36 0.060";
   eyeRotation = "0.574892 0.0910342 0.813149 4.72198";

   projectileSpread = "0.007";
   parentImage = "LurkerWandWeaponImage";

   // Called when the weapon is first mounted and there is ammo.
   // We want a smooth transition from datablocks, change Activate params
   stateTimeoutValue[1]             = 0.7;
   stateWaitForTimeout[1]           = true;
   stateSequence[1]                 = "idle";
   stateSound[1]                    = "";
   stateTransitionOnTimeout[1]      = "Ready";
   stateAllowImageChange[1]         = false; 
}; 

//-----------------------------------------------------------------------------
// SMS Inventory

SmsInv.AllowWeapon("Mage");
SmsInv.AddWeapon(LurkerWand, "Lurker Wand", 1);

SmsInv.AllowClip("armor\tMage\t4");
SmsInv.AddClip(LurkerWandClip, "Lurker Wand Clips", 4);

SmsInv.AllowAmmo("armor\tMage\t30");
SmsInv.AddAmmo(LurkerWandAmmo, 30);
