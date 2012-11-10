Contrast Enhance
================


The <span class=keyword>Contrast Enhance</span> image effect enhances the impression of contrast for a given camera. It uses the well-known <span class=component>unsharp mask</span> process available in image processing applications.

When blurring is applied to an image, the colors of adjacent pixels are averaged to some extent, resulting in a reduction of sharp edge detail. However, areas of flat color remain relatively unchanged. The idea behind unsharp masking is that an image is compared with a blurred (or "unsharp") version of itself. The difference in brightness between each pixel in the original and the corresponding pixel in the blurred image is an indication of how much constrast the pixel has against its neighbours. The brightness of that pixel is then changed in proportion to the local contrast. A pixel which is darker after blurring must be brighter than its neighbours, so its brightness is further increased while if the pixel is darker after blurring then it will be darkened even more. The effect of this is to increase contrast selectively in areas of the image where the detail is most noticeable. The parameters of unsharp masking are the pixel radius over which colors are blurred, the degree to which brightness will be altered by the effect and a "threshold" of contrast below which no change of brightness will be made.

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.


![](http://docwiki.hq.unity3d.com/uploads/Main/ContrastEnhanceDisabled.png)  
_No Contrast Enhance_


![](http://docwiki.hq.unity3d.com/uploads/Main/ContrastEnhanceEnabled.png)  
_Contrast enhance enabled_

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Intensity</span> |The intensity of contrast enhancement. |
|<span class=component>Threshhold</span> |The constrast threshold below which no enhancement is applied. |
|<span class=component>Blur Spread</span> |The radius over which contrast comparisons are made. |

(:include imagefx-SM2:)

