Importing Objects From Lightwave
================================


You can import meshes and animations from Lightwave using the FBX plugin for Lightwave.

Unity currently imports
-----------------------


1. All nodes with position, rotation and scale. Pivot points and Names are also imported.
1. Meshes with UVs and normals.
1. Materials with Texture and diffuse color. Multiple materials per mesh.
1. Animations.
1. Bone-based animations.

Installation
------------


Download the latest Lightwave FBX exporter from:

* [OS X lighwave 8.2 and 9.0 plugin](http://unity3d.com/lightwave_plugins/mbr_FBX200508_LW82_MACOS.pkg.sit.md)
* [OS X Lighwave 8.0 plugin](http://unity3d.com/lightwave_plugins/mbr_FBX200508_LW80_MACOS.pkg.sit.md)
* [Windows Lighwave 8.2 and 9.0 plugin](http://unity3d.com/lightwave_plugins/mbr_FBX200508_LW82_WIN.zip.md)
* [Windows Lighwave 8.0 plugin](http://unity3d.com/lightwave_plugins/mbr_FBX200508_LW80_WIN.zip.md)

By downloading these plugins you automatically agree to [this licence](http://unity3d.com/lightwave_plugins/License.txt.md).


There are two versions of the plugin, one for LightWave 8.0 and one for LightWave 8.2 through 9.0. Make sure you install the correct version.

The plugin for Mac comes in an OS X package. If you double-click the package to install it, the installer will try to put it in the correct folder. If it can't find your LightWave plugin folder, it will create its own LightWave folder in your <span class=menu>Applications</span> folder and dump it there. If the latter occurs you should move it to your LightWave plugin folder (or any sub-folder). Once there you have to add the plugin to LightWave via the "Edit Plugins" panel (<span class=menu>Option-F11</span>) -  see the LightWave manual for more details on how to add plugins.


![](http://docwiki.hq.unity3d.com/uploads/Main/Lightwave./LWexpEditPlugs.jpg)  

Once added to LightWave, the plugin is acessible via the Generics menu (on the Utiliies) tab.  If the Generic menu is not present you will have to add it using the Config Menus panel. In the latter panel it can be found in the Plug-ins category and is called "Generic Plugins". Add it to any convenient menu (see the LightWave manual for more details on how to do this).

More information about installation can also be found in the release notes that can downloaded with the installer.

Exporting
---------


All objects and animations have to be exported from Layout (there is no Modeler FBX exporter).


###1. Select Export to FBX from the Generics menu


![](http://docwiki.hq.unity3d.com/uploads/Main/Lightwave./LWexpGenerics2.jpg)  


###2. Select the appropriate settings in the fbx export dialog

* Select the fbx file name. Make sure to save the exported fbx file in the Assets folder of your current Unity project.
* In the FBX dialogue panel you MUST select <span class=component>Embed Textures</span> otherwise the exported object will have no UVs. This is a bug in the Lightwave fbx exporter and will be fixed in a future version according to Autodesk.
* If you want to export animations into Unity you must have "Animations" checked. You also need to have "Lights" or "Cameras" checked.
* To change the name of the exported animation clip in Unity, change the name from "LW Take 001" to your liking.


![](http://docwiki.hq.unity3d.com/uploads/Main/Lightwave./fbxtex602b.jpg)  


###3. Switch to Unity.

* Unity will automatically import the fbx file and generate materials for the textures.
* Drag the imported fbx file from the Project view into the Scene view.

Important notes
---------------


* You must select <span class=component>Embed Textures</span> in the FBX panel when exporting or no UVs are exported
* If you want to export animations you must enable <span class=component>Animations</span> and either <span class=component>Camera</span> or <span class=component>Lights</span>.
* It is strongly recommended to always place your textures in a folder called "Textures" next to the fbx file. This will guarantee that Unity can always find the Texture and automatically connect the texture to the material.
