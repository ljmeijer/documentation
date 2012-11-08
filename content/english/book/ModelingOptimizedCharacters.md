Modeling Characters for Optimal Performance
===========================================


Below are some tips for designing character models to give optimal rendering speed.

Use a Single Skinned Mesh Renderer
----------------------------------


You should use only a single [skinned mesh renderer](class-SkinnedMeshRenderer.md) for each character. Unity optimizes animation using visibility culling and bounding volume updates and these optimizations are only activated if you use one [animation component](class-Animation.md) and one skinned mesh renderer in conjunction. The rendering time for a model could roughly double as a result of using two skinned meshes in place of a single mesh and there is seldom any practical advantage in using multiple meshes.


Use as Few Materials as Possible
--------------------------------


You should also keep the number of [materials](class-Material.md) on each mesh as low as possible. The only reason why you might want to have more than one material on a character is that you need to use different shaders for different parts (eg, a special shader for the eyes). However, two or three materials per character should be sufficient in almost all cases.


Use as Few Bones as Possible
----------------------------


A bone hierarchy in a typical desktop game uses somewhere between fifteen and sixty bones. The fewer bones you use, the better the performance will be. You can achieve very good quality on desktop platforms and fairly good quality on mobile platforms with about thirty bones. Ideally, keep the number below thirty for mobile devices and don't go too far above thirty for desktop games.

Polygon Count
-------------


The number of polygons you should use depends on the quality you require and the platform you are targeting.  For mobile devices, somewhere between 300 and 1500 polygons per mesh will give good results, whereas for desktop platforms the ideal range is about 1500 to 4000. You may need to reduce the polygon count per mesh if the game can have lots of characters onscreen at any given time. As an example, Half Life 2 used 2500-5000 triangles per character. Current AAA games running on the PS3 or Xbox 360 usually have characters with 5000-7000 triangles.


Keep Forward and Inverse Kinematics Separate
--------------------------------------------


When animations are imported, a model's inverse kinematic (IK) nodes are baked into forward kinematics (FK) and as a result, Unity doesn't need the IK nodes at all. However, if they are left in the model then they will have a CPU overhead even though they don't affect the animation. You can delete the redundant IK nodes in Unity or in the modeling tool, according to your preference.  Ideally, you should keep separate IK and FK hierarchies during modeling to make it easier to remove the IK nodes when necessary.

