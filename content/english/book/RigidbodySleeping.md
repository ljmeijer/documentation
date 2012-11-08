Rigidbody Sleeping
==================


When Rigidbodies fall to rest - a box landing on the floor - they will start sleeping. Sleeping is an optimization which allows the Physics Engine to stop processing those rigidbodies. This way you can have huge amounts of rigidbodies in your scene as long as you make sure that they normally don't move.

Rigidbody sleeping happens completely automatically. Whenever a rigidbody is slower than the sleepAngularVelocity and sleepVelocity it will start falling asleep. After a few frames of resting it will then be set to sleep. When the body is sleeping, no collision detection or simulation will be performed anymore. This saves a lot of CPU cycles.

Rigidbodies automatically wake up when:
* another rigidbody collides with the sleeping rigidbody
* another rigidbody connected through a joint is moving.
* when modifying a property of the rigidbody
* when [adding forces](ScriptRef:Rigidbody.AddForce.html).

So if you want to make rigidbodies fall to rest, don't modify their properties or add forces when they are about to go into sleep mode.

There are two variables that you can tune to make sure your rigidbodies automatically fall to rest: [Rigidbody.sleepVelocity](ScriptRef:Rigidbody-sleepVelocity.html) and [Rigidbody.sleepAngularVelocity](ScriptRef:Rigidbody-sleepAngularVelocity.html). Those two variables are initialized to the sleepVelocity and sleepAngularVelocity variable defined in the [Physics Manager](class-PhysicsManager.md) (_Edit -> Project Settings -> Physics_).

Rigidbodies can also be forced to sleep using [rigidbody.Sleep](ScriptRef:Rigidbody.Sleep.html). This is useful to start rigidbodies in a rest state when loading a new level.


Kinematic rigidbodies wake up sleeping rigidbodies. Static Colliders do not.
If you have a sleeping rigidbody and you move a static collider (A collider without a Rigidbody attached) into the rigidbody or pull it from underneath the rigidbody, the sleeping rigidbody will __not__ awake.
If you move a Kinematic Rigidbody out from underneath normal Rigidbodies that are at rest on top of it, the sleeping Rigidbodies will "wake up" and be correctly calculated again in the physics update.  So if you have a lot of Static Colliders that you want to move around and have different objects fall on them correctly, use Kinematic Rigidbody Colliders.


Kinematic rigidbodies - they will not be calculated during the physics update since they are not going anywhere.  If you move a Kinematic Rigidbody out from underneath normal Rigidbodies that are at rest on top of it, the sleeping Rigidbodies will "wake up" and be correctly calculated again in the physics update.  So if you have a lot of Static Colliders that you want to move around and have different objects fall on them correctly, use Kinematic Rigidbody Colliders.
