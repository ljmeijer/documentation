Ellipsoid Particle Emitter (Legacy)
===================================


The <span class=keyword>Ellipsoid Particle Emitter</span> spawns particles inside a sphere. Use the <span class=component>Ellipsoid</span> property below to scale & stretch the sphere.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-EllipsoidEmitter.png)  
_The Ellipsoid Particle Emitter <span class=keyword>Inspector</span>_


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
(:include comp-ParticleEmitterProps:)

|    |    |
|:---|:---|
|<span class=component>Ellipsoid</span> |Scale of the sphere along X, Y, and Z that the particles are spawned inside. |
|<span class=component>MinEmitterRange</span> |Determines an empty area in the center of the sphere - use this to make particles appear on the edge of the sphere. |


Details
-------


Ellipsoid Particle Emitters (EPEs) are the basic emitter, and are included when you choose to add a <span class=keyword>Particle System</span> to your scene from <span class=menu>Components->Particles->Particle System</span>.  You can define the boundaries for the particles to be spawned, and give the particles an initial velocity.  From here, use the [Particle Animator](class-ParticleAnimator.md) to manipulate how your particles will change over time to achieve interesting effects.

(:include comp-ParticleEmitterDetails:)


###Min Emitter Range

The <span class=component>Min Emitter Range</span> determines the depth within the ellipsoid that particles can be spawned.  Setting it to 0 will allow particles to spawn anywhere from the center core of the ellipsoid to the outer-most range.  Setting it to 1 will restrict spawn locations to the outer-most range of the ellipsoid.


![](http://docwiki.hq.unity3d.com/uploads/Main/EmitterRange0.png)  
_<span class=component>Min Emitter Range</span> of 0_


![](http://docwiki.hq.unity3d.com/uploads/Main/EmitterRange1.png)  
_<span class=component>Min Emitter Range</span> of 1_

Hints
-----


(:include comp-ParticleEmitterHints:)
