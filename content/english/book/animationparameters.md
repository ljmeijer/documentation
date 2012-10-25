Animation Parameters
====================


Animation Parameters expose the operation of the state machine to game logic. Events are triggered based on event parameters, activated from game logic. Typically you would work with events in 3 places:

1. Setting up parameters in the <span class=inspector>Parameter Widget</span> in the bottom-left corner of the <span class=inspector>Animator Controller Window</span>
1. Setting up conditions for transitions in the <span class=inspector>Transition Inspector</span>, based on those parameters
1. Controlling the parameters from script.

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimEvents.png)  

Event parameters can be of 4 basic types: _Vector_, _Float_, _Int_, and _Bool_, and they can be controlled from script via the functions [SetVector](ScriptRef:Animator.SetVector.html), [SetFloat](ScriptRef:Animator.SetFloat.html), [SetInt](ScriptRef:Animator.SetInt.html), and [SetBool](ScriptRef:SetBool.html) respectively.

Note that the values next to the parameters serve as Check default values for those parameters at startup, unless they're overriden by (or blended with) values from [animation curves](AnimatorCurves)

Thus, a complete animated character in the scene will have both an <span class=component>Animator Component</span> and a script that controls the parameters in the Animator. 

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimAnimatorAndScript.png)  

Here's an example of a script that modifies event parameters based on user input

    
    public class AvatarCtrl : MonoBehaviour {
    	
    	protected Animator animator;
    	
    	public float DirectionDampTime = .25f;
    				
    	void Start () 
    	{
    		animator = GetComponent<Animator>();
    	}
        
    	void Update () 
    	{
    		if(animator)
    		{
                            //get the current state
    			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    			
                            //if we're in "Run" mode, respond to input for jump, and set the Jump parameter accordingly. 
            	        if(stateInfo.name == "Base Layer.RunBT")
    			{
    				if(Input.GetButton("Fire1")) 
                                        animator.SetBool("Jump", true );
    			}
    			else
    			{
                	                animator.SetBool("Jump", false);				
    			}
    		
             		float h = Input.GetAxis("Horizontal");
                    	float v = Input.GetAxis("Vertical");
    			
                            //set event parameters based on user input
    			animator.SetFloat("Speed", h*h+v*v);
                            animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
    		}		
    	}   		  
    }
    

(back to [Animation State Machines](Animation State Machines))
