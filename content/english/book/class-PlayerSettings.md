Player Settings
===============


<span class=keyword>Player Settings</span> is where you define various parameters (platform specific) for the final game that you will build in Unity. Some of these values for example are used in the <span class=keyword>Resolution Dialog</span> that launches when you open a standalone game, others are used by XCode when building your game for the iOS devices, so it's important to fill them out correctly.

To see the Player Settings choose <span class=menu>Edit->Project Settings->Player</span> from the menu bar.


![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSetInspTop.png)  
_Global Settings that apply to any project you create._


|**_Property:_** |**_Function:_** |
|:---|:---|
|!Cross-Platform Properties      ||
|<span class=component>Company Name</span> |The name of your company. This is used to locate the preferences file. |
|<span class=component>Product Name</span> |The name that will appear on the menu bar when your game is running and is used to locate the preferences file also. |
|<span class=component>Default Icon</span> |Default icon the application will have on every platform (You can override this later for platform specific needs). |

Per-Platform Settings
=====================


##desktop Details
Web-Player
----------


####_Resolution And Presentation_


![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSetWebResPres.png)  


|**_Property:_** |**_Function:_** |
|:---|:---|
|___Resolution___              ||
|<span class=component>Default Screen Width</span>     |Screen Width the player will be generated with.|
|<span class=component>Default Screen Height</span>    |Screen Height the plater will be generated with.|
|<span class=component>Run in background</span>        |Check this if you dont want to stop executing your game if the player looses focus.|
|___WebPlayer Template___      |For more information you should check the [UsingWebPlayertemplates | "Using WebPlayer templates page"](UsingWebPlayertemplates|"UsingWebPlayertemplatespage".md), note that for each built-in and custom template there will be an icon in this section.|

####_Icon_


![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSetWebIcon.png)  

Icons don't have any meaning for most webplayer builds but they are needed for Native Client builds used as Chrome applications. You can set these icons here.

####_Other Settings_


![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSetWebOther355.png)  


|**_Property:_** |**_Function:_** |
|:---|:---|
|___Rendering___               |
|<span class=component>Rendering Path</span>           |This property is shared between Standalone and WebPlayer content.|
|>>><span class=component>Vertex Lit</span>               |Lowest lighting fidelity, no shadows support. Best used on old machines or limited mobile platforms.|
|>>><span class=component>Forward with Shaders</span>     |Good support for lighting features; limited support for shadows.|
|>>><span class=component>Deferred Lighting</span>        |Best support for lighting and shadowing features, but requires certain level of hardware support. Best used if you have many realtime lights. Unity Pro only.|
|<span class=component>Color Space</span>|The color space to be used for rendering|
|>>><span class=component>GammaSpace Rendering</span>|Rendering is gamma-corrected|
|>>><span class=component>Linear Rendering Hardware Sampling</span>|Rendering is done in linear space|
|<span class=component>Static Batching</span>             |Set this to use Static batching on your build (Inactive by default in webplayers). Unity Pro only.|
|<span class=component>Dynamic Batching</span>            |Set this to use Dynamic Batching on your build (Activated by default). |
|___Streaming___               ||
|<span class=component>First Streamed Level</span>     |If you are publishing a Streamed Web Player, this is the index of the first level that will have access to all Resources.Load assets.|
|__<span class=component>Optimization</span>__||
|<span class=component>Optimize Mesh Data</span>|Remove any data from meshes that is not required by the material applied to them (tangents, normals, colors, UV).|
|<span class=component>Debug Unload Mode</span>|Output debugging information regarding Resources.UnloadUnusedAssets.|
|>>><span class=component>Disabled</span>|Don't output any debug data for UnloadUnusedAssets.|
|>>><span class=component>Overview only</span>|Minimal stats about UnloadUnusedAssets usage.|
|>>><span class=component>Full (slow)</span>|Output overview stats along with stats for all affected objects. This option can slow down execution due to the amount of data being displayed.|

Standalone
----------

####_Resolution And Presentation_


![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSetPCResPres35.png)  


