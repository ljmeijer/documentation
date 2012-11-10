Rendering with Replaced Shaders
===============================


Some rendering effects require rendering a scene with a different set of shaders. For example, good edge detection would need a texture with scene normals, so it could detect edges where surface orientations differ. Other effects might need a texture with scene depth, and so on. To achieve this, it is possible to render the scene with replaced shaders of all objects.

Shader replacement is done from scripting using [Camera.RenderWithShader](ScriptRef:Camera.RenderWithShader.html) or [Camera.SetReplacementShader](ScriptRef:Camera.SetReplacementShader.html) functions. Both functions take a <span class=component>shader</span> and a <span class=component>replacementTag</span>.

It works like this: the camera renders the scene as it normally would. the objects still use their materials, but the actual shader that ends up being used is changed:
* If <span class=component>replacementTag</span> is empty, then all objects in the scene are rendered with the given replacement shader.
* If <span class=component>replacementTag</span> is not empty, then for each object that would be rendered:
    * The real object's shader is queried for the [tag value](SL-SubshaderTags.md).
    * If it does not have that tag, object is __not rendered__.
    * A [subshader](SL-SubShader.md) is found in the replacement shader that has a given tag with the found value. If no such subshader is found, object is __not rendered__.
    * Now that subshader is used to render the object.


So if all shaders would have, for example, a "RenderType" tag with values like "Opaque", "Transparent", "Background", "Overlay", you could write a replacement shader that only renders solid objects by using one subshader with RenderType=Solid [tag](SL-SubshaderTags.md). The other tag types would not be found in the replacement shader, so the objects would be not rendered. Or you could write several subshaders for different "RenderType" tag values. Incidentally, all built-in Unity shaders have a "RenderType" tag set.

Shader replacement tags in built-in Unity shaders
-------------------------------------------------


All built-in Unity shaders have a "<span class=keyword>RenderType</span>" tag set that can be used when rendering with replaced shaders. Tag values are the following:
* <span class=component>Opaque</span>: most of the shaders ([Normal](shader-NormalFamily.md), [Self Illuminated](shader-SelfIllumFamily.md), [Reflective](shader-ReflectiveFamily.md), terrain shaders).
* <span class=component>Transparent</span>: most semitransparent shaders ([Transparent](shader-TransparentFamily.md), Particle, Font, terrain additive pass shaders).
* <span class=component>TransparentCutout</span>: masked transparency shaders ([Transparent Cutout](shader-TransparentCutoutFamily.md), two pass vegetation shaders).
* <span class=component>Background</span>: Skybox shaders.
* <span class=component>Overlay</span>: GUITexture, Halo, Flare shaders.
* <span class=component>TreeOpaque</span>: terrain engine tree bark.
* <span class=component>TreeTransparentCutout</span>: terrain engine tree leaves.
* <span class=component>TreeBillboard</span>: terrain engine billboarded trees.
* <span class=component>Grass</span>: terrain engine grass.
* <span class=component>GrassBillboard</span>: terrain engine billboarded grass.


Built-in scene depth/normals texture
------------------------------------


A Camera has a built-in capability to render depth or depth+normals texture, if you need that in some of your effects. See [Camera Depth Texture](SL-CameraDepthTexture.md) page. Note that in some cases (depending on the hardware), the depth and depth+normals textures can internally be rendered using shader replacement. So it is important to have the correct "<span class=keyword>RenderType</span>" tag in your shaders.


