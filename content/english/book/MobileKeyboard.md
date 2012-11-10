Mobile Keyboard
===============

In most cases, Unity will handle keyboard input automatically for GUI elements but it is also easy to show the keyboard on demand from a script.


<a id="iOS"></a>

##ios Details
Using the Keyboard
------------------

###GUI Elements
The keyboard will appear automatically when a user taps on editable GUI elements. Currently, [GUI.TextField](ScriptRef:GUI.TextField.html), [GUI.TextArea](ScriptRef:GUI.TextArea.html) and [GUI.PasswordField](ScriptRef:GUI.PasswordField.html) will display the keyboard; see the  [GUI class](ScriptRef:GUI.html) documentation for further details.

###Manual Keyboard Handling
Use the <span class=component>iPhoneKeyboard.Open</span> function to open the keyboard. Please see the [iPhoneKeyboard](ScriptRef:iPhoneKeyboard.html) scripting reference for the parameters that this function takes.

Keyboard Type Summary
---------------------

The Keyboard supports the following types:

|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>iPhoneKeyboardType.Default</span> |Letters. Can be switched to keyboard with numbers and punctuation.|
|<span class=component>iPhoneKeyboardType.ASCIICapable</span> |Letters. Can be switched to keyboard with numbers and punctuation.|
|<span class=component>iPhoneKeyboardType.NumbersAndPunctuation</span> |Numbers and punctuation. Can be switched to keyboard with letters.|
|<span class=component>iPhoneKeyboardType.URL</span> |Letters with slash and .com buttons. Can be switched to keyboard with numbers and punctuation.|
|<span class=component>iPhoneKeyboardType.NumberPad</span> |Only numbers from 0 to 9.|
|<span class=component>iPhoneKeyboardType.PhonePad</span> |Keyboard used to enter phone numbers.|
|<span class=component>iPhoneKeyboardType.NamePhonePad</span> |Letters. Can be switched to phone keyboard.|
|<span class=component>iPhoneKeyboardType.EmailAddress</span> |Letters with @ sign. Can be switched to keyboard with numbers and punctuation.|

Text Preview
------------

By default, an edit box will be created and placed on top of the keyboard after it appears. This works as preview of the text that user is typing, so the text is always visible for the user. However, you can disable text preview by setting <span class=component>iPhoneKeyboard.hideInput</span> to true. Note that this works only for certain keyboard types and input modes. For example, it will not work for phone keypads and multi-line text input. In such cases, the edit box will always appear. <span class=component>iPhoneKeyboard.hideInput</span> is a global variable and will affect all keyboards.

Keyboard Orientation
--------------------

By default, the keyboard automatically follows the device orientation. To disable or enable rotation to a certain orientation, use the following properties available in [iPhoneKeyboard](ScriptRef:iPhoneKeyboard.html):

|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>autorotateToPortrait</span> |Enable or disable autorotation to portrait orientation (button at the bottom).|
|<span class=component>autorotateToPortraitUpsideDown</span> |Enable or disable autorotation to portrait orientation (button at top).|
|<span class=component>autorotateToLandscapeLeft</span> |Enable or disable autorotation to landscape left orientation (button on the right).|
|<span class=component>autorotateToLandscapeRight</span> |Enable or disable autorotation to landscape right orientation (button on the left).|

Visibility and Keyboard Size
----------------------------

There are three keyboard properties in [iPhoneKeyboard](ScriptRef:iPhoneKeyboard.html) that determine keyboard visibility status and size on the screen.

|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>visible</span> |Returns <span class=component>true</span> if the keyboard is fully visible on the screen and can be used to enter characters.|
|<span class=component>area</span> |Returns the position and dimensions of the keyboard.|
|<span class=component>active</span> |Returns <span class=component>true</span> if the keyboard is activated. This property is not static property. You must have a keyboard instance to use this property.|

Note that <span class=component>iPhoneKeyboard.area</span> will return a rect with position and size set to 0 until the keyboard is fully visible on the screen. You should not query this value immediately after <span class=component>iPhoneKeyboard.Open</span>. The sequence of keyboard events is as follows:

* <span class=component>iPhoneKeyboard.Open</span> is called. <span class=component>iPhoneKeyboard.active</span> returns true. <span class=component>iPhoneKeyboard.visible</span> returns false. <span class=component>iPhoneKeyboard.area</span> returns (0, 0, 0, 0).
* Keyboard slides out into the screen. All properties remain the same.
* Keyboard stops sliding. <span class=component>iPhoneKeyboard.active</span> returns true. <span class=component>iPhoneKeyboard.visible</span> returns true. <span class=component>iPhoneKeyboard.area</span> returns real position and size of the keyboard.

Secure Text Input
-----------------

It is possible to configure the keyboard to hide symbols when typing. This is useful when users are required to enter sensitive information (such as passwords). To manually open keyboard with secure text input enabled, use the following code:
````

iPhoneKeyboard.Open("", iPhoneKeyboardType.Default, false, false, true);

````


![](http://docwiki.hq.unity3d.com/uploads/Main/KeyboardSecure.png)  
_Hiding text while typing_

Alert keyboard
--------------

To display the keyboard with a black semi-transparent background instead of the classic opaque, call <span class=component>iPhoneKeyboard.Open</span> as follows:
````

iPhoneKeyboard.Open("", iPhoneKeyboardType.Default, false, false, true, true);

````


![](http://docwiki.hq.unity3d.com/uploads/Main/KeyboardClassic.png)  
_Classic keyboard_


![](http://docwiki.hq.unity3d.com/uploads/Main/KeyboardAlert.png)  
_Alert keyboard_


<a id="Android"></a>

###android Details
Unity Android reuses the iOS API to display system keyboard. Even though Unity Android supports most of the functionality of its iPhone counterpart, there are two aspects which are not supported:
* <span class=component>iPhoneKeyboard.hideInput</span>
* <span class=component>iPhoneKeyboard.area</span>

Please also note that the layout of a <span class=component>iPhoneKeyboardType</span> can differ somewhat between devices.
