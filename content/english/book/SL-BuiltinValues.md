ShaderLab builtin values
========================


Unity provides a handful of builtin values for your shaders: things like current object's transformation matrices, time etc.

You just use them in ShaderLab like you'd use any other property, the only difference is that you don't have to declare it somewhere - they are "built in".

Using them in [programmable shaders](SL-ShaderPrograms.md) requires including [SL-BuiltinIncludes | <span class=keyword>UnityCG.cginc</span> file](SL-BuiltinIncludes|<span class=keyword>UnityCG.cginc</span>file.md).

Transformations
---------------


: <span class=component>float4x4 UNITY_MATRIX_MVP</span> : Current model*view*projection matrix
: <span class=component>float4x4 UNITY_MATRIX_MV</span> : Current model*view matrix
: <span class=component>float4x4 UNITY_MATRIX_P</span> : Current projection matrix
: <span class=component>float4x4 UNITY_MATRIX_T_MV</span> : Transpose of model*view matrix
: <span class=component>float4x4 UNITY_MATRIX_IT_MV</span> : Inverse transpose of model*view matrix
: <span class=component>float4x4 UNITY_MATRIX_TEXTURE0</span> to <span class=component>UNITY_MATRIX_TEXTURE3</span> : Texture transformation matrices
: <span class=component>float4x4 _Object2World</span> : Current model matrix
: <span class=component>float4x4 _World2Object</span> : Inverse of current world matrix
: <span class=component>float3 _WorldSpaceCameraPos</span> : World space position of the camera
: <span class=component>float4 unity_Scale</span> : `xyz` components unused; `.w` contains scale for uniformly scaled objects.

###Lighting

In plain ShaderLab, you access the following properties by appending zero at the end: e.g. the light's model*light color is `_ModelLightColor0`. In Cg shaders, they are exposed as arrays with a single element, so the same in Cg is `_ModelLightColor[0]`.


|    |    |    |
|:---|:---|:---|
| __Name__ | __Type__ | __Value__ |
|_ModelLightColor |float4 |Material's Main * Light color |
|_SpecularLightColor |float4 |Material's Specular * Light color |
|_ObjectSpaceLightPos |float4 |Light's position in object space. _w_ component is 0 for directional lights, 1 for other lights |
|_Light2World |float4x4 |Light to World space matrix |
|_World2Light |float4x4 |World to Light space matrix |
|_Object2Light |float4x4 |Object to Light space matrix |

Various
-------


* <span class=component>float4 _Time</span> : Time (t/20, t, t*2, t*3), use to animate things inside the shaders
* <span class=component>float4 _SinTime</span> : Sine of time: (t/8, t/4, t/2, t)
* <span class=component>float4 _CosTime</span> : Cosine of time: (t/8, t/4, t/2, t)
* <span class=component>float4 _ProjectionParams</span> :
  `x` is 1.0 or -1.0, negative if currently rendering with a flipped projection matrix   
  `y` is camera's near plane   
  `z` is camera's far plane   
  `w` is 1/FarPlane.
* <span class=component>float4 _ScreenParams</span> :
  `x` is current render target width in pixels   
  `y` is current render target height in pixels   
  `z` is 1.0 + 1.0/width   
  `w` is 1.0 + 1.0/height
