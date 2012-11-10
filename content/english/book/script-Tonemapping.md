Tonemapping
===========


<span class=component>Tonemapping</span> is usually understood as the process of mapping color values from [HDR](HDR.md) (high dynamic range) to LDR (low dynamic range). In Unity, this means for most platforms that arbitrary 16-bit floating point color values will be mapped to traditional 8-bit values in the [0,1] range.

Note that Tonemapping will only properly work if the used camera is [HDR](HDR.md) enabled. It is also recommended to give light sources higher than normal intensity values to make use of the bigger range. Just as in real life there is huger differences in Luminance and our eyes or any capturing medium is only able to sample a certain range of that. 


##u40 Details
Tonemapping works well in conjunction with the HDR-enabled [Bloom image effect](script-Bloom.md). Make sure that Bloom should be applied before Tonemapping as otherwise all high ranges will be lost. Generally, any effect that can benefit from higher luminances should be scheduled before the Tonemapper (one more example being the [Depth of Field image effect](script-DepthOfFieldScatter.md)).

There are different ways on how to map intensities to LDR (as selected by <span class=component>Mode</span>). This effect provides several techniques, two of them being adaptive (<span class=component>AdaptiveReinhard</span> and <span class=component>AdaptiveReinhardAutoWhite</span>), which means that color changes are carried out delayed as the change in intensities is fully registered. Cameras and the human eye have this effect. This enables interesting dynamic effects such as a simulation of the natural adaption happening when entering or leaving a dark tunnel into bright sunlight.

The following two screenshots show Photographic Tonemapping with different exposure values. Note how banding is avoided by using HDR cameras.


![](http://docwiki.hq.unity3d.com/uploads/Main/ImageEffects./Photographics.png)  



![](http://docwiki.hq.unity3d.com/uploads/Main/ImageEffects./Photographics2.png)  

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Mode</span> |Choose the desired tonemapping algorithm.|


|    |    |
|:---|:---|
|<span class=component>Exposure</span> |Simulated exposure, defining the actual range of luminances.|
|<span class=component>Average grey</span> |Average grey value of the scene that defines the intensity of the result.|
|<span class=component>White</span> |Smallest value that will be mapped white.|
|<span class=component>Adaption speed</span> |Adjustment speed for all adaptive tonemappers.|
|<span class=component>Texture size</span> |Size of the internal texture for all adaptive tonemappers. Bigger values capture more details when calculating the new intensity and lower performance.|

(:include imagefx-SM2:)