|**_Property:_** |**_Function:_** |
|:---|:---|
|___Resolution___              ||
|<span class=component>Default Screen Width</span>     |Screen Width the stand alone game will be using by default.|
|<span class=component>Default Screen Height</span>    |Screen Height the plater will be using by default.|
|<span class=component>Run in background</span>        |Check this if you dont want to stop executing your game if it looses focus.|
|___Standalone Player Options___||
|<span class=component>Default is Full Screen</span>   |Check this if you want to start your game by default in full screen mode.|
|<span class=component>Capture Single Screen</span>    |If enabled, standalone games in fullscreen mode will not darken the secondary monitor in multi-monitor setups.|
|<span class=component>DisplayResolution Dialog</span> ||
|>>><span class=component>Disabled</span>                 |No resolution dialog will appear when starting the game.|
|>>><span class=component>Enabled</span>                  |Resolution dialog will always appear when the game is launched.|
|<span class=component>Hidden by default</span>        |The resolution player is possible to be opened only if you have pressed the "alt" key when starting the game.|
|<span class=component>Use Player Log</span>          |Write a log file with debugging information. If you plan to submit your application to the Mac App Store you will want to leave this option un-ticked.  Ticked is the default. |
|<span class=component>Mac App Store Validation</span>          |Enable receipt validation for the Mac App Store. |
|<span class=component>Supported Aspect Ratios</span>  |Aspect Ratios selectable in the Resolution Dialog will be monitor-supported resolutions of enabled items from this list.|


####_Icon_


![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSettings-DesktopIcon.png)  


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Override for Standalone</span>  |Check if you want to assign a custom icon you would like to be used for your standalone game. Different sizes of the icon should fill in the squares below.|

####_Splash Image_


![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSettings-DesktopSplashImage.png)  


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Config Dialog Banner</span>     |Add your custom splash image that will be displayed when the game is starting.|


####_Other Settings_


![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSetPCOther355.png)  


|**_Property:_** |**_Function:_** |
|:---|:---|
|___Rendering___               |
|<span class=component>Rendering Path</span>              |This property is shared between Standalone and WebPlayer content.|
|>>><span class=component>Vertex Lit</span>               |Lowest lighting fidelity, no shadows support. Best used on old machines or limited mobile platforms.|
|>>><span class=component>Forward with Shaders</span>     |Good support for lighting features; limited support for shadows.|
|>>><span class=component>Deferred Lighting</span>        |Best support for lighting and shadowing features, but requires certain level of hardware support. Best used if you have many realtime lights. Unity Pro only.|
|<span class=component>Color Space</span>|The color space to be used for rendering|
|>>><span class=component>GammaSpace Rendering</span>|Rendering is gamma-corrected|
|>>><span class=component>Linear Rendering Hardware Sampling</span>|Rendering is done in linear space|
|<span class=component>Static Batching</span>             |Set this to use Static batching on your build (Inactive by default in webplayers). Unity Pro only.|
|<span class=component>Dynamic Batching</span>            |Set this to use Dynamic Batching on your build (Activated by default). |
|__<span class=component>Optimization</span>__||
|<span class=component>API Compatibility Level</span>     ||
|>>><span class=component>.Net 2.0</span>                 |.Net 2.0 libraries. Maximum .net compatibility,  biggest file sizes|
|>>><span class=component>.Net 2.0 Subset</span>          |Subset of full .net compatibility,  smaller file sizes|
|<span class=component>Optimize Mesh Data</span>|Remove any data from meshes that is not required by the material applied to them (tangents, normals, colors, UV).|
|<span class=component>Debug Unload Mode</span>|Output debugging information regarding Resources.UnloadUnusedAssets.|
|>>><span class=component>Disabled</span>|Don't output any debug data for UnloadUnusedAssets.|
|>>><span class=component>Overview only</span>|Minimal stats about UnloadUnusedAssets usage.|
|>>><span class=component>Full (slow)</span>|Output overview stats along with stats for all affected objects. This option can slow down execution due to the amount of data being displayed.|

<a id="iOS"></a>

#####ios Details
####_Resolution And Presentation_


![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSetiOSResPres.png)  


