Graphics Emulation
==================


You can choose to emulate less capable graphics hardware when working in the Unity editor. This is very handy when writing custom shaders and rendering effects, and is a quick way to test how your game will look on that eight year old graphics card that someone might have.

To enable Graphics emulation, go to <span class=menu>Edit->Graphics Emulation</span>, and choose your desired emulation level.

__Note:__ The available graphic emulation options change depending on the platform you are currently targeting. More information can be found on the [Publishing builds page](PublishingBuilds.md).


![](http://docwiki.hq.unity3d.com/uploads/Main/GraphicsEmulationMenu.jpg)  
_Enabling Graphics Emulation_


Technical Details
-----------------


Graphics emulation limits the graphics _capabilities_ that are supported, but it does not emulate the _performance_ of graphics hardware. Your game in the editor will still be rendered by your graphics card, more and more features will be disabled as you reduce emulation quality.

While emulation is a quick way to check out graphics capabilities, you should still test your game on actual hardware. This will reveal real performance and any peculiarities of the specific graphics card, operating system or driver version.

Emulation Levels
----------------


Graphics emulation levels are the following:

###In web player or standalone mode:


|    |    |
|:---|:---|
|<span class=component>No Emulation</span> |No emulation is performed.|
|<span class=component>Shader Model 3</span> |Emulates graphics card with Shader Model 3.0 level capabilities. Long vertex & fragment shader programs, realtime shadows, HDR.|
|<span class=component>Shader Model 2</span> |Shader Model 2.0 capabilities. Vertex & fragment programs, realtime shadows. No HDR, maximum 4 texture combiner stages. |
|<span class=component>Shader Model 1</span> |Shader Model 1.x capabilities. Vertex programs, 4 texture combiner stages. __Not supported__: fragment programs, shadows, HDR, depth textures, multiple render targets. |
|<span class=component>DirectX 7</span> |DirectX 7 level capabilities. Vertex programs (usually in software mode), two texture combiner stages. __Not supported__: fragment programs, shadows, HDR, depth textures, 3D textures, min/max/sub blending. |


###In iOS or Android mode:


|    |    |
|:---|:---|
|<span class=component>No Emulation</span> |No emulation is performed.|
|<span class=component>OpenGL ES 1.x</span> |OpenGL ES 1.1: Four texture combiner stages. __Not supported__: vertex or fragment programs, shadows and pretty much all other graphics features ;) |
|<span class=component>OpenGL ES 2.0</span> |OpenGL ES 2.0: Vertex & fragment programs, four texture combiner stages. __Not supported__: HDR, 3D textures. |

When your graphics card does not support all the capabilities of some emulation level, that level will be disabled. For example, the Intel GMA950 (Intel 915/945/3000) card does not support Shader Model 3.0, so there's no way to emulate that level.

