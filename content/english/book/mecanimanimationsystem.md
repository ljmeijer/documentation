Mecanim Animation System
========================


Unity has a rich and sophisticated animation system called <span class=keyword>Mecanim</span>. Mecanim provides:

* Easy workflow and setup of animations on humanoid characters.
* Animation retargeting - the ability to apply animations from one character model onto another
* Simplified workflow for aligning animation clips
* Convenient preview of animation clips, transitions and interactions between them. This allows animators to work more independently from programmers, prototype and preview their animations before gameplay code is hooked in.
* Management of complex interactions between animations from a visual programming tool.
* Animating different body parts with different logic.

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimShowcase.png)  
->Typical setup in the Visual Programming Tool and the <span class=inspector>Animation Preview window</span>

Mecanim workflow
----------------


Workflow in Mecanim can be split into 3 major stages.

1. __Asset preparation and import__. This is done by artists or animators, with 3rd party tools, such as Max or Maya. This step is independent of Mecanim features. \\
2. __Humanoid character setup for Mecanim__. This involves creating and setting up an [Avatar<span class=keyword>](</span>CreatingtheAvatar) tweaking [Muscle definitions<span class=keyword>](</span>MuscleDefinitions).\\
3. __Bringing characters to life__. This involves [setting up animation clips](AligningAnimationClips), as well as interactions between them, and involves setup of [State Machines](AnimationStateMachines) and [Blend Trees](AnimationBlendTrees), exposing [Animation Parameters](AnimationParameters), and controlling animations from code. 

Mecanim comes with a lot of new concepts and terminology. If at any point, you need to look up what something means, go to our [Animation Glossary](AnimationGlossary)

(:tocportion:)

Legacy animation system
-----------------------

While Mecanim is recommended for use in most situations, especially for work humanoid animations, the Legacy animation system is still used in a variety of contexts. One of them is working legacy animations and code (content created before Unity 4.0). Another is controlling animation clips with parameters other than time (for example for controlling the aiming angle). 
For information on the Legacy animation system, see [this section](Main.Animations40)

Unity intends to phase out the Legacy animation system over time for all cases by merging the workflows with Mecanim.