|**_Property:_** |**_Function:_** |
|:---|:---|
|___Resolution___                    ||
|<span class=component>Default Orientation</span>               |(This setting is shared between iOS and Android devices)|
|>>><span class=component>Portrait</span>                       |The device is in portrait mode, with the device held upright and the home button at the bottom.|
|>>><span class=component>Portrait Upside Down (iOS Only)</span>|The device is in portrait mode but upside down, with the device held upright and the home button at the top.|
|>>><span class=component>Landscape Right (iOS Only)</span>     |The device is in landscape mode, with the device held upright and the home button on the __left__ side.|
|>>><span class=component>Landscape Left</span>                 |The device is in landscape mode, with the device held upright and the home button on the __right__ side.|
|>>><span class=component>Auto Rotation</span>                  |The screen orientation is automatically set based on the physical device orientation.
|___Auto Rotation settings___        ||
|>>><span class=component>Use Animated Autorotation</span>      |When checked, orientation change is animated. This only applies when Default orientation is set to Auto Rotation.
|___Allowed Orientations for Auto Rotation___    ||
|>>><span class=component>Portrait</span>                       |When checked, portrait orientation is allowed. This only applies when Default orientation is set to Auto Rotation.
|>>><span class=component>Portrait Upside Down</span>           |When checked, portrait upside down orientation is allowed. This only applies when Default orientation is set to Auto Rotation.
|>>><span class=component>Landscape Right</span>                |When checked, landscape right (home button on the __left__ side) orientation is allowed. This only applies when Default orientation is set to Auto Rotation.
|>>><span class=component>Landscape Left</span>                 |When checked, landscape left (home button is on the __right__ side) orientation is allowed. This only applies when Default orientation is set to Auto Rotation.
|___Status Bar___                    ||
|<span class=component>Status Bar Hidden</span>        |Specifies whether the status bar is initially hidden when the application launches.|
|<span class=component>Status Bar Style</span>         |Specifies the style of the status bar as the application launches|
|>>><span class=component>Default</span>                  ||
|>>><span class=component>Black Translucent</span>        ||
|>>><span class=component>Black Opaque</span>             ||
|<span class=component>Use 32-bit Display Buffer</span>        |Specifies if Display Buffer should be created to hold 32-bit color values (16-bit by default). Use it if you see banding, or need alpha in your ImageEffects, as they will create RTs in same format as Display Buffer.|
|<span class=component>Show Loading Indicator</span>|Options for the loading indicator|
|>>><span class=component>Don't Show</span>|No indicator|
|>>><span class=component>White Large</span>|Indicator shown large and in white|
|>>><span class=component>White</span>|Indicator shown at normal size in white|
|>>><span class=component>Gray</span>|Indicator shown at normal size in gray|

####_Icon_


![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSetiOSIcon355.png)  


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Override for iOS</span>      |Check if you want to assign a custom icon you would like to be used for your iPhone/iPad game. Different sizes of the icon should fill in the squares below.|
|<span class=component>Prerendered icon</span>           |If unchecked iOS applies sheen and bevel effects to the application icon.|

####_Splash Image_


![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSetiOSSplash355.png)  


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Mobile Splash Screen (Pro-only feature)</span>|Specifies texture which should be used for iOS Splash Screen. Standard Splash Screen size is 320x480.(This is shared between Android and iOS)|
|<span class=component>High Res. iPhone (Pro-only feature)</span>|Specifies texture which should be used for iOS 4th gen device Splash Screen. Splash Screen size is 640x960.|
|<span class=component>iPad Portrait (Pro-only feature)</span>|Specifies texture which should be used as iPad Portrait orientation Splash Screen. Standard Splash Screen size is 768x1024.|
|<span class=component>High Res iPad Portrait (Pro-only feature)</span>|Specifies texture which should be used as iPad Portrait orientation Splash Screen. Standard Splash Screen size is 1536x2048.|
|<span class=component>iPad Landscape (Pro-only feature)</span>|Specifies texture which should be used as iPad Landscape orientation Splash Screen. Standard Splash Screen size is 1024x768.|
|<span class=component>High Res iPad Landscape (Pro-only feature)</span>|Specifies texture which should be used as iPad Portrait orientation Splash Screen. Standard Splash Screen size is 2048x1536.|

####_Other Settings_


![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSetiOSOther355.png)  


