Xbox 360: Getting Started
=========================


###Developing for Xbox 360
To develop for the Xbox 360 you must be a Microsoft Certified Xbox 360 Developer and own the appropriate hardware. See the [Xbox 360 Setup](xbox360-setup.md) page for a seat setup checklist.

###Access Xbox 360 unique functionality
Unity Xbox provides a number of new scripting APIs to access Xbox Live services, storage devices, Avatars and much more. See the _UnityEngine.X360_ namespace in the scripting API.

###How Unity Xbox differs from Desktop Unity
1. Strongly Typed JavaScript
    * Dynamic typing in JavaScript is always turned off in Unity on Xbox. This is the same as adding `#pragma strict` to your scripts, but it is done by default instead, in order to improve performance. When you launch an existing Unity Project, with dynamic typing, you will see compiler errors. You can easily fix them by either using static typing for the variables that are causing errors or taking advantage of type interface.
1. Ahead-Of-Time (AOT) compilation
    * Scripts are AOT compiled and loaded in as normal Xbox 360 dynamic libraries. JITing is not supported.
    * Exotic class libraries (reflection, LINQ etc) not fully supported.
1. Limited memory
    * Expect ~440MB free system memory with an empty project loaded.
1. Fixed resolution
    * 720p (1280x720) is the only resolution you'll have to deal with.
1. No hardware [MSAA](http://en.wikipedia.org/wiki/Multisample_anti-aliasing.md)
    * Unity for Xbox does not do hardware MSAA. Use "AntialiasingAsPostEffect" technique "FXAA3" from the "Image Effects" standard package for best results.
1. XMA audio compression
    * Unity will compress audio to XMA when targeting Xbox 360.
    * Unity will use OGG in the editor (XMA can not be played on the PC). Expect audio quality to differ and check the output Xbox produces.
    * Only two channels are supported when load type is "Compressed in memory".

###Build information:
* XDK version: July 2012, #21173.4.

###Further reading:
(:tocportion:)
