Particle Animator (Legacy)
==========================


<span class=keyword>Particle Animators</span> move your particles over time, you use them to apply wind, drag & color cycling to your particle systems.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-ParticleAnimator.png)  
_The Particle Animator <span class=keyword>Inspector</span>_


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Does Animate Color</span> |If enabled, particles cycle their color over their lifetime. |
|<span class=component>Color Animation</span> |The 5 colors particles go through. All particles cycle over this - if some have a shorter life span than others, they will animate faster. |
|<span class=component>World Rotation Axis</span> |An optional world-space axis the particles rotate around. Use this to make advanced spell effects or give caustic bubbles some life. |
|<span class=component>Local Rotation Axis</span> |An optional local-space axis the particles rotate around. Use this to make advanced spell effects or give caustic bubbles some life. |
|<span class=component>Size Grow</span> |Use this to make particles grow in size over their lifetime. As randomized forces will spread your particles out, it is often nice to make them grow in size so they don't fall apart. Use this to make smoke rise upwards, to simulate wind, etc. |
|<span class=component>Rnd Force</span> |A random force added to particles every frame. Use this to make smoke become more alive. |
|<span class=component>Force</span> |The force being applied every frame to the particles, measure relative to the world. |
|<span class=component>Damping</span> |How much particles are slowed every frame. A value of 1 gives no damping, while less makes them slow down. |
|<span class=component>Autodestruct</span> |If enabled, the GameObject attached to the Particle Animator will be destroyed when all particles disappear. |

Details
-------


Particle Animators allow your particle systems to be dynamic.  They allow you to change the color of your particles, apply forces and rotation, and choose to destroy them when they are finished emitting.  For more information about Particle Systems, reference [Mesh Particle Emitters](class-MeshParticleEmitter.md), [Ellipsoid Particle Emitters](class-EllipsoidParticleEmitter.md), and [Particle Renderers](class-ParticleRenderer.md).


###Animating Color

If you would like your particles to change colors or fade in/out, enable them to <span class=component>Animate Color</span> and specify the colors for the cycle.  Any particle system that animates color will cycle through the 5 colors you choose.  The speed at which they cycle will be determined by the Emitter's <span class=component>Energy</span> value.

If you want your particles to fade in rather than instantly appear, set your first or last color to have a low Alpha value.


![](http://docwiki.hq.unity3d.com/uploads/Main/ParticleRainbow.png)  
_An <span class=component>Animating Color</span> Particle System_


###Rotation Axes

Setting values in either the Local or World <span class=component>Rotation Axes</span> will cause all spawned particles to rotate around the indicated axis (with the <span class=keyword>Transform's</span> position as the center).  The greater the value is entered on one of these axes, the faster the rotation will be.

Setting values in the Local Axes will cause the rotating particles to adjust their rotation as the Transform's rotation changes, to match its local axes.

Setting values in the World Axes will cause the particles' rotation to be consistent, regardless of the Transform's rotation.


###Forces & Damping

You use force to make particles accelerate in the direction specified by the force.

<span class=component>Damping</span> can be used to decelerate or accelerate without changing their direction:
* A value of 1 means no <span class=component>Damping</span> is applied, the particles will not slow down or accelerate.
* A value of 0 means particles will stop immediately.
* A value of 2 means particles will double their speed every second.


###Destroying GameObjects attached to Particles

You can destroy the Particle System and any attached <span class=keyword>GameObject</span> by enabling the <span class=component>AutoDestruct</span> property.  For example, if you have an oil drum, you can attach a Particle System that has <span class=component>Emit</span> disabled and <span class=component>AutoDestruct</span> enabled.  On collision, you enable the Particle Emitter.  The explosion will occur and after it is over, the Particle System and the oil drum will be destroyed and removed from the scene.

Note that automatic destruction takes effect only after some particles have been emitted. The precise rules for when the object is destroyed when <span class=component>AutoDestruct</span> is on:
* If there have been some particles emitted already, but all of them are dead now, _or_
* If the [emitter](class-EllipsoidParticleEmitter.md) did have <span class=component>Emit</span> on at some point, but now <span class=component>Emit</span> is off.

Hints
-----

* Use the <span class=component>Color Animation</span> to make your particles fade in & out over their lifetime - otherwise, you will get nasty-looking pops.
* Use the <span class=component>Rotation Axes</span> to make whirlpool-like swirly motions.

