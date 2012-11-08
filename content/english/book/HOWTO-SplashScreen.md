How do I make a Splash Screen?
==============================



##desktop Details
Here's how to do a splash screen or any other type of full-screen image in Unity. This method works for multiple resolutions and aspect ratios.

1. First you need a big texture. Ideally textures should be power of two in size. You might for example use 1024x512 as this fits most screens.
1. Make a box using the <span class=menu>GameObject->Create Other->Cube</span> menubar item.
1. Scale it to be in 16:9 format by entering 16 and 9 as the first two value in the Scale:

![](http://docwiki.hq.unity3d.com/uploads/Main/HOWTO-SplashScreen1.png)  
1. Drag the texture onto the cube and make the <span class=keyword>Camera</span> point at it. Place the camera at such a distance so that the cube is still visible on a 16:9 aspect ratio.  Use the <span class=keyword>Aspect Ratio Selector</span> in the <span class=keyword>Scene View</span> menu bar to see the end result.

##ios Details
[Customising IOS device Splash Screens](MobileCustomizeSplashScreen.md)

##android Details
[Customising Android device Splash Screens](MobileCustomizeSplashScreen.md)
