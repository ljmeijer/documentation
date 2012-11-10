Character Controller
====================


The <span class=keyword>Character Controller</span> is mainly used for third-person or first-person player control that does not make use of <span class=keyword>Rigidbody</span> physics.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-CharacterController.png)  
_The Character Controller_

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Height</span> |The Character's <span class=keyword>Capsule Collider</span> height.  Changing this will scale the collider along the Y axis in both positive and negative directions. |
|<span class=component>Radius</span> |Length of the Capsule Collider's radius.  This is essentially the width of the collider. |
|<span class=component>Slope Limit</span> |Limits the collider to only climb slopes that are equal to or less than the indicated value. |
|<span class=component>Step Offset</span> |The character will step up a stair only if it is closer to the ground than the indicated value. |
|<span class=component>Min Move Distance</span> |If the character tries to move below the indicated value, it will not move at all. This can be used to reduce jitter. In most situations this value should be left at 0. |
|<span class=component>Skin width</span> |Two colliders can penetrate each other as deep as their Skin Width. Larger Skin Widths reduce jitter. Low Skin Width can cause the character to get stuck. A good setting is to make this value 10% of the Radius. |
|<span class=component>Center</span> |This will offset the Capsule Collider in world space, and won't affect how the Character pivots. |


Details
-------


The traditional Doom-style first person controls are not physically realistic. The character runs 90 miles per hour, comes to a halt immediately and turns on a dime. Because it is so unrealistic, use of Rigidbodies and physics to create this behavior is impractical and will feel wrong. The solution is the specialized Character Controller. It is simply a capsule shaped <span class=keyword>Collider</span> which can be told to move in some direction from a script. The Controller will then carry out the movement but be constrained by collisions. It will slide along walls, walk up stairs (if they are lower than the <span class=component>Step Offset</span>) and walk on slopes within the <span class=component>Slope Limit</span>.

The Controller does not react to forces on its own and it does not automatically push Rigidbodies away.

If you want to push Rigidbodies or objects with the Character Controller, you can apply forces to any object that it collides with via the <span class=component>OnControllerColliderHit()</span> function through scripting.

On the other hand, if you want your player character to be affected by physics then you might be better off using a [Rigidbody](class-Rigidbody.md) instead of the Character Controller.


###Fine-tuning your character

You can modify the <span class=component>Height</span> and <span class=component>Radius</span> to fit your Character's mesh. It is recommended to always use around 2 meters for a human-like character. You can also modify the <span class=component>Center</span> of the capsule in case your pivot point is not at the exact center of the Character.

<span class=component>Step Offset</span> can affect this too, make sure that this value is between 0.1 and 0.4 for a 2 meter sized human.

<span class=component>Slope Limit</span> should not be too small. Often using a value of 90 degrees works best. The Character Controller will not be able to climb up walls due to the capsule shape.


###Don't get stuck

The <span class=component>Skin Width</span> is one of the most critical properties to get right when tuning your Character Controller.
If your character gets stuck it is most likely because your <span class=component>Skin Width</span> is too small. The <span class=component>Skin Width</span> will let objects slightly penetrate the Controller but it removes jitter and prevents it from getting stuck.

It's good practice to keep your <span class=component>Skin Width</span> at least greater than 0.01 and more than 10% of the <span class=component>Radius</span>.

We recommend keeping <span class=component>Min Move Distance</span> at 0.

See the Character Controller script reference [here](ScriptRef:CharacterController.html)

You can download an example project showing pre-setup animated and moving character controllers from the [Resources](http://www.unity3d.com/support/resources.md) area on our website.

Hints
-----

* Try adjusting your <span class=component>Skin Width</span> if you find your character getting stuck frequently.
* The Character Controller can affect objects using physics if you write your own scripts.
* The Character Controller can not be affected by objects through physics.
* Note that changing Character Controller properties in the inspector will recreate the controller in the scene, so any existing Trigger contacts will get lost, and you will not get any OnTriggerEntered messages until the controller is moved again.

