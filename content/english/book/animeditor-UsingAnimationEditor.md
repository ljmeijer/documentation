Using the Animation View (Legacy)
=================================


The <span class=keyword>Animation View</span> can be used to preview and edit <span class=keyword>Animation Clips</span> for animated <span class=keyword>Game Objects</span> in Unity. The <span class=keyword>Animation View</span> can be opened from the <span class=menu>Window->Animation</span> menu.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorMenu.png)  


Viewing Animations on a GameObject
----------------------------------


The <span class=keyword>Animation View</span> is tightly integrated with the <span class=keyword>Hierarchy View</span>, the <span class=keyword>Scene View</span>, and the <span class=keyword>Inspector</span>. Like the Inspector, the Animation View will show whatever <span class=keyword>Game Object</span> is selected. You can select a Game Object to view using the <span class=keyword>Hierarchy View</span> or the <span class=keyword>Scene View</span>. (If you select a Prefab in the <span class=keyword>Project View</span> you can inspect its animation curves as well, but you have to drag the Prefab into the Scene View in order to be able to edit the curves.)


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorShowsSelectedPP.png)  
_The <span class=keyword>Animation View</span> shows the <span class=keyword>Game Object</span> selected in the <span class=keyword>Hierarchy View</span>._

At the left side of the <span class=keyword>Animation View</span> is a hierarchical list of the animatable properties of the selected <span class=keyword>Game Object</span>. The list is ordered by the <span class=keyword>Components</span> and <span class=keyword>Materials</span> attached to the Game Object, just like in the <span class=keyword>Inspector</span>. Components and Materials can be folded and unfolded by clicking the small triangles next to them. If the selected Game Object has any child Game Objects, these will be shown after all of the Components and Materials.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorMatchesInspectorPP.png)  
_The property list to the left in the <span class=keyword>Animation View</span> shows the Components and Materials of the selected <span class=keyword>Game Object</span>, just like the <span class=keyword>Inspector</span>._


Creating a New Animation Clip
-----------------------------


Animated <span class=keyword>Game Objects</span> in Unity need an <span class=keyword>Animation Component</span> that controls the animations. If a Game Object doesn't already have an Animation Component, the <span class=keyword>Animation View</span> can add one for you automatically when creating a new <span class=keyword>Animation Clip</span> or when entering <span class=keyword>Animation Mode</span>.

To create a new <span class=keyword>Animation Clip</span> for the selected <span class=keyword>Game Object</span>, click the right of the two selection boxes at the upper right of the <span class=keyword>Animation View</span> and select <span class=menu>[Create New Clip]</span>. You will then be prompted to save an Animation Clip somewhere in your <span class=keyword>Assets</span> folder. If the Game Object doesn't have an <span class=keyword>Animation Component</span> already, it will be automatically added at this point. The new <span class=keyword>Animation Clip</span> will automatically be added to the list of Animations in the Animation Component.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorNewClip.png)  
_Create a new <span class=keyword>Animation Clip</span>._

In the <span class=keyword>Animation View</span> you can always see which <span class=keyword>Game Object</span> you are animating and which <span class=keyword>Animation Clip</span> you are editing. There are two selection boxes in the upper left of the Animation View. The left selection box shows the <span class=keyword>Game Object</span> with the <span class=keyword>Animation Component</span> attached, and the right selection box shows the <span class=keyword>Animation Clip</span> you are editing.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorNewAnimationPP.png)  
_The left selection box shows the <span class=keyword>Game Object</span> with the <span class=keyword>Animation Component</span> attached, and the right selection box shows the <span class=keyword>Animation Clip</span> you are editing._


Animating a Game Object
-----------------------


To begin editing an Animation Clip for the selected Game Object, click on the <span class=menu>Animation Mode button</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorAnimationModeButton.png)  

