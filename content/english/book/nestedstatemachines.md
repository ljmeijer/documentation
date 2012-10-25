Nested State Machines
=====================


For convenience, it is possible to nest Animation State Machines within other Animation State Machines. You can create a Sub-state machine by rightclicking on an empty space within the <span class=inspector>Animator Controller</span> window and selecting <span class=menu>Create Sub-State Machine</span>. 

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimStateMachinePullDown.png)  

This forms a sub-state machine, to which you can navigate by double-clicking on the rhombic node:

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimSubStateMachine.png)  

Note, however, that you can only connect from states to other states. Thus when you create a transition from a state to a state machine, Unity will ask you to select a state from that machine. You can connect both up and down the hierarchy. 

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimSelectSubState.png)  

The <span class=inspector>State Inspector</span> and the <span class=inspector>Transition Inspector</span> will indicate which state machine each state comes from:
![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimTransitionToSubStateInspector.png)  
(back to [State Machines introduction](Animation State Machines))

(back to [Mecanim introduction](MecanimAnimationSystem))
