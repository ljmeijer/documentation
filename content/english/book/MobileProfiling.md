Profiling
=========


Ports that the Unity profiler uses:
	MulticastPort : 54998
	ListenPorts : 55000 - 55511
	Multicast(unittests) : 55512 - 56023
They should be accessible from within the network node. That is, the devices that you’re trying to profile on should be able to see these ports on the machine with the Unity Editor with the Profiler on.

First steps
-----------


Unity relies on the CPU (heavily optimized for the SIMD part of it, like SSE on x86 or NEON on ARM) for skinning, batching, physics, user scripts, particles, etc. 

The GPU is used for shaders, drawcalls, image effects.

###CPU or GPU bound

* Use the internal profiler to detect the CPU and GPU ms

###Pareto analysis
A large majority of problems (80%) are produced by a few key causes (20%).

1. Use the Editor profiler to get the most problematic function calls and optimize them first.
1. Make sure the scripts run only when necessary.
    1. Use _OnBecameVisible/OnBecameInvisible_ to disable inactive objects.
    1. Use coroutines if you don’t need some scripts to run every frame.
````

// Do some stuff every frame:
void Update () {
}

//Do some stuff every 0.2 seconds:
IEnumerator Start ()_ {
   while (true) {
      yield return new WaitForSeconds (0.2f);
   }
}

````
    1. Use the _.NET System.Threading.Thread_ class to put heavy calculations to the other thread. This allows you to run on multiple cores, but Unity API is not thread-safe. So buffer inputs and results and read and assign them on the main thread.

CPU Profiling
-------------


###Profile user code

Not all of the user code is shown in the Profiler. But you can use _Profiler.BeginSample_ and _Profiler.EndSample_ to make the required user code appear in the profiler.

GPU Profiling
-------------


The Unity Editor profiler cannot show GPU data as of now. We’re working with hardware manufacturers to make it happen with the Tegra devices being the first to appear in the Editor profiler.


###ios Details
###Tools for iOS

* Unity internal profiler (not the Editor profiler).  This shows the GPU time for the whole scene.
* PowerVR PVRUniSCo shader analyzer.  See below.
* iOS: Xcode OpenGL ES Driver Instruments can show only high-level info:
    * “Device Utilization %” - GPU time spent on rendering in total. >95% means the app is GPU bound.
    * “Renderer Utilization %” - GPU time spent drawing pixels.
    * “Tiler Utilization %” - GPU time spent processing vertices.
    * “Split count” - the number of frame splits, where the vertex data didn’t fit into allocated buffers.

PowerVR is tile based deferred renderer, so it&#146;s impossible to get GPU timings per draw call. However you can get GPU times for the whole scene using Unity’s built-in profiler (the one that prints results to Xcode output). Apple’s tools currently can only tell you how busy the GPU and its parts are, but do not give times in milliseconds.

PVRUniSCo gives cycles for the whole shader, and approximate cycles for each line in the 
shader code. Windows & Mac! But it won’t match what Apple’s drivers are doing exactly anyway. Still, a good ballpark measure. 


####android Details
###Tools for Android

* Adreno (Qualcomm)
* NVPerfHUD (NVIDIA)
* PVRTune, PVRUniSCo (PowerVR)

On Tegra, NVIDIA provides excellent performance tools which does everything you want - GPU time per draw call, Cycles per shader, Force 2x2 texture, Null view rectangle, runs on Windows, OSX, Linux. PerfHUD ES does not easily work with consumer devices, you need the development board from NVIDIA.

Qualcomm provides excellent Adreno Profiler (Windows only) which is Windows only, but works with consumer devices! It features Timeline graphs, frame capture, Frame debug, API calls, Shader analyzer, live editing.

###Graphics related CPU profiling

The internal profiler gives a good overview per module:
* time spent in OpenGL ES API
* batching efficiency
* skinning, animations, particles

Memory
------


Integrate this: http://docwiki.hq.unity3d.com/internal/index.php?n=Support.MemoryUsage

There is Unity memory and mono memory. 

###Mono memory

Mono memory handles script objects, wrappers for Unity objects (game objects, assets, components, etc). Garbage Collector cleans up when the allocation does not fit in the available memory or on a _System.GC.Collect()_ call.

Memory is allocated in heap blocks. More can allocated if it cannot fit the data into the allocated block. Heap blocks will be kept in Mono until the app is closed. In other words, Mono does not release any memory used to the OS (Unity 3.x). Once you allocate a certain amount of memory, it is reserved for mono and not available for the OS. Even when you release it, it will become available internally for Mono only and not for the OS. The heap memory value in the Profiler will only increase, never decrease.

