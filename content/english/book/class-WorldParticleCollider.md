World Particle Collider (Legacy)
================================


The <span class=keyword>World Particle Collider</span> is used to collide particles against other <span class=keyword>Colliders</span> in the scene.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-ParticleCollider.png)  
_A <span class=keyword>Particle System</span> colliding with a <span class=keyword>Mesh Collider</span>_


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Bounce Factor</span> |Particles can be accelerated or slowed down when they collide against other objects. This factor is similar to the <span class=keyword>Particle Animator's</span> <span class=component>Damping</span> property. |
|<span class=component>Collision Energy Loss</span> |Amount of energy (in seconds) a particle should lose when colliding. If the energy goes below 0, the particle is killed. |
|<span class=component>Min Kill Velocity</span> |If a particle's <span class=component>Velocity</span> drops below <span class=component>Min Kill Velocity</span> because of a collision, it will be eliminated. |
|<span class=component>Collides with</span> |Which [Layers](Layers.md) the particle will collide against. |
|<span class=component>Send Collision Message</span> |If enabled, every particle sends out a collision message that you can catch through scripting. |


Details
-------


To create a Particle System with Particle Collider:
1. Create a Particle System using <span class=menu>GameObject->Create Other->Particle System</span>
1. Add the Particle Collider using <span class=menu>Component->Particles->World Particle Collider</span>


###Messaging

If <span class=component>Send Collision Message</span> is enabled, any particles that are in a collision will send the message <span class=component>OnParticleCollision()</span> to  both the particle's <span class=keyword>GameObject</span> and the GameObject the particle collided with.


Hints
-----


* <span class=component>Send Collision Message</span> can be used to simulate bullets and apply damage on impact.
* Particle Collision Detection is slow when used with a lot of particles. Use Particle Collision Detection wisely.
* Message sending introduces a large overhead and shouldn't be used for normal Particle Systems.
