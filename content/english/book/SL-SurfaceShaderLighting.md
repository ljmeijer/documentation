Custom Lighting models in Surface Shaders
=========================================


When writing [Surface Shaders](SL-SurfaceShaders.md), you're describing properties of a surface (albedo color, normal, ...) and the lighting interaction is computed by a <span class=keyword>Lighting Model</span>. Built-in lighting models are <span class=keyword>Lambert</span> (diffuse lighting) and <span class=keyword>BlinnPhong</span> (specular lighting).

Sometimes you might want to use a custom lighting model, and it is possible to do that in Surface Shaders. Lighting model is nothing more than a couple of Cg/HLSL functions that match some conventions. The built-in `Lambert` and `BlinnPhong` models are defined in `Lighting.cginc` file inside Unity (<span class=menu>{unity install path}/Data/CGIncludes/Lighting.cginc</span> on Windows, <span class=menu>/Applications/Unity/Unity.app/Contents/CGIncludes/Lighting.cginc</span> on Mac).


Lighting Model declaration
--------------------------


Lighting model is a couple of regular functions with names starting with `Lighting`. They can be declared anywhere in your shader file or one of included files. The functions are:
1. `half4 Lighting__Name__ (SurfaceOutput s, half3 lightDir, half atten);`
  This is used in forward rendering path for light models that _are not_ view direction dependent (e.g. diffuse).
1. `half4 Lighting__Name__ (SurfaceOutput s, half3 lightDir, half3 viewDir, half atten);`
  This is used in forward rendering path for light models that are view direction dependent.
1. `half4 Lighting__Name___PrePass (SurfaceOutput s, half4 light);`
  This is used in deferred lighting path.

Note that you don't need to declare all functions. A lighting model either uses view direction or it does not. Similarly, if the lighting model will not work in deferred lighting, you just do not declare `_PrePass` function, and all shaders that use it will compile to forward rendering only.

Decoding directional lightmaps needs to be customized in some circumstances in a similar fashion as the lighting function for forward and deferred lighting. Use one of the functions below depending on whether your light model is view direction dependent or not. Both functions handle forward and deferred lighting rendering paths automatically.

1. `half4 Lighting__Name___DirLightmap (SurfaceOutput s, fixed4 color, fixed4 scale, bool surfFuncWritesNormal);`
  This is used for light models that are not view direction dependent (e.g. diffuse).
1. `half4 Lighting__Name___DirLightmap (SurfaceOutput s, fixed4 color, fixed4 scale, half3 viewDir, bool surfFuncWritesNormal, out half3 specColor);`
  This is used for light models that are view direction dependent.


Examples
--------


__[Surface Shader Lighting Examples](SL-SurfaceShaderLightingExamples.md)__

