Using DirectX 11 in Unity 4
===========================


Unity 4 introduces ability to use DirectX 11 graphics API, with all the goodies that you expect from it: compute shaders, tessellation shaders, shader model 5.0 and so on.

Enabling DirectX 11
-------------------


To enable DirectX 11 for your game builds and the editor, set "Use DX11" option in [Player Settings](class-PlayerSettings.md). Unity editor needs to be restarted for this to take effect.

Note that DX11 requires Windows Vista or later and at least a DX10-level GPU (preferably DX11-level). Unity editor window title has "<DX11>" at the end when it is actually running in DX11 mode.



Image Effects that can take advantage of DX11
---------------------------------------------


* [Depth of Field effect](script-DepthOfFieldScatter.md) (optimized Bokeh texture splatting)
* [Noise and Grain effect](script-NoiseAndGrain.md) (higher quality noise patterns)
* [Motion Blur effect](script-CameraMotionBlur.md) (higher quality reconstruction filter)

Compute Shaders
---------------


Compute shaders allow using GPU as a massively parallel processor. See [Compute Shaders](ComputeShaders.md) page for mode details.


Tessellation & Geometry Shaders
-------------------------------


Surface shaders have support for simple tessellation & displacement, see [Surface Shader Tessellation](SL-SurfaceShaderTessellation.md) page.

When manually writing [shader programs](SL-ShaderPrograms.md), you can use full set of DX11 shader model 5.0 features, including geometry, hull & domain shaders.


DirectX 11 Examples
-------------------


The following screenshots show examples of what becomes possible with DirectX 11.


![](http://docwiki.hq.unity3d.com/uploads/Main/DX11Explosion2.png)  
_The volumetric explosion in these shots is rendered using raymarching which becomes plausible with shader model 5.0. Moreover, as it generates and updates depth values, it becomes fully compatible with depth based image effects such as depth of field or motion blur._


![](http://docwiki.hq.unity3d.com/uploads/Main/DX11Hair.png)  
_The hair in this shot is implemented via DirectX 11 tessellation & geometry shaders to dynamically generate and animate individual strings of hair. Shading is based on a model proposed by Kajiya-Kai that enables a more believable diffuse and specular behaviour._


![](http://docwiki.hq.unity3d.com/uploads/Main/DX11Fur.png)  
_Similar to the hair technique above, the shown slippers fur is also based on generating geometry emitted from a simple base slippers mesh._


![](http://docwiki.hq.unity3d.com/uploads/Main/DX11Bokeh1.png)  
_The blur effect in this image (known as <span class=component>Bokeh</span>) is based on splatting a texture on top of very bright pixels. This can create very believable camera lens blurs, especially when used in conjunction with [HDR](HDR.md) rendering._


![](http://docwiki.hq.unity3d.com/uploads/Main/Bokeh2.png)  
_Exaggerated lens blur similar to the screenshot above. This is a possible result using the new [Depth of Field](script-DepthOfFieldScatter.md)  effect_
