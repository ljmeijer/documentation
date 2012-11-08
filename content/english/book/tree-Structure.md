Tree Creator Structure
======================


The Tree Creator's inspector is split into three different panes: Hierarchy, Editing Tools and Properties.

Hierarchy
---------


The hierarchy view is where you start building your tree. It shows a schematic representation of the tree, where each box is a group of nodes. By selecting one of the groups in the hierarchy you can modify its properties. You may also add or remove groups by clicking one of the buttons in the toolbar below the hierarchy.


![](http://docwiki.hq.unity3d.com/uploads/Main/treeEditor-HierarchyView.png)  
(:comment image source treeEditor-HierarchyView.psd :)
This hierarchy represents a tree with one trunk, 25 child branches. Child branches have in total 70 fronds attached, 280 leaves and 25 fronds with branches. Node representing the last group is selected. Also the trunk has 25 leaves of one type and 15 of another type, the last group is hidden.


|    |    |
|:---|:---|
|<span class=component>Tree Stats</span>     |Status information about your tree, tells you how many vertices, triangles and materials the tree has.|
|<span class=component>Delete Node</span>    |Deletes the currently selected group in the Hierarchy or a node or a spline point in the Scene View.|
|<span class=component>Copy Node</span>      |Copies the currently selected group.|
|<span class=component>Add Branch</span>     |Adds a branch group node to the currently selected group node.|
|<span class=component>Add Leaf</span>       |Adds a leaf group node to the currently selected group node.|
|<span class=component>External Reload</span>|Recomputes the whole tree, should be used when the source materials have changed or when a mesh used in Mesh <span class=component>Geometry Mode</span> on leaves has changed.|


Nodes in the tree hierarchy represent groups of elements in the tree itself, i.e. branches, leaves or fronds. There are 5 types of nodes:

###Root Node:

![](http://docwiki.hq.unity3d.com/uploads/Main/TreeEditor-RootNode.png)  

This is the starting point of a tree. It determines the global parameters for a tree, such as: quality, seed to diversify the trees, ambient occlusion and some material properties.

###Branch Nodes

![](http://docwiki.hq.unity3d.com/uploads/Main/TreeEditor-BranchNode.png)  

First branch group node attached to the root node creates trunk(s). The following branch nodes will create child branches. Various shape, growth and breaking parameters can be set on this type of node.

###Leaf Node

![](http://docwiki.hq.unity3d.com/uploads/Main/TreeEditor-LeafNode.png)  

Leaves can be attached to a root node (e.g. for small bushes) or to branch nodes. Leaves are final nodes, meaning no other nodes can be attached to them. Various geometry and distribution parameters can be set on this type of a node.

###Frond Node

![](http://docwiki.hq.unity3d.com/uploads/Main/TreeEditor-FrondNode.png)  

It has a similar behavior as the branch node, with some of the shape properties disabled and frond specific ones added.

###Branch + Frond Node

![](http://docwiki.hq.unity3d.com/uploads/Main/TreeEditor-BranchFrondNode.png)  

This kind of node is a mixture of a branch and a frond, with properties of both types being accessible.

Node Parameters
---------------

* Number at the top right of each node represents the number of elements this node created in the tree. The value is related to the frequency parameter from the Distribution tab.
* A node can be visible (Attach:TreeEditor-VisibleNode.png) or invisible (Attach:TreeEditor-InvisibleNode.png).
* If a node was edited manually (branch splines or leaves were manipulated in the Scene View) a warning sign will appear over the node (Attach:TreeEditor-ManualNode.png). In such a case some procedural properties will be disabled.


Editing Tools
=============



![](http://docwiki.hq.unity3d.com/uploads/Main/TreeEditor-TreeEditingTools.png)  
  
While the Tree Creator works with procedural elements, you can decide at any time to modify them by hand to achieve the exact positioning and shape of elements you want.
Once you have edited a group by hand, certain procedural properties will no longer be available. You can, however, always revert it to a procedural group by clicking the button displayed in the <span class=menu>Branch/Leaf Group Properties</span>.



|    |    |
|:---|:---|
|<span class=component>Move</span>             |Select a node or a spline point in the Scene View. Dragging the node allows you to move it along and around its parent. Spline points can be moved using the normal move handles.|
|<span class=component>Rotate</span>           |Select a node or a spline point in the Scene View. Both will show the normal rotation handles.|
|<span class=component>Free Hand Drawing</span>|Click on a spline point and drag the mouse to draw a new shape. Release the mouse to complete the drawing. Drawing always happens on a plane perpendicular to the viewing direction.|



Global Tree Properties
======================

Every tree has a root node which contains the global properties. This is the least complex group type, but it contains some important properties that control the rendering and generation of the entire tree.

Distribution
------------

Allows for diversifying trees by changing the <span class=component>Tree Seed</span> and making groups of trees by adjusting the <span class=component>Area Spread</span> when the frequency on the branch node connected to the root node is higher than 1.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeNode-RootPropertiesDistribution.png)  


|    |    |
|:---|:---|
|<span class=component>Tree Seed</span>    |The global seed that affects the entire tree. Use it to randomize your tree, while keeping the general structure of it.|
|<span class=component>Area Spread</span>  |Adjusts the spread of trunk nodes. Has an effect only if you have more than one trunk.|
|<span class=component>Ground Offset</span>|Adjusts the offset of trunk nodes on Y axis.|


Geometry
--------

Allows to set the overall quality of the tree geometry and to control ambient occlusion.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeNode-RootPropertiesGeometry.png)  


|    |    |
|:---|:---|
|<span class=component>LOD Quality</span>      |Defines the level-of-detail for the entire tree. A low value will make the tree less complex, a high value will make the tree more complex. Check the statistics in the hierarchy view to see the current complexity of the mesh. Depending on the type of the tree and your target platform, you may need to adjust this property to make the tree fit within your polygon budget. With careful creation of art assets you can produce good looking trees with relatively few polygons.|
|<span class=component>Ambient Occlusion</span>|Toggles ambient occlusion on or off. While modifying tree properties ambient occlusion is always hidden and won't be recomputed until you finish your changes, e.g. let go a slider. Ambient occlusion can greatly improve the visual quality of your tree, but its computation takes time, so you may want to disable it until you are happy with the shape of your tree.|
|<span class=component>AO Density</span>       |Adjusts the density of ambient occlusion. The higher the value the darker the effect.|

Material
--------

Controls the global material properties of the tree.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeNode-RootPropertiesMaterial.png)  

Translucency is one of the effects you can control in the Material properties. That property has an effect on leaves, which are translucent meaning that they permit the light to pass through them, but they diffuse it on the way.


|    |    |
|:---|:---|
|<span class=component>Translucency Color</span>             |The color that will be multiplied in when the leaves are backlit.|
|<span class=component>Translucency View Dependency</span>   |Fully view dependent translucency is relative to the angle between the view direction and the light direction. View independent is relative to the angle between the leaf's normal vector and the light direction.|
|<span class=component>Alpha Cutoff</span>                   |Alpha values from the base texture smaller than the alpha cutoff are clipped creating a cutout.|
|<span class=component>Shadow Strength</span>                |Makes the shadows on the leaves less harsh. __Note:__ Since it scales all the shadowing that the leaves receive, it should be used with care for trees that are e.g. in a shadow of a mountain.|
|<span class=component>Shadow Offset</span>                  |Scales the values from the Shadow Offset texture set in the source material. It is used to offset the position of the leaves when collecting the shadows, so that the leaves appear as if they were not placed on one quad. It's especially important for billboarded leaves and they should have brighter values in the center of the texture and darker ones at the border. Start out with a black texture and add different shades of gray per leaf.|
|<span class=component>Shadow Caster Resolution</span>       |Defines the resolution of the texture atlas containing alpha values from source diffuse textures. The atlas is used when the leaves are rendered as shadow casters. Using lower resolution might increase performance.|

[Branches](tree-Branches.md)
============================

This section focuses on explaining the specific [Branch Group Properties](tree-Branches.md).


[Leaves](tree-Leaves.md)
========================

This section focuses on explaining the specific [Leaf Group Properties](tree-Leaves.md).

