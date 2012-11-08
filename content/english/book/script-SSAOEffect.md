Screen Space Ambient Occlusion (SSAO) image effect
==================================================


<span class=keyword>Screen Space Ambient Occlusion (SSAO)</span> approximates [Ambient Occlusion](http://en.wikipedia.org/wiki/Ambient_occlusion.md) in realtime, as an image post-processing effect. It darkens creases, holes and surfaces that are close to each other. In real life, such areas tend to block out or <span class=component>occlude</span> ambient light, hence they appear darker.

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.


![](http://docwiki.hq.unity3d.com/uploads/Main/FxSSAO.png)  
_SSAO applied to the scene._


![](http://docwiki.hq.unity3d.com/uploads/Main/FxNoSSAO.png)  
_The same scene without SSAO for comparison. Note the differences at the corners where structures or grass meet the ground._

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Radius</span> |The maximum "radius" of a gap that will introduce ambient occlusion.|
|<span class=component>Sample Count</span> |Number of ambient occlusion samples. A higher count will give better quality but with a higher processing overhead.|
|<span class=component>Occlusion Intensity</span> |The degree of darkness added by ambient occlusion.|
|<span class=component>Blur</span> |Amount of blur to apply to the darkening. No blur (0) is much faster but the darkened areas will be noisy. |
|<span class=component>Downsampling</span> |The resolution at which calculations should be performed (for example, a downsampling value of 2 will work at half the screen resolution). Downsampling increases rendering speed at the cost of quality.|
|<span class=component>Occlusion Attenuation</span> |How fast occlusion should attenuate with distance. |
|<span class=component>Min Z</span> |Try increasing this value if there are artifacts. |

Details
-------


SSAO approximates ambient occlusion using an image processing effect. Its cost depends purely on screen resolution and SSAO parameters and does not depend on scene complexity as true AO would. However, the approximation tends to introduce artifacts. For example, objects that are outside of the screen do not contribute to occlusion and the amount of occlusion is dependent on viewing angle and camera position.

Note that SSAO is quite expensive in terms of processing time and generally should only be used on high-end graphics cards. Using SSAO will cause Unity to render the depth+normals texture of the camera which increases the number of draw calls and has a CPU processing overhead. However, the depth+normals texture then can be used for other effects as well (eg, Depth of Field). Once the texture is generated, the remainder of the SSAO effect is performed on the graphics card.


Hardware support
----------------


SSAO works on graphics cards with Shader Model 3.0 support (eg, GeForce 6 and later, Radeon X1300 and later).  All image effects automatically disable themselves when they can not run on a particular graphics card. Due to the complexity of the effect, SSAO is not supported on mobile devices.
