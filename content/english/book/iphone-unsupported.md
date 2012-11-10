Features currently not supported by Unity iOS
=============================================


Graphics
--------

* DXT texture compression is not supported; use PVRTC formats instead. Please see the [Texture2D Component page](class-Texture2D.md) for more information.
* Rectangular textures can not be compressed to PVRTC formats.
* Movie Textures are not supported; use a full-screen streaming playback instead. Please see the [Movie playback page](Main.VideoFiles.md) for more information.
* Open GL ES2.0 is not supported on iPhone, iPhone 3G, iPod Touch 1st and iPod Touch 2nd Generation hardware.


Audio
-----

* Ogg audio compression is not supported. Ogg audio will be  automatically converted to MP3 when you switch to iOS platform in the Editor. Please see the [AudioClip Component page](class-AudioClip.md) for more information about audio support in Unity iOS.

Scripting
---------

* <span class=component>OnMouseDown</span>, <span class=component>OnMouseEnter</span>, <span class=component>OnMouseOver</span>, <span class=component>OnMouseExit</span>, <span class=component>OnMouseDown</span>, <span class=component>OnMouseUp</span>, <span class=component>OnMouseDrag</span> events are not supported.
* Dynamic features like Duck Typing are not supported. Use `#pragma strict` for your scripts to force the compiler to report dynamic features as errors.
* Video streaming via <span class=component>WWW</span> class is not supported.
* FTP support by <span class=component>WWW</span> class is limited.

Features Restricted to Unity iOS Advanced License
-------------------------------------------------

* Static batching is only supported in __Unity iOS Advanced__.
* Video playback is only supported in __Unity iOS Advanced__.
* Splash-screen customization is only supported in __Unity iOS Advanced__.
* AssetBundles are only supported in __Unity iOS Advanced__.
* Code stripping is only supported in __Unity iOS Advanced__.
* .NET sockets are only supported in __Unity iOS Advanced__.

__Note:__ it is recommended to minimize your references to external libraries, because 1 MB of .NET CIL code roughly translates to 3-4 MB of ARM code. For example, if your application references System.dll and System.Xml.dll then it means additional 6 MB of ARM code __if stripping is not used__. At some point application will reach limit when linker will have troubles linking the code.
If you care a lot about application size you might find C# a more suitable language for your code as is has less dependencies than JavaScript.
