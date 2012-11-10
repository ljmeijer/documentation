Optimizations
=============


Just like on PCs, mobile platforms like iOS and Android have devices of various levels of performance. You can easily find a phone that’s 10x more powerful for rendering than some other phone.
Quite easy way of scaling:
1. Make sure it runs okay on baseline configuration
1. Use more eye-candy on higher performing configurations:
    * Resolution
    * Post-processing
    * MSAA
    * Anisotropy
    * Shaders
    * Fx/particles density, on/off

Focus on GPUs
-------------


Graphics performance is bound by fillrate, pixel and geometric complexity (vertex count). All three of these can be reduced if you can find a way to cull more renderers. Occlusion culling and could help here. Unity will automatically cull objects outside the viewing frustum.

On mobiles you’re essentially fillrate bound (fillrate = screen pixels * shader complexity * overdraw), and over-complex shaders is the most common cause of problems. So use mobile shaders that come with Unity or design your own but make them as simple as possible. If possible simplify your pixel shaders by moving code to vertex shader.

If reducing the Texture Quality in Quality Settings makes the game run faster, you are probably limited by memory bandwidth. So compress textures, use mipmaps, reduce texture size, etc.

LOD (Level of Detail) – make objects simpler or eliminate them completely as they move further away. The main goal would be to reduce the number of draw calls.

###Good practice

Mobile GPUs have huge constraints in how much heat they produce, how much power they use, and how large or noisy they can be. So compared to the desktop parts, mobile GPUs have way less bandwidth, low ALU performance and texturing power. The architectures of the GPUs are also tuned to use as little bandwidth & power as possible.

Unity is optimized for OpenGL ES 2.0, it uses GLSL ES (similar to HLSL) shading language. Built in shaders are most often written in HLSL (also known as Cg). This is cross compiled into GLSL ES for mobile platforms. You can also write GLSL directly if you want to, but doing that limits you to OpenGL-like platforms (e.g. mobile + Mac) since there currently are no GLSL->HLSL translation tools. When you use float/half/fixed types in HLSL, they end up highp/mediump/lowp precision qualifiers in GLSL ES.

Here is the checklist for good practice:
1. Keep the number of materials as low as possible. This makes it easier for Unity to batch stuff.
1. Use texture atlases (large images containing a collection of sub-images) instead of a number of individual textures. These are faster to load, have fewer state switches, and are batching friendly.
1. Use _Renderer.sharedMaterial_ instead of _Renderer.material_ if using texture atlases and shared materials.
1. Forward rendered pixel lights are expensive.
    * Use light mapping instead of realtime lights where ever possible.
    * Adjust pixel light count in quality settings. Essentially only the directional light should be per pixel, everything else - per vertex. Certainly this depends on the game.
1. Experiment with Render Mode of Lights in the Quality Settings to get the correct priority.
1. Avoid Cutout (alpha test) shaders unless really necessary.
1. Keep Transparent (alpha blend) screen coverage to a minimum.
1. Try to avoid situations where multiple lights illuminate any given object.
1. Try to reduce the overall number of shader passes (Shadows, pixel lights, reflections).
1. Rendering order is critical. In general case:
    1. fully opaque objects roughly front-to-back.
    1. alpha tested objects roughly front-to-back.
    1. skybox.
    1. alpha blended objects (back to front if needed).
1. Post Processing is expensive on mobiles, use with care.
1. Particles: reduce overdraw, use the simplest possible shaders.
1. Double buffer for Meshes modified every frame:
````

void Update (){
  // flip between meshes
  bufferMesh = on ? meshA : meshB;
  on = !on;
  bufferMesh.vertices = vertices; // modification to mesh
  meshFilter.sharedMesh = bufferMesh;
}

````

###Sharer optimizations

Checking if you are fillrate-bound is easy: does the game run faster if you decrease the display resolution? If yes, you are limited by fillrate.

