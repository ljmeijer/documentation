Measuring Performance with the Built-in Profiler
================================================



##ios Details
On iOS, it's disabled by default so to enable it, you need to open the Unity-generated XCode project, select the `iPhone_Profiler.h` file and change the line

````
#define ENABLE_INTERNAL_PROFILER 0
````

to

````
#define ENABLE_INTERNAL_PROFILER 1
````

Select <span class=menu>Run->Console</span> in the XCode menu to display the output console (GDB) and then run your project. Unity will output statistics to the console window every thirty frames.


##android Details
On Android, it is enabled by default. Just make sure Development Build is checked in the player settings when building, and the statistics should show up in logcat when run on the device. To view logcat, you need <span class=component>`adb`</span> or the Android Debug Bridge. Once you have that, simply run the shell command <span class=component>`adb logcat`</span>.

Here's an example of the built-in profiler's output.

````

iPhone/iPad Unity internal profiler stats:
cpu-player>    min:  9.8   max: 24.0   avg: 16.3
cpu-ogles-drv> min:  1.8   max:  8.2   avg:  4.3
cpu-waits-gpu> min:  0.8   max:  1.2   avg:  0.9
cpu-present>   min:  1.2   max:  3.9   avg:  1.6
frametime>     min: 31.9   max: 37.8   avg: 34.1
draw-call #>   min:   4    max:   9    avg:   6     | batched:    10
tris #>        min:  3590  max:  4561  avg:  3871   | batched:  3572
verts #>       min:  1940  max:  2487  avg:  2104   | batched:  1900
player-detail> physx:  1.2 animation:  1.2 culling:  0.5 skinning:  0.0 batching:  0.2 render: 12.0 fixed-update-count: 1 .. 2
mono-scripts>  update:  0.5   fixedUpdate:  0.0 coroutines:  0.0 
mono-memory>   used heap: 233472 allocated heap: 548864  max number of collections: 1 collection total duration:  5.7

````
All times are measured in milliseconds per frame. You can see the minimum, maximum and average times over the last thirty frames.

General CPU Activity
--------------------


|    |
|:---|
|<span class=component>cpu-player</span> |Displays the time your game spends executing code inside the Unity engine and executing scripts on the CPU.
|<span class=component>cpu-ogles-drv</span> |Displays the time spent executing OpenGL ES driver code on the CPU. Many factors like the number of draw calls, number of internal rendering state changes, the rendering pipeline setup and even the number of processed vertices can have an effect on the driver stats.
|<span class=component>cpu-waits-gpu</span> |Displays the time the CPU is idle while waiting for the GPU to finish rendering. If this number exceeds 2-3 milliseconds then your application is most probably fillrate/GPU processing bound.  If this value is too small then the profile skips displaying the value.
|<span class=component>msaa-resolve</span> |The time taken to apply anti-aliasiing.
|<span class=component>cpu-present</span> |The amount of time spent executing the presentRenderbuffer command in OpenGL ES.
|<span class=component>frametime</span> |Represents the overall time of a game frame. Note that iOS hardware is always locked at a 60Hz refresh rate, so you will always get multiples times of ~16.7ms  (1000ms/60Hz = ~16.7ms).

Rendering Statistics
--------------------


|    |
|:---|
|<span class=component>draw-call #</span> |The number of draw calls per frame. Keep it as low as possible.
|<span class=component>tris #</span> |Total number of triangles sent for rendering.
|<span class=component>verts #</span> |Total number of vertices sent for rendering. You should keep this number below 10000 if you use only static geometry but if you have lots of skinned geometry then you should keep it much lower.
|<span class=component>batched</span> |Number of draw-calls, triangles and vertices which were automatically batched by the engine. Comparing these numbers with draw-call and triangle totals will give you an idea how well is your scene prepared for batching. Share as many materials as possible among your objects to improve batching.

Detailed Unity Player Statistics
--------------------------------

The <span class=component>player-detail</span> section provides a detailed breakdown of what is happening inside the engine:-

|    |
|:---|
|<span class=component>physx</span> |Time spent on physics.
|<span class=component>animation</span> |Time spent animating bones.
|<span class=component>culling</span> |Time spent culling objects outside the camera frustum.
|<span class=component>skinning</span> |Time spent applying animations to skinned meshes.
|<span class=component>batching</span> |Time spent batching geometry. Batching dynamic geometry is considerably more expensive than batching static geometry.
|<span class=component>render</span> |Time spent rendering visible objects.
|<span class=component>fixed-update-count</span> |Minimum and maximum number of FixedUpdates executed during this frame. Too many FixedUpdates will deteriorate performance considerably. There are some simple guidelines to set a good value for the fixed time delta [here](#FixedDeltaTime).

Detailed Scripts Statistics
---------------------------

The <span class=component>mono-scripts</span> section provides a detailed breakdown of the time spent executing code in the Mono runtime:

|    |
|:---|
|<span class=component>update</span> |Total time spent executing all Update() functions in scripts.
|<span class=component>fixedUpdate</span> |Total time spent executing all FixedUpdate() functions in scripts.
|<span class=component>coroutines</span> |Time spent inside script coroutines.

Detailed Statistics on Memory Allocated by Scripts
--------------------------------------------------

The <span class=component>mono-memory</span> section gives you an idea of how memory is being managed by the Mono garbage collector:

|    |
|:---|
|<span class=component>allocated heap</span> |Total amount of memory available for allocations. A garbage collection will be triggered if there is not enough memory left in the heap for a given allocation. If there is still not enough free memory even after the collection then the allocated heap will grow in size.
|<span class=component>used heap</span> |The portion of the <span class=component>allocated heap</span> which is currently used up by objects. Every time you create a new class instance (not a struct) this number will grow until the next garbage collection.
|<span class=component>max number of collections</span> |Number of garbage collection passes during the last 30 frames.
|<span class=component>collection total duration</span> |Total time (in milliseconds) of all garbage collection passes that have happened during the last 30 frames.

