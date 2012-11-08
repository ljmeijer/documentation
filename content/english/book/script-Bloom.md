Bloom
=====


<span class=component>Blooming</span> is the optical effect where light from a bright source (such as a glint) appears to leak into surrounding objects. The <span class=keyword>Bloom</span> image effect adds bloom and also automatically generates lens flares in a highly efficient way. Bloom is a very distinctive effect that can make a big difference to a scene and may suggest a magical or dreamlike environment especially when used in conjunction with [Glow](HDR]]rendering.Ontheotherhand,givenpropersettingsit'salsopossibletoenhancephotorealismusingthiseffect.Glowaroundverybrightobjectsisacommonphenomenaobservedinfilmandphotography,whereluminancevaluesdiffervastly.Bloomisanenhancedversionofthe[[script-GlowEffect.md) and [Bloom And Flares](script-BloomAndLensFlares.md) image effects.


![](http://docwiki.hq.unity3d.com/uploads/Main/ImageEffects./HDRBloom2.png)  
_Example showing proper HDR glow as created by the <span class=keyword>Bloom</span> effect. In this scene, bloom uses a threshhold of 1.0 indicating that only HDR reflections, highlights or emissive surfaces glow, but common lighting is generally unaffected. In this particular example, only the car window (sporting the reflection of HDR sun values) glows._


![](http://docwiki.hq.unity3d.com/uploads/Main/ImageEffects./bloomAnamorphicFlares.png)  
_Example showing <span class=component>Anamorphic Lens Flares</span> result as created by the <span class=keyword>Bloom</span> effect_

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Quality</span> |High quality preserves high frequencies and reduces aliasing. |
|<span class=component>Mode</span> |Choose complex mode to show advanced options. |
|<span class=component>Blend</span> |The method used to add bloom to the color buffer. The softer <span class=component>Screen</span> mode is better for preserving bright image details but doesn't work with HDR. |
|<span class=component>HDR</span> |Whether bloom is using HDR buffers. This will result in a different look as pixel intensities may leave the [0,1] range, see details in [tonemapping](script-Tonemapping.md) and [HDR](HDR.md). |
|<span class=component>Cast lens flares</span> |Enable or disable automatic screen based lens flare generation. |


|    |    |
|:---|:---|
|<span class=component>Intensity</span> |The global light intensity of the added light (affects bloom and lens flares). |
|<span class=component>Threshhold</span> |Regions of the image brighter than this threshold receive blooming (and potentially lens flares). |
|<span class=component>RGB Threshhold</span> |Chose different threshholds for R, G and B. |


|    |    |
|:---|:---|
|<span class=component>Blur iterations</span> |The number of times gaussian blur is applied. More iterations improve smoothness but take extra time to process and hide small frequencies.|
|<span class=component>Sample distance</span> |The max radius of the blur. Does not affect performance. |
|<span class=component>Use alpha mask</span> |The degree to which the alpha channel acts as a mask for the bloom effect. |


|    |    |
|:---|:---|
|<span class=component>Lens Flares</span> |The type of lens flare. The options are <span class=component>Ghosting</span>, <span class=component>Anamorphic</span> or a mix of the two. |
|<span class=component>Local intensity</span> |Local intensity used only for lens flares. 0 disables lens flares entirely.|
|<span class=component>Local threshold</span> |The accumulative light intensity threshold that defines which image parts are candidates for lens flares. |
|<span class=component>Stretch width</span> |The width for anamorphic lens flares. |
|<span class=component>Rotation</span> |The orientation for anamorphic lens flares. |
|<span class=component>Blur iterations</span> |The number of times blurring is applied to anamorphic lens flares. More iterations improve smoothness but take more processing time. |
|<span class=component>Saturation</span> |(De-)saturates lens flares. If 0, lens flares will fully receive the <span class=component>Tint Color</span>. |
|<span class=component>Tint Color</span> |Color modulation for the anamorphic flare type. |
|<span class=component>1st-4th Color</span> |Color modulation for all lens flares when <span class=component>Ghosting</span> or <span class=component>Combined</span> is chosen. |
|<span class=component>Lens flare mask</span> |Mask used to prevent lens flare artifacts at screen edges.|

Blend Modes: Add and Screen
---------------------------


Blend modes determine the way that two images will be combined when overlaid. Each pixel from the base image is combined mathematically with the pixel in the corresponding position in the overlay image. Two blend modes are available for this image effect, Add and Screen.

###Add Mode

When the images are blended in Add mode, the values of the color channels (red, green and blue) are simply added together and clamped to the maximum value of 1. The overall effect is that areas of each image that aren't especially bright can easily blend to maximum brightness in the result. The final image tends to lose color and detail and so Add mode is useful when a dazzling "white out" effect is required.

###Screen Mode

Screen mode is so named because it simulates the effect of projecting the two source images onto a white screen simultaneously. Each color channel is combined separately but identically to the others. Firstly, the channel values of the two source pixels are inverted (ie, subtracted from 1). Then, the two inverted values are multiplied together and the result is inverted. The result is brighter than either of the two source pixels but it will be at maximum brightness only if one of the source colors was also. The overall effect is that more color variation and detail from the source images is preserved, leading to a gentler effect than Add mode.

(:include imagefx-SM2:)
