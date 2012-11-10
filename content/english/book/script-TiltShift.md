Tilt Shift
==========


<span class=keyword>Tilt Shift</span> is a specialized version of the [Depth of Field](script-DepthOfField34.md) effect that allows for very smooth transitions between focused and defocused areas. It is is easier to use and is generally less prone to unsightly image artifacts. However, since it relies on dependent texture lookups, it can also have a higher processing overhead.


![](http://docwiki.hq.unity3d.com/uploads/Main/ImageEffects./TiltShift2.png)  
_Tilt shift example. Observe the overall smoothness the effect achieves._

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.

Properties
----------


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Focal Settings</span> ||
|<span class=component>Visualize</span> |Visualizes the focal plane in the game view with a green tint (useful for learning or debugging). |
|<span class=component>Distance</span> |The distance to the focal plane from the camera position in world space units. |
|<span class=component>Smoothness</span> |The smoothness when transitioning from out-of-focus to in-focus areas. |


|    |    |
|:---|:---|
|<span class=component>Background Blur</span> ||
|<span class=component>Downsample</span> |Downsamples most internal buffers (this makes the effect faster but more blurry).|
|<span class=component>Iterations</span> |Number of iterations for blurring the background areas (ie, everything behind the focal plane). Each iteration requires processing time.|
|<span class=component>Max Blur spread</span> |The maximum blur distance for the defocused areas. Makes out-of-focus areas increasingly blurred. |


|    |    |
|:---|:---|
|<span class=component>Foreground Blur</span> ||
|<span class=component>Enable</span> |Enables foreground blurring. This typically gives a better result but with a cost in processing time.|
|<span class=component>Iterations</span> |Number of iterations for blurring the foreground areas (ie, everything in front of the focal area). Each iteration requires processing time.|


(:include imagefx-SM3Depth:)

