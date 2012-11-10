Trouble Shooting
================

This section addresses common problems that can arise when using Unity. Each platform is dealt with separately below.

<a id="DesktopTroubleShooting"></a>

##desktop Details
* This means that MonoDevelop was unable to find the Unity executable. In the MonoDevelop preferences, go to the Unity/Debugger section and then browse to where your Unity executable is located.

Is there a way to get rid of the welcome page in MonoDevelop?
-------------------------------------------------------------

* Yes. In the MonoDevelop preferences, go to the Visual Style section, and uncheck "Load welcome page on startup".

Geforce 7300GT on OSX 10.6.4
----------------------------

* Deferred rendering is disabled because materials are not displayed correctly for Geforce 7300GT on OX 10.6.4; This happens because of buggy video drivers.

On Windows x64, Unity crashes when my script throws a NullReferenceException
----------------------------------------------------------------------------

* Please apply [Windows Hotfix #976038](http://support.microsoft.com/kb/976038.md).

<a id="DesktopShadowTroubleShooting"></a>
Graphics
--------

###Slow framerate and/or visual artifacts.
* This may occur if your video card drivers are not up to date. Make sure you have the latest official drivers from your card vendor.




Shadows
-------


* Shadows are a <span class=keyword>Unity Pro</span> only feature, so without Unity Pro you won't get shadows. Simpler shadow methods, like using a [Projector](class-Projector.md), are still possible, of course.
* Shadows also require certain graphics hardware support. See [Shadows](Shadows.md) page for details.
* Check if shadows are not completely disabled in [Quality Settings](class-QualitySettings.md).
* __Shadows are currently not supported for Android and iOS mobile platforms.__

###Some of my objects do not cast or receive shadows

An object's [Renderer](class-MeshRenderer.md) must have <span class=component>Receive Shadows</span> enabled for shadows to be rendered onto it. Also, an object must have <span class=component>Cast Shadows</span> enabled in order to cast shadows on other objects (both are on by default).

Only opaque objects cast and receive shadows. This means that objects using the built-in [Transparent](shader-TransparentFamily.md) or Particle shaders will not cast shadows. In most cases it is possible to use [Transparent Cutout](shader-TransparentCutoutFamily.md) shaders for objects like fences, vegetation, etc. If you use custom written [Geometry render queue](Shaders]],theyhavetobepixel-litandusethe[[SL-SubshaderTags.md). Objects using <span class=component>VertexLit</span> shaders do not receive shadows but are able to cast them.

Only <span class=keyword>Pixel lights</span> cast shadows. If you want to make sure that a light always casts shadows no matter how many other lights are in the scene, then you can set it to <span class=component>Force Pixel</span> render mode (see the [Light](class-Light.md) reference page).


<a id="iPhoneTroubleShooting"></a>

####ios Details
Troubleshooting on iOS devices
==============================


There are some situations with iOS where your game can work perfectly in the Unity editor but then doesn't work or maybe doesn't even start on the actual device.
The problems are often related to code or content quality. This section describes the most common scenarios.

The game stops responding after a while. Xcode shows "interrupted" in the status bar.
-------------------------------------------------------------------------------------

There are a number of reasons why this may happen. Typical causes include:
1. Scripting errors such as using uninitialized variables, etc.
1. Using 3rd party Thumb compiled native libraries. Such libraries trigger a known problem in the iOS SDK linker and might cause random crashes.
1. Using generic types with value types as parameters (eg, List<int>, List<SomeStruct>, List<SomeEnum>, etc) for serializable script properties.
1. Using reflection when managed code stripping is enabled.
1. Errors in the native plugin interface (the managed code method signature does not match the native code function signature).
Information from the XCode Debugger console can often help detect these problems (Xcode menu: <span class=component>View > Debug Area > Activate Console</span>).

The Xcode console shows "Program received signal:  &#8220;SIGBUS&#8221; or EXC_BAD_ACCESS error.
------------------------------------------------------------------------------------------------

This message typically appears on iOS devices when your application receives a NullReferenceException. There two ways to figure out where the fault happened: 
####Managed stack traces
Since version 3.4 Unity includes software-based handling of the NullReferenceException. The AOT compiler includes quick checks for null references each time a method or variable is accessed on an object. This feature affects script performance which is why it is enabled only for development builds (for basic license users it is enough to enable the "development build" option in the Build Settings dialog, while iOS pro license users additionally need to enable the "script debugging" option).
If everything was done right and the fault actually is occurring in .NET code then you won't see EXC_BAD_ACCESS anymore. Instead, the .NET exception text will be printed in the Xcode console (or else your code will just handle it in a "catch" statement). Typical output might be:
````

Unhandled Exception: System.NullReferenceException: A null value was found where an object instance was required.
  at DayController+$handleTimeOfDay$121+$.MoveNext () [0x0035a] in DayController.js:122 

````

This indicates that the fault happened in the handleTimeOfDay method of the DayController class, which works as a coroutine. Also if it is script code then you will generally be told the exact line number (eg, "DayController.js:122"). The offending line might be something like the following:

````

 Instantiate(_imgwww.assetBundle.mainAsset);

````

This might happen if, say, the script accesses an asset bundle without first checking that it was downloaded correctly.

####Native stack traces
Native stack traces are a much more powerful tool for fault investigation but using them requires some expertise. Also, you generally can't continue after these native (hardware memory access) faults happen. To get a native stack trace, type <span class=component>bt all</span> into the Xcode Debugger Console. Carefully inspect the printed stack traces - they may contain hints about where the error occurred. You might see something like:
````

...
Thread 1 (thread 11523): 
#0 0x006267d0 in m_OptionsMenu_Start () 
#1 0x002e4160 in wrapper_runtime_invoke_object_runtime_invoke_void__this___object_intptr_intptr_intptr () 
#2 0x00a1dd64 in mono_jit_runtime_invoke (method=0x18b63bc, obj=0x5d10cb0, params=0x0, exc=0x2fffdd34) at /Users/mantasp/work/unity/unity-mono/External/Mono/mono/mono/mini/mini.c:4487
#3 0x0088481c in MonoBehaviour::InvokeMethodOrCoroutineChecked ()
...

````
First of all you should find the stack trace for __"Thread 1"__, which is the main thread. The very first lines of the stack trace will point to the place where the error occurred. In this example, the trace indicates that the NullReferenceException happened inside the _"OptionsMenu"_ script's _"Start"_ method. Looking carefully at this method implementation would reveal the cause of the problem. Typically, NullReferenceExceptions happen inside the <span class=component>Start</span> method when incorrect assumptions are made about initialization order.
In some cases only a partial stack trace is seen on the Debugger Console:
````

Thread 1 (thread 11523): 
#0 0x0062564c in start ()

````
This indicates that native symbols were stripped during the Release build of the application. The full stack trace can be obtained with the following procedure:
* Remove application from device.
* Clean all targets.
* Build and run.
* Get stack traces again as described above.

EXC_BAD_ACCESS starts occurring when an external library is linked to the Unity iOS application.
------------------------------------------------------------------------------------------------

This usually happens when an external library is compiled with the ARM Thumb instruction set. Currently such libraries are not compatible with Unity. The problem can be solved easily by recompiling the library without Thumb instructions. You can do this for the library's Xcode project with the following steps:
* in Xcode, select _"View"_ > _"Navigators"_ > _"Show Project Navigator"_ from the menu
* select the _"Unity-iPhone"_ project, activate _"Build Settings"_ tab
* in the search field enter : _"Other C Flags"_
* add _-mno-thumb_ flag there and rebuild the library.

If the library source is not available you should ask the supplier for a non-thumb version of the library.

The Xcode console shows "WARNING -> applicationDidReceiveMemoryWarning()" and the application crashes immediately afterwards
----------------------------------------------------------------------------------------------------------------------------

(Sometimes you might see a message like _Program received signal:  “0”_.)
This warning message is often not fatal and merely indicates that iOS is low on memory and is asking applications to free up some memory. Typically, background processes like Mail will free some memory and your application can continue to run. However, if your application continues to use memory or ask for more, the OS will eventually start killing applications and yours could be one of them. Apple does not document what memory usage is safe, but empirical observations show that applications using less than 50% MB of all device RAM (like ~200-256 MB for 2nd generation ipad) do not have major memory usage problems.
The main metric you should rely on is how much RAM your application uses. Your application memory usage consists of three major components:
* application code (the OS needs to load and keep your application code in RAM, but some of it might be discarded if really needed)
* native heap (used by the engine to store its state, your assets, etc. in RAM)
* managed heap (used by your Mono runtime to keep C# or JavaScript objects)
* GLES driver memory pools: textures, framebuffers, compiled shaders, etc.
Your application memory usage can be tracked by two Xcode Instruments tools: <span class=component>Activity Monitor</span>, <span class=component>Object Allocations</span> and <span class=component>VM Tracker</span>. You can start from the Xcode Run menu: <span class=component>Product > Profile</span> and then select specific tool. <span class=component>Activity Monitor</span> tool shows all process statistics including <span class=component>Real memory</span> which can be regarded as the total amount of RAM used by your application. 


![](http://docwiki.hq.unity3d.com/uploads/Main/ActivityMonitor.png)  

__Note:__ The [internal profiler](iphone-InternalProfiler.md) shows only the heap allocated by .NET scripts. Total memory usage can be determined via Xcode Instruments as shown above. This figure includes parts of the application binary, some standard framework buffers, Unity engine internal state buffers, the .NET runtime heap (number printed by internal profiler), GLES driver heap and some other miscellaneous stuff.  


The other tool displays all allocations made by your application and includes both native heap and managed heap statistics (don't forget to check the <span class=component>Created and still living</span> box to get the current state of the application). The important statistic is the <span class=component>Net bytes</span> value.


![](http://docwiki.hq.unity3d.com/uploads/Main/ObjectAlloc.png)  

To keep memory usage low:
* Reduce the application binary size by using the strongest iOS stripping options (Advanced license feature), and avoid unnecessary dependencies on different .NET libraries. See the [player settings](Main.class-PlayerSettings.md) and [player size optimization](Main.iphone-playerSizeOptimization.md) manual pages for further details.
* Reduce the size of your content. Use PVRTC compression for textures and use low poly models. See the manual page about [reducing file size](Main.ReducingFilesize.md) for more information.
* Don't allocate more memory than necessary in your scripts. Track mono heap size and usage with the [internal profiler](Main.iphone-InternalProfiler.md)
* __Note:__ with Unity 3.0, the scene loading implementation has changed significantly and now all scene assets are preloaded. This results in fewer hiccups when instantiating game objects. If you need more fine-grained control of asset loading and unloading during gameplay, you should use [Resources.Load](ScriptRef:Resources.Load.html) and [Object.Destroy](ScriptRef:Object.Destroy.html).

Querying the OS about the amount of free memory may seem like a good idea to evaluate how well your application is performing. However, the free memory statistic is likely to be unreliable since the OS uses a lot of dynamic buffers and caches. The only reliable approach is to keep track of memory consumption for your application and use that as the main metric. Pay attention to how the graphs from the tools described above change over time, especially after loading new levels.

The game runs correctly when launched from Xcode but crashes while loading the first level when launched manually on the device.
--------------------------------------------------------------------------------------------------------------------------------

There could be several reasons for this. You need to inspect the device logs to get more details. Connect the device to your Mac, launch Xcode and select <span class=component>Window > Organizer</span> from the menu. Select your device in the Organizer's left toolbar, then click on the "Console" tab and review the latest messages carefully. Additionally, you may need to investigate crash reports. You can find out how to obtain crash reports here: [http://developer.apple.com/iphone/library/technotes/tn2008/tn2151.html](http://developer.apple.com/iphone/library/technotes/tn2008/tn2151.html.md).

The Xcode Organizer console contains the message "killed by SpringBoard".
-------------------------------------------------------------------------

There is a poorly-documented time limit for an iOS application to render its first frames and process input. If your application exceeds this limit, it will be killed by SpringBoard. This may happen in an application with a first scene which is too large, for example. To avoid this problem, it is advisable to create a small initial scene which just displays a splash screen, waits a frame or two with <span class=keyword>yield</span> and then starts loading the real scene. This can be done with code as simple as the following:
````
 
function Start () {
    yield;
    Application.LoadLevel("Test");
}

````

Type.GetProperty() / Type.GetValue() cause crashes on the device
----------------------------------------------------------------

Currently <span class=component>Type.GetProperty()</span> and <span class=component>Type.GetValue()</span> are supported only for the <span class=component>.NET 2.0 Subset</span> profile. You can select the .NET API compatibility level in the [Player Settings](class-PlayerSettings.md). 

__Note:__ <span class=component>Type.GetProperty()</span> and <span class=component>Type.GetValue()</span> might be incompatible with managed code stripping and might need to be excluded (you can supply a custom non-strippable type list during the stripping process to accomplish this). For further details, see the [iOS player size optimization guide](iphone-playerSizeOptimization.md).

The game crashes with the error message "ExecutionEngineException: Attempting to JIT compile method 'SometType`1<SomeValueType>:.ctor ()' while running with --aot-only."
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

The Mono .NET implementation for iOS is based on AOT (ahead of time compilation to native code) technology, which has its limitations. It compiles only those generic type methods (where a value type is used as a generic parameter) which are explicitly used by other code. When such methods are used only via reflection or from native code (ie, the serialization system) then they get skipped during AOT compilation. The AOT compiler can be hinted to include code by adding a dummy method somewhere in the script code. This can refer to the missing methods and so get them compiled ahead of time.
````

void _unusedMethod()
{
    var tmp = new SomeType<SomeValueType>();
}

````
__Note:__ value types are basic types, enums and structs.

Various crashes occur on the device when a combination of System.Security.Cryptography and managed code stripping is used
-------------------------------------------------------------------------------------------------------------------------

.NET Cryptography services rely heavily on reflection and so are not compatible with managed code stripping since this involves static code analysis. Sometimes the easiest solution to the crashes is to exclude the whole <span class=component>System.Security.Crypography</span> namespace from the stripping process.

The stripping process can be customized by adding a custom <span class=component>link.xml</span> file to the <span class=component>Assets</span> folder of your Unity project. This specifies which types and namespaces should be excluded from stripping. Further details can be found in the [iOS player size optimization guide](iphone-playerSizeOptimization.md).

###link.xml
````

<linker>
       <assembly fullname="mscorlib">
               <namespace fullname="System.Security.Cryptography" preserve="all"/>
       </assembly>
</linker>


````

"Ran out of trampolines of type 1/2" runtime error
--------------------------------------------------

This error usually happens if you use lots of recursive generics. You can hint to the AOT compiler to allocate more trampolines of type 1 or type 2. Additional AOT compiler command line options can be specified in the "Other Settings" section of the [Player Settings](Main.class-PlayerSettings#iOS.md). For type 1 trampolines, specify <span class=component>nrgctx-trampolines=ABCD</span>, where ABCD is the number of new trampolines required (i.e. 4096). For type 2 trampolines specify <span class=component>nimt-trampolines=ABCD</span>.

After upgrading Xcode Unity iOS runtime fails with message "You are using Unity iPhone Basic. You are not allowed to remove the Unity splash screen from your game"
-------------------------------------------------------------------------------------------------------------------------------------------------------------------

With some latest Xcode releases there were changes introduced in PNG compression and optimization tool. These changes might cause false positives in Unity iOS runtime checks for splash screen modifications. If you encounter such problems try upgrading Unity to the latest publicly available version. If it does not help you might consider following workaround:
* Open your Xcode project
* Select "Unity-iPhone" project there
* Select "Build Settings" tab there
* Look for "Compress PNG files" option and set it to NO

App Store submission fails with "iPhone/iPod Touch: application executable is missing a required architecture. At least one of the following architecture(s) must be present: armv6" message
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

You might get such message when updating already existing application, which previously was submitted with armv6 support. Unity 4.x and Xcode 4.5 does not support armv6 platform anymore. To solve submission problem just set <span class=component>Target OS Version</span> in Unity <span class=component>Player Settings</span> to <span class=component>4.3</span> or higher.

"PlayerLoop called recursively!" error occurs when using Cocoa via a native function called from a script
---------------------------------------------------------------------------------------------------------

Some operations with the UI will result in iOS redrawing the window immediately (the most common example is adding a UIView with a UIViewController to the main UIWindow). If you call a native function from a script, it will happen inside Unity's PlayerLoop, resulting in PlayerLoop being called recursively. In such cases, you should consider using the [performSelectorOnMainThread](http://developer.apple.com/library/mac/#documentation/Cocoa/Reference/Foundation/Classes/NSObject_Class/Reference/Reference.html#//apple_ref/occ/instm/NSObject/performSelectorOnMainThread:withObject:waitUntilDone:.md) method with waitUntilDone set to false. It will inform iOS to schedule the operation to run between Unity's PlayerLoop calls.

Profiler or Debugger unable to see game running on iOS device
-------------------------------------------------------------

* Check that you have built a Development build, and ticked the "Enable Script Debugging" and "Autoconnect profiler" boxes (as appropriate).
* The application running on the device will make a multicast broadcast to 225.0.0.222 on UDP port 54997.  Check that your network settings allow this traffic.  Then, the profiler will make a connection to the remote device on a port in the range 55000 - 55511 to fetch profiler data from the device.  These ports will need to be open for UDP access.

Missing DLLs
------------

If your application runs ok in editor but you get errors in your iOS project this may be caused by missing DLLs (e.g. I18N.dll, I19N.West.dll). In this case, try copying those dlls from within the Unity.app to your project's Assets/Plugins folder. The location of the DLLs within the unity app is:
 Unity.app/Contents/Frameworks/Mono/lib/mono/unity 
You should then also check the stripping level of your project to ensure the classes in the DLLs aren't being removed when the build is optimised. Refer to the [iOS Optimisation Page ](iphone-playerSizeOptimization.md) for more information on iOS Stripping Levels.

Xcode Debugger console reports: ExecutionEngineException: Attempting to JIT compile method '(wrapper native-to-managed) Test:TestFunc (int)' while running with --aot-only
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Typically such message is received when managed function delegate is passed to the native function, but required wrapper code wasn't generated when building application. You can help AOT compiler by hinting which methods will be passed as delegates to the native code. This can be done by adding "MonoPInvokeCallbackAttribute" custom attribute. Currently only static methods can be passed as delegates to the native code.

Sample code:
````

using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using AOT;

public class NewBehaviourScript : MonoBehaviour {

	[DllImport ("__Internal")]
	private static extern void DoSomething (NoParamDelegate del1, StringParamDelegate del2);

	delegate void NoParamDelegate ();
	delegate void StringParamDelegate (string str);
	
	[MonoPInvokeCallback (typeof (NoParamDelegate))]
	public static void NoParamCallback()
	{
		Debug.Log ("Hello from NoParamCallback");
	}
	
	[MonoPInvokeCallback (typeof (StringParamDelegate))]
	public static void StringParamCallback(string str)
	{
		Debug.Log (string.Format ("Hello from StringParamCallback {0}", str));
	}

	// Use this for initialization
	void Start () {
		DoSomething(NoParamCallback, StringParamCallback);
	}
}

````

<a id="AndroidTroubleShooting"></a>

###android Details
Troubleshooting Android development
===================================

Unity fails to install your application to your device
------------------------------------------------------

1. Verify that your computer can actually see and communicate with the device. See the [Publishing Builds](Main.PublishingBuilds.md) page for further details.
1. Check the error message in the Unity console. This will often help diagnose the problem.

If you get an error saying "Unable to install APK, protocol failure" during a build then this indicates that the device is connected to a low-power USB port (perhaps a port on a keyboard or other peripheral). If this happens, try connecting the device to a USB port on the computer itself.

Your application crashes immediately after launch.
--------------------------------------------------

1. Ensure that you are not trying to use [NativeActivity](Main.class-PlayerSettings#Android.md) with devices that do not support it.
1. Try removing any native plugins you have.
1. Try disabling stripping.
1. Use <span class=keyword>adb logcat</span> to get the crash report from your device.

Building DEX Failed
-------------------

This an error which will produce a message like the following:-
````

Building DEX Failed!
G:\Unity\JavaPluginSample\Temp/StagingArea> java -Xmx1024M 
-Djava.ext.dirs="G:/AndroidSDK/android-sdk_r09-windows\platform-tools/lib/" 
-jar "G:/AndroidSDK/android-sdk_r09-windows\platform-tools/lib/dx.jar" 
--dex --verbose --output=bin/classes.dex bin/classes.jar plugins
Error occurred during initialization of VM
Could not reserve enough space for object heap
Could not create the Java virtual machine.

````

This is usually caused by having the wrong version of Java installed on your machine. Updating your Java installation to the latest version will generally solve this issue.

The game crashes after a couple of seconds when playing video
-------------------------------------------------------------

Make sure `Settings->Developer Options->Don't keep activities` isn't enabled on the phone. The video player is its own activity and therefore the regular game activity will be destroyed if the video player is activated.

My game quits when I press the sleep button
-------------------------------------------

Change the `<activity>` tag in the `AndroidManifest.xml` to contain `<android:configChanges>` tag as described [here](http://developer.android.com/guide/topics/manifest/activity-element.html#config.md).

An example activity tag might look something like this:-

````

<activity android:name=".AdMobTestActivity"
                  android:label="@string/app_name"
                  android:configChanges="fontScale|keyboard|keyboardHidden|locale|mnc|mcc|navigation|orientation|screenLayout|screenSize|smallestScreenSize|uiMode|touchscreen">
            <intent-filter>
                <action android:name="android.intent.action.MAIN" />
                <category android:name="android.intent.category.LAUNCHER" />
            </intent-filter>
        </activity>

````

