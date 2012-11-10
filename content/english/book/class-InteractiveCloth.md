Interactive Cloth
=================


The Interactive  Cloth class is a Component that simulates a "cloth-like" behavior on a mesh. Use this Component if you want to use cloth in your scene.


![](http://docwiki.hq.unity3d.com/uploads/Main/InteractiveCloth.png)  
_Interactive cloth in the scene view and its properties in the inspector._


Properties
----------

Interactive Cloth
-----------------


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Bending Stiffness</span> |Bending stiffness of the cloth.|
|<span class=component>Stretching Stiffness</span> |Stretching Stiffness of the cloth.|
|<span class=component>Damping</span> |Damp cloth motion.|
|<span class=component>Use Gravity</span> |Should Gravity affect the cloth simulation?.|
|<span class=component>External Acceleration</span> |A constant, external acceleration applied to the cloth|
|<span class=component>Random Acceleration</span> |A random, external acceleration applied to the cloth|
|<span class=component>Mesh</span> |Mesh that will be used by the interactive cloth for the simulation|
|<span class=component>Thickness</span> |The thickness of the cloth surface.|
|<span class=component>Friction</span> |The friction of the cloth.|
|<span class=component>Density</span> |The density of the cloth.|
|<span class=component>Pressure</span> |The pressure inside the cloth/|
|<span class=component>Collision Response</span> |How much force will be applied to colliding rigidbodies?.|
|<span class=component>Attachment Tear Factor</span> |How far attached rigid bodies need to be stretched, before they will tear off.|
|<span class=component>Attachment Response</span> |How much force will be applied to attached rigidbodies?.|
|<span class=component>Tear Factor</span> |How far cloth vertices need to be stretched, before the cloth will tear.|
|<span class=component>Attached Colliders</span> |Array that contains the attached colliders to this cloth|
|<span class=component>Self Collision</span> |Will the cloth collide with itself?.|

The Interactive Cloth Component depends of the Cloth Renderer Component, this means that this component cannot be removed if the Cloth Renderer is present in the Game Object.

Cloth Renderer
--------------


|    |    |
|:---|:---|
|<span class=component>Cast Shadows</span> |If selected the cloth will cast shadows|
|<span class=component>Receive Shadows</span> |The cloth can receive Shadows if enabled|
|<span class=component>Lightmap Index</span> |The index of the lightmap applied to this renderer.|
|<span class=component>Lightmap Tiling Offset</span> |The tiling & offset used for lightmap.|
|<span class=component>Materials</span> |Materials that the cloth will use.|
|<span class=component>Pause When Not Visible</span> |If selected, the simulation will not be calculated when the cloth is not being rendered by the camera.|




Adding an Interactive Cloth Game Object
---------------------------------------

To add an Interactive Cloth in the scene just select <span class=component>GameObject->Create Other->Cloth</span>.

Hints.
------

* Using lots of clothes in your game will reduce exponentially the performance of your game.
* If you want to simulate clothing on characters, check out the [Skinned Cloth](class-SkinnedCloth.md) component instead, which interacts with the SkinnedMeshRenderer component and is much faster then InteractiveCloth.
* To attach the cloth to other objects, use the _Attached Colliders_ property to assign other objects to attach to. The colliders must overlap some vertices of the cloth mesh for this to work.
* Attached Colliders' objects must intersect with the cloth you are attaching to.

Notes.
------

* Cloth simulation will generate normals but not tangents. If the source mesh has tangents, these will be passed to the shader unmodified - so if you are using a shader which depends on tangents (such as bump mapped shaders), the lighting will look wrong for cloth which has been moved from it's initial position.

