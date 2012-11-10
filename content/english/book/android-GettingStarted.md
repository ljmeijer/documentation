Getting Started with Android Development
========================================


Building games for a device running Android OS requires an approach similar to that for iOS development.  However, the hardware is not completely standardized across all devices, and this raises issues that don't occur in iOS development.  There are some feature differences in the Android version of Unity just as there are with the iOS version.

Setting up your Android Developer environment
---------------------------------------------

You will need to have your Android developer environment set up before you can test your Unity games on the device.  This involves downloading and installing the Android SDK with the different Android plaforms and adding your physical device to your system (this is done a bit differently depending on whether you are developing on Windows or Mac).  This setup process is explained on the Android developer website, and there may be additional information provided by the manufacturer of your device.  Since this is a complex process, we've provided a [basic outline](android-sdksetup.md) of the tasks that must be completed before you can run code on your Android device or in the Android emulator.  However, the best thing to do is follow the instructions step-by-step from the [Android developer portal](http://developer.android.com/sdk.md).

Access Android Functionality
----------------------------

Unity Android provides scripting APIs to access various input data and settings. You can find out more about the available classes on the [Android scripting page](Main.android-API.md).

Exposing Native C, C++ or Java Code to Scripts
----------------------------------------------

Unity Android allows you to call custom functions written in C/C++ directly from C# scripts (Java functions can be called indirectly). To find out how to make functions from native code accessible from Unity, visit the [plugins page](Main.Plugins#AndroidPlugins.md).

Occlusion Culling
-----------------

Unity includes support for occlusion culling which is a particularly valuable optimization on mobile platforms. More information can be found on the [occlusion culling](OcclusionCulling.md) page.

Splash Screen Customization
---------------------------

The splash screen displayed while the game launches can be customized - see [this page](MobileCustomizeSplashScreen#Android.md) for further details.

Troubleshooting and Bug Reports
-------------------------------

There are many reasons why your application may crash or fail to work as you expected. Our [Android troubleshooting guide](TroubleShooting#AndroidTroubleShooting.md) will help you get to the bottom of bugs as quickly as possible. If, after consulting the guide, you suspect the problem is internal to Unity then you should file a bug report - see [this page](android-bugreporting.md) for details on how to do this.

How Unity Android Differs from Desktop Unity
--------------------------------------------

###Strongly Typed JavaScript
For performance reasons, dynamic typing in JavaScript is always turned off in Unity Android, as if #pragma strict were applied automatically to all scripts. This is important to know if you start with a project originally developed for the desktop platforms since you may find you get unexpected compile errors when switching to Android; dynamic typing is the first thing to investigate. These errors are usually easy to fix if you make sure all variables are explicitly typed or use type inference on initialization.


###ETC as Recommended Texture Compression
Although Unity Android does support DXT/PVRTC/ATC textures, Unity will decompress the textures into RGB(A) format at runtime if those compression methods are not supported by the particular device in use. This could have an impact on the GPU rendering speed and it is recommended to use the ETC format instead. ETC is the de facto standard compression format on Android, and should be supported on all post 2.0 devices. However, ETC does not support an alpha channel and RGBA 16-bit will sometimes be the best trade-off between size, quality and rendering speed where alpha is required.

It is also possible to create separate android distribution archives (.apk) for each of the DXT/PVRTC/ATC formats, and let the Android Market's filtering system select the correct archives for different devices (see [Publishing Builds for Android ](Main.PublishingBuilds#Android.md)).

###Movie Playback
Movie textures are not supported on Android, but a full-screen streaming playback is provided via scripting functions. To learn about supported file formats and scripting API, consult the [movie page](Main.VideoFiles.md) or the [Android supported media formats page ](http://developer.android.com/guide/appendix/media-formats.html.md).

###Further Reading
(:tocportion:)
