Rendering upgrade details
=========================


Unity 3 brings a lot of graphics related changes, and some things might need to be tweaked when you upgrade existing Unity 2.x projects. For changes related to shaders, see [Shader Upgrade Guide](SL-V3Conversion.md).

Forward Rendering Path changes
------------------------------


Unity 2.x had one rendering path, which is called [Forward](RenderTech-ForwardRendering.md) in Unity 3. Major changes in it compared to Unity 2.x:
* Most common case (one directional per-pixel light) is drawn in one pass now! (used to be two passes)
* Point & Spot light shadows are not supported. Only one Directional light can cast shadows. Use [Deferred Lighting](RenderTech-DeferredLighting.md) path if you need more shadows.
* Most "Vertex" lights replaced with Spherical Harmonics lighting.
* Forward rendering path is purely shader based now, so it works on OpenGL ES 2.0, Xbox 360, PS3 (i.e. platforms that don't support fixed function rendering).


Shader changes
--------------


See [Shader Upgrade Guide](SL-V3Conversion.md) for more details. Largest change is: if you want to write shaders that interact with lighting, you should use [Surface Shaders](SL-SurfaceShaders.md).


Obscure Graphics Changes That No One Will Probably Notice '^TM^'
----------------------------------------------------------------


* Removed Mac Radeon 9200 pixel shader support (`!!ATIfs` assembly shaders).
* Removed support for per-pixel lighting on pre-ShaderModel2.0 hardware. As a result, Diffuse Fast shader is just VertexLit now.
* Removed non-attenuated lights. All point and spot lights are attenuated now.
* Removed script callbacks: `OnPreCullObject` and `RenderBeforeQueues` attribute.
* Removed p-buffer based RenderTextures. RenderTextures on OpenGL require FBO support now.
* Most [Pass LightMode tags](SL-PassTags.md) are gone, and replaced with new tags. You should generally be using [Surface Shaders](SL-SurfaceShaders.md) for that stuff anyway.
* Texture instanceIDs are not OpenGL texture names anymore. Might affect C++ Plugins that were relying on that; use `texture.GetNativeTextureID()` instead.
* Rename shader keywords SHADOWS_NATIVE to SHADOWS_DEPTH; SHADOWS_PCF4 to SHADOWS_SOFT.
* Removed ambient boost on objects that were affected by more than 8 vertex lights.
* Removed `_ObjectSpaceCameraPos` and `_ObjectSpaceLightPos0` (added `_WorldSpaceCameraPos` and `_WorldSpaceLightPos0`).
* `LightmapMode` tag in shader texture property does nothing now.
* Skybox shaders do not write into depth buffer.
* `GrabPass` (i.e. refractive glass shader) now always grabs texture of the size of the screen.
* `#pragma multi_compile_vertex` and `#pragma multi_compile_fragment` are gone.
* Polygon offset in ShaderLab can't reference variables anymore (like `Offset [_Var1], [_Var2]`).
* Renamed `TRANSFER_EYEDEPTH/OUTPUT_EYEDEPTH` to `UNITY_TRANSFER_DEPTH/UNITY_OUTPUT_DEPTH`. They also work on a float2 in Unity 3.
* Removed special shader pass types: R2TPass, OffscreenPass.
* Removed `_Light2World0`, `_World2Light0` built-in shader matrices.
* Removed _SceneAmbient, _MultiModelAmbient, _MultiAmbient, _ModelAmbient, _MultiplyFog, _LightHackedDiffuse0, _ObjectCenterModelLightColor0 built-in shader vectors.
* Removed `_FirstPass` built-in shader float.
* Fog mode in shader files can't come from variable (like `Fog { Mode [_MyFogMode] }`). To use global fog mode, write `Fog { Mode Global }`.
* Removed `BlendColor` color from ShaderLab.
* Removed support for declaring texture matrix by-value in shader property.
* Removed support for "static" shader properties.
* Removed support for texture border color (`RenderTexture.SetBorderColor`).
* Removed `ColorMaterial Ambient, Diffuse, Specular` support (ColorMaterial AmbientAndDiffuse & Emission left). Support for the removed ones varied a lot depending on the platform causing confusion; and they didn't seem to be very useful anyway.
* Built-in `_CameraToWorld` and `_WorldToCamera` matrices now do what you'd expect them to do. Previously they only contained the rotation part, and camera-to-world was flipped on Y axis. Yeah, we don't know how that happened either :)
* Removed `Shader.ClearAll()`. Was deprecated since 2007, time to let it go.
* Vertex shaders are compiled to Shader Model 2.0 now (before was 1.1). If you want to compile to SM1.1, add `#pragma target 1.1` in the shader.

