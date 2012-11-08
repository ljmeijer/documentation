Twirl image effect
==================


The <span class=keyword>Twirl</span> image effect distorts the rendered image within a circular region. The pixels at the centre of the circle are rotated by a specified angle; the rotation for other pixels in the circle decreases with distance from the centre, diminishing to zero at the circle's edge.

Twirl is similar to another image effect called [Vortex](script-VortexEffect.md), although vortex distorts the image around a central circle rather than a single point.

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.


![](http://docwiki.hq.unity3d.com/uploads/Main/FxTwirl.png)  
_Twirl image effect applied to the scene_


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Radius</span> |The radius of the ellipse where image distortion occurs, given in normalized screen coordinates (ie, a radius of 0.5 is half the size of the screen). |
|<span class=component>Angle</span>  |The angle of rotation at the centre point.|
|<span class=component>Center</span> |The point at the centre of the circle where distortion occurs.|

(:include imagefx-SM2:)

