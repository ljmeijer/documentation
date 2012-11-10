Occlusion Culling (Pro only)
============================


Occlusion Culling is a feature that disables rendering of objects when they are not currently seen by the camera because they are obscured by other objects. This does not happen automatically in 3D computer graphics since most of the time objects farthest away from the camera are drawn first and closer objects are drawn over the top of them (this is called "overdraw"). Occlusion Culling is different from Frustum Culling. Frustum Culling only disables the renderers for objects that are outside the camera's viewing area but does not disable anything hidden from view by overdraw.  Note that when you use Occlusion Culling you will still benefit from Frustum Culling.


![](http://docwiki.hq.unity3d.com/uploads/Main/OcclusionCullingOff.png)  
_The scene rendered without Occlusion Culling_


![](http://docwiki.hq.unity3d.com/uploads/Main/OcclusionCullingOn.png)  
_The same scene rendered with Occlusion Culling_

The occlusion culling process will go through the scene using a virtual camera to build a hierarchy of potentially visible sets of objects. This data is used at runtime by each camera to identify what is visible and what is not. Equipped with this information, Unity will ensure only visible objects get sent to be rendered. This reduces the number of draw calls and increases the performance of the game.

The data for occlusion culling is composed of cells. Each cell is a subdivision of the entire bounding volume of the scene. More specifically the cells form a binary tree. Occlusion Culling uses two trees, one for View Cells (Static Objects) and the other for Target Cells (Moving Objects). View Cells map to a list of indices that define the visible static objects which gives more accurate culling results for static objects.

It is important to keep this in mind when creating your objects because you need a good balance between the size of your objects and the size of the cells. Ideally, you shouldn't have cells that are too small in comparison with your objects but equally you shouldn't have objects that cover many cells. You can sometimes improve the culling by breaking large objects into smaller pieces. However, you can still merge small objects together to reduce draw calls and, as long as they all belong to the same cell, occlusion culling will not be affected.  The collection of cells and the visibility information that determines which cells are visible from any other cell is known as a PVS (__P__otentially __V__isible __S__et).


Setting up Occlusion Culling
----------------------------


In order to use Occlusion Culling, there is some manual setup involved.  First, your level geometry must be broken into sensibly sized pieces. It is also helpful to lay out your levels into small, well defined areas that are occluded from each other by large objects such as walls, buildings, etc.  The idea here is that each individual mesh will be turned on or off based on the occlusion data.  So if you have one object that contains all the furniture in your room then either all or none of the entire set of furniture will be culled.  This doesn't make nearly as much sense as making each piece of furniture its own mesh, so each can individually be culled based on the camera's view point.

You need to tag all scene objects that you want to be part of the occlusion to <span class=menu>Occlusion Static</span> in the <span class=keyword>Inspector</span>. The fastest way to do this is to multi-select the objects you want to be included in occlusion calculations, and mark them as <span class=menu>Occlusion Static</span> and <span class=menu>Occludee Static</span>. 


![](http://docwiki.hq.unity3d.com/uploads/Main/OcclusionStaticDropdown.png)  
_Marking an object for Occlusion_

When should I use <span class=menu>Occludee Static</span>? Transparent objects that do not occlude, as well as small objects that are unlikely to occlude other things, should be marked as <span class=menu>Occludees</span>, but not <span class=menu>Occluders</span>. This means they will be considered in occlusion by other objects, but will not be considered as occluders themselves, which will help reduce computation. 

Occlusion Culling Window
------------------------

For most operations dealing with Occlusion Culling, we recommend you use the Occlusion Culling Window (<span class=menu>Window->Occlusion Culling</span>)

In the Occlusion Culling Window, you can work with occluder meshes, and [Occlusion Areas](class-OcclusionArea.md). 

If you are in the <span class=menu>Object</span> tab of the <span class=menu>Occlusion Culling Window</span> and have some [Mesh Renderer](class-MeshRenderer.md) selected in the scene, you can modify the relevant Static flags:

![](http://docwiki.hq.unity3d.com/uploads/Main/OcclusionCullingInspectorObject.png)  
_Occlusion Culling Window for a Mesh Renderer_

If you are in the <span class=menu>Object</span> tab of the <span class=menu>Occlusion Culling Window</span> and have an [Occlusion Area](class-OcclusionArea.md) selected, you can work with relevant OcclusionArea properties (for more details go to the [Occlusion Area](class-OcclusionArea.md) section)

![](http://docwiki.hq.unity3d.com/uploads/Main/OcclusionCullingInspectorOcclusionArea.png)  
_Occlusion Culling Window for the Occlusion Area_

__NOTE:__ By default if you don't create any occlusion areas, occlusion culling will be applied to the whole scene.

__NOTE:__ Whenever your camera is outside occlusion areas, occlusion culling will not be applied. It is important to set up your Occlusion Areas to cover the places where the camera can potentially be, but making the areas too large, incurs a cost during baking. 



Occlusion Culling - Bake
------------------------



![](http://docwiki.hq.unity3d.com/uploads/Main/OcclusionCullingInspectorBake.png)  
_Occlusion culling inspector bake tab._

Properties
----------


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Technique</span> |Select between the types of occlusion culling baking |
|>>><span class=component>PVS only</span> |Only static objects will be occlusion culled. Dynamic objects will be culled based on the view frustrum only. this technique has the smallest overhead on the CPU, but since dynamic objects are not culled, it is only recommended for games with few moving objects and characters. Since all visibility is precomputed, you cannot open or close portals at runtime. |
|>>><span class=component>PVS and dynamic objects</span> |Static objects are culled using precomputed visibility. Dynamic objects are culled using portal culling. this technique is a good balance between runtime overhead and culling efficiency. Since all visibility is precomputed, you cannot open or close a portal at runtime |
|>>><span class=component>Automatic Portal Generation</span> |Portals are generated automatically. Static and dynamic objects are culled through portals. This allows you to open and close portals at runtime. This technique will cull objects most accurately, but also has the most performance overhead on the CPU. 
|<span class=component>View Cell Size</span> |Size of each view area cell. A smaller value produces more accurate occlusion culling. The value is a tradeoff between occlusion accuracy and storage size|
|<span class=component>Near Clip Plane</span> |Near clip plane should be set to the smallest near clip plane that will be used in the game of all the cameras.|
|<span class=component>Far Clip Plane</span> |Far Clip Plane used to cull the objects. Any object whose distance is greater than this value will be occluded automatically.(Should be set to the largest far clip planed that will be used in the game of all the cameras)|
|<span class=component>Memory limit</span> |This is a hint for the PVS-based baking, not available in _Automatic Portal Generation_ mode
When you have finished tweaking these values you can click on the <span class=menu>Bake</span> Button to start processing the Occlusion Culling data. If you are not satisfied with the results, you can click on the <span class=menu>Clear</span> button to remove previously calculated data.

Occlusion Culling - Visualization
---------------------------------



![](http://docwiki.hq.unity3d.com/uploads/Main/OcclusionCullingInspectorVisualization.png)  
_Occlusion culling inspector visualization tab._

The near and far planes define a virtual camera that is used to calculate the occlusion data. If you have several cameras with different near or far planes, you should use the smallest near plane and the largest far plane distance of all cameras for correct inclusion of objects. 


All the objects in the scene affect the size of the bounding volume so try to keep them all within the visible bounds of the scene.


When you're ready to generate the occlusion data, click the <span class=menu>Bake</span> button. Remember to choose the <span class=menu>Memory Limit</span> in the <span class=menu>Bake</span> tab. Lower values make the generation quicker and less precise, higher values are to be used for production quality closer to release. 

Bear in mind that the time taken to build the occlusion data will depend on the cell levels, the data size and the quality you have chosen.  Unity will show the status of the PVS generation at the bottom of the main window.

After the processing is done, you should see some colorful cubes in the View Area.  The colored areas are regions that share the same occlusion data.

Click on <span class=menu>Clear</span> if you want to remove all the pre-calculated data for Occlusion Culling.

(:include class-OcclusionArea:)
(:include class-OcclusionPortal:)
