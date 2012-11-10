Materials and Shaders
=====================


There is a close relationship between <span class=keyword>Materials</span> and <span class=keyword>Shaders</span> in Unity.  Shaders contain code that defines what kind of properties and assets to use.  Materials allow you to adjust properties and assign assets.


![](http://docwiki.hq.unity3d.com/uploads/Main/Shader-NormalBumpSpec.png)  
_A Shader is implemented through a Material_

To create a new Material, use <span class=menu>Assets->Create->Material</span> from the main menu or the <span class=keyword>Project View</span> context menu.  Once the Material has been created, you can apply it to an object and tweak all of its properties in the <span class=keyword>Inspector</span>.  To apply it to an object, just drag it from the <span class=keyword>Project View</span> to any object in the <span class=keyword>Scene</span> or <span class=keyword>Hierarchy</span>.

Setting Material Properties
---------------------------


You can select which Shader you want any particular Material to use.  Simply expand the <span class=menu>Shader</span> drop-down in the Inspector, and choose your new Shader.  The Shader you choose will dictate the available properties to change. The properties can be colors, sliders, textures, numbers, or vectors. If you have applied the Material to an active object in the <span class=keyword>Scene</span>, you will see your property changes applied to the object in real-time.

There are two ways to apply a <span class=keyword>Texture</span> to a property.

1. Drag it from the Project View on top of the Texture square
1. Click the <span class=menu>Select</span> button, and choose the texture from the drop-down list that appears

Two placement options are available for each <span class=keyword>Texture</span>:


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Tiling</span>   |Scales the texture along the different.|
|<span class=component>Offset</span>  |Slides the texture around.|



Built-in Shaders
----------------


There is a library of [built-in Shaders](Built-inShaderGuide.md) that come standard with every installation of Unity.  There are over 30 of these [built-in Shaders](Built-inShaderGuide.md), and six basic families.

* [Normal ](shader-NormalFamily.md): For opaque textured objects.
* [Transparent ](shader-TransparentFamily.md): For partly transparent objects. The texture's alpha channel defines the level of transparency.
* [TransparentCutOut ](shader-TransparentCutoutFamily.md): For objects that have only fully opaque and fully transparent areas, like fences.
* [Self-Illuminated ](shader-SelfIllumFamily.md): For objects that have light emitting parts.
* [Reflective ](shader-ReflectiveFamily.md): For opaque textured objects that reflect an environment <span class=keyword>Cubemap</span>.

In each group, built-in shaders range by complexity, from the simple <span class=component>VertexLit</span> to the complex <span class=component>Parallax Bumped with Specular</span>.  For more information about performance of Shaders, please read the built-in Shader [performance page](shader-Performance.md)

This grid displays a thumbnail of all built-in Shaders:


![](http://docwiki.hq.unity3d.com/uploads/Main/BuiltinShaders.png)  
_The builtin Unity shaders matrix_


Shader technical details
------------------------


Unity has an extensive Shader system, allowing you to tweak the look of all in-game graphics. It works like this:

A Shader basically defines a formula for how the in-game shading should look. Within any given Shader is a number of properties (typically textures). Shaders are implemented through <span class=keyword>Materials</span>, which are attached directly to individual <span class=keyword>GameObjects</span>.  Within a Material, you will choose a Shader, then define the properties (usually textures and colors, but properties can vary) that are used by the Shader.

This is rather complex, so let's look at a workflow diagram:


![](http://docwiki.hq.unity3d.com/uploads/Main/material_diagram.png)  

On the left side of the graph is the <span class=keyword>Carbody Shader</span>. 2 different Materials are created from this: <span class=component>Blue car Material</span> and <span class=component>Red car Material</span>. Each of these Materials have 2 textures assigned; the <span class=component>Car Texture</span> defines the main texture of the car, and a <span class=component>Color FX texture</span>. These properties are used by the shader to make the car finish look like 2-tone paint. This can be seen on the front of the red car: it is yellow where it faces the camera and then fades towards purple as the angle increases. The car materials are attached to the 2 cars. The car wheels, lights and windows don't have the color change effect, and must hence use a different Material. At the bottom of the graph there is a <span class=component>Simple Metal Shader</span>. The <span class=component>Wheel Material</span> is using this Shader. Note that even though the same <span class=component>Car Texture</span> is reused here, the end result is quite different from the car body, as the Shader used in the Material is different.

To be more specific, a Shader defines:
* The method to render an object. This includes using different methods depending on the graphics card of the end user.
* Any vertex and fragment programs used to render.
* Some texture properties that are assignable within Materials.
* Color and number settings that are assignable within Materials.

A Material defines:
* Which textures to use for rendering.
* Which colors to use for rendering.
* Any other assets, such as a Cubemap that is required by the shader for rendering.

Shaders are meant to be written by graphics programmers. They are created using the <span class=keyword>ShaderLab</span> language, which is quite simple. However, getting a shader to work well on a variety graphics cards is an involved job and requires a fairly comprehensive knowledge of how graphics cards work.

A number of shaders are built into Unity directly, and some more come in the [Standard Assets](HOWTO-InstallStandardAssets.md) Library.  If you like, there is plenty more shader information in the [Built-in Shader Guide](Built-inShaderGuide.md).
