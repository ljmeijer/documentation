Crashes
=======


Checklist for crashes
---------------------


* Disable code stripping (and set “slow with exceptions” for iOS)
* Follow the instructions on Optimizing the Size of the Built iOS Player (http://docs.unity3d.com/Documentation/Manual/iphone-playerSizeOptimization.html) to make sure your game does not crash with stripping on iOS.
* Verify it is not because of out of memory (restart your device, use the device with maximum RAM for the platform, be sure to watch the logs)

Editor.log - on the editor
--------------------------


The Debug messages, warnings and errors all go to the console.  Also Unity prints status reports to the console – loading assets, initializing mono, graphics driver info.

If you are trying to understand what is going on look at the editor.log.  Here you will get the full picture, not just a console fragment. You can try to understand what’s happening, and watch the full log of your coding session. This will help you track down what has caused Unity crash to crash or find out what’s wrong with your assets.

Unity prints some tjings on the devices as well; Logcat console for android and Xcode gdb console on iOS devices


###android Details
Debugging on Android
--------------------


1. Use the _DDMS_ or _ADB_ tool
1. Watch the stacktrace (Android 3 or newer). Either use _c++filt_ (part of the _ndk_) or the other methods, like: http://slush.warosu.org/c++filtjs to decode the mangled function calls
1. Look at the _.so_ file that the crash occurs on:
    1. _libunity.so_ - the crash is in the Unity code or the user code
    1. _libdvm.so_ - the crash is in the Java world, somewhere with Dalvik. So find Dalvik’s stacktrace, look at your JNI code or anything Java-related (including your possible changes to the _AndroidManifest.xml_).
    1. _libmono.so_ - either a Mono bug or you're doing something Mono strongly dislikes
1. If the crashlog does not help you can disassemble it to get a rough understanding of what has happened.
    1. use ARM EABI tools from the Android NDK like this: _objdump.exe -S libmono.so >> out.txt_
    1. Look at the code around pc from the stacktrace.
    1. try to match that code within the fresh _out.txt_ file.
    1. Scroll up to understand what is happening in the function it occurs in.



###ios Details
Debugging on iOS
----------------


1. Xcode has built in tools.  Xcode 4 has a really nice GUI for debugging crashes, Xcode 3 has less.
1. Full gdb stack - thread apply all bt
1. Enable soft-null-check:
Enable development build and script debugging. Now uncaught null ref exceptions will be printed to the Xcode console with the appropriate managed call stack.
1. Try turning the "fast script call" and code stripping off. It may stop some random crashes, like those caused by using some rare _.Net_ functions or reflection.


Strategy
--------


1. Try to figure out which script the crash happens in and debug it using mono develop on the device.
1. If the crash seems to not be in your code, take a closer look at the stacktrace, there should be a hint of something happening. Take a copy and submit it, and we’ll take a look.

