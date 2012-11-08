Using Animation Curves (Legacy)
===============================


The Property List
-----------------


In an <span class=keyword>Animation Clip</span>, any animatable property can have an <span class=keyword>Animation Curve</span>, which means that the Animation Clip controls that property. In the property list of the <span class=keyword>Animation View</span> properties with <span class=keyword>Animation Curves</span> have colored curve indicators. For information on how to add curves to an animation property, see the section on [Using the Animation View](animeditor-UsingAnimationEditor.md).

A <span class=keyword>Game Object</span> can have quite a few components and the property list in the <span class=keyword>Animation View</span> can get very long. To show only the properties that have <span class=keyword>Animation Curves</span>, click the lower left button in the <span class=keyword>Animation View</span> to set its state to <span class=menu>Show: Animated</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorShowAnimatedPP.png)  
_Set the toggle button in the lower left corner to <span class=menu>Show: Animated</span> to hide all the properties without <span class=keyword>Animation Curves</span> from the property list._


Understanding Curves, Keys and Keyframes
----------------------------------------


An <span class=keyword>Animation Curve</span> has multiple <span class=keyword>keys</span> which are control points that the curve passes through. These are visualized in the <span class=keyword>Curve Editor</span> as small diamond shapes on the curves. A frame in which one or more of the shown curves have a <span class=keyword>key</span> is called a <span class=keyword>keyframe</span>. The <span class=keyword>keyframes</span> are shown as white diamonds in the <span class=menu>Keyframe Line</span>.

If a property has a <span class=keyword>key</span> in the currently previewed frame, the curve indicator will have a diamond shape.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorDetailPP.png)  
_The <span class=menu>Rotation.y</span> property has a <span class=keyword>key</span> at the currently previewed frame. The <span class=menu>Keyframe Line</span> marks the <span class=keyword>keyframes</span> for all shown curves._

The <span class=menu>Keyframe Line</span> only shows keyframes for the curves that are shown. If a property is selected in the property list, only that property is shown, and the <span class=menu>Keyframe Line</span> will not mark the keys of the curves that are not shown.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorSimpleSingleCurve.png)  
_When a property is selected, other properties are not shown and the keys of their curves are not shown in the <span class=menu>Keyframe Line</span>._


Adding and Moving Keyframes
---------------------------



![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorKeyframeLine.png)  
The <span class=menu>Keyframe Line</span> shows the <span class=keyword>keyframes</span> of the currently shown curves. You can add a <span class=keyword>keyframe</span> by double-clicking the <span class=menu>Keyframe Line</span> or by using the <span class=menu>Keyframe button</span>.

A <span class=keyword>keyframe</span> can be added at the currently previewed frame by clicking the <span class=menu>Keyframe button</span> or at any given frame by double-clicking the <span class=menu>Keyframe Line</span> at the frame where the <span class=keyword>keyframe</span> should be. This will add a <span class=keyword>key</span> to all the shown curves at once. It is also possible to add a <span class=keyword>keyframe</span> by right-clicking the <span class=menu>Keyframe Line</span> and select <span class=menu>Add Keyframe</span> from the context menu. Once placed, <span class=keyword>keyframes</span> can be dragged around with the mouse. It is also possible to select multiple <span class=keyword>keyframes</span> to drag at once. <span class=keyword>Keyframes</span> can be deleted by selecting them and pressing <span class=menu>Delete</span>, or by right-clicking on them and selecting <span class=menu>Delete Keyframe</span> from the context menu.


Wrap Mode
---------


An <span class=keyword>Animation Clip</span> in Unity can have various <span class=keyword>Wrap Modes</span> that can for example set the Animation Clip to loop. See [WrapMode](ScriptRef:WrapMode.html) in the Scripting Reference to learn more. The Wrap Mode of an Animation Clip can be set in the <span class=keyword>Animation View</span> in the lower right selection box. The <span class=menu>Curve View</span> will preview the selected <span class=keyword>Wrap Mode</span> as white lines outside of the time range of the Animation Clip.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorWrapmode.png)  
Setting the <span class=keyword>Wrap Mode</span> of an <span class=keyword>Animation Clip</span> will preview that Wrap Mode in the <span class=menu>Curve View</span>.


Supported Animatable Properties
-------------------------------


