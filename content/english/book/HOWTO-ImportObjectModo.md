Importing Objects From Modo
===========================


Unity natively imports modo files. This works under the hood by using the modo COLLADA exporter. Modo version 501 and later use this approach. To get started, save your .lxo file in the project's Assets folder. When you switch back into Unity, the file is imported automatically and will show up in the Project View.

For older modo versions prior to 501, simply save your Modo scene as an FBX or COLLADA file into the Unity project folder. When you switch back into Unity, the scene is imported automatically and will show up in the <span class=keyword>Project View</span>.

To see your model in Unity, drag it from the Project View into the <span class=keyword>Scene View</span>.

If you modify the lxo file, Unity will automatically update whenever you save.

Unity currently imports
-----------------------


1. All nodes with position, rotation and scale. Pivot points and names are also imported.
1. Meshes with vertices, normals and UVs.
1. Materials with Texture and diffuse color. Multiple materials per mesh.
1. Animations


Requirements
------------

* modo 501 or later is required for native import of *.lxo files.

