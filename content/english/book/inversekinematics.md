Inverse Kinematics
------------------


Inverse Kinematics (IK) is the ability to control the character's body parts based on various objects in the world. You may want your character to look at an object, grab it, kick it, step on it, or do a combination of actions with different body parts. The object the character interacts with may be something in the environment (a ledge, a wall, or a treasure chest), or something attached to him (a gun, or a set of keys). The IK makes sure that all of the body parts align properly in order for the character to interact with the object. For example, if we want the character to grab an object with his hand, not only does the hand need to grab the object, the joint angles of the shoulder and elbow need to be adjusted to get the hand to the right place in a natural way. 

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimIKGrabbing.png)  

IK in Mecanim is possible for any characer with a valid Avatar. 

To set up IK for a character, you typically have objects around the scene that a character interacts with, and then set up the IK thru script, in particular, Animator functions like
[SetIKPositionWeight](ScriptRef:Animator.SetIKPositionWeight.html),
[SetIKRotationWeight](ScriptRef:Animator.SetIKRotationWeight.html),
[SetIKPosition](ScriptRef:Animator.SetIKPosition.html),
[SetIKRotation](ScriptRef:Animator.SetIKRotation.html),
[SetLookAtPosition](ScriptRef:Animator.SetIKLookAtPosition.html),
[bodyPosition](ScriptRef:Animator-bodyPosition.html),
[bodyRotation](ScriptRef:Animator-bodyRotation.html)

In the illustration above, we show a character grabbing a cylindrical object. How do we make this happen?

We start out with a character that has a valid Avatar, and attach to it a script that actually takes care of the IK, let's call it <span class=component>IKCtrl</span>:

    
    using UnityEngine;
    using System;
    using System.Collections;
      
    [RequireComponent(typeof(Animator))]  
    
    public class IKCtrl : MonoBehaviour {
    	
    	protected Animator animator;
    	
    	public bool ikActive = false;
    	public Transform rightHandObj = null;
    	
    	void Start () 
    	{
    		animator = GetComponent<Animator>();
    	}
        
            //a callback for calculating IK
    	void OnAvatarIK()
    	{
    	      if(animator) {
    
                            //if the IK is active, set the position and rotation directly to the goal. 
    			if(ikActive) {
    
                                    //weight = 1.0 for the right hand means position and rotation will be at the IK goal (the place the character wants to grab)
    				animator.SetIKPositionWeight(AvatarIKGoal.RightHand,1.0f);
    				animator.SetIKRotationWeight(AvatarIKGoal.RightHand,1.0f);
    							
    			        //set the position and the rotation of the right hand where the external object is
    				if(rightHandObj != null) {
    					animator.SetIKPosition(AvatarIKGoal.RightHand,rightHandObj.position);
    					animator.SetIKRotation(AvatarIKGoal.RightHand,rightHandObj.rotation);
    				}					
    				
    			}
    
                            //if the IK is not active, set the position and rotation of the hand back to the original position
    			else {			
    				animator.SetIKPositionWeight(AvatarIKGoal.RightHand,0);
    				animator.SetIKRotationWeight(AvatarIKGoal.RightHand,0);				
    			}
    		}
    	}	  
    }

As we do not intend for the character to grab the entire object with his hand, we position a sphere where the hand should be on the cylinder, and rotate it accordingly. 

This sphere should then be placed as the "Right Hand Obj" property of the IKCtrl script
![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimIKSetupInspector.png)  

Observe the character grabbing and ungrabbing the object as you click the <span class=component>IKActive</span> checkbox

(back to [Mecanim introduction](MecanimAnimationSystem))
