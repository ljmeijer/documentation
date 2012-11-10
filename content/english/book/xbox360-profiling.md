Profiling
=========


###Unity Profiler
Unity editor can attach to a development player running on any Xbox on the network.
1. Run your build.
1. Activate _Windows->Profiler_.
1. Select _XenonPlayer(YOUR_XBOX_NAME)_ as the active profiler.
1. Use the profiler as usual.

###PIX
1. [Timing Capture](#Timing)
1. [GPU Trace](#GPUTrace)
1. [CPU Trace](#CPUTrace)

---- 

<a id="Timing"></a>PIX Timing Capture
-------------------------------------

Timing capture can be used like for any normal Xbox application.

<a id="GPUTrace"></a>PIX GPU Trace
----------------------------------

GPU trace can be used like for any normal Xbox application.

<a id="CPUTrace"></a>PIX CPU Trace
----------------------------------

CPU trace can be used like for any normal Xbox application.
Navigate to "Functions->Module" tab and load any missing symbol files from BUILD_TARGET\Media\Managed.
1. Assembly* files are generated from your Unity scripts.
1. Other libraries with `AOTCompileStep` in their paths are also Unity related.
Symbol names do not match those in your scripts exactly, but they can be easily interpreted. Examples:
1. `plt_UnityEngine_Screen_get_width` is the getter of `UnityEngine.Screen.width`.
1. `MyScript_Update` is the Update function of MyScript.
1. `plt_UnityEngine_Rect__ctor_single_single_single_single` is the constructor of `UnityEngine.Rect` with 4 arguments.
