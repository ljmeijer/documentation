Vortex image effect
===================


The <span class=keyword>Vortex</span> image effect distorts the rendered image within a circular region. Pixels in the image are displaced around a central circular area by a specified angle; the amount of displacement reduces with distance from the centre, diminishing to zero at the circle's edge. Vortex is similar to another image effect called [Twirl](script-TwirlEffect.md), although Twirl distorts the image around a point rather than a circle.

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.


![](http://docwiki.hq.unity3d.com/uploads/Main/FxVortex.png)  
_Vortex image effect applied to the scene_


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Radius</span> |The radius of the circle where distortion occurs, given in normalized screen coordinates (ie, a radius of 0.5 is half the size of the screen). |
|<span class=component>Angle</span>  |The angle by which pixels are displaced around the central circle. |
|<span class=component>Center</span> |The center of the circular region of distortion.|

(:include imagefx-SM2:)

