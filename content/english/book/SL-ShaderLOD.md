Shader Level of Detail
======================


Shader Level of Detail (LOD) works by only using shaders or subshaders that have their LOD value less than a given number.

By default, allowed LOD level is infinite, that is, all shaders that are supported by the user's hardware can be used. However, in some cases you might want to drop shader details, even if the hardware can support them. For example, some cheap graphics cards might support all the features, but are too slow to use them. So you may want to not use parallax normal mapping on them.

Shader LOD can be either set per individual shader (using [Shader.maximumLOD](ScriptRef:Shader-maximumLOD.html)), or globally for all shaders (using [Shader.globalMaximumLOD](ScriptRef:Shader-globalMaximumLOD.html)).

In your custom shaders, use <span class=keyword>LOD</span> command to set up LOD value for any subshader.

Built-in shaders in Unity have their LODs set up this way:
* VertexLit kind of shaders = 100
* Decal, Reflective VertexLit = 150
* Diffuse = 200
* Diffuse Detail, Reflective Bumped Unlit, Reflective Bumped VertexLit = 250
* Bumped, Specular = 300
* Bumped Specular = 400
* Parallax = 500
* Parallax Specular = 600


