Flash: Building & Running
=========================


The following is a step-by-step guide to build and run a new project exported to Flash.

1. Create your Unity content.
1. Choose File->Build Settings to bring up the Build Settings dialog and add your scene(s).
1. Change the Platform to Flash Player
1. Target Player can be left as the default. This option enables you to change the target Flash Player based on the features you require (see http://www.adobe.com/support/documentation/en/flashplayer/releasenotes.html for details).
1. Tick Development Build.  (This causes Unity to __not__ compress the final SWF file.  Not compressing will make the build faster, and also, the SWF file will not have to be decompressed before being run in the Flash Player.  Note that an empty scene built using the Development Build option will be around 16M in size, compared to around 2M compressed.)
1. Press the Build button.


![](http://docwiki.hq.unity3d.com/uploads/Main/FlashExportBuildSettings.png)  

Unity will build a SWF file at the location you choose.  Additionally it will create the following files:
* an html file - Use this to view your Flash-built content.
* a swfobject.js file - Handles checking for the Flash Player and browser integration.
* an embeddingapi.swc file.

To view your Flash-built content open the html file. Do not open the SWF file directly.

Build-and-run will create the same files, launch your default browser and load the generated html file.

The embeddingapi.swc file created in the build allows you to load the SWF in your own project. Embedding the Unity content in a standard flash project allows you to do GUI in Flash. This type of Flash integration will of course not work in any of the other build targets.

As with the other build targets, there are Player settings that you can specify. Most of the Flash settings are shared with other platforms. Note that the resolution for the content is taken from the Standalone player settings.

We allow for a Flash API that gives you texture handles, which in combination with the swc embedding will give you means to do webcam, video, vector graphics from flash as textures.

  

The Build Process
-----------------

The Unity Flash Publisher attempts to convert scripts from C#/UnityScript into ActionScript. In this process, there can be two kinds of conversion errors:
* errors during conversion of unity code to ActionScript
* errors while compiling the converted code.

Errors during conversion will point to the original files and will have the familiar UnityScript error messages with file names and line numbers. 

Errors during the compilation of the converted ActionScript will take you to the message in the generated ActionScript code (with filenames ending with `.as`).

  

Debugging Converted ActionScript Code
-------------------------------------

During a build, the converted ActionScript (`.as`) files are stored within your project folder in:
* /Temp/StagingArea/Data/ConvertedDotNetCode/

If you encounter errors with your SWF (at runtime or during a build), it can be useful to look at this converted code.

It is possible that any ActionScript errors at compilation time will not be easily understood. Just remember that the ActionScript is generated from your game script code, so any changes you need to make will be in your original code and not the converted ActionScript files.

  

Building for a specific Flash Player version
--------------------------------------------


The dropdown box in the build settings window will enable you to choose which Flash Player version you wish to target. This will always default to the lowest supported Flash Player version (currently 11.2) upon creating/reopening your Unity project.

If you wish to build for a specific Flash Player version you can do so by creating an editor script to perform the build for you. In order to do this, you can specify a [FlashBuildSubtarget](http://docs.unity3d.com/Documentation/ScriptReference/FlashBuildSubtarget.html.md) in your [EditorUserBuildSettings](http://docs.unity3d.com/Documentation/ScriptReference/EditorUserBuildSettings.html.md) when building to Flash from an editor script. For example:

````

EditorUserBuildSettings.flashBuildSubtarget = FlashBuildSubtarget.Flash11dot2;
BuildPipeline.BuildPlayer(..., ..., BuildTarget.FlashPlayer, BuildOptions.Development);

````

  

Example Build Errors and Warnings
---------------------------------


Below are some common errors/warnings you may encounter when using the Flash export. We also have sections on the [Forums](http://forum.unity3d.com/forums/36-Flash-Development.md) and [Answers](http://answers.unity3d.com/questions/topics/flash.html.md) dedicated to Flash export which may be of help if your error is not listed below.

###Unable to find Java
````

Error building Player: Exception: Compiling SWF Failed: Unable to launch Java - is the Java Runtime Environment (JRE) installed?

````
If you encounter the above error at build time, please [install the 32-bit JRE](http://www.oracle.com/technetwork/java/javase/install-windows-141940.html.md) and try again. 

  

###'TerrainCollider' is not supported
````

'TerrainCollider' is not supported when building for FlashPlayer. 
'TerrainData' is not supported when building for FlashPlayer. 
Asset: 'Assets/New Terrain.asset'

````
The terrain feature is not supported when building for the FlashPlayer target.  All [un-supported features](flash-whatssupported.md) will generate a similar warning.  Note that the build will continue, however, the unsupported feature will be missing from the final SWF.

  

###Unboxing
````

Error: Call to a possibly undefined method RuntimeServices_UnboxSingle_Object through a reference with static type Class.

````
This is likely because the conversion between types that is defined on the UnityScript side is not defined for our Flash Publisher.  Any time you see an error that refers to `Unbox` it means a type conversion is required but cannot be found. In order to resolve these issues:
* Do not forget to use `#pragma strict`, and take care of all "implicit downcast" warning messages.
* The rule of thumb is to avoid runtime casts from Object to primitive types (int, float, etc.). Also prefer containers with explicit types to generic ones, for example:
    * System.Collections.Generic.List.<float> instead of Array
    * Dictionary<string, float> instead of Hashtable

  

###UnauthorizedAccessException
````

Error building Player: UnauthorizedAccessException: Access to the path "Temp/StagingArea/Data/ConvertedDotNetCode/global" is denied.

````
If Unity-generated ActionScript files are open in a text editor, Unity may refuse to build issuing this error. To fix this, please close the ActionScript files and allow Unity to overwrite them.
