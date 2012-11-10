Animation State Machines
========================


It is common for a character to have several different animations that correspond to different actions it can perform in the game. For example, it may breathe or sway slightly while idle, walk when commanded to and raise its arms in panic as it falls from a platform. Controlling when these animations are played back is potentially quite a complicated scripting task. Mecanim borrows a computer science concept known as a <span class=keyword>state machine</span> to simplify the control and sequencing of a character's animations.

State machine basics
--------------------


The basic idea is that a character is engaged in some particular kind of action at any given time. The actions available will depend on the type of gameplay but typical actions include things like idling, walking, running, jumping, etc. These actions are referred to as <span class=keyword>states</span>, in the sense that the character is in a "state" where it is walking, idling or whatever. In general, the character will have restrictions on the next state it can go to rather than being able to switch immediately from any state to any other. For example, a running jump can only be taken when the character is already running and not when it is at a standstill, so it should never switch straight from the idle state to the running jump state. The options for the next state that a character can enter from its current state are referred to as <span class=keyword>state transitions</span>. Taken together, the set of states, the set of transitions and the variable to remember the current state form a <span class=keyword>state machine</span>.

The states and transitions of a state machine can be represented using a graph diagram, where the nodes represent the states and the arcs (arrows between nodes) represent the transitions. You can think of the current state as being a marker or highlight that is placed on one of the nodes and can then only jump to another node along one of the arrows.


![](http://docwiki.hq.unity3d.com/uploads/Main/StateMachineDiagram.png)  

The importance of state machines for animation is that they can be designed and updated quite easily with relatively little coding. Each state has an animation sequence associated with it that will play whenever the machine is in that state. This enables an animator or designer to define the possible sequences of character actions and animations without being concerned about how the code will work. 

Mecanim state machines
----------------------

Mecanim's Animation State Machines provide a way to overview all of the animation clips related to a particular character and allow various events in the game (for example user input) to trigger different animations.  

Animation State Machines can be set up from the [Animator Controller Window](Animator.md), and they look something like this:


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimStateMachine.png)  

State Machines consist of <span class=keyword>States</span>, <span class=keyword>Transitions</span> and <span class=keyword>Events</span> and smaller Sub-State Machines can be used as components in larger machines.

(:tocportion:)

(back to [Mecanim introduction](MecanimAnimationSystem.md))
