Configurable Joint
==================


<span class=keyword>Configurable Joints</span> are extremely customizable.  They expose all joint-related properties of PhysX, so they are capable of creating behaviors similar to all other joint types.


![](http://docwiki.hq.unity3d.com/uploads/Main/ConfigurableJointImage.png)  
_Properties of the Configurable Joint_


Details
-------


There are two primary functions that the Configurable Joint can perform: movement/rotation restriction and movement/rotation acceleration.  These functions depend on a number of inter-dependent properties.  It may require some experimentation to create the exact behavior you're trying to achieve.  We'll now give you an overview of the Joint's functionality to make your experimentation as simple as possible.


Movement/Rotation Restriction
-----------------------------


You specify restriction per axis and per motion type.  <span class=component>XMotion</span>, <span class=component>YMotion</span>, and <span class=component>ZMotion</span> allow you to define translation along that axis.  <span class=component>Angular XMotion</span>, <span class=component>Angular YMotion</span>, and <span class=component>Angular ZMotion</span> allow you to define rotation around that axis.  Each one of these properties can be set to <span class=component>Free</span> (unrestricted), <span class=component>Limited</span> (restricted based on limits you can define), or <span class=component>Locked</span> (restricted to zero movement).

###Limiting Motion

When you have any of the <span class=component>"Motion"</span> properties set to <span class=component>Limited</span>, you can define the limitations of movement for that axis.  You do this by changing the values of one of the <span class=component>"Limit"</span> properties.

For translation of movement (non-angular), the <span class=component>Linear Limit</span> property will define the maximum distance the object can move from its origin.  Translation on any <span class=component>"Motion"</span> properties set to <span class=component>Limited</span> will be restricted according to <span class=component>Linear Limit->Limit</span>.  Think of this <span class=component>Limit</span> property as setting a border around the axis for the object.

<span class=component>Bouncyness</span>, <span class=component>Spring</span>, and <span class=component>Damper</span> will define the behavior of the object when it reaches the <span class=component>Limit</span> on any of the <span class=component>Limited</span> <span class=component>"Motion"</span> axes.  If all of these values are set to 0, the object will instantly stop moving when it reaches the border.  <span class=component>Bouncyness</span> will make the object bounce back away from the border.  <span class=component>Spring</span> and <span class=component>Damper</span> will use springing forces to pull the object back to the border.  This will soften the border, so the object will be able to pass through the border and be pulled back instead of stopping immediately.


###Limiting Rotation

Limiting rotation works almost the same as limiting motion.  The difference is that the three <span class=component>"Angular Motion"</span> properties all correspond to different <span class=component>"Angular Limit"</span> properties.  Translation restriction along all 3 axes are defined by the <span class=component>Linear Limit</span> property, and rotation restriction along each of the 3 axes is defined by a separate <span class=component>"Angular Limit"</span> property per axis.

<span class=component>Angular XMotion</span> limitation is the most robust, as you can define a <span class=component>Low Angular XLimit</span> and a <span class=component>High Angular XLimit</span>.  Therefore if you want to define a low rotation limit of -35 degrees and a high rotation limit of 180 degrees, you can do this.  For the Y and Z axes, the low and high rotation limits will be identical, set together by the <span class=component>Limit</span> property of <span class=component>Angular YLimit</span> or <span class=component>Angular ZLimit</span>.

The same rules about object behavior at the rotation limits from the Limiting Motion section applies here.


Movement/Rotation Acceleration
------------------------------


You specify object movement or rotation in terms of moving the object toward a particular position/rotation, or velocity/angular velocity.  This system works by defining the <span class=component>"Target"</span> value you want to move toward, and using a <span class=component>"Drive"</span> to provide acceleration which will move the object toward that target.  Each <span class=component>"Drive"</span> has a <span class=component>Mode</span>, which you use to define which <span class=component>"Target"</span> the object is moving toward.


###Translation Acceleration

The <span class=component>XDrive</span>, <span class=component>YDrive</span>, and <span class=component>ZDrive</span> properties  are what start the object moving along that axis.  Each <span class=component>Drive</span>'s <span class=component>Mode</span> will define whether the object should be moving toward the <span class=component>Target Position</span> or <span class=component>Target Velocity</span> or both.  For example, when <span class=component>XDrive</span>'s mode is set to <span class=component>Position</span>, then the object will try to move to the value of <span class=component>Target Position->X</span>.

When a <span class=component>Drive</span> is using <span class=component>Position</span> in its <span class=component>Mode</span>, its <span class=component>Position Spring</span> value will define how the object is moved toward the <span class=component>Target Position</span>.  Similarly, when a <span class=component>Drive</span> is using <span class=component>Velocity</span> in its <span class=component>Mode</span>, its <span class=component>Maximum Force</span> value will define how the object is accelerated to the <span class=component>Target Velocity</span>.


###Rotation Acceleration

Rotation acceleration properties: <span class=component>Angular XDrive</span>, <span class=component>Angular YZDrive</span>, and <span class=component>Slerp Drive</span> function the same way as the translation <span class=component>Drives</span>.  There is one substantial difference.  <span class=component>Slerp Drive</span> behaves differently from the <span class=component>Angular Drive</span> functionality.  Therefore you can choose to use either both <span class=component>Angular Drives</span> or <span class=component>Slerp Drive</span> by choosing one from the <span class=component>Rotation Drive Mode</span>.  You cannot use both at once.


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Anchor</span> |The point where the center of the joint is defined.  All physics-based simulation will use this point as the center in calculations |
|<span class=component>Axis</span> |The local axis that will define the object's natural rotation based on physics simulation |
|<span class=component>Secondary Axis</span> |Together, <span class=component>Axis</span> and <span class=component>Secondary Axis</span> define the local coordinate system of the joint. The third axis is set to be orthogonal to the other two. |
|<span class=component>XMotion</span> |Allow movement along the X axis to be Free, completely Locked, or Limited according to <span class=component>Linear Limit</span> |
|<span class=component>YMotion</span> |Allow movement along the Y axis to be Free, completely Locked, or Limited according to <span class=component>Linear Limit</span> |
|<span class=component>ZMotion</span> |Allow movement along the Z axis to be Free, completely Locked, or Limited according to <span class=component>Linear Limit</span> |
|<span class=component>Angular XMotion</span> |Allow rotation around the X axis to be Free, completely Locked, or Limited according to <span class=component>Low</span> and <span class=component>High Angular XLimit</span> |
|<span class=component>Angular YMotion</span> |Allow rotation around the Y axis to be Free, completely Locked, or Limited according to <span class=component>Angular YLimit</span> |
|<span class=component>Angular ZMotion</span> |Allow rotation around the Z axis to be Free, completely Locked, or Limited according to <span class=component>Angular ZLimit</span> |
|<span class=component>Linear Limit</span> |Boundary defining movement restriction, based on distance from the joint's origin |
|>>><span class=component>Limit</span> |The distance in units from the origin to the wall of the boundary |
|>>><span class=component>Bouncyness</span> |Amount of bounce-back force applied to the object when it reaches the <span class=component>Limit</span> |
|>>><span class=component>Spring</span> |Strength of force applied to move the object back to the <span class=component>Limit</span>.  Any value other than 0 will implicitly soften the boundary |
|>>><span class=component>Damper</span> |Resistance strength against the <span class=component>Spring</span> |
|<span class=component>Low Angular XLimit</span> |Boundary defining lower rotation restriction, based on delta from original rotation |
|>>><span class=component>Limit</span> |The rotation in degrees that the object's rotation should not drop below |
|>>><span class=component>Bouncyness</span> |Amount of bounce-back torque applied to the object when its rotation reaches the <span class=component>Limit</span> |
|>>><span class=component>Spring</span> |Strength of force applied to move the object back to the <span class=component>Limit</span>.  Any value other than 0 will implicitly soften the boundary |
|>>><span class=component>Damper</span> |Resistance strength against the <span class=component>Spring</span> |
|<span class=component>High Angular XLimit</span> |Boundary defining upper rotation restriction, based on delta from original rotation. |
|>>><span class=component>Limit</span> |The rotation in degrees that the object's rotation should not exceed |
|>>><span class=component>Bouncyness</span> |Amount of bounce-back torque applied to the object when its rotation reaches the <span class=component>Limit</span> |
|>>><span class=component>Spring</span> |Strength of force applied to move the object back to the <span class=component>Limit</span>.  Any value other than 0 will implicitly soften the boundary |
|>>><span class=component>Damper</span> |Resistance strength against the <span class=component>Spring</span> |
|<span class=component>Angular YLimit</span> |Boundary defining rotation restriction, based on delta from original rotation |
|>>><span class=component>Limit</span> |The rotation in degrees that the object's rotation should not exceed |
|>>><span class=component>Bouncyness</span> |Amount of bounce-back torque applied to the object when its rotation reaches the <span class=component>Limit</span> |
|>>><span class=component>Spring</span> |Strength of torque applied to move the object back to the <span class=component>Limit</span>.  Any value other than 0 will implicitly soften the boundary |
|>>><span class=component>Damper</span> |Resistance strength against the <span class=component>Spring</span> |
|<span class=component>Angular ZLimit</span> |Boundary defining rotation restriction, based on delta from original rotation |
|>>><span class=component>Limit</span> |The rotation in degrees that the object's rotation should not exceed |
|>>><span class=component>Bouncyness</span> |Amount of bounce-back torque applied to the object when its rotation reaches the <span class=component>Limit</span> |
|>>><span class=component>Spring</span> |Strength of force applied to move the object back to the <span class=component>Limit</span>.  Any value other than 0 will implicitly soften the boundary |
|>>><span class=component>Damper</span> |Resistance strength against the <span class=component>Spring</span> |
|<span class=component>Target Position</span> |The desired position that the joint should move into |
|<span class=component>Target Velocity</span> |The desired velocity that the joint should move along |
|<span class=component>XDrive</span> |Definition of how the joint's movement will behave along its local X axis |
|>>><span class=component>Mode</span> |Set the following properties to be dependent on <span class=component>Target Position</span>, <span class=component>Target Velocity</span>, or both |
|>>><span class=component>Position Spring</span> |Strength of a rubber-band pull toward the defined direction. Only used if <span class=component>Mode</span> includes <span class=component>Position</span> |
|>>><span class=component>Position Damper</span> |Resistance strength against the <span class=component>Position Spring</span>. Only used if <span class=component>Mode</span> includes <span class=component>Position</span> |
|>>><span class=component>Maximum Force</span> |Amount of strength applied to push the object toward the defined direction. Only used if <span class=component>Mode</span> includes <span class=component>Velocity</span> |
|<span class=component>YDrive</span> |Definition of how the joint's movement will behave along its local Y axis |
|>>><span class=component>Mode</span> |Set the following properties to be dependent on <span class=component>Target Position</span>, <span class=component>Target Velocity</span>, or both |
|>>><span class=component>Position Spring</span> |Strength of a rubber-band pull toward the defined direction. Only used if <span class=component>Mode</span> includes <span class=component>Position</span>. |
|>>><span class=component>Position Damper</span> |Resistance strength against the <span class=component>Position Spring</span>. Only used if <span class=component>Mode</span> includes <span class=component>Position</span>. |
|>>><span class=component>Maximum Force</span> |Amount of strength applied to push the object toward the defined direction. Only used if <span class=component>Mode</span> includes <span class=component>Velocity</span>. |
|<span class=component>ZDrive</span> |Definition of how the joint's movement will behave along its local Z axis |
|>>><span class=component>Mode</span> |Set the following properties to be dependent on <span class=component>Target Position</span>, <span class=component>Target Velocity</span>, or both. |
|>>><span class=component>Position Spring</span> |Strength of a rubber-band pull toward the defined direction. Only used if <span class=component>Mode</span> includes <span class=component>Position</span> |
|>>><span class=component>Position Damper</span> |Resistance strength against the <span class=component>Position Spring</span>. Only used if <span class=component>Mode</span> includes <span class=component>Position</span> |
|>>><span class=component>Maximum Force</span> |Amount of strength applied to push the object toward the defined direction. Only used if <span class=component>Mode</span> includes <span class=component>Velocity</span> |
|<span class=component>Target Rotation</span> |This is a Quaternion. It defines the desired rotation that the joint should rotate into |
|<span class=component>Target Angular Velocity</span> |This is a Vector3. It defines the desired angular velocity that the joint should rotate into |
|<span class=component>Rotation Drive Mode</span> |Control the object's rotation with either <span class=component>X & YZ</span> or <span class=component>Slerp Drive</span> by itself |
|<span class=component>Angular XDrive</span> |Definition of how the joint's rotation will behave around its local X axis. Only used if <span class=component>Rotation Drive Mode</span> is <span class=component>Swing & Twist</span> |
|>>><span class=component>Mode</span> |Set the following properties to be dependent on <span class=component>Target Rotation</span>, <span class=component>Target Angular Velocity</span>, or both |
|>>><span class=component>Position Spring</span> |Strength of a rubber-band pull toward the defined direction. Only used if <span class=component>Mode</span> includes <span class=component>Position</span> |
|>>><span class=component>Position Damper</span> |Resistance strength against the <span class=component>Position Spring</span>. Only used if <span class=component>Mode</span> includes <span class=component>Position</span> |
|>>><span class=component>Maximum Force</span> |Amount of strength applied to push the object toward the defined direction. Only used if <span class=component>Mode</span> includes <span class=component>Velocity</span>. |
|<span class=component>Angular YZDrive</span> |Definition of how the joint's rotation will behave around its local Y and Z axes. Only used if <span class=component>Rotation Drive Mode</span> is <span class=component>Swing & Twist</span> |
|>>><span class=component>Mode</span> |Set the following properties to be dependent on <span class=component>Target Rotation</span>, <span class=component>Target Angular Velocity</span>, or both |
|>>><span class=component>Position Spring</span> |Strength of a rubber-band pull toward the defined direction. Only used if <span class=component>Mode</span> includes <span class=component>Position</span> |
|>>><span class=component>Position Damper</span> |Resistance strength against the <span class=component>Position Spring</span>. Only used if <span class=component>Mode</span> includes <span class=component>Position</span> |
|>>><span class=component>Maximum Force</span> |Amount of strength applied to push the object toward the defined direction. Only used if <span class=component>Mode</span> includes <span class=component>Velocity</span> |
|<span class=component>Slerp Drive</span> |Definition of how the joint's rotation will behave around all local axes. Only used if <span class=component>Rotation Drive Mode</span> is <span class=component>Slerp Only</span> |
|>>><span class=component>Mode</span> |Set the following properties to be dependent on <span class=component>Target Rotation</span>, <span class=component>Target Angular Velocity</span>, or both |
|>>><span class=component>Position Spring</span> |Strength of a rubber-band pull toward the defined direction. Only used if <span class=component>Mode</span> includes <span class=component>Position</span> |
|>>><span class=component>Position Damper</span> |Resistance strength against the <span class=component>Position Spring</span>. Only used if <span class=component>Mode</span> includes <span class=component>Position</span> |
|>>><span class=component>Maximum Force</span> |Amount of strength applied to push the object toward the defined direction. Only used if <span class=component>Mode</span> includes <span class=component>Velocity</span> |
|<span class=component>Projection Mode</span> |Properties to track to snap the object back to its constrained position when it drifts off too much|
|<span class=component>Projection Distance</span> |Distance from the <span class=component>Connected Body</span> that must be exceeded before the object snaps back to an acceptable position |
|<span class=component>Projection Angle</span> |Difference in angle from the <span class=component>Connected Body</span> that must be exceeded before the object snaps back to an acceptable position |
|<span class=component>Congfigure in World Space</span> |If enabled, all Target values will be calculated in World Space instead of the object's Local Space |
|<span class=component>Break Force</span> |Applied Force values above this number will cause the joint to be destroyed |
|<span class=component>Break Torque</span> |Applied Torque values above this number will cause the joint to be destroyed |
