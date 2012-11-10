Character Joint
===============


<span class=keyword>Character Joints</span> are mainly used for Ragdoll effects. They are an extended ball-socket joint which allows you to limit the joint on each axis.

If you just want to set up a ragdoll read about [Ragdoll Wizard](wizard-RagdollWizard.md).


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-CharacterJoint.png)  
_The Character Joint on a Ragdoll_


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Connected Body</span> |Optional reference to the <span class=keyword>Rigidbody</span> that the joint is dependent upon. If not set, the joint connects to the world. |
|<span class=component>Anchor</span> |The point in the <span class=keyword>GameObject's</span> local space where the joint rotates around. |
|<span class=component>Axis</span> |The twist axes. Visualized with the orange gizmo cone. |
|<span class=component>Swing Axis</span> |The swing axis. Visualized with the green gizmo cone. |
|<span class=component>Low Twist Limit</span> |The lower limit of the joint. |
|<span class=component>High Twist Limit</span> |The higher limit of the joint. |
|<span class=component>Swing 1 Limit</span> |Lower limit around the defined <span class=component>Swing Axis</span> |
|<span class=component>Swing 2 Limit</span> |Upper limit around the defined <span class=component>Swing Axis</span> |
|<span class=component>Break Force</span> |The force that needs to be applied for this joint to break. |
|<span class=component>Break Torque</span> |The torque that needs to be applied for this joint to break. |


Details
-------


Character joint's give you a lot of possibilities for constraining motion like with a universal joint.

The twist axis (visualized with the orange gizmo) gives you most control over the limits as you can specify a lower and upper limit in degrees (the limit angle is measured relative to the starting position). A value of -30 in <span class=component>Low Twist Limit</span>-><span class=component>Limit</span> and 60 in <span class=component>High Twist Limit</span>-><span class=component>Limit</span> limits the rotation around the twist axis (orange gizmo) between -30 and 60 degrees.

The <span class=component>Swing 1 Limit</span> limits the rotation around the swing axis (green axis). The limit angle is symmetric. Thus a value of eg. 30 will limit the rotation between -30 and 30.

The <span class=component>Swing 2 Limit</span> axis doesn't have a gizmo but the axis is orthogonal to the 2 other axes.
Just like the previous axis the limit is symmetric, thus a value of eg. 40 will limit the rotation around that axis between -40 and 40 degrees.


###Breaking joints

You can use the <span class=component>Break Force</span> and <span class=component>Break Torque</span> properties to set limits for the joint's strength.  If these are less than infinity, and a force/torque greater than these limits are applied to the object, its Fixed Joint will be destroyed and will no longer be confined by its restraints.

Hints
-----

* You do not need to assign a <span class=component>Connected Body</span> to your joint for it to work.
* Character Joints require your object to have a Rigidbody attached.

