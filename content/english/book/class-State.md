Animation States
----------------


<span class=keyword>Animation States</span> are the basic building blocks of an <span class=keyword>Animation State Machine</span>. Each state contains an individual animation sequence (or blend tree) which will play while the character is in that state. When an event in the game triggers a state transition, the character will be left in a new state whose animation sequence will then take over.

When you select a state in the <span class=inspector>Animator Controller</span>, you will see the properties for that state in the inspector:-


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimStateInspector.png)  


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Speed</span>      |The default speed of the animation|
|<span class=component>Motion</span>     |The animation clip assigned to this state|
|<span class=component>Foot IK</span>    |Should Foot IK be respected for this state|
|<span class=component>Transitions</span>|The list of transitions originating from this state|

The default state, displayed in brown, is the state that the machine will be in when it is first activated. You can change the default state, if necessary, by right-clicking on another state and selecting <span class=menu>Set As Default</span> from the context menu. The _solo_ and _mute_ checkboxes on each transition are used to control the behaviour of <span class=keyword>animation previews</span> - see [this page](AnimationSoloMute.md) for further details.

A new state can be added by right-clicking on an empty space in the <span class=inspector>Animator Controller Window</span> and selecting <span class=menu>Create State->Empty</span> from the context menu. Alternatively, you can drag an animation into the Animator Controller Window to create a state containing that animation. (Note that you can only drag Mecanim animations into the Controller - non-Mecanim animations will be rejected.) States can also contain [Blend Trees](Main.AnimationBlendTrees.md).

###Any State
<span class=keyword>Any State</span> is a special state which is always present. It exists for the situation where you want to go to a specific state regardless of which state you are currently in. This is a shorthand way of adding the same outward transition to all states in your machine. Note that the special meaning of <span class=keyword>Any State</span> implies that it cannot be the end point of a transition (ie, jumping to "any state" cannot be used as a way to pick a random state to enter next).


![](http://docwiki.hq.unity3d.com/uploads/Main/AnyState.png)  

(back to [Animation State Machines](AnimationStateMachines.md))
