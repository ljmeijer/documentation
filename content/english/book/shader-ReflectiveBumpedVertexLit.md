Reflective Normal mapped Vertex-lit
===================================



![](http://docwiki.hq.unity3d.com/uploads/Main/Shaders./Shader-ReflBumpVertex.png)  

(:include shader-ReflectiveFamilyImport:)

(:include shader-VertexLitSubsetImport:)

Special Properties
------------------


This shader is a good alternative to Reflective Normal mapped.  If you do not need the object itself to be affected by pixel lights, but do want the reflection to be affected by a normal map, this shader is for you. This shader is vertex-lit, so it is rendered more quickly than its Reflective Normal mapped counterpart.

Performance
-----------


Generally, this shader is not expensive to render.  For more details, please view the [Shader Peformance page](shader-Performance.md).
