Spring Joint
============

The <span class=keyword>Spring Joint</span> groups together two <span class=keyword>Rigidbodies</span>, constraining them to move like they are connected by a spring.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-SpringJoint.png)  
_The Spring Joint <span class=keyword>Inspector</span>_

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Connected Body</span> |Optional reference to the Rigidbody that the joint is dependent upon.|
|<span class=component>Anchor</span>         |Position in the object's local space (at rest) that defines the center of the joint. This is not the point that the object will be drawn toward.|
|>>><span class=component>X</span>           |Position of the joint's local center along the X axis. |
|>>><span class=component>Y</span>           |Position of the joint's local center along the Y axis. |
|>>><span class=component>Z</span>           |Position of the joint's local center along the Z axis. |
|<span class=component>Spring</span>       |Strength of the spring.|
|<span class=component>Damper</span>       |Amount that the spring is reduced when active. |
|<span class=component>Min Distance</span> |Distances greater than this will not cause the Spring to activate. |
|<span class=component>Max Distance</span> |Distances less than this will not cause the Spring to activate. |
|<span class=component>Break Force</span>  |The force that needs to be applied for this joint to break. |
|<span class=component>Break Torque</span> |The torque that needs to be applied for this joint to break. |

Details
-------


Spring Joints allows a Rigidbodied <span class=keyword>GameObject</span> to be pulled toward a particular "target" position.  This position will either be another Rigidbodied GameObject or the world.  As the GameObject travels further away from this "target" position, the Spring Joint applies forces that will pull it back to its original "target" position.  This creates an effect very similar to a rubber band or a slingshot.

The "target" position of the Spring is determined by the relative position from the <span class=component>Anchor</span> to the <span class=component>Connected Body</span> (or the world) when the Spring Joint is created, or when Play mode is entered.  This makes the Spring Joint very effective at setting up Jointed characters or objects in the Editor, but is harder to create push/pull spring behaviors in runtime through scripting.  If you want to primarily control a GameObject's position using a Spring Joint, it is best to create an empty GameObject with a Rigidbody, and set that to be the <span class=component>Connected Rigidbody</span> of the Jointed object.  Then in scripting you can change the position of the <span class=component>Connected Rigidbody</span> and see your Spring move in the ways you expect.

###Connected Rigidbody
You do not need to use a <span class=component>Connected Rigidbody</span> for your joint to work.  Generally, you should only use one if your object's position and/or rotation is dependent on it.  If there is no <span class=component>Connected Rigidbody</span>, your Spring will connect to the world.

###Spring & Damper

<span class=component>Spring</span> is the strength of the force that draws the object back toward its "target" position.  If this is 0, then there is no force that will pull on the object, and it will behave as if no Spring Joint is attached at all.

<span class=component>Damper</span> is the resistance encountered by the <span class=component>Spring</span> force.  The lower this is, the springier the object will be.  As the <span class=component>Damper</span> is increased, the amount of bounciness caused by the Joint will be reduced.

###Min & Max Distance

If the position of your object falls in-between the <span class=component>Min</span> & <span class=component>Max Distances</span>, then the Joint will not be applied to your object.  The position must be moved outside of these values for the Joint to activate.

Hints
-----

* You do not need to assign a <span class=component>Connected Body</span> to your Joint for it to work.
* Set the ideal positions of your Jointed objects in the Editor prior to entering Play mode.
* Spring Joints require your object to have a Rigidbody attached.

