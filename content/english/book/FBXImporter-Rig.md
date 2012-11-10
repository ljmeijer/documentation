FBX Importer, Rig options
=========================


The Rig TAB allows you to assign or create an avatar definition to your imported skinned model so that you can animate it - see [Asset Preparation and Import](Main.AssetPreparationandImport.md)

If you have a __humanoid character__ e.g. a biped (two legs) that has two arms and a head, then choose Humanoid and 'Create from this model' an Avatar will be created to best match the bone hierarchy - see [Avatar Creation and Setup](AvatarCreationandSetup.md) or you can pick an alternative avatar Definition that has already been set up.

If you have a non humanoid character e.g. a quadruped, or any animateable entity that you wish to use with [Mecanim](MecanimAnimationSystem.md) choose __Generic__ after choosing you will then need to identify a bone in the drop down to choose as the 
root node.

Choose legacy if you wish to use the legacy animation system and import and use animations as with 3.x


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimImporterRigTab.png)  


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Animation Type</span>           |The type of animation.|
|>>><span class=component>None</span>|No animation present|
|>>><span class=component>Legacy</span>|Legacy animation system|
|>>><span class=component>Generic</span>|Generic Mecanim animation|
|>>><span class=component>Humanoid</span>|Humanoid Mecanim animation system|
|<span class=component>Avatar Definition</span>|Where to get the Avatar definition|
|>>><span class=component>Create from this model</span>|The Avatar should be based on this model|
|>>><span class=component>Copy from other Avatar</span>|Point to an Avatar config set up on another model. 
|<span class=component>Configure...</span>|Go to the [Avatar configuration](ConfiguringtheAvatar.md)|
|<span class=component>Keep additional bones</span>| |
