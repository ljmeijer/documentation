PlayStation3: Getting Started
=============================



###Developing for PS3
To develop for the PS3 you must be a Sony registered developer and own the appropriate hardware. See the [PS3 Setup](ps3-setup.md) or [PS3 Setup for Source Licensees](ps3-setupforsource.md) page depending on your license for a seat setup checklist.

###Build information:
* SDK version: 410.001

###Access PS3 unique functionality
Unity PS3 provides a number of new scripting APIs to access PSN services, Move and Navigation controllers, native video support and much more. See the _UnityEngine.PS3_ namespace in the scripting API.

###How Unity PS3 differs from Desktop Unity
* Strongly Typed JavaScript
    * Dynamic typing in JavaScript is always turned off in Unity PS3 . This is the same as adding `#pragma strict` to your scripts, but it is done by default instead. This greatly improves performance. When you launch an existing Unity Project, you will receive compiler errors if you are using dynamic typing. You can easily fix them by either using static typing for the variables that are causing errors or taking advantage of type interface.
* Ahead-Of-Time compilation
    * Scripts are AOT compiled into a static library which is subsequently linked with the Unity Run-Time to produce the player. Due to platform limitations, JITing is not supported. This means that reflection cannot be used.
* Limited memory
    * The console has a total of 256MB of System (Main) Memory and 256MB of Video Memory. The Unity Player and AOT'd Script Assemblies will take away from the main memory.
* Limited resolutions set
    * 1080p (HD-Native)
    * 720p (HD-Native)
    * 576p (SD-Downscaled from 720p)
    * 480p (SD-Downscaled from 720p)
* No hardware MSAA
    * Unity for PS3 does not do hardware MSAA. Use "AntialiasingAsPostEffect" technique "FXAA2" from the "Image Effects" standard package for best results.
* Video formats
    * Unity supports only MPEG4/AVC and DivX formats specially packaged into PAM or AVI containers. See the documentation on https://ps3.scedev.net for details on how to package video

###Further reading:
(:tocportion:)
