Editing Curves
==============


<span class=keyword>Curves</span> can be used for many different things and there are several different controls in Unity that use curves that can be edited.

* The [Animation View](AnimationEditorGuide.md) uses curves to animate properties over time in an <span class=keyword>Animation Clip</span>.

![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorCurve.png)  
_The Animation View._

* Script components can have member variables of type [AnimationCurve](EditingValueProperties.md) that can be used for all kinds of things. Clicking on those in the Inspector will open up the <span class=keyword>Curve Editor</span>.

![](http://docwiki.hq.unity3d.com/uploads/Main/CurveEditorPopup.png)  
_The Curve Editor._

* The [Audio Source](class-AudioSource.md) component uses curves to control rolloff and other properties as a function of distance to the Audio Source.

![](http://docwiki.hq.unity3d.com/uploads/Main/AudioSourceCurve.png)  
_Distance function curves in the AudioSource component in the Inspector._


While these controls have subtle differences, the <span class=keyword>curves</span> can be edited in the exact same way in all of them. This page explains how to navigate and edit curves in those controls. 

Adding and Moving Keys on a Curve
---------------------------------


A <span class=keyword>key</span> can be added to a curve by double-clicking on the curve at the point where the <span class=keyword>key</span> should be placed. It is also possible to add a <span class=keyword>key</span> by right-clicking on a curve and select <span class=menu>Add Key</span> from the context menu.

Once placed, <span class=keyword>keys</span> can be dragged around with the mouse:

* Click on a <span class=keyword>key</span> to select it. Drag the selected <span class=keyword>key</span> with the mouse.
* To snap the <span class=keyword>key</span> to the grid while dragging it around, hold down <span class=menu>Command</span> on Mac / <span class=menu>Control</span> on Windows while dragging.

It is also possible to select multiple <span class=keyword>keys</span> at once:

* To select multiple <span class=keyword>keys</span> at once, hold down <span class=menu>Shift</span> while clicking the keys.
* To deselect a selected <span class=keyword>key</span>, click on it again while holding down <span class=menu>Shift</span>.
* To select all <span class=keyword>keys</span> within a rectangular area, click on an empty spot and drag to form the rectangle selection.
* The rectangle selection can also be added to existing selected keys by holding down <span class=menu>Shift</span>.

<span class=keyword>Keys</span> can be deleted by selecting them and pressing <span class=menu>Delete</span>, or by right-clicking on them and selecting <span class=menu>Delete Key</span> from the context menu.


Navigating the Curve View
-------------------------


When working with the <span class=keyword>Animation View</span> you can easily zoom in on details of the curves you want to work with or zoom out to get the full picture.

You can always press <span class=menu>F</span> to frame-select the shown curves or selected keys in their entirely.

###Zooming

You can <span class=menu>zoom</span> the Curve View using the scroll-wheel of your mouse, the zoom functionality of your trackpad, or by holding <span class=menu>Alt</span> while right-dragging with your mouse. 

You can zoom on only the horizontal or vertical axis:

* <span class=menu>zoom</span> while holding down <span class=menu>Command</span> on Mac / <span class=menu>Control</span> on Windows to zoom horizontally.
* <span class=menu>zoom</span> while holding down <span class=menu>Shift</span> to zoom vertically.

Furthermore, you can drag the end caps of the scrollbars to shrink or expand the area shown in the Curve View.

###Panning

You can <span class=menu>pan</span> the Curve View by middle-dragging with your mouse or by holding <span class=menu>Alt</span> while left-dragging with your mouse.


Editing Tangents
----------------


A <span class=keyword>key</span> has two <span class=keyword>tangents</span> - one on the left for the ingoing slope and one on the right for the outgoing slope. The tangents control the shape of the curve between the keys. The <span class=keyword>Animation View</span> have multiple tangent types that can be used to easily control the curve shape. The tangent types for a <span class=keyword>key</span> can be chosen by right-clicking the key.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationTypeOfConnections2.png)  
_Right-click a <span class=keyword>key</span> to select the tangent type for that key._

In order for animated values to change smoothly when passing a key, the left and right tangent must be co-linear. The following tangent types ensure smoothness:
* <span class=menu>Auto</span>: The tangents are automatically set so make the curve go smoothly through the key.

![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationAuto.png)  
* <span class=menu>Free Smooth</span>: The tangents can be freely set by dragging the tangent handles. They are locked to be co-linear to ensure smoothness.

![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationFreeSmooth.png)  
* <span class=menu>Flat</span>: The tangents are set to be horizontal. (This is a special case of <span class=menu>Free Smooth</span>.)

![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationFlat.png)  

Sometimes smoothness is not desired. The left and right tangent can be set individually when the tangents are <span class=menu>Broken</span>. The left and right tangent can each be set to one of the following tangent types:
* <span class=menu>Free</span>: The tangent can be freely set by dragging the tangent handle.

![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationBrokenFree.png)  
* <span class=menu>Linear</span>: The tangent points towards the neighboring key. A linear curve segment can be made by setting the tangents at both ends to be <span class=menu>Linear</span>.

![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationBrokenLinear.png)  
* <span class=menu>Constant</span>: The curve retains a constant value between two keys. The value of the left key determines the value of the curve segment.

![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationBrokenConstant.png)  

