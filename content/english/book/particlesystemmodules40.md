Particle System Modules (Shuriken)
==================================


This page is dedicated to individual modules and their properties. For introduction to modules see [this page](ParticleSystemModulesIntro)

Initial Module
--------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenInitialModule.png)  
This module is always present, cannot be removed or disabled.
||PROPS
||<span class=component>Duration</span>           ||The duration the Particle System will be emitting particles.||
||<span class=component>Looping</span>            ||Is the Particle System looping.||
||<span class=component>Prewarm</span>            ||Only looping systems can be prewarmed which means that the Particle System will have emitted particles at start as if it had already emitted particles one cycle. ||
||<span class=component>Start Delay</span>        ||Delay in seconds that this Particle System will wait before emitting particles. Note prewarmed looping systems cannot use a start delay.||
||<span class=component>Start Lifetime</span>           ||The lifetime of particles in seconds (see [MinMaxCurve](ParticleSystemCurveEditor)). ||
||<span class=component>Start Speed</span>              ||The speed of particles when emitted.(see [MinMaxCurve](ParticleSystemCurveEditor)).||
||<span class=component>Start Size</span>               ||The size of particles when emitted. (see [MinMaxCurve](ParticleSystemCurveEditor)).||
||<span class=component>Start Rotation</span>       ||The rotation of particles when emitted. (see [MinMaxCurve](ParticleSystemCurveEditor)).||
||<span class=component>Start Color</span>              ||The color of particles when emitted. (see [MinMaxGradient](ParticleSystemColorEditor)).||
||<span class=component>Gravity Modifier</span>            ||The amount of gravity that will affect particles during their lifetime.||
||<span class=component>Inherit Velocity</span>   ||Factor for controlling the amount of velocity the particles should inherit of the transform of the Particle System (for moving Particle Systems).||
||<span class=component>Simulation Space</span>  ||Simulate the Particle System in local space or world space.||
||<span class=component>Play On Awake</span>      ||If enabled the Particle System will automatically start when it's created.||
||<span class=component>Max Particles</span>      ||Max number of particles the Particle System will emit.||



Emission Module
---------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenEmissionModule.png)  
Controls the rate of particles being emitted and allows spawning large groups of particles at certain moments (over Particle System duration time). Useful for explosions when a bunch of particles need to be created at once.
||PROPS
||<span class=component>Rate</span>               ||Amount of particles emitted over Time (per second) or Distance (per meter). (see [MinMaxCurve](ParticleSystemCurveEditor))||
||<span class=component>Bursts</span> (Time option only)  ||Add bursts of particles that occur within the duration of the Particle System
||>>><span class=component>Time and Number of Particles</span> ||Specify time (in seconds within duration) that a specified amount of particles should be emitted. Use the + and - for adjusting number of bursts.||

Shape Module
------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenShapeModule.png)  
Defines the shape of the emitter: Sphere, Hemishpere, Cone, Box and Mesh. Can apply initial force along the surface normal or random direction.

||PROPS
||<span class=component>Sphere</span>             || ||
||>>><span class=component>Radius</span>          ||Radius of the sphere (can also be manipulated by handles in the Scene View)||
||>>><span class=component>Emit from Shell</span> ||Emit from shell of the sphere. If disabled, particles will be emitted from the volume of the sphere.||
||>>><span class=component>Random Direction</span>||Should particles have have a random direction when emitted or a direction along the surface normal of the sphere||
||<span class=component>Hemisphere</span>         || ||
||>>><span class=component>Radius</span>          ||Radius of the hemisphere (can also be manipulated by handles in the Scene View)||
||>>><span class=component>Emit from Shell</span> ||Emit from shell of the hemisphere. If disabled particles will be emitted from the volume of the hemisphere.||
||>>><span class=component>Random Direction</span>||Should particles have have a random direction when emitted or a direction along the surface normal of the hemisphere.||
||<span class=component>Cone</span>               || ||
||>>><span class=component>Angle</span>           ||Angle of the cone. If angle is 0 then particles will be emitted in one direction. (can also be manipulated by handles in the Scene View)||
||>>><span class=component>Radius</span>          ||A value larger than 0 when basically create a capped cone, using this will change emission from a point to a disc.(can also be manipulated by handles in the Scene View)||
||>>><span class=component>Emit From</span>       ||Determines where emission originates from. Possible values are Base, Base Shell, Volume and Volume Shell.
||<span class=component>Box</span>                || ||
||>>><span class=component>Box X</span>          ||Scale of box in X (can also be manipulated by handles in the Scene View)||
||>>><span class=component>Box Y</span>          ||Scale of box in Y (can also be manipulated by handles in the Scene View)||
||>>><span class=component>Box Z</span>          ||Scale of box in Z (can also be manipulated by handles in the Scene View)||
||>>><span class=component>Random Direction</span>||Should particles have have a random direction when emitted or a direction along the Z-axis of the box||
||<span class=component>Mesh</span>               || ||
||>>><span class=component>Type</span>            ||Particles can be emitted from either Vertex, Edge or Triangle||
||>>><span class=component>Mesh</span>            ||Select Mesh that should be used as emission shape||
||>>><span class=component>Random Direction</span>||Should particles have have a random direction when emitted or a direction along the surface of the mesh||

