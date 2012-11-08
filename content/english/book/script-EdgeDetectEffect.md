Edge Detection image effect
===========================


<span class=keyword>Edge Detect</span> image effect adds black edges to the image wherever color differences exceed some threshold.

If more sophisticated geometry-based edge detection is required, the Standard Assets also provide such a [normals and depth-based edge detection](script-EdgeDetectEffectNormals.md) effect.

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.


![](http://docwiki.hq.unity3d.com/uploads/Main/FxEdge.png)  
_Edge Detect image effect applied to the scene_


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Threshold</span> |Edges will be displayed wherever the color difference between neighboring pixels exceeds this value. Increasing the value will make edges less sensitive to texture or lighting changes. |

(:include imagefx-SM2:)

