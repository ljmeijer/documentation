Configuring the Avatar
======================


Since the <span class=keyword>Avatar</span> is such an important aspect of the Mecanim system, it is important that it is configured properly for your model. So, whether the [automatic Avatar creation](CreatingtheAvatar.md) fails or succeeds, you need to go into the <span class=menu>Configure Avatar</span> mode to ensure your Avatar is valid and properly set up. It is important that your character's bone structure matches Mecanim's predefined bone structure _and_ that the model is in T-pose.

If the automatic Avatar creation fails, you will see a cross next to the _Configure_ button. 

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimAvatarInvalid.png)  

If it succeeds, you will see a check/tick mark:

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimAvatarApplied.png)  

Here, success simply means all of the required bones have been matched but for better results, you might want to match the optional bones as well and get the model into a proper T-pose.

When you go to the <span class=menu>Configure ...</span> menu, the editor will ask you to save your scene. The reason for this is that in <span class=menu>Configure</span> mode, the Scene View is used to display bone, muscle and animation information for the selected model alone, without displaying the rest of the scene.


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimConfigureAvatarSaveDialog.png)  

Once you have saved the scene, you will see a new <span class=inspector>Avatar Configuration</span> inspector, with a bone mapping.

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimAvatarMappingValid.png)  

The inspector shows which of the bones are required and which are optional - the optional ones can have their movements interpolated automatically. For Mecanim to produce a valid match, your skeleton needs to have at least the required bones in place. In order to improve your chances for finding a match to the Avatar, name your bones in a way that reflects the body parts they represent (names like "LeftArm", "RightForearm" are suitable here). 

If the model does NOT yield a valid match, you can manually follow a similar process to the one used internally by Mecanim:- 

1. <span class=menu>Sample Bind-pose</span> (try to get the model closer to the pose with which it was modelled, a sensible initial pose)
1. <span class=menu>Automap</span> (create a bone-mapping from an initial pose)
1. <span class=menu>Enforce T-pose</span> (force the model closer to T-pose, which is the default pose used by Mecanim animations)


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimPoseMenus.png)  

If the auto-mapping (<span class=menu>Mapping->Automap</span>) fails completely or partially, you can assign bones by either draging them from the <span class=inspector>Scene</span> or from the <span class=inspector>Hierarchy</span>. If Mecanim thinks a bone fits, it will show up as green in the <span class=inspector>Avatar Inspector</span>, otherwise it shows up in red. 

Finally, if the bone assignment is correct, but the character is not in the correct _pose_, you will see the message "Character not in T-Pose". You can try to fix that with <span class=menu>Enforce T-Pose</span> or rotate the remaining bones into T-pose. 


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimMappingMenus.png)  

(:include class-HumanTemplate:)

(back to [Avatar Creation and Setup](AvatarCreationandSetup.md))

(back to [Mecanim introduction](MecanimAnimationSystem.md))
