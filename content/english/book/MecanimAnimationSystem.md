Mecanim Animation System
========================


Unity has a rich and sophisticated animation system called <span class=keyword>Mecanim</span>. Mecanim provides:

* Easy workflow and setup of animations on humanoid characters.
* Animation retargeting - the ability to apply animations from one character model onto another.
* Simplified workflow for aligning animation clips.
* Convenient preview of animation clips, transitions and interactions between them. This allows animators to work more independently of programmers, prototype and preview their animations before gameplay code is hooked in.
* Management of complex interactions between animations with a visual programming tool.
* Animating different body parts with different logic.


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimShowcase.png)  
_Typical setup in the Visual Programming Tool and the <span class=inspector>Animation Preview window</span>_

Mecanim workflow
----------------


Workflow in Mecanim can be split into three major stages.

1. __Asset preparation and import__. This is done by artists or animators, with 3rd party tools, such as Max or Maya. This step is independent of Mecanim features.   
2. Character setup for Mecanim, which can be done in 2 ways:
   a. __Humanoid character setup__. Mecanim has a special workflow for humanoid models, with extended GUI support and [retargeting](Retargeting.md). The setup involves creating and setting up an [Avatar<span class=keyword>](</span>CreatingtheAvatar.md) and tweaking [Muscle definitions<span class=keyword>](</span>MuscleDefinitions.md).  
   b. __Generic character setup__. This is for anything like creatures, animated props, four-legged animals, etc. Retargeting is not possible here, but you can still take advantage of the rich feature set of Mecanim, including everything described below. 
3. __Bringing characters to life__. This involves [setting up animation clips](AligningAnimationClips.md), as well as interactions between them, and involves setup of [State Machines](AnimationStateMachines.md) and [Blend Trees](AnimationBlendTrees.md), exposing [Animation Parameters](AnimationParameters.md), and controlling animations from code. 

Mecanim comes with a lot of new concepts and terminology. If at any point, you need to find out what something means, go to our [Animation Glossary](AnimationGlossary.md).

(:tocportion:)

Legacy animation system
-----------------------

While Mecanim is recommended for use in most situations, especially for working humanoid animations, the Legacy animation system is still used in a variety of contexts. One of them is working legacy animations and code (content created before Unity 4.0). Another is controlling animation clips with parameters other than time (for example for controlling the aiming angle). 
For information on the Legacy animation system, see [this section](Main.Animations40.md)

Unity intends to phase out the Legacy animation system over time for all cases by merging the workflows into Mecanim.
