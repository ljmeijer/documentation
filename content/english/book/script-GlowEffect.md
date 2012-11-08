Glow image effect
=================


<span class=keyword>Glow</span> (sometimes called "Bloom") can dramatically enhance the rendered image by making overbright parts "glow" (e.g. sun, light sources, strong highlights). 

##u30 Details

##u40 Details
The [Bloom](script-Bloom.md) image effect gives greater control over the glow but has a bit higher processing overhead.

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.


![](http://docwiki.hq.unity3d.com/uploads/Main/FxGlow.png)  
_Glow effect applied to the scene_

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Glow Intensity</span> |Total brightness at the brightest spots of the glowing areas. |
|<span class=component>Blur Iterations</span> |Number of times the glow is blurred when being drawn. Each iteration requires processing time.|
|<span class=component>Blur Spread</span> |The pixel distance over which pixels are combined to produce blurring.|
|<span class=component>Glow Tint</span> |Color tint applied to the glow. |
|<span class=component>Downsample Shader</span> |The shader used for the glow. You generally should not have to change this. |


Details
-------


Glow uses the alpha channel of the final image to represent "color brightness". All colors are treated as RGB, multiplied by the alpha channel. You can view the contents of the alpha channel in <span class=keyword>Scene View</span>.

All built-in shaders write the following information to alpha:

* Main texture's alpha multiplied by main color's alpha (not affected by lighting).
* Specular shaders add specular highlight multiplied by specular color's alpha.
* Transparent shaders do not modify alpha channel at all.
* Particle shaders do not modify alpha channel, except for Particles/Multiply which darkens anything that is in alpha.
* Skybox shaders write alpha of the texture multiplied by tint alpha

Most of the time you'll want to do this to get reasonable glow:

* Set material's main color alpha to zero or use a texture with zero alpha channel. In the latter case, you can put non-zero alpha in the texture to cause these parts to glow.
* Set the specular color alpha for Specular shaders to be 100%.
* Keep in mind what alpha the camera clears to (if it clears to a solid color), or what alpha the skybox material uses.
* Add the Glow image effect to the camera. Tweak _Glow Intensity_ and _Blur Iterations_ values, you can also take a look at the comments in the shader script source.
* The alpha channel on the Skybox can be used to great effect to add more glow when looking at the sun


###Tips:
* Use the alpha rendering mode in the scene view toolbar to quickly see which objects output different values to the alpha channel.

(:include imagefx-SM2:)
