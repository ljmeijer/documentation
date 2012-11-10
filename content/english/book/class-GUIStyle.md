GUI Style
=========


<span class=keyword>GUI Styles</span> are a collection of custom attributes for use with <span class=keyword>UnityGUI</span>.  A single GUI Style defines the appearance of a single UnityGUI <span class=keyword>Control</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/GuiStyleInspector.png)  
_A GUI Style in the <span class=keyword>Inspector</span>_

If you want to add style to more than one control, use a [GUI Skin](class-GUISkin.md) instead of a GUI Style.  For more information about UnityGUI, please read the [GUI Scripting Guide](GUIScriptingGuide.md).


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Name</span> |The text string that can be used to refer to this specific Style |
|<span class=component>Normal</span> |Background image & Text Color of the Control in default state |
|<span class=component>Hover</span> |Background image & Text Color when the mouse is positioned over the Control |
|<span class=component>Active</span> |Background image & Text Color when the mouse is actively clicking the Control |
|<span class=component>Focused</span> |Background image & Text Color when the Control has keyboard focus |
|<span class=component>On Normal</span> |Background image & Text Color of the Control in enabled state |
|<span class=component>On Hover</span> |Background image & Text Color when the mouse is positioned over the enabled Control |
|<span class=component>On Active</span> |Properties when the mouse is actively clicking the enabled Control |
|<span class=component>On Focused</span> |Background image & Text Color when the enabled Control has keyboard focus |
|<span class=component>Border</span> |Number of pixels on each side of the <span class=component>Background</span> image that are not affected by the scale of the Control' shape |
|<span class=component>Padding</span> |Space in pixels from each edge of the Control to the start of its contents. |
|<span class=component>Margin</span> |The margins between elements rendered in this style and any other GUI Controls. |
|<span class=component>Overflow</span> |Extra space to be added to the background image. |
|<span class=component>Font</span> |The Font used for all text in this style |
|<span class=component>Image Position</span> |The way the background image and text are combined. |
|<span class=component>Alignment</span> |Standard text alignment options. |
|<span class=component>Word Wrap</span> |If enabled, text that reaches the boundaries of the Control will wrap around to the next line |
|<span class=component>Text Clipping</span> |If <span class=component>Word Wrap</span> is enabled, choose how to handle text that exceeds the boundaries of the Control |
|>>><span class=component>Overflow</span> |Any text that exceeds the Control boundaries will continue beyond the boundaries |
|>>><span class=component>Clip</span> |Any text that exceeds the Control boundaries will be hidden |
|<span class=component>Content Offset</span> |Number of pixels along X and Y axes that the Content will be displaced in addition to all other properties |
|>>><span class=component>X</span> |Left/Right Offset |
|>>><span class=component>Y</span> |Up/Down Offset |
|<span class=component>Fixed Width</span> |Number of pixels for the width of the Control, which will override any provided <span class=component>Rect()</span> value |
|<span class=component>Fixed Height</span> |Number of pixels for the height of the Control, which will override any provided <span class=component>Rect()</span> value |
|<span class=component>Stretch Width</span> |If enabled, Controls using this style can be stretched horizontally for a better layout. |
|<span class=component>Stretch Height</span> |If enabled, Controls using this style can be stretched vertically for a better layout. |


Details
-------


GUIStyles are declared from scripts and modified on a per-instance basis.  If you want to use a single or few Controls with a custom Style, you can declare this custom Style in the script and provide the Style as an argument of the Control function.  This will make these Controls appear with the Style that you define.

First, you must declare a GUI Style from within a script.

````

/* Declare a GUI Style */
var customGuiStyle : GUIStyle;

...

````

When you attach this script to a GameObject, you will see the custom Style available to modify in the <span class=keyword>Inspector</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/ModifyingStyleInInspector.png)  
_A Style declared in a script can be modified in each instance of the script_

Now, when you want to tell a particular Control to use this Style, you provide the name of the Style as the last argument in the Control function.

````

...

function OnGUI () {
	// Provide the name of the Style as the final argument to use it
	GUILayout.Button ("I am a custom-styled Button", customGuiStyle);

	// If you do not want to apply the Style, do not provide the name
	GUILayout.Button ("I am a normal UnityGUI Button without custom style");
}

````


![](http://docwiki.hq.unity3d.com/uploads/Main/guiStyle-TwoButtonsOneIsStyled.png)  
_Two Buttons, one with Style, as created by the code example_

For more information about using UnityGUI, please read the [GUI Scripting Guide](GUIScriptingGuide.md).
