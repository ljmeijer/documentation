Asset Preparation and Import
============================


Humanoid meshes
---------------


In order to take full advantage of Mecanim's humanoid animation system and retargeting, you need to have a <span class=keyword>rigged</span> and <span class=keyword>skinned</span> humanoid type mesh.

1. A character <span class=keyword>model</span> is generally made up of polygons in a 3D package or converted to polygon or triangulated mesh, from a more complex mesh type before export.

1. A <span class=keyword>joint hierarchy</span> or <span class=keyword>skeleton</span> which defines the bones inside the mesh and their movement in relation to one another, must be created to control the movement of the character.
    * The process for creating this and the controls for manipulating this is generally called <span class=keyword>rigging</span>

1. Additionally the mesh or skin must then be <span class=keyword>skinned</span> to the joint hierarchy to define which parts of the character mesh move when a given joint is animated.
    * The process is generally called <span class=keyword>skinning</span>

->Attach:Char200.png
->   Stages for preparing a character (modeling, rigging, and skinning)

How to obtain humanoid models
-----------------------------


There are 3 ways to obtain humanoid models for with the Mecanim Animation system:

->A. Use a procedural character system or character generator such as _Poser_, _Makehuman_, [_Mixamo_](http://www.mixamo.com/)

    * Some of these methods will rig and skin your mesh - see mixamo, others will not, (see [Preparing your own character](Preparingacharacterfromscratch)) additionally these methods may require that you optimise your mesh (reduce the number of polygons) for use in Unity

->B. Download from the asset store

    * Demo examples and character content is available on the [asset store](http://unity3d.com/unity/asset-store/)

->C. [Prepare your own character](Preparingacharacterfromscratch)


Export & Verify
---------------


Unity imports a number of different 3D generic and native file formats, to most successfully export and verify your model we recommend FBX 2012 as it allows you to

* Export mesh with skeleton hierarchy, normals, textures and animation
* Re-import into your 3D package to verify your animated model has exported as you expected
* Export animations without meshes

Asset Preparation and Import
============================

(:tocportion:)

(back to [Mecanim introduction](MecanimAnimationSystem))

