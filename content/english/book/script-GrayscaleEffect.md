Grayscale image effect
======================


<span class=keyword>Grayscale</span> is a simple image effect that changes colors to grayscale by default. It can also use a <span class=component>Texture Ramp</span> texture to remap luminance to arbitrary colors.

Like all [image effects](comp-ImageEffects.md), Grayscale is available in Unity Pro only. Make sure to have the [Pro Standard Assets installed](HOWTO-InstallStandardAssets.md).


![](http://docwiki.hq.unity3d.com/uploads/Main/FxGrayscale.png)  
_Grayscale image effect applied to the scene_


Remapping colors
----------------


Grayscale can do a simple version of color correction, i.e. remap grayscale image into arbitrary colors. This can be used for effects like heat vision.

The process of color remapping is very similar to [ColorCorrection](script-ColorCorrectionEffect.md) effect:
1. Take a screenshot of a typical scene in your game.
1. Open it in Photoshop and convert to grayscale.
1. Color correct it using the <span class=menu>Image->Adjustments->Curves</span>.
1. Save the __.acv__ file file from the dialog using <span class=menu>Save...</span>
1. Open <span class=menu>Pro Standard Assets->Image Based->color correction ramp.png</span> in Photoshop
1. Now apply color correction to the ramp image: open <span class=menu>Image->Adjustments->Curves</span> again and load your saved __.acv__ file
1. Select your camera in Unity and select <span class=menu>Component->Image Effects->Grayscale</span> to add the effect. Select your modified color ramp.
1. Hit Play to see the effect in action!

###Details

Color remapping works by remapping the original image luminance through the color ramp image (sized 256x1):
* result color = pixel's color in the ramp image at (OriginalLuminance + <span class=component>RampOffset</span>) index. For example, to invert the colors in the image you only need to flip the original color ramp horizontally (so that it goes from white to black instead of from black to white):


![](http://docwiki.hq.unity3d.com/uploads/Main/FxGrayscaleNegative.png)  
_Grayscale applied to the scene with color ramp that goes from white to black._


A more complex version of color remapping that does arbitrary color correction can be achieved with [ColorCorrection](script-ColorCorrectionEffect.md) image effect.

(:include imagefx-SM2:)

