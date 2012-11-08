Aligning animation clips
========================


Working with animation clips is easy in Mecanim. 


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Name</span> |The name of the clip.|
|<span class=component>Source Take</span> |The take in the source file to use as a source for this animation clip.|
|<span class=component>Start</span> |Start frame of the clip.|
|<span class=component>End</span> |End frame of the clip.|
|<span class=component>Loop Pose</span>  |Enable to make the motion loop seamlessly.|
|<span class=component>Cycle Offset</span>  |Offset to the cycle of a looping animation, if a different time in it is desired to be the start.|
|<span class=component>Root Transform Rotation</span> | | 
|>>><span class=component>Bake into Pose</span> |Enable to make root rotation be baked into the movement of the bones. Disable to make root rotation be stored as root motion.| 
|>>><span class=component>Based Upon</span> |What the root rotation is based upon.|
|>>> >>><span class=component>Original</span>|Keeps the rotation as it is authored in the source file.|
|>>> >>><span class=component>Body Orientation</span> |Keeps the upper body pointing forward.|
|>>><span class=component>Offset</span> |Offset in degrees to the root rotation.|
|<span class=component>Root Transform Position (Y)</span> | | 
|>>><span class=component>Bake into Pose</span> |Enable to make vertical root motion be baked into the movement of the bones. Disable to make vertical root motion be stored as root motion.| 
|>>><span class=component>Based Upon</span> |What the vertical root position is based upon.|
|>>> >>><span class=component>Original</span> |Keeps the vertical position as it is authored in the source file.|
|>>> >>><span class=component>Center of Mass</span> |Keeps the center of mass aligned with root transform position.|
|>>> >>><span class=component>Feet</span>|Keeps the feet aligned with the root transform position.|
|>>><span class=component>Offset</span> |Offset to the vertical root position.|
|<span class=component>Root Transform Position (XZ)</span> | | 
|>>><span class=component>Bake into Pose</span> |Enable to make horizontal root motion be baked into the movement of the bones. Disable to make horizontal root motion be stored as root motion.| 
|>>><span class=component>Based Upon</span> |What the horizontal root position is based upon.|
|>>> >>><span class=component>Original</span> |Keeps the horizontal position as it is authored in the source file.|
|>>> >>><span class=component>Center of Mass</span> |Keeps the center of mass aligned with the root transform position.|
|>>><span class=component>Offset</span> |Offset to the horizontal root position.|
|<span class=component>Mirror</span> |Mirror left and right in this clip.|
|<span class=component>Body Mask</span> |The Body mask applied to this animation clip (see section on [body masks](AvatarBodyMask.md)).|
|<span class=component>Curves</span> (Unity Pro only)|Parameter-related curves (see [Curves in Mecanim](AnimatorCurves.md)).|

(back to [Mecanim introduction](MecanimAnimationSystem.md))
