Hinge Joint
===========


The <span class=keyword>Hinge Joint</span> groups together two [Rigidbodies](class-Rigidbody.md), constraining them to move like they are connected by a hinge. It is perfect for doors, but can also be used to model chains, pendulums, etc.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-HingeJoint.png)  
_The Hinge Joint <span class=keyword>Inspector</span>_

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Connected Body</span> |Optional reference to the Rigidbody that the joint is dependent upon. If not set, the joint connects to the world. |
|<span class=component>Anchor</span> |The position of the axis around which the body swings. The position is defined in local space. |
|<span class=component>Axis</span> |The direction of the axis around which the body swings. The direction is defined in local space. |
|<span class=component>Use Spring</span> |Spring makes the Rigidbody reach for a specific angle compared to its connected body. |
|<span class=component>Spring</span> |Properties of the Spring that are used if <span class=component>Use Spring</span> is enabled. |
|>>><span class=component>Spring</span> |The force the object asserts to move into the position. |
|>>><span class=component>Damper</span> |The higher this value, the more the object will slow down. |
|>>><span class=component>Target Position</span> |Target angle of the spring. The spring pulls towards this angle measured in degrees. |
|<span class=component>Use Motor</span> |The motor makes the object spin around. |
|<span class=component>Motor</span> |Properties of the Motor that are used if <span class=component>Use Motor</span> is enabled. |
|>>><span class=component>Target Velocity</span> |The speed the object tries to attain. |
|>>><span class=component>Force</span> |The force applied in order to attain the speed. |
|>>><span class=component>Free Spin</span> |If enabled, the motor is never used to brake the spinning, only accelerate it. |
|<span class=component>Use Limits</span> |If enabled, the angle of the hinge will be restricted within the <span class=component>Min</span> & <span class=component>Max</span> values. |
|<span class=component>Limits </span> |Properties of the Limits that are used if <span class=component>Use Limits</span> is enabled. |
|>>><span class=component>Min</span> |The lowest angle the rotation can go. |
|>>><span class=component>Max</span> |The highest angle the rotation can go. |
|>>><span class=component>Min Bounce</span> |How much the object bounces when it hits the minimum stop. |
|>>><span class=component>Max Bounce</span> |How much the object bounces when it hits the maximum stop. |
|<span class=component>Break Force</span> |The force that needs to be applied for this joint to break. |
|<span class=component>Break Torque</span> |The torque that needs to be applied for this joint to break. |


Details
-------


A single Hinge Joint should be applied to a <span class=keyword>GameObject</span>.  The hinge will rotate at the point specified by the <span class=component>Anchor</span> property, moving around the specified <span class=component>Axis</span> property.  You __do not__ need to assign a GameObject to the joint's <span class=component>Connected Body</span> property.  You should only assign a GameObject to the <span class=component>Connected Body</span> property if you want the joint's <span class=keyword>Transform</span> to be dependent on the attached object's Transform.

Think about how the hinge of a door works. The <span class=component>Axis</span> in this case is up, positive along the Y axis. The <span class=component>Anchor</span> is placed somewhere at the intersection between door and wall.  You would not need to assign the wall to the <span class=component>Connected Body</span>, because the joint will be connected to the world by default.

Now think about a doggy door hinge. The doggy door's <span class=component>Axis</span> would be sideways, positive along the relative X axis.  The main door should be assigned as the <span class=component>Connected Body</span>, so the doggy door's hinge is dependent on the main door's Rigidbody.


###Chains

Multiple Hinge Joints can also be strung together to create a chain.  Add a joint to each link in the chain, and attach the next link as the <span class=component>Connected Body</span>.


Hints
-----

* You do not need to assign a <span class=component>Connected Body</span> to your joint for it to work.
* Use <span class=component>Break Force</span> in order to make dynamic damage systems. This is really cool as it allows the player to break a door off its hinge by blasting it with a rocket launcher or running into it with a car.
* The <span class=component>Spring</span>, <span class=component>Motor</span>, and <span class=component>Limits</span> properties allow you to fine-tune your joint's behaviors.