Velocity Over Lifetime Module
-----------------------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenVelocityOverLifetimeModule.png)  
Directly animates velocity of the particle. Mostly useful for particles which has complex physical, but simple visual behavior (like smoke with turbulence and temperature loss) and has little interaction with physical world.
||PROPS
||<span class=component>XYZ</span>               ||Use either constant values for curves or random between curves for controlling the movement of the particles. See [MinMaxCurve](ParticleSystemCurveEditor).||
||<span class=component>Space</span>       ||Local / World: Are the velocity values in local space or world space ||


Limit Velocity Over Lifetime Module
-----------------------------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenLimitVelocityOverLifetimeModule.png)  
Basically can be used to simulate drag. Dampens or clamps velocity, if it is over certain threshold. Can be configured per axis or per vector length.
||PROPS
||<span class=component>Separate Axis</span>         ||Use for setting per axis control.||
||>>><span class=component>Speed</span>          ||Specify magnitude as constant or by curve that will limit all axes of velocity.||
||>>><span class=component>XYZ</span>  ||Control each axis seperately. See [MinMaxCurve](ParticleSystemCurveEditor).||
||<span class=component>Dampen</span>                ||(0-1) value that controls how much the exceeding velocity should be dampened. For example, a value of 0.5 will dampen exceeding velocity by 50%||


Force Over Lifetime Module
--------------------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenForceOverLifetimeModule.png)  
||PROPS
||<span class=component>XYZ</span>               ||Use either constant values for curves or random between curves for controlling the force applied to the particles. See [MinMaxCurve](ParticleSystemCurveEditor).||
||<span class=component>Randomize</span>       ||Randomize the force applied to the particles every frame ||

Color Over Lifetime Module
--------------------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenColorOverLifetimeModule.png)  
||PROPS
||<span class=component>Color</span>         ||Controls the color of each particle during its lifetime. If some particles have a shorter lifetime than others, they will animate faster. Use constant color, random between two colors, animate it using gradient or specify a random color using two gradients (see  [Gradient](GradientEditor)). Note that this colour will be _multiplied_ by the value in the <span class=keyword>Start Color</span> property - if the Start Color is black then Color Over Lifetime will not affect the particle.||
||<span class=component>Color Scale</span>   ||Use the color scale for easy adjustment of color or gradient.||

Color By Speed Module
---------------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenColorBySpeedModule.png)  
Animates particle color based on its speed. Remaps speed in the defined range to a color.
||PROPS
||<span class=component>Color</span>         ||Color used for remapping of speed. Use gradients for varying colors. See [MinMaxGradient](ParticleSystemColorEditor).||
||<span class=component>Color Scale</span>   ||Use the color scale for easy adjustment of color or gradient.||
||<span class=component>Speed Range</span>   ||The min and max values for defining the speed range which is used for remapping a speed to a color.||


Size Over Lifetime Module
-------------------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenSizeOverLifetimeModule.png)  
||PROPS
||<span class=component>Size</span>         ||Controls the size of each particle during its lifetime. Use constant size, animate it using a curve or specify a random size using two curves. See [MinMaxCurve](ParticleSystemCurveEditor).||

Size By Speed Module
--------------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenSizeBySpeedModule.png)  
||PROPS
||<span class=component>Size</span>          ||Size used for remapping of speed. Use curves for varying sizes. See [MinMaxCurve](ParticleSystemCurveEditor).||
||<span class=component>Speed Range</span>   ||The min and max values for defining the speed range which is used for remapping a speed to a size.||


