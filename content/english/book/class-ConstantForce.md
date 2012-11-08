Constant Force
==============


<span class=keyword>Constant Force</span> is a quick utility for adding constant forces to a <span class=keyword>Rigidbody</span>.  This works great for one shot objects like rockets, if you don't want it to start with a large velocity but instead accelerate.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-ConstantForce.png)  
_A rocket propelled forward by a Constant Force_


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Force</span> |The vector of a force to be applied in world space. |
|<span class=component>Relative Force</span> |The vector of a force to be applied in the object's local space. |
|<span class=component>Torque</span> |The vector of a torque, applied in world space. The object will begin spinning _around_ this vector. The longer the vector is, the faster the rotation. |
|<span class=component>Relative Torque</span> |The vector of a torque, applied in local space. The object will begin spinning _around_ this vector. The longer the vector is, the faster the rotation. |


###Details

To make a rocket that accelerates forward set the <span class=component>Relative Force</span> to be along the positive z-axis. Then use the Rigidbody's <span class=component>Drag</span> property to make it not exceed some maximum velocity (the higher the drag the lower the maximum velocity will be). In the Rigidbody, also make sure to turn off gravity so that the rocket will always stay on its path.

Hints
-----

* To make an object flow upwards, add a Constant Force with the <span class=component>Force</span> property having a positive Y value.
* To make an object fly forwards, add a Constant Force with the <span class=component>Relative Force</span> property having a positive Z value.
