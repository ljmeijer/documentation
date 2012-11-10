Unity supports textured 3D models from a variety of programs or sources. This short guide has been put together by games artists with developers at Unity, to help you create assets that work better and more efficiently in your Unity project.

Scale & Units
-------------


* Set your system and project units  for your software to work consistently with Unity e.g. Metric.
    * Working to scale can be important for both lighting and physics simulation;
    * Be aware for example; Max system unit default is inches and Maya is centimetres.
    * Unity has different scaling for FBX and 3D application files on import, check FBX import scale setting in Inspector.
    * If in doubt export a metre cube with your scene to match in Unity.
* Animation frame rate defaults can be different in packages, is a good idea to set consistently across your pipeline – e.g. 30fps for example.

Files & Objects
---------------

* Name objects in your scene sensibly and uniquely – this can help you locate and troubleshoot specific meshes in your project:
* Avoid special characters `*()?”£$n`  etc.
* Use simple but descriptive names for both objects and files (allow for duplication later).
* Keep your hierarchies as simple as you can.
* With big projects in your 3D application, consider having a working file outside your Unity project directory – this can often avert time consuming updates and importing unnecessary data.


![](http://docwiki.hq.unity3d.com/uploads/Main/HierarchyWrongRight.png)  
_Sensibly named objects help you find stuff quickly_

Mesh
====


* Build with an efficient topology – use polygons only where you need them.
* Optimise your geometry if it has too many polygons – many character models will need to be intelligently optimised or even rebuilt by an artist esp if sourced/built from:
    * 3D capture data
    * Poser
    * Zbrush
    * Other hi density Nurbs/Patch models designed for render
* Evenly spaced polygons in buildings, landscape and architecture where you can afford them, will help spread lighting and avoid awkward kinks.
* Avoid really long thin triangles


![](http://docwiki.hq.unity3d.com/uploads/Main/GeomWrongRight.png)  
_Stairway to framerate heaven_

The method you use to construct objects can have a massive affect on the number of polygons, especially when not optimised. Observe the same shape mesh : 156 triangles (right) vs 726 (left). 726 may not sound like a great deal of polygons, but if this is used 40 times in a level, you will really start to see the savings. A good rule of thumb is often to start simple and add detail where needed. It’s always easier to add polygon than take them away.

Textures
========


Textures are more efficient and don’t need rescaling at build time if authored to specific texture sizes – e.g a power of two – up to 4096×4096 pixels, e.g. 512×512 or 256×1024 etc.  (2048×2048 is the highest on many graphics cards/platforms) there is lots of expertise online for creating good textures, but some of these guidelines can help you get the most efficient results from your project:

* Working with a Hi-res source file outside your unity project can be good working practice (such as a PSD or Gimp file – you can always downsize from source but not the other way round).
* Use the texture resolution output you require in your scene (e.g. save a copy – such as a 256×256 optimised PNG or a TGA file for example) you can make a judgement based on where the texture will be seen and where it is mapped.
* Store your output texture files together in your Unity project for example: \Assets\textures
* Make sure your 3D working file is referring to the same textures for consistency when you save/export.
* Make use of the available space in your texture, but be aware of different materials requiring different parts of the same texture can end up using loading that texture multiple times.
* For alpha (cutout) and elements that may require different shaders, separate the  textures. E.g. the single texture below (left) has been replaced by 3 smaller textures below (right)


![](http://docwiki.hq.unity3d.com/uploads/Main/Pack_WrongRight2.png)  
_1 texture (left) vs 3 textures (right)_

* Make use of tiling textures (which seamlessly repeat) then you can use better resolution repeating over space.
* Remove easily noticeable repeating elements from your bitmap, and be careful with contrast – if you want to add details use decals and objects to break up the repeats.


![](http://docwiki.hq.unity3d.com/uploads/Main/TexWrongRight.png)  
_Tiling textures ftw_

* Unity takes care of compression for the output platform, so unless your source is already a JPG of the correct resolution it’s better to use a lossless format for your textures.
* When creating a texture page from photographs, reduce the page to individual modular sections that can repeat, e.g. you don’t need 12 of the same windows using up texture space. That way you can have more pixel detail for that one window.


![](http://docwiki.hq.unity3d.com/uploads/Main/BuildingWrongRight.png)  
_Do you need ALL those windows?_

Materials
=========

* Organise and name the materials in your scene – this way you can find and edit your materials in Unity more easily when they’ve imported
* You can choose to create materials in Unity from either:
    * <modelname> material name> or:
    * <texture name> – make sure you are aware of which you want.
* Settings for materials in your native package will not all be imported to unity:
    * Diffuse Colour, Diffuse texture and Names are usually supported
    * Shader model, specular, normal, other secondary textures and substance material settings will not be recognised/imported (coming in 3.5)

Import/Export
=============


Unity can use two types of files: Saved 3D application files and Exported 3D formats – which you decide to use can be quite important:

Saved application files
-----------------------


Unity can import, through conversion:  Max, Maya, Blender, Cinema4D, Modo, Lightwave & cheetah3D files, e.g. .MAX, .MB, .MA etc.
see more in [Importing Objects](HOWTO-importObject.md)

__Advantages__:

* Quick iteration process (save and Unity updates)
* Simple initially

__Disadvantages__:
* A licensed copy of that software must be installed on all machines using the Unity project
* Files can become bloated with unnecessary data
* Big files can slow Unity updates
* Less Validation – harder to troubleshoot problems

Exported 3D formats
-------------------


Unity can also read FBX, OBJ, 3DS, DAE & DXF files – for a general export guide you can refer to this section [this section](HOWTO-exportFBX.md)

__Advantages__:

* Only export the data you need
* Verify your data (re-import into 3D package) before Unity
* Generally smaller files
* Encourages modular approach

__Disadvantages__:

* Can be slower pipeline or prototyping and iterations
* Easier to lose track of versions between source(working file) and game data (exported FBX)
