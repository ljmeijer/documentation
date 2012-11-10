Target Matching
===============


Often in games, a situation arises where a character must move in such a way that a hand or foot lands at a certain place at a certain time. For example, the character may need to jump across stepping stones or jump and grab an overhead beam.

You can use the [Animator.MatchTarget function](ScriptRef:Animator.MatchTarget) to handle this kind of situation. Say, for example, you want to arrange an situation where the character jumps onto a platform and you already have an animation clip for it called _Jump Up_. To do this, follow the steps below.

* Find the place in the animation clip at which the character is beginning to get off the ground, note in this case it is 11.0% or 0.11 into the animation clip in normalized time.

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimMatchTargetStart.png)  

* Find the place in the animation clip at which the character is about to land on his feet, note in this case the value is 22.3% or 0.223.

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimMatchTargetEnd.png)  

* Create a script (`TargetCtrl.cs`) that makes a call to [MatchTarget](ScriptRef:Animator.MatchTarget), like this:

````
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
				animator.MatchTarget(jumpTarget.position, jumpTarget.rotation, AvatarTarget.LeftFoot, new MatchTargetWeightMask(Vector3.one, 1f), 0.11f, 0.223f);
		}		
	}
}

````

Attach that script onto the Mecanim model. 

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimMatchTargetInspector.png)  

The script will move the character so that it jumps from its current position and lands with its left foot at the target. Bear in mind that the result of using MatchTarget will generally only make sense if it is called at the right point in gameplay.

(back to [Mecanim introduction](MecanimAnimationSystem.md))
