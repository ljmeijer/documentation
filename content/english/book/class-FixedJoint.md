Fixed Joint
===========


<span class=keyword>Fixed Joints</span> restricts an object's movement to be dependent upon another object.  This is somewhat similar to <span class=keyword>Parenting</span> but is implemented through physics rather than <span class=keyword>Transform</span> hierarchy.  The best scenarios for using them are when you have objects that you want to easily break apart from each other, or connect two object's movement without parenting.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-FixedJoint.png)  
_The Fixed Joint <span class=keyword>Inspector</span>_


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Connected Body</span> |Optional reference to the Rigidbody that the joint is dependent upon. If not set, the joint connects to the world. |
|<span class=component>Break Force</span>   |The force that needs to be applied for this joint to break. |
|<span class=component>Break Torque</span>  |The torque that needs to be applied for this joint to break. |


Details
-------


There may be scenarios in your game where you want objects to stick together permanently or temporarily.  Fixed Joints may be a good <span class=keyword>Component</span> to use for these scenarios, since you will not have to script a change in your object's hierarchy to achieve the desired effect. The trade-off is that you must use <span class=keyword>Rigidbodies</span> for any objects that use a Fixed Joint.

For example, if you want to use a "sticky grenade", you can write a script that will detect collision with another Rigidbody (like an enemy), and then create a Fixed Joint that will attach itself to that Rigidbody.  Then as the enemy moves around, the joint will keep the grenade stuck to them.


###Breaking joints

You can use the <span class=component>Break Force</span> and <span class=component>Break Torque</span> properties to set limits for the joint's strength.  If these are less than infinity, and a force/torque greater than these limits are applied to the object, its Fixed Joint will be destroyed and will no longer be confined by its restraints.


Hints
-----

* You do not need to assign a <span class=component>Connected Body</span> to your joint for it to work.
* Fixed Joints require a Rigidbody.