|**_Property:_** |**_Function:_** |
|:---|:---|
|___Rendering___               ||
|<span class=component>Static Batching</span>             |Set this to use Static batching on your build (Activated by default). Pro-only feature.|
|<span class=component>Dynamic Batching</span>            |Set this to use Dynamic Batching on your build (Activated by default). |
|___Identification___          ||
|<span class=component>Bundle Identifier</span>           |The string used in your provisioning certificate from your Apple Developer Network account(This is shared between iOS and Android) |
|<span class=component>Bundle Version</span>              |Specifies the build version number of the bundle, which identifies an iteration (released or unreleased) of the bundle. This is a monotonically increased string, comprised of one or more period-separated
|___Configuration___           |
|<span class=component>Target Device</span>               |Specifies application target device type.|
|>>><span class=component>iPhone Only</span>              |Application is targeted for iPhone devices only.|
|>>><span class=component>iPad Only</span>                |Application is targeted for iPad devices only.|
|>>><span class=component>iPhone + iPad</span>            |Application is targeted for both iPad and iPhone devices.|
|<span class=component>Target Platform</span>             |Specifies the target arquitecture you are going to build for.(This setting is shared between iOS and Android Platforms)|
|>>><span class=component>armv6 (OpenGL ES1.1)</span>     |Application is optimized for armv6 chipsets|
|>>><span class=component>Universal armv6+armv7 (OpenGL ES1.1+2.0)</span>|Application supports both armv6 and armv7 chipsets. _Note: increases application distribution size_|
|>>><span class=component>armv7</span>     |Application is optimized for armv7 chipsets. 1st-2nd gen. devices are not supported. There might be additional requirements for this build target imposed by Apple App Store. Defaults to OpenGL ES 2.0.|
|<span class=component>Target Resolution</span>           |Resolution you want to use on your deployed device.(This setting will not have any effect on devices with maximum resolution of 480x320)|
|>>><span class=component>Native(Default Device Resolution)</span>|Will use the device native resolution.|
|>>><span class=component>Standard(Medium or Low Resolution)</span>|Use the lowest resolution possible (480x320).|
|>>><span class=component>HD(Highest available resolution)</span>|Use the maximum resolution allowed on the device (960x640).|
|<span class=component>Accelerometer Frequency</span>|How often the accelerometer is sampled|
|>>><span class=component>Disabled</span>|Accelerometer is not sampled|
|>>><span class=component>15Hz</span>|15 samples per second|
|>>><span class=component>30Hz</span>|30 samples per second|
|>>><span class=component>60Hz</span>|60 samples per second|
|>>><span class=component>100Hz</span>|100 samples per second|
|<span class=component>Override iPod Music</span>|If selected application will silence user's iPod music. Otherwise user's iPod music will continue playing in the background. |
|<span class=component>UI Requires Persistent WiFi</span> |Specifies whether the application requires a Wi-Fi connection. iOS maintains the active Wi-Fi connection open while the application is running.|
|<span class=component>Exit on Suspend</span> |Specifies whether the application should quit when suspended to background on iOS versions that support multitasking.|
|___Optimization___            ||
|<span class=component>Api Compatibility Level</span>     |Specifies active .NET API profile|
|>>><span class=component>.Net 2.0</span>                 |.Net 2.0 libraries. Maximum .net compatibility,  biggest file sizes|
|>>><span class=component>.Net 2.0 Subset</span>          |Subset of full .net compatibility,  smaller file sizes|
|<span class=component>AOT compilation options</span>     |Additional AOT compiler options.|
|<span class=component>SDK Version</span>          |Specifies iPhone OS SDK version to use for building in Xcode|
|>>><span class=component>iOS 4.0</span>            |iOS SDK 4.0.|
|>>><span class=component>iOS Simulator 4.0</span>            |iOS Simulator 4.0. Application built for this version of SDK will be able to run only on Simulator from the SDK 4.|
|>>><span class=component>iOS 4.1</span>            |iOS 4.1.|
|>>><span class=component>iOS Simulator 4.1</span>            |iOS Simulator 4.1. Application built for this version of SDK will be able to run only on Simulator from the SDK 4.x.|
|>>><span class=component>iOS 4.2</span>            |iOS 4.2.|
|>>><span class=component>iOS Simulator 4.2</span>            |iOS Simulator 4.2. Application built for this version of SDK will be able to run only on Simulator from the SDK 4.x.|
|>>><span class=component>iOS 4.3</span>            |iOS 4.3.|
|>>><span class=component>iOS Simulator 4.3</span>            |iOS Simulator 4.3. Application built for this version of SDK will be able to run only on Simulator from the SDK 4.x.|
|>>><span class=component>iOS 5.0</span>|iOS 5.0|
|>>><span class=component>iOS Simulator 5.0</span>|iOS Simulator 5.0. Application built for this version of SDK will be able to run only on Simulator from the SDK 5.x.|
|>>><span class=component>iOS latest</span>            |Latest available iOS SDK. Available since iOS SDK 4.2. (default value)|
|>>><span class=component>iOS Simulator latest</span>            |Latest available iOS Simulator SDK. Available since iOS SDK 4.2.|
|>>><span class=component>Unknown</span>                  |iOS SDK version is not managed by Unity Editor.|
|<span class=component>Target iOS Version</span>          |Specifies lowest iOS version where final application will able to run|
|>>><span class=component>3.0</span>            |iPhone OS 3.0. (default value)|
|>>><span class=component>3.1</span>            |iPhone OS 3.1.|
|>>><span class=component>3.1.2</span>          |iPhone OS 3.1.2.|
|>>><span class=component>3.1.3</span>          |iPhone OS 3.1.3.|
|>>><span class=component>3.2</span>            |iPhone OS 3.2.|
|>>><span class=component>4.0</span>            |iPhone OS 4.0.|
|>>><span class=component>4.1</span>            |iPhone OS 4.1.|
|>>><span class=component>4.2</span>            |iPhone OS 4.2.|
|>>><span class=component>4.3</span>            |iPhone OS 4.3.|
|>>><span class=component>5.0</span>|iPhone OS 5.0|
|>>><span class=component>Unknown</span>                  |iPhone OS SDK version is not managed by Unity Editor.|
|<span class=component>Stripping Level (Pro-only feature)</span> |Options to strip out scripting features to reduce built player size(This setting is shared between iOS and Android Platforms)|
|>>><span class=component>Disabled</span>         |No reduction is done.|
|>>><span class=component>Strip Assemblies</span> |Level 1 size reduction.|
|>>><span class=component>Strip ByteCode</span> |Level 2 size reduction (includes reductions from Level 1).|
|>>><span class=component>Use micro mscorlib</span> |Level 3 size reduction (includes reductions from Levels 1 and 2).|
|<span class=component>Script Call Optimization</span> |Optionally disable exception handling for a speed boost at runtime |
|>>><span class=component>Slow and Safe</span> |Full exception handling will occur with some performance impact on the device |
|>>><span class=component>Fast but no Exceptions</span> |No data provided for exceptions on the device, but the game will run faster |
|<span class=component>Optimize Mesh Data</span>|Remove any data from meshes that is not required by the material applied to them (tangents, normals, colors, UV).|
|<span class=component>Debug Unload Mode</span>|Output debugging information regarding Resources.UnloadUnusedAssets.|
|>>><span class=component>Disabled</span>|Don't output any debug data for UnloadUnusedAssets.|
|>>><span class=component>Overview only</span>|Minimal stats about UnloadUnusedAssets usage.|
|>>><span class=component>Full (slow)</span>|Output overview stats along with stats for all affected objects. This option can slow down execution due to the amount of data being displayed.|

