Features currently not supported by Unity Android
=================================================


Graphics
--------

* Non-square textures are not supported by the ETC format.
* Movie Textures are not supported, use a full-screen streaming playback instead. Please see the [Movie playback page](Main.VideoFiles.md) for more information.

Scripting
---------

* <span class=component>OnMouseEnter</span>, <span class=component>OnMouseOver</span>, <span class=component>OnMouseExit</span>, <span class=component>OnMouseDown</span>, <span class=component>OnMouseUp</span>, and <span class=component>OnMouseDrag</span> events are not supported on Android.
* Dynamic features like Duck Typing are not supported. Use #pragma strict for your scripts to force the compiler to report dynamic features as errors.
* Video streaming via <span class=component>WWW</span> class is not supported.
