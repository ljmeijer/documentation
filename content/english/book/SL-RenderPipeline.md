Unity's Rendering Pipeline
==========================


Shaders define both how an object looks by itself (its material properties) and how it reacts to the light. Because lighting calculations must be built into the shader, and there are many possible light & shadow types, writing quality shaders that "just work" would  be an involved task. To make it easier, Unity 3 introduces [Surface Shaders](SL-SurfaceShaders.md), where all the lighting, shadowing, lightmapping, forward vs. deferred lighting things are taken care of automatically.

This document describes the pecularities of Unity's lighting & rendering pipeline and what happens behind the scenes of [Surface Shaders](SL-SurfaceShaders.md).


Rendering Paths
---------------


How lighting is applied and which [Passes](SL-Pass.md) of the shader are used depends on which [Rendering Path](RenderingPaths.md) is used. Each pass in a shader communicates its lighting type via [Pass Tags](SL-PassTags.md).
* In [Deferred Lighting](RenderTech-DeferredLighting.md), `PrepassBase` and `PrepassFinal` passes are used.
* In [Forward Rendering](RenderTech-ForwardRendering.md), `ForwardBase` and `ForwardAdd` passes are used.
* In [Vertex Lit](RenderTech-VertexLit.md), `Vertex`, `VertexLMRGBM` and `VertexLM` passes are used.
* In any of the above, to render [Shadows](Shadows.md), `ShadowCaster` and `ShadowCollector` passes are used.


Deferred Lighting path
----------------------


`PrepassBase` pass renders normals & specular exponent; `PrepassFinal` pass renders final color by combining textures, lighting & emissive material properties. All regular in-scene lighting is done separately in screen-space. See [Deferred Lighting](RenderTech-DeferredLighting.md) for details.


Forward Rendering path
----------------------


`ForwardBase` pass renders ambient, lightmaps, main directional light and not important (vertex/SH) lights at once. `ForwardAdd` pass is used for any additive per-pixel lights; one invocation per object illuminated by such light is done. See [Forward Rendering](RenderTech-ForwardRendering.md) for details.

If forward rendering is used, but a shader does not have forward-suitable passes (i.e. neither `ForwardBase` nor `ForwardAdd` pass types are present), then that object is rendered just like it would in Vertex Lit path, see below.


Vertex Lit Rendering path
-------------------------


Since vertex lighting is most often used on platforms that do not support programmable shaders, Unity can't create multiple shader permutations internally to handle lightmapped vs. non-lightmapped cases. So to handle lightmapped and non-lightmapped objects, multiple passes have to be written explicitly. 
* `Vertex` pass is used for non-lightmapped objects. All lights are rendered at once, using a fixed function OpenGL/Direct3D lighting model ([Blinn-Phong](http://en.wikipedia.org/wiki/Blinn-Phong_shading.md))
* `VertexLMRGBM` pass is used for lightmapped objects, when lightmaps are RGBM encoded (this happens on most desktops and consoles). No realtime lighting is applied; pass is expected to combine textures with a lightmap.
* `VertexLMM` pass is used for lightmapped objects, when lightmaps are double-LDR encoded (this happens on mobiles and old desktops). No realtime lighting is applied; pass is expected to combine textures with a lightmap.