__Note:__ If you build for example for iPhone OS 3.2, and then select Simulator 3.2 in Xcode you will get a ton of errors. So you __MUST__ be sure to select a proper Target SDK in Unity Editor.
<a id="Android"></a>

#####android Details
####_Resolution And Presentation_

![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSettingsAndroidResolutionPresentation.png)  
_Resolution and presentation for your Android project builds._

|**_Property:_** |**_Function:_** |
|:---|:---|
|___Resolution___              ||
|<span class=component>Default Orientation</span>         |(This setting is shared between iOS and Android devices)|
|>>><span class=component>Portrait</span>                 |The device is in portrait mode, with the device held upright and the home button at the bottom.|
|>>><span class=component>Portrait Upside Down</span>     |The device is in portrait mode but upside down, with the device held upright and the home button at the top (only available with Android OS 2.3 and later).|
|>>><span class=component>Landscape Right</span>          |The device is in landscape mode, with the device held upright and the home button on the __left__ side (only available with Android OS 2.3 and later).|
|>>><span class=component>Landscape Left</span>           |The device is in landscape mode, with the device held upright and the home button on the __right__ side.|
|<span class=component>Use 32-bit Display Buffer</span>        |Specifies if Display Buffer should be created to hold 32-bit color values (16-bit by default). Use it if you see banding, or need alpha in your ImageEffects, as they will create RTs in same format as Display Buffer. Not supported on devices running pre-Gingerbread OS (will be forced to 16-bit).|
|<span class=component>Use 24-bit Depth Buffer</span>        |If set Depth Buffer will be created to hold (at least) 24-bit depth values. Use it only if you see 'z-fighting' or other artifacts, as it may have performance implications.|
|!                               |!|
|                                ||
|__<span class=component>Icon</span>__                           ||

