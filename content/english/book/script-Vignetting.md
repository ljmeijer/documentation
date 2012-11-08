Vignetting (and Chromatic Aberration)
=====================================


The <span class=keyword>Vignetting</span> image effect introduces darkening, blur and chromatic aberration (spectral color separation) at the edges and corners of the image. This is usually used to simulate a view through a camera lens but can also be used to create abstract effects.


![](http://docwiki.hq.unity3d.com/uploads/Main/ImageEffects./VignetteExample.png)  
_Example of Vignetting and chromatic Aberration. Notice how the screen corners darken and color separation (aberration) creates purple and slightly green color fringing._

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.

##u30 Details
Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Intensity</span> |The degree of darkening applied to the screen edges and corners.|
|<span class=component>Chromatic Aberration</span> |The degree of chromatic aberration. A value of 0.0 will disable chromatic aberration entirely. |
|<span class=component>Blur</span> |The amount of blur that is added to the screen corners. |
|<span class=component>Blur Spread</span> |The blur width used when <span class=component>Blur</span> is added. |

###u40 Details
Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Vignetting</span> |The degree of darkening applied to the screen edges and corners. Choose 0 to disable this feature and save on performance.|
|<span class=component>Blurred Corners</span> |The amount of blur that is added to the screen corners. Choose 0 to disable this feature and save on performance. |
|<span class=component>Blur Distance</span> |The blur filter sample distance used when blurring corners. |


|    |    |
|:---|:---|
|<span class=component>Aberration Mode</span> |<span class=component>Advanced</span> tries to model more aberration effects (the constant axial aberration existant on the entire image plane) while <span class=component>Simple</span> only models tangential aberration (limited to corners). |
|<span class=component>Strength</span> |Overall aberration intensity (not to confuse with color offset distance), defaults to 1.0. |
|<span class=component>Tangential Aberration</span> |The degree of tangential chromatic aberration: Uniform on the entire image plane.  |
|<span class=component>Axial Aberration</span> |The degree of axial chromatic aberration: Scales with smaller distance to the image plane's corners. |
|<span class=component>Contrast Dependency</span> |The bigger this value, the more contrast is needed for the aberration to trigger. Higher values are more realistic (in this case, an HDR input is recommended). |

Advanced Mode
-------------


Advanced mode is more expensive but offers a more realistic implementation of Chromatic Aberration.


![](http://docwiki.hq.unity3d.com/uploads/Main/AberrationExample.png)  
_The <span class=component>Advanced</span> mode offers great control over our model of chromatic aberration -- also known as green or purple color fringing -- a common phenomenon in photography (also see image below)._


![](http://docwiki.hq.unity3d.com/uploads/Main/ColorFringing.png)  
_Closeup view of color fringing. Note how around areas of great contrast purple and green shimmers seem to appear. This effect depends depends on the kind of camera or lens system being used. The effect is based on the fact that different wavelengths will be projected on different focal planes._


(:include imagefx-SM2:)
