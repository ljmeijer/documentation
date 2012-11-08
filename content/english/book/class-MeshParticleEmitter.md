Mesh Particle Emitter (Legacy)
==============================


The <span class=keyword>Mesh Particle Emitter</span> emits particles around a mesh. Particles are spawned from the surface of the mesh, which can be necessary when you want to make your particles interact in a complex way with objects.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-MeshPE.png)  
_The Mesh Particle Emitter <span class=keyword>Inspector</span>_


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
(:include comp-ParticleEmitterProps:)

|    |    |
|:---|:---|
|<span class=component>Interpolate Triangles</span> |If enabled, particles are spawned all over the mesh's surface. If disabled, particles are only spawned from the mesh's vertrices. |
|<span class=component>Systematic</span> |If enabled, particles are spawned in the order of the vertices defined in the mesh. Although you seldom have direct control over vertex order in meshes, most 3D modelling applications have a very systematic setup when using primitives. It is important that the mesh contains no faces in order for this to work. |
|<span class=component>Min Normal Velocity</span> |Minimum amount that particles are thrown away from the mesh. |
|<span class=component>Max Normal Velocity</span> |Maximum amount that particles are thrown away from the mesh. |


Details
-------


Mesh Particle Emitters (MPEs) are used when you want more precise control over the spawn position & directions than the simpler <span class=keyword>Ellipsoid Particle Emitter</span> gives you.  They can be used for making advanced effects.

MPEs work by emitting particles at the vertices of the attached mesh. Therefore, the areas of your mesh that are more dense with polygons will be more dense with particle emission.

(:include comp-ParticleEmitterDetails:)


Interpolate Triangles
---------------------


Enabling your emitter to <span class=component>Interpolate Triangles</span> will allow particles to be spawned between the mesh's vertices.  This option is off by default, so particles will only be spawned at the vertices.


![](http://docwiki.hq.unity3d.com/uploads/Main/MeshPE-InterpolateOff.png)  
_A sphere with <span class=component>Interpolate Triangles</span> off (the default)_

Enabling this option will spawn particles on and in-between vertices, essentially all over the mesh's surface (seen below).


![](http://docwiki.hq.unity3d.com/uploads/Main/MeshPE-InterpolateOn.png)  
_A sphere with <span class=component>Interpolate Triangles</span> on_

It bears repeating that even with <span class=component>Interpolate Triangles</span> enabled, particles will still be denser in areas of your mesh that are more dense with polygons.


Systematic
----------


Enabling <span class=component>Systematic</span> will cause your particles to be spawned in your mesh's vertex order.  The vertex order is set by your 3D modeling application.


![](http://docwiki.hq.unity3d.com/uploads/Main/MeshPE-Systematic.png)  
_An MPE attached to a sphere with <span class=component>Systematic</span> enabled_


Normal Velocity
---------------


<span class=component>Normal Velocity</span> controls the speed at which particles are emitted along the normal from where they are spawned.

For example, create a Mesh Particle System, use a cube mesh as the emitter, enable <span class=component>Interpolate Triangles</span>, and set <span class=component>Normal Velocity Min</span> and <span class=component>Max</span> to 1. You will now see the particles emit from the faces of the cube in a straight line.


See Also
--------

* [How to make a Mesh Particle Emitter](HOWTO-MeshParticleEmitter.md)


Hints
-----


(:include comp-ParticleEmitterHints:)
* MPEs can also be used to make glow from a lot of lamps placed in a scene. Simply make a mesh with one vertex in the center of each lamp, and build an MPE from that with a halo material. Great for evil sci-fi worlds.