![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSettings-AndroidIcon.png)  
_Different icons that your project will have when built._

|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Override for Android</span>        |Check if you want to assign a custom icon you would like to be used for your Android game. Different sizes of the icon should fill in the squares below.|
|!                               |!|
|                                ||
|__<span class=component>Splash Image</span>__                    ||

![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSettings-AndroidSplashImage.png)  
_Splash image that is going to be displayed when your project is launched._

|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Mobile Splash Screen (Pro-only feature)</span>|Specifies texture which should be used by the iOS Splash Screen. Standard Splash Screen size is 320x480.(This is shared between Android and iOS)|
|<span class=component>Splash Scaling</span>              |Specifies how will be the splash image scaling on the device.|
|!                               |!|
|                                ||
|__<span class=component>Other Settings</span>__                 ||

![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSetAndroidOther355.png)  


|    |    |
|:---|:---|
|___Rendering___               ||
|<span class=component>Static Batching</span>             |Set this to use Static batching on your build (Activated by default). Pro-only feature.|
|<span class=component>Dynamic Batching</span>            |Set this to use Dynamic Batching on your build (Activated by default). |
|___Identification___          ||
|<span class=component>Bundle Identifier</span>           |The string used in your provisioning certificate from your Apple Developer Network account(This is shared between iOS and Android) |
|<span class=component>Bundle Version</span>              |Specifies the build version number of the bundle, which identifies an iteration (released or unreleased) of the bundle. This is a monotonically increased string, comprised of one or more period-separated(This is shared between iOS and Android)|
|<span class=component>Bundle Version Code</span>         |An internal version number. This number is used only to determine whether one version is more recent than another, with higher numbers indicating more recent versions. This is not the version number shown to users; that number is set by the versionName attribute. The value must be set as an integer, such as "100". You can define it however you want, as long as each successive version has a higher number. For example, it could be a build number. Or you could translate a version number in "x.y" format to an integer by encoding the "x" and "y" separately in the lower and upper 16 bits. Or you could simply increase the number by one each time a new version is released.|
|___Configuration___           |
|<span class=component>Device Filter</span>               |Specifies the target architecture you are going to build for.|
|>>><span class=component>ARMv7 only</span>     |Application optimized for ARMv7 CPU architecture. It will also enable correct Android Market device filtering, thus recommended for publishing to the Android Market (only devices supporting Unity Android will list the application on the Android Market).|

