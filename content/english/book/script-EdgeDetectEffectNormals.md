Edge Detect Effect Normals
==========================


This version of the <span class=keyword>Edge Detect</span> image effect creates outlines around edges by taking the scene geometry into account. Edges are not determined by colour differences but by the surface normals and distance from camera of neighbouring pixels (the surface normal is an "arrow" that indicates the direction the surface is facing at a given pixel position). Generally, where two adjacent pixels have significantly different normals and/or distances from the camera, there is an edge in the scene.

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.


![](http://docwiki.hq.unity3d.com/uploads/Main/EdgeDetectionExampleSciFiScene.png)  
_Example Edge Detection. Note how edge outlines can be smoothed out by adding an Antialiasing effect to follow Edge Detection._

This effect uses the <span class=component>ImageEffectOpaque</span> attribute which enables image effects to be executed before the transparent render passes. By default, image effects are executed after both opaque and transparent passes have been fully rendered.


##u30 Details
Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Mode</span> |Chose the filter type (current options are <span class=component>Thin</span> or <span class=component>Thick</span>). Thick will take more samples into consideration to construct outlines. |


|    |    |
|:---|:---|
|<span class=component>Edge Sensitivity</span> ||
|<span class=component>Depth</span> |The minimum difference between the distances of adjacent pixels that will indicate an edge. |
|<span class=component>Normals</span> |The minimum difference between the normals of adjacent pixels that will indicate an edge. |


|    |    |
|:---|:---|
|<span class=component>Background options</span> ||
|<span class=component>Edges only</span> |Blend the background with a fixed color. |
|<span class=component>Background</span> |The color used when <span class=component>Edges only</span> is > 0. |


###u40 Details
Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Mode</span> |Chose the filter type (see below). |


|    |    |
|:---|:---|
|<span class=component>Depth Sensitivity</span> |The minimum difference between the distances of adjacent pixels that will indicate an edge. |
|<span class=component>Normals Sensitivity</span> |The minimum difference between the normals of adjacent pixels that will indicate an edge. |
|<span class=component>Sampling Distance</span> |Bigger sampling distances (default is 1.0) create thicker edges but also introduce haloing artifacts. |


|    |    |
|:---|:---|
|<span class=component>Edges exponent</span> |Exponent used for Sobel filter. Smaller values detect smaller depth differences as edges. |


|    |    |
|:---|:---|
|<span class=component>Background options</span> ||
|<span class=component>Edges only</span> |Blend the background with a fixed color. |
|<span class=component>Background</span> |The color used when <span class=component>Edges only</span> is > 0. |


Filter Types
------------


The new <span class=component>SobelDepthThin</span> filter offers a way to make edge detection work with other depth based image effects such as Depth of Field, Fog or Motion Blur as edges don't cross an object's silhouette:


![](http://docwiki.hq.unity3d.com/uploads/Main/EdgeDetectionWidthDofExample.png)  
_Edges don't leak into the defocused background and at the same time, the background blur doesn't remove the created edges._

Note that as only depth is used for edge detection, this filter discards edges inside silhouettes.

<span class=component>SobelDepth</span> works similarly but doesn't discard edges outside the silhouette of an object. Hence, the ede detection is more precise but doesn't work well with other depth-based effects.

<span class=component>TriangleDepthNormals</span> is likely the cheapest available filter even though it examines both depth and normals to decide if a pixel resides on an edge, i.e. it detects more than just object silhouettes. A high amount of normal map details however might break this filter.

<span class=component>RobertsCrossDepthNormals</span> shares its properties with the _Triangle_ filter but looks at slightly more samples to determine edges. As a natural byproduct, the resulting edges tend to be thicker.

(:include imagefx-SM2Depth:)
