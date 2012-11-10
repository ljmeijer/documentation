Capsule Collider
================


The <span class=keyword>Capsule Collider</span> is made of two half-spheres joined together by a cylinder.  It is the same shape as the Capsule primitive.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-CapsuleCollider.png)  
_A pile of Capsule Colliders_


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
(:include comp-ColliderProps:)

|    |    |
|:---|:---|
|<span class=component>Radius</span> |The radius of the Collider's local width. |
|<span class=component>Height</span> |The total height of the Collider. |
|<span class=component>Direction</span> |The axis of the capsule's lengthwise orientation in the object's local space. |
|<span class=component>Center</span> |The position of the Collider in the object's local space. |


Details
-------


You can adjust the Capsule Collider's <span class=component>Radius</span> and <span class=component>Height</span> independently of each other.  It is used in the [Character Controller](class-CharacterController.md) and works well for poles, or can be combined with other Colliders for unusual shapes.


![](http://docwiki.hq.unity3d.com/uploads/Main/capsulecollider.png)  
_A standard Capsule Collider_

(:include comp-ColliderDetails:)


Compound Colliders
------------------


(:include comp-ColliderCompound:)


Hints
-----

(:include comp-ColliderHints:)

(:include comp-ColliderAdvanced:)
