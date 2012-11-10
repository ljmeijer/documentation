Render Settings
===============


The <span class=keyword>Render Settings</span> contain default values for a range of visual elements in your scene, like <span class=keyword>Lights</span> and <span class=keyword>Skyboxes</span>.

To see the Render Settings choose <span class=menu>Edit->Render Settings</span> from the menu bar.


![](http://docwiki.hq.unity3d.com/uploads/Main/RenderSet.png)  


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Fog</span> |If enabled, fog will be drawn throughout your scene. |
|<span class=component>Fog Color</span> |Color of the fog. |
|<span class=component>Fog Mode</span> |Fog mode: Linear, Exponential (Exp) or Exponential Squared (Exp2). This controls the way fog fades in with distance. |
|<span class=component>Fog Density</span> |Density of the fog; only used by Exp and Exp2 fog modes. |
|<span class=component>Linear Fog Start/End</span> |Start and End distances of the fog; only used by Linear fog mode. |
|<span class=component>Ambient Light</span> |Color of the scene's ambient light. |
|<span class=component>Skybox Material</span> |Default skybox that will be rendered for cameras that have no skybox attached. |
|<span class=component>Halo Strength</span> |Size of all light halos in relation to their <span class=component>Range</span>. |
|<span class=component>Flare Strength</span> |Intensity of all flares in the scene. |
|<span class=component>Halo Texture</span> |Reference to a [Texture](class-Texture2D.md) that will appear as the glow for all Halos in lights. |
|<span class=component>Spot Cookie</span> |Reference to a Texture2D that will appear as the cookie mask for all Spot lights. |


Details
-------


The Render Settings is used to define some basic visual commonalities of any individual scene in your project.  Maybe you have two levels in the same environment: one at daytime and one at nighttime.  You can use the same meshes and Prefabs to populate the scene, but you can change the <span class=component>Ambient Light</span> to be much brighter at daytime, and much darker at night.


###Fog

Enabling <span class=component>Fog</span> will give a misty haze to your scene.  You can adjust the look and color of the Fog with <span class=component>Fog Density</span> and <span class=component>Fog Color</span>, respectively.

Adding fog is often used to optimize performance by making sure that far away objects fade out and are not drawn.  Please note that enabling fog is not enough to enable this performance optimization. To do that you also need to adjust your [Camera's](class-Camera.md) <span class=component>Far Clip Plane</span>, so that geometry far away will not be drawn. It is best to tweak the fog to look correct first. Then make the [Camera's](class-Camera.md) far clip plane smaller until you see the geometry being clipped away before the fog fades it out.


![](http://docwiki.hq.unity3d.com/uploads/Main/RenderSettings-FogOff.png)  
_A scene with Fog turned off_


![](http://docwiki.hq.unity3d.com/uploads/Main/RenderSettings-FogOn.png)  
_The same scene with Fog turned on_

Note that fog is rendered uniformly in orthographic camera mode. This is because in our shaders, we output post-perspective space Z coordinate as the fog coordinate. But post-perspective Z is not really suitable for fog in orthographic cameras. Why do we do this? Because it's fast and does not need any extra computations; handling orthographic cameras would make all shaders be a bit slower.

Hints
-----

* Don't under-estimate the visual impact your game can make by thoughtfully tweaking the Render Settings!
* Render Settings are per-scene: each scene in your game can have different Render Settings.
