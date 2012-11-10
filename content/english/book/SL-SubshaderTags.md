ShaderLab syntax: SubShader Tags
================================


Subshaders use tags to tell how and when they expect to be rendered to the rendering engine.

Syntax
------

:__Tags {__ "_TagName1_" = "_Value1_" "_TagName2_" = "_Value2_" __}__: Specifies __TagName1__ to have __Value1__, __TagName2__ to have __Value2__. You can have as many tags as you like.

Details
-------

Tags are basically key-value pairs. Inside a [SubShader](SL-SubShader.md) tags are used to determine rendering order and other parameters of a subshader. Note that the following tags recognized by Unity _'must_' be inside SubShader section and not inside Pass!

###Rendering Order - Queue tag

You can determine in which order your objects are drawn using the _Queue_ tag. A Shader decides which render queue its objects belong to, this way any Transparent shaders make sure they are drawn after all opaque objects and so on.

There are four pre-defined render queues, but there can be more queues in between the predefined ones. The predefined queues are:
* <span class=component>Background</span> - this render queue is rendered before any others. It is used for skyboxes and the like.
* <span class=component>Geometry</span> _(default)_ - this is used for most objects. Opaque geometry uses this queue.
* <span class=component>AlphaTest</span> - alpha tested geometry uses this queue. It's a separate queue from <span class=component>Geometry</span> one since it's more efficient to render alpha-tested objects after all solid ones are drawn.
* <span class=component>Transparent</span> - this render queue is rendered after _Geometry_ and <span class=component>AlphaTest</span>, in back-to-front order. Anything alpha-blended (i.e. shaders that don't write to depth buffer) should go here (glass, particle effects).
* <span class=component>Overlay</span> - this render queue is meant for overlay effects. Anything rendered last should go here (e.g. lens flares).

````
Shader "Transparent Queue Example" {
     SubShader {
        Tags {"Queue" = "Transparent" }
        Pass {
            // rest of the shader body...
        }
    }
} 
````
_An example illustrating how to render something in the transparent queue_

<span class=component>Geometry</span> render queue optimizes the drawing order of the objects for best performance. All other render queues sort objects by distance, starting rendering from the furthest ones and ending with the closest ones.

For special uses in-between queues can be used. Internally each queue is represented by integer index; <span class=component>Background</span> is 1000, <span class=component>Geometry</span> is 2000, <span class=component>AlphaTest</span> is 2450, <span class=component>Transparent</span> is 3000 and <span class=component>Overlay</span> is 4000. If a shader uses a queue like this:
````

Tags { "Queue" = "Geometry+1" }

````
This will make the object be rendered after all opaque objects, but before transparent objects, as render queue index will be 2001 (geometry plus one). This is useful in situations where you want some objects be always drawn between other sets of objects. For example, in most cases transparent water should be drawn after opaque objects but before transparent objects.



###RenderType tag

<span class=component>RenderType</span> tag categorizes shaders into several predefined groups, e.g. is is an opaque shader, or an alpha-tested shader etc. This is used by [Shader Replacement](SL-ShaderReplacement.md) and in some cases used to produce [camera's depth texture](SL-CameraDepthTexture.md).



###IgnoreProjector tag

If <span class=component>IgnoreProjector</span> tag is given and has a value of "True", then an object that uses this shader will not be affected by [Projectors](class-Projector.md). This is mostly useful on semitransparent objects, because there is no good way for Projectors to affect them.


See Also
--------


Passes can be given Tags as well, see [Pass Tags](SL-PassTags.md).

