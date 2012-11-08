Depth of Field 3.4
==================



##u30 Details
<span class=keyword>Depth of Field 3.4</span> is a common postprocessing effect that simulates the properties of a camera lens. The name refers to the fact that the effect was added in Unity 3.4.

##u40 Details
<span class=keyword>Depth of Field 3.4</span> is a common postprocessing effect that simulates the properties of a camera lens. The name refers to the fact that the effect was added in Unity 3.4, but now is superseded by a more modern [Depth Of Field Scatter](script-DepthOfFieldScatter.md) effect which uses optimized techniques to simulate lens blurs and enables better transitions between focal areas. However, depending on the use case, performance might be a lot better in the old 3.4 version as it was developed for older hardware.

In real life, a camera can only focus sharply on an object at a specific distance; objects nearer or farther from the camera will be somewhat out of focus. The blurring not only gives a visual cue about an object's distance but also introduces <span class=component>bokeh</span> which is the term for pleasing visual artifacts that appear around bright areas of the image as they fall out of focus.

An example of the new Depth of Field effect can be seen in the following images, displaying the results of a defocused foreground and a defocused background. Notice how the foreground blur overlaps with the rest while the background doesn't.


![](http://docwiki.hq.unity3d.com/uploads/Main/ImageEffects./DofExample1.png)  
_Only the nearby pipes are in the focal area_


![](http://docwiki.hq.unity3d.com/uploads/Main/ImageEffects./DofExample2.png)  
_Foreground vs Background blurring with Depth of Field_

You might also consider using the [Tilt Shift effect](script-TiltShift.md) for a more straightforward but less sophisticated depth-of-field effect.

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.

Properties
----------


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>General Settings</span> ||
|<span class=component>Resolution</span> |Determines the internal render target sizes. A lower resolution will result in faster rendering and lower memory requirements. |
|<span class=component>Quality</span> |The quality level. Choose between the faster <span class=component>OnlyBackground</span> or the higher-quality <span class=component>BackgroundAndForeground</span> which calculates the depth-of-field defocus for both areas separately. |
|<span class=component>Simple tweak</span> |Switches to a simpler focal model. |
|<span class=component>Visualize focus</span> |This shows the focal plane in the game view to assist learning and debugging. |
|<span class=component>Enable bokeh</span> |This will generate more realistic lens blurs where very bright parts are scaled and overlap. |


|    |    |
|:---|:---|
|<span class=component>Focal Settings</span> ||
|<span class=component>Focal distance</span> |The distance to the focal plane from the camera position in world space. |
|<span class=component>Object Focus</span> |Determine the focal distance using a target object in the scene.|
|<span class=component>Smoothness</span> |The smoothness when transitioning from out-of-focus to in-focus areas. |
|<span class=component>Focal size</span> |The size of the in-focus area. |


|    |    |
|:---|:---|
|<span class=component>Blur</span> ||
|<span class=component>Blurriness</span> |How many iterations are used when blurring the various buffers (each iteration requires processing time).|
|<span class=component>Blur spread</span> |The blur radius. This is resolution-independent, so you may need to readjust the value for each required resolution. |


|    |    |
|:---|:---|
|<span class=component>Bokeh Settings</span> ||
|<span class=component>Destination</span> |Enabling foreground and background blur increases rendering time but gives more realistic results. |
|<span class=component>Intensity</span> |Blend intensity used as bokeh shapes are being accumulated. This is a critical value that always needs to be carefully adjusted.|
|<span class=component>Min luminance</span> |The luminance threshold below which pixels will not have bokeh artifacts applied.  |
|<span class=component>Min contrast</span> |The contrast threshold  below which pixels will not have bokeh artifacts applied. The significance of this is that you usually only need bokeh shapes in areas of high frequency (ie, cluttered or "noisy" areas of image) since they are otherwise nearly invisible. Performance will be improved if you use this parameter to avoid generating unnecessary bokeh artifacts.  |
|<span class=component>Downsample</span> |The size of the internal render target used for accumulating bokeh shapes. |
|<span class=component>Size</span> |The maximum bokeh size. Will be modulated by the amount of defocus (Circle of Confusion). |
|<span class=component>Bokeh Texture</span> |The texture defining the bokeh shapes. |

Note that since the bokeh effect is created by drawing triangles per pixel, it can drastically affect your framerate, especially if it's not adjusted optimally. Adjust the <span class=component>Size</span>, <span class=component>Min luminance</span>, <span class=component>Min contrast</span>, <span class=component>Downsample</span> and <span class=component>Resolution</span> to improve performance. Also, since the screen is darkened before the bokeh shapes are applied, you should use an appropriate <span class=component>Blurriness</span> level to remove possible artefacts.

(:include imagefx-SM3Depth:)
