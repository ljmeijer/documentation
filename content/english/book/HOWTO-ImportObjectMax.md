Importing Objects From 3D Studio Max
====================================


If you make your 3D objects in 3dsMax, you can save your .max files directly into your <span class=keyword>Project</span> or export them into Unity using the __Autodesk .FBX__ or other genric formats. 
Unity imports meshes from 3ds Max. Saving a Max file or exporting a generic 3D file type each has advantages and disadvantages see [class-Mesh](class-Mesh.md)
--------------------------------------------------------------------------------------------------------------------------------------------------------------


1. All nodes with position, rotation and scale. Pivot points and Names are also imported.
1. Meshes with vertex colors, normals and one or [two UV sets](#twouvs).
1. Materials with diffuse texture and color. Multiple materials per mesh.
1. Animations.
1. [Bone based animations](#bones).

To manually export to FBX from 3DS Max
--------------------------------------

1. Download the latest fbx exporter from [Autodesk website](http://autodesk.com/fbx.md) and install it.
1. Export your scene or selected objects (<span class=menu>File->Export</span> or <span class=menu>File->Export Selected</span>) in __.fbx__ format. Using default export options should be okay.
1. Copy the exported fbx file into your Unity project folder.
1. When you switch back into Unity, the __.fbx__ file is imported automatically.
1. Drag the file from the <span class=keyword>Project View</span> into the <span class=keyword>Scene View</span>.

Exporter options
----------------


Using default FBX exporter options (that basically export everything) you can choose:

Embed textures - this stores the image maps in the file, good for portability, not so good for file size


![](http://docwiki.hq.unity3d.com/uploads/Main/FBX2013.png)  

_Default FBX exporter options (for fbx plugin version 2013.3)_


<a id="bones"></a>
Exporting Bone-based Animations
-------------------------------


There is a procedure you should follow when you want to export bone-based animations:

1. Set up the bone structure as you please.
1. Create the animations you want, using FK and/or IK
1. Select all bones and/or IK solvers
1. Go to <span class=menu>Motion->Trajectories</span> and press <span class=menu>Collapse</span>. Unity makes a key filter, so the amount of keys you export is irrelevant
1. "Export" or "Export selected" as newest FBX format
1. Drop the FBX file into <span class=keyword>Assets</span> as usual
1. In Unity you must reassign the Texture to the Material in the root bone

When exporting a bone hierarchy with mesh and animations from 3ds Max to Unity, the GameObject hierarchy produced will correspond to the hierarchy you can see in "Schematic view" in 3ds Max. One difference is Unity will place a GameObject as the new root, containing the animations, and will place the mesh and material information in the root bone.

If you prefer to have animation and mesh information in the same Unity GameObject, go to the Hierarchy view in 3ds Max, and parent the mesh node to a bone in the bone hierarchy. 


<a id="twouvs"></a>
Exporting Two UV Sets for Lightmapping
--------------------------------------


3ds Max' Render To Texture and automatic unwrapping functionality can be used to create lightmaps. Note that Unity has built-in [lightmapper](Lightmapping.md), but you might prefer using 3dsmax if that fits your workflow better. Usually one UV set is used for main texture and/or normal maps, and another UV set is used for the lightmap texture. For both UV sets to come through properly, the material in 3ds Max has to be Standard and both Diffuse (for main texture) and Self-Illumination (for lightmap) map slots have to be set up:


![](http://docwiki.hq.unity3d.com/uploads/Main/3dsMaxLightmapMaterial.png)  
_Material setup for Lightmapping in 3ds Max, using self-illumination map_

Note that if object uses a Shell material type, then current Autodesk's FBX exporter will __not export UVs correctly__.

Alternatively, you can use Multi/Sub Object material type and setup two sub-materials, using the main texture and the lightmap in their diffuse map slots, like shown below. However, if faces in your model use different sub-material IDs, this will result in multiple materials being imported, which is not optimal for performance.


![](http://docwiki.hq.unity3d.com/uploads/Main/3dsMaxMultiSubObject.png)  
_Alternate Material setup for Lightmapping in 3ds Max, using multi/sub object material_


Troubleshooting
---------------


If you have any issues with importing some models: ensure that you have the latest FBX plugin installed from [Autodesk website](http://autodesk.com/fbx.md) or revert to FBX 2012.
