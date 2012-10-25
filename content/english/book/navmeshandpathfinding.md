Navmesh and Pathfinding (Pro only)
==================================


A navigation mesh (also known as the _Navmesh_) is a simplified representation of world geometry, which gameplay agents use to navigate the world. Typically an agent has a _goal_, or a _destination_, to which it is trying to find a path, and then navigate to that goal along the path. This process is called _pathfinding_. Note that _Navmesh generation_ (or _baking_) is done by game developers inside the editor, while the _pathfinding_ is done by agents at runtime based on that Navmesh.

In the complex world of games, there can be many agents, dynamic obstacles, and constantly changing accessibility levels for different areas in the world. Agents need to react dynamically to those changes. An agent's pathfinding task can be interrupted by or affected by things like collision avoidance with other characters, changing characteristics of the terrain, physical obstacles (such as closing doors), and an update to the actual destination. 

Here is a simple example of how to set up a navmesh, and an agent that will do pathfinding on it:

* Create some geometry in the level, for example a <span class=keyword>Plane</span> or a <span class=keyword>Terrain</span>.
* In the Inspector Window's right hand corner click on <span class=menu>Static</span> and make sure that this geometry is marked up as <span class=menu>Navigation Static</span>
->Attach:NavmeshStaticPulldown.png

* Pull up the Navigation Mesh window (<span class=menu>Window</span>-><span class=menu>Navigation</span>).
* [Bake the mesh](Navmeshbaking). This will generate the navmesh for all <span class=keyword>navigation-static</span> geometry.
* Create some dynamic geometry in the scene (such as characters).
* Set up an agent (or multiple agents), by adding a [NavMeshAgent](class-NavMeshAgent) component to a dynamic geometry in the scene.
* Give the agent a destination (by setting the _destination_ property) in a script attached to the agent.
* Press play and watch the magic.

Note that it is also possible to define custom [NavMesh layers](class-NavMeshLayers). These are needed for situations where some parts of the environment are easier for agents to pass through than others. For parts of the mesh that are not directly connected, it is possible to create [Off Mesh Links](class-OffMeshLink).

Automatic off-mesh links
------------------------

Navmesh geometry can also be marked up for automatic off-mesh link generation, like this:

![](http://docwiki.hq.unity3d.com/uploads/Main/NavmeshStaticPlusOffmesh.png)  
_Marking up geometry for automatic off-mesh link generation_

Geometry marked up in this way will be checked during the [Navmesh Baking](Navmeshbaking) process for creating links to other Navmesh geometry. This way, we can control the auto-generation for each GameObject. Whether an off-mesh link will be auto-generated in the baking process is also determined by the <span class=component>Jump distance</span> and the <span class=component>Drop height</span> properties in the <span class=menu>Navigation Bake</span> settings. 

The NavMeshLayer assigned to auto-generated off-mesh links, is the built-in layer <span class=component>Jump</span>. This allows for global control of the auto-generated off-mesh links costs (see [Navmesh layers](class-NavMeshLayers)).

Note, that there is also a possibility for setting up _manual_ off-mesh links (described [here](class-OffMeshLink)).
