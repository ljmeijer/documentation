Branch Group Properties
=======================


Branch groups node is responsible for generating branches and fronds. Its properties appear when you have selected a branch, frond or branch + frond node.

Distribution
------------

Adjusts the count and placement of branches in the group. Use the curves to fine tune position, rotation and scale. The curves are relative to the parent branch or to the area spread in case of a trunk.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeNode-BranchPropertiesDistribution.png)  


|    |    |
|:---|:---|
|<span class=component>Group Seed</span>  |The seed for this group of branches. Modify to vary procedural generation.|
|<span class=component>Frequency</span>   |Adjusts the number of branches created for each parent branch.|
|<span class=component>Distribution</span>|The way the branches are distributed along their parent.|
|<span class=component>Twirl</span>       |Defines how many nodes are in each whorled step when using Whorled distribution. For real plants this is normally a Fibonacci number.|
|<span class=component>Growth Scale</span>|Defines the scale of nodes along the parent node. Use the curve to adjust and the slider to fade the effect in and out.|
|<span class=component>Growth Angle</span>|Defines the initial angle of growth relative to the parent. Use the curve to adjust and the slider to fade the effect in and out.|


Geometry
--------

Select what type of geometry is generated for this branch group and which materials are applied. <span class=component>LOD Multiplier</span> allows you to adjust the quality of this group relative to tree's <span class=component>LOD Quality</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeNode-BranchPropertiesGeometry.png)  


|    |    |
|:---|:---|
|<span class=component>LOD Multiplier</span> |Adjusts the quality of this group relative to tree's LOD Quality, so that it is of either higher or lower quality than the rest of the tree.|
|<span class=component>Geometry Mode</span>  |Type of geometry for this branch group: Branch Only, Branch + Fronds, Fronds Only.|
|<span class=component>Branch Material</span>|The primary material for the branches.|
|<span class=component>Break Material</span> |Material for capping broken branches.|
|<span class=component>Frond Material</span> |Material for the fronds.|


Shape
-----

Adjusts the shape and growth of the branches. Use the curves to fine tune the shape, all curves are relative to the branch itself.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeNode-BranchPropertiesShape.png)  


|    |    |
|:---|:---|
|<span class=component>Length</span>            |Adjusts the length of the branches.|
|<span class=component>Relative Length</span>   |Determines whether the radius of a branch is affected by its length.|
|<span class=component>Radius</span>            |Adjusts the radius of the branches, use the curve to fine-tune the radius along the length of the branches.|
|<span class=component>Cap Smoothing</span>     |Defines the roundness of the cap/tip of the branches. Useful for cacti.|
|!Growth               |!Adjusts the growth of the branches.|
|<span class=component>Crinkliness</span>       |Adjusts how crinkly/crooked the branches are, use the curve to fine-tune.|
|<span class=component>Seek Sun</span>          |Use the curve to adjust how the branches are bent upwards/downwards and the slider to change the scale.|
|!Surface Noise        |!Adjusts the surface noise of the branches.|
|<span class=component>Noise</span>             |Overall noise factor, use the curve to fine-tune.|
|<span class=component>Noise Scale U</span>     |Scale of the noise around the branch, lower values will give a more wobbly look, while higher values gives a more stochastic look.|
|<span class=component>Noise Scale V</span>     |Scale of the noise along the branch, lower values will give a more wobbly look, while higher values gives a more stochastic look.|
|!Flare                |!Defines a flare for the trunk.|
|<span class=component>Flare Radius</span>      |The radius of the flares, this is added to the main radius, so a zero value means no flares.|
|<span class=component>Flare Height</span>      |Defines how far up the trunk the flares start.|
|<span class=component>Flare Noise</span>       |Defines the noise of the flares, lower values will give a more wobbly look, while higher values gives a more stochastic look.|


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeNode-BranchPropertiesShapeFrond.png)  

__These properties are for child branches only, not trunks.__

|    |    |
|:---|:---|
|! Welding             |!Defines the welding of branches onto their parent branch. Only valid for secondary branches.|
|<span class=component>Weld Length</span>       |Defines how far up the branch the weld spread starts.|
|<span class=component>Spread Top</span>        |Weld's spread factor on the top-side of the branch, relative to it's parent branch. Zero means no spread.|
|<span class=component>Spread Bottom</span>     |Weld's spread factor on the bottom-side of the branch, relative to it's parent branch. Zero means no spread.|


Breaking
--------

Controls the breaking of branches.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeNode-BranchPropertiesBreaking.png)  


|    |    |
|:---|:---|
|<span class=component>Break Chance</span>  |Chance of a branch breaking, i.e. 0 = no branches are broken, 0.5 = half of the branches are broken, 1.0 = all the branches are broken.|
|<span class=component>Break Location</span>|This range defines where the branches will be broken. Relative to the length of the branch.|


Fronds
------

Here you can adjust the number of fronds and their properties. This tab is only available if you have Frond geometry enabled in the <span class=component>Geometry</span> tab.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeNode-BranchPropertiesFronds.png)  


|    |    |
|:---|:---|
|<span class=component>Frond Count</span>   |Defines the number of fronds per branch. Fronds are always evenly spaced around the branch.|
|<span class=component>Frond Width</span>   |The width of the fronds, use the curve to adjust the specific shape along the length of the branch.|
|<span class=component>Frond Range</span>   |Defines the starting and ending point of the fronds.|
|<span class=component>Frond Rotation</span>|Defines rotation around the parent branch.|
|<span class=component>Frond Crease</span>  |Adjust to crease / fold the fronds.|


Animation
---------

Adjusts the parameters used for animating this group of branches. The wind zones are only active in Play Mode.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeNode-BranchPropertiesAnimation.png)  


|    |    |
|:---|:---|
|<span class=component>Main Wind</span>       |Primary wind effect. This creates a soft swaying motion and is typically the only parameter needed for primary branches.|
|<span class=component>Main Turbulence</span> |Secondary turbulence effect. Produces more stochastic motion, which is individual per branch. Typically used for branches with fronds, such as ferns and palms.|
|<span class=component>Edge Turbulence</span> |Turbulence along the edge of fronds. Useful for ferns, palms, etc.|
|<span class=component>Create Wind Zone</span>|Creates a [Wind Zone](class-WindZone.md).|

