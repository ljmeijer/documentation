Projector
=========


A <span class=keyword>Projector</span> allows you to project a <span class=keyword>Material</span> onto all objects that intersect its frustum. The material must use a special type of shader for the projection effect to work correctly - see the projector prefabs in Unity's standard assets for examples of how to use the supplied Projector/Light and Projector/Multiply shaders.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-Projector.png)  
_The Projector <span class=keyword>Inspector</span>_

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Near Clip Plane</span>    |Objects in front of the near clip plane will not be projected upon. |
|<span class=component>Far Clip Plane</span>     |Objects beyond this distance will not be affected. |
|<span class=component>Field Of View</span>      |The field of view in degrees. This is only used if the Projector is not Ortho Graphic. |
|<span class=component>Aspect Ratio</span>       |The Aspect Ratio of the Projector. This allows you to tune the height vs width of the Projector. |
|<span class=component>Is Ortho Graphic</span>   |If enabled, the Projector will be Ortho Graphic instead of perspective. |
|<span class=component>Ortho Graphic Size</span> |The Ortho Graphic size of the Projection. this is only used if Is Ortho Graphic is turned on. |
|<span class=component>Material</span>           |The Material that will be Projected onto Objects. |
|<span class=component>Ignore Layers</span>      |Objects that are in one of the Ignore Layers will not be affected. By default, Ignore Layers is none so all geometry that intersects the Projector frustum will be affected. |


Details
-------


With a projector you can:
1. Create shadows.
1. Make a real world projector on a tripod with another [Camera](class-Camera.md) that films some other part of the world using a <span class=keyword>Render Texture</span>.
1. Create bullet marks.
1. Funky lighting effects.


![](http://docwiki.hq.unity3d.com/uploads/Main/Projector-BlobShadow.png)  
_A Projector is used to create a Blob Shadow for this Robot_

If you want to create a simple shadow effect, simply drag the <span class=menu>StandardAssets->Blob-Shadow->Blob shadow projector</span> <span class=keyword>Prefab</span> into your scene. You can modify the Material to use a different Blob shadow texture.

__Note:__ When creating a projector, always be sure to set the wrap mode of the texture's material of the projector to _clamp_. else the projector's texture will be seen repeated and you will not achieve the desired effect of shadow over your character.
Hints
-----

* Projector Blob shadows can create very impressive Splinter Cell-like lighting effects if used to shadow the environment properly.
* When no <span class=component>Falloff</span> Texture is used in the projector's Material, it can project both forward and backward, creating "double projection". To fix this, use an alpha-only Falloff texture that has a black leftmost pixel column.
