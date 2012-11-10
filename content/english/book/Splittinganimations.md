Splitting Animations
====================


An animated character typically has a number of different movements that are activated in the game in different circumstances. For example, it might need separate animations for walking, running, jumping, throwing, dying, etc. Depending on the way the model was animated, these separate movements might be imported as distinct animation clips or as one single clip where each movement simply follows on from the previous one. In cases where there is only a single clip, the clip must be __split__ into its component animation sequences within Unity, which will involve some extra steps in your workflow.

Working with models that have pre-split animations
--------------------------------------------------


The simplest types of models to work with are those that contain pre-split animations. If you have an animation like that, the <span class=inspector>Animations</span> tab in the <span class=inspector>Animation Importer Inspector</span> will look like this:

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimImportPreSplitAnimation.png)  

You will see a list available clips which you can preview by pressing Play in the <span class=inspector>Preview Window</span> (lower down in the inspector). The frame ranges of the clips can be edited, if needed. 

Working with models that have unsplit animations
------------------------------------------------


For models where the clips are supplied as one continuous animation, the <span class=inspector>Animation</span> tab in the <span class=inspector>Animation Importer Inspector</span> will look like this:


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimImportAnimationNoSplit.png)  

In cases like this, you can define the frame ranges that correspond to each of the separate animation sequences (walking, jumping, etc). You can create a new animation clip by pressing (+) and selecting the range of frames that are included in it. 

For example:
* walk animation during frames 1 - 33
* run animation during frames 41 - 57
* kick animation during frames 81 - 97



![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimImportAnimationSplitting.png)  
_The Import Settings Options for Animation_

In the Import Settings, the <span class=component>Split Animations</span> table is where you tell Unity which frames in your asset file make up which Animation Clip. The names you specify here are used to activate them in your game.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>name</span>        |Defines the Animation Clip's name within Unity. |
|<span class=component>Start</span> |The first frame of the animation. The frame number refers to the same frame as in the 3D program used to create the animation. |
|<span class=component>End</span>  |The last frame of the animation. |
|<span class=component>Wrap Mode</span>   |Defines how should time beyond the playback range of the clip be treated (Once, Loop, PingPong, ClampForever).|
|<span class=component>Add Loop Frame</span>  |If enabled, an extra <span class=component>loop frame</span> is inserted at the end of the animation. This frame matches the first frame in the clip. Use this if you want to make a looping animation and the first & last frames don't match up exactly. |

Working with animation clips for Mecanim animations.
----------------------------------------------------


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimImportChristmasTree.png)  


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Lock Pose</span>        |Lock Pose |
|<span class=component>Lock Root Rotation</span> |Lock Root Rotation|
|<span class=component>Lock Height</span>  |Lock Height |
|<span class=component>Lock Root Position</span>   |Lock root position|
|<span class=component>Rotation Offset</span>  |Rotation Offset|
|<span class=component>Cycle Offset</span>  |Cycle Offset|
|<span class=component>Mirror</span>  |Mirror |
|<span class=component>Body Mask</span>|The parts of the body this animation clip affects
|<span class=component>Curves</span>|Parametric curves


<a id="ImportModelNoAnims"></a>

Adding animations to models that do not contain them
----------------------------------------------------

You can add animation clips to an <span class=component>Animation</span> component even for models without muscle definitions (ie, non-Mecanim). You need to specify the default animation clip in the <span class=component>Animation</span> property, and the available animation clips in the <span class=component>Animations</span> property. The animation clips you add to such a non-Mecanim model should also be setup in a non-Mecanim way (ie, the <span class=component>Muscle Definition</span> property should be set to <span class=component>None</span>)

For models that have muscle definitions (Mecanim), the process is different:-

* Create a <span class=component>New Animator Controller</span>
* Open the <span class=inspector>Animator Controller Window</span>
* Drag the desired animation clip into the <span class=inspector>Animator Controller Window</span>
* Drag the model asset into the Hierarchy.
* Add the animator controller to the <span class=component>Animator component</span> of the asset.

<a id="ImportFile"></a>

###Importing Animations using multiple model files

Another way to import animations is to follow a naming scheme that Unity allows for the animation files. You create separate model files and name them with the convention 'modelName@animationName.fbx'. For example, for a model called "goober", you could import separate idle, walk, jump and walljump animations using files named "goober@idle.fbx", "goober@walk.fbx", "goober@jump.fbx" and "goober@walljump.fbx". Only the animation data from these files will be used, even if the original files are exported with mesh data.


![](http://docwiki.hq.unity3d.com/uploads/Main/animation_at_naming.png)  

_An example of four animation files for an animated character (note that the .fbx suffix is not shown within Unity)_

Unity automatically imports all four files and collects all animations to the file without the @ sign in. In the example above, the goober.mb file will be set up to reference idle, jump, walk and wallJump automatically.

For FBX files, simply export a model file with no animation ticked (eg, goober.fbx) and the 4 clips as goober@_animname_.fbx by exporting the desired keyframes for each (enable animation in the FBX dialog).

(back to [Mecanim introduction](MecanimAnimationSystem.md))
