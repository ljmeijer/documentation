Skybox
======


<span class=keyword>Skyboxes</span> are a wrapper around your entire scene that display the vast beyond of your world.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-Skybox.png)  
_One of the default Skyboxes found under <span class=menu>Standard Assets->Skyboxes</span>_


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Material</span> |The <span class=keyword>Material</span> used to render the Skybox, which contains 6 <span class=keyword>Textures</span>. This Material should use the Skybox Shader, and each of the textures should be assigned to the proper global direction. |


Details
-------


Skyboxes are rendered before anything else in the scene in order to give the impression of complex scenery at the horizon. They are a box of 6 textures, one for each primary direction (+/-X, +/-Y, +/-Z).

You have two options for implementing Skyboxes.  You can add them to an individual [Camera](class-Camera.md) (usually the main Camera) or you can set up a default Skybox in [Render Settings's](class-RenderSettings.md) <span class=component>Skybox Material</span> property.  The [Render Settings](class-RenderSettings.md) is most useful if you want all Cameras in your scene to share the same Skybox.

Adding the Skybox <span class=keyword>Component</span> to a Camera is useful if you want to override the default Skybox set up in the Render Settings.  E.g. You might have a split screen game using two Cameras, and want the Second camera to use a different Skybox.  To add a Skybox Component to a Camera, click to highlight the Camera and go to <span class=menu>Component->Rendering->Skybox</span>.

Unity's Standard Assets contain 2 pre-setup Skybox materials in <span class=menu>Standard Assets->Skyboxes</span>.

If you want to create a new Skybox, [use this guide](HOWTO-UseSkybox.md).


Hints
-----


* If you have a Skybox assigned to a Camera, make sure to set the Camera's <span class=component>Clear mode</span> to Skybox.
* It's a good idea to match your Fog color to the skybox's color. Fog color can be set in [Render Settings](class-RenderSettings.md).
