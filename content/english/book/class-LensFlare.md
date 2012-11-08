Lens Flare
==========


<span class=keyword>Lens Flares</span> simulate the effect of lights refracting inside camera lens. They are used to represent really bright lights or, more subtly, just to add a bit more atmosphere to your scene.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-LensFlare.png)  
_The Lens Flare <span class=keyword>Inspector</span>_

The easiest way to setup a Lens Flare is just to assign the Flare property of the [Light](class-Light.md). Unity contains a couple of pre-configured Flares in the [Standard Assets package](HOWTO-InstallStandardAssets.md).

Otherwise, create an empty <span class=keyword>GameObject</span> with <span class=menu>GameObject->Create Empty</span> from the menu bar and add the Lens Flare <span class=keyword>Component</span> to it with <span class=menu>Component->Rendering->Lens Flare</span>.  Then and choose the <span class=component>Flare</span> in the Inspector.

To see the effect of Lens Flare in the <span class=keyword>Scene View</span>, check the <span class=menu>Fx</span> button in the Scene View toolbar:


![](http://docwiki.hq.unity3d.com/uploads/Main/LensFlare-FXButton.png)  
_Enable the <span class=menu>Fx</span> button to view Lens Flares in the Scene View_


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Flare</span>       |The [Flare](class-Flare.md) to render. The flare defines all aspects of the lens flare's appearance. |
|<span class=component>Color</span>       |Some flares can be colorized to better fit in with your scene's mood. |
|<span class=component>Brightness</span>  |How large and bright the Lens Flare is. |
|<span class=component>Directional</span> |If set, the flare will be oriented along positive Z axis of the game object. It will appear as if it was infinitely far away, and won't track object's position, only the direction of Z axis. |


Details
-------


You can directly set flares as a property of a [Light](class-Light.md) Component, or set them up separately as Lens Flare component. If you attach them to a light, they will automatically track the position and direction of the light. To get more precise control, use this Component.

A [Camera](class-Camera.md) has to have a [Flare Layer](class-FlareLayer.md) Component attached to make Flares visible (this is true by default, so you don't have to do any set-up).


Hints
-----


* Be discrete about your usage of Lens Flares.
* If you use a very bright Lens Flare, make sure its direction fits with your scene's primary light source.
* To design your own Flares, you need to create some Flare Assets. Start by duplicating some of the ones we provided in the the <span class=menu>Lens Flares</span> folder of the Standard Assets, then modify from that.
* Lens Flares are blocked by <span class=keyword>Colliders</span>.  A Collider in-between the Flare GameObject and the Camera will hide the Flare, even if the Collider does not have a <span class=keyword>Mesh Renderer</span>.
