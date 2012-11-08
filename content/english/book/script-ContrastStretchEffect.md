Contrast Stretch image effect
=============================


<span class=keyword>Contrast Stretch</span> dynamically adjusts the contrast of the image according to the range of brightness levels it contains. The adjustment takes place gradually over a period of time, so the player can be briefly dazzled by bright outdoor light when emerging from a dark tunnel, say. Equally, when moving from a bright scene to a dark one, the "eye" takes some time to adapt.

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.

Understanding Contrast Stretch
------------------------------


The clarity of detail in an image is largely determined by the range of different brightness values it contains. It is difficult for the eye to distinguish between two brightness levels that differ by less than about 2% and above that, the greater the difference, the stronger the detail. The overall separation between the lightest and darkest values in an image is referred to as the <span class=component>contrast</span> of that image.

It is common for an image to use less than the full range of available brightness values. One way to increase the contrast is to redistribute the pixels' values so as to make better use of the range. The darkest level in the original image is remapped to a even darker level, the brightest to a brighter level and all the levels in between are moved farther apart in proportion. The distribution of levels is then "stretched" out farther across the available range and thus this effect is known as <span class=component>contrast stretch</span>.

Contrast stretching is evocative of the way the eye adapts to different light conditions. When walking from an outdoor area to a dimly lit building, the view will briefly appear indistinct until the contrast is stretched to reveal the detail. When emerging from the building, the contrast stretch will have the effect of making the outdoor scene appear dazzling bright until the "eye" of the player adjusts.


![](http://docwiki.hq.unity3d.com/uploads/Main/FxNone.png)  
_No Contrast Stretch applied._


![](http://docwiki.hq.unity3d.com/uploads/Main/FxContrast1.png)  
_Contrast stretch applied with a dark skybox. Note that buildings get brighter._


![](http://docwiki.hq.unity3d.com/uploads/Main/FxContrast2.png)  
_Contrast stretch applied with a very bright skybox. Note that buildings get darker._

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Adaptation Speed</span> |The speed of the transition.  The lower this number, the slower the transition |
|<span class=component>Limit Minimum</span> |The darkest level in the image after adjustment.|
|<span class=component>Limit Maximum</span> |The brightest level in the image after adjustment.|

###Tips:

* Since Constrast Stretch is applied over a period of time, the full effect is only visible in Play mode.

(:include imagefx-SM2:)

