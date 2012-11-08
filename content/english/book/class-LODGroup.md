Level of Detail (Pro Only)
==========================


As your scenes get larger, performance becomes a bigger consideration. One of the ways to manage this is to have meshes with different levels of detail depending on how far the camera is from the object. 
This is called <span class=keyword>Level of Detail</span> (abbreviated as <span class=keyword>LOD</span>) 

Here's one of the ways to set up an object with different <span class=keyword>LODs</span>.\

1. Create an empty <span class=component>Game Object</span> in the scene
1. Create 2 versions of the mesh, a high-res mesh (for <span class=component>L0D:0</span>, when camera is the closest), and a low-res mesh (for <span class=component>L0D:1</span>, when camera is further away)
1. Add a <span class=component>LODGroup</span> component to this object (<span class=menu>Component</span>-><span class=menu>Rendering</span>-><span class=menu>LOD Group</span>)
1. Drag in the object with the high-res mesh onto the first <span class=component>Renderers</span> box for <span class=component>L0D:0</span>. Say yes to the "Reparent game objects?" dialog
1. Drag in the object with the low-res mesh onto the first <span class=component>Renderers</span> box for <span class=component>LOD:1</span>. Say yes to the "Reparent game objects?" dialog
1. Right Click on <span class=component>LOD:2</span> and remove it.

At this point the empty object should contain both versions of the mesh, and "know" which mesh to show depending on how far away the camera is. 

You can preview the effect of this, by dragging the camera icon left and right in the window for the <span class=component>LODGroup</span> component.


![](http://docwiki.hq.unity3d.com/uploads/Main/LOD0_demo.jpg)  
>_camera at LOD 0_

![](http://docwiki.hq.unity3d.com/uploads/Main/LOD1_demo.jpg)  
>_camera at LOD 1_

In the <span class=keyword>Scene View</span>, you should be able to see
* Percentage of the view this object occupies
* What <span class=keyword>LOD</span> is currently being displayed
* The number of triangles

LOD-based naming conventions in the asset import pipeline
---------------------------------------------------------


In order to simplify setup of LODs, Unity has a naming convention for models that are being imported.
 
Simply create your meshes in your modelling tool with names ending with _LOD0, _LOD1, _LOD2, etc., and the LOD group with appropriate settings will be created for you. 

Note that the convention assumes that the LOD 0 is the highest resolution model.

Setting up LODs for different platforms
---------------------------------------


You can tweak your LOD settings for each platform in [Quality Settings](class-QualitySettings.md), in particular the properties of <span class=menu>LOD bias</span> and <span class=menu>Maximum LOD Level</span>. 

Utilities
---------

Here are some options that help you work with LODs


|    |    |
|:---|:---|
|Recalculate Bounds|If there is new geometry added to the LODGroup, that is not reflected in the bounding volume, press this to update the bounds. One example where this is needed is when one of the geometries is part of a [prefab](Prefabs.md), and new geometry is added to that prefab. Geometry added directly to the LODGroup will automatically updates the bounds|
|Update Lightmaps|Updates the <span class=component>Scale in Lightmap</span> property in the [lightmaps](Lightmapping.md) based on the LOD level boundaries.|
|Upload to Importer|Uploads the LOD level boundaries to the importer|
