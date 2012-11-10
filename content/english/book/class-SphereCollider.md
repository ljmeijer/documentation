Sphere Collider
===============

The <span class=keyword>Sphere Collider</span> is a basic sphere-shaped collision primitive.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-SphereCollider.png)  
_A pile of Sphere Colliders_


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
(:include comp-ColliderProps:)

|    |    |
|:---|:---|
|<span class=component>Radius</span> |The size of the Collider. |
|<span class=component>Center</span> |The position of the Collider in the object's local space. |


Details
-------


The Sphere Collider can be resized to uniform scale, but not along individual axes. It works great for falling boulders, ping pong balls, marbles, etc.


![](http://docwiki.hq.unity3d.com/uploads/Main/spherecollider.png)  
_A standard Sphere Collider_

(:include comp-ColliderDetails:)


Compound Colliders
------------------

(:include comp-ColliderCompound:)


Hints
-----

(:include comp-ColliderHints:)
* If you make an explosion, it can be very effective to add a rigidbody with lots of drag and a sphere collider to it in order to push it out a bit from the wall it hits.

(:include comp-ColliderAdvanced:)
