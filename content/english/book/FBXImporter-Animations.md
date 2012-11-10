FBX Importer - Animations Tab
=============================



![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimImporterAnimationsTab.png)  


|    |
|:---|
|___Animations___ |
|<span class=component>Generation</span> |Controls how animations are imported: |
|>>><span class=component>Don't Import</span> |No animation or skinning is imported. |
|>>><span class=component>Store in Original Roots</span> |Animations are stored in the root objects of your animation package (these might be different from the root objects in Unity). |
|>>><span class=component>Store in Nodes</span> |Animations are stored together with the objects they animate. Use this when you have a complex animation setup and want full scripting control. |
|>>><span class=component>Store in Root</span> |Animations are stored in the scene's transform root objects. Use this when animating anything that has a hierarchy. |
|<span class=component>Bake Animations</span> |Enable this when using IK or simulation in your animation package. Unity will convert to forward kinematics on import. This option is available only for Maya, 3dsMax and Cinema4D files. |
|<span class=component>Animation Wrap mode</span> |The default <span class=keyword>Wrap Mode</span> for the animation in the mesh being imported |
|>>><span class=component>Default</span>|The animation plays as specified in the animation splitting options below.|
|>>><span class=component>Once</span>|The animation plays through to the end once and then stops.|
|>>><span class=component>Loop</span>|The animation plays through and then restarts when the end is reached.|
|>>><span class=component>PingPong</span>|The animation plays through and then plays in reverse from the end to the start, and so on.|
|>>><span class=component>ClampForever</span>|The animation plays through but the last frame is repeated indefinitely. This is not the same as Once mode because playback does not technically stop at the last frame (which is useful when blending animations).|
|<span class=component>Split Animations</span> |If you have multiple animations in a single file, you can split it into multiple clips. |
|>>><span class=component>Name</span>|The name of the split animation clip|
|>>><span class=component>Start</span>|The first frame of this clip in the model file |
|>>><span class=component>End</span>|The last frame of this clip in the model file |
|>>><span class=component>WrapMode</span>|What the split clip does when the end of the animation is reached (this is identical to the wrap mode option described above).|
|>>><span class=component>Loop</span>|Depending on how the animation was created, one extra frame of animation may be required for the split clip to loop properly.  If your looping animation doesn't look correct, try enabling this option. |
|___Animation Compression___ |
|<span class=component>Anim. Compression</span> |The type of compression that will be applied to this mesh's animation(s) |
|>>><span class=component>Off</span> |Disables animation compression. This means that Unity doesn't reduce keyframe count on import, which leads to the highest precision animations, but slower performance and bigger file and runtime memory size. It is generally not advisable to use this option - if you need higher precision animation, you should enable keyframe reduction and lower allowed <span class=component>Animation Compression Error</span> values instead. |
|>>><span class=component>Keyframe Reduction</span> |Reduces keyframes on import. If selected, the <span class=component>Animation Compression Errors</span> options are displayed. |
|>>><span class=component>Keyframe Reduction and Compression</span> |Reduces keyframes on import and compresses keyframes when storing animations in files. This affects only file size - the runtime memory size is the same as <span class=component>Keyframe Reduction</span>. If selected, the <span class=component>Animation Compression Errors</span> options are displayed. |
|<span class=component>Animation Compression Errors</span> |These options are available only when keyframe reduction is enabled. |
|>>><span class=component>Rotation Error</span> |Defines how much rotation curves should be reduced. The smaller value you use - the higher precision you get. |
|>>><span class=component>Position Error</span> |Defines how much position curves should be reduced. The smaller value you use - the higher precision you get. |
|>>><span class=component>Scale Error</span> |Defines how much scale curves should be reduced. The smaller value you use - the higher precision you get. |
