Scene View Navigation
=====================


The Scene View has a set of navigation controls to help you move around quickly and efficiently.


Arrow Movement
--------------


You can use the <span class=menu>Arrow Keys</span> to move around the scene as though "walking" through it. The up and down arrows move the camera forward and backward in the direction it is facing. The left and right arrows pan the view sideways. Hold down the <span class=menu>Shift</span> key with an arrow to move faster.


Focusing
--------


If you select a GameObject in the hierarchy, then move the mouse over the scene view and press the <span class=menu>F</span> key, the view will move so as to center on the object. This feature is referred to as <span class=component>frame selection</span>.


Move, Orbit and Zoom
--------------------


Moving, orbiting and zooming are key operations in Scene View navigation, so Unity provides several alternative ways to perform them for maximum convenience.

###Using the Hand Tool

When the hand tool is selected (shortcut: <span class=menu>Q</span>), the following mouse controls are available:


![](http://docwiki.hq.unity3d.com/uploads/Main/UI-ViewTool.png)  

![](http://docwiki.hq.unity3d.com/uploads/Main/Editor-EyeTool.png)  

![](http://docwiki.hq.unity3d.com/uploads/Main/Editor-ZoomTool.png)  

Holding down <span class=menu>Shift</span> will increase the rate of movement and zooming.

###Shortcuts Without Using the Hand Tool

For extra efficiency, all of these controls can also be used regardless of which transform tool is selected.
The most convenient controls depend on which mouse or track-pad you are using:


|    |    |    |    |
|:---|:---|:---|:---|
|!Action   |!3-button mouse                                        |!2-button mouse or track-pad         |!Mac with only one mouse button or track-pad                 |
|<span class=keyword>Move</span>  |Hold <span class=menu>Alt</span> and middle click-drag.                    |Hold <span class=menu>Alt-Control</span> and click-drag. |Hold <span class=menu>Alt-Command</span> and click-drag.                         |
|<span class=keyword>Orbit</span> |Hold <span class=menu>Alt</span> and click-drag.                           |Hold <span class=menu>Alt</span> and click-drag.         |Hold <span class=menu>Alt</span> and click-drag.                                 |
|<span class=keyword>Zoom</span>  |Hold <span class=menu>Alt</span> and right click-drag or use scroll-wheel. |Hold <span class=menu>Alt</span> and right click-drag.   |Hold <span class=menu>Alt-Control</span> and click-drag or use two-finger swipe. |


Flythrough Mode
---------------


The <span class=keyword>Flythrough</span> mode lets you navigate the Scene View by flying around in first person similar to how you would navigate in many games.

* Click and hold the right mouse button.
* Now you can move the view around using the mouse and use the <span class=menu>WASD</span> keys to move left/right forward/backward and the <span class=menu>Q</span> and <span class=menu>E</span> keys to move up and down.
* Holding down <span class=menu>Shift</span> will make you move faster.

Flythrough mode is designed for <span class=keyword>Perspective Mode</span>. In <span class=keyword>Isometric Mode</span>, holding down the right mouse button and moving the mouse will orbit the camera instead.

Scene Gizmo
-----------


In the upper-right corner of the Scene View is the <span class=keyword>Scene Gizmo</span>.  This displays the Scene View Camera's current orientation, and allows you to quickly modify the viewing angle.


![](http://docwiki.hq.unity3d.com/uploads/Main/Editor-SceneGizmo.png)  


###u30 Details
You can click on any of the arms to snap the Scene View Camera to that direction and change it to <span class=keyword>Isometric Mode</span>.  While in Isometric Mode, you can right-click drag to orbit, and Alt-click drag to pan.  To exit this mode, click the middle of the Scene Gizmo. You can also Shift-click the middle of the Scene Gizmo any time to toggle <span class=keyword>Isometric Mode</span>.

###u40 Details
You can click on any of the arms to snap the Scene View Camera to that direction.  Click the middle of the Scene Gizmo, or the text below it, to toggle between <span class=keyword>Isometric Mode</span> and <span class=keyword>Perspective Mode</span>.  You can also always shift-click the middle of the Scene Gizmo to get a "nice" perspective view with an angle that is looking at the scene from the side and slightly from above.


![](http://docwiki.hq.unity3d.com/uploads/Main/Camera-Non-Ortho.png)  
_Perspective mode._


![](http://docwiki.hq.unity3d.com/uploads/Main/Camera-Ortho.png)  
_Isometric mode. Objects do not get smaller with distance here!_

###Mac Trackpad Gestures

####u30 Details
On a Mac with a trackpad, you can drag with two fingers to zoom the view. You can also use three fingers to simulate the effect of the <span class=keyword>Scene Gizmo</span>: drag up, left, right or down to activate top, right, left or perspective views, respectively.

####u40 Details
On a Mac with a trackpad, you can drag with two fingers to zoom the view.

You can also use three fingers to simulate the effect of clicking the arms of the <span class=keyword>Scene Gizmo</span>: drag up, left, right or down to snap the Scene View Camera to the corresponding direction. In OS X 10.7 "Lion" you may have to change your trackpad settings in order to enable this feature:
* Open System Preferences and then Trackpad (or type trackpad into Spotlight).
* Click into the "More Gestures" option.
* Click the first option labelled "Swipe between pages" and then either set it to "Swipe left or right with three fingers" or "Swipe with two or three fingers".
