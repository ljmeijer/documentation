Color Correction image effect
=============================


<span class=keyword>Color Correction</span> allows you apply arbitrary color correction to your scene as a postprocessing effect (just like the Curves tool in Photoshop or Gimp). This page explains how to setup color correction in Photoshop and then apply _exactly_ the same color correction at runtime in Unity.

Like all [image effects](comp-ImageEffects.md), Color Correction is only available in Pro version of Unity. Make sure to have the [Pro Standard Assets installed](HOWTO-InstallStandardAssets.md).


![](http://docwiki.hq.unity3d.com/uploads/Main/FxColorCorr.png)  
_Color correction applied to the scene. Color ramp used (magnified) is shown at the right._


![](http://docwiki.hq.unity3d.com/uploads/Main/ImageEffects./FxColorRamp.png)  
_Color ramp used for the image above._


Getting color correction from Photoshop into Unity
--------------------------------------------------


1. Take a screenshot of a typical scene in your game
1. Open it in Photoshop and color correct using the <span class=menu>Image->Adjustments->Curves</span>
1. Save the __.acv__ file file from the dialog using <span class=menu>Save...</span>
1. Open <span class=menu>Pro Standard Assets->Image Based->color correction ramp.png</span> in Photoshop
1. Now apply color correction to the ramp image: open <span class=menu>Image->Adjustments->Curves</span> again and load your saved __.acv__ file
1. Select your camera in Unity and select <span class=menu>Component->Image Effects->Color Correction</span> to add color correction effect. Select your modified color ramp.
1. Hit Play to see the effect in action!


Details
-------


Color correction works by remapping the original image colors through the color ramp image (sized 256x1):
1. result.red = pixel's red value in ramp image at (original.red + <span class=component>RampOffsetR</span>) index
1. result.green = pixel's green value in ramp image at (original.green + <span class=component>RampOffsetG</span>) index
1. result.blue = pixel's blue value in ramp image at (original.blue + <span class=component>RampOffsetB</span>) index
So for example, to invert the colors in the image you only need to flip the original color ramp horizontally (so that it goes from white to black instead of from black to white).

A simpler version of color remapping that only remaps based on luminance can be achieved with [Grayscale](script-GrayscaleEffect.md) image effect.


###Tips:
* The color correction ramp image should not have mip-maps. Turn them off in <span class=keyword>Import Settings</span>. It should also be set to <span class=keyword>Clamp</span> mode.

(:include imagefx-SM2:)

