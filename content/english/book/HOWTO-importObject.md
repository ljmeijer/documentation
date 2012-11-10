How do I import objects from my 3D app?
=======================================


Unity supports importing from most popular 3D applications. Choose the one you're working with below:

* [Maya](HOWTO-ImportObjectMaya.md)
* [Cinema 4D](HOWTO-ImportObjectCinema4D.md)
* [3ds Max](HOWTO-ImportObjectMax.md)
* [Cheetah3D](HOWTO-ImportObjectCheetah3D.md)
* [Modo](HOWTO-ImportObjectModo.md)
* [Lightwave](HOWTO-importObjectLightwave.md)
* [Blender](HOWTO-ImportObjectBlender.md)

Other applications
------------------


Unity can read __.FBX__, __.dae__, __.3DS__, __.dxf__ and __.obj__ files, so check to see if your program can export to one of these formats. FBX exporters for popular 3D packages can be found [here](http://autodesk.com/fbx.md). Many packages also have a Collada exporter available.

Hints
-----


* Store textures in a folder called <span class=keyword>Textures</span> next to the exported mesh. This will guarantee that Unity will always be able to find the Texture and automatically connect the Texture to the Material. For more information, see the [Textures](class-Texture2D.md) reference.

See Also
--------

* [Modeling Optimized Characters](ModelingOptimizedCharacters.md)
* [How do I use normal maps?](HOWTO-bumpmap.md)
* [Mesh Import Settings](class-Mesh.md)
* [How do I fix the rotation of an imported model?](HOWTO-FixZAxisIsUp.md)
