
datablock ItemData(DeerData)
{
   shapeFile = "art/shapes/actors/deer/deer.dts";
   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   gravityMod = 1;
};

datablock ParticleData(DeerParticleData : DefaultParticle)
{
   lifetimeMS = 1000;
   gravityCoefficient = 0;
   dragCoefficient = "2";
 
   sizes[0] = 1;
   sizes[1] = 1;
   sizes[2] = 1;
   sizes[3] = 1;
   inheritedVelFactor = "0";
};

datablock ParticleEmitterData(DeerEmitterData : DefaultEmitter)
{
   particles = DeerParticle;
   ejectionPeriodMS = "10";
   ejectionVelocity = "4.167";
   ejectionOffset = "0.625";
   thetaMax = "180";
   softnessDistance = "1";
   lifetimeMS = "200";
};
 
datablock ParticleEmitterNodeData(DeerEmitterNodeData  : DefaultEmitterNodeData)
{
   timeMultiple = 1.0;
};
