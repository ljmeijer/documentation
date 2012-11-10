FBX export guide
----------------


Unity supports FBX files which can be generated from many popular 3D applications. Use these guidelines to help ensure the most best results.

Select > Prepare > Check Settings > Export > Verify > Import
------------------------------------------------------------


###_'What_' do you want to export? - be aware of export scope e.g. meshes, cameras, lights, animation rigs, etc. -

* Applications often let you export _'_selected objects_'_ or a _'_whole scene_'_
* Make sure you are exporting only the objects you want to use from your scene by either exporting selected, or removing unwanted data from your scene.
* Good working practice often means keeping a working file with all lights, guides, control rigs etc. but only export the data you need with _export selected,_ an export preset or even a custom scene exporter.

###_'What_' do you need to include? - prepare your assets:

* Meshes - Remove construction history, Nurbs, Nurms, Subdiv surfaces must be converted to polygons - e.g. triangulate or quadrangulate
* Animation - Select the correct rig, check frame rate, animation length etc.
* Textures - Make sure your textures are sourced already from your Unity project or copied into a folder called \textures in your project
* Smoothing - Check if you want smoothing groups and/or smooth mesh

###_'How_' do I include those elements? - check the FBX export settings

* Be aware of your settings in the export dialogue so that you know what to expect and can match up the fbx settings In Unity - see figs 1, 2 & 3 below
* Nodes, markers and their transforms can be exporte
* Cameras and Lights are not currently imported in to Unity

###_'Which_' version of FBX are you using? if in doubt use [2012.2](http://usa.autodesk.com/adsk/servlet/pc/item?siteID=123112&id=18817399.md)

* Autodesk update their FBX installer regularly and it can provide different results with different versions of their own software and other 3rd party 3D apps.
* _'_See Advanced Options >  FBX file format_'_

###Will it work? - Verify your export

* Check your file size - do a sanity check on the file size (e.g. >10kb?)
* Re-import your FBX into a new scene in the 3D package you use to generate it - is it what you expected?

###_'Import!_'

* Import into Unity
* Check FBX import settings in inspector : texures, animations, smoothing, etc.

See below for Maya FBX dialogue example:

Fig 1 General, Geometry & Animation

![](http://docwiki.hq.unity3d.com/uploads/Main/FBX_A.png)  
Fig 2 Lights, Advanced options

![](http://docwiki.hq.unity3d.com/uploads/Main/FBX_B.png)  
