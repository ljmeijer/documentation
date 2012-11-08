Camera
======

<span class=keyword>Cameras</span> are the devices that capture and display the world to the player.  By customizing and manipulating cameras, you can make the presentation of your game truly unique.  You can have an unlimited number of cameras in a scene. They can be set to render in any order, at any place on the screen, or only certain parts of the screen.


![](http://docwiki.hq.unity3d.com/uploads/Main/InspectorCamera35.png)  
_Unity's flexible Camera object_

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Clear Flags</span> |Determines which parts of the screen will be cleared.  This is handy when using multiple Cameras to draw different game elements. |
|<span class=component>Background</span> |Color applied to the remaining screen after all elements in view have been drawn and there is no skybox. |
|<span class=component>Culling Mask</span> |Include or omit layers of objects to be rendered by the Camera.  Assign layers to your objects in the Inspector. | 
|<span class=component>Projection</span> |Toggles the camera's capability to simulate perspective. |
|>>><span class=component>Perspective</span> |Camera will render objects with perspective intact. |
|>>><span class=component>Orthographic</span> |Camera will render objects uniformly, with no sense of perspective. |
|<span class=component>Size</span> (when Orthographic is selected) |The viewport size of the Camera when set to Orthographic. |
|<span class=component>Field of view</span> |Width of the Camera's view angle, measured in degrees along the local Y axis. |
|<span class=component>Clipping Planes</span> |Distances from the camera to start and stop rendering. |
|>>><span class=component>Near</span> |The closest point relative to the camera that drawing will occur. |
|>>><span class=component>Far</span> |The furthest point relative to the camera that drawing will occur. |
|<span class=component>Normalized View Port Rect</span> |Four values that indicate where on the screen this camera view will be drawn, in Screen Coordinates (values 0-1). |
|>>><span class=component>X</span> |The beginning horizontal position that the camera view will be drawn. |
|>>><span class=component>Y</span> |The beginning vertical position that the camera view will be drawn. |
|>>><span class=component>W</span> (Width) |Width of the camera output on the screen. |
|>>><span class=component>H</span> (Height) |Height of the camera output on the screen. |
|<span class=component>Depth</span> |The camera's position in the draw order. Cameras with a larger value will be drawn on top of cameras with a smaller value. |
|<span class=component>Rendering Path</span> |Options for defining what rendering methods will be used by the camera. |
|>>><span class=component>Use Player Settings</span> |This camera will use whichever Rendering Path is set in the Player Settings. |
|>>><span class=component>Vertex Lit</span> |All objects rendered by this camera will be rendered as Vertex-Lit objects. |
|>>><span class=component>Forward</span> |All objects will be rendered with one pass per material, as was standard in Unity 2.x. |
|>>><span class=component>Deferred Lighting</span> (Unity Pro only) |All objects will be drawn once without lighting, then lighting of all objects will be rendered together at the end of the render queue. |
|<span class=component>Target Texture</span> (Unity Pro/Advanced only) |Reference to a [Render Texture](class-RenderTexture.md) that will contain the output of the Camera view. Making this reference will disable this Camera's capability to render to the screen. | 
|<span class=component>HDR</span>|Enables High Dynamic Range rendering for this camera.|


Details
-------


Cameras are essential for displaying your game to the player.  They can be customized, scripted, or parented to achieve just about any kind of effect imaginable.  For a puzzle game, you might keep the Camera static for a full view of the puzzle.  For a first-person shooter, you would parent the Camera to the player character, and place it at the character's eye level.  For a racing game, you'd likely want to have the Camera follow your player's vehicle.

You can create multiple Cameras and assign each one to a different <span class=component>Depth</span>.  Cameras are drawn from low <span class=component>Depth</span> to high <span class=component>Depth</span>.  In other words, a Camera with a <span class=component>Depth</span> of 2 will be drawn on top of a Camera with a depth of 1.  You can adjust the values of the <span class=component>Normalized View Port Rectangle</span> property to resize and position the Camera's view onscreen.  This can create multiple mini-views like missile cams, map views, rear-view mirrors, etc.

###Render Path
Unity supports different Rendering Paths. You should choose which one you use depending on your game content and target platform / hardware. Different rendering paths have different features and performance characteristics that mostly affect Lights and Shadows.  
The rendering Path used by your project is chosen in Player Settings. Additionally, you can override it for each Camera.

For more info on rendering paths, check the [rendering paths page](RenderingPaths.md).


###Clear Flags

Each Camera stores color and depth information when it renders its view.  The portions of the screen that are not drawn in are empty, and will display the skybox by default.  When you are using multiple Cameras, each one stores its own color and depth information in buffers, accumulating more data as each Camera renders.  As any particular Camera in your scene renders its view, you can set the <span class=component>Clear Flags</span> to clear different collections of the buffer information. This is done by choosing one of the four options:


####Skybox

This is the default setting.  Any empty portions of the screen will display the current Camera's skybox.  If the current Camera has no skybox set, it will default to the skybox chosen in the [Render Settings](class-RenderSettings.md) (found in <span class=menu>Edit->Render Settings</span>).  It will then fall back to the <span class=component>Background Color</span>. Alternatively a [Skybox component](class-Skybox.md) can be added to the camera. If you want to create a new Skybox, [you can use this guide](HOWTO-UseSkybox.md).


####Solid Color

Any empty portions of the screen will display the current Camera's <span class=component>Background Color</span>.


####Depth Only

If you wanted to draw a player's gun without letting it get clipped inside the environment, you would set one Camera at <span class=component>Depth</span> 0 to draw the environment, and another Camera at <span class=component>Depth</span> 1 to draw the weapon alone.  The weapon Camera's <span class=component>Clear Flags</span> should be set to to <span class=component>depth only</span>.  This will keep the graphical display of the environment on the screen, but discard all information about where each object exists in 3-D space.  When the gun is drawn, the opaque parts will completely cover anything drawn, regardless of how close the gun is to the wall.


![](http://docwiki.hq.unity3d.com/uploads/Main/Camera-ClearFlags.png)  
_The gun is drawn last, after clearing the depth buffer of the cameras before it_


####Don't Clear

This mode does not clear either the color or the depth buffer.  The result is that each frame is drawn over the next, resulting in a smear-looking effect.  This isn't typically used in games, and would likely be best used with a custom shader.


###Clip Planes

The <span class=component>Near</span> and <span class=component>Far Clip Plane</span> properties determine where the Camera's view begins and ends.  The planes are laid out perpendicular to the Camera's direction and are measured from the its position.  The <span class=component>Near plane</span> is the closest location that will be rendered, and the <span class=component>Far plane</span> is the furthest.

The clipping planes also determine how depth buffer precision is distributed over the scene. In general, to get better precision you should move the <span class=component>Near plane</span> as far as possible.

Note that the near and far clip planes together with the planes defined by the field of view of the camera describe what is popularly known as the camera _frustum_.  Unity ensures that when rendering your objects those which are completely outside of this frustum are not displayed.  This is called Frustum Culling.  Frustum Culling happens irrespective of whether you use Occlusion Culling in your game.

For performance reasons, you might want to cull small objects earlier. For example, small rocks and debris could be made invisible at much smaller distance than large buildings. To do that, put small objects into a [separate layer](Layers.md) and setup per-layer cull distances using [Camera.layerCullDistances](ScriptRef:Camera-layerCullDistances.html) script function.

###Culling Mask

The <span class=component>Culling Mask</span> is used for selectively rendering groups of objects using Layers.  More information on using layers can be found [here](Layers.md).

Commonly, it is good practice to put your User Interface on a different layer, then render it by itself with a separate Camera set to render the UI layer by itself.

In order for the UI to display on top of the other Camera views, you'll also need to set the <span class=component>Clear Flags</span> to <span class=component>Depth only</span> and make sure that the UI Camera's <span class=component>Depth</span> is higher than the other Cameras.


###Normalized Viewport Rectangle

<span class=component>Normalized Viewport Rectangles</span> are specifically for defining a certain portion of the screen that the current camera view will be drawn upon.  You can put a map view in the lower-right hand corner of the screen, or a missile-tip view in the upper-left corner.  With a bit of design work, you can use <span class=component>Viewport Rectangle</span> to create some unique behaviors.

It's easy to create a two-player split screen effect using <span class=component>Normalized Viewport Rectangle</span>.  After you have created your two cameras, change both camera H value to be 0.5 then set player one's Y value to 0.5, and player two's Y value to 0.  This will make player one's camera display from halfway up the screen to the top, and player two's camera will start at the bottom and stop halfway up the screen.


![](http://docwiki.hq.unity3d.com/uploads/Main/Camera-Viewport.png)  
_Two-player display created with <span class=component>Normalized Viewport Rectangle</span>_


###Orthographic

Marking a Camera as <span class=component>Orthographic</span> removes all perspective from the Camera's view. This is mostly useful for making isometric or 2D games.

Note that fog is rendered uniformly in orthographic camera mode and may therefore not appear as expected. Read more about why in the [component reference on Render Settings](class-RenderSettings.md).


![](http://docwiki.hq.unity3d.com/uploads/Main/Camera-Non-Ortho-FPS.png)  
_Perspective camera._


![](http://docwiki.hq.unity3d.com/uploads/Main/Camera-Ortho-FPS.png)  
_Orthographic camera. Objects do not get smaller with distance here!_

###Render Texture

This feature is only available for Unity Advanced licenses .  It will place the camera's view onto a [Texture](class-RenderTexture.md) that can then be applied to another object.  This makes it easy to create sports arena video monitors, surveillance cameras, reflections etc.


![](http://docwiki.hq.unity3d.com/uploads/Main/Camera-RenderTexture.png)  
_A Render Texture used to create a live arena-cam_

Hints
-----


* Cameras can be instantiated, parented, and scripted just like any other GameObject.
* To increase the sense of speed in a racing game, use a high <span class=component>Field of View</span>.
* Cameras can be used in physics simulation if you add a <span class=keyword>Rigidbody</span> Component.
* There is no limit to the number of Cameras you can have in your scenes.
* Orthographic cameras are great for making 3D user interfaces
* If you are experiencing depth artifacts (surfaces close to each other flickering), try setting <span class=component>Near Plane</span> to as large as possible.
* Cameras cannot render to the Game Screen and a Render Texture at the same time, only one or the other.
* Pro license holders have the option of rendering a Camera's view to a texture, called Render-to-Texture, for even more unique effects.
* Unity comes with pre-installed Camera scripts, found in <span class=menu>Components->Camera Control</span>.  Experiment with them to get a taste of what's possible.

