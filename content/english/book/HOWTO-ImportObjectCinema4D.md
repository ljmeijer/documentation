Importing Objects From Cinema 4D
================================


Unity natively imports Cinema 4D files. To get started, simply place your __.c4d__ file in your project's Assets folder.
When you switch back into Unity, the scene is imported automatically and will show up in the <span class=keyword>Project View</span>.

To see your model in Unity, simply drag it from the Project View into the <span class=keyword>Scene View</span>.

If you modify your __.c4d__ file, Unity will automatically update whenever you save.

Unity currently imports
-----------------------


1. All objects with position, rotation and scale. Pivot points and Names are also imported.
1. Meshes with UVs and normals.
1. Materials with Texture and diffuse color. Multiple materials per mesh.
1. Animations FK (IK needs to be manually baked).
1. Bone-based animations.

Unity does not import Point Level Animations (PLA) at the moment. Use Bone-based animations instead.


Animated Characters using IK
----------------------------


If you are using IK to animate your characters in Cinema 4D, you have to bake the IK before exporting using the <span class=menu>Plugins->Mocca->Cappucino</span> menu. If you don't bake your IK prior to importing into Unity, you will most likely only get animated locators but no animated bones.


Requirements
------------


* You need to have at least Cinema 4D version 8.5 installed to import __.c4d__ files.

If you don't have Cinema 4D installed on your machine but want to import a Cinema 4D file from another machine, you can export to the FBX format, which Unity imports natively:
1. Open the Cinema 4D file
1. In Cinema 4D choose <span class=menu>File->Export->FBX 6.0</span>
1. Place the exported fbx file in the Unity project's Assets folder. Unity will now automatically import the fbx file.


Hints
-----


1. To maximize import speed when importing Cinema 4D files: go to the Cinema 4D preferences (<span class=menu>Edit->Preferences</span>) and select the FBX 6.0 preferences. Now uncheck <span class=component>Embed Textures</span>.


Behind the import process (Advanced)
------------------------------------


When Unity imports a Cinema 4D file it will automatically install a Cinema 4D plugin and launch Cinema 4D in the background. Unity then communicates with Cinema 4D to convert the .c4d file into a format Unity can read. The first time you import a .c4d file and Cinema 4D is not open yet it will take a short while to launch it but afterwards importing __.c4d__ files will be very quick.


Cinema 4D 10 support
--------------------


When importing __.c4d__ files directly, Unity behind the scenes lets Cinema 4D convert its files to FBX.
When Maxon shipped Cinema 4D 10.0, the FBX exporter was severly broken. With Cinema 4D 10.1 a lot of the issues have been fixed. Thus we strongly recommend everyone using Cinema 4D 10 to upgrade to 10.1.

Now there are still some issues left in Maxons FBX exporter. It seems that currently there is no reliable way of exporting animated characters that use the Joint's introduced in Cinema 4D 10. However the old bone system available in 9.6 exports perfectly fine. Thus when creating animated characters it is critical that you use the old bone system instead of joints.
