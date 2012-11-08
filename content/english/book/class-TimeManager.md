Time Manager
============



![](http://docwiki.hq.unity3d.com/uploads/Main/TimeSet.png)  
_The Time Manager_


Properties
----------




|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Fixed Timestep</span> |A framerate-independent interval that dictates when physics calculations and <span class=component>FixedUpdate()</span> events are performed. |
|<span class=component>Maximum Allowed Timestep</span> |A framerate-independent interval that caps the worst case scenario when frame-rate is low. Physics calculations and <span class=component>FixedUpdate()</span> events will not be performed for longer time than specified. |
|<span class=component>Time Scale</span> |The speed at which time progress. Change this value to simulate bullet-time effects. A value of 1 means real-time. A value of .5 means half speed; a value of 2 is double speed. |

Details
-------


###Fixed Timestep

Fixed time stepping is very important for stable physics simulation. Not all computers are made equal, and different hardware configurations will run Unity games with varying performance.  Therefore, physics must be calculated independently of the game's frame rate.  Physics calculations like collision detection and Rigidbody movement are performed in discrete fixed time steps that are not dependent on frame rate. This makes the simulation more consistent across different computers or when changes in the frame rate occur. For example, the frame rate can drop due to an appearance of many game onscreen, or because the user launched another application in the background.

Here's how the fixed time step is calculated.  Before every frame is drawn onscreen, Unity advances the fixed time by fixed delta time and performs physics calculations until it reaches the current time.  This directly correlates to the <span class=component>Fixed Timestep</span> property.  The smaller the value of <span class=component>Fixed Timestep</span>, the more frequently physics will be calculated.  The number of Fixed frames per second can be calculated by dividing 1 by <span class=component>Fixed Timestep</span>.  Therefore, 1 / 0.02 = 50 fixed frames per second and 1 / 0.05 = 20 fixed frames per second.

Simply put, a smaller fixed update value leads to more accurate physics simulation but is heavier on the CPU.

###Maximum Allowed Timestep
Fixed time stepping ensures stable physics simulation. However it can cause negative impact on performance if game is heavy on physics and is already running slow or occasionally dips to low frame rate. Longer the frame takes to process - more fixed update steps will have to be executed for the next frame. This results in performance degradation. To prevent such scenario Unity iOS introduced <span class=component>Maximum Allowed Timestep</span> which ensures that physics calculations will not run longer than specified threshold.

If frame takes longer to process than time specified in <span class=component>Maximum Allowed Timestep</span>, then physics will "pretend" that frame took only <span class=component>Maximum Allowed Timestep</span> seconds. In other words if frame rate drops below some threshold, then rigid bodies will slow down a bit allowing CPU to catch up.

<span class=component>Maximum Allowed Timestep</span> affects both physics calculation and <span class=component>FixedUpdate()</span> events.

<span class=component>Maximum Allowed Timestep</span> is specified in seconds as <span class=component>Fixed Timestep</span>. Therefore setting 0.1 will make physics and <span class=component>FixedUpdate()</span> events to slow down, if frame rate dips below 1 / 0.1 = 10 frames per second.

###Typical scenario
1. Let's assume <span class=component>Fixed Timestep</span> is 0.01, which means that physx, fixedUpdate and animations should be processed every 10 ms.
1. When your frame time is ~33 ms then fixed loop is executed 3 times per visual frame on average.
1. But frametime isn't fixed constant and depends on many factors including your scene state, OS background taks, etc.
1. Because of 3. reasons frametime sometimes can reach 40-50 ms, which means that fixed step loop will be executed 4-5 times.
1. When your fixed timestep tasks are pretty heavy then time spent on physx, fixedUpdates and animations extend your frametime by another 10 ms, which means one more additional iteration of all these fixed timestep tasks.
1. In some unlucky cases process described in 5. could extend to 10 and more times of processing fixed step loop.
1. That's why <span class=component>Maximum Allowed Timestep</span> was introduced, it is the method to limit how much times physx, fixedUpdates and animations can be processed during single visual frame. If you have <span class=component>Maximum Allowed Timestep</span> set to 100 ms and your <span class=component>Fixed Timestep</span> is 10 ms, then for fixed step tasks will be executed up to 10 times per visual frame. So sometimes small performance hitch could trigger big performance hitch because of increased fixed timestep iteration count. By decreasing <span class=component>Maximum Allowed Timestep</span> to 30 ms, you are limiting max fixed step iteration count to 3 and this means that your physx, fixedUpdate and animation won't blow your frametime up very much, but there is some negative effect of this limiting. Your animations and physics will slow down a bit when performance hitch occurs.


Hints
-----

* Give the player control over time by changing <span class=component>Time Scale</span> dynamically through scripting.
* If your game is physics heavy or spends significant amount of time in <span class=component>FixedUpdate()</span> events, then set <span class=component>Maximum Allowed Timestep</span> to 0.1. This will prevent physics from driving your game below 10 frames per second.

