Manually Scripting Root Motion
==============================


Sometimes your animation comes as "in-place", which means if you put it in a scene, it will not move the character that it's on. In other words, the animation does not contain "root motion". For this, we can modify root motion from script. To put everything together follow the steps below (note there are many variations of achieving the same result, this is just one recipe). 

* Open the inspector for the FBX file that contains the in-place animation, and go to the <span class=inspector>Animation</span> tab
* Make sure the <span class=menu>Muscle Definition</span> is set to the Avatar you intend to control (let's say this avatar is called _Dude_, and he has already been added to the <span class=inspector>Hierarchy View</span>).
* Select the animation clip from the available clips
* Make sure <span class=component>Loop Pose</span> is properly aligned (the light next to it is green), and that the checkbox for <span class=component>Loop Pose</span> is clicked

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimRootMotionChristmasTree.png)  

* Preview the animation in the animation viewer to make sure the beginning and the end of the animation align smoothly, and that the character is moving "in-place"\
* On the animation clip create a curve that will control the speed of the character (you can add a curve from the <span class=inspector>Animation Import inspector</span> <span class=menu>Curves-> +</span>)
* Name that curve something meaningful, like "Runspeed"

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimRootMotionCurve.png)  

* Create a new <span class=component>Animator Controller</span>, (let's call it <span class=component>RootMotionController</span>)
* Drop the desired animation clip into it, this should create a state with the name of the animation (say <span class=component>Run</span>)
* Add a parameter to the Controller with the same name as the curve (in this case, "Runspeed")

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimRootMotionController.png)  

* Select the character <span class=component>Dude</span> in the <span class=inspector>Hierarchy</span>, whose inspector should already have an <span class=component>Animator</span> component.
* Drag <span class=component>RootMotionController</span> onto the <span class=component>Controller</span> property of the Animator
* If you press play now, you should see the "Dude" running in place

* Finally, to control the motion, we will need to create a script (RootMotionScript.cs), that implements the OnAvatarMove callback.
    
    using UnityEngine;
    using System.Collections;
    
    [RequireComponent(typeof(Animator))]
    	
    public class RootMotionScript : MonoBehaviour {
    			
    	void OnAvatarMove()
    	{
                Animator animator = GetComponent<Animator>(); 
                                  
                if (animator)
                {
    	       Vector3 newPosition = transform.position;
                   newPosition.z += animator.GetFloat("Runspeed") * Time.deltaTime;                                 
    	       transform.position = newPosition;
                }
    	}
    }
    
* Attach RootMotionScript.cs to "Dude"
* Note that the Animator component detects there is a script with `OnAvatarMove` and <span class=component>Apply Root Motion</span> property shows up as _Handled by Script_
![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimRootMotionDude.png)  
* Now you should see that the character is moving at the speed specified.

(back to [Mecanim introduction](MecanimAnimationSystem))