Try reducing shader complexity by the following methods:
* Avoid alpha-testing shaders; instead use alpha-blended versions.
* Use simple, optimized shader code (such as the “Mobile” shaders that ship with Unity).
* Avoid expensive math functions in shader code (pow, exp, log, cos, sin, tan, etc). Consider using pre-calculated lookup textures instead.
* Pick lowest possible number precision format (float, half, fixedin Cg) for best performance.

Focus on CPUs
-------------


It is often the case that games are limited by the GPU on pixel processing. So they end up having unused CPU power, especially on multicore mobile CPUs. So it is often sensible to pull some work off the GPU and put it onto the CPU instead (Unity does all of these): mesh skinning, batching of small objects, particle geometry updates.

These should be used with care, not blindly. If you are not bound by draw calls, then batching is actually worse for performance, as it makes culling less efficient and makes more objects affected by lights!

###Good practice

* Don’t use more than a few hundred draw calls per frame on mobiles.
* FindObjectsOfType (and Unity getter properties in general) are very slow, so use them sensibly.
* Set the Static property on non-moving objects to allow internal optimizations like static batching.
* Spend lots of CPU cycles to do occlusion culling and better sorting (to take advantage of Early Z-cull).

###Physics

Physics can be CPU heavy. It can be profiled via the Editor profiler. If Physics appears to take too much time on CPU:
* Tweak _Time.fixedDeltaTime_ (in Project settings -> Time) to be as high as you can get away with. If your game is slow moving, you probably need less fixed updates than games with fast action. Fast paced games will need more frequent calculations, and thus _fixedDeltaTime_ will need to be lower or a collision may fail.
* Physics.solverIterationCount (Physics Manager).
* Use as little Cloth objects as possible.
* Use Rigidbodies only where necessary.
* Use primitive colliders in preference mesh colliders.
* Never ever move a static collider (ie a collider without a Rigidbody) as it causes a big performance hit.
    * Shows up in Profiler as “Static Collider.Move” but actual processing is in _Physics.Simulate_
    * If necessary, add a RigidBody and set _isKinematic_ to true.
* On Windows you can use NVidia’s AgPerfMon profiling tool set to get more details if needed.


####android Details
###GPU

These are the popular mobile architectures. This is both different hardware vendors than in PC/console space, and very different GPU architectures than the “usual” GPUs. 
* ImgTec PowerVR SGX - Tile based, deferred: render everything in small tiles (as 16x16), shade only visible pixels
* NVIDIA Tegra - Classic: Render everything
* Qualcomm Adreno - Tiled: Render everything in tile, engineered in large tiles (as 256k).  Adreno 3xx can switch to traditional.
* ARM Mali Tiled: Render everything in tile, engineered in small tiles (as 16x16)

Spend some time looking into different rendering approaches and design your game accordingly. Pay especial attention to sorting. Define the lowest end supported devices early in the dev cycle. Test on them with the profiler on as you design your game.

Use platform specific texture compression.

