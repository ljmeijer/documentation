Android SDK Setup
=================

There are some steps you must follow before you can build and run any code on your Android device.  This is true regardless of whether you use Unity or write Android applications from scratch.

1. Download the Android SDK
---------------------------

Go to the [Android Developer SDK webpage](http://developer.android.com/sdk.md). Download and unpack the latest Android SDK. 

2. Installing the Android SDK
-----------------------------

Follow the instructions under [Installing the SDK](http://developer.android.com/sdk/installing.html.md) (although you can freely skip the optional parts relating to Eclipse).
In step 4 of _Installing the SDK_ be sure to add at least one _'Android platform_' with API level equal to or higher than 9 (Platform 2.3 or greater), the _'Platform Tools_', and the _'USB drivers_' if you're using Windows.

3. Get the device recognized by your system
-------------------------------------------

This can be tricky, especially under Windows based systems where drivers tend to be a problem. Also, your device may come with additional information or specific drivers from the manufacturer.
* For _'Windows_': If the Android device is automatically recognized by the system you still might need to update the drivers with the ones that came with the Android SDK. This is done through the Windows Device Manager.
--->If the device is not recognized automatically use the drivers from the Android SDK, or any specific drivers provided by the manufacturer.
--->Additional info can be found here: [USB Drivers for Windows](http://developer.android.com/sdk/win-usb.html.md)
* For _'Mac_': If you're developing on Mac OSX then no additional drivers are usually required.

__Note:__ Don't forget to turn on "USB Debugging" on your device. You can do this from the home screen: press MENU, select Applications > Development, then enable USB debugging.

If you are unsure whether your device is properly installed on your system, please read the [trouble-shooting page](TroubleShooting#AndroidTroubleShooting.md) for details.

4. Add the Android SDK path to Unity
------------------------------------

The first time you build a project for Android (or if Unity later fails to locate the SDK) you will be asked to locate the folder where you installed the Android SDK (you should select the root folder of the SDK installation). The location of the Android SDK can also be changed in the editor by selecting Unity > Preferences from the menu and then clicking on External Tools in the preferences window.

