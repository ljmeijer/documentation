Plugins (Pro/Mobile-Only Feature)
=================================


Unity has extensive support for <span class=keyword>Plugins</span>, which are libraries of native code written in C, C++, Objective-C, etc.  Plugins allow your game code (written in Javascript, C# or Boo) to call functions from these libraries.  This feature allows Unity to integrate with middleware libraries or existing C/C++ game code.

__Note:__ On the desktop platforms, plugins are a pro-only feature. For security reasons, plugins are not usable with webplayers.

In order to use a plugin you need to do two things:-

* Write functions in a C-based language and compile them into a library.
* Create a C# script which calls functions in the library.

The plugin should provide a simple C interface which the C# script then exposes to other user scripts. It is also possible for Unity to call functions exported by the plugin when certain low-level rendering events happen (for example, when a graphics device is created), see the [Native Plugin Interface](NativePluginInterface.md) page for details.


Here is a very simple example:


###C File of a Minimal Plugin:

````
float FooPluginFunction () { return 5.0F; } 
````

###C# Script that Uses the Plugin:


````
using UnityEngine;
using System.Runtime.InteropServices;

class SomeScript : MonoBehaviour {

   #if UNITY_IPHONE || UNITY_XBOX360
   
   // On iOS and Xbox 360 plugins are statically linked into
   // the executable, so we have to use __Internal as the
   // library name.
   [DllImport ("__Internal")]

   #else

   // Other platforms load plugins dynamically, so pass the name
   // of the plugin's dynamic library.
   [DllImport ("PluginName")]
	
   #endif

   private static extern float FooPluginFunction ();

   void Awake () {
      // Calls the FooPluginFunction inside the plugin
      // And prints 5 to the console
      print (FooPluginFunction ());
   }
} 
````

Note that when using Javascript you will need to use the following syntax, where DLLName is the name of the plugin you have written, or "__Internal" if you are writing statically linked native code:

````
@DllImport (DLLName)
static private function FooPluginFunction () : float {};
````

Creating a Plugin
-----------------


In general, plugins are built with native code compilers on the target platform. Since plugin functions use a C-based call interface, you must avoid name mangling issues when using C++ or Objective-C.

For further details and examples, see the following pages:-


###desktop Details
* [Building Plugins for Desktop Platforms](PluginsForDesktop.md)

###ios Details
* [Building Plugins for iOS](PluginsForIOS.md)

###android Details
* [Building Plugins for Android](PluginsForAndroid.md)

###xbox360 Details
* [Building Plugins for Xbox 360](PluginsForXbox360.md)

###ps3 Details
* [Building Plugins for PlayStation3](ps3-nativeplugins.md)

Further Information
-------------------

* [Native Plugin Interface](NativePluginInterface.md) - this is needed if you want to do rendering in your plugin.
* [Mono Interop with native libraries](http://www.mono-project.com/Interop_with_Native_Libraries.md).
* [P-invoke documentation on MSDN](http://msdn2.microsoft.com/en-us/library/fzhhdwae.aspx.md).
