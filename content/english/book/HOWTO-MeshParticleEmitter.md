How do I make a Mesh Particle Emitter? (Legacy Particle System)
===============================================================


<span class=keyword>Mesh Particle Emitters</span> are generally used when you need high control over where to emit particles.

For example, when you want to create a flaming sword:

1. Drag a mesh into the scene.
1. Remove the <span class=component>Mesh Renderer</span> by right-clicking on the <span class=component>Mesh Renderer's</span> <span class=keyword>Inspector</span> title bar and choose <span class=component>Remove Component</span>.
1. Choose <span class=menu>Mesh Particle Emitter</span> from the <span class=menu>Component->Effects->Legacy Particles</span> menu.
1. Choose <span class=menu>Particle Animator</span> from the <span class=menu>Component->Effects->Legacy Particles</span> menu.
1. Choose <span class=menu>Particle Renderer</span> from the <span class=menu>Component->Effects->Legacy Particles</span> menu.

You should now see particles emitting from the mesh.

Play around with the values in the [Mesh Particle Emitter](class-MeshParticleEmitter.md).

Especially enable <span class=component>Interpolate Triangles</span> in the Mesh Particle Emitter Inspector and set <span class=component>Min Normal Velocity</span> and <span class=component>Max Normal Velocity</span> to 1.

To customize the look of the particles that are emitted:

1. Choose <span class=menu>Assets->Create->Material</span> from the menu bar.
1. In the Material Inspector, select <span class=menu>Particles->Additive</span> from the shader drop-down.
1. Drag & drop a texture from the <span class=keyword>Project view</span> onto the texture slot in the Material Inspector.
1. Drag the Material from the Project View onto the Particle System in the <span class=keyword>Scene View</span>.

You should now see textured particles emitting from the mesh.

See Also
--------

* [Mesh Particle Emitter Component Reference page](class-MeshParticleEmitter.md)
