GUI Scripting Guide
===================



Overview
--------


UnityGUI allows you to create a wide variety of highly functional GUIs very quickly and easily.  Rather than creating a GUI object, manually positioning it, and then writing a script that handles its functionality, you can do everything at once with just a few lines of code.  The code produces <span class=keyword>GUI controls</span> that are instantiated, positioned and handled with a single function call.

For example, the following code will create and handle a button with no additional work in the editor or elsewhere:-

````

// JavaScript
function OnGUI () {
	if (GUI.Button (Rect (10,10,150,100), "I am a button")) {
		print ("You clicked the button!");
	}
}


// C#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
			
	void OnGUI () {
		if (GUI.Button (new Rect (10,10,150,100), "I am a button")) {
			print ("You clicked the button!");
		}
	}
}

````


![](http://docwiki.hq.unity3d.com/uploads/Main/guiScripting-simpleButton.png)  
_This is the button created by the code above_

Although this example is very simple, there are very powerful and complex techniques available for use in UnityGUI.  GUI construction is a broad subject but the following sections should help you get up to speed as quickly as possible.  This guide can be read straight through or used as reference material.


[UnityGUI Basics](gui-Basics.md)
--------------------------------


This section covers the fundamental concepts of UnityGUI, giving you an overview as well as a set of working examples you can paste into your own code. UnityGUI is very friendly to play with, so this is a good place to get started.


[Controls](gui-Controls.md)
---------------------------


This section lists every available Control in UnityGUI, along with code samples and images showing the results.


[Customization](gui-Customization.md)
-------------------------------------


It is important to be able to change the appearance of the GUI to match the look of your game.  All controls in UnityGUI can be customized with <span class=keyword>GUIStyles</span> and <span class=keyword>GUISkins</span>, as explained in this section.


[Layout Modes](gui-Layout.md)
-----------------------------


UnityGUI offers two ways to arrange your GUIs: you can manually place each control on the screen, or you can use an automatic layout system which works in a similar way to HTML tables.  Either system can be used as desired and the two can be freely mixed.  This section explains the functional differences between the two systems, including examples.


[Extending UnityGUI](gui-Extending.md)
--------------------------------------


UnityGUI is very easy to extend with new Control types. This chapter shows you how to make simple _compound_ controls - complete with integration into Unity's event system.


[Extending Unity Editor](gui-ExtendingEditor.md)
------------------------------------------------


The GUI of the Unity editor is actually written using UnityGUI. Consequently, the editor is highly extensible using the same type of code you would use for in-game GUI. In addition, there are a number of Editor-specific GUI controls to help you create custom editor GUI.

