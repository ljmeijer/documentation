Global Fog
==========


The <span class=keyword>Global Fog</span> image effect creates camera-based exponential fog. All calculations are done in world space which makes it possible to have height-based fog modes that can be used for sophisticated effects (see example).


![](http://docwiki.hq.unity3d.com/uploads/Main/GlobalFogExample.png)  
_Example of global fog, demonstrating both distance and height based fog_


![](http://docwiki.hq.unity3d.com/uploads/Main/Athmospheric.png)  
_Example of "cheating" at atmospheric effects using global fog_

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.

Properties
----------


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Fog Mode</span> |The available types of fog, based on distance, height or both|
|<span class=component>Start Distance</span> |The distance at which the fog starts fading in, in world space units.|
|<span class=component>Global Density</span> |The degree to which the <span class=component>Fog Color</span> accumulates with distance.|
|<span class=component>Height Scale</span> |The degree to which the fog density reduces with height (when height-based fog is enabled).|
|<span class=component>Height</span> |The world space Y coordinate where fog starts to fade in.|
|<span class=component>Global Fog Color</span> |The color of the fog.|

(:include imagefx-SM2Depth:)

