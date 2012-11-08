Animator Component
==================


Any GameObject that has an avatar will also have an <span class=component>Animator</span> component, which is the link between the character and its behavior. 


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimAnimatorComponent.png)  

The <span class=component>Animator</span> component references an <span class=component>Animator Controller</span> which is used for setting up behavior on the character. This includes setup for [State Machines](AnimationStateMachines.md), [Blend Trees](AnimationBlendTrees.md), and events to be controlled from script.

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Controller</span>  |The animator controller attached to this character|
|<span class=component>Avatar</span> |The [Avatar](class-Avatar.md) for this character. 
|<span class=component>Apply Root Motion</span> |Should we control the character's position from the animation itself or from script. 
|<span class=component>Animate Physics</span> |Should the animation interact with physics? |
|<span class=component>Culling Mode</span> |Culling mode for animations|
|>>><span class=component>Always animate</span>|Always animate, don't do culling|
|>>><span class=component>Based on Renderers</span>|When the renderers are invisible, only root motion is animated. All other body parts will remain static while the character is invisible. |

