Noise image effect
==================


<span class=keyword>Noise</span> is an image postprocessing effect that can simulate both TV and VCR noise.

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.


![](http://docwiki.hq.unity3d.com/uploads/Main/FxNoise.png)  
_Noise effect with high intensity applied to the scene_


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Monochrome</span> |If enabled, Noise is similar to TV noise. If disabled, it more closely resembles VCR noise - it distorts color values in YUV space, so you also get hue changes, mostly towards magenta/green gues. |
|<span class=component>Grain Intensity Min/Max</span> |The intensity of noise takes random values between <span class=component>Min</span> and <span class=component>Max</span>. |
|<span class=component>Grain Size</span> |The size of a single grain texture pixel in screen pixels. Increasing this will make noise grains larger. |
|<span class=component>Scratch Intensity Min/Max</span> |The intensity of additional scratch/dust takes random values between <span class=component>Min</span> and <span class=component>Max</span>. |
|<span class=component>Scratch FPS</span> |Scratches jump to different positions on the screen at this framerate. |
|<span class=component>Scratch Jitter</span> |Scratches can jitter slightly while remaining close to their original positions. |

(:include imagefx-SM2:)

