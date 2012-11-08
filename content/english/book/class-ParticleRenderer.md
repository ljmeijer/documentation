Particle Renderer (Legacy)
==========================


The <span class=keyword>Particle Renderer</span> renders the <span class=keyword>Particle System</span> on screen.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-ParticleRenderer.png)  
_The Particle Renderer <span class=keyword>Inspector</span>_


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Materials</span> |Reference to a list of <span class=keyword>Materials</span> that will be displayed in the position of each individual particle. |
|<span class=component>Camera Velocity Scale</span> |The amount of stretching that is applied to the Particles based on [Camera](class-Camera.md) movement. |
|<span class=component>Stretch Particles</span> |Determines how the particles are rendered. |
|>>><span class=component>Billboard</span> |The particles are rendered as if facing the camera. |
|>>><span class=component>Stretched</span> |The particles are facing the direction they are moving. |
|>>><span class=component>SortedBillboard</span> |The particles are sorted by depth. Use this when using a blending material. |
|>>><span class=component>VerticalBillboard</span> |All particles are aligned flat along the X/Z axes. |
|>>><span class=component>HorizontalBillboard</span> |All particles are aligned flat along the X/Y axes. |
|<span class=component>Length Scale</span> |If <span class=component>Stretch Particles</span> is set to <span class=component>Stretched</span>, this value determines how long the particles are in their direction of motion. |
|<span class=component>Velocity Scale</span> |If <span class=component>Stretch Particles</span> is set to <span class=component>Stretched</span>, this value determines the rate at which particles will be stretched, based on their movement speed. |
|<span class=component>UV Animation</span> |If either of these are set, the UV coordinates of the particles will be generated for use with a tile animated texture. See the section on [Animated Textures](#AnimatedTextures) below. |
|>>><span class=component>X Tile</span> |Number of frames located across the X axis. |
|>>><span class=component>Y Tile</span> |Number of frames located across the Y axis. |
|>>><span class=component>Cycles</span> |How many times to loop the animation sequence. |


Details
-------


Particle Renderers are required for any Particle Systems to be displayed on the screen.


![](http://docwiki.hq.unity3d.com/uploads/Main/ParticleRendererExhaust.png)  
_A Particle Renderer makes the Gunship's engine exhaust appear on the screen_


###Choosing a Material

When setting up a Particle Renderer it is very important to use an appropriate material and shader that renders both sides of the material. Most of the time you want to use a Material with one of the built-in Particle Shaders. There are some premade materials in the <span class=menu>Standard Assets->Particles->Sources</span> folder that you can use.

Creating a new material is easy:
1. Select <span class=menu>Assets->Create Other->Material</span> from the menu bar.
1. The [Material](class-Material.md) has a shader popup, choose one of the shaders in the Particles group. Eg. <span class=menu>Particles->Multiply</span>.
1. Now assign a Texture. The different shaders use the alpha channel of the textures slightly differently, but most of the time a value of black will make it invisible and white in the alpha channel will display it on screen.


###Distorting particles

By default particles are rendered billboarded. That is simple square sprites. This is good for smoke and explosions and most other particle effects.

Particles can be made to either stretch with the velocity. This is useful for sparks, lightning or laser beams. <span class=component>Length Scale</span> and <span class=component>Velocity Scale</span> affects how long the stretched particle will be.

<span class=component>Sorted Billboard</span> can be used to make all particles sort by depth. Sometimes this is necessary, mostly when using <span class=menu>Alpha Blended</span> particle shaders. This can be expensive and should only be used if it really makes a quality difference when rendering.


<a id="AnimatedTextures"></a>

###Animated textures

Particle Systems can be rendered with an animated tile texture. To use this feature, make the texture out of a grid of images. As the particles go through their life cycle, they will cycle through the images. This is good for adding more life to your particles, or making small rotating debris pieces.

Hints
-----

* Use Particle Shaders with the Particle Renderer.
