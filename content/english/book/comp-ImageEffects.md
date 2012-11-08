Image Effect Scripts
====================


This group handles all <span class=keyword>Render Texture</span>-based fullscreen image postprocessing effects. They are only available with Unity Pro. They add a lot to the look and feel of your game without spending much time on artwork.

All image effects make use of Unity's <span class=component>OnRenderImage</span> function which any MonoBehavior attached to a camera can overwrite to accomplish a wide range of custom effects. 

Image effects can be executed directly after the opaque pass or after opaque and transparent passes (default). The former behavior can very easily be acquired by adding the attribute <span class=component>ImageEffectOpaque</span> to the OnRenderImage function of the effect in question. For an example of an effect doing this, have a look at the [Edge Detection effect](script-EdgeDetectEffectNormals.md).

(:tocportion:)

The scene used in above pages looks like this without any image effects applied:


![](http://docwiki.hq.unity3d.com/uploads/Main/FxNone.png)  
_Scene with no image postprocessing effects._

Multiple image effects can be "stacked" on the same camera. Just add them and it will work.


![](http://docwiki.hq.unity3d.com/uploads/Main/FxBlurNoise.png)  
_Blur and Noise applied to the same camera. Yay for noisy blur!_
