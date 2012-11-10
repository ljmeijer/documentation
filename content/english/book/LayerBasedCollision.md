Layer-Based Collision Detection.
================================

In Unity 3.x we introduce Layer-Based collision detection, which is a way to make <span class=keyword>Game Objects</span> collide with another specific <span class=keyword>Game Objects</span> that are tied up to specific layers.


![](http://docwiki.hq.unity3d.com/uploads/Main/LayerBasedCollision.png)  
_Objects Colliding with their own layer._

In the image above you can see 6 GameObjects, (3 planes, 3 cubes) and the "Collision Matrix" to the right that states which Objects can collide with which layer.
In the example, we have set the Collision Matrix in a way that only GameObjects that belong to same layers can collide.

Setting GameObjects to detect Collisions Based on Layers.
=========================================================

1. Select a layer your Game Objects will belong to
  Attach:LayerBasedCollisionLayer.png
1. Repeat 1 for each Game Object until you have finished assigning your Game Objects to the layers.
1. Open the Physics Preference Panel by clicking on <span class=menu>Edit->Project Settings->Physics</span>.
1. Select which layers on the Collision Matrix will interact with the other layers by checking them.
  Attach:LayerCollisionMatrix.png

