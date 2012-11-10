Debugging
=========


###Script debugging with MonoDevelop
Coming soon.

###Crashes
1. [Xbox Watson](#Watson)
1. [Crash Dumps](#CrashDumps)
1. [Explicit Null Checks](#ExplicitNullChecks)
1. [Script Debugging with Mono Develop](#MonoDevelop)
---- 

<a id="Watson"></a>Xbox Watson
------------------------------

Keeping Xbox Watson attached to the kit you're testing on is always a good idea for the visibility of debug output.
If your project crashes, you will get output similar to this: `Exception : 4177526784 3221225477 2281767608 FirstChance`. Here's how to interpret it:
1. Convert it to hex to get `Exception : 0xF9000000 0xC0000005 0x880102B8 FirstChance`.
1. The second value is the exception type (i.e. 0xC0000005 is EXCEPTION_ACCESS_VIOLATION).
1. The third value is the instruction address (i.e. 0x880102B8).
1. Look for previous output mentioning loaded DLLs, i.e.: `Loaded DLL Assembly-CSharp.dll.xex (\Device\Harddisk0\Partition1\DEVKIT\Unity\Media\Managed\Assembly-CSharp.dll.xex); Mapped 0x88000000 thru 0x88030000`
1. If the instruction address is in the mapped range of a DLL, it's the culprit.
1. This method is not very informative.

<a id="CrashDumps"></a>Crash Dumps
----------------------------------

Crash dumps are saved on your devkit (DEVKIT\dumps) if Watson is not attached, otherwise dumps can be saved directly to your pc. Once a crash dump is on your development machine it can be examined like this:
1. Open the dump in Visual Studio.
1. Start debugging.
1. Load symbols for your managed code from BUILD_TARGET\Media\Managed.
1. Examine the callstack, etc.
* _Known issue:_ Visual Studio currently displays only the top function when in compiled script code.
* _Note_: Make sure to save 'MiniDump with heap' otherwise symbols will not load.

<a id="ExplicitNullChecks"></a>Explicit Null Checks
---------------------------------------------------

In case you're only interested in hunting down your null ref bugs, this is your best bet. Enabling the feature will:
1. Throw a NullReferenceException.
1. Output the _managed_ callstack, i.e.:
`[F9000000:] EXCEPTION handling: NullReferenceException`
`NullReferenceException: A null value was found where an object instance was required.`
`  at MyScript.BadFunction () [0x00023] in C:\MyExample\Assets\MyScript.cs:19 `
`  at MyScript.Start () [0x00000] in C:\MyExample\Assets\MyScript.cs:23 `
_Note that NullReferenceException will NOT work in non-development(Release) builds._

<a id="DebugShadersUPDB"></a>Debugging shaders via PIX (Automatic UPDB generation)
----------------------------------------------------------------------------------

To enable PIX debugging of shaders.
1. In the Windows system registry (regedit), create a DumpShaderPdbDir string registry entry in the HKEY_CURRENT_USER\Software\Microsoft\XenonSDK\ subkey. Within the registry entry, specify a directory on your PC where UPDB files will be automatically generated.
1. In Unity re-import the .shaders files (Shader opcode generation occurs during import time not at build time).
1. Build and run your Unity project.
1. Launch PIX and perform a "Record GPU" [ctrl+G]
1. Launch the PIX analysis app [F5]
1. Select the DrawIndexPrimitive of interest and select Shaders tab.
Periodic clearing of the UPDB folder might be required.


###u40 Details
<a id="MonoDevelop"></a>Script Debugging with MonoDevelop
---------------------------------------------------------

1. __Detach Xbox Watson!__ Script debugging does not work if a debugger is attached.
1. Enable script debugging in the build settings window.
1. Build and run your project.
1. Attach MonoDevelop to an instance of "XenonPlayer".
1. Use as normal.
1. Known issues:
    1. Floating point registers may be trampled in the current version. Take care when debugging around plugin invocation code that uses floating point values.
