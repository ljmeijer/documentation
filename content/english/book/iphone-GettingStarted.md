Getting Started with iOS Development
====================================


Building games for devices like the iPhone and iPad requires a different approach than you would use for desktop PC games. Unlike the PC market, your target hardware is standardized and not as fast or powerful as a computer with a dedicated video card. Because of this, you will have to approach the development of your games for these platforms a little differently. Also, the features available in Unity for iOS differ slightly from those for desktop PCs.

Setting Up Your Apple Developer Account
---------------------------------------

Before you can run Unity iOS games on the actual device, you will need to have your Apple Developer account approved and set up.  This includes establishing your team, adding your devices, and finalizing your provisioning profiles.  All this setup is performed through Apple's developer website.  Since this is a complex process, we have provided a [basic outline](iphone-accountsetup.md) of the tasks that must be completed before you can run code on your iOS devices.  However, the best thing to do is follow the step-by-step instructions at [Apple's iPhone Developer portal](http://developer.apple.com/iphone.md).

__Note__: We recommend that you set up your Apple Developer account before proceeding because you will need it to use Unity to its full potential with iOS.

Accessing iOS Functionality
---------------------------

Unity provides a number of scripting APIs to access the multi-touch screen, accelerometer, device geographical location system and much more. You can find out more about the script classes on the [iOS scripting page](Main.iphone-API.md).

Exposing Native C, C++ or Objective-C Code to Scripts
-----------------------------------------------------

Unity allows you to call custom native functions written in C, C++ or Objective-C directly from C# scripts. To find out how to bind native functions, visit the [plugins page](Main.Plugins.md).

Prepare Your Application for In-App Purchases
---------------------------------------------

The Unity iOS runtime allows you to download new content and you can use this feature to implement in-app purchases. See the [downloadable content](iphone-Downloadable-Content.md) manual page for further information.

Occlusion Culling
-----------------

Unity supports _occlusion culling_ which is useful for squeezing high performance out of complex scenes with many objects. See the [occlusion culling](OcclusionCulling.md) manual page for further information.

Splash Screen Customization
---------------------------

See the [splash screen customization page](MobileCustomizeSplashScreen.md) to find out how to change the image your game shows while launching.

Troubleshooting and Reporting Crashes.
--------------------------------------

If you are experiencing crashes on the iOS device, please consult the [iOS troubleshooting](TroubleShooting#iPhoneTroubleShooting.md) page for a list of common issues and solutions. If you can't find a solution here then please file a bug report for the crash (menu: <span class=menu>Help > Report A Bug</span> in the Unity editor).


How Unity's iOS and Desktop Targets Differ
------------------------------------------


###Statically Typed JavaScript
Dynamic typing in JavaScript is always turned off in Unity when targetting iOS (this is equivalent to `#pragma strict` getting added to all your scripts automatically). Static typing greatly improves performance, which is especially important on iOS devices. When you switch an existing Unity project to the iOS target, you will get compiler errors if you are using dynamic typing. You can easily fix these either by using explicitly declared types for the variables that are causing errors or taking advantage of type inference.

###MP3 Instead of Ogg Vorbis Audio Compression
For performance reasons, MP3 compression is favored on iOS devices. If your project contains audio files with Ogg Vorbis compression, they will be re-compressed to MP3 during the build. Consult the [audio clip](class-AudioClip.md) documentation for more information on using compressed audio on the iPhone.

###PVRTC Instead of DXT Texture Compression
Unity iOS does not support DXT textures. Instead, PVRTC texture compression is natively supported by iPhone/iPad devices. Consult the [texture import settings](class-Texture2D.md) documentation to learn more about iOS texture formats.

###Movie Playback
MovieTextures are not supported on iOS.  Instead, full-screen streaming playback is provided via scripting functions. To learn about the supported file formats and scripting API, consult the [movie page](Main.VideoFiles.md) in the manual.



Further Reading
---------------

(:tocportion:)

