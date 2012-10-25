Splitting Animations
====================


Working with models that have pre-split animations
--------------------------------------------------


The simplest types of models to work with are those that contain pre-split animations. If you have an animation like that, the <span class=inspector>Animations</span> tab in the <span class=inspector>Animation Importer Inspector</span> will look like this:
![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimImportPreSplitAnimation.png)  

You will see a list of available clips, which you can you add "actual" clips by pressing (+). Each time you add an actual animation clip, you will be able to select between available animation clips and preview them, by pressing Play in the <span class=inspector>Preview Window</span>. In this scenario, the animation clips are already split so their ranges do not need to be specified in the importer. The properties of the clips, however, can still be edited, if needed. 

###Working with models with unsplit animations

Another type of model you might encounter is a single model containing all animations. The <span class=inspector>Animation</span> tab in the <span class=inspector>Animation Importer Inspector</span> will look like this:

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimImportAnimationNoSplit.png)  

In this case, you can define which frames make up each part of the animation. Somewhere (such as in a text file or an email), the animator will need to specify which animation clip corresponds to what range of frames. You can set those ranges up for each animation clip. Animation clips are added by pressing (+), as before. 

For example:
* walk animation during frames 1 - 33
* run animation during frames 41 - 57
* kick animation during frames 81 - 97


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimImportAnimationSplitting.png)  
_The Import Settings Options for Animation_

In the Import Settings, the <span class=component>Split Animations</span> table is where you tell Unity which frames in your asset file make up which Animation Clip. The names you specify here are used to activate them in your game.

||PROPS
||<span class=component>name</span>        ||Defines the Animation Clip's name within Unity. ||
||<span class=component>Start</span> ||The first frame of the animation. The frame number refers to the same frame as in the 3D program used to create the animation. ||
||<span class=component>End</span>  ||The last frame of the animation. ||
||<span class=component>Wrap Mode</span>   ||Defines how should time beyond the playback range of the clip be treated (Once, Loop, PingPong, ClampForever).||
||<span class=component>Add Loop Frame</span>  ||If enabled, an extra <span class=component>loop frame</span> is inserted at the end of the animation. This frame matches the first frame in the clip. Use this if you want to make a looping animation and the first & last frames don't match up exactly. ||

Working with animation clips for Mecanim animations.
----------------------------------------------------

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimImportAnimationSplittingWithAvatar.png)  

||PROPS
||<span class=component>Lock Pose</span>        ||Lock Pose ||
||<span class=component>Lock Root Rotation</span> ||Lock Root Rotation||
||<span class=component>Lock Height</span>  ||Lock Height ||
||<span class=component>Lock Root Position</span>   ||Lock root position||
||<span class=component>Rotation Offset</span>  ||Rotation Offset||
||<span class=component>Cycle Offset</span>  ||Cycle Offset||
||<span class=component>Mirror</span>  ||Mirror ||
||<span class=component>Body Mask</span>||The parts of the body this animation clip affects
||<span class=component>Curves</span>||Parametric curves


<a id="ImportModelNoAnims"></a>

Adding animations to models that do not contain them
----------------------------------------------------

_For models without muscle definitions (non-Mecanim)_, we will be able to add animation clips to the <span class=component>Animation Component</span>. You need to specify the default animation clip in the <span class=component>Animation</span> property, and the available animation clips in the <span class=component>Animations</span> property. The animation clips we add to such a non-Mecanim model should also be setup in a non-Mecanim way (i.e. the <span class=component>Muscle Definition</span> property should be set to <span class=component>None</span>)
_For models that have muscle definitions (Mecanim)_, this is done differently. You need to: 
* Create a <span class=component>New Animator Controller</span>
* Open the <span class=inspector>Animator Controller Window</span>
* Drag a desired animation clip into the <span class=inspector>Animator Controller Window</span>
* Drag the model asset into the Hierarchy.
* Add the animator controller to the <span class=component>Animator component</span> of the asset.

<a id="ImportFile"></a>

###Importing Animations using multiple model files

Another way to import animations is to follow the @ animation naming scheme. You create separate model files and use this naming convention: 'model name'@'animation name'.fbx

![](http://docwiki.hq.unity3d.com/uploads/Main/animation_at_naming.png)  

_An example of four animation files for an animated character_

Unity automatically imports all four files and collects all animations to the file without the @ sign in. In the example above, the goober.mb file will be set up to reference idle, jump, walk and wallJump automatically.

For __FBX__ simply export a model file with no animation ticked e.g. goober.fbx and the 4 clips as goober@_animname_.fbx by exporting the desired keyframes for each (animation enable in the fbx dialogue)

(back to [Mecanim introduction](MecanimAnimationSystem))
