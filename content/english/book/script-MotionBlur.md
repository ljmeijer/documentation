Motion Blur image effect
========================


<span class=keyword>Motion Blur</span> image effect enhances fast-moving scenes by leaving "motion trails" of previously rendered frames.

##u40 Details
For a modern implementation of Motion Blur, please refer to the new [Camera Motion Blur Effect](script-CameraMotionBlur.md).

Like all [image effects](comp-ImageEffects.md), Motion Blur is only available in Unity Pro. Make sure to have the [Pro Standard Assets installed](HOWTO-InstallStandardAssets.md).


![](http://docwiki.hq.unity3d.com/uploads/Main/FxMotionBlur.png)  
_Motion Blur effect applied to the rotating scene_


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Blur Amount</span> |How much of the previous frames to leave in the image. Higher values make longer motion trails. |
|<span class=component>Extra Blur</span>  |If checked, this makes motion trails more blurry, by applying some extra blur to previous frames. |


###Tips:
* Motion Blur only works while in play mode because it's time based.

###Hardware support

Motion Blur effect works all graphics cards that support rendering to a texture. E.g. GeForce2, Radeon 7000 and up. All image effects automatically disable themselves when they can not run on an end-users graphics card.
