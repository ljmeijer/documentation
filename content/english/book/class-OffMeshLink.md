Off-mesh links (Pro only)
=========================


Note that this section is primarily about the _manual_ off-mesh links, namely those that are set up by the user via the <span class=component>OffMeshLink</span> component. For automatically generated off-mesh links, see the the [Navmesh intro](NavmeshandPathfinding.md)


![](http://docwiki.hq.unity3d.com/uploads/Main/OffMeshLinkInScene.png)  

It is possible that the _navmesh static_ geometry in the scene is disconnected, thus making it impossible for agents to get from one part of the world to the other.

To remedy this, Unity has a system of <span class=keyword>Off-mesh links</span>


![](http://docwiki.hq.unity3d.com/uploads/Main/OffMeshLink.png)  
_The OffMeshLink component_

An off-mesh link is a component that can be placed on any object, and it has the following properties


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Start</span> |The start object of the off-mesh link.
|<span class=component>End</span>    |The end object of the off-mesh link.
|<span class=component>Cost Override</span>|If value is positive, use it when calculating path cost on processing a path request. Otherwise, we use the default cost (cost of the layer to which this game object belongs). If the Cost Override is set to the value 3.0, moving over the off-mesh link will be three times more expensive than moving the same distance on a default NavMesh area. _This property is runtime-editable and does not require a re-bake_
|<span class=component>Bi Directional</span>|If this is on, the link can be traversed both ways, if it's off, the link can only be traversed in the direction from Start to End.
|<span class=component>Activated</span>   |Specifies if this link is actually used by the pathfinder. When this property is false, the off-mesh link will be disregarded. _This property is runtime-editable, and does not require a re-bake._


Special notes on OffMeshLink properties
---------------------------------------


The "Activated" and "Cost Override" properties can be changed at runtime and
have immediate effect. All other properties require a Navmesh re-bake before they effect. 

If the start or end transforms are unassigned when baking, or if the position of either the start or end transforms is too far away from the NavMesh to find valid positions, the off-mesh links will not be generated. In this case, an error is displayed in the Console window.


(back to [Navigation and Pathfinding](NavmeshandPathfinding.md))