This will enter <span class=keyword>Animation Mode</span>, where changes to the Game Object are stored into the <span class=keyword>Animation Clip</span>. (If the Game Object doesn't have an <span class=keyword>Animation Component</span> already, it will be automatically added at this point. If there is not an existing <span class=keyword>Animation Clip</span>, you will be prompted to save one somewhere in your <span class=keyword>Assets</span> folder.)

You can stop the <span class=keyword>Animation Mode</span> at any time by clicking the <span class=menu>Animation Mode button</span> again. This will revert the <span class=keyword>Game Object</span> to the state it was in prior to entering the Animation Mode.

You can animate any of the properties shown in the property list of the <span class=keyword>Animation View</span>. To animate a property, click on the <span class=menu>Key Indicator</span> for that property and choose <span class=menu>Add Curve</span> from the menu. You can also select multiple properties and right click on the selection to add curves for all the selected properties at once. (<span class=component>Transform</span> properties are special in that the <span class=component>.x</span>, <span class=component>.y</span>, and <span class=component>.z</span> properties are linked, so that curves are added three at a time.)


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorAddCurves.png)  
_Any property can be animated by clicking on its <span class=menu>Key Indicator</span> or by right clicking on its name. For <span class=component>Transform</span> properties, curves for <span class=menu>.x</span>, <span class=menu>.y</span>, and <span class=menu>.z</span> are added together._

When in <span class=keyword>Animation Mode</span>, a red vertical line will show which frame of the <span class=keyword>Animation Clip</span> is currently previewed. The <span class=keyword>Inspector</span> and <span class=keyword>Scene View</span> will show the Game Object at that frame of the Animation Clip. The values of the animated properties at that frame are also shown in a column to the right of the property names.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorPreviewFramePP.png)  
_In <span class=keyword>Animation Mode</span> a red vertical line shows the currently previewed frame. The animated values at that frame are previewed in the <span class=keyword>Inspector</span> and <span class=keyword>Scene View</span> and to the right of the property names in the <span class=keyword>Animation View</span>._

You can click anywhere on the <span class=menu>Time Line</span> to preview or modify that frame in the Animation Clip. The numbers in the <span class=menu>Time Line</span> are shown as seconds and frames, so 1:30 means 1 second and 30 frames.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorTimeLine.png)  

![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorFrameNavigation.png)  

You can also use the following keyboard shortcuts to navigate between frames:

* Press <span class=menu>Comma</span> (<span class=menu>,</span>) to go to the previous frame.
* Press <span class=menu>Period</span> (<span class=menu>.</span>) to go to the next frame.
* Hold Alt and press <span class=menu>Comma</span> (<span class=menu>,</span>) to go to the previous <span class=keyword>keyframe</span>.
* Hold Alt and press <span class=menu>Period</span> (<span class=menu>.</span>) to go to the next <span class=keyword>keyframe</span>.

In <span class=keyword>Animation Mode</span> you can move, rotate, or scale the <span class=keyword>Game Object</span> in the <span class=keyword>Scene View</span>. This will automatically create <span class=keyword>Animation Curves</span> for the position, rotation, and scale properties of the <span class=keyword>Animation Clip</span> if they didn't already exist, and keys on those Animation Curves will automatically be created at the currently previewed frame to store the respective <span class=menu>Transform</span> values you changed.

You can also use the <span class=keyword>Inspector</span> to modify any of the animatable properties of the <span class=keyword>Game Object</span>. This too will create <span class=keyword>Animation Curves</span> as needed, and create <span class=keyword>keys</span> on those Animation Curves at the currently previewed frame to store your changed values. Properties that are not animatable are grayed out in the <span class=keyword>Inspector</span> while in Animation Mode.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorKeyframeButton.png)  

You can also manually create a <span class=keyword>keyframe</span> using the <span class=menu>Keyframe button</span>. This will create a key for all the curves that are currently shown in the <span class=keyword>Animation View</span>. If you want to only show curves for a subset of the properties in the property list, you can select those properties. This is useful for selectively adding keys to specific properties only.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorSelectedPropertyShown.png)  
_When selecting a property in the property list, only the curve for that property is shown._


Playback
--------


The <span class=keyword>Animation Clip</span> can be played back at anytime by clicking the <span class=menu>Play button</span> in the <span class=keyword>Animation View</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorPlayButton.png)  

The playback will loop within the time range that is shown in the <span class=menu>Time Line</span>. This makes it possible to focus on refining a small part of the <span class=keyword>Animation Clip</span> that is being worked on, without having to play back the entire length of the clip. To play back the whole length of the <span class=keyword>Animation Clip</span>, zoom out to view the entire time range, or press <span class=menu>F</span> to Frame Select with no <span class=keyword>keys</span> selected. To learn more about navigating the <span class=menu>Curve View</span>, see the section on [Editing Animation Curves](animeditor-AnimationCurves.md).

