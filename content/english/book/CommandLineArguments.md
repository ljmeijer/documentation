Command line arguments
======================


Typically, Unity will be launched by double-clicking its icon from the desktop but it is also possible to run it from the command line (ie, the MacOS Terminal or the Windows Command Prompt). When launched in this way, Unity can receive commands and information on startup, which can be very useful for test suites, automated builds and other production tasks.

Under MacOS, you can launch Unity from the Terminal by typing:-

````
/Applications/Unity/Unity.app/Contents/MacOS/Unity
````

...while under Windows, you should type

````
"C:\Program Files (x86)\Unity\Editor\Unity.exe"
````

...at the command prompt.

Standalone Unity games can be launched in a similar way.


Command Line Arguments
----------------------

As mentioned above, the editor and also built games can optionally be supplied with additional commands and information on startup. This is done using the following command line arguments:-

:<span class=component>-batchmode</span>:Run Unity in batch mode. This should always be used in conjunction with the other command line arguments as it ensures no pop up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of script code, asset server updates fail or other operations fail Unity will immediately exit with return code 1. Note that in batch mode, Unity will send a minimal version of its log output to the console. However, the [Log Files](LogFiles.md) still contain the full log information.


:<span class=component>-quit</span>:Quit the Unity editor after other commands have finished executing.  Note that this can cause error messages to be hidden (but they will show up in the Editor.log file).

:<span class=component>-buildWindowsPlayer <pathname></span>:Build a standalone Windows player (eg, -buildWindowsPlayer path/to/your/build.exe).

:<span class=component>-buildOSXPlayer <pathname></span>:Build a standalone Mac OSX player (eg, -buildOSXPlayer path/to/your/build.app).


###u40 Details
:<span class=component>-buildLinux32Player <pathname></span>:Build a 32-bit standalone Linux player (eg, -buildLinux32Player path/to/your/build).

:<span class=component>-buildLinux64Player <pathname></span>:Build a 64-bit standalone Linux player (eg, -buildLinux64Player path/to/your/build).

:<span class=component>-importPackage <pathname></span>:Import the given [package](HOWTO-exportpackage.md). No import dialog is shown.

:<span class=component>-createProject <pathname></span>:Create an empty project at the given path.

:<span class=component>-projectPath <pathname></span>:Open the project at the given path.

:<span class=component>-logFile <pathname></span>:Specify where the Editor or Windows standalone log file will be written.

