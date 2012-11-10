Built-in shader include files
=============================


Unity contains several files that can be used by your [shader programs](SL-ShaderPrograms.md) to bring in predefined variables and helper functions. This is done by the standard `#include` directive, e.g.:

    CGPROGRAM
    // ...
    #include "UnityCG.cginc"
    // ...
    ENDCG

Shader include files in Unity are with `.cginc` extension, and the built-in ones are:
* `HLSLSupport.cginc` - _(automatically included)_ Helper macros and definitions for cross-platform shader compilation.
* `UnityCG.cginc` - commonly used global variables and helper functions.
* `AutoLight.cginc` - lighting & shadowing functionality, e.g. [surface shaders](SL-SurfaceShaders.md) use this file internally.
* `Lighting.cginc` - standard [surface shader](SL-SurfaceShaders.md) lighting models; automatically included when you're writing surface shaders.
* `TerrainEngine.cginc` - helper functions for Terrain & Vegetation shaders.

These files are found inside Unity application (<span class=menu>{unity install path}/Data/CGIncludes/UnityCG.cginc</span> on Windows, <span class=menu>/Applications/Unity/Unity.app/Contents/CGIncludes/UnityCG.cginc</span> on Mac), if you want to take a look at what exactly is done in any of the helper code.


HLSLSupport.cginc
-----------------


This file is _automatically included_ when compiling shaders. It mostly declares various [preprocessor macros](SL-BuiltinMacros.md) to aid in multi-platform shader development.


UnityCG.cginc
-------------


This file is often included in Unity shaders to bring in many helper functions and definitions.

###Data structures in UnityCG.cginc

* struct `appdata_base`: vertex shader input with position, normal, one texture coordinate.
* struct `appdata_tan`: vertex shader input with position, normal, tangent, one texture coordinate.
* struct `appdata_full`: vertex shader input with position, normal, tangent, vertex color and two texture coordinates.
* struct `appdata_img`: vertex shader input with position and one texture coordinate.

###Generic helper functions in UnityCG.cginc

* `float3 WorldSpaceViewDir (float4 v)` - returns world space direction (not normalized) from given object space vertex position towards the camera.
* `float3 ObjSpaceViewDir (float4 v)` - returns object space direction (not normalized) from given object space vertex position towards the camera.
* `float2 ParallaxOffset (half h, half height, half3 viewDir)` - calculates UV offset for parallax normal mapping.
* `fixed Luminance (fixed3 c)` - converts color to luminance (grayscale).
* `fixed3 DecodeLightmap (fixed4 color)` - decodes color from Unity lightmap (RGBM or dLDR depending on platform).
* `float4 EncodeFloatRGBA (float v)` - encodes [0..1) range float into RGBA color, for storage in low precision render target.
* `float DecodeFloatRGBA (float4 enc)` - decodes RGBA color into a float.
* Similarly, `float2 EncodeFloatRG (float v)` and `float DecodeFloatRG (float2 enc)` that use two color channels.
* `float2 EncodeViewNormalStereo (float3 n)` - encodes view space normal into two numbers in 0..1 range.
* `float3 DecodeViewNormalStereo (float4 enc4)` - decodes view space normal from enc4.xy.

###Forward rendering helper functions in UnityCG.cginc

These functions are only useful when using forward rendering (ForwardBase or ForwardAdd pass types).

* `float3 WorldSpaceLightDir (float4 v)` - computes world space direction (not normalized) to light, given object space vertex position.
* `float3 ObjSpaceLightDir (float4 v)` - computes object space direction (not normalized) to light, given object space vertex position.
* `float3 Shade4PointLights (...)` - computes illumination from four point lights, with light data tightly packed into vectors. Forward rendering uses this to compute per-vertex lighting.


###Vertex-lit helper functions in UnityCG.cginc

These functions are only useful when using per-vertex lit shaders ("Vertex" pass type).

* `float3 ShadeVertexLights (float4 vertex, float3 normal)` - computes illumination from four per-vertex lights and ambient, given object space position & normal.
