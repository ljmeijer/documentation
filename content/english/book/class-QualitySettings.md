Quality Settings
================


Unity allows you to set the level of graphical quality it will attempt to render. Generally speaking, quality comes at the expense of framerate and so it may be best not to aim for the highest quality on mobile devices or older hardware since it will have a detrimental effect on gameplay. The <span class=keyword>Quality Settings</span> inspector (menu: <span class=menu>Edit->Project Settings->Quality</span>) is split into two main areas. At the top, there is the following matrix:-


![](http://docwiki.hq.unity3d.com/uploads/Main/QualSettingsTop.png)  

Unity lets you assign a name to a given combination of quality options for easy reference. The rows of the matrix let you choose which of the different platforms each quality level will apply to. The Default row at the bottom of the matrix is not a quality level in itself but rather sets the default quality level used for each platform (a green checkbox in a column denotes the level currently chosen for that platform). Unity comes with six quality levels pre-enabled but you can add your own levels using the button below the matrix. You can use the trashcan icon (the rightmost column) to delete an unwanted quality level.

You can click on the name of a quality level to select it for editing, which is done in the panel below the settings matrix:-


![](http://docwiki.hq.unity3d.com/uploads/Main/QualitySettingsBottom.png)  


The quality options you can choose for a quality level are as follows:-

|**_Property:_** |**_Function:_** |
|:---|:---|
|Name|The name that will be used to refer to this quality level|
|<span class=component>Pixel Light Count</span>|The maximum number of pixel lights when Forward Rendering is used.
|<span class=component>Texture Quality</span>|This lets you choose whether to display textures at maximum resolution or at a fraction of this (lower resolution has less processing overhead). The options are __Full Res__, __Half Res__, __Quarter Res__ and __Eighth Res__.
|<span class=component>Anisotropic Textures</span>|This enables if and how anisotropic textures will be used.|
|>>><span class=component>Disabled</span>|Anisotropic textures are not used.|
|>>><span class=component>Per Texture</span>|Anisotropic rendering will be enabled separately for each Texture.|
|>>><span class=component>Forced On</span>|Anisotropic textures are always used.|
|<span class=component>AntiAliasing</span>|This sets the level of antialiasing that will be used. The options are __2x__, __4x__ and __8x__ multi-sampling.|
|<span class=component>Soft Particles</span>|Should soft blending be used for particles?|
|<span class=component>Shadows</span>|This determines which type of shadows should be used|
|>>><span class=component>Hard and Soft Shadows</span>|Both hard and soft shadows will be rendered.|
|>>><span class=component>Hard Shadows Only</span>|Only hard shadows will be rendered.|
|>>><span class=component>Disable Shadows</span>|No shadows will be rendered.|
|<span class=component>Shadow resolution</span>|Shadows can be rendered at several different resolutions: __Low__, __Medium__, __High__ and __Very High__. The higher the resolution, the greater the processing overhead.|
|<span class=component>Shadow Projection</span>|There are two different methods for projecting shadows from a directional light. __Close Fit__ renders higher resolution shadows but they can sometimes wobble slightly if the camera moves. __Stable Fit__ renders lower resolution shadows but they don't wobble with camera movements.|
|<span class=component>Shadow Cascades</span>|The number of shadow cascades can be set to zero, two or four. A higher number of cascades gives better quality but at the expense of processing overhead (see the Directional Shadows page for further details).|
|<span class=component>Shadow Distance</span>|The maximum distance from camera at which shadows will be visible. Shadows that fall beyond this distance will not be rendered.|
|<span class=component>Blend Weights</span>|The number of bones that can affect a given vertex during an animation. The available options are one, two or four bones.|
|<span class=component>VSync Count</span>|Rendering can be synchronised with the refresh rate of the display device to avoid "tearing" artifacts (see below). You can choose to synchronise with every vertical blank (VBlank), every second vertical blank or not to synchronise at all.|
|<span class=component>LOD Bias</span>|LOD levels are chosen based on the onscreen size of an object. When the size is between two LOD levels, the choice can be biased toward the less detailed or more detailed of the two models available. This is set as a fraction from 0 to 1 - the closer it is to zero, the more the bias is toward the less detailed model.|
|<span class=component>Maximum LOD Level</span>|The highest LOD that will be used by the game. Models which have a LOD above this level will not be used and omitted from the build (which will save storage and memory space).|

##u40 Details
|<span class=component>Particle Raycast Budget</span>|The maximum number of raycasts to use for approximate particle system collisions (those with <span class=component>Medium</span> or <span class=component>Low</span> quality). See [Particle System Collision Module](ParticleSystemModules40.md).|

Tearing
-------


The picture on the display device is not continuously updated but rather the updates happen at regular intervals much like frame updates in Unity. However, Unity's updates are not necessarily synchronised with those of the display, so it is possible for Unity to issue a new frame while the display is still rendering the previous one. This will result in a visual artifact called "tearing" at the position onscreen where the frame change occurs.


![](http://docwiki.hq.unity3d.com/uploads/Main/Tearing.png)  
_Simulated example of tearing. The shift in the picture is clearly visible in the magnified portion._

It is possible to set Unity to switch frames only during the period where the display device is not updating, the so-called "vertical blank". The VSync option on the Quality Settings synchronises frame switches with the device's vertical blank or optionally with every other vertical blank. The latter may be useful if the game requires more than one device update to complete the rendering of a frame.

<a id="fsaa"></a>
###Anti-aliasing

Anti aliasing improves the appearance of polygon edges, so they are not "jagged", but smoothed out on the screen. However, it incurs a performance cost for the graphics card and uses more video memory (there's no cost on the CPU though). The level of anti-aliasing determines how smooth polygon edges are (and how much video memory does it consume).


![](http://docwiki.hq.unity3d.com/uploads/Main/AntiAliasingNone.png)  
_Without anti-aliasing, polygon edges are "jagged"._


![](http://docwiki.hq.unity3d.com/uploads/Main/AntiAliasing6x.png)  
_With 6x anti-aliasing, polygon edges are smoothed out._


<a id="softparticles"></a>
###Soft Particles

Soft Particles fade out near intersections with other scene geometry. This looks much nicer, however it's more expensive to compute (more complex pixel shaders), and only works on platforms that support [depth textures](SL-DepthTextures.md). Furthermore, you have to use [Deferred Lighting](RenderTech-DeferredLighting.md) rendering path, or make the camera render [depth textures](SL-CameraDepthTexture.md) from scripts.


![](http://docwiki.hq.unity3d.com/uploads/Main/SoftParticlesOff.png)  
_Without Soft Particles - visible intersections with the scene._



![](http://docwiki.hq.unity3d.com/uploads/Main/SoftParticlesOn.png)  
_With Soft Particles - intersections fade out smoothly._
