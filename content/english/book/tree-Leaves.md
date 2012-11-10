Leaf Group Properties
=====================


Leaf groups generate leaf geometry. Either from primitives or from user created meshes.

Distribution
------------

Adjusts the count and placement of leaves in the group. Use the curves to fine tune position, rotation and scale. The curves are relative to the parent branch.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeNode-LeafNodePropertiesDistribution.png)  


|    |    |
|:---|:---|
|<span class=component>Group Seed</span>  |The seed for this group of leaves. Modify to vary procedural generation.|
|<span class=component>Frequency</span>   |Adjusts the number of leaves created for each parent branch.|
|<span class=component>Distribution</span>|Select the way the leaves are distributed along their parent.|
|<span class=component>Twirl</span>       |Twirl around the parent branch.|
|<span class=component>Whorled Step</span>|Defines how many nodes are in each whorled step when using Whorled distribution. For real plants this is normally a Fibonacci number.|
|<span class=component>Growth Scale</span>|Defines the scale of nodes along the parent node. Use the curve to adjust and the slider to fade the effect in and out.|
|<span class=component>Growth Angle</span>|Defines the initial angle of growth relative to the parent. Use the curve to adjust and the slider to fade the effect in and out.|

Geometry
--------

Select what type of geometry is generated for this leaf group and which materials are applied. If you use a custom mesh, its materials will be used.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeNode-LeafNodePropertiesGeometry.png)  


|    |    |
|:---|:---|
|<span class=component>Geometry Mode</span>|The type of geometry created. You can use a custom mesh, by selecting the Mesh option, ideal for flowers, fruits, etc.|
|<span class=component>Material</span>     |Material used for the leaves.|
|<span class=component>Mesh</span>         |Mesh used for the leaves.|

Shape
-----

Adjusts the shape and growth of the leaves.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeNode-LeafNodePropertiesShape.png)  


|    |    |
|:---|:---|
|<span class=component>Size</span>               |Adjusts the size of the leaves, use the range to adjust the minimum and the maximum size.|
|<span class=component>Perpendicular Align</span>|Adjusts whether the leaves are aligned perpendicular to the parent branch.|
|<span class=component>Horizontal Align</span>   |Adjusts whether the leaves are aligned horizontally.|

Animation
---------

Adjusts the parameters used for animating this group of leaves. Wind zones are only active in Play Mode. If you select too high values for Main Wind and Main Turbulence the leaves may float away from the branches.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeNode-LeafNodePropertiesAnimation.png)  


|    |    |
|:---|:---|
|<span class=component>Main Wind</span>      |Primary wind effect. Usually this should be kept as a low value to avoid leaves floating away from the parent branch.|
|<span class=component>Main Turbulence</span>|Secondary turbulence effect. For leaves this should usually be kept as a low value.|
|<span class=component>Edge Turbulence</span>|Defines how much wind turbulence occurs along the edges of the leaves.|

