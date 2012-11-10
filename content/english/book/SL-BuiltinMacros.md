Predefined shader preprocessor macros
=====================================


When compiling [shader programs](SL-ShaderPrograms.md), Unity defines several preprocessor macros.

Target platform
---------------


* `SHADER_API_OPENGL` - desktop OpenGL
* `SHADER_API_D3D9` - Direct3D 9
* `SHADER_API_XBOX360` - Xbox 360
* `SHADER_API_PS3` - PlayStation 3
* `SHADER_API_D3D11` - desktop Direct3D 11
* `SHADER_API_GLES` - OpenGL ES 2.0 (desktop or mobile), use presence of `SHADER_API_MOBILE` to determine.
* `SHADER_API_FLASH` - Flash Stage3D
* `SHADER_API_D3D11_9X` - Direct3D 11 target for Windows RT

Additionally, `SHADER_TARGET_GLSL` is defined when the target shading language is GLSL (always true when `SHADER_API_GLES` is defined; and can be true for `SHADER_API_OPENGL` when `#pragma glsl` is used).

`SHADER_API_MOBILE` is defined for `SHADER_API_GLES` when compiling for "mobile" platform (iOS/Android); and not defined when compiling for "desktop" (NativeClient).

Platform difference helpers
---------------------------


Direct use of these platform macros is discouraged, since it's not very future proof. For example, if you're writing a shader that checks for D3D9, then maybe in the future the check should be extended to include D3D11. Instead, Unity defines several helper macros (in [[SL-BuiltinIncludes | @@HLSLSupport.cginc@

* `UNITY_ATTEN_CHANNEL` - which channel of light attenuation texture contains the data; used in per-pixel lighting code. Defined to either 'r' or 'a'.
* `UNITY_HALF_TEXEL_OFFSET` - defined on platforms that need a half-texel offset adjustment in mapping texels to pixels (e.g. Direct3D 9).
* `UNITY_UV_STARTS_AT_TOP` - always defined with value or 1 or 0; value of one is on platforms where texture V coordinate is zero at "top of the texture". Direct3D-like platforms use value of 1; OpenGL-like platforms use value of 0.
* `UNITY_MIGHT_NOT_HAVE_DEPTH_TEXTURE` - defined if a platform might emulate shadow maps or depth textures by manually rendering depth into a texture.
* `UNITY_PROJ_COORD(a)` - given a 4-component vector, return a texture coordinate suitable for projected texture reads. On most platforms this returns the given value directly.

###u40 Details
* `UNITY_NEAR_CLIP_VALUE` - defined to the value of near clipping plane; Direct3D-like platforms use 0.0 while OpenGL-like platforms use -1.0.
* `UNITY_COMPILER_CG`, `UNITY_COMPILER_HLSL` or `UNITY_COMPILER_HLSL2GLSL` determine which underlying shader compiler is used; use in case of subtle syntax differences force you to write different shader code.
* `UNITY_CAN_COMPILE_TESSELLATION` - defined when the shader compiler "understands" tessellation shader HLSL syntax (currently only D3D11).
* `UNITY_INITIALIZE_OUTPUT(type,name)` - initialize variable _name_ of given _type_ to zero.


###u40 Details
Constant buffer macros
----------------------


Direct3D 11 groups all shader variables into "constant buffers". Most of Unity's built-in variables are already grouped, but for variables in your own shaders it might be more optimal to put them into separate constant buffers depending on expected frequency of updates.

Use `CBUFFER_START(name)` and `CBUFFER_END` macros for that:
    CBUFFER_START(MyRarelyUpdatedVariables)
    float4 _SomeGlobalValue;
    CBUFFER_END



Surface shader pass indicators
------------------------------


When [Surface Shaders](SL-SurfaceShaders.md) are compiled, they end up generating a lot of code for various passes to do lighting. When compiling each pass, one of the following macros is defined:
* `UNITY_PASS_FORWARDBASE` - forward rendering base pass (main directional light, lightmaps, SH).
* `UNITY_PASS_FORWARDADD` - forward rendering additive pass (one light per pass).
* `UNITY_PASS_PREPASSBASE` - deferred lighting base pass (renders normals & specular exponent).
* `UNITY_PASS_PREPASSFINAL` - deferred lighting final pass (applies lighting & textures).
* `UNITY_PASS_SHADOWCASTER` - shadow caster rendering pass.
* `UNITY_PASS_SHADOWCOLLECTOR` - shadow "gathering" pass for directional light shadows.

