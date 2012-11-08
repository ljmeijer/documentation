Transparent Bumped Specular
===========================



![](http://docwiki.hq.unity3d.com/uploads/Main/Shaders./Shader-TransBumpSpec.png)  

One consideration for this shader is that the Base texture's alpha channel defines both the Transparent areas as well as the Specular Map.

(:include shader-TransFamilyImport:)

(:include shader-BumpSubsetImport:)

(:include shader-SpecularSubsetImport:)

Performance
-----------


Generally, this shader is moderately expensive to render.  For more details, please view the [Shader Peformance page](shader-Performance.md).
