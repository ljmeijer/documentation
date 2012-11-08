Skinned Mesh Renderer
=====================


The <span class=keyword>Skinned Mesh Renderer</span> is automatically added to imported meshes when the imported mesh is skinned.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-SkinnedMeshRenderer.png)  
_An animated character rendered using the Skinned Mesh Renderer_


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Cast Shadows</span> (Pro only) |If enabled, this <span class=keyword>Mesh</span> will create shadows when a shadow-creating [Light](class-Light.md) shines on it |
|<span class=component>Receive Shadows</span> (Pro only) |If enabled, this Mesh will display any shadows being cast upon it |
|<span class=component>Materials</span> |A list of <span class=keyword>Materials</span> to render model with. |
|<span class=component>Quality</span> |The maximum amount of bones affecting every vertex. |
|<span class=component>Update When Offscreen</span> |If enabled, the Skinned Mesh will be updated when offscreen. If disabled, this also disables updating animations. |
|<span class=component>Bounds</span> |These bounds are use for determining when skinned mesh is offscreen. Bounding box is also displayed in the SceneView. Bounds are precalculated on import based on Mesh and animations in the model file. |
|<span class=component>Mesh</span> |Meshed used by this renderer. |

Details
-------


Skinned Meshes are used for rendering characters. Characters are animated using bones, and every bone affects a part of the mesh. Multiple bones can affect the same vertex and are weighted.  The main advantage to using boned characters in Unity is you can enable the bones to be affected by physics, making your characters into ragdolls.  You can enable/disable bones via scripting, so your character instantly goes ragdoll when it is hit by an explosion.


![](http://docwiki.hq.unity3d.com/uploads/Main/RagdollRobot.png)  
_A Skinned Mesh enabled as a Ragdoll_

###Quality

Unity can skin every vertex with either 1, 2, or 4 bones. 4 bone weights look nicest and are most expensive. 2 Bone weights is a good compromise and can be commonly used in games.

If <span class=component>Quality</span> is set to <span class=component>Automatic</span>, the [Quality Settings](class-QualitySettings.md) <span class=component>Blend Weights</span> value will be used. This allows end-users to choose a quality setting that gives them optimum performance.


###Update When Offscreen and Bounds

By default, skinned meshes that are not visible are not updated. The skinning is not updated until the mesh comes back on screen. This is an important performance optimization - it allows you to have a lot of characters running around not taking up any processing power when they are not visible.

However, visibility is determined from the Mesh's Bounds, which is precalculated on import. Unity takes into account all attached animations for precalcualating bounding volume, but there are cases when Unity can't precalculate Bounds to fit all user's needs, for example (each of these become a problem when they push bones or vertices out of precalculated bounding volume):
* adding animations at run-time;
* using additive animations;
* proceduraly affecting positions of bones;
* using vertex shaders which can push vertices out of precalculated bounds;
* using ragdolls.

In those cases there are two solutions:
1. modify Bounds to match potential bounding volume of your mesh;
1. enable <span class=component>Update When Offscreen</span> to skin and render skinned mesh all the time.

You should use fist option most of the time since it has better performance and use second option only if performance is not important in your case or you can't predict the size of your bounding volume (for example when using ragdolls).

In order to make SkinnedMeshes work better with Ragdolls Unity will automatically remap the SkinnedMeshRenderer to the rootbone on import. However Unity only does this if there is a single SkinnedMeshRenderer in the model file.
So if you can't attach all SkinnedMeshRenderers to the root bone or a child and you use ragdolls, you should turn off this optimization.

Hints
-----


* Skinned Meshes currently can be imported from:
    * Maya
    * Cinema4D
    * 3D Studio Max
    * Blender
    * Cheetah 3D
    * XSI
    * Any other tool that supports the FBX format
