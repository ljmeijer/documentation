Sun Shafts
==========


The <span class=keyword>Sun Shafts</span> image effect simulates the radial light scattering (also known as the "god ray" effect) that arises when a very bright light source is partly obscured.

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.


![](http://docwiki.hq.unity3d.com/uploads/Main/ImageEffects./sunShaftsExample.png)  
_Example of the Sun Shafts effect_

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Rely on Z Buffer</span> |This option can be used when no depth textures are available or they are too expensive to calculate (eg, in forward rendering with a large number of objects). Note that if this option is disabled then Sun Shafts must be the very first image effect applied to the camera.|
|<span class=component>Resolution</span> |The resolution at which the shafts are generated. Lower resolutions are faster to calculate and create softer results. |
|<span class=component>Blend Mode</span> |Chose between the softer <span class=component>Screen</span> mode and the simpler <span class=component>Add</span> mode. |


|    |    |
|:---|:---|
|<span class=component>Sun Transform</span> |The transform of the light source that casts the Sun Shafts. Only the position is significant. |
|<span class=component>Center on ...</span>|Within the editor, position the <span class=component>Sun Transform</span> object at the center of the game view camera.|


|    |    |
|:---|:---|
|<span class=component>Shafts color</span> |The tint color of the shafts. |
|<span class=component>Distance falloff</span> |The degree to which the shafts' brightness diminishes with distance from the <span class=component>Sun Transform</span> object. |


|    |    |
|:---|:---|
|<span class=component>Blur size</span> |The radius over which pixel colours are combined during blurring. |
|<span class=component>Blur iterations</span> |The number of repetitions of the blur operation. More iterations will give smoother blurring but each has a cost in processing time.|


|    |    |
|:---|:---|
|<span class=component>Intensity</span> |The brightness of the generated shafts. |
|<span class=component>Use alpha mask</span> |Defines how much the alpha channel of the color buffer should be used when generating Sun Shafts. This is useful when your skybox has a proper alpha channel that defines a mask (eg, for clouds blocking the sun shafts). |

Blend Modes: Add and Screen
---------------------------


Blend modes determine the way that two images will be combined when overlaid. Each pixel from the base image is combined mathematically with the pixel in the corresponding position in the overlay image. Two blend modes are available for Unity image effects, Add and Screen.

###Add Mode

When the images are blended in Add mode, the values of the color channels (red, green and blue) are simply added together and clamped to the maximum value of 1. The overall effect is that areas of each image that aren't especially bright can easily blend to maximum brightness in the result. The final image tends to lose color and detail and so Add mode is useful when a dazzling "white out" effect is required.

###Screen Mode

Screen mode is so named because it simulates the effect of projecting the two source images onto a white screen simultaneously. Each color channel is combined separately but identically to the others. Firstly, the channel values of the two source pixels are inverted (ie, subtracted from 1). Then, the two inverted values are multiplied together and the result is inverted. The result is brighter than either of the two source pixels but it will be at maximum brightness only if one of the source colors was also. The overall effect is that more color variation and detail from the source images is preserved, leading to a gentler effect than Add mode.

(:include imagefx-SM2Depth:)

