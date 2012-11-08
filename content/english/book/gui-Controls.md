Controls
========



Control Types
-------------


There are a number of different GUI <span class=keyword>Controls</span> that you can create.  This section lists all of the available display and interactive Controls.  There are other GUI functions that affect layout of Controls, which are described in the [Layout](gui-Layout.md) section of the Guide.


###[Label](ScriptRef:GUI.Label.html)

The <span class=component>Label</span> is non-interactive.  It is for display only.  It cannot be clicked or otherwise moved.  It is best for displaying information only.

````

/* GUI.Label example */


// JavaScript
function OnGUI () {
	GUI.Label (Rect (25, 25, 100, 30), "Label");
}


// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
					
	void OnGUI () {
		GUI.Label (new Rect (25, 25, 100, 30), "Label");
	}

}

````


![](http://docwiki.hq.unity3d.com/uploads/Main/gsg-LabelExample.png)  
_The Label created by the example code_


###[Button](ScriptRef:GUI.Button.html)

The <span class=component>Button</span> is a typical interactive button.  It will respond a single time when clicked, no matter how long the mouse remains depressed.  The response occurs as soon as the mouse button is released.

####Basic Usage
In UnityGUI, Buttons will return <span class=component>true</span> when they are clicked.  To execute some code when a Button is clicked, you wrap the the GUI.Button function in an <span class=component>if</span> statement.  Inside the <span class=component>if</span> statement is the code that will be executed when the Button is clicked.

````

/* GUI.Button example */


// JavaScript
function OnGUI () {
	if (GUI.Button (Rect (25, 25, 100, 30), "Button")) {
		// This code is executed when the Button is clicked
	}
}


// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
					
	void OnGUI () {
		if (GUI.Button (new Rect (25, 25, 100, 30), "Button")) {
			// This code is executed when the Button is clicked
		}
	}

}

````


![](http://docwiki.hq.unity3d.com/uploads/Main/gsg-ButtonExample.png)  
_The Button created by the example code_


###[RepeatButton](ScriptRef:GUI.RepeatButton.html)

<span class=component>RepeatButton</span> is a variation of the regular <span class=component>Button</span>.  The difference is, <span class=component>RepeatButton</span> will respond every frame that the mouse button remains depressed.  This allows you to create click-and-hold functionality.

####Basic Usage
In UnityGUI, RepeatButtons will return <span class=component>true</span> for every frame that they are clicked.  To execute some code while the Button is being clicked, you wrap the the GUI.RepeatButton function in an <span class=component>if</span> statement.  Inside the <span class=component>if</span> statement is the code that will be executed while the RepeatButton remains clicked.

````

/* GUI.RepeatButton example */


// JavaScript
function OnGUI () {
	if (GUI.RepeatButton (Rect (25, 25, 100, 30), "RepeatButton")) {
		// This code is executed every frame that the RepeatButton remains clicked
	}
}


// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
					
	void OnGUI () {
		if (GUI.RepeatButton (new Rect (25, 25, 100, 30), "RepeatButton")) {
			// This code is executed every frame that the RepeatButton remains clicked
		}
	}

}

````


![](http://docwiki.hq.unity3d.com/uploads/Main/gsg-RepeatButtonExample.png)  
_The Repeat Button created by the example code_



###[TextField](ScriptRef:GUI.TextField.html)

The <span class=component>TextField</span> Control is an interactive, editable single-line field containing a text string.

####Basic Usage
The TextField will always display a string.  You must provide the string to be displayed in the TextField.  When edits are made to the string, the TextField function will return the edited string.

````

/* GUI.TextField example */


// JavaScript
var textFieldString = "text field";

function OnGUI () {
	textFieldString = GUI.TextField (Rect (25, 25, 100, 30), textFieldString);
}


// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
					
	private string textFieldString = "text field";
	
	void OnGUI () {
		textFieldString = GUI.TextField (new Rect (25, 25, 100, 30), textFieldString);
	}

}

````


![](http://docwiki.hq.unity3d.com/uploads/Main/gsg-TextFieldExample.png)  
_The TextField created by the example code_



###[TextArea](ScriptRef:GUI.TextArea.html)

The <span class=component>TextArea</span> Control is an interactive, editable multi-line area containing a text string.

####Basic Usage
The TextArea will always display a string.  You must provide the string to be displayed in the TextArea.  When edits are made to the string, the TextArea function will return the edited string.

````

/* GUI.TextArea example */


// JavaScript
var textAreaString = "text area";

function OnGUI () {
	textAreaString = GUI.TextArea (Rect (25, 25, 100, 30), textAreaString);
}


// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
					
	private string textAreaString = "text area";
	
	void OnGUI () {
		textAreaString = GUI.TextArea (new Rect (25, 25, 100, 30), textAreaString);
	}

}

