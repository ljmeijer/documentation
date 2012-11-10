Trees
=====


Unity's Terrain Engine has special support for Trees.  You can put thousands of trees onto a Terrain, and render them in-game with a practical frame rate.  This works by rendering trees near the camera in full 3D, and transitioning far-away trees to 2D billboards.  Billboards in the distance will automatically update to orient themselves correctly as they are viewed from different angles.  This transition system makes a detailed tree environment very simple for performance.  You have complete control over tweaking the parameters of the mesh-to-billboard transition so you can get the best performance you need.


![](http://docwiki.hq.unity3d.com/uploads/Main/terrain-PlacingTrees.png)  
_You can easily paint lots of trees for beautiful environments like this_

Adding Trees
------------


Select the <span class=keyword>Place Trees</span> button Attach:terrain-TreesButton.png in the <span class=keyword>Inspector</span>.

Before you can place trees on your terrain, you have to add them to the library of available trees.  To do this, click the <span class=menu>Edit Trees button->Add Tree</span>.  You'll see the <span class=keyword>Add Tree</span> dialog appear.


![](http://docwiki.hq.unity3d.com/uploads/Main/terrain-AddTreeDialog.png)  
_The Add Tree dialog_

Select the tree from your <span class=keyword>Project View</span> and drag it to the <span class=component>Tree</span> variable.  You can also edit the <span class=component>Bend Factor</span> if you want to add an additional bit of animated "bending in the wind" effect to the trees.  When you're ready, click <span class=menu>Add</span>.  The tree will now appear selected in the Inspector.


![](http://docwiki.hq.unity3d.com/uploads/Main/terrain-AddedTree.png)  
_The newly added tree appears selected in the Inspector_

You can add as many trees as you like.  Each one will be selectable in the Inspector for you to place on your Terrain.


![](http://docwiki.hq.unity3d.com/uploads/Main/terrain-AddedMultipleTrees.png)  
_The currently selected tree will always be highlighted in blue_

Painting Trees
--------------


While still using the Place Trees tool, click anywhere on the Terrain to place your trees.  To erase trees, hold the <span class=menu>Shift</span> button and click on the Terrain.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-PaintingTrees.png)  
_Painting trees is as easy as using a paintbrush tool_

There are a number of options at your disposal when placing trees.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Brush Size</span> |Radius in meters of the tree placing brush. |
|<span class=component>Tree Spacing</span> |Percentage of tree width between trees. |
|<span class=component>Color Variation</span> |Allowed amount of color difference between each tree. |
|<span class=component>Tree Height</span> |Height adjustment of each tree compared to the asset. |
|<span class=component>Height Variation</span> |Allowed amount of difference in height between each tree. |
|<span class=component>Tree Width</span> |Width adjustment of each tree compared to the asset. |
|<span class=component>Width Variation</span> |Allowed amount of difference in width between each tree. |


###Tree Painting Tips


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-TreeBrushSize.png)  
_Different Brush sizes cover different area sizes_


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-TreeSpacing.png)  
_Adjust <span class=component>Tree Spacing</span> to change the density of the trees you're painting_


Editing Trees
-------------


To change any import parameters for an added tree, select the detail and choose <span class=menu>Edit Trees button->Edit Detail</span>.  Or double-click the tree you want to edit.  You will then see the <span class=keyword>Edit Tree</span> dialog, and you can change any of the settings.

Mass Placement
--------------


If you don't want to paint your trees and you just want a whole forest created, you can use <span class=menu>Terrain->Mass Place Trees</span>.  Here, you will see the <span class=keyword>Mass Place Trees</span> dialog.  You can set the number of trees you want placed, and they'll be instantly positioned.  All the trees added to your Terrain will be used in this mass placement.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-MassPlacedTrees.png)  
_10,000 Trees placed at once_

Refreshing Source Assets
------------------------


If you make any updates to your tree asset source file, it must be manually re-imported into the Terrain.  To do this, use <span class=menu>Terrain->Refresh Tree and Detail Prototypes</span>.  This is done after you've changed your source asset and saved it, and will refresh the trees in your Terrain immediately.

Creating Trees
--------------


Trees can be created in two ways to the terrain engine:

The first one is by using the [Tree creator](class-Tree.md) that Unity comes with, and the second one is by using a 3rd party modeling program compatible with Unity, in this case every tree should consist of a single mesh with two <span class=keyword>Materials</span>. One for the trunk and one for the leaves. 

For performance reasons, triangle count should be kept below 2000 for an average tree. The fewer triangles the better.  The pivot point of the tree mesh must be exactly at the root of the tree, that is at the point where the tree should meet the surface it is placed on. This makes it the easiest to import into Unity and other modelling applications.

Trees must use the <span class=component>Nature/Soft Occlusion Leaves</span> and <span class=component>Nature/Soft Occlusion Bark shader</span>.  In order to use those shaders you also have to place the tree in a special folder that contains the name "Ambient-Occlusion". When you place a model in that folder and reimport it, Unity will calculate soft ambient occlusion specialized for trees. The "Nature/Soft Occlusion" shaders need this information. If you don't follow the naming conventions the tree will look weird with completely black parts.

Unity also ships with several high quality trees in the "Terrain Demo.unitypackage". You can use those trees readily in your game. 


Using Low Poly Trees
--------------------



![](http://docwiki.hq.unity3d.com/uploads/Main/lowpolytree.png)  

One branch with leaves is done with only six triangles and shows quite a bit of curvature. You can add more triangles for even more curvature. But the main point is: When making trees, work with triangles not with quads. If you use quads you basically need twice as many triangles to get the same curvature on branches.

The tree itself wastes a lot of fillrate by having large polygons but almost everything is invisible due to the alpha. This should be avoided for performance reasons and of course because the goal is to make dense trees. This is one of the things that makes Oblivion's trees look great. They are so dense you cant even see through the leaves.


Setting up Tree Collisions
--------------------------


If you'd like your trees to make use of colliders, it's very easy.  When you've imported your Tree asset file, all you need to do is instantiate it in the Scene View, add a <span class=keyword>Capsule Collider</span> and tweak it, and make the GameObject into a new Prefab.  Then when you're adding trees to your Terrain, you add the tree Prefab with the Capsule Collider attached. You can only use Capsule Colliders when adding collisions with trees.

Making your Trees Collide.
--------------------------


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainCollider.png)  
_Terrain Collider Inspector_

If you want to make your trees collide with rigid bodies, make sure you you check the _Create Tree Colliders_ box. else your objects will go trough the trees you create. Note that the PhysX engine used by Unity only handles a maximum of 65536 colliders in a scene. If you use more trees then that (minus the other colliders already in the scene), then enabling tree colliders will fail with an error.

