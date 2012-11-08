Unity 3.x Shader Conversion Guide
=================================


Unity 3 has many new features and changes to its rendering system, and ShaderLab did update accordingly. Some advanced shaders that were used in Unity 2.x, especially the ones that used per-pixel lighting, will need update for Unity 3. If you have trouble updating them - just ask for our help!

For general graphics related Unity 3 upgrade details, see [Rendering Upgrade Details](RenderingUpgradeDetails.md).

When you open your Unity 2.x project in Unity 3.x, it will automatically upgrade your shader files as much as possible. The document below lists all the changes that were made to shaders, and what to do when you need manual shader upgrade.


Per-pixel lit shaders
---------------------


In Unity 2.x, writing shaders that were lit per-pixel was quite complicated. Those shaders would have multiple passes, with <span class=keyword>LightMode</span> tags on each (usually <span class=component>PixelOrNone</span>, <span class=component>Vertex</span> and <span class=component>Pixel</span>). With addition of [Deferred Lighting](RenderTech-DeferredLighting.md) in Unity 3.0 and changes in old forward rendering, we needed an easier, more robust and future proof way of writing shaders that interact with lighting. __All old per-pixel lit shaders need to be rewritten__ to be [Surface Shaders](SL-SurfaceShaders.md).


Cg shader changes
-----------------


###Built-in "glstate" variable renames

In Unity 2.x, accessing some built-in variables (like model*view*projection matrix) was possible through built-in Cg names like `glstate.matrix.mvp`. However, that does not work on some platforms, so in Unity 3.0 we renamed those built-in variables. All these replacements will be done automatically when upgrading your project:

* `glstate.matrix.mvp` to UNITY_MATRIX_MVP
* `glstate.matrix.modelview[0]` to UNITY_MATRIX_MV
* `glstate.matrix.projection` to UNITY_MATRIX_P
* `glstate.matrix.transpose.modelview[0]` to UNITY_MATRIX_T_MV
* `glstate.matrix.invtrans.modelview[0]` to UNITY_MATRIX_IT_MV
* `glstate.matrix.texture[0]` to UNITY_MATRIX_TEXTURE0
* `glstate.matrix.texture[1]` to UNITY_MATRIX_TEXTURE1
* `glstate.matrix.texture[2]` to UNITY_MATRIX_TEXTURE2
* `glstate.matrix.texture[3]` to UNITY_MATRIX_TEXTURE3
* `glstate.lightmodel.ambient` to UNITY_LIGHTMODEL_AMBIENT
* `glstate.matrix.texture` to UNITY_MATRIX_TEXTURE

###Semantics changes

Additionally, it is recommended to use `SV_POSITION` (instead of `POSITION`) semantic for position in vertex-to-fragment structures.

###More strict error checking

Depending on platform, shaders might be compiled using a different compiler than Cg (e.g. HLSL on Windows) that has more strict error checking. Most common cases are:
* All vertex/fragment shader inputs and outputs need to have "semantics" assigned to them. Unity 2.x allowed to not assign any semantics (in which case some TEXCOORD would be used); in Unity 3.0 semantic is required.
* All shader output variables need to be written into. For example, if you have a `float4 color : COLOR` as your vertex shader output, you can't just write into `rgb` and leave alpha uninitialized.


Other Changes
-------------


###RECT textures are gone

In Unity 2.x, [RenderTextures](class-RenderTexture.md) could be not power of two in size, so called "RECT" textures. They were designated by "RECT" texture type in shader properties and used as `samplerRECT`, `texRECT` and so on in Cg shaders. Texture coordinates for RECT textures were a special case in OpenGL: they were in pixels. In all other platforms, texture coordinates were just like for any other texture: they went from 0.0 to 1.0 over the texture.

In Unity 3.0 we have decided to remove this OpenGL special case, and treat non power of two RenderTextures the same everywhere. It is recommended to replace `samplerRECT`, `texRECT` and similar uses with regular `sampler2D` and `tex2D`. Also, if you were doing any special pixel adressing for OpenGL case, you need to remove that from your shader, i.e. just keep the non-OpenGL part (look for `SHADER_API_D3D9` or `SHADER_API_OPENGL` macros in your shaders).



