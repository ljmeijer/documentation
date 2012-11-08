Reflective Shader Family
========================


<span class=keyword>Reflective</span> shaders will allow you to use a Cubemap which will be reflected on your mesh.  You can also define areas of more or less reflectivity on your object through the alpha channel of the <span class=component>Base</span> texture. High relectivity is a great effect for glosses, oils, chrome, etc.  Low reflectivity can add effect for metals, liquid surfaces, or video monitors.

[Reflective Vertex-Lit](shader-ReflectiveVertexLit.md)
------------------------------------------------------


[Attach:Shaders./Thumb-ReflVertex.png](shader-ReflectiveVertexLit.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for defining reflective areas
* One <span class=component>Reflection</span> Cubemap for Reflection Map

[shader-ReflectiveVertexLit | &#187; More details](shader-ReflectiveVertexLit|&#187;Moredetails.md)


[Reflective Diffuse](shader-ReflectiveDiffuse.md)
-------------------------------------------------


[Attach:Shaders./Thumb-ReflDiffuse.png](shader-ReflectiveDiffuse.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for defining reflective areas
* One <span class=component>Reflection</span> Cubemap for Reflection Map

[shader-ReflectiveDiffuse | &#187; More details](shader-ReflectiveDiffuse|&#187;Moredetails.md)


[Reflective Specular](shader-ReflectiveSpecular.md)
---------------------------------------------------


[Attach:Shaders./Thumb-ReflSpec.png](shader-ReflectiveSpecular.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for defining reflective areas & Specular Map combined
* One <span class=component>Reflection</span> Cubemap for Reflection Map

_'Note:_'
One consideration for this shader is that the <span class=component>Base</span> texture's alpha channel will double as both the reflective areas and the Specular Map.

[shader-ReflectiveSpecular | &#187; More details](shader-ReflectiveSpecular|&#187;Moredetails.md)


[Reflective Normal mapped](shader-ReflectiveBumpedDiffuse.md)
-------------------------------------------------------------


[Attach:Shaders./Thumb-ReflBump.png](shader-ReflectiveBumpedDiffuse.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for defining reflective areas
* One <span class=component>Reflection</span> Cubemap for Reflection Map
* One <span class=component>Normal map</span> normal map, no alpha channel required

[shader-ReflectiveBumpedDiffuse | &#187; More details](shader-ReflectiveBumpedDiffuse|&#187;Moredetails.md)


[Reflective Normal Mapped Specular](shader-ReflectiveBumpedSpecular.md)
-----------------------------------------------------------------------


[Attach:Shaders./Thumb-ReflBumpSpec.png](shader-ReflectiveBumpedSpecular.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for defining reflective areas & Specular Map combined
* One <span class=component>Reflection</span> Cubemap for Reflection Map
* One <span class=component>Normal map</span> normal map, no alpha channel required

_'Note:_'
One consideration for this shader is that the <span class=component>Base</span> texture's alpha channel will double as both the reflective areas and the Specular Map.

[shader-ReflectiveBumpedSpecular | &#187; More details](shader-ReflectiveBumpedSpecular|&#187;Moredetails.md)


[Reflective Parallax](shader-ReflectiveParallaxDiffuse.md)
----------------------------------------------------------


[Attach:Shaders./Thumb-ReflParallaxBump.png](shader-ReflectiveParallaxDiffuse.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for defining reflective areas
* One <span class=component>Reflection</span> Cubemap for Reflection Map
* One <span class=component>Normal map</span> normal map, with alpha channel for Parallax Depth

[shader-ReflectiveParallaxDiffuse | &#187; More details](shader-ReflectiveParallaxDiffuse|&#187;Moredetails.md)


[Reflective Parallax Specular](shader-ReflectiveParallaxSpecular.md)
--------------------------------------------------------------------


[Attach:Shaders./Thumb-ReflParallaxBumpSpec.png](shader-ReflectiveParallaxSpecular.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for defining reflective areas & Specular Map
* One <span class=component>Reflection</span> Cubemap for Reflection Map
* One <span class=component>Normal map</span> normal map, with alpha channel for Parallax Depth

_'Note:_'
One consideration for this shader is that the <span class=component>Base</span> texture's alpha channel will double as both the reflective areas and the Specular Map.

[shader-ReflectiveParallaxSpecular | &#187; More details](shader-ReflectiveParallaxSpecular|&#187;Moredetails.md)


[Reflective Normal mapped Unlit](shader-ReflectiveBumpedUnlit.md)
-----------------------------------------------------------------


[Attach:Shaders./Thumb-ReflBumpUnlit.png](shader-ReflectiveBumpedUnlit.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for defining reflective areas
* One <span class=component>Reflection</span> Cubemap for Reflection Map
* One <span class=component>Normal map</span> normal map, no alpha channel required

[shader-ReflectiveBumpedUnlit | &#187; More details](shader-ReflectiveBumpedUnlit|&#187;Moredetails.md)


[Reflective Normal mapped Vertex-Lit](shader-ReflectiveBumpedVertexLit.md)
--------------------------------------------------------------------------


[Attach:Shaders./Thumb-ReflBumpVertex.png](shader-ReflectiveBumpedVertexLit.md)

_'Assets needed:_'
* One <span class=component>Base</span> texture with alpha channel for defining reflective areas
* One <span class=component>Reflection</span> Cubemap for Reflection Map
* One <span class=component>Normal map</span> normal map, no alpha channel required

[shader-ReflectiveBumpedVertexLit | &#187; More details](shader-ReflectiveBumpedVertexLit|&#187;Moredetails.md)
