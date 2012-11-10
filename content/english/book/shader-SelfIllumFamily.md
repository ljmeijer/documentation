Self-Illuminated Shader Family
==============================


The <span class=keyword>Self-Illuminated</span> shaders will emit light only onto themselves based on an attached alpha channel.  They do not require any Lights to shine on them to emit this light.  Any vertex lights or pixel lights will simply add more light on top of the self-illumination.

This is mostly used for light emitting objects. For example, parts of the wall texture could be self-illuminated to simulate lights or displays.  It can also be useful to light power-up objects that should always have consistent lighting throughout the game, regardless of the lights shining on it.

[Self-Illuminated Vertex-Lit](shader-SelfIllumVertexLit.md)
-----------------------------------------------------------


[Attach:Shaders./Thumb-IllumVertex.png](shader-SelfIllumVertexLit.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture, no alpha channel required
* One <span class=component>Illumination</span> texture with alpha channel for Illumination Map

[shader-SelfIllumVertexLit| &#187; More details](shader-SelfIllumVertexLit|&#187;Moredetails.md)


[Self-Illuminated Diffuse](shader-SelfIllumDiffuse.md)
------------------------------------------------------


[Attach:Shaders./Thumb-IllumDiffuse.png](shader-SelfIllumDiffuse.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture, no alpha channel required
* One <span class=component>Illumination</span> texture with alpha channel for Illumination Map

[shader-SelfIllumDiffuse | &#187; More details](shader-SelfIllumDiffuse|&#187;Moredetails.md)


[Self-Illuminated Specular](shader-SelfIllumSpecular.md)
--------------------------------------------------------


[Attach:Shaders./Thumb-IllumSpec.png](shader-SelfIllumSpecular.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for Specular Map
* One <span class=component>Illumination</span> texture with alpha channel for Illumination Map

[shader-SelfIllumSpecular | &#187; More details](shader-SelfIllumSpecular|&#187;Moredetails.md)


[Self-Illuminated Bumped](shader-SelfIllumBumpedDiffuse.md)
-----------------------------------------------------------


[Attach:Shaders./Thumb-IllumBump.png](shader-SelfIllumBumpedDiffuse.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture, no alpha channel required
* One <span class=component>Normal map</span> normal map with alpha channel for Illumination

[shader-SelfIllumBumpedDiffuse | &#187; More details](shader-SelfIllumBumpedDiffuse|&#187;Moredetails.md)


[Self-Illuminated Bumped Specular](shader-SelfIllumBumpedSpecular.md)
---------------------------------------------------------------------


[Attach:Shaders./Thumb-IllumBumpSpec.png](shader-SelfIllumBumpedSpecular.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for Specular Map
* One <span class=component>Normal map</span> normal map with alpha channel for Illumination Map

[shader-SelfIllumBumpedSpecular | &#187; More details](shader-SelfIllumBumpedSpecular|&#187;Moredetails.md)


[Self-Illuminated Parallax](shader-SelfIllumParallaxDiffuse.md)
---------------------------------------------------------------


[Attach:Shaders./Thumb-IllumParallaxBump.png](shader-SelfIllumParallaxDiffuse.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture, no alpha channel required
* One <span class=component>Normal map</span> normal map with alpha channel for Illumination Map & Parallax Depth combined

_'Note:_'
One consideration of this shader is that the <span class=component>Bumpmap</span> texture's alpha channel doubles as a Illumination and the Parallax Depth.

[shader-SelfIllumParallaxDiffuse | &#187; More details](shader-SelfIllumParallaxDiffuse|&#187;Moredetails.md)


[Self-Illuminated Parallax Specular](shader-SelfIllumParallaxSpecular.md)
-------------------------------------------------------------------------


[Attach:Shaders./Thumb-IllumParallaxBumpSpec.png](shader-SelfIllumParallaxSpecular.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for Specular Map
* One <span class=component>Normal map</span> normal map with alpha channel for Illumination Map & Parallax Depth combined

_'Note:_'
One consideration of this shader is that the <span class=component>Bumpmap</span> texture's alpha channel doubles as a Illumination and the Parallax Depth.

[shader-SelfIllumParallaxSpecular | &#187; More details](shader-SelfIllumParallaxSpecular|&#187;Moredetails.md)
