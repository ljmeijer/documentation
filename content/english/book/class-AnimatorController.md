Animator Controller
-------------------


You can view and set up character behavior from the <span class=inspector>Animator Controller</span> view (Menu: <span class=menu>Window > Animator Controller</span>).

An <span class=component>Animator Controller</span> can be created from the <span class=inspector>Project View</span> (Menu: <span class=menu>Create > Animator Controller</span>).
This creates a `.controller` asset on disk, which looks like this in the <span class=inspector>Project Browser</span>


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimAnimatorControllerIcon.png)  
Animator Controller asset on disk

After the state machine setup has been made, you can drop the controller onto the Animator component of any character with an Avatar in the <span class=inspector>Hierarchy View</span>. 


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimAnimatorControllerWindow.png)  
>The Animator Controller Window

The <span class=inspector>Animator Controller Window</span> will contain 
* The <span class=inspector>Animation Layer Widget</span> (top-left corner, see [Animation Layers](AnimationLayers.md))
* The <span class=inspector>Event Parameters Widget</span> (bottom-left, see [Animation Parameters](AnimationParameters.md))
* The visualization of the [State Machine itself](AnimationStateMachines.md).

Note that the <span class=inspector>Animator Controller Window</span> will always display the state machine from the most recently selected `.controller` asset, regardless of what scene is currently loaded.
