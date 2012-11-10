Log Files
=========


There might be times during the development when you need to obtain information from the logs of the webplayer you've built, your standalone player, the target device or the editor. Usually you need to see these files when you have experienced a problem and you have to know where exactly the problem occurred.

On Mac the webplayer, player and editor logs can be accessed uniformly through the standard <span class=menu>Console.app</span> utility.

On Windows the webplayer and editor logs are place in folders there are not shown in the Windows Explorer by default. Please see the [Accessing hidden folders](AccessingHiddenFolders.md) page to resolve that situation.

Editor
------

Editor log can be brought up through the <span class=menu>Open Editor Log</span> button in Unity's Console window.


|    |    |
|:---|:---|
|<span class=component>Mac OS X</span>            |~/Library/Logs/Unity/Editor.log|
|<span class=component>Windows XP</span> *        |_C:\Documents and Settings\username\Local Settings\Application Data_\Unity\Editor\Editor.log|
|<span class=component>Windows Vista/7</span> *   |_C:\Users\username\AppData\Local_\Unity\Editor\Editor.log|

(*) On Windows the Editor log file is stored in the local application data folder: _&#37;LOCALAPPDATA&#37;_\Unity\Editor\Editor.log, where _LOCALAPPDATA_ is defined by [CSIDL_LOCAL_APPDATA](http://msdn.microsoft.com/en-us/library/bb762494&#40;VS.85&#41;.aspx.md).


###desktop Details

On Mac all the logs can be accessed uniformly through the standard <span class=menu>Console.app</span> utility.

Webplayer
---------


|    |    |
|:---|:---|
|<span class=component>Mac OS X</span>                        |~/Library/Logs/Unity/WebPlayer.log|
|<span class=component>Windows XP</span> *                    |_C:\Documents and Settings\username\Local Settings\Temp_\UnityWebPlayer\log\log_UNIQUEID.txt|
|<span class=component>Windows  Vista/7</span> *              |_C:\Users\username\AppData\Local\Temp_\UnityWebPlayer\log\log_UNIQUEID.txt|
|<span class=component>Windows Vista/7 + IE7 + UAC</span> *   |_C:\Users\username\AppData\Local\Temp\__Low___\UnityWebPlayer\log\log_UNIQUEID.txt|

(*) On Windows the webplayer log is stored in a temporary folder:  _&#37;TEMP&#37;_\UnityWebPlayer\log\log_UNIQUEID.txt, where _TEMP_ is defined by [GetTempPath](http://msdn.microsoft.com/en-us/library/aa364992&#40;VS.85&#41;.aspx.md).

Player
------


|    |    |
|:---|:---|
|<span class=component>Mac OS X</span>      |~/Library/Logs/Unity/Player.log|
|<span class=component>Windows </span> *    |_EXECNAME_Data_\output_log.txt|

(*) _EXECNAME_Data_ is a folder next to the executable with your game.

Note that on Windows standalones the location of the log file can be changed (or logging suppressed.)  See the [command line](CommandLineArguments.md) page for further details.


###ios Details
The device log can be accessed in XCode via GDB console or the Organizer Console. The latter is useful for getting crashlogs when your application was not running through the XCode debugger.

Please see [Debugging Applications](http://developer.apple.com/library/ios/#documentation/Xcode/Conceptual/iphone_development/130-Debugging_Applications/debugging_applications.html.md) in the iOS Development Guide. Also our [Troubleshooting](TroubleShooting#iPhoneTroubleShooting.md) and [Bugreporting](iphone-bugreporting.md) guides may be useful for you.


###android Details
The device log can be viewed by using the [logcat console](http://developer.android.com/guide/developing/tools/adb.html#logcat.md). Use the <span class=component>adb</span> application found in <span class=component>Android SDK/platform-tools directory</span> with a trailing <span class=component>logcat</span> parameter:

`$ adb logcat`

Another way to inspect the LogCat is to use the [Dalvik Debug Monitor Server (DDMS)](http://developer.android.com/guide/developing/debugging/ddms.html.md). DDMS can be started either from <span class=component>Eclipse</span> or from inside the <span class=component>Android SDK/tools</span>. DDMS also provides a number of other debug related tools.