Rotation Over Lifetime Module
-----------------------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenRotationOverLifetime.png)  
Specify values in degrees.
||PROPS
||<span class=component>Rotational Speed</span>         ||Controls the rotational speed of each particle during its lifetime. Use constant rotational speed, animate it using a curve or specify a random rotational speed using two curves. See [MinMaxCurve](ParticleSystemCurveEditor).||


Rotation By Speed Module
------------------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenRotationBySpeedModule.png)  
||PROPS
||<span class=component>Rotational Speed</span>          ||Rotational speed used for remapping of a particle's speed. Use curves for varying rotational speeds. See [MinMaxCurve](ParticleSystemCurveEditor).||
||<span class=component>Speed Range</span>       ||The min and max values for defining the speed range which is used for remapping a speed to a rotational speed.||


External Forces Module
----------------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenExtForcesModule.png)  
||PROPS
||<span class=component>Multiplier</span>||Scale factor that determines how much the particles are affected by wind zones (i.e., the wind force vector is multiplied by this value).


Collision Module
----------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenCollisionModule40.png)  
Set up collisions for the particles of this Particle System. World and planar collisions are supported. Planar collision is very efficient for simple collision detection. Planes are set up by referencing an existing transform in the scene or by creating a new empty GameObject for this purpose. Another benefit of planar collision is that particle systems with collision planes can be set up as prefabs. World collision uses raycasts so must be used with care in order to ensure good performance. However, for cases where approximate collisions are acceptable world collision in <span class=component>Low</span> or <span class=component>Medium</span> quality can be very efficient.

###Properties common for any Collision Module
||PROPS
||<span class=component>Planes/World</span>          ||Specify the collision type: <span class=component>Planes</span> for planar collision or <span class=component>World</span> for world collisions.||
||<span class=component>Dampen</span>                ||(0-1) When the particle collides, it will keep this fraction of its speed. Unless it is set to 1.0, the particle will become slower after collision.||
||<span class=component>Bounce</span>                ||(0-1) When the particle collides, it will keep this fraction of the component of the velocity, which is normal to the plane of collision.||
||<span class=component>Lifetime Loss</span>         ||(0-1) The fraction of Start Lifetime lost on each collision. When lifetime reaches 0, the particle dies. For example if a particle should die on first collision, set this to 1.0.||
||<span class=component>Min Kill Speed</span>        ||The minimum speed of a particle before it is killed.||

###Properties available only in the <span class=component>Planes</span> Mode
||PROPS
||<span class=component>Planes</span> ||Planes are defined by assigning a reference to a transform. This transform can be any transform in the scene and can be animated. Multiple planes can be used. Note: the Y-axis is used as the normal of a plane.||
||<span class=component>Visualization</span>    ||Only used for visualizing the planes: Grid or Solid.||
||>>><span class=component>Grid</span>           ||Rendered as gizmos and is useful for quick indication of position and orientation in the world.||
||>>><span class=component>Solid</span>          ||Renders a plane in the scene which is useful for exact positioning of a plane.||
||<span class=component>Scale Plane</span>      ||Resizes the visualization planes.||
||<span class=component>Particle Radius</span>  ||The assumed radius of the particle for collision purposes.||


###Properties available only in the <span class=component>World</span> Mode
||PROPS
||<span class=component>Collides With</span>    ||Filter for specifying colliders. Select <span class=component>Everything</span> to colllide with the whole world.||
||<span class=component>Collision Quality</span>||The quality of the world collision.||
||>>><span class=component>_High_</span>           ||All particles performs a scene raycast per frame. Note: This is CPU intensive, it should only be used with 1000 simultaneous particles (scene wide) or less.||
||>>><span class=component>_Medium_</span>         ||The particle system receives a share of the globally set <span class=component>Particle Raycast Budget</span> (see [Particle Raycast Budget](class-QualitySettings)) in each frame. Particles are updated in a round-robin fashion where particles that do not receive a raycast in a given frame will lookup and use older collisions stored in a cache. Note: This collision type is approximate and some particles will leak, particularly at corners.||
||>>><span class=component>Low</span>            ||Same as <span class=component>Medium</span> except the particle system is only awarded a share of the <span class=component>Particle Raycast Budget</span> every fourth frame.||
||<span class=component>Voxel Size</span>         ||Density of the voxels used for caching intersections used in the <span class=component>Medium</span> and <span class=component>Low</span> quality setting. The size of a voxel is given in scene units. Usually, 0.5 - 1.0 should be used (assuming metric units).||


