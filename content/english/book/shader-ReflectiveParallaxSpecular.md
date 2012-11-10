Reflective Parallax Specular
============================



![](http://docwiki.hq.unity3d.com/uploads/Main/Shaders./Shader-ReflParallaxBumpSpec.png)  

One consideration for this shader is that the Base texture's alpha channel will double as both the Reflection Map and the Specular Map.

(:include shader-ReflectiveFamilyImport:)

(:include shader-ParallaxSubsetImport:)

(:include shader-SpecularSubsetImport:)

Performance
-----------


Generally, this shader is on the more expensive rendering side.  For more details, please view the [Shader Peformance page](shader-Performance.md).