````


![](http://docwiki.hq.unity3d.com/uploads/Main/gsg-TextAreaExample.png)  
_The TextArea created by the example code_


###[Toggle](ScriptRef:GUI.Toggle.html)

The <span class=component>Toggle</span> Control creates a checkbox with a persistent on/off state.  The user can change the state by clicking on it.

####Basic Usage
The Toggle on/off state is represented by a true/false boolean. You must provide the boolean as a parameter to make the Toggle represent the actual state. The Toggle function will return a new boolean value if it is clicked.  In order to capture this interactivity, you must assign the boolean to accept the return value of the Toggle function.

````

/* GUI.Toggle example */


// JavaScript
var toggleBool = true;

function OnGUI () {
	toggleBool = GUI.Toggle (Rect (25, 25, 100, 30), toggleBool, "Toggle");
}


// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
					
	private bool toggleBool = true;
	
	void OnGUI () {
		toggleBool = GUI.Toggle (new Rect (25, 25, 100, 30), toggleBool, "Toggle");
	}

}

````


![](http://docwiki.hq.unity3d.com/uploads/Main/gsg-ToggleExample.png)  
_The Toggle created by the example code_


###[Toolbar](ScriptRef:GUI.Toolbar.html)

The <span class=component>Toolbar</span> Control is essentially a row of <span class=component>Buttons</span>.  Only one of the Buttons on the Toolbar can be active at a time, and it will remain active until a different Button is clicked. This behavior emulates the behavior of a typical Toolbar.  You can define an arbitrary number of Buttons on the Toolbar.

####Basic Usage
The active Button in the Toolbar is tracked through an integer.  You must provide the integer as an argument in the function.  To make the Toolbar interactive, you must assign the integer to the return value of the function.  The number of elements in the content array that you provide will determine the number of Buttons that are shown in the Toolbar.

````

/* GUI.Toolbar example */


// JavaScript
var toolbarInt = 0;
var toolbarStrings : String[] = ["Toolbar1", "Toolbar2", "Toolbar3"];

function OnGUI () {
	toolbarInt = GUI.Toolbar (Rect (25, 25, 250, 30), toolbarInt, toolbarStrings);
}


// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
					
	private int toolbarInt = 0;
	private string[] toolbarStrings = {"Toolbar1", "Toolbar2", "Toolbar3"};
	
	void OnGUI () {
		toolbarInt = GUI.Toolbar (new Rect (25, 25, 250, 30), toolbarInt, toolbarStrings);
	}

}

````


![](http://docwiki.hq.unity3d.com/uploads/Main/gsg-ToolbarExample.png)  
_The Toolbar created by the example code_


###[SelectionGrid](ScriptRef:GUI.SelectionGrid.html)

The <span class=component>SelectionGrid</span> Control is a multi-row <span class=component>Toolbar</span>.  You can determine the number of columns and rows in the grid.  Only one Button can be active at time.

####Basic Usage
The active Button in the SelectionGrid is tracked through an integer.  You must provide the integer as an argument in the function.  To make the SelectionGrid interactive, you must assign the integer to the return value of the function.  The number of elements in the content array that you provide will determine the number of Buttons that are shown in the SelectionGrid.  You also can dictate the number of columns through the function arguments.


````

/* GUI.SelectionGrid example */


// JavaScript
var selectionGridInt : int = 0;
var selectionStrings : String[] = ["Grid 1", "Grid 2", "Grid 3", "Grid 4"];

function OnGUI () {
	selectionGridInt = GUI.SelectionGrid (Rect (25, 25, 100, 30), selectionGridInt, selectionStrings, 2);

}


// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
					
	private int selectionGridInt = 0;
	private string[] selectionStrings = {"Grid 1", "Grid 2", "Grid 3", "Grid 4"};
	
	void OnGUI () {
		selectionGridInt = GUI.SelectionGrid (new Rect (25, 25, 300, 60), selectionGridInt, selectionStrings, 2);
	
	}

}

````


