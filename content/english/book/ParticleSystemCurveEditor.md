Particle System Curve Editor
============================

MinMax curves
-------------


Many of the properties in the particle system modules describe a change of a value with time. That change is described via <span class=keyword>MinMax Curves</span>. 
These time-animated properties (for example  <span class=component>size</span> and <span class=component>speed</span>), will have a pull down menu on the right hand side, where you can choose between: 

![](http://docwiki.hq.unity3d.com/uploads/Main/MinMaxDropDown.png)  

<span class=component>Constant</span>: The value of the property will not change with time, and will not be displayed in the <span class=keyword>Curve Editor</span>

<span class=component>Random between constants</span>: The value of the property will be selected at random between the two constants

<span class=component>Curve</span>: The value of the property will change with time based on the curve specified in the <span class=keyword>Curve Editor</span>


![](http://docwiki.hq.unity3d.com/uploads/Main/ParticleSystemOneCurve.png)  
>A property animated with a Curve

<span class=component>Random between curves</span>: A curve will be generated at random between the min and the max curve, and the value of the property will change in time based on the generated curve

![](http://docwiki.hq.unity3d.com/uploads/Main/BetweenTwoCurves.png)  
A property animated as <span class=component>Random Between Two Curves</span>

In the <span class=keyword>Curve Editor</span>, the _x_-axis spans time between 0 and the value specified by the <span class=component>Duration</span> property, and the _y_-axis represents the value of the animated property at each point in time. The range of the _y_-axis can be adjusted in the number field in the upper right corner of the <span class=keyword>Curve Editor</span>. The <span class=keyword>Curve Editor</span> currently displays all of the curves for a particle system in the same window. 


![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenMultipleCurves.png)  
>Multiple curves in the same curve editor

Note that the "-" in the bottom-right corner will remove the currently selected curve, while the "+" will _optimize_ it (that is make it into a parametrized curve with at most 3 keys). 

For animating properties that describe vectors in 3D space, we use the TripleMinMax Curves, which are simply curves for the x-,y-, and z- dimensions side by side, and it looks like this: 

![](http://docwiki.hq.unity3d.com/uploads/Main/ShurikenTripleMinMaxCurves.png)  

Managing many curves in the curve editor
----------------------------------------

To avoid cluttering in the <span class=keyword>Curve Editor</span>, it is possible to toggle curves on and off, by clicking on them in the inspector. The Particle System Curve Editor can also be detached from the Inspector by right-clicking on the <span class=component>Particle System Curves</span> title bar, after which you should see something like this:


![](http://docwiki.hq.unity3d.com/uploads/Main/DetachedCurveEditor.png)  
A detached Curve Editor that can be docked like any other window 

For more information on working with curves, take a look at the [Curve Editor documentation](EditingCurves.md)