:<span class=component>-assetServerUpdate <IP[Asset Server](=:=]port]projectNameusernamepassword[r<revision>]></span>:Forceanupdateoftheprojectinthe[[AssetServer.md) given by _IP:port_. The port is optional and if not given it is assumed to be the standard one (10733). It is advisable to use this command in conjunction with the _-projectPath_ argument to ensure you are working with the correct project. If no project name is given then the last project opened by Unity is used. If no project exists at the path given by _-projectPath_ then one is created automatically.


###u30 Details
:<span class=component>-exportPackage <exportAssetPath exportFileName></span>:Exports a package given a path.  <span class=component>exportAssetPath</span> is a folder (relative to to the Unity project root) to export from the Unity project and <span class=component>exportFileName</span> is the package name. Currently, this option can only export a whole folder at a time.  This command normally needs to be used with the <span class=component>-projectPath</span> argument.

###u40 Details
:<span class=component>-exportPackage <exportAssetPath1 exportAssetPath2 ExportAssetPath3 exportFileName></span>:Exports a package given a path (or set of given paths).  <span class=component>exportAssetPath</span> is a folder (relative to to the Unity project root) to export from the Unity project and <span class=component>exportFileName</span> is the package name. Currently, this option can only export whole folders at a time.  This command normally needs to be used with the <span class=component>-projectPath</span> argument.

:<span class=component>-nographics (Windows only)</span>:When running in batch mode, do not initialize graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU.

:<span class=component>-executeMethod <ClassName.MethodName></span>:Execute the static method as soon as Unity is started, the project is open and after the optional asset server update has been performed. This can be used to do continous integration, perform Unit Tests, make builds, prepare some data, etc. If you want to return an error from the commandline process you can either throw an exception which will cause Unity to exit with 1 or else call [EditorApplication.Exit](ScriptRef:EditorApplication.Exit.html) with a non-zero code. If you want to pass parameters you can add them to the command line and retrieve them inside the method using System.Environment.GetCommandLineArgs. 

To use `-executeMethod` __you need to have a script in an Editor folder and a static function in the class__. 

````

// C# example
using UnityEditor;
class MyEditorScript
{
     static void PerformBuild ()
     {
         string[] scenes = { "Assets/MyScene.unity" };
         BuildPipeline.BuildPlayer(scenes, ...);
     }
}

````

````

// JavaScript example
static void PerformBuild ()
{
    string[] scenes = { "Assets/MyScene.unity" };
    BuildPipeline.BuildPlayer(scenes, ...);
}

````


###Example usage

Execute Unity in batch mode, execute `MyEditorScript.MyMethod` method, and quit upon completion.

__Windows:__  
`C:\program files\Unity\Editor>Unity.exe -quit -batchmode -executeMethod MyEditorScript.MyMethod`

__Mac OS:__  
`/Applications/Unity/Unity.app/Contents/MacOS/Unity -quit -batchmode -executeMethod MyEditorScript.MyMethod`


Execute Unity in batch mode. Use the project path given and update from the asset server. Execute the given method after all assets have been downloaded and imported from the asset server. After the method has finished execution, automatically quit Unity.

`/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -projectPath ~/UnityProjects/AutobuildProject -assetServerUpdate 192.168.1.1 MyGame AutobuildUser l33tpa33 -executeMethod MyEditorScript.PerformBuild -quit`


<a id="player"></a>
Unity Standalone Player command line arguments
----------------------------------------------


Standalone players built with Unity also understand some command line arguments:

:<span class=component>-batchmode</span>:Run the game in "headless" mode. The game will not display anything or accept user input. This is mostly useful for running servers for [networked games](NetworkReferenceGuide.md).

:<span class=component>-force-opengl (Windows only)</span>: Make the game use OpenGL for rendering, even if Direct3D is available. Normally Direct3D is used but OpenGL is used if Direct3D 9.0c is not available.


###u40 Details
:<span class=component>-force-d3d9 (Windows only)</span>: Make the game use Direct3D 9 for rendering. This is the default, so normally there's no reason to pass it.

:<span class=component>-force-d3d11 (Windows only)</span>: Make the game use Direct3D 11 for rendering. 

:<span class=component>-single-instance (Linux & Windows only)</span>:Allow only one instance of the game to run at the time. If another instance is already running then launching it again with `-single-instance` will just focus the existing one.

:<span class=component>-nolog (Windows only)</span>:Do not produce output log. Normally `output_log.txt` is written in the `*_Data` folder next to the game executable, where [Debug.Log](ScriptRef:Debug.Log.html) output is printed.

:<span class=component>-force-d3d9-ref (Windows only)</span>:Make the game run using Direct3D's "Reference" software renderer. The [DirectX SDK](http://msdn.microsoft.com/en-us/directx/default.aspx.md) has to be installed for this to work. This is mostly useful for building automated test suites, where you want to ensure rendering is exactly the same no matter what graphics card is being used.

:<span class=component>-adapter N (Windows only)</span>:Allows the game to run full-screen on another display, where N denotes the display number.

:<span class=component>-popupwindow (Windows only)</span>:The window will be created as a a pop-up window (without a frame).

:<span class=component>-screen-width (Linux & Windows only)</span>:Overrides the default screen width.  This must be an integer from a supported resolution.

:<span class=component>-screen-height (Linux & Windows only)</span>: Overrides the default screen height.  This must be an integer from a supported resolution.

:<span class=component>-screen-quality (Linux only)</span>: Overrides the default screen quality.  Example usage would be: `/path/to/myGame -screen-quality Beautiful`


Editor Installer
----------------

The following options can be used when installing the Unity Editor from command line:


:<span class=component>/S (Windows only)</span>:Performs a silent (no questions asked) install.

:<span class=component>[=/D=PATH=] (Windows only)</span>:Sets the default install directory. Useful when combined with the silent install option.


###Example usage

Install Unity silently to E:\Development\Unity.

__Windows:__  
`[=UnitySetup.exe /S /D=E:\Development\Unity=]`
