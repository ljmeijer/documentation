
#u40 Details
Building Plugins for Desktop Platforms
======================================


This page describes [Native Code Plugins](Plugins.md) for desktop platforms (Windows/Mac OS X/Linux). Note that plugins are intentionally disabled in webplayers for security reasons.


Building a Plugin for Mac OS X
------------------------------


On Mac OSX, [plugins](Plugins.md) are deployed as bundles. You can create the bundle project with XCode by selecting <span class=menu>File->NewProject...</span> and then selecting Bundle - Carbon/Cocoa Loadable Bundle.

If you are using C++ (.cpp) or Objective-C (.mm) to implement the plugin then you must ensure the functions are declared with C linkage to avoid [name mangling issues](http://en.wikipedia.org/wiki/Name_mangling.md).

````
extern "C" {
  float FooPluginFunction ();
} 
````

Building a Plugin for Windows
-----------------------------


Plugins on Windows are DLL files with exported functions. Practically any language or development environment that can create DLL files can be used to create plugins.  
As with Mac OSX, you should declare any C++ functions with C linkage to avoid name mangling issues.

Building a Plugin for Linux
---------------------------


Plugins on Linux are `.so` files with exported functions.  These libraries are typically written in C or C++, but any language can be used.  
As with the other platforms, you should declare any C++ functions with C linkage in order to avoid name mangling issues.

###32-bit and 64-bit libraries
Currently, plugins for 32-bit and 64-bit players need to be managed manually, e.g, before building a 64-bit player, you need to copy the 64-bit library into the `Assets/Plugins` folder, and before building a 32-bit player, you need to copy the 32-bit library into the `Assets/Plugins` folder.

Using your plugin from C#
-------------------------


Once built, the bundle should be placed in the <span class=menu>Assets->Plugins</span> folder in the Unity project. Unity will then find it by name when you define a function like this in the C# script:-

````
[DllImport ("PluginName")]
private static extern float FooPluginFunction (); 
````

Please note that <span class=component>PluginName</span> should not include the library prefix nor file extension. For example, the actual name of the plugin file would be PluginName.dll on Windows and libPluginName.so on Linux.  
Be aware that whenever you change code in the Plugin you will need to recompile scripts in your project or else the plugin will not have the latest compiled code.

Deployment
----------


For cross platform plugins you must include the .bundle (for Mac), .dll (for Windows), and .so (for Linux) files in the Plugins folder.  
No further work is then required on your side - Unity automatically picks the right plugin for the target platform and includes it with the player.


Examples
--------


###Simplest Plugin
This plugin project implements only some very basic operations (print a number, print a string, add two floats, add two integers). This example may be helpful if this is your first Unity plugin.  
The project can be found [here](Attach:SimplestPluginExample-4.0.zip.md) and includes Windows, Mac, and Linux project files.

###Rendering from C++ code
An example multiplatform plugin that works with multithreaded rendering in Unity can be found on the [Native Plugin Interface](NativePluginInterface.md) page.

###Midi Plugin
A complete example of the Plugin interface can be found [here](http://unity3d.com/tutorials/midiplugin.zip.md).

This is a complete Midi plugin for OS X which uses Apple's CoreMidi API. It provides a simple C API and a C# class to access it from Unity. The C# class contains a high level API, with easy access to NoteOn and NoteOff events and their velocity.

###Texture Plugin
An example of how to assign image data to a texture directly in OpenGL (note that this will only work when Unity is using an OpenGL renderer). This example includes both XCode and Visual Studio project files. The plugin, along with an accompanying Unity project, can be found [here](http://unity3d.com/support/resources/example-projects/texture-plugins.md).


####u30 Details
Building Plugins for Desktop Platforms
======================================


This page describes [Native Code Plugins](Plugins.md) for desktop platforms (Windows/Mac OS X) . Note that plugins are intentionally disabled in webplayers for security reasons.


Building a Plugin for Mac OS X
------------------------------


On Mac OSX, [plugins](Plugins.md) are deployed as bundles. You can create the bundle project with XCode by selecting <span class=menu>File->NewProject...</span> and then selecting Bundle - Carbon/Cocoa Loadable Bundle.

If you are using C++ (.cpp) or Objective-C (.mm) to implement the plugin then you must ensure the functions are declared with C linkage to avoid [name mangling issues](http://en.wikipedia.org/wiki/Name_mangling.md).

````
extern "C" {
  float FooPluginFunction ();
} 
````

Building a Plugin for Windows
-----------------------------


Plugins on Windows are DLL files with exported functions. Practically any language or development environment that can create DLL files can be used to create plugins.  
As with Mac OSX, you should declare any C++ functions with C linkage to avoid name mangling issues.

Using your plugin from C#
-------------------------


Once built, the bundle should be placed in the <span class=menu>Assets->Plugins</span> folder in the Unity project. Unity will then find it by name when you define a function like this in the C# script:-

````
[DllImport ("PluginName")]
private static extern float FooPluginFunction (); 
````

Please note that <span class=component>PluginName</span> should not include the extension of the filename. Be aware that whenever you change code in the Plugin you will need to recompile scripts in your project or else the plugin will not have the latest compiled code.

Deployment
----------


For cross platform plugins you must include both the .bundle (for Mac) and .dll (for Windows) files in the Plugins folder. No further work is then required on your side - Unity automatically picks the right plugin for the target platform and includes it with the player.


Examples
--------


###Simplest Plugin
This plugin project implements only some very basic operations (print a number, print a string, add two floats, add two integers). This example may be helpful if this is your first Unity plugin.  
The project can be found [here](Attach:SimplestPluginExample.zip.md) and includes both Windows and Mac project files.

###Rendering from C++ code
An example multiplatform plugin that works with multithreaded rendering in Unity can be found on the [Native Plugin Interface](NativePluginInterface.md) page.

###Midi Plugin
A complete example of the Plugin interface can be found [here](http://unity3d.com/tutorials/midiplugin.zip.md).

This is a complete Midi plugin for OS X which uses Apple's CoreMidi API. It provides a simple C API and a C# class to access it from Unity. The C# class contains a high level API, with easy access to NoteOn and NoteOff events and their velocity.

###Texture Plugin
An example of how to assign image data to a texture directly in OpenGL (note that this will only work when Unity is using an OpenGL renderer). This example includes both XCode and Visual Studio project files. The plugin, along with an accompanying Unity project, can be found [here](http://unity3d.com/support/resources/example-projects/texture-plugins.md).

