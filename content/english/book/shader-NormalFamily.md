Normal Shader Family
====================


These shaders are the basic shaders in Unity.  They are not specialized in any way and should be suitable for most opaque objects.  They are not suitable if you want your object to be transparent, emitting light etc. 

[Vertex Lit](shader-NormalVertexLit.md)
---------------------------------------


[Attach:Shaders./Thumb-NormalVertex.png](shader-NormalVertexLit.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture, no alpha channel required


[Diffuse](shader-NormalDiffuse.md)
----------------------------------


[Attach:Shaders./Thumb-NormalDiffuse.png](shader-NormalDiffuse.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture, no alpha channel required


[Specular](shader-NormalSpecular.md)
------------------------------------


[Attach:Shaders./Thumb-NormalSpec.png](shader-NormalSpecular.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for Specular Map


[Normal mapped](shader-NormalBumpedDiffuse.md)
----------------------------------------------


[Attach:Shaders./Thumb-NormalBump.png](shader-NormalBumpedDiffuse.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture, no alpha channel required
* One <span class=component>Normal map</span>


[Normal mapped Specular](shader-NormalBumpedSpecular.md)
--------------------------------------------------------


[Attach:Shaders./Thumb-NormalBumpSpec.png](shader-NormalBumpedSpecular.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for Specular Map
* One <span class=component>Normal map</span>


[Parallax](shader-NormalParallaxDiffuse.md)
-------------------------------------------


[Attach:Shaders./Thumb-NormalParallaxBump.png](shader-NormalParallaxDiffuse.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture, no alpha channel required
* One <span class=component>Normal map</span>
* One <span class=component>Height</span> texture with Parallax Depth in the alpha channel


[Parallax Specular](shader-NormalParallaxSpecular.md)
-----------------------------------------------------


[Attach:Shaders./Thumb-NormalParallaxBumpSpec.png](shader-NormalParallaxSpecular.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for Specular Map
* One <span class=component>Normal map</span>
* One <span class=component>Height</span> texture with Parallax Depth in the alpha channel


[Decal](shader-NormalDecal.md)
------------------------------


[Attach:Shaders./Thumb-NormalDecal.png](shader-NormalDecal.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture, no alpha channel required
* One <span class=component>Decal</span> texture with alpha channel for Decal transparency


[Diffuse Detail](shader-NormalDiffuseDetail.md)
-----------------------------------------------


[Attach:Shaders./Thumb-NormalDiffuseDetail.png](shader-NormalDiffuseDetail.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture, no alpha channel required
* One <span class=component>Detail</span> grayscale texture; with 50% gray being neutral color
