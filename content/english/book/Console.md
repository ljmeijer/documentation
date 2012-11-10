Console
=======


Double-clicking an error in the Status Bar or choosing <span class=menu>Window->Console</span> will bring up the <span class=keyword>Console</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/Console-floating.png)  
_Console in the editor._

The Console shows messages, warnings, errors, or debug output from your game. You can define your own messages to be sent to the Console using <span class=menu>Debug.Log()</span>, <span class=menu>Debug.LogWarning</span>, or <span class=menu>Debug.LogError()</span>.  You can double-click any message to be taken to the script that caused the message.  You also have a number of options on the Console Toolbar.


![](http://docwiki.hq.unity3d.com/uploads/Main/Console-toolbar.png)  
_Console control toolbar helps your filter your debug output._

* Pressing <span class=menu>Clear</span> will remove all current messages from the Console.
* When <span class=menu>Collapse</span> is enabled, identical messages will only be shown once.
* When <span class=menu>Clear on play</span> is enabled, all messages will be removed from the Console every time you go into Play mode.
* When <span class=menu>Error Pause</span> is enabled, <span class=menu>Debug.LogError()</span> will cause the pause to occur but <span class=menu>Debug.Log()</span> will not.
* Pressing <span class=menu>Open Player Log</span> will open the Player Log in a text editor (or using the Console app on Mac if set as the default app for .log files).
* Pressing <span class=menu>Open Editor Log</span> will open the Editor Log in a text editor (or using the Console app on Mac if set as the default app for .log files).


