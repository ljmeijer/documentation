Diffuse Detail
==============



![](http://docwiki.hq.unity3d.com/uploads/Main/Shaders./Shader-NormalDiffuseDetail.png)  

Diffuse Detail Properties
-------------------------

This shader is a version of the regular Diffuse shader with additional data.  It allows you to define a second "Detail" texture that will gradually appear as the camera gets closer to it.  It can be used on terrain, for example.  You can use a base low-resolution texture and stretch it over the entire terrain.  When the camera gets close the low-resolution texture will get blurry, and we don't want that. To avoid this effect, create a generic Detail texture that will be tiled over the terrain. This way, when the camera gets close, the additional details appear and the blurry effect is avoided.

The Detail texture is put "on top" of the base texture. Darker colors in the detail texture will darken the main texture and lighter colors will brighten it. Detail texture are usually gray-ish. For more information on effectively creating Detail textures, please view [this page](HOWTO-UseDetailTexture.md).

Performance
-----------

This shader is pixel-lit, and approximately equivalent to the Diffuse shader.  It is marginally more expensive due to additional texture.
