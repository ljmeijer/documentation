PlayStation3: Native Plugins
============================


This page describes [Native Code Plugins](Plugins.md) for PS3


Plugin development:
-------------------


* The PRX should be written according to SCE's Specifications. Please consult Lv2_PRX-Programming_Guide located in the pdf SDK docs under development_basic.

Plugin requirements:
--------------------

* Linked against the same SDK as Unity. (See the [Getting Started](ps3-gettingstarted.md) page for current SDK Version.)
* OnModuleStart / OnModuleStop functions have the following signature:

-->`int OnModuleStart(unsigned int args, void* argp);`
-->`int OnModuleStop(unsigned int args, void* argp);`


* The name used for [DllImport] in the script should be identical to the name used for `SYS_MODULE_INFO` and `SYS_LIB_DECLARE`
-->`[DllImport("MyPlugin")]` will load the plugin that has been declared with `SYS_MODULE_INFO(MyPlugin, ... )` and `SYS_LIB_DECLARE(MyModule, SYS_LIB_AUTO_EXPORT)`;


* In order to be loaded by the runtime, the plugin's .sprx and _stub.a and  must reside in _/path/to/project/Assets/Plugins/PS3/_. For example if your plugin is called _MyPlugin_, then _/path/to/project/Assets/Plugins/PS3/_ should contain _MyPlugin.sprx_ and _MyPlugin_stub.a_
    * See [Project Structure](ps3-projectstructure.md) for more details
    * See [Mono Interop docs](http://www.mono-project.com/Interop_with_Native_Libraries.md) for marshaling details.


Notes
-----


* The name used to identify the module (SYS_MODULE_INFO/SYS_LIB_DECLARE) must be maximum 25 characters.
* CellSpurs2 instance is passed as argp in the OnModuleStart function:

-->`CellSpurs2* spursInstance = (CellSpurs2*)argp;`


Example Plugin using ProDG's VSI.NET for Visual Studio 2008
-----------------------------------------------------------


###1. Create a new Project in Visual Studio.
* Select the PS3 PPU PRX template.
* Make sure that in the post build events “make_fself_npdrm” is used instead of the default “make_fself”.

###2. Build the Project.

###3. Copy the generated Plugin files to your Unity Project folder.
* It must be placed at this locations:

    * Assets/Plugins/PS3/XXXXXXX.sprx
    * Assets/Plugins/PS3/XXXXXXX_stub.a

###4. Use the plugin in your script code :

* Include InteropServices : using System.Runtime.InteropServices;
* Declare the dll with dllimport : [DllImport ("Name Of The Module")]
* Use preprocessor defines to compile your code for PS3 only.

````

using UnityEngine;
using System.Runtime.InteropServices;
		
public class UseThePlugin : MonoBehaviour {
#if UNITY_PS3 && !UNITY_EDITOR
	[DllImport ("Unity_PRX_Example")]
	private static extern int _Unity_PRX_Example_export_function ();

	void OnGUI () {
		GUILayout.Label ("Return value: " + _Unity_Example_export_function().ToString());
	}
#else
	void OnGUI () {
		GUILayout.Label ("Run the Test on the PS3");
	}	
#endif
}

````

###5. Verify it works
* The default PS3 PPU PRX project returns a zero. If that worked you should see "Return value: 0" printed on the screen.


Reference documentation
-----------------------


1. PRX files
https://ps3.scedev.net/docs/ps3-en,Lv2_PRX-Programming_Guide/1/

1. PRXS files
https://ps3.scedev.net/docs/ps3-en,Application_Requirements,Executable_Files/1/

1. NPDRM
https://ps3.scedev.net/docs/ps3-en,NP_DRM-Package_Requirements,Introduction/

1. PRX commands
https://ps3.scedev.net/docs/ps3-en,Lv2_PRX-Programming_Guide,Commands_Reference/1/

1. StdLibs for PRXS plugins
https://ps3.scedev.net/docs/ps3-en,C_and_Cpp_standard_libraries,C_and_Cpp_standard_libraries_1/1



