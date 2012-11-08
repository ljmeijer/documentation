Editing Value Properties
========================


Value properties do not reference anything and they can be edited right on the spot. Typical value properties are numbers, toggles, strings, and selection popups, but they can also be colors, vectors, curves, and other types.


![](http://docwiki.hq.unity3d.com/uploads/Main/Editor-Inspector.png)  
_Value properties on the inspector can be numbers, checkboxes, strings..._

Many value properties have a text field and can be adjusted simply by clicking on them, entering a value using the keyboard, and pressing <span class=menu>Enter</span> to save the value.

* You can also put your mouse next to a numeric property, left-click and drag it to scroll values quickly
* Some numeric properties also have a slider that can be used to visually tweak the value.

Some Value Properties open up a small popup dialog that can be used to edit the value.

Color Picker
------------

Properties of the <span class=keyword>Color</span> type will open up the <span class=keyword>Color Picker</span>. (On Mac OS X this color picker can be changed to the native OS color picker by enabling <span class=menu>Use OS X Color Picker</span> under <span class=menu>Unity->Preferences</span>.)

The Color Picker reference in the inspector is represented by:


![](http://docwiki.hq.unity3d.com/uploads/Main/Editor-ColorPickerReference.png)  
_Color Picker reference in the inspector._

And opens the Color Picker just by clicking on it:


![](http://docwiki.hq.unity3d.com/uploads/Main/ColorPickerDescr.png)  
_Color Picker descriptions._

Use the <span class=keyword>Eyedropper Tool</span> when you want to find a value just by putting your mouse over the color you want to grab.  
<span class=keyword>RGB / HSV Selector</span> lets you switch your values from _Red, Green, Blue_ to _Hue, Saturation and Value (Strength)_ of your color.  
Finally, the transparency of the Color selected can be controlled  by the <span class=keyword>Alpha Channel</span> value.


Curve Editor
------------

Properties of the <span class=keyword>AnimationCurve</span> type will open up the <span class=keyword>Curve Editor</span>. The Curve Editor lets you edit a curve or choose from one of the presets. For more information on editing curves, see the guide on [Editing Curves](EditingCurves.md).

The type is called AnimationCurve for legacy reasons, but it can be used to define any custom curve function. The function can then be evaluated at runtime from a script. 

An AnimationCurve property is shown in the inspector as a small preview:

![](http://docwiki.hq.unity3d.com/uploads/Main/Editor-PopupCurve.png)  
_A preview of an AnimationCurve in the Inspector._

Clicking on it opens the Curve Editor:


![](http://docwiki.hq.unity3d.com/uploads/Main/CurveEditorPopupDescr.png)  
_The Curve Editor is for editing AnimationCurves._

<span class=keyword>Wrapping Mode</span> Lets you select between Ping Pong, Clamp and Loop for the Control Keys in your curve.  
The <span class=keyword>Presets</span> lets you modify your curve to default outlines the curves can have.

Gradient editor
---------------


In graphics and animation, it is often useful to be able to blend one colour gradually into another, over space or time. A <span class=keyword>gradient</span> is a visual representation of a colour progression, which simply shows the main colours (which are called <span class=keyword>stops</span>) and all the intermediate shades between them. In Unity, gradients have their own special value editor, shown below.


![](http://docwiki.hq.unity3d.com/uploads/Main/GradientDiagram.png)  

The upward-pointing arrows along the bottom of the gradient bar denote the stops. You can select a stop by clicking on it; its value will be shown in the Color box which will open the standard colour picker when clicked. A new stop can be created by clicking just underneath the gradient bar. The position of any of the stops can be changed simply by clicking and dragging and a stop can be removed with <span class=menu>ctrl/cmd + delete</span>.

The downward-pointing arrows above the gradient bar are also stops but they correspond to the alpha (transparency) of the gradient at that point. By default, there are two stops set to 100% alpha (ie, fully opaque) but any number of stops can be added and edited in much the same way as the colour stops.
