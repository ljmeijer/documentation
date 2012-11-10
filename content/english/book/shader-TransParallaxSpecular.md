Transparent Parallax Specular
=============================



![](http://docwiki.hq.unity3d.com/uploads/Main/Shaders./Shader-TransParallaxBumpSpec.png)  

One consideration for this shader is that the Base texture's alpha channel defines both the Transparent areas as well as the Specular Map.

(:include shader-TransFamilyImport:)

(:include shader-ParallaxSubsetImport:)

(:include shader-SpecularSubsetImport:)

Performance
-----------


Generally, this shader is on the more expensive rendering side.  For more details, please view the [Shader Peformance page](shader-Performance.md).
