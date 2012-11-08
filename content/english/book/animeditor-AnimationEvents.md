Using Animation Events
======================


The power of animation clips can be increased by using <span class=keyword>Animation Events</span>, which allow you to call functions in the object's script at specified points in the timeline.

The function called by an animation event can optionally take one parameter. The parameter can be a float, string, int, object reference or an AnimationEvent object. The AnimationEvent object has member variables that allow a float, string, integer and object reference to be passed into the function all at once, along with other information about the event that triggered the function call.

````

// This JavaScript function can be called by an Animation Event
function PrintFloat (theValue : float) {
	Debug.Log ("PrintFloat is called with a value of " + theValue);
}

````

You can add an animation event to a clip at the current playhead position by clicking the <span class=menu>Event button</span> or at any point in the animation by double-clicking the <span class=menu>Event Line</span> at the point where you want the event to be triggered. Once added, an event can be repositioned by dragging with the mouse. You can delete an event by selecting it and pressing <span class=menu>Delete</span>, or by right-clicking on it and selecting <span class=menu>Delete Event</span> from the contextual menu.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorEventLine.png)  
_<span class=keyword>Animation Events</span> are shown in the <span class=menu>Event Line</span>. Add a new <span class=keyword>Animation Event</span> by double-clicking the <span class=menu>Event Line</span> or by using the <span class=menu>Event button</span>._

When you add an event, a dialog box will appear to prompt you for the name of the function and the value of the parameter you want to pass to it.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorEventPopup.png)  
_The <span class=keyword>Animation Event</span> popup dialog lets you specify which function to call with which parameter value._

The events added to a clip are shown as markers in the event line. Holding the mouse over a marker will show a tooltip with the function name and parameter value.


![](http://docwiki.hq.unity3d.com/uploads/Main/AnimationEditorEventTooltip.png)  
_Holding the mouse cursor over an <span class=menu>Animation Event marker</span> will show which function it calls as well as the parameter value._