![](http://docwiki.hq.unity3d.com/uploads/Main/gsg-SelectionGridExample.png)  
_The SelectionGrid created by the example code_


###[HorizontalSlider](ScriptRef:GUI.HorizontalSlider.html)

The <span class=component>HorizontalSlider</span> Control is a typical horizontal sliding knob that can be dragged to change a value between predetermined min and max values.

####Basic Usage
The position of the Slider knob is stored as a float.  To display the position of the knob, you provide that float as one of the arguments in the function.  There are two additional values that determine the minimum and maximum values.  If you want the slider knob to be adjustable, assign the slider value float to be the return value of the Slider function.

````

/* Horizontal Slider example */


// JavaScript
var hSliderValue : float = 0.0;

function OnGUI () {
	hSliderValue = GUI.HorizontalSlider (Rect (25, 25, 100, 30), hSliderValue, 0.0, 10.0);
}


// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
					
	private float hSliderValue = 0.0f;
	
	void OnGUI () {
		hSliderValue = GUI.HorizontalSlider (new Rect (25, 25, 100, 30), hSliderValue, 0.0f, 10.0f);
	}

}

````


![](http://docwiki.hq.unity3d.com/uploads/Main/gsg-HorizontalSliderExample.png)  
_The Horizontal Slider created by the example code_


###[VerticalSlider](ScriptRef:GUI.VerticalSlider.html)

The <span class=component>VerticalSlider</span> Control is a typical vertical sliding knob that can be dragged to change a value between predetermined min and max values.

####Basic Usage
The position of the Slider knob is stored as a float.  To display the position of the knob, you provide that float as one of the arguments in the function.  There are two additional values that determine the minimum and maximum values.  If you want the slider knob to be adjustable, assign the slider value float to be the return value of the Slider function.

````

/* Vertical Slider example */


// JavaScript
var vSliderValue : float = 0.0;

function OnGUI () {
	vSliderValue = GUI.VerticalSlider (Rect (25, 25, 100, 30), vSliderValue, 10.0, 0.0);
}


// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
					
	private float vSliderValue = 0.0f;
	
	void OnGUI () {
		vSliderValue = GUI.VerticalSlider (new Rect (25, 25, 100, 30), vSliderValue, 10.0f, 0.0f);
	}

}

````


![](http://docwiki.hq.unity3d.com/uploads/Main/gsg-VerticalSliderExample.png)  
_The Vertical Slider created by the example code_


###[HorizontalScrollbar](ScriptRef:GUI.HorizontalScrollbar.html)

The <span class=component>HorizontalScrollbar</span> Control is similar to a <span class=component>Slider</span> Control, but visually similar to Scrolling elements for web browsers or word processors.  This control is used to navigate the <span class=component>ScrollView</span> Control.

####Basic Usage
Horizontal Scrollbars are implemented identically to Horizontal Sliders with one exception: There is an additional argument which controls the width of the Scrollbar knob itself.

````

/* Horizontal Scrollbar example */


// JavaScript
var hScrollbarValue : float;

function OnGUI () {
	hScrollbarValue = GUI.HorizontalScrollbar (Rect (25, 25, 100, 30), hScrollbarValue, 1.0, 0.0, 10.0);
}


// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
					
	private float hScrollbarValue;
	
	void OnGUI () {
		hScrollbarValue = GUI.HorizontalScrollbar (new Rect (25, 25, 100, 30), hScrollbarValue, 1.0f, 0.0f, 10.0f);
	}

}

````


![](http://docwiki.hq.unity3d.com/uploads/Main/gsg-HorizontalScrollbarExample.png)  
_The Horizontal Scrollbar created by the example code_


###[VerticalScrollbar](ScriptRef:GUI.VerticalScrollbar.html)

The <span class=component>VerticalScrollbar</span> Control is similar to a <span class=component>Slider</span> Control, but visually similar to Scrolling elements for web browsers or word processors.  This control is used to navigate the <span class=component>ScrollView</span> Control.

####Basic Usage
Vertical Scrollbars are implemented identically to Vertical Sliders with one exception: There is an additional argument which controls the height of the Scrollbar knob itself.


````

/* Vertical Scrollbar example */


// JavaScript
var vScrollbarValue : float;

function OnGUI () {
	vScrollbarValue = GUI. VerticalScrollbar (Rect (25, 25, 100, 30), vScrollbarValue, 1.0, 10.0, 0.0);
}


// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
					
	private float vScrollbarValue;
	
	void OnGUI () {
		vScrollbarValue = GUI. VerticalScrollbar (new Rect (25, 25, 100, 30), vScrollbarValue, 1.0f, 10.0f, 0.0f);
	}

}

````


