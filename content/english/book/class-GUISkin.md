GUI Skin
========


<span class=keyword>GUISkins</span> are a collection of <span class=keyword>GUIStyles</span> that can be applied to your GUI.  Each <span class=keyword>Control</span> type has its own Style definition.  Skins are intended to allow you to apply style to an entire UI, instead of a single Control by itself.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-GUISkin.png)  
_A GUI Skin as seen in the <span class=keyword>Inspector</span>_

To create a GUISkin, select <span class=menu>Assets->Create->GUI Skin</span> from the menubar.

GUISkins are part of the <span class=keyword>UnityGUI</span> system.  For more detailed information about UnityGUI, please take a look at the [GUI Scripting Guide](GUIScriptingGuide.md).


Properties
----------


All of the properties within a GUI Skin are an individual [GUIStyle](class-GUIStyle.md).  Please read the [GUIStyle](class-GUIStyle.md) page for more information about how to use Styles.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Font</span> |The global Font to use for every Control in the GUI |
|<span class=component>Box</span> |The [Style](class-GUIStyle.md) to use for all Boxes |
|<span class=component>Button</span> |The [Style](class-GUIStyle.md) to use for all Buttons |
|<span class=component>Toggle</span> |The [Style](class-GUIStyle.md) to use for all Toggles |
|<span class=component>Label</span> |The [Style](class-GUIStyle.md) to use for all Labels |
|<span class=component>Text Field</span> |The [Style](class-GUIStyle.md) to use for all Text Fields |
|<span class=component>Text Area</span> |The [Style](class-GUIStyle.md) to use for all Text Areas |
|<span class=component>Window</span> |The [Style](class-GUIStyle.md) to use for all Windows |
|<span class=component>Horizontal Slider</span> |The [Style](class-GUIStyle.md) to use for all Horizontal Slider bars |
|<span class=component>Horizontal Slider Thumb</span> |The [Style](class-GUIStyle.md) to use for all Horizontal Slider Thumb Buttons |
|<span class=component>Vertical Slider</span> |The [Style](class-GUIStyle.md) to use for all Vertical Slider bars |
|<span class=component>Vertical Slider Thumb</span> |The [Style](class-GUIStyle.md) to use for all Vertical Slider Thumb Buttons |
|<span class=component>Horizontal Scrollbar</span> |The [Style](class-GUIStyle.md) to use for all Horizontal Scrollbars |
|<span class=component>Horizontal Scrollbar Thumb</span> |The [Style](class-GUIStyle.md) to use for all Horizontal Scrollbar Thumb Buttons |
|<span class=component>Horizontal Scrollbar Left Button</span> |The [Style](class-GUIStyle.md) to use for all Horizontal Scrollbar scroll Left Buttons |
|<span class=component>Horizontal Scrollbar Right Button</span> |The [Style](class-GUIStyle.md) to use for all Horizontal Scrollbar scroll Right Buttons |
|<span class=component>Vertical Scrollbar</span> |The [Style](class-GUIStyle.md) to use for all Vertical Scrollbars |
|<span class=component>Vertical Scrollbar Thumb</span> |The [Style](class-GUIStyle.md) to use for all Vertical Scrollbar Thumb Buttons |
|<span class=component>Vertical Scrollbar Up Button</span> |The [Style](class-GUIStyle.md) to use for all Vertical Scrollbar scroll Up Buttons |
|<span class=component>Vertical Scrollbar Down Button</span> |The [Style](class-GUIStyle.md) to use for all Vertical Scrollbar scroll Down Buttons |
|<span class=component>Custom 1-20</span> |Additional custom Styles that can be applied to any Control |
|<span class=component>Custom Styles</span> |An array of additional custom Styles that can be applied to any Control |
|<span class=component>Settings</span> |Additional Settings for the entire GUI |
|>>><span class=component>Double Click Selects Word</span> |If enabled, double-clicking a word will select it |
|>>><span class=component>Triple Click Selects Line</span> |If enabled, triple-clicking a word will select the entire line |
|>>><span class=component>Cursor Color</span> |Color of the keyboard cursor |
|>>><span class=component>Cursor Flash Speed</span> |The speed at which the text cursor will flash when editing any Text Control |
|>>><span class=component>Selection Color</span> |Color of the selected area of Text |


Details
-------


When you are creating an entire GUI for your game, you will likely need to do a lot of customization for every different Control type.  In many different game genres, like real-time strategy or role-playing, there is a need for practically every single Control type.

Because each individual Control uses a particular Style, it does not make sense to create a dozen-plus individual Styles and assign them all manually.  GUI Skins take care of this problem for you.  By creating a GUI Skin, you have a pre-defined collection of Styles for every individual Control.  You then apply the Skin with a single line of code, which eliminates the need to manually specify the Style of each individual Control.


###Creating GUISkins

GUISkins are asset files.  To create a GUI Skin, select <span class=menu>Assets->Create->GUI Skin</span> from the menubar.  This will put a new GUISkin in your <span class=keyword>Project View</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/GUISkin-ProjectView.png)  
_A new GUISkin file in the Project View_


###Editing GUISkins

After you have created a GUISkin, you can edit all of the [Styles](class-GUIStyle.md) it contains in the Inspector.  For example, the <span class=component>Text Field</span> [Style](class-GUIStyle.md) will be applied to all Text Field Controls.


![](http://docwiki.hq.unity3d.com/uploads/Main/GUISkin-EditingTextField.png)  
_Editing the Text Field Style in a GUISkin_

No matter how many Text Fields you create in your script, they will all use this [Style](class-GUIStyle.md).  Of course, you have control over changing the styles of one Text Field over the other if you wish.  We'll discuss how that is done next.


###Applying GUISkins

To apply a GUISkin to your GUI, you must use a simple script to read and apply the Skin to your Controls.

````

// Create a public variable where we can assign the GUISkin
var customSkin : GUISkin;

// Apply the Skin in our OnGUI() function
function OnGUI () {
	GUI.skin = customSkin;

	// Now create any Controls you like, and they will be displayed with the custom Skin
	GUILayout.Button ("I am a re-Skinned Button");

	// You can change or remove the skin for some Controls but not others
	GUI.skin = null;

	// Any Controls created here will use the default Skin and not the custom Skin
	GUILayout.Button ("This Button uses the default UnityGUI Skin");
}

````

In some cases you want to have two of the same Control with different Styles.  For this, it does not make sense to create a new Skin and re-assign it.  Instead, you use one of the <span class=component>Custom</span> Styles in the skin.  Provide a <span class=component>Name</span> for the custom Style, and you can use that name as the last argument of the individual Control.

````

// One of the custom Styles in this Skin has the name "MyCustomControl"
var customSkin : GUISkin;

function OnGUI () {
	GUI.skin = customSkin;

	// We provide the name of the Style we want to use as the last argument of the Control function
	GUILayout.Button ("I am a custom styled Button", "MyCustomControl");

	// We can also ignore the Custom Style, and use the Skin's default Button Style
	GUILayout.Button ("I am the Skin's Button Style");
}

````

For more information about working with GUIStyles, please read the [GUIStyle](class-GUIStyle.md) page.  For more information about using UnityGUI, please read the [GUI Scripting Guide](GUIScriptingGuide.md).
