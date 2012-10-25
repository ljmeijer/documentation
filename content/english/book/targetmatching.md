Target Matching
===============


Often in games, a situation arises when a character needs to reach a certain place within a certain amount of time in a smooth way (a foot on a staircase, a hand on a ledge, etc.). 

For this we use the [MatchTarget API](ScriptRef:Animator.MatchTarget). Let's say we want to set up a situation for "jump on platform", and we already have an animation clip for it, called _Jump Up_. To do this, follow the steps below:

* Find the place in the animation clip at which the character is beginning to get off the ground, note in this case it is 0.448 into the animation clip
![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimMatchTargetStart.png)  

* Find the place in the animation clip at which the character is about to land on his feet, note in this case the value is 0.568.
![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimMatchTargetEnd.png)  

* Create a script (`TargetCtrl.cs`) that makes a call to [MatchTarget](ScriptRef:Animator.MatchTarget), like this:

    
        using UnityEngine;
        using System;
      
        [RequireComponent(typeof(Animator))]  
        public class TargetCtrl : MonoBehaviour {
    	
    	protected Animator animator;	
    
            //the platform object in the scene
            public Transform jumpTarget = null; 
            void Start () {
    	     animator = GetComponent<Animator>();
            }
    
            void Update () {
                    if(animator) {
    		       if(Input.GetButton("Fire1"))		       
                                animator.MatchTarget(jumpTarget.position, jumpTarget.position, AvatarTarget.LeftFoot, 0.448, 0.568, new Vector(1,1,1,1));
    		}		
            }
        }
    

Attach that script onto the Mecanim model. 
![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimMatchTargetInspector.png)  

This should get your character positioned properly on the platform.

(back to [Mecanim introduction](MecanimAnimationSystem))