![](http://docwiki.hq.unity3d.com/uploads/Main/gsg-VerticalScrollbarExample.png)  
_The Vertical Scrollbar created by the example code_


###[ScrollView](ScriptRef:GUI.BeginScrollView.html)

<span class=component>ScrollViews</span> are Controls that display a viewable area of a much larger set of Controls.

####Basic Usage
ScrollViews require two <span class=component>Rects</span> as arguments.  The first <span class=component>Rect</span> defines the location and size of the viewable ScrollView area on the screen.  The second <span class=component>Rect</span> defines the size of the space contained inside the viewable area.  If the space inside the viewable area is larger than the viewable area, Scrollbars will appear as appropriate.  You must also assign and provide a 2D Vector which stores the position of the viewable area that is displayed.

````

/* ScrollView example */


// JavaScript
var scrollViewVector : Vector2 = Vector2.zero;
var innerText : String = "I am inside the ScrollView";

function OnGUI () {
	// Begin the ScrollView
	scrollViewVector = GUI.BeginScrollView (Rect (25, 25, 100, 100), scrollViewVector, Rect (0, 0, 400, 400));

	// Put something inside the ScrollView
	innerText = GUI.TextArea (Rect (0, 0, 400, 400), innerText);

	// End the ScrollView
	GUI.EndScrollView();
}


// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
					
	private Vector2 scrollViewVector = Vector2.zero;
	private string innerText = "I am inside the ScrollView";
	
	void OnGUI () {
		// Begin the ScrollView
		scrollViewVector = GUI.BeginScrollView (new Rect (25, 25, 100, 100), scrollViewVector, new Rect (0, 0, 400, 400));
	
		// Put something inside the ScrollView
		innerText = GUI.TextArea (new Rect (0, 0, 400, 400), innerText);
	
		// End the ScrollView
		GUI.EndScrollView();
	}

}

````


![](http://docwiki.hq.unity3d.com/uploads/Main/gsg-ScrollViewExample.png)  
_The ScrollView created by the example code_



###[Window](ScriptRef:GUI.Window.html)

<span class=component>Windows</span> are drag-able containers of Controls.  They can receive and lose focus when clicked.  Because of this, they are implemented slightly differently from the other Controls.  Each Window has an <span class=component>id</span> number, and its contents are declared inside a separate function that is called when the Window has focus.

####Basic Usage
Windows are the only Control that require an additional function to work properly.  You must provide an <span class=component>id</span> number and a function name to be executed for the Window.  Inside the Window function, you create your actual behaviors or contained Controls.

````

/* Window example */


// JavaScript
var windowRect : Rect = Rect (20, 20, 120, 50);

function OnGUI () {
	windowRect = GUI.Window (0, windowRect, WindowFunction, "My Window");
}

function WindowFunction (windowID : int) {
	// Draw any Controls inside the window here
}


// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
					
	private Rect windowRect = new Rect (20, 20, 120, 50);
	
	void OnGUI () {
		windowRect = GUI.Window (0, windowRect, WindowFunction, "My Window");
	}
	
	void WindowFunction (int windowID) {
		// Draw any Controls inside the window here
	}

}

````


![](http://docwiki.hq.unity3d.com/uploads/Main/gsg-WindowExample.png)  
_The Window created by the example code_


###[GUI.changed](ScriptRef:GUI-changed.html)

To detect if the user did any action in the GUI (clicked a button, dragged a slider, etc), read the <span class=component>GUI.changed</span> value from your script. This gets set to true when the user has done something, making it easy to validate the user input.  

A common scenario would be for a Toolbar, where you want to change a specific value based on which Button in the Toolbar was clicked.  You don't want to assign the value in every call to <span class=component>OnGUI()</span>, only when one of the Buttons has been clicked.  

````

/* GUI.changed example */


// JavaScript
private var selectedToolbar : int = 0;
private var toolbarStrings = ["One", "Two"];

function OnGUI () {
	// Determine which button is active, whether it was clicked this frame or not
	selectedToolbar = GUI.Toolbar (Rect (50, 10, Screen.width - 100, 30), selectedToolbar, toolbarStrings);

	// If the user clicked a new Toolbar button this frame, we'll process their input
	if (GUI.changed)
	{
		print ("The toolbar was clicked");

		if (selectedToolbar == 0)
		{
			print ("First button was clicked");
		}
		else
		{
			print ("Second button was clicked");
		}
	}
}


// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
					
	private int selectedToolbar = 0;
	private string[] toolbarStrings = {"One", "Two"};
	
	void OnGUI () {
		// Determine which button is active, whether it was clicked this frame or not
		selectedToolbar = GUI.Toolbar (new Rect (50, 10, Screen.width - 100, 30), selectedToolbar, toolbarStrings);
	
		// If the user clicked a new Toolbar button this frame, we'll process their input
		if (GUI.changed)
		{
			Debug.Log("The toolbar was clicked");
	
			if (0 == selectedToolbar)
			{
				Debug.Log("First button was clicked");
			}
			else
			{
				Debug.Log("Second button was clicked");
			}
		}
	}

}

````

<span class=component>GUI.changed</span> will return true if any GUI Control placed before it was manipulated by the user.