###Further reading
* PowerVR SGX Architecture Guide [http://imgtec.com/powervr/insider/powervr-sdk-docs.asp](http://imgtec.com/powervr/insider/powervr-sdk-docs.asp.md)
* Tegra GLES2 feature guide [http://developer.download.nvidia.com/tegra/docs/tegra_gles2_development.pdf](http://developer.download.nvidia.com/tegra/docs/tegra_gles2_development.pdf.md)
* Qualcomm Adreno GLES performance guide [http://developer.qualcomm.com/file/607/adreno200performanceoptimizationopenglestipsandtricksmarch10.pdf](http://developer.qualcomm.com/file/607/adreno200performanceoptimizationopenglestipsandtricksmarch10.pdf.md)
* Engel, Rible [http://altdevblogaday.com/2011/08/04/programming-the-xperia-play-gpu-by-wolfgang-engel-and-maurice-ribble/](http://altdevblogaday.com/2011/08/04/programming-the-xperia-play-gpu-by-wolfgang-engel-and-maurice-ribble/.md)
* ARM Mali GPU Optimization guide [http://www.malideveloper.com/developer-resources/documentation/index.php](http://www.malideveloper.com/developer-resources/documentation/index.php.md)

###Screen resolution

###Android version



####ios Details
###GPU

Only PowerVR architecture (tile based deferred) to be concerned about. 
* ImgTec PowerVR SGX. Tile based, deferred: render everything in tiles, shade only visible pixels
* ImgTec .PowerVR MBX. Tile based, deferred, fixed function - pre iPhone 4/iPad 1 devices

This means:
* Mipmaps are not so necessary.
* Antialiasing and aniso are cheap enough, not needed on iPad 3 in some cases

And cons:
* If vertex data per frame (number of vertices * storage required after vertex shader) exceeds the internal buffers allocated by the driver, the scene has to be “split” which costs performance. The driver might allocate a larger buffer after this point, or you might need to reduce your vertex count. This becomes apparent on iPad2 (iOS 4.3) at around 100 thousand vertices with quite complex shaders.
* TBDR needs more transistors allocated for the tiling and deferred parts, leaving conceptually less transistors for “raw performance”. It’s very hard (i.e. practically impossible) to get GPU timing for a draw call on TBDR, making profiling hard.

###Further reading
* PowerVR SGX Architecture Guide [http://imgtec.com/powervr/insider/powervr-sdk-docs.asp](http://imgtec.com/powervr/insider/powervr-sdk-docs.asp.md)

###Screen resolution

###iOS version

Dynamic Objects
---------------


###Asset Bundles

* Asset Bundles are cached on a device to a certain limit
* Create using the Editor API
* Load
    * Using WWW API: WWW.LoadFromCacheOrDownload
    * As a resource: AssetBundle.CreateFromMemory or AssetBundle.CreateFromFile
* Unload
    * AssetBundle.Unload
        * There is an option to unload the bundle, but keep the loaded asset from it
        * Also can kill all the loaded assets even if they’re referenced in the scene
    * Resources.UnloadUnusedAssets
        * Unloads all assets no longer referenced in the scene. So remember to kill references to the assets you don’t need.
        * Public and static variables are never garbage collected.
    * Resources.UnloadAsset
        * Unloads a specific asset from memory. It can be reloaded from disk if needed.


####Is there any limitation for download numbers of Assetbundle at the same time on iOS? (e.g Can we download over 10 assetbundles safely at the same time(or every frame)? )


Downloads are implemented via async API provided by OS, so OS decides how many threads need to be created for downloads. When launching multiple concurrent downloads you should keep in mind total device bandwidth it can support and amount of free memory. Each concurrent download allocates its own temporal buffer, so you should be careful there to not run out of memory.

###Resources


* Assets need to be recognized by Unity to be placed in a build.
* Add .bytes file extension to any raw bytes you want Unity to recognize as a binary data.
* Add .txt file extension to any text files you want Unity to recognize as a text asset
* Resources are converted to a platform format at a build time.
* Resources.Load()

Silly issues checklist
----------------------



* Textures without proper compression
    * Different solutions for different cases, but be sure to compress textures unless you’re sure you should not.
    * ETC/RGBA16 - default for android
        * but can tweak depending on the GPU vendor
        * best approach is to use ETC where possible
        * alpha textures can use two ETC files with one channel being for alpha
    * PVRTC - default for iOS
        * good for most cases
* Textures having Get/Set pixels enabled - doubles the footprint, uncheck unless Get/Set is needed
* Textures loaded from JPEG/PNGs on the runtime will be uncompressed
* Big mp3 files marked as decompress on load
* Additive scene loading
* Unused Assets that remain uncleaned in memory
    * Static fields
    * not unloaded asset bundles
* If it randomly crashes, try on a devkit or a device with 2 GB memory (like Ipad 3).
Sometimes there’s nothing in the console, just a random crash
* Fast script call and stripping may lead to random crashes on iOS. Try without them.

