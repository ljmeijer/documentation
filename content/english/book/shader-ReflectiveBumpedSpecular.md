Reflective Bumped Specular
==========================



![](http://docwiki.hq.unity3d.com/uploads/Main/Shaders./Shader-ReflBumpSpec.png)  

One consideration for this shader is that the Base texture's alpha channel will double as both the Reflection Map and the Specular Map.

(:include shader-ReflectiveFamilyImport:)

(:include shader-BumpSubsetImport:)

(:include shader-SpecularSubsetImport:)

Performance
-----------


Generally, this shader is moderately expensive to render.  For more details, please view the [Shader Peformance page](shader-Performance.md).
