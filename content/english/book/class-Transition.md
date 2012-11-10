Animation Transitions
---------------------


<span class=keyword>Animation Transitions</span> define _what_ happens when you switch from one <span class=keyword>Animation State</span> to another. There can be only one transition active at any given time. 


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Atomic</span>      |Is this transition atomic? (cannot be interrupted)
|<span class=component>Conditions</span>    |Here we decide _when_ transitions get triggered. 

A condition consists of 2 parts: 
1. A conditional predicate (<span class=component>If</span>, <span class=component>If Not</span>, <span class=component>Less</span>, <span class=component>Greater</span>, <span class=component>Equals</span>, <span class=component>Not Equal</span>, and <span class=component>Exit Time</span>).
1. An event parameter (in conjunction with <span class=component>If</span> and <span class=component>If Not</span>, use bool parameters, <span class=component>Exit Time</span> just uses time).
1. A parameter value (if needed)

You can adjust the transition between the two animation clips by dragging the start and end values of the overlap. 

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimTransitionInspector.png)  

(back to [Animation State Machines](AnimationStateMachines.md))
