NavMesh Agent (Pro Only)
========================


The <span class=component>NavMesh Agent</span> component is used in connection with pathfinding, and is the place to put information about how this agent navigates the  [NavMesh](NavmeshandPathfinding.md). You can access it in <span class=menu>Component->Navigation->Nav Mesh Agent</span>


![](http://docwiki.hq.unity3d.com/uploads/Main/NavMeshAgent.png)  


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Radius</span>|Agent radius (used for pathfinding purposes only, and can differ from the actual object's radius, typically larger). |
|<span class=component>Speed</span> |Maximum movement speed with which the agent can traverse the world toward its destination.|
|<span class=component>Acceleration</span> |Maximum acceleration.|
|<span class=component>Angular Speed</span> |Maximum rotation speed in (deg/s).|
|<span class=component>Stopping distance</span> |Stopping distance. The agent will decelerate when within this distance to the destination.|
|<span class=component>Auto Traverse OffMesh Link</span>	|Automate movement onto and off of OffMeshLinks.
|<span class=component>Auto Repath</span> |Acquire new path if existing is partial or invalid.
|<span class=component>Height</span>|The height of the agent (used in debug graphics).
|<span class=component>Base offset</span> |Vertical offset of the collision geometry relative to the actual geometry.
|<span class=component>Obstacle Avoidance Type</span> |The level of quality of avoidance.
|<span class=component>NavMesh Walkable</span> |Specifies the types of [Navmesh layers](class-NavMeshLayers.md) that the agent can traverse.

(back to [Navigation and Pathfinding](NavmeshandPathfinding.md))