The <span class=keyword>Animation View</span> can be used to animate much more than just the position, rotation, and scale of a <span class=keyword>Game Object</span>. The properties of any <span class=keyword>Component</span> and <span class=keyword>Material</span> can be animated - even the public variables of your own scripts components. Making animations with complex visual effects and behaviors is only a matter of adding <span class=keyword>Animation Curves</span> for the relevant properties.

The following types of properties are supported in the animation system:

* Float
* Color
* Vector2
* Vector3
* Vector4
* Quaternion

Arrays are not supported and neither are structs or objects other than the ones listed above. 

Booleans in script components are not supported by the animation system, but booleans in certain built-in components are. For those booleans, a value of <span class=menu>0</span> equals <span class=menu>False</span> while any other value equals <span class=menu>True</span>.

Here are a few examples of the many things the <span class=keyword>Animation View</span> can be used for:

* Animate the <span class=component>Color</span> and <span class=component>Intensity</span> of a <span class=component>Light</span> to make it blink, flicker, or pulsate.
* Animate the <span class=component>Pitch</span> and <span class=component>Volume</span> of a looping <span class=component>Audio Source</span> to bring life to blowing wind, running engines, or flowing water while keeping the sizes of the sound assets to a minimum.
* Animate the <span class=component>Texture Offset</span> of a <span class=component>Material</span> to simulate moving belts or tracks, flowing water, or special effects.
* Animate the <span class=component>Emit</span> state and <span class=component>Velocities</span> of multiple <span class=component>Ellipsoid Particle Emitters</span> to create spectacular fireworks or fountain displays.
* Animate variables of your own script components to make things behave differently over time.

When using <span class=keyword>Animation Curves</span> to control game logic, please be aware of the way animations are [played back and sampled](AnimationScripting#Playback.md) in Unity.


Rotation Interpolation Types
----------------------------


In Unity rotations are internally represented as <span class=component>Quaternions</span>. Quaternions consist of <span class=component>.x</span>, <span class=component>.y</span>, <span class=component>.z</span>, and <span class=component>.w</span> values that should generally not be modified manually except by people who know exactly what they're doing. Instead, rotations are typically manipulated using <span class=component>Euler Angles</span> which have <span class=component>.x</span>, <span class=component>.y</span>, and <span class=component>.z</span> values representing the rotations around those three respective axes.

When interpolating between two rotations, the interpolation can either be performed on the <span class=component>Quaternion</span> values or on the <span class=component>Euler Angles</span> values. The <span class=keyword>Animation View</span> lets you choose which form of interpolation to use when animating <span class=component>Transform</span> rotations. However, the rotations are always shown in the form of <span class=component>Euler Angles</span> values no matter which interpolation form is used.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorQuaternionInterpolationMenu.png)  
_Transform rotations can use <span class=component>Euler Angles</span> interpolation or <span class=component>Quaternion</span> interpolation._

###Quaternion Interpolation

Quaternion interpolation always generates nice interpolations along the shortest path between two rotations. This avoids rotation interpolation artifacts such as Gimbal Lock. However, Quaternion interpolation cannot represent rotations larger than 180 degrees, because it is then shorter to go the other way around. If you use Quaternion interpolation and place two keys further apart than 180 degrees, the curve will look discontinuous, even though the actual rotation is still smooth - it simply goes the other way around, because it is shorter. If rotations larger than 180 degrees are desired, additional keys must be placed in between. When using Quaternion interpolation, changing the keys or tangents of one curve may also change the shapes of the other two curves, since all three curves are created from the internal Quaternion representation. When using Quaternion interpolation, keys are always linked, so that creating a key at a specific time for one of the three curves will also create a key at that time for the other two curves.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorQuaternionInterpolation.png)  
_Placing two keys 270 degrees apart when using Quaternion interpolation will cause the interpolated value to go the other way around, which is only 90 degrees._

###Euler Angles Interpolation

Euler Angles interpolation is what most people are used to working with. Euler Angles can represent arbitrary large rotations and the <span class=component>.x</span>, <span class=component>.y</span>, and <span class=component>.z</span> curves are independent from each other. Euler Angles interpolation can be subject to artifacts such as Gimbal Lock when rotating around multiple axes at the same time, but are intuitive to work with for simple rotations around one axis at a time. When Euler Angles interpolation is used, Unity internally bakes the curves into the Quaternion representation used internally. This is similar to what happens when importing animation into Unity from external programs. Note that this curve baking may add extra keys in the process and that tangents with the <span class=menu>Constant</span> tangent type may not be completely precise at a sub-frame level.
