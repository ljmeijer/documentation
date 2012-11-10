Physics Manager
===============


You can access the <span class=keyword>Physics Manager</span> by selecting <span class=menu>Edit->Project Settings->Physics</span> from the menu bar.


![](http://docwiki.hq.unity3d.com/uploads/Main/PhysicsSet4b7.png)  
_The Physics Manager_


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Gravity</span> |The amount of gravity applied to all <span class=keyword>Rigidbodies</span>. Usually gravity acts only on the Y-axis (negative is down). Gravity is meters/(seconds^2). |
|<span class=component>Default Material</span> |The default <span class=keyword>Physics Material</span> that will be used if none has been assigned to an individual <span class=keyword>Collider</span>. |
|<span class=component>Bounce Threshold</span> |Two colliding objects with a relative velocity below this value will not bounce. This value also reduces jitter so it is not recommended to set it to a very low value. |
|<span class=component>Sleep Velocity</span> |The default linear velocity, below which objects start going to sleep. |
|<span class=component>Sleep Angular Velocity</span> |The default angular velocity, below which objects start going to sleep. |
|<span class=component>Max Angular Velocity</span> |The default maximimum angular velocity permitted for any Rigidbodies. The angular velocity of Rigidbodies is clamped to stay within <span class=component>Max Angular Velocity</span> to avoid numerical instability with quickly rotating bodies. Because this may prevent intentional fast rotations on objects such as wheels, you can override this value for any Rigidbody by scripting <span class=component>Rigidbody.maxAngularVelocity</span>. |
|<span class=component>Min Penetration For Penalty</span> |How deep in meters are two objects allowed to penetrate before the collision solver pushes them apart. A higher value will make objects penetrate more but reduces jitter. |
|<span class=component>Solver Iteration Count</span> |Determines how accurately joints and contacts are resolved. Usually a value of 7 works very well for almost all situations. |
|<span class=component>Raycasts Hit Triggers</span> |If enabled, any Raycast that intersects with a Collider marked as a Trigger will return a hit.  If disabled, these intersections will not return a hit. |
|<span class=component>Layer Collision Matrix</span> |Defines how the [layer-based collision](LayerBasedCollision.md) detection system will behave.|

Details
-------

The Physics Manager is where you define the default behaviors of your world.  For an explanation of Rigidbody Sleeping, read this page about [sleeping](RigidbodySleeping.md).

Hints
-----

* If you are having trouble with connected bodies oscillating and behaving eratically, setting a higher <span class=component>Solver Iteration Count</span> may improve their stability, but will require more processing power.
