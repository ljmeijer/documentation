Blur image effect
=================


The <span class=keyword>Blur</span> image effect blurs the rendered image in real-time.

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.


![](http://docwiki.hq.unity3d.com/uploads/Main/FxBlur.png)  
_Blur effect applied to the scene_


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Iterations</span> |The number of times the basic blur operation will be repeated. More iterations typically give a better result but each has a cost in processing time. |
|<span class=component>Blur Spread</span> |Higher values will spread out the blur more at the same iteration count but at some cost in quality. Usually values from 0.6 to 0.7 are a good compromise between quality and speed. |

(:include imagefx-SM2:)

