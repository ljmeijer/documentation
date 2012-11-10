Sub-State Machines
==================


It is common for a character to have complex actions that consist of a number of stages. Rather than handle the entire action with a single state, it makes sense to identify the separate stages and use a separate state for each. For example, a character may have an action called "Trickshot" where it crouches to take a steady aim, shoots and then stands up again.


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimStateExcerpt.png)  
_The sequence of states in a "Trickshot" action_

Although this is useful for control purposes, the downside is that the state machine will become large and unwieldy as more of these complex actions are added. You can simplify things somewhat just by separating the groups of states visually with empty space in the editor. However, Mecanim goes a step further than this by allowing you to collapse a group of states into a single named item in the state machine diagram. These collapsed groups of states are called <span class=keyword>Sub-state machines</span>.

You can create a sub-state machine by right clicking on an empty space within the <span class=inspector>Animator Controller</span> window and selecting <span class=menu>Create Sub-State Machine</span> from the context menu. A sub-state machine is represented in the editor by an elongated hexagon to distinguish it from normal states.


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimSubStateMachine.png)  
_A sub-state machine_

When you double-click the hexagon, the editor is cleared to let you edit the sub-state machine as though it were a completely separate state machine in its own right. The bar at the top of the window shows a "breadcrumb trail" to show which sub-state machine is currently being edited (and note that you can create sub-state machines within other sub-state machines, and so on). Clicking an item in the trail will focus the editor on that particular sub-state machine.


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimStateMachineCrumbs.png)  
_The "breadcrumb trail"_

External transitions
--------------------

As noted above, a sub-state machine is just a way of visually collapsing a group of states in the editor, so when you make a transition to a sub-state machine, you have to choose which of its states you want to connect to.  


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimSelectSubState.png)  
_Choosing a target state within the "Trickshot" sub-state machine_

You will notice an extra state in the sub-state machine whose name begins with _Up_.


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimSubStateUp.png)  
_The "Up" state_

The _Up_ state represents the "outside world", the state machine that encloses the sub-state machine in the view. If you add a transition from a state in sub-state machine to the _Up_ state, you will be prompted to choose one of the states of the enclosing machine to connect to.


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimSubStateExternal.png)  
_Connecting to a state in the enclosing machine_

(back to [State Machines introduction](AnimationStateMachines.md))

(back to [Mecanim introduction](MecanimAnimationSystem.md))
