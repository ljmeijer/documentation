Noise And Grain
===============


The <span class=keyword>Noise And Grain</span> image effect simulates noise and film grain which is a typical effect happening in film or photography. This special noise implementation can even be used to enhance image contrast as it's using a special blend mode. It also enables typical noise scenarios, such as as low level light noise or softening glowing halo's or bloom borders.

The [DirectX 11](DirectX11.md) implementation is totally independent of any texture reads and thus a good fit for modern graphics hardware. 

The standard version uses a noise texture that should have an average luminance of 0.5 to prevent unwanted brightness changes of the resulting image. The used default texture is an example for this.


![](http://docwiki.hq.unity3d.com/uploads/Main/ImageEffects./NoiseAndGrain.png)  
_Example screenshot of the effect. Notice its smoothness, how it sticks mostly to bright and dark areas and that it has a distinct blue tint._

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>[DirectX11](DirectX11.md) Grain</span> |Enable high quality noise and grain (DX11 only).|
|<span class=component>Monochrome</span> |Use greyscale noise only.|
|<span class=component>Intensity Multiplier</span> |Global intensity adjustment.|
|<span class=component>General</span> |Add noise equally for all luminance ranges.|
|<span class=component>Black Boost</span> |Add extra low luminance noise.|
|<span class=component>White Boost</span> |Add extra high luminance noise.|
|<span class=component>Mid Grey</span> |Defines ranges for high-level and low-level noise ranges above.|
|<span class=component>Color Weights</span> |Additionally tint noise.|


|    |    |
|:---|:---|
|<span class=component>Texture</span> |Texture used for non-DX11 mode.|
|<span class=component>Filter</span> |Texture filtering.|
|<span class=component>Softness</span> |Defines noise or grain crispness. Higher values might yield better performance but require temporary a render target.|


|    |
|:---|
|<span class=component>Advanced</span> |
|<span class=component>Tiling</span> |Noise pattern tiling (can be tweaked for all color channels individually when in non-DX11 texture mode).|

(:include imagefx-SM2:)

