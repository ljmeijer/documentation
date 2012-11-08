Solo and Mute functionality
---------------------------


In complex state machines, it is useful to preview the operation of some parts of the machine separately. For this, you can use the Mute / Solo functionality. Muting means a transition will be disabled. Soloed transtions are enabled and with respect to other transitions originating from the same state. You can set up mute and solo states either from the <span class=inspector>Transition Inspector</span>, or the <span class=inspector>State Inspector</span> (recommended), where you'll have an overview of all the transitions from that state. 


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimSoloMuteInspector.png)  

Soloed transitions will be shown in green, while muted transitions in red, like this:


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimSoloMuteGraph.png)  

In the example above, if you are in `State 0`, only transitions to `State A` and `State B` will be available.

* The basic rule of thumb is that if one Solo is ticked, the rest of the transitions from that state will be muted.
* If both Solo and Mute are ticked, then Mute takes precedence.

Known issues:
* The controller graph currently doesn't always reflect the internal mute states of the engine.

(back to [State Machines introduction](AnimationStateMachines.md))

(back to [Mecanim introduction](MecanimAnimationSystem.md))
