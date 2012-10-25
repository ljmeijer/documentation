Working with Animation Curves in Mecanim.
=========================================


Animation curves can be attached to animation clips in the <span class=menu>Animation Import Settings -> Animations tab</span>

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimCurves.png)  
->The curves on animation clips in Mecanim.

The curve's X-axis represents _normalized time_ and always ranges between 0.0 and 1.0 (corresponding to the beginning and the end of the animation clip respectively). 

You can pull up the regular curve editor by double-clicking it. In this curve editor you will be able to add <span class=keyword>keys</span> to the curve, which are convenient for marking important parts of the animation (for a _walk_ animation, this may be: left foot on the ground, both feet on the ground, right foot on the ground, etc.) . Once the keys are set up, you can also set curve values at various key frames by pressing the <span class=menu>Previous/Next Key Frame</span> buttons. This will move the vertical red line to indicate at which value of _normalized time_ we are, and the value we enter in the  text box will correspond to the value of the curve at that time.  

Animation Curves and Animator Controller parameters
---------------------------------------------------

If the name of the curve is the same as the name of one of the [parameters](AnimationParameters) in the [Animator Controller](Animator), the curve will control that parameter, and any call to  [GetFloat](ScriptRef:Animator.GetFloat.html) (for example) will reflect the values from the curve.

Note that at any given point in time, we might have multiple animation clips attempting to set the same parameter from the same controller. In that case, the curve values from the multiple animation clips are blended. 

In addition if an animation has no curve for that particular value, the blending will be done with the default value for that parameter.

(back to [Mecanim introduction](MecanimAnimationSystem))