#####u30 Details
|>>><span class=component>ARMv6 with VFP</span>     |Application optimized for ARMv6 CPU architecture (requires VFP support). Use runtime detection of hardware capabilities rather than relying on the Android Market filtering mechanism. It means the application when published to the Android Market will be visible also to devices not supporting Unity Android. Obviously this is not recommended, especially for paid applications (though can be combined with other means of filtering instead, like OpenGLES version).|
|<span class=component>Graphics Level</span>              |Select either ES 1.1 ('fixed function') or ES 2.0 ('shader based') Open GL level. When using the AVD (emulator) only ES 1.x is supported.|
|<span class=component>Install Location</span>            |Specifies application install location on the device (for detailed information, please refer to http://developer.android.com/guide/appendix/install-location.html).|
|>>><span class=component>Automatic</span>       |Let OS decide. User will be able to move the app back and forth.|
|>>><span class=component>Prefer External</span> |Install app to external storage (SD-Card) if possible. OS does not guarantee that will be possible; if not, the app will be installed to internal memory.|
|>>><span class=component>Force Internal</span>  |Force app to be installed into internal memory. User will be unable to move the app to external storage.|
|<span class=component>Internet Access</span>    |When set to Require, will enable networking permissions even if your scripts are not using this. Automatically enabled for development builds.|
|<span class=component>Write Access</span>    |When set to External (SDCard), will enable write access to external storage such as the SD-Card. Automatically enabled for development builds.|
|___Optimization___            ||
|<span class=component>Api Compatibility Level</span>     |Specifies active .NET API profile|
|>>><span class=component>.Net 2.0</span>                 |.Net 2.0 libraries. Maximum .net compatibility,  biggest file sizes|
|>>><span class=component>.Net 2.0 Subset</span>          |Subset of full .net compatibility,  smaller file sizes|
|<span class=component>Stripping Level (Pro-only feature)</span> |Options to strip out scripting features to reduce built player size(This setting is shared between iOS and Android Platforms)|
|>>><span class=component>Disabled</span>         |No reduction is done.|
|>>><span class=component>Strip Assemblies</span> |Level 1 size reduction.|
|>>><span class=component>Strip ByteCode (iOS only)</span> |Level 2 size reduction (includes reductions from Level 1).|
|>>><span class=component>Use micro mscorlib</span> |Level 3 size reduction (includes reductions from Levels 1 and 2).|
|<span class=component>Enable "logcat" profiler</span>|Enable this if you want to get feedback from your device while testing your projects. So adb logcat prints logs from the device to the console (only available in development builds).|
|<span class=component>Optimize Mesh Data</span>|Remove any data from meshes that is not required by the material applied to them (tangents, normals, colors, UV).|
|<span class=component>Debug Unload Mode</span>|Output debugging information regarding Resources.UnloadUnusedAssets.|
|>>><span class=component>Disabled</span>|Don't output any debug data for UnloadUnusedAssets.|
|>>><span class=component>Overview only</span>|Minimal stats about UnloadUnusedAssets usage.|
|>>><span class=component>Full (slow)</span>|Output overview stats along with stats for all affected objects. This option can slow down execution due to the amount of data being displayed.|


|    |    |
|:---|:---|
|!Publishing Settings            ||

![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSettings-AndroidPublishingSettings.png)  
_Publishing settings for Android Market_

|**_Property:_** |**_Function:_** |
|:---|:---|
|___Keystore___                               ||
|>>><span class=component>Use Existing Keystore / Create New Keystore</span>|Use this to choose whether to create a new Keystore or use an existing one.|
|>>><span class=component>Browse Keystore</span>                            |Lets you select an existing Keystore.|
|>>><span class=component>Keystore password</span>                       |Password for the Keystore.|
|>>><span class=component>Confirm password</span>                        |Password confirmation, only enabled if the Create New Keystore option is chosen.|
|___Key___                                    ||
|>>><span class=component>Alias</span>                                      |Key alias|
|>>><span class=component>Password</span>                                   |Password for key alias|

#####u30 Details
|__Android Market Licensing (LVL)__||
|>>><span class=component>Public Key</span>  |The public key provided by the [Android developer site](http://developer.android.com/guide/publishing/licensing.html#account.md).|

#####u40 Details
|>>><span class=component>Split Application Binary</span>  |Split application binary into expansion files, for use with Google Play Store if application is larger than 50 MB. When enabled the player executable and data will be split up, with a generated .apk consisting only of the executable (Java and Native) code (~10MB), and the data for the first scene. The application data will be serialized separately to an APK Expansion File (.obb). |
Note that for security reasons, Unity will save neither the keystore password nor the key password. Also, note that the signing must be done from Unity's player settings - using jarsigner will not work.


Flash
-----


####_Resolution And Presentation_


![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSetFlashResPres.png)  


|**_Property:_** |**_Function:_** |
|:---|:---|
|___Resolution___              ||
|<span class=component>Default Screen Width</span>     |Screen Width the player will be generated with.|
|<span class=component>Default Screen Height</span>    |Screen Height the plater will be generated with.|


####_Other Settings_


![](http://docwiki.hq.unity3d.com/uploads/Main/PlayerSetFlashOther355.png)  


|**_Property:_** |**_Function:_** |
|:---|:---|
|___Optimization___||
|<span class=component>Stripping</span>|Bytecode can optionally be stripped during the build.|
|<span class=component>Optimize Mesh Data</span>|Remove any data from meshes that is not required by the material applied to them (tangents, normals, colors, UV).|
|<span class=component>Debug Unload Mode</span>|Output debugging information regarding Resources.UnloadUnusedAssets.|
|>>><span class=component>Disabled</span>|Don't output any debug data for UnloadUnusedAssets.|
|>>><span class=component>Overview only</span>|Minimal stats about UnloadUnusedAssets usage.|
|>>><span class=component>Full (slow)</span>|Output overview stats along with stats for all affected objects. This option can slow down execution due to the amount of data being displayed.|

Details
=======



##desktop Details
The Player Settings window is where many technical preference defaults are set. See also [Quality Settings](class-QualitySettings.md) where the different graphics quality levels can be set up.

###Publishing a web player

<span class=component>Default Web Screen Width</span> and <span class=component>Default Web Screen Height</span> determine the size used in the html file. You can modify the size in the html file later.

<span class=component>Default Screen Width</span> and <span class=component>Default Screen Height</span> are used by the Web Player when entering fullscreen mode through the context menu in the Web Player at runtime.


###Customizing your Resolution Dialog


![](http://docwiki.hq.unity3d.com/uploads/Main/Resolution-GameLauncher.png)  
_The Resolution Dialog, presented to end-users_

You have the option of adding a custom banner image to the Screen Resolution Dialog in the Standalone Player. The maximum image size is 432 x 163 pixels. The image will not be scaled up to fit the screen selector. Instead it will be centered and cropped.

###Publishing to Mac App Store

<span class=component>Use Player Log</span> enables writing a log file with debugging information. This is useful to find out what happened if there are problems with your game. When publishing games for Apple's Mac App Store, it is recommended to turn this off, because Apple may reject your submission otherwise. See [this manual page](LogFiles.md) for further information about log files.

<span class=component>Use Mac App Store Validation</span> enables receipt validation for the Mac App Store. If this is enabled, your game will only run when it contains a valid receipt from the Mac App Store. Use this when submitting games to Apple for publishing on the App Store. This prevents people from running the game on any computer then the one it was purchased on. Note that this feature does not implement any strong copy protection. In particular, any potential crack against one Unity game would work against any other Unity content. For this reason, it is recommended that you implement your own receipt validation code on top of this using Unity's plugin feature. However, since Apple requires plugin validation to initially happen before showing the screen setup dialog, you should still enable this check, or Apple might reject your submission. 


####ios Details
###Bundle Identifier

The <span class=component>Bundle Identifier</span> string must match the provisioning profile of the game you are building.  The basic structure of the identifier is <span class=component>com.CompanyName.GameName</span>. This structure may vary internationally based on where you live, so always default to the string provided to you by Apple for your Developer Account.  Your GameName is set up in your provisioning certificates, that are manageable from the Apple iPhone Developer Center website.  Please refer to the [Apple iPhone Developer Center website](http://developer.apple.com/iphone/.md) for more information on how this is performed.

###Stripping Level (Pro-only)

Most games don't use all necessary dlls.  With this option, you can strip out unused parts to reduce the size of the built player on iOS devices.  If your game is using classes that would normally be stripped out by the option you currently have selected, you'll be presented with a Debug message when you make a build.

###Script Call Optimization

A good development practice on iOS is to never rely on exception handling (either internally or through the use of try/catch blocks).  When using the default <span class=component>Slow and Safe</span> option, any exceptions that occur on the device will be caught and a stack trace will be provided.  When using the <span class=component>Fast but no Exceptions</span> option, any exceptions that occur will crash the game, and no stack trace will be provided.  However, the game will run faster since the processor is not diverting power to handle exceptions.  When releasing your game to the world, it's best to publish with the <span class=component>Fast but no Exceptions</span> option.


####android Details
###Bundle Identifier

The <span class=component>Bundle Identifier</span> string is the unique name of your application when published to the Android Market and installed on the device.  The basic structure of the identifier is <span class=component>com.CompanyName.GameName</span>, and can be chosen arbitrarily.  In Unity this field is shared with the iOS Player Settings for convenience.

###Stripping Level (Pro-only)

Most games don't use all the functionality of the provided dlls.  With this option, you can strip out unused parts to reduce the size of the built player on Android devices.
