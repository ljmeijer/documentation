Asset Preparation and Import
============================


Humanoid meshes
---------------


In order to take full advantage of Mecanim's humanoid animation system and retargeting, you need to have a <span class=keyword>rigged</span> and <span class=keyword>skinned</span> humanoid type mesh.

1. A character <span class=keyword>model</span> is generally made up of polygons in a 3D package or converted to polygon or triangulated mesh, from a more complex mesh type before export.

1. A <span class=keyword>joint hierarchy</span> or <span class=keyword>skeleton</span> which defines the bones inside the mesh and their movement in relation to one another, must be created to control the movement of the character. The process for creating the joint hierarchy is known as <span class=keyword>rigging</span>.

1. The mesh or _skin_ must then be connected to the joint hierarchy in order to define which parts of the character mesh move when a given joint is animated. The process of connecting the skeleton to the mesh is known as <span class=keyword>skinning</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/Char200.png)  
>   Stages for preparing a character (modeling, rigging, and skinning)

How to obtain humanoid models
-----------------------------


There are three main ways to obtain humanoid models for with the Mecanim Animation system:

1. Use a procedural character system or character generator such as _Poser_, _Makehuman_ or [_Mixamo_](http://www.mixamo.com/.md). Some of these systems will rig and skin your mesh (eg, Mixamo) while others will not. Furthermore, these methods may require that you reduce the number of polygons in your original mesh to make it suitable for use in Unity.

1. Purchase demo examples and character content from the [Unity Asset Store](http://unity3d.com/unity/asset-store/.md).

1. Also, you can of course [prepare your own character](Preparingacharacterfromscratch.md) from scratch.


Export & Verify
---------------


Unity imports a number of different generic and native 3D file formats. The format we recommend for exporting and verifying your model is FBX 2012 since it will allow you to:

* Export the mesh with the skeleton hierarchy, normals, textures and animation
* Re-import into your 3D package to verify your animated model has exported as you expected
* Export animations without meshes

Further details
---------------

The following pages cover the stages of preparing and importing animation assets in greater depth
(:tocportion:)

(back to [Mecanim introduction](MecanimAnimationSystem.md))
