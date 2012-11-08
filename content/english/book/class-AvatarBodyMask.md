Avatar Body Mask
================


Specific body parts can be selectively enabled or disabled in an animation using a so-called <span class=keyword>Body Mask</span>. Body masks are used in the <span class=inspector>Animation</span> tab of the mesh import inspector and [Animation Layers](AnimationLayers.md). Body masks enable you to tailor an animation to fit the specific requirements of your character more closely. For example, you may have a standard walking animation that includes both arm and leg motion, but if a character is carrying a large object with both hands then you wouldn't want his arms to swing by his sides as he walks. However, you could still use the standard walking animation by switching off the arm movements in the body mask.

The body parts included are: Head, Left Arm, Right Arm, Left Hand, Right Hand, Left Leg, Right Leg and Root (which is denoted by the "shadow" under the feet). 
In the body mask, you can also toggle __inverse kinematics__ (IK) for hands and feet, which will determine whether or not IK curves will be included in animation blending. 


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimBodyMaskAssetNoArms.png)  
_Body mask in the Body Mask inspector (arms excluded)_

In the Animation tab of the mesh import inspector, you will see a list entitled _Clips_ that contains all the object's animation clips. When you select an item from this list, options for the clip will be shown, including the body mask editor.

You can also create Body Mask Assets (<span class=menu>Assets->Create->Avatar Body Mask</span>), which show up as .mask files on disk.

The BodyMask assets can be reused in [Animator Controllers](AnimationStateMachines.md), when specifying [Animation Layers](AnimationLayers.md)

A benefit of using body masks is that they tend to reduce memory overheads since body parts that are not active do not need their associated animation curves. Also, the unused curves need not be calculated during playback which will tend to reduce the CPU overhead of the animation.

(back to [Mecanim introduction](MecanimAnimationSystem.md))
