Meshes
======


<span class=keyword>Meshes</span> make up a large part of your 3D worlds. Aside from some [Asset store](http://unity3d.com/unity/asset-store/.md) plugins, Unity does not include modelling tools. Unity does however have great interactivity with most 3D modelling packages. Unity supports triangulated or Quadrangulated polygon meshes. Nurbs, Nurms, Subdiv surfaces must be converted to polygons.


![](http://docwiki.hq.unity3d.com/uploads/Main/Tris.png)  

(:include 3D-formats:)

Here are some guidelines for directly supported 3D applications, others can most often export file type listed above.

* [Maya](HOWTO-ImportObjectMaya.md)
* [Cinema 4D](HOWTO-ImportObjectCinema4D.md)
* [3ds Max](HOWTO-ImportObjectMax.md)
* [Cheetah3D](HOWTO-ImportObjectCheetah3D.md)
* [Modo](HOWTO-ImportObjectModo.md)
* [Lightwave](HOWTO-importObjectLightwave.md)
* [Blender](HOWTO-ImportObjectBlender.md)


Textures
--------


Unity will attempt to find the textures used by a mesh automatically on import by following a specific search plan. First, the importer will look for a sub-folder called Textures within the same folder as the mesh or in any parent folder. If this fails, an exhaustive search of all textures in the project will be carried out. Although slightly slower, the main disadvantage of the exhaustive search is that there could be two or more textures in the project with the same name. In this case, it is not guaranteed that the right one will be found.


![](http://docwiki.hq.unity3d.com/uploads/Main/Mesh-TextureImportHierarchy.png)  
_Place your textures in a <span class=menu>Textures</span> folder at or above the asset's level_


[FBX importer options for the model](FBXImporter-Model.md)

###Material Generation and Assignment

For each imported material Unity will apply the following rules:-

If material generation is disabled (i.e. <span class=component>Import Materials</span> is unchecked), then it will assign the Default-Diffuse material. If it is enabled then it will do the following:
* Unity will pick a name for the Unity material based on the <span class=component>Material Naming</span> setting
* Unity will try to find an existing material with that name. The scope of the Material search is defined by the <span class=component>Material Search</span> setting.
* If Unity succeeds in finding an existing material then it will use it for the imported scene, otherwise it will generate a new material

<a id="colliders"></a>
###Colliders

Unity uses two main types of colliders: <span class=keyword>Mesh Colliders</span> and <span class=keyword>Primitive Colliders</span>.  Mesh colliders are components that use imported mesh data and can be used for environment collision. When you enable <span class=keyword>Generate Colliders</span> in the Import Settings, a Mesh collider is automatically added when the mesh is added to the Scene.  It will be considered solid as far as the physics system is concerned.

If you are moving the object around (a car for example), you can not use Mesh colliders. Instead, you will have to use Primitive colliders. In this case you should disable the <span class=component>Generate Colliders</span> setting.


###Animations

Animations are automatically imported from the scene. For more details about animation import options see the [Animation Import](Animations.md) chapter.

###Normal mapping and characters

If you have a character with a normal map that was generated from a high-polygon version of the model, you should import the game-quality version with a <span class=component>Smoothing angle</span> of 180 degrees.  This will prevent odd-looking seams in lighting due to tangent splitting.  If the seams are still present with these settings, enable <span class=component>Split tangents across UV seams</span>.

If you are converting a greyscale image into a normal map, you don't need to worry about this.



Hints
-----


* Merge your meshes together as much as possible. Make them share materials and textures. This has a huge performance benefit.
* If you need to set up your objects further in Unity (adding physics, scripts or other coolness), save yourself a world of pain and name your objects properly in your 3D application. Working with lots of _pCube17_ or _Box42_-like objects is not fun.
* Make your meshes be centered on the world origin in your 3D app. This will make them easier to place in Unity.
* If a mesh does not have vertex colors, Unity will automatically add an array of all-white vertex colors to the mesh the first time it is rendered.

###The Unity Editor shows too many vertices or triangles (compared to what my 3D app says)
This is correct. What you are looking at is the number of vertices/triangles actually being sent to the GPU for rendering. In addition to the case where the material requires them to be sent twice, other things like hard-normals and non-contiguous UVs increase vertex/triangle counts significantly compared to what a modeling app tells you. Triangles need to be contiguous in both 3D and UV space to form a strip, so when you have UV seams, degenerate triangles have to be made to form strips - this bumps up the count.


See Also
--------

* [Modeling Optimized Characters](ModelingOptimizedCharacters.md)
* [How do I use normal maps?](HOWTO-bumpmap.md)
* [How do I fix the rotation of an imported model?](HOWTO-FixZAxisIsUp.md)

