ShaderLab syntax: GrabPass
==========================

GrabPass is a special passtype - it grabs the contents of the screen where the object is about to be drawn into a texture. This texture can be used in subsequent passes to do advanced image based effects.

Syntax
------

The GrabPass belongs inside a [subshader](SL-SubShader.md). It can take two forms:
* Just `GrabPass { }` will grab current screen contents into a texture. The texture can be accessed in further passes by `_GrabTexture` name. Note: this form of grab pass will do the expensive screen grabbing operation for each object that uses it!
* `GrabPass { "_TextureName_" }` will grab screen contents into a texture, but will only do that once per frame for the first object that uses the given texture name. The texture can be accessed in further passes by the given texture name. This is a more performant way when you have multiple objects using grab pass in the scene.

Additionally, GrabPass can use [Name](SL-Name.md) and [Tags](SL-PassTags.md) commands.


Example
-------


Here is an expensive way to invert the colors of what was rendered before:

````
Shader "GrabPassInvert" {
    SubShader {
        // Draw ourselves after all opaque geometry
        Tags { "Queue" = "Transparent" }

        // Grab the screen behind the object into _GrabTexture
        GrabPass { }

        // Render the object with the texture generated above, and invert it's colors
        Pass {
            SetTexture [_GrabTexture] { combine one-texture }
        }
    }
} 
````


This shader has two passes: First pass grabs whatever is behind the object at the time of rendering, then applies that in the second pass. Now of course, the same effect could be achieved much cheaper using an invert [blend mode](SL-Blend.md).

See Also
--------

* [Regular Pass command](SL-Pass.md)
