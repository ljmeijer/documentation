Physic Material
===============


The <span class=keyword>Physic Material</span> is used to adjust friction and bouncing effects of colliding objects.

To create a Physic Material select <span class=menu>Assets->Create->Physic Material</span> from the menu bar.  Then drag the Physic Material from the Project View onto a <span class=keyword>Collider</span> in the scene.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-PhysicMaterial.png)  
_The Physic Material <span class=keyword>Inspector</span>_


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Dynamic Friction</span> |The friction used when already moving. Usually a value from 0 to 1. A value of zero feels like ice, a value of 1 will make it come to rest very quickly unless a lot of force or gravity pushes the object. |
|<span class=component>Static Friction</span> |The friction used when an object is laying still on a surface. Usually a value from 0 to 1. A value of zero feels like ice, a value of 1 will make it very hard to get the object moving. |
|<span class=component>Bouncyness</span> |How bouncy is the surface? A value of 0 will not bounce. A value of 1 will bounce without any loss of energy. |
|<span class=component>Friction Combine Mode</span> |How the friction of two colliding objects is combined. |
|>>><span class=component>Average</span> |The two friction values are averaged. |
|>>><span class=component>Min</span> |The smallest of the two values is used. |
|>>><span class=component>Max</span> |The largest of the two values is used. |
|>>><span class=component>Multiply</span> |The friction values are multiplied with each other. |
|<span class=component>Bounce Combine</span> |How the bouncyness of two colliding objects is combined. It has the same modes as Friction Combine Mode |
|<span class=component>Friction Direction 2</span> |The direction of anisotropy. Anisotropic friction is enabled if this direction is not zero. Dynamic Friction 2 and Static Friction 2 will be applied along Friction Direction 2. |
|<span class=component>Dynamic Friction 2</span> |If anisotropic friction is enabled, DynamicFriction2 will be applied along Friction Direction 2. |
|<span class=component>Static Friction 2</span> |If anisotropic friction is enabled, StaticFriction2 will be applied along Friction Direction 2. |


Details
-------


Friction is the quantity which prevents surfaces from sliding off each other. This value is critical when trying to stack objects. Friction comes in two forms, dynamic and static. <span class=component>Static friction</span> is used when the object is lying still. It will prevent the object from starting to move. If a large enough force is applied to the object it will start moving. At this point <span class=component>Dynamic Friction</span> will come into play. <span class=component>Dynamic Friction</span> will now attempt to slow down the object while in contact with another.

Hints
-----

* Don't try to use a standard physic material for the main character. Make a customized one and get it perfect.
