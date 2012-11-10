Transparent Shader Family
=========================


The Transparent shaders are used for fully- or semi-transparent objects.  Using the alpha channel of the <span class=component>Base</span> texture, you can determine areas of the object which can be more or less transparent than others.  This can create a great effect for glass, HUD interfaces, or sci-fi effects.

[Transparent Vertex-Lit](shader-TransVertexLit.md)
--------------------------------------------------


[Attach:Shaders./Thumb-TransVertex.png](shader-TransVertexLit.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for Transparency Map

[shader-TransVertexLit | &#187; More details](shader-TransVertexLit|&#187;Moredetails.md)


[Transparent Diffuse](shader-TransDiffuse.md)
---------------------------------------------


[Attach:Shaders./Thumb-TransDiffuse.png](shader-TransDiffuse.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for Transparency Map

[shader-TransDiffuse | &#187; More details](shader-TransDiffuse|&#187;Moredetails.md)


[Transparent Specular](shader-TransSpecular.md)
-----------------------------------------------


[Attach:Shaders./Thumb-TransSpec.png](shader-TransSpecular.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for combined Transparency Map/Specular Map

_'Note:_'
One limitation of this shader is that the <span class=component>Base</span> texture's alpha channel doubles as a Specular Map for the Specular shaders in this family.


[shader-TransSpecular | &#187; More details](shader-TransSpecular|&#187;Moredetails.md)


[Transparent Normal mapped](shader-TransBumpedDiffuse.md)
---------------------------------------------------------


[Attach:Shaders./Thumb-TransBump.png](shader-TransBumpedDiffuse.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for Transparency Map
* One <span class=component>Normal map</span> normal map, no alpha channel required

[shader-TransBumpedDiffuse | &#187; More details](shader-TransBumpedDiffuse|&#187;Moredetails.md)


[Transparent Normal mapped Specular](shader-TransBumpedSpecular.md)
-------------------------------------------------------------------


[Attach:Shaders./Thumb-TransBumpSpec.png](shader-TransBumpedSpecular.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for combined Transparency Map/Specular Map
* One <span class=component>Normal map</span> normal map, no alpha channel required

_'Note:_'
One limitation of this shader is that the <span class=component>Base</span> texture's alpha channel doubles as a Specular Map for the Specular shaders in this family.

[shader-TransBumpedSpecular | &#187; More details](shader-TransBumpedSpecular|&#187;Moredetails.md)


[Transparent Parallax](shader-TransParallaxDiffuse.md)
------------------------------------------------------


[Attach:Shaders./Thumb-TransParallaxBump.png](shader-TransParallaxDiffuse.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for Transparency Map
* One <span class=component>Normal map</span> normal map with alpha channel for Parallax Depth

[shader-TransParallaxDiffuse | &#187; More details](shader-TransParallaxDiffuse|&#187;Moredetails.md)


[Transparent Parallax Specular](shader-TransParallaxSpecular.md)
----------------------------------------------------------------


[Attach:Shaders./Thumb-TransParallaxBumpSpec.png](shader-TransParallaxSpecular.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for combined Transparency Map/Specular Map
* One <span class=component>Normal map</span> normal map with alpha channel for Parallax Depth

_'Note:_'
One limitation of this shader is that the <span class=component>Base</span> texture's alpha channel doubles as a Specular Map for the Specular shaders in this family.

[shader-TransParallaxSpecular | &#187; More details](shader-TransParallaxSpecular|&#187;Moredetails.md)
