Particle Systems (Legacy, prior to release 3.5)
===============================================


<span class=keyword>Particles</span> are essentially 2D images rendered in 3D space.  They are primarily used for effects such as smoke, fire, water droplets, or leaves.  A <span class=component>Particle System</span> is made up of three separate Components: <span class=component>Particle Emitter</span>, <span class=component>Particle Animator</span>, and a <span class=component>Particle Renderer</span>.  You can use a Particle Emitter and Renderer together if you want static particles.  The Particle Animator will move particles in different directions and change colors.  You also have access to each individual particle in a particle system via scripting, so you can create your own unique behaviors that way if you choose.

Please view the Particle Scripting Reference [here](Path:../ScriptReference/ParticleEmitter.html.md).

(:include class-EllipsoidParticleEmitter:)
(:include class-MeshParticleEmitter:)
(:include class-ParticleAnimator:)
(:include class-WorldParticleCollider:)
(:include class-ParticleRenderer:)
