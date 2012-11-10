Importing Objects From Blender
==============================


Unity natively imports Blender files. This works under the hood by using the Blender FBX exporter, which was added to Blender in version 2.45.  For this reason, you must update to Blender 2.45 or later (but see Requirements below).

To get started, save your __.blend__ file in your project's Assets folder. When you switch back into Unity, the file is imported automatically and will show up in the <span class=keyword>Project View</span>.

To see your model in Unity, drag it from the Project View into the <span class=keyword>Scene View</span>.

If you modify your __.blend__ file, Unity will automatically update whenever you save.

Unity currently imports
-----------------------

1. All nodes with position, rotation and scale. Pivot points and Names are also imported.
1. Meshes with vertices, polygons, triangles, UVs, and normals.
1. Bones
1. Skinned Meshes
1. Animations

Requirements
------------

* You need to have Blender version 2.45-2.49 or 2.58 or later (versions 2.50-2.57 do not work, because FBX export was changed/broken in Blender).
* Textures and diffuse color are not assigned automatically. Manually assign them by dragging the texture onto the mesh in the Scene View in Unity.
