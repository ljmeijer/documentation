Camera's Depth Texture
======================


In Unity a Camera can generate a depth or depth+normals texture. This is a minimalistic G-buffer texture that can be used for post-processing effects or to implement custom lighting models (e.g. light pre-pass). Camera actually builds the depth texture using [Shader Replacement](SL-ShaderReplacement.md) feature, so it's entirely possible to do that yourself, in case you need a different G-buffer setup.

Camera's depth texture can be turned on using [Camera.depthTextureMode](ScriptRef:Camera-depthTextureMode.html) variable from script.

There are two possible depth texture modes:
* <span class=component>DepthTextureMode.Depth</span>: a [depth texture](SL-DepthTextures.md).
* <span class=component>DepthTextureMode.DepthNormals</span>: depth and view space normals packed into one texture.

DepthTextureMode.Depth texture
------------------------------


This builds a screen-sized [depth texture](SL-DepthTextures.md).

DepthTextureMode.DepthNormals texture
-------------------------------------


This builds a screen-sized 32 bit (8 bit/channel) texture, where view space normals are encoded into R&G channels, and depth is encoded in B&A channels. Normals are encoded using Stereographic projection, and depth is 16 bit value packed into two 8 bit channels.

[SL-BuiltinIncludes | `UnityCG.cginc` include file](SL-BuiltinIncludes|`UnityCG.cginc`includefile.md) has a helper function `DecodeDepthNormal` to decode depth and normal from the encoded pixel value. Returned depth is in 0..1 range.

For examples on how to use the depth and normals texture, please refer to the EdgeDetection image effect in the Shader Replacement example project or [SSAO Image Effect](script-SSAOEffect.md).


Tips & Tricks
-------------


When implementing complex shaders or Image Effects, keep [Rendering Differences Between Platforms](SL-PlatformDifferences.md) in mind. In particular, using depth texture in an Image Effect often needs special handling on Direct3D + Anti-Aliasing.

In some cases, the depth texture might come directly from the native Z buffer. If you see artifacts in your depth texture, make sure that the shaders that use it __do not__ write into the Z buffer (use [ZWrite Off](SL-CullAndDepth.md)).


Under the hood
--------------


Depth texture can come directly from the actual depth buffer, or be rendered in a separate pass, depending on the rendering path used and the hardware. When the depth texture is rendered in a separate pass, this is done through [Shader Replacement](SL-ShaderReplacement.md). Hence it is important to have correct "<span class=keyword>RenderType</span>" tag in your shaders.

