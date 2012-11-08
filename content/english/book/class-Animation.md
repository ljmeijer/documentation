Animation
=========



![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationInspector35.png)  
_The Animation <span class=keyword>Inspector</span>_

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Animation</span>  |The default animation that will be played when Play Automatically is enabled. |
|<span class=component>Animations</span> |A list of animations that can be accessed from scripts. |
|<span class=component>Play Automatically</span> |Should the animation be played automatically when starting the game? |
|<span class=component>Animate Physics</span> |Should the animation interact with physics. |
|<span class=component>Culling Type</span>|Determines when the animation will not be played.|
|>>><span class=component>Always Animate</span>|Always animate.|
|>>><span class=component>Based on Renderers</span>|Cull based on the default animation pose.|
|>>><span class=component>Based on Clip Bounds</span>|Cull based on clip bounds (calculated during import), if the clip bounds are out of view, the animation will not be played.|
|>>><span class=component>Based on User Bounds</span>|Cull based on bounds defined by the user, if the user-defined bounds are out of view, the animation will not be played.|

See the [Animation View Guide](AnimationEditorGuide.md) for more information on how to create animations inside Unity.%%  See the [Animation Import](Animations.md) page on how to import animated characters, or the [Animation Scripting](AnimationScripting.md) page on how to create animated behaviors for your game.


