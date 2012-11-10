Debugging
=========


###What is not available?
* You can't debug managed code with MonoDevelop due couple of reasons:
    * Wii player uses Mono library for consoles which doesn't have the necessary changes for the debugger to work.
    * For the debugger to work the network connection is required between the PC and the NDEV kit, only wireless connection is available, though at the moment it's not clear if it's possible to adapt connection like this for debugger needs.
* You can't use Unity Editor profiler with Wii player due above mentioned network connection limitation, though in the near future it should be possible to use Nintendo Wii Profiler.

###Most of the debugging features are only available when the wii player is built with "Development Build" checkbox on (in Build Settings).

###Debugging with development player:

* Additional files:
> When you build the development player, you get additionally two files in <ProjectFolder>\Pacakge :
    * UnityWii.map;
    * UnityWii.minimap (preparsed version of UnityWii.map and is used by the development player when crash occurs to output stactraces with resolved function names instead of addresses);

###Special keys:


|    |    |
|:---|:---|
|!Key|!Description|
|Hold 1 + Press B on the first Wii Controller.|Outputs the memory statistics|
|Hold 2 + Press B on the first Wii Controller.|Enters memory debugging mode|


###Understanding the crash output:
````

ErrorHandler: Received DSI handler from Mono
ErrorHandler: DSI exception caught
ErrorHandler: Trying to open UnityWii.minimap
ErrorHandler: Crash occured in 0x80c4c9ec:  ScriptNullRef:Func1 () + 0x30 (IL Offset: 0xc) (0x80c4c9bc 0x80c4ca24) [0x90027300 - Unity Root Domain]
ErrorHandler: ---------------------------------------------------------------
ErrorHandler: Outputing stacktrace:
ErrorHandler: 0x808c28f8:   0x808c2918    0x80c4c9e4  ScriptNullRef:Func1 () + 0x28 (IL Offset: 0xc) (0x80c4c9bc 0x80c4ca24) [0x90027300 - Unity Root Domain]
ErrorHandler: 0x808c2918:   0x808c2938    0x80c4c9a0  ScriptNullRef:Start () + 0x24 (IL Offset: 0x6) (0x80c4c97c 0x80c4c9b0) [0x90027300 - Unity Root Domain]
ErrorHandler: 0x808c2938:   0x808c2998    0x80c4c77c  (wrapper runtime-invoke) object:runtime_invoke_void__this__ (object,intptr,intptr,intptr) + 0x80 (IL Offset: 0x0) (0x80c4c6fc 0x80c4c7fc) [0x90027300 - Unity Root Domain]
ErrorHandler: 0x808c2998:   0x808c29d8    0x804bb91c mono_jit_runtime_invoke
ErrorHandler: 0x808c29d8:   0x808c29f8    0x8046f51c mono_runtime_invoke
ErrorHandler: 0x808c29f8:   0x808c2a88    0x8021876c InvokeMethodOrCoroutineChecked__13MonoBehaviourFP10MonoMethodPFPvPP13MonoException_P10MonoObjectP10MonoObject
ErrorHandler: 0x808c2a88:   0x808c2a98    0x80217c7c Start__13MonoBehaviourFv
ErrorHandler: 0x808c2a98:   0x808c2ae8    0x801a18f4 Update__18DelayedCallManagerFi
ErrorHandler: 0x808c2ae8:   0x808c2b18    0x801f4bc0 PlayerLoop__Fbb
ErrorHandler: 0x808c2b18:   0x808c2b88    0x80277ebc main
ErrorHandler: 0x808c2b88:   0xffffffff    0x80006474 __start
ErrorHandler: It seems crash occured in Mono, try to output exception:

Unhandled Exception: System.NullReferenceException: Object reference not set to an instance of an object

````

It was produced by the following code:

````

using UnityEngine;
using System.Collections;

public class ScriptNullRef : MonoBehaviour 
{
     void Func1()
     {
        MonoBehaviour b = null;
        Debug.Log("1");
        b.ToString();   // DSI exception occurs here..
        Debug.Log("2");
     }
     void Start () 
     {
        Func1();
     }
     void Update ()
     {
     }
}

````

Most common exceptions:
* DSI exception (0x00300) - the data memory access cannot be performed, for ex., when trying to read from NULL pointer.
* ISI exception (0x00400) - an attempt to fetch the next instruction to be executed fails, for ex., function pointer is NULL, and you're trying to call that function.
* FPE exception (0x00800) - floating point exception, for ex., division by zero __(Note: this will be disabled in the builds which are released after 2011-03-30, because floating point exceptions shouldn't make the program crash, only the warning message will be outputted in the log)__

When exception occurs, the development player tries to open UnityWii.minimap and tries to resolve the stacktrace.
There are two types of functions in Unity Wii:
* JIT (Just-In-Time) functions - produced by mono whenever you're calling managed code function for the first time, these functions cannot be resolved using the UnityWii map files, and if you're using the CodeWarrior for debugging, you will only see hex addresses in the stactrace. Development player resolves these functions using a special mono function.
* Native code functions - simple c/c++ functions, you can find all of these functions in the UnityWii.map.

It's easy to distinguish which function is which by just looking at the function description:
1. JIT function - "ErrorHandler: 0x808c28f8:   0x808c2918    0x80c4c9e4  ScriptNullRef:Func1 () + 0x28 (IL Offset: 0xc) (0x80c4c9bc 0x80c4ca24) [0x90027300 - Unity Root Domain]"
1. Simple function - "ErrorHandler: 0x808c2998:   0x808c29d8    0x804bb91c mono_jit_runtime_invoke"

If the exception occurs in the managed code, you can find the exact code location where it occurred - meaning the exact instruction:
* Open ildasm.exe (usually it's located in \Program Files\Microsoft SDKs\Windows\v6.0A\Bin).
* Locate Assembly-CSharp.dll, it's should be located in <ProjectFolder>\Pacakge\Data\Managed folder, and all of your C# code goes there.
* Drag Assembly-CSharp.dll on top of the ildasm.exe, you should see something like this now:

> Attach:disam1.jpg
> We know that DSI exception occurred in ScriptNullRef:Func1, double-click on it:

> Attach:disam2.jpg

> Remember the output of the crash handler - "ErrorHandler: Crash occured in 0x80c4c9ec:  ScriptNullRef:Func1 () + 0x30 __(IL Offset: 0xc)__ (0x80c4c9bc 0x80c4ca24) [0x90027300 - Unity Root Domain]".
> So the crash occurred near - "IL_000c:  ldloc.0".
