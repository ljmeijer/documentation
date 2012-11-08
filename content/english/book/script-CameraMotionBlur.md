Camera Motion Blur
==================


<span class=keyword>Motion Blur</span> is a common postprocessing effect simulating the fact that for most camera systems 'light' gets accumulated over time (instead of just taking discrete snapshots). Fast camera or object motion will hence produce blurred images.


![](http://docwiki.hq.unity3d.com/uploads/Main/MbReconstructionBlurExample.png)  
_Example of a standard camera motion blur when the camera is moving sideways. Also, notice how the background areas blur less than the foreground ones which is a typical side effect of motion blur._

The current Motion Blur implementation only supports blur due to camera motion with the option to exclude certain layers (useful for excluding characters and/or dynamic objects, especially when those are following the camera movement). It can however be extended to support dynamic objects if an additional script keeps track of each objects model matrix and updates the velocity buffer.


![](http://docwiki.hq.unity3d.com/uploads/Main/MotionBlurExamplePassion.png)  
_Example showing Camera Motion Blur with dynamic objects (canisters, bus) being excluded_

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.

Properties
----------


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Technique</span> |Motion Blur algorithm. <span class=keyword>Reconstruction</span> filters will generally give best results at the expense of performance and a limited blur radius of 10 pixels unless a [DirectX11](DirectX11.md) enabled graphics device is used. |
|<span class=component>Velocity Scale</span> |Higher scale makes image more likely to blur. |
|<span class=component>Velocity Max</span> |Maximum pixel distance blur will be clamped to and tile size for reconstruction filters (see below). |
|<span class=component>Velocity Min</span> |Minimum pixel distance at which blur is removed entirely. |


|    |
|:---|
|<span class=component>Camera Motion</span> specific:|


|    |    |
|:---|:---|
|<span class=component>Camera Rotation</span> |Scales strength of blurs due to camera rotations. |
|<span class=component>Camera Movement</span> |Scales strength of blurs due to camera translations. |


|    |
|:---|
|<span class=component>Local Blur</span>, <span class=component>Reconstruction</span> and <span class=component>ReconstructionDX11</span> specific:|


|    |    |
|:---|:---|
|<span class=component>Exclude layers</span> |Objects in this layer will remain unaffected. |
|<span class=component>Velocity downsample</span> |Lower resolution velocity buffers might help performance but will heavily degrade blur quality. Might still be a valid option for simple scenes. |
|<span class=component>Sampler Jitter</span> |Adding noise helps prevent ghosting for the <span class=keyword>Reconstruction</span> filter. |
|<span class=component>Max Sample Count</span> |Number of samples used to determine the blur. Affects performance a lot. |


|    |    |
|:---|:---|
|<span class=component>Preview (Scale)</span> |Preview how blur might look like given artificial camera motion values. |

Motion Blur Filters (Technique)
-------------------------------


<span class=keyword>Local Blur</span> simply performs a directional blur along the current's pixel velocity. Being essentially a _gather_ operation, it is suited for scenes with a low geometric complexity (e.g. vast terrains), large blur radii or when 'realism' is not the governing factor. One shortcoming is that it can't produce proper 'overlaps' of blurred objects onto focused background areas. Another one that excluded objects 'smear' onto blurred areas.


![](http://docwiki.hq.unity3d.com/uploads/Main/LocalBlurExample2.png)  
_Example using the <span class=component>Local Blur</span> technique while the camera is translating sideways and either foreground (top) or background is excluded (bottom). Notice that both of the above mentioned artifacts apply, typically degrading image quality. If those are not important in your case, this motion blur technique is a fast and effective option._

<span class=keyword>Reconstruction</span> filters can produce more realistic blur results. The name Reconstruction is derived from the fact that the filter tries to estimate backgrounds, even if there is no information available in the given color and depth buffers. The results can be of higher quality and shortcomings of the _Local Blur_'s gather filter can be avoided (it can e.g. produce proper overlaps).

It is based on the paper _A Reconstruction Filter for Plausible Motion Blur_ (http://graphics.cs.williams.edu/papers/MotionBlurI3D12/). The algorithm chops the image into tiles of the size <span class=component>Velocity Max</span> and uses the maximum velocity in the area to simulate a blurry pixel scattering onto neighbouring areas. Artifacts can arise if the velocity is highly varying while the mentioned tile size is large. 

The [DirectX11](DirectX11.md) exclusive filter <span class=component>ReconstructionDX11</span> allows arbitrary blur distances (aka tile size or <span class=component>Velocity Max</span>) and a flexible number of samples.


![](http://docwiki.hq.unity3d.com/uploads/Main/ReconstructionExample2.png)  
_Example using the <span class=component>Reconstruction</span> technique while the camera is translating sideways. Notice that this time, the mentioned artifacts are less severe as the Reconstruction filter tries to solve those cases (cubes overlapping when background is excluded (bottom) or excluded cubes not smearing onto blurred background (top))._

While all of the above filters need a prepass to generate a velocity buffer, the <span class=keyword>Camera Motion</span> filter solely works on the camera motion. It generates a global filter direction based on camera change and blurs the screen along that direction (see http://www.valvesoftware.com/publications/2008/GDC2008_PostProcessingInTheOrangeBox.pdf for more details). 
It is especially suited for smoothing fast camera rotations, for instance in first person shooter games. 


![](http://docwiki.hq.unity3d.com/uploads/Main/CameraMotionBlurExample.png)  
_Example using the <span class=component>Camera Motion</span> technique. Notice that the blur is uniform across the entire screen._

(:include imagefx-SM3Depth:)
