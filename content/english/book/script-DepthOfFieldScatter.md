Depth of Field
==============


<span class=keyword>Depth of Field</span> is a common postprocessing effect that simulates the properties of a camera lens. This version is a more modern and sophisticated version of the old [Depth of Field 3.4 effect](script-DepthOfField34.md) that works especially well with [HDR](HDR.md) rendering and a [DirectX 11](DirectX11.md) compatible graphics device.

In real life, a camera can only focus sharply on an object at a specific distance; objects nearer or farther from the camera will be somewhat out of focus. The blurring not only gives a visual cue about an object's distance but also introduces <span class=component>Bokeh</span> which is the term for pleasing visual artifacts that appear around bright areas of the image as they fall out of focus. Common <span class=component>Bokeh</span> shapes are discs, hexagons and other shapes of higher level dihedral groups.

While the regular version only supports disc shapes (generated via circular texture sampling), the [DirectX 11](DirectX11.md) version is able to splat any shape as defined by the <span class=component>Bokeh Texture</span>.

An example of Depth of Field effect can be seen in the following image, displaying the results of a focused foreground and a defocused background..


![](http://docwiki.hq.unity3d.com/uploads/Main/ImageEffects./DepthOfFieldScatter.png)  
_The [DirectX11](DirectX11.md) version of this effect can create nicely defined bokeh shapes at a very reasonable cost._

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.

Properties
----------


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Focal Settings</span> ||
|<span class=component>Visualize</span> |Overlay color indicating camera focus. |
|<span class=component>Focal distance</span> |The distance to the focal plane from the camera position in world space. |
|<span class=component>Focal Size</span> |Increase the total focal area. |
|<span class=component>Focus on Transform</span> |Determine the focal distance using a target object in the scene.|
|<span class=component>Aperture</span> | The camera's aperture defining the transition between focused and defocused areas. It is good practice to keep this value as high as possible, as otherwise sampling artifacts might occur, especially when the <span class=component>Max Blur Distance</span> is big. Bigger Aperture values will automatically downsample the image to produce a better defocus. |


|    |    |
|:---|:---|
|```` ||
|<span class=component>Defocus Type</span> |Algorithm used to produce defocused areas. <span class=component>DX11</span> is effectively a bokeh splatting technique while <span class=component>DiscBlur</span> indicates a more traditional (scatter as gather) based blur.|
|<span class=component>Sample Count</span> |Amount of filter taps. Greatly affects performance. |
|<span class=component>Max Blur Distance</span> |Max distance for filter taps. Affects texture cache and can cause undersampling artifacts if value is too big. A value smaller than 4.0 should produce decent results. |
|<span class=component>High Resolution</span> |Perform defocus operations in full resolution. Affects performance but might help reduce unwanted artifacts and produce more defined bokeh shapes. |


|    |    |
|:---|:---|
|```` ||
|<span class=component>Near Blur</span> |Foreground areas will overlap at a performance cost. |
|<span class=component>Overlap Size</span> |Increase foreground overlap dilation if needed. |


|    |    |
|:---|:---|
|<span class=component>DX11 Bokeh Settings</span> ||
|<span class=component>Bokeh Texture</span> |Texture defining bokeh shape.|
|<span class=component>Bokeh Scale</span> |Size of bokeh texture.|
|<span class=component>Bokeh Intensity</span> |Blend strength of bokeh shapes.|
|<span class=component>Min Luminance</span> |Only pixels brighter than this value will cast bokeh shapes. Affects performance as it limits overdraw to a more reasonable amount.|
|<span class=component>Spawn Heuristic</span> |Bokeh shapes will only be cast if pixel in questions passes a frequency check. A threshhold around 0.1 seems like a good tradeoff between performance and quality.|

Comparison between DirectX11 and DiscBlur settings
--------------------------------------------------



![](http://docwiki.hq.unity3d.com/uploads/Main/HighRezBokeh.png)  
_Smooth transitions are possible with the high resolution DX11 version (albeit at a high performance cost)._


![](http://docwiki.hq.unity3d.com/uploads/Main/BokehDisc.png)  
_Due to the nature of the standard DiscBlur texture sampling approach, the maximum blur radius is limited before sampling artifacts become appearant. Also, only spherical Bokeh shapes are possible._

About DirectX 11 Bokeh Splatting
--------------------------------


This powerful technique enables proper Scattering, however due to high demands on fillrate, it should be used with care. The parameters <span class=component>Spawn Heuristic</span> and <span class=component>Min Luminance</span> control when and where Bokeh Sprites will be placed. If pixels don't pass a luminance and frequency check, a simple Box Blur will be used instead. It's however hard to notice as it uses the same kernel width as the Bokeh sprites. 

The following pictures show that the road, that is neither bright nor bears great frequency changes can just be blurred with a simple box filter without ruining the overall <span class=component>Bokeh</span> experience.


![](http://docwiki.hq.unity3d.com/uploads/Main/BokehSplatting1.png)  
_Example with small <span class=component>Max Blur Distance</span>_


![](http://docwiki.hq.unity3d.com/uploads/Main/BokehSplatting2.png)  
_Example with big <span class=component>Max Blur Distance</span>_



(:include imagefx-SM3Depth:)
