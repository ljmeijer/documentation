Import settings for Meshes
==========================


The <span class=keyword>Import Settings</span> for a model file will be displayed in the <span class=inspector>Model</span> tab of the FBX importer inspector when the model is selected. These affect the __mesh__, it's __normals__ and imported __materials__. Settings are applied per asset on disk so if you need assets with different settings make (and rename accordingly) a duplicate file.

Although defaults can suffice initially, it is worth studying the settings glossary below, as they can determine what you wish to do with the game object.

Some general adjustments to be made for example might be:

* Scale - this scale factor is used for compensating difference in units between Unity and 3d modeling tool - it rescales whole file. If you do not care about units you can simply set it to 1.
* Generate colliders - this will generate a collison mesh to allow your model to collide with other objects - see notes below.
* Material Naming and Search - this will help you automatically setup your materials and locate textures


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimImporterModelTab.png)  
_FBX Importer Inspector: Model tab_


|**_Property:_** |**_Function:_** |
|:---|:---|
|___Meshes___ |
|<span class=component>Scale Factor</span> |Unity's physics system expects 1 meter in the game world to be 1 unit in the imported file. If you prefer to model at a different scale then you can compensate for it here. defaults for different 3D packages are as follows .fbx, .max, .jas, .c4d = 0.01, .mb, .ma, .lxo, .dxf, .blend, .dae = 1 .3ds = 0.1|
|<span class=component>Mesh Compression</span> |Increasing this value will reduce the file size of the mesh, but might introduce irregularities.  It's best to turn it up as high as possible without the mesh looking too different from the uncompressed version. This is useful for [optimizing game size](ReducingFilesize.md). |
|<span class=component>Read/Write Enabled</span>|Enables the mesh to be written at runtime so you can modify the data - makes a copy in memory.|
|<span class=component>Optimize Mesh</span>|This option determines the order in which triangles will be listed in the mesh.|
|<span class=component>Generate Colliders</span> |If this is enabled, your meshes will be imported with Mesh Colliders automatically attached. This is useful for quickly generating a collision mesh for environment geometry, but should be avoided for geometry you will be moving. For more info see [Colliders](#colliders) below. |
|<span class=component>Swap UVs</span> |Use this if lightmapped objects pick up the wrong UV channels. This will swap your primary and secondary UV channels.|
|<span class=component>Generate Lightmap</span> |Use this to create the second UV channel to be used for Lightmapping.|
|>>><span class=component>Advanced Options</span> |See [Lightmapping UVs document](Main.LightmappingUV.md).|
|___Normals & Tangents___ |
|<span class=component>Normals</span> |Defines if and how normals should be calculated. This is useful for [optimizing game size](ReducingFilesize.md). |
|>>><span class=component>Import</span> |Default option. Imports normals from the file. |
|>>><span class=component>Calculate</span> |Calculates normals based on <span class=component>Smoothing angle</span>. If selected, the <span class=component>Smoothing Angle</span> becomes enabled. |
|>>><span class=component>None</span> |Disables normals. Use this option if the mesh is neither normal mapped nor affected by realtime lighting. |
|<span class=component>Tangents</span> |Defines if and how tangents and binormals should be calculated. This is useful for [optimizing game size](ReducingFilesize.md). |
|>>><span class=component>Import</span> |Imports tangents and binormals from the file. This option is available only for FBX, Maya and 3dsMax files and only when normals are imported from the file. |
|>>><span class=component>Calculate</span> |Default option. Calculates tangents and binormals. This option is available only when normals are either imported or calculated.  |
|>>><span class=component>None</span> |Disables tangents and binormals. The mesh will have no Tangents, so won't work with normal-mapped shaders. |
|<span class=component>Smoothing Angle</span> |Sets how sharp an edge has to be in order to be treated as a hard edge. It is also used to split normal map tangents. |
|<span class=component>Split Tangents</span> |Enable this if normal map lighting is broken by seams on your mesh. This usually only applies to characters. |
|___Materials___ |
|<span class=component>Import Materials</span> |Disable this if you don't want materials to be generated. Default-Diffuse material will be used instead. |
|<span class=component>Material Naming</span> |Controls how Unity materials are named: |
|>>><span class=component>By Base Texture Name</span> |The name of the diffuse texture of the imported material that will be used to name the material in Unity. When a diffuse texture is not assigned to the material, Unity will use the name of the imported material. |
|>>><span class=component>From Model's Material</span> |The name of the imported material will be used for naming the Unity material. |
|>>><span class=component>Model Name + Model's Material</span> |The name of the model file in combination with the name of the imported material will be used for naming the Unity material. |
|>>><span class=component>Texture Name or Model Name + Model's Material (Obsolete)</span> |The name of the diffuse texture of the imported material will be used for naming the Unity material. When a diffuse texture is not assigned or it cannot be located in one of the Textures folders, then the material will be named by Model Name + Model's Material instead. This option is backwards compatible with the behavior of Unity 3.4 (and earlier versions). We recommend using <span class=component>By Base texture Name</span>, because it is less complicated and has more consistent behavior. |
|<span class=component>Material Search</span> |Controls where Unity will try to locate existing materials using the name defined by the <span class=component>Material Naming</span> option: |
|>>><span class=component>Local</span> |Unity will try to find existing materials only in the "local" Materials folder, ie, the Materials subfolder which is the same folder as the model file. |
|>>><span class=component>Recursive-Up</span> |Unity will try to find existing materials in all Materials subfolders in all parent folders up to the Assets folder. |
|>>><span class=component>Everywhere</span> |Unity will try to find existing materials in all Unity project folders. |

