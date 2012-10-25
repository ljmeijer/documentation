Configuring the Avatar
======================


In order to use the Mecanim, you need to match your existing skeleton to a predefined bone structure and pose (otherwise known as the <span class=keyword>Avatar</span>). 

it is necessary to have an Avatar, and it is important that this Avatar is configured properly. 

Thus whether the [automatic Avatar creation](Creating the Avatar) fails or succeeds, you need to go into the <span class=menu>Configure Avatar</span> mode to ensure your Avatar is valid and properly set up. It is important that your character's bone structure matches Mecanim's predefined bone structure _and_ that the model is in T-pose.

If the automatic Avatar creation fails, you will see the following indicator. 
![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimAvatarInvalid.png)  

If it succeeds, you should see the following:
![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimAvatarApplied.png)  

The success simply means all of the required bones have been matched, but for better results, you might want to match the optional bones as well, and get the model in a proper T-pose. 

When you go into the <span class=menu>Configure ...</span> menu, the editor will ask you to save your scene. (The reason for this is that in <span class=menu>Configure</span> mode, we use the Scene View to for displaying bone, muscle and animation information for the selected model alone, instead of displaying the rest of the scene.)

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimConfigureAvatarSaveDialog.png)  

Once you've saved the scene, you'll see a new <span class=inspector>Avatar Configuration</span> inspector, with a bone mapping
![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimAvatarMappingValid.png)  

Some of the bones (marked with an asterisk (*)) are required, while others are optional and can be interpolated. For Mecanim to produce a valid match, your skeleton needs to have at least all the required bones in place. In order to improve your chances for finding a match to the Avatar, make sure to name your bones in a sensible way. 

If the model does NOT yield a valid match, you can manually try to recreate the process used internally by Mecanim. 

1. <span class=menu>Sample Bind-pose</span> (try to get the model closer to the pose with which it was modelled, a sensible initial pose)
1. <span class=menu>Automap</span> (create a bone-mapping from an initial pose)
1. <span class=menu>Enforce T-pose</span> (force the model closer to T-pose, which is the default pose used by Mecanim animations)

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimPoseMenus.png)  

If the auto-mapping (<span class=menu>Mapping->Automap</span>) fails completely or partially, you can assign bones by either draging them from the <span class=inspector>Scene</span> or from the <span class=inspector>Hierarchy</span>. If Mecanim thinks a bone fits, it will show up as green in the <span class=inspector>Avatar Inspector</span>, otherwise it shows up in red. 

Finally, if the bone assignment is correct, but the character is not in the correct _pose_, you will see the message "Character not in T-Pose", and the bones not in the T-pose will be . You can try to fix that with <span class=menu>Enforce T-Pose</span> or rotate the remaining bones into T-pose. 

Saving and Loading bone mappings
--------------------------------

When mapping your character requires you to do manual assignments, you have the option to <span class=menu>Save</span> the mapping and <span class=menu>Load</span> for another model

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimMappingMenus.png)  

(:include class-HumanTemplate:)

(back to [Avatar Creation and Setup](Avatar Creation and Setup))

(back to [Mecanim introduction](MecanimAnimationSystem))