Sub Emitter Module
------------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenSubEmitter.png)  
This is a powerful module that enables spawning of other Particle Systems at the follwing particle events: birth, death or collision of a particle.
||PROPS
||<span class=component>Birth</span>         ||Spawn another Particle System at birth of each particle in this Particle System||
||<span class=component>Death</span>         ||Spawn another Particle System at death of each particle in this Particle System||
||<span class=component>Collision</span>     ||Spawn another Particle System at collision of each particle in this Particle System. IMPORTANT: Collision needs to be set up using the Collision Module. See Collision Module||

Texture Sheet Animation Module
------------------------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenTextureSheetModule.png)  
Animates UV coordinates of the particle over its lifetime. Animation frames can be presented in a form of a grid or every row in the sheet can be separate animation. The frames are animated with curves or can be a random frame between two curves. The speed of the animation is defined by "Cycles".
IMPORTANT: The texture used for animation is the one used by the material found in the Renderer module.
||PROPS
||<span class=component>Tiles</span>             ||Define the tiling of the texture.||
||<span class=component>Animation</span>         ||Specify the animation type: Whole Sheet or Single Row.||
||>>><span class=component>Whole Sheet</span>    ||Uses the whole sheet for uv animation||
||>>><span class=component>- Frame over Time</span>   ||Controls the uv animation frame of each particle during its lifetime over the whole sheet. Use constant, animate it using a curve or specify a random frame using two curves. See [MinMaxCurve](ParticleSystemCurveEditor).||
||>>><span class=component>Single Row</span>     ||Uses a single row of the texture sheet for uv animation||
||>>><span class=component>- Random Row</span>     ||If checked the start row will be random and if unchecked the row index can be specified (first row is 0).||
||>>><span class=component>- Frame over Time</span>   ||Controls the uv animation frame of each particle during its lifetime within the specified row. Use constant, animate it using a curve or specify a random frame using two curves. See [MinMaxCurve](ParticleSystemCurveEditor).||
||>>><span class=component>- Cycles</span>        ||Specify speed of animation.||

<a id="RendererModule"></a>
Renderer Module
---------------

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenRendererModule40.png)  
The renderer module exposes the <span class=component>ParticleSystemRenderer</span> component's properties. Note that even though a GameObject has a <span class=component>ParticleSystemRenderer</span> component, its properties are only exposed here, when this module is removed/added. It is actually the <span class=component>ParticleSystemRenderer</span> component that is added or removed.

||PROPS
||<span class=component>Render Mode</span>             ||Select one of the following particle render modes||
||>>><span class=component>Billboard</span>            ||Makes the particles always face the camera||
||>>><span class=component>Stretched Billboard</span>            ||Particles are stretched using the following parameters||
||>>><span class=component>-  Camera Scale</span>      ||How much the camera speed is factored in when determining particle stretching||
||>>><span class=component>-  Speed Scale</span>       ||Defines the length of the particle compared to its speed||
||>>><span class=component>-  Length Scale</span>      ||Defines the length of the particle compared to its width||
||>>><span class=component>Horizontal Billboard</span> ||Makes the particles align with the Y axis||
||>>><span class=component>Vertical Billboard</span>   ||Makes the particles align with the XZ plane while facing the camera||
||>>><span class=component>Mesh</span>                 ||Particles are rendered using a mesh instead of a quad||
||>>><span class=component>-  Mesh</span>              ||The reference to the mesh used for rendering particles||
||<span class=component>Normal Direction</span>        ||Value from 0 to 1 that determines how much normals point toward the camera (0) and how much sideways toward the centre of the view (1).||
||<span class=component>Material</span>                ||Material used by billboarded or mesh particles.||
||<span class=component>Sort Mode</span>               ||The draw order of particles can be sorted by distance, youngest first, or oldest first.||
||<span class=component>Sorting Fudge</span>           ||Use this to affect the draw order. Particle systems with _lower_ sorting fudge numbers are more likely to be drawn last, and thus appear in front of other transparent objects, including other particles.||
||<span class=component>Cast Shadows</span>            ||Should particles cast shadows? May or may not be possible depending on the material||
||<span class=component>Receive Shadows</span>         ||Should particles receive shadows? May or may not be possible depending on the material||
||<span class=component>Max Particle Size</span>       ||Set max relative viewport size. Valid values: 0-1 ||
