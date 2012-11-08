Blend Trees
===========


Blend Trees are used for continuous blending between similar animations based on float [event parameters](AnimationParameters.md). A typical example of this is blending between _walk_ and _run_ animations based on the _speed_ parameter. Mecanim can ensure that the transition between the walk and the run is smooth (it is important that the animation clips are _aligned_: e.g. start with the left foot on the floor at 0.0, and have the right foot on the floor at 0.5 for both. Another typical example is a transition between RunLeft, Run and RunRight animations based on the _direction_ parameter value between 0.0 (left) and 1.0 (right). 

To start working with a new blend tree, you need to:
1. Right-click on empty space on the <span class=inspector>Animator Controller Window</span>
1. Select <span class=menu>From New Blend Tree</span>.
1. Double-click on the Blend Tree to bring up the <span class=inspector>Blend Tree Inspector</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimBlendTreeInitial.png)  

In the inspector, the first thing you need is to select the [Animation Parameter](AnimationParameters.md) that will control this Blend Tree. 

Then you can add individual animations by clicking <span class=menu>+ -> Add Motion Field</span> to add an animation clip to the blend tree. When you're done, it should look something like this:


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimBlendTree.png)  

The red vertical bar indicates the current value of the event parameter. You can preview what happens to the animations by pressing <span class=menu>Play</span> in the <span class=inspector>Animation Preview Window</span>, dragging the bar left and right.

FAQ: When should I use <span class=keyword>State Machines</span> and when should I use <span class=keyword>Blend Trees</span>?
Answer: State machines are used for transitioning between unrelated animations based on discrete thresholds or boolean parameters. Blend trees are used for blending continuously between similar animations based on continuous (float) parameters.

(back to [Mecanim introduction](MecanimAnimationSystem.md))
