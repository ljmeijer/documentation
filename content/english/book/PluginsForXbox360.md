Building Plugins for Xbox 360
=============================


This page describes [Native Code Plugins](Plugins.md) for Xbox 360.

Plugin requirements:
--------------------

1. Linked against the same libraries as Unity.
    * Development Build uses instrumented XDK libraries.
    * Non-development Build uses release XDK libraries.
1. Access to certain system services might not be possible if Unity already uses them:
    * [Avatar system](xbox360-avatars.md) can be disabled in Player Settings if a custom implementation is desired.

Plugin development:
-------------------

1. An Xbox 360 DLL is written as usual.
1. A relocation address must be provided manually:
    * See library _Project Properties - Xbox 360 Image conversion - Base Address_.
    * Available address range: 0x06000000 to 0x08000000.
1. Compiled libraries are be placed in PROJECT\Assets\Plugins folder. See See [Project Structure](xbox360-projectstructure.md) for more details.
1. A library definition file must be provided (PLUGINNAME.def).
1. See [Mono Interop docs](http://www.mono-project.com/Interop_with_Native_Libraries.md) for marshaling details.


Examples
--------


See "Xbox 360 - Native Plugin Example" package.


