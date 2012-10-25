3D formats
==========

Importing meshes into Unity can be achieved from two main types of files: 
1. __Exported 3D file formats__, such as .FBX or .OBJ
1. __Proprietary 3D application files__, such as `.Max` and `.Blend` file formats from 3D Studio Max or Blender for example.

Either should enable you to get your meshes into Unity, but there are considerations as to which type you choose: 

Exported 3D files
-----------------

Unity can read [here](HOWTO-exportFBX|.FBX]], __.dae__ (Collada), __.3DS__, __.dxf__ and __.obj__ files, FBX exporters can be found [[http://autodesk.com/fbx) and obj or Collada exporters can also be found for many applications

__Advantages:__
* Only export the data you need
* Verifiable data (re-import into 3D package before Unity)
* Generally smaller files
* Encourages modular approach - e.g different components for collision types or interactivity
* Supports other 3D packages whose Proprietary formats we don't have direct support for

__Disadvantages:__
* Can be a slower pipeline for prototyping and iterations
* Easier to lose track of versions between source(working file) and game data (exported FBX for example)


Proprietary 3D application files
--------------------------------


Unity can also import, _through conversion_:  __Max__, __Maya__, __Blender__, __Cinema4D__, __Modo__, __Lightwave__ & __Cheetah3D__ files, e.g. __.MAX__, __.MB__, __.MA__ etc.

__Advantages:__
* Quick iteration process (save the source file and Unity reimports)
* Simple initially

__Disadvantages:__
* A licensed copy of that software must be installed on all machines using the Unity project
* Files can become bloated with unnecessary data
* Big files can slow Unity updates
* Less validation – harder to troubleshoot problems

