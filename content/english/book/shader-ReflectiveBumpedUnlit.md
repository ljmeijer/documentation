Reflective Normal Mapped Unlit
==============================



![](http://docwiki.hq.unity3d.com/uploads/Main/Shaders./Shader-ReflBumpUnlit.png)  

(:include shader-ReflectiveFamilyImport:)

Normal mapped Properties
------------------------


This shader does not use normal-mapping in the traditional way.  The normal map does not affect any lights shining on the object, because the shader does not use lights at all.  The normal map will only distort the reflection map.

Special Properties
------------------


This shader is special because it does not respond to lights at all, so you don't have to worry about performance reduction from use of multiple lights. It simply displays the reflection cube map on the model. The reflection is distorted by the normal map, so you get the benefit of detailed reflection.  Because it does not respond to lights, it is quite cheap.  It is somewhat of a specialized use case, but in those cases it does exactly what you want as cheaply as possible.

Performance
-----------


Generally, this shader is quite cheap to render.  For more details, please view the [Shader Peformance page](shader-Performance.md).
