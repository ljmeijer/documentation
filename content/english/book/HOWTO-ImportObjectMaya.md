Importing Objects From Maya
===========================


Unity natively imports Maya files. To get started, simply place your __.mb__ or __.ma__ file in your project's Assets folder.
When you switch back into Unity, the scene is imported automatically and will show up in the Project view.

To see your model in Unity, simply drag it from the <span class=keyword>Project View</span> into the <span class=keyword>Scene View</span> or <span class=keyword>Hierarchy View</span>.

Unity currently imports from Maya:
----------------------------------

1. All nodes with position, rotation and scale. Pivot points and Names are also imported.
1. Meshes with vertex colors, normals and up to 2 UV sets.
1. Materials with Texture and diffuse color. Multiple materials per mesh.
1. Animations FK & IK
1. Bone-based animations

Unity does not import blend shapes. Use Bone-based animations instead. Unity automatically triangulates polygonal meshes when importing, thus there is no need to do this manually in Maya.

If you are using IK to animate characters you have to select the imported .mb file in <span class=keyword>Project View</span> and choose <span class=component>Bake IK & Simulation</span> in the <span class=keyword>Import Settings</span> dialog in the <span class=keyword>Inspector</span>.


Requirements
------------


In order to import Maya __.mb__ and __.ma__ files, you need to have Maya installed on the machine you are using Unity to import the .mb/.ma file. Maya 8.0 and up is supported.

>If you don't have Maya installed on your machine but want to import a Maya file from another machine, you can export [to fbx format](Main.HOWTO-exportFBX.md), which Unity imports natively.  Please Install ->[2011.3](http://usa.autodesk.com/adsk/servlet/pc/item?siteID=123112&id=15765120.md) for best results. To export see [HOWTO_exportFBX](Main.HOWTO-exportFBX.md).


>Once exported Place the fbx file in the Unity project folder. Unity will now automatically import the fbx file. Check the FBX import setting in the inspector as mentioned in [HOWTO_exportFBX](Main.HOWTO-exportFBX.md)

###Behind the import process (Advanced)

When Unity imports a Maya file it will launch Maya in the background. Unity then communicates with Maya to convert the .mb file into a format Unity can read. The first time you import a Maya file in Unity, Maya has to launch in a command line process, this can take around 20 seconds, but subsequent imports will be very quick.

Troubleshooting
---------------


* Keep your scene simple, try and work with a file which only contains the objects you need in Unity
* If your meshes cause problems, make sure you have converted any patches, nurbs surface etc into Polygons (Modify > Convert + also Mesh > Quadragulate/Triangulate) Unity only support Polygons.
* Maya in some rare cases messes up the node history, which sometimes results in models not exporting correctly. Fortunately you can very easily fix this by selecting <span class=menu>Edit->Delete by Type->Non-Deformer History</span>.
* Unity likes to keep up with the latest FBX where possible so if you have any issues with importing some models, check for the latest FBX exporters from [Autodesk website](http://autodesk.com/fbx.md) or revert to FBX 2012
* Animation baking in Maya is now done with FBX instead of natively, which allows for more complex animations to be baked properly to FBX format. If you are using driven keys, then make sure to set at least one key on your drivers for the animation to bake properly
