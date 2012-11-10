The Amount of One Vector's Magnitude that Lies in Another Vector's Direction
============================================================================


A car's speedometer typically works by measuring the rotational speed of one of the unpowered wheels. The car may not be moving directly forward (it may be skidding sideways, for example) in which case part of the motion will not be in the direction the speedometer can measure. The magnitude of an object's rigidbody.velocity vector will give the speed in its direction of overall motion but to isolate the speed in the forward direction, you should use the dot product:-

````
var fwdSpeed = Vector3.Dot(rigidbody.velocity, transform.forward);
````

Naturally, the direction can be anything you like but the direction vector must always be normalized for this calculation. Not only is the result more correct than the magnitude of the velocity, it also avoids the slow square root operation involved in finding the magnitude.
