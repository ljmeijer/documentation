Execution Order of Event Functions
==================================

In Unity scripting, there are a number of event functions that get executed in a predetermined order as a script executes. This execution order is described below:

First Scene Load
----------------

These functions get called when a scene starts (once for each object in the scene). 
* __Awake:__ This function is always called before any Start functions and also just after a prefab is instantiated. (If a GameObject is in-active during start up Awake is not called until it is made active, or a function in any script attached to it is called.)
* __OnEnable:__ (only called if the Object is active): This function is called just after the object is enabled. This happens when a MonoBehaviour is instance is created, such as when a level is loaded or a GameObject with the script component is instantiated.

Before the first frame update
-----------------------------

* __Start:__ Start is called before the first frame update only if the script instance is enabled.

In between frames
-----------------

* __OnApplicationPause:__ This is called at the end of the frame where the pause is detected, effectively between the normal frame updates. One extra frame will be issued after <span class=component>OnApplicationPause</span> is called to allow the game to show graphics that indicate the paused state.

Update Order
------------

When you're keeping track of game logic and interactions, animations, camera positions, etc., there are a few different events you can use.  The common pattern is to perform most tasks inside the <span class=component>Update()</span> function, but there are also other functions you can use.

* __FixedUpdate:__ <span class=component>FixedUpdate()</span> is often called more frequently than <span class=component>Update()</span>.  It can be called multiple times per frame, if the frame rate is low and it may not be called between frames at all if the frame rate is high.  All physics calculations and updates occur immediately after <span class=component>FixedUpdate()</span>.  When applying movement calculations inside <span class=component>FixedUpdate()</span>, you do not need to multiply your values by <span class=component>Time.deltaTime</span>.  This is because <span class=component>FixedUpdate()</span> is called on a reliable timer, independent of the frame rate.

* __Update:__ <span class=component>Update()</span> is called once per frame.  It is the main workhorse function for frame updates.

* __LateUpdate:__ <span class=component>LateUpdate()</span> is called once per frame, after <span class=component>Update()</span> has finished.  Any calculations that are performed in <span class=component>Update()</span> will have completed when <span class=component>LateUpdate()</span> begins.  A common use for <span class=component>LateUpdate()</span> would be a following third-person camera.  If you make your character move and turn inside <span class=component>Update()</span>, you can perform all camera movement and rotation calculations in <span class=component>LateUpdate()</span>.  This will ensure that the character has moved completely before the camera tracks its position.


Rendering
---------

* __OnPreCull:__ Called before the camera culls the scene. Culling determines which objects are visible to the camera. OnPreCull is called just before culling takes place.
* __OnBecameVisible/OnBecameInvisible:__ Called when an object becomes visible/invisible to any camera.
* __OnWillRenderObject:__ Called __once__ for each camera if the object is visible.
* __OnPreRender:__ Called before the camera starts rendering the scene.
* __OnRenderObject:__ Called after all regular scene rendering is done. You can use GL class or Graphics.DrawMeshNow to draw custom geometry at this point.
* __OnPostRender:__ Called after a camera finishes rendering the scene.
* __OnRenderImage(Pro only):__ Called after scene rendering is complete to allow postprocessing of the screen image.
* __OnGUI:__ Called multiple times per frame in response to GUI events. The Layout and Repaint events are processed first, followed by a Layout and keyboard/mouse event for each input event.
* __OnDrawGizmos__ Used for drawing Gizmos in the scene view for visualisation purposes.

Coroutine
---------

Normal coroutine updates are run after the Update function returns. A coroutine is function that can suspend its execution (yield) until the given given YieldInstruction finishes.
Different uses of Coroutines:
* __yield;__ The coroutine will continue after all Update functions have been called on the next frame.
* __yield WaitForSeconds(2);__ Continue after a specified time delay, after all Update functions have been called for the frame
* __yield WaitForFixedUpdate();__ Continue after all FixedUpdate has been called on all scripts
* __yield WWW__ Continue after a WWW download has completed.
* __yield StartCoroutine(MyFunc);__ Chains the coroutine, and will wait for the MyFunc coroutine to complete first.

When the Object is Destroyed
----------------------------


* __OnDestroy:__ This function is called after all frame updates for the last frame of the object's existence (the object might be destroyed in response to Object.Destroy or at the closure of a scene).

When Quitting
-------------

These functions get called on all the active objects in your scene, :
* __OnApplicationQuit:__ This function is called on all game objects before the application is quit. In the editor it is called when the user stops playmode. In the web player it is called when the web view is closed.
* __OnDisable:__ This function is called when the behaviour becomes disabled or inactive.

###So in conclusion, this is the execution order for any given script:

* All Awake calls
* All Start Calls
* __while__ (stepping towards variable delta time)
    * All FixedUpdate functions
    * Physics simulation
    * OnEnter/Exit/Stay trigger functions
    * OnEnter/Exit/Stay collision functions
 
* Rigidbody interpolation applies transform.position and rotation
* OnMouseDown/OnMouseUp etc. events
* All Update functions
* Animations are advanced, blended and applied to transform
* All LateUpdate functions
* Rendering

Hints
-----

* Coroutines are executed after all Update functions.
