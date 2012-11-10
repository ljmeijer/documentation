Using Mono DLLs in a Unity Project
==================================


Usually, scripts are kept in a project as source files and compiled by Unity whenever the source changes. However, it is also possible to compile a script to a __dynamically linked library__ (DLL) using an external compiler. The resulting DLL can then be added to the project and the classes it contains can be attached to objects just like normal scripts.

It is generally much easier to work with scripts than DLLs in Unity. However, you may have access to third party Mono code which is supplied in the form of a DLL. When developing your own code, you may be able to use compilers not supported by Unity (F#, for example) by compiling the code to a DLL and adding it to your Unity project. Also, you may want to supply Unity code without the source (for an Asset Store product, say) and a DLL is an easy way to do this.


Creating a DLL
--------------


To create a DLL, you will first need a suitable compiler. Not all compilers that produce .NET code are guaranteed to work with Unity, so it may be wise to test the compiler with some available code before doing significant work with it. If the DLL contains no code that depends on the Unity API then you can simply compile it to a DLL using the appropriate compiler options. If you do want to use the Unity API then you will need to make Unity's own DLLs available to the compiler. On a Mac, these are contained in the application bundle (you can see the internal structure of the bundle by using the Show Package Contents command from the contextual menu; right click or ctrl-click the Unity application):-

The path to the Unity DLLs will typically be

	/Applications/Unity/Unity.app/Contents/Frameworks/Managed/

...and the two DLLs are called UnityEngine.dll and UnityEditor.dll.

On Windows, the DLLs can be found in the folders that accompany the Unity application. The path will typically be

	C:\Program Files (x86)\Unity\Editor\Data\Managed

...while the names of the DLLs are the same as for Mac OS.

The exact options for compiling the DLL will vary depending on the compiler used. As an example, the command line for the Mono C# compiler, __mcs__, might look like this on Mac OS:-

	mcs -r:/Applications/Unity/Unity.app/Contents/Frameworks/Managed/UnityEngine.dll -target:library ClassesForDLL.cs 

Here, the _-r_ option specifies a path to a library to be included in the build, in this case the UnityEngine library. The _-target_ option specifies which type of build is required; the word "library" is used to select a DLL build. Finally, the name of the source file to compile is _ClassesForDLL.cs_ (it is assumed that this file is in the current working folder, but you could specify the file using a full path if necessary). Assuming all goes well, the resulting DLL file will appear shortly in the same folder as the source file.

Using the DLL
-------------


Once compiled, the DLL file can simply be dragged into the Unity project like any other asset. The DLL asset has a foldout triangle which can be used to reveal the separate classes inside the library. Classes that derive from MonoBehaviour can be dragged onto Game Objects like ordinary scripts. Non-MonoBehaviour classes can be used directly from other scripts in the usual way.


![](http://docwiki.hq.unity3d.com/uploads/Main/DLLScreenshot.png)  
_A folded-out DLL with the classes visible_

