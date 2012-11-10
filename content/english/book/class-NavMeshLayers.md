NavMesh Layers (Pro only)
=========================


The primary task of the navigation system is finding the _optimal_ path between two points in navigation-space. In the simplest case, the optimal path is the shortest path. However, in many complex environments, some areas are harder to move thru than others (for example, crossing a river can be more costly than running across a bridge). To model this, Unity utilizes the concept of _cost_ and the _optimal path_ is defined as the path with the lowest cost. To manage costs, Unity has the concept of <span class=keyword>Navmesh Layers</span>. Each geometry marked up as <span class=component>Navmesh Static</span> will belong to a Navmesh Layer. 

During pathfinding, instead of comparing lengths of potential path segments, the cost of each segment is evaluated. This is a done by scaling the length of each segment by the cost of the navmesh layer for that particular segment. Note that when all costs are set to 1, the optimal path is equivalent to the shortest path. 

To define custom layers per project
* Go to <span class=menu>Edit</span>-><span class=menu>Project Settings</span>-><span class=menu>Navmesh Layers</span>

![](http://docwiki.hq.unity3d.com/uploads/Main/NavMeshLayers.png)  

* Go to one of the user layers, and set up name and cost
    * The name is what will be used everywhere in the scene for identifying the navmesh layer
    * The cost indicates how difficult it is to traverse the NavMesh layer. 1 is default, 2.0 is twice as difficult, 0.5 is half as difficult, etc.
* There are 3 built-in layers
    * Default - specifies the cost for everything not otherwise specified
    * Not walkable - the cost is ignored
    * Jump - the cost of automatically generated off-mesh links

To apply custom layers to specific geometry
* Select the geometry in the editor
* Pull up the <span class=menu>Navigation Mesh</span> window (<span class=menu>Window</span>-><span class=menu>Navigation</span>)
* Go to the <span class=menu>Object</span> tab, and select the desired <span class=menu>Navigation layer</span> for that object

![](http://docwiki.hq.unity3d.com/uploads/Main/NavigationMeshObjectWindow.png)  

* If you have <span class=menu>Show NavMesh</span> enabled in the <span class=menu>Navmesh Display</span> window, the different layers should show up in different colors in the editor.

To tell an agent what layers he can or cannot traverse
* Go to the <span class=component>NavMeshAgent</span> component of the agent's geometry
* Modify <span class=component>NavMesh Walkable</span> property
* Don't forget to set the agent's <span class=component>destination</span> property from a script


_Note: Setting the cost value below 1 is not recommended, as the underlying pathfinding method does not guarantee an optimal path in this case_

One good use case for using Navmesh Layers is: 
* You have a road that pedestrians (NavmeshAgents) need to cross.
* The pedestrian walkway in the middle is the preferred place for them to go
* Set up a navmesh layer with high cost for most of the road, and a navmesh layer with a low cost for the pedestrian walkway.
* This will cause agents to prefer paths that go thru the pedestrian walkway.
Another relevant topic for advanced pathfinding is [Off-mesh links](class-OffMeshLink.md)

(back to [Navigation and Pathfinding](NavmeshandPathfinding.md))
