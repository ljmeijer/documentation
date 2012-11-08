Creating the Avatar
===================


After an FBX file is imported, you can specify what kind of rig it is in the <span class=inspector>Rig</span> tab of the <span class=inspector>FBX importer options</span>. 

Humanoid animations
-------------------

For a Humanoid rig, select <span class=menu>Humanoid</span> and click <span class=menu>Apply</span>. Mecanim will attempt to match up your existing bone structure to the Avatar bone structure. In many cases, it can do this automatically by analysing the connections between bones in the rig.

If the match has succeeded, you will see a check mark next to the <span class=menu>Configure...</span> menu


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimImporterRigTab.png)  

Also, in the case of a successful match, an Avatar sub-asset is added to the FBX asset, which you will be able to see in the project view hierarchy. 

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimFBXNoAvatar.png)  
_Models with and without an Avatar sub-asset_


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimAvatarCreated.png)  
_The inspector for an Avatar asset_

If Mecanim was unable to create the Avatar, you will see a cross next to the <span class=menu>Configure ...</span> button, and no Avatar sub-asset will be added. When this happens, you need to [configure the avatar manually](ConfiguringtheAvatar.md).

Non-humanoid animations
-----------------------


Two options for non-humanoid animation are provided: <span class=keyword>Generic</span> and <span class=keyword>Legacy</span>. Generic animations are imported using the Mecanim system but don't take advantage of the extra features available for humanoid animations. Legacy animations use the the animation system that was provided by Unity before Mecanim. There are some cases where it is still useful to work with legacy animations (most notably with legacy projects that you don't want to update fully) but they are seldom needed for new projects. See [this section](Animations40.md) of the manual for further details on legacy animations.

(back to [Avatar Creation and Setup](AvatarCreationandSetup.md))

(back to [Mecanim introduction](MecanimAnimationSystem.md))
