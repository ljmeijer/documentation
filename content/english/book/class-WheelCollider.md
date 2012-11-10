Wheel Collider
==============


The <span class=keyword>Wheel Collider</span> is a special collider for grounded vehicles. It has built-in collision detection, wheel physics, and a slip-based tire friction model.  It can be used for objects other than wheels, but it is specifically designed for vehicles with wheels.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-WheelCollider.png)  
_The Wheel Collider Component. Car model courtesy of ATI Technologies Inc._


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Center</span> |Center of the wheel in object local space. |
|<span class=component>Radius</span> |Radius of the wheel. |
|<span class=component>Suspension Distance</span> |Maximum extension distance of wheel suspension, measured in local space. Suspension always extends downwards through the local Y-axis. |
|<span class=component>Suspension Spring</span> |The suspension attempts to reach a <span class=component>Target Position</span> by adding spring and damping forces. |
|>>><span class=component>Spring</span> |Spring force attempts to reach the <span class=component>Target Position</span>. A larger value makes the suspension reach the <span class=component>Target Position</span> faster. |
|>>><span class=component>Damper</span> |Dampens the suspension velocity. A larger value makes the <span class=component>Suspension Spring</span> move slower. |
|>>><span class=component>Target Position</span> |The suspension's rest distance along Suspension Distance. 0 maps to fully extended suspension, and 1 maps to fully compressed suspension. Default value is zero, which matches the behavior of a regular car's suspension. |
|<span class=component>Mass</span> |The Mass of the wheel. |
|<span class=component>Forward/Sideways Friction</span> |Properties of tire friction when the wheel is rolling forward and sideways. See [Wheel Friction Curves](#Friction) section below. |


Details
-------


The wheel's collision detection is performed by casting a ray from <span class=component>Center</span> downwards through the local Y-axis. The wheel has a <span class=component>Radius</span> and can extend downwards according to the <span class=component>Suspension Distance</span>. The vehicle is controlled from scripting using different properties: <span class=component>motorTorque</span>, <span class=component>brakeTorque</span> and <span class=component>steerAngle</span>. See the [Wheel Collider scripting reference](ScriptRef:WheelCollider.html) for more information.

The Wheel Collider computes friction separately from the rest of physics engine, using a slip-based friction model. This allows for more realistic behaviour but also causes Wheel Colliders to ignore standard [Physic Material](class-PhysicMaterial.md) settings.


###Wheel collider setup

You do not turn or roll WheelCollider objects to control the car - the objects that have WheelCollider attached should always be fixed relative to the car itself. However, you might want to turn and roll the graphical wheel representations. The best way to do this is to setup separate objects for Wheel Colliders and visible wheels:


![](http://docwiki.hq.unity3d.com/uploads/Main/WheelsSetup.png)  
_Wheel Colliders are separate from visible Wheel Models_


###Collision geometry

Because cars can achieve large velocities, getting race track collision geometry right is very important. Specifically, the [collision mesh](class-MeshCollider.md) should not have small bumps or dents that make up the visible models (e.g. fence poles). Usually a collision mesh for the race track is made separately from the visible mesh, making the collision mesh as smooth as possible. It also should not have thin objects - if you have a thin track border, make it wider in a collision mesh (or completely remove the other side if the car can never go there).


![](http://docwiki.hq.unity3d.com/uploads/Main/WheelGeometries.png)  
_Visible geometry (left) is much more complex than collision geometry (right)_


[Wheel Friction Curves](#Friction)
###Wheel Friction Curves

Tire friction can be described by the _Wheel Friction Curve_ shown below. There are separate curves for the wheel's forward (rolling) direction and sideways direction. In both directions it is first determined how much the tire is slipping (based on the speed difference between the tire's rubber and the road). Then this slip value is used to find out tire force exerted on the contact point.

The curve takes a measure of tire slip as an input and gives a force as output. The curve is approximated by a two-piece spline. The first section goes from _(0 , 0)_ to _(<span class=component>ExtremumSlip</span> , <span class=component>ExtremumValue</span>)_, at which point the curve's tangent is zero. The second section goes from _(<span class=component>ExtremumSlip</span> , <span class=component>ExtremumValue</span>)_ to _(<span class=component>AsymptoteSlip</span> , <span class=component>AsymptoteValue</span>)_, where curve's tangent is again zero:


![](http://docwiki.hq.unity3d.com/uploads/Main/WheelFrictionCurve.png)  
_Typical shape of a wheel friction curve_

The property of real tires is that for low slip they can exert high forces, since the rubber compensates for the slip by stretching. Later when the slip gets really high, the forces are reduced as the tire starts to slide or spin. Thus,  tire friction curves have a shape like in the image above.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Extremum Slip/Value</span> |Curve's extremum point. |
|<span class=component>Asymptote Slip/Value</span> |Curve's asymptote point. |
|<span class=component>Stiffness</span> |Multiplier for the <span class=component>Extremum Value</span> and <span class=component>Asymptote Value</span> (default is 1). Changes the stiffness of the friction. Setting this to zero will completely disable all friction from the wheel. Usually you modify stiffness at runtime to simulate various ground materials from scripting. |


Hints
-----

* You might want to decrease physics timestep length in [Time Manager](class-TimeManager.md) to get more stable car physics, especially if it's a racing car that can achieve high velocities.
* To keep a car from flipping over too easily you can lower its [Rigidbody](class-Rigidbody.md) center of mass a bit from script, and apply "down pressure" force that depends on car velocity.
