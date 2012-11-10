Flare
=====


<span class=keyword>Flare</span> objects are the source assets that are used by [Lens Flare Components](class-LensFlare.md). The Flare itself is a combination of a texture file and specific information that determines how the Flare behaves.  Then when you want to use the Flare in a <span class=keyword>Scene</span>, you reference the specific Flare from inside a <span class=keyword>LensFlare</span> <span class=keyword>Component</span> attached to a <span class=keyword>GameObject</span>.

There are some sample Flares in the [Standard Assets](HOWTO-InstallStandardAssets.md) package. If you want to add one of these to your scene, attach a [Lens Flare](class-LensFlare.md) Component to a GameObject, and drag the Flare you want to use into the <span class=component>Flare</span> property of the Lens Flare, just like assigning a <span class=keyword>Material</span> to a <span class=keyword>Mesh Renderer</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/FlareInspector.png)  
_The Flare <span class=keyword>Inspector</span>_

Flares work by containing several Flare <span class=component>Elements</span> on a single <span class=keyword>Texture</span>.  Within the Flare, you pick & choose which <span class=component>Elements</span> you want to include from any of the Textures. 

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Elements</span> |The number of Flare images included in the Flare. |
|>>><span class=component>Image Index</span> |Which Flare image to use from the <span class=component>Flare Texture</span> for this Element.  See the [Flare Textures](#FlareTextures) section below for more information. |
|>>><span class=component>Position</span> |The Element's offset along a line running from the containing GameObject's position through the screen center. 0 = GameObject position, 1 = screen center. |
|>>><span class=component>Size</span> |The size of the element. |
|>>><span class=component>Color</span> |Color tint of the element. |
|>>><span class=component>Use Light Color</span> |If the Flare is attached to a Light, enabling this will tint the Flare with the Light's color. |
|>>><span class=component>Rotate</span> |If enabled, bottom of the Element will always face the center of the screen, making the Element spin as the Lens Flare moves around on the screen. |
|>>><span class=component>Zoom</span> |If enabled, the Element will scale up when it becomes visible and scale down again when it isn't. |
|>>><span class=component>Fade</span> |If enabled, the Element will fade in to full strength when it becomes visible and fade out when it isn't. |
|<span class=component>Flare Texture</span> |A texture containing images used by this Flare's <span class=component>Elements</span>. It must be arranged according to one of the <span class=component>TextureLayout</span> options. |
|<span class=component>Texture Layout</span> |How the individual Flare Element images are laid out inside the <span class=component>Flare Texture</span>.  

![](http://docwiki.hq.unity3d.com/uploads/Main/FlareLayouts.png)  
|<span class=component>Use Fog</span> |If enabled, the Flare will fade away with distance fog. This is used commonly for small Flares. |


Details
-------


A Flare consists of multiple <span class=component>Elements</span>, arranged along a line. The line is calculated by comparing the position of the GameObject containing the Lens Flare to the center of the screen.  The line extends beyond the containing GameObject and the screen center.  All Flare <span class=component>Elements</span> are strung out on this line.


<a id="FlareTextures"></a>
Flare Textures
--------------


For performance reasons, all <span class=component>Elements</span> of one Flare must share the same Texture. This Texture contains a collection of the different images that are available as Elements in a single Flare. The <span class=component>Texture Layout</span> defines how the <span class=component>Elements</span> are laid out in the <span class=component>Flare Texture</span>.


###Texture Layouts

These are the options you have for different Flare <span class=component>Texture Layouts</span>.  The numbers in the images correspond to the <span class=component>Image Index</span> property for each <span class=component>Element</span>.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>1 Large 4 Small</span> |Attach:FlaresLayout0.png  
Designed for large sun-style Flares where you need one of the <span class=component>Elements</span> to have a higher fidelity than the others.  This is designed to be used with Textures that are twice as high as they are wide. |
|<span class=component>1 Large 2 Medium 8 Small</span> |Attach:FlaresLayout1.png  
Designed for complex flares that require 1 high-definition, 2 medium & 8 small images.  This is used in the standard assets "50mm Zoom Flare" where the two medium Elements are the rainbow-colored circles. This is designed to be used with textures that are twice as high as they are wide. |
|<span class=component>1 Texture</span> |Attach:FlaresLayout2.png  
A single image. |
|<span class=component>2x2 grid</span> |Attach:FlaresLayout3.png  
A simple 2x2 grid. |
|<span class=component>3x3 grid</span> |Attach:FlaresLayout4.png  
A simple 3x3 grid. |
|<span class=component>4x4 grid</span> |Attach:FlaresLayout5.png  
A simple 4x4 grid. |

Hints
-----

* If you use many different Flares, using a single <span class=component>Flare Texture</span> that contains all the <span class=component>Elements</span> will give you best rendering performance.
* Lens Flares are blocked by <span class=keyword>Colliders</span>.  A Collider in-between the Flare GameObject and the Camera will hide the Flare, even if the Collider does not have a <span class=keyword>Mesh Renderer</span>.