If the system cannot fit new data into the allocated heap block, the Mono calls a "GC" and can allocate a new heap block (for example, due to fragmentation).

“Too many heap sections” means you’ve run out of Mono memory (because of fragmentation or heavy usage). 

Use _System.GC.GetTotalMemory_ to get the total used Mono memory.

The general advice is, use as small an allocation as possible.

###Unity memory

Unity memory handles Asset data (Textures, Meshes, Audio, Animation, etc), Game objects, Engine internals (Rendering, Particles, Physics, etc).
Use _Profiler.usedHeapSize_ to get the total used Unity memory.

###Memory map
No tools yet but you can use the following.

* Unity Profiler - not perfect, skips stuff, but you can get an overview.  It works on the device!
* Internal profiler
    * Shows Used heap and allocated heap - see mono memory.
    * Shows the number of mono allocations per frame.
* Xcode tools - iOS
    * Xcode Instruments Activity Monitor - Real Memory column.
    * Xcode Instruments Allocations - net allocations for created and living objects.
    * VM Tracker
        * textures usually get allocated with IOKit label.
        * meshes usually go into VM Allocate.
* Make your own tool
    * _FindObjectsOfTypeAll (type : Type) : Object[]_
    * _FindObjectsOfType (type : Type): Object[]_
    * _GetRuntimeMemorySize (o : Object) : int	_
    * _GetMonoHeapSize_
    * _GetMonoUsedSize_
    * _Profiler.BeginSample/EndSample_ - profile your own code
    * _UnloadUnusedAssets () : AsyncOperation_
    * _System.GC.GetTotalMemory/Profiler.usedHeapSize_
* References to the loaded objects - There is no way to figure this out.  A workaround is to “Find references in scene” for public variables.

###Memory hiccups

* Garbage collector
    * This fires when the system cannot fit new data into the allocated heap block.
    * Don’t use _OnGUI_ on mobiles
        * It shoots several times per frame
        * It completely redraws the view.
        * It creates tons of memory allocation calls that require Garbage Collection to be invoked.
    * Creating/removing too many objects too quickly?
        * This may lead to fragmentation.
        * Use the Editor profiler to track the memory activity.
        * The internal profiler can be used to track the mono memory activity.
    * _System.GC.Collect()_ You can use this _.Net_ function when it’s ok to have a hiccup.
* New memory allocations
    * Allocation hiccups
        * Use lists of preallocated, reusable class instances to implement your own memory management scheme.
        * Don’t make huge allocations per frame, cache, preallocate instead
    * Problems with fragmentation?
        * Preallocate the memory pool.
        * Keep a List of inactive GameObjects and reuse them instead of Instantiating and Destroying them.
    * Out of mono memory
        * Profile memory activity - when does the first memory page fill up?
        * Do you really need so many gameobjects that a single memory page is not enough?
    * Use structs instead of classes for local data. Classes are stored on the heap; structs on the stack.
	
````

class MyClass {
   public int a, b, c;
}

struct MyStruct {
   public int a, b, c;
}

void Update () {
   //BAD
   // allocated on the heap, will be garbage collected later!
   MyClass c = new MyClass();
   
   //GOOD
   //allocated on the stack, no GC going to happen!
   MyStruct s = new MyStruct();
}

````

* Read the relevant section in the manual Link to http://docs.unity3d.com/Documentation/Manual/UnderstandingAutomaticMemoryManagement.html

###Out of memory crashes

At some points a game may crash with "out of memory" though it in theory it should fit in fine. When this happens compare your normal game memory footprint and the allocated memory size when the crash happens. If the numbers are not similar, then there is a memory spike. This might be due to:
* Two big scenes being loaded at the same time - use an empty scene between two bigger ones to fix this.
* Additive scene loading - remove unused parts to maintain the memory size.
* Huge asset bundles loaded to the memory
* Loading via WWW or instantiating (a huge amount of) big objects like:
    * Textures without proper compression (a no go for mobiles).
    * Textures having Get/Set pixels enabled. This requires an uncompressed copy of the texture in memory.
    * Textures loaded from JPEG/PNGs at runtime are essentially uncompressed.
    * Big mp3 files marked as decompress on loading.
* Keeping unused assets in weird caches like static monobehavior fields, which are not cleared when changing scenes.

