View Modes
==========


The Scene View control bar lets you choose various options for viewing the scene and also control whether lighting and audio are enabled. These controls only affect the scene view during development and have no effect on the built game.

![](http://docwiki.hq.unity3d.com/uploads/Main/SceneViewControlBar35.png)  
(:comment image source SceneViewToolbarPopups.psd :)


Draw Mode
---------


The first drop-down menu selects which <span class=keyword>Draw Mode</span> will be used to depict the scene.

![](http://docwiki.hq.unity3d.com/uploads/Main/DrawModeDropdown35.png)  
(:comment image source SceneViewToolbarPopups.psd :)
_Draw Mode drop-down_

* __Textured__: show surfaces with their textures visible.
* __Wireframe__: draw meshes with a wireframe representation.
* __Tex-Wire__: show meshes textured and with wireframes overlaid.
* __Render Paths__: show the [rendering path](RenderingPaths) for each object using a color code: Green indicates [deferred lighting](RenderTech-DeferredLighting), yellow indicates [forward rendering](RenderTech-ForwardRendering) and red indicates [vertex lit](RenderTech-VertexLit).
* __Lightmap Resolution__: overlay a checkered grid on the scene to show the resolution of the lightmaps.


Render Mode
-----------


The next drop-down along selects which of four <span class=keyword>Render Modes</span> will be used to render the scene.

![](http://docwiki.hq.unity3d.com/uploads/Main/RenderModeDropdown35.png)  
(:comment image source SceneViewToolbarPopups.psd :)
_Render Mode drop-down_

* __RGB__: render the scene with objects normally colored.
* __Alpha__: render colors with alpha.
* __Overdraw__: render objects as transparent "silhouettes". The transparent colors accumulate, making it easy to spot places where one object is drawn over another.
* __Mipmaps:__ show ideal texture sizes using a color code: red indicates that the texture is larger than necessary (at the current distance and resolution); blue indicates that the texture could be larger. Naturally, ideal texture sizes depend on the resolution at which the game will run and how close the camera can get to particular surfaces.


Scene Lighting, Game Overlay, and Audition Mode
-----------------------------------------------


To the right of the dropdown menus are three buttons which control other aspects of the scene representation.

![](http://docwiki.hq.unity3d.com/uploads/Main/SceneViewButtons35.png)  

The first button determines whether the view will be lit using a default scheme or with the lights that have actually been added to the scene. The default scheme is used initially but this will change automatically when the first light is added. The second button controls whether skyboxes and GUI elements will be rendered in the scene view and also shows and hides the placement grid. The third button switches audio sources in the scene on and off.
