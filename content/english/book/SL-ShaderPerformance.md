Performance Tips when Writing Shaders
=====================================


Use Common sense ;)
-------------------


Compute only things that you need; anything that is not actually needed can be eliminated. For example, supporting per-material color is nice to make a shader more flexible, but if you always leave that color set to white then it's useless computations performed for each vertex or pixel rendered on screen.

Another thing to keep in mind is frequency of computations. Usually there are many more pixels rendered (hence their pixel shaders executed) than there are vertices (vertex shader executions); and more vertices than objects being rendered. So generally if you can, move computations out of pixel shader into the vertex shader; or out of shaders completely and set the values once from a script.

Less Generic Surface Shaders
----------------------------


[Surface Shaders](SL-SurfaceShaders.md) are great for writing shaders that interact with lighting. However, their default options are tuned for "general case". In many cases, you can tweak them to make shaders run faster or at least be smaller:
* `approxview` directive for shaders that use view direction (i.e. Specular) will make view direction be normalized per-vertex instead of per-pixel. This is approximate, but often good enough.
* `halfasview` for Specular shader types is even faster. Half-vector (halfway between lighting direction and view vector) will be computed and normalized per vertex, and [lighting function](SL-SurfaceShaderLighting.md) will already receive half-vector as a parameter instead of view vector.
* `noforwardadd` will make a shader fully support only one directional light in Forward rendering. The rest of the lights can still have an effect as per-vertex lights or spherical harmonics. This is great to make shader smaller and make sure it always renders in one pass, even with multiple lights present.
* `noambient` will disable ambient lighting and spherical harmonics lights on a shader. This can be slightly faster.


Precision of computations
-------------------------


When writing shaders in Cg/HLSL, there are three basic number types: `float`, `half` and `fixed` (as well as vector & matrix variants of them, e.g. half3 and float4x4):
* `float`: high precision floating point. Generally 32 bits, just like float type in regular programming languages.
* `half`: medium precision floating point. Generally 16 bits, with a range of -60000 to +60000 and 3.3 decimal digits of precision.
* `fixed`: low precision fixed point. Generally 11 bits, with a range of -2.0 to +2.0 and 1/256th precision.

Use lowest precision that is possible; this is especially important on mobile platforms like iOS and Android. Good rules of thumb are:
* For colors and unit length vectors, use `fixed`.
* For others, use `half` if range and precision is fine; otherwise use `float`.

On mobile platforms, the key is to ensure as much as possible stays in low precision in the fragment shader. On most mobile GPUs, applying swizzles to low precision (fixed/lowp) types is costly; converting between fixed/lowp and higher precision types is quite costly as well.


Alpha Testing
-------------


Fixed function [AlphaTest](SL-AlphaTest.md) or it's programmable equivalent, `clip()`, has different performance characteristics on different platforms:
* Generally it's a small advantage to use it to cull out totally transparent pixels on most platforms.
* However, on PowerVR GPUs found in iOS and some Android devices, alpha testing is expensive. Do not try to use it as "performance optimization" there, it will be slower.

Color Mask
----------


On some platforms (mostly mobile GPUs found in iOS and Android devices), using [ColorMask](SL-Pass.md) to leave out some channels (e.g. `ColorMask RGB`) can be expensive, so only use it if really necessary.
