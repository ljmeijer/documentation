Playstation3: Memory
====================


The console has a total of 256MB of System (Main) Memory and 256MB of Video Memory. The following is a general overview of the memory reserved by Unity PS3:

* The size of EBOOT.BIN (Unity Player)
* The size of media/managed folder which contains .SPRX and .SDAT files that hold your game (AOT'd code + metadata). - The code size is printed in the console when building the player
* 512KB for fragment shader instances (for patching).
* 4MB for geometry ringbuffer - used by SPU skinning.
* 3MB for RSX command buffer.
* 3MB for init time modules.
* Whatever is set at Sys Modules Reserve (MB) in the PS3 publishing settings.

Memory recommendations
----------------------

* _'Non Power of Two Textures (NPOT)_'
Unity keeps a padded to next pow2 and a scaled to next pow2 version in order to achieve pixel perfect rendering in GUIs. Avoid using NPOT textures as much as possible.

* _'Non uniform scaled meshes_'
The source mesh is kept untouched and then for each instance it will create a VBO that will hold the scaled data.

* _'HideFlags.DontSave flag_'
Assets with HideFlags.DontSave are never freed by Unity and the responsability to free them is on the user - you have to call DestroyImmediate on them in OnDestroy / OnDisable depending on yourscript. - this one is typically the cause for leaks when switching levels.

* _'Uncompressed sounds / Non-streamed sounds_'
This can take a significant amount of memory. Try to use compressed sounds or streaming when possible.

* _'GPU and CPU synchronization_'
Due to the fact that the PS3 GPU runs asynchronously from the CPU (GPU can be several frames behind the CPU), all the resources touched by the GPU have to be delayed deleted. This means that all the buffers (textures, shaders, meshes, bos etc) that are deleted / changed have to be kept persistent for the duration of the frame - the freeing of dynamic resource for the previous frame is happening after the flip.  
  
Each of these dynamic resources are being duplicated for for every frame the GPU lags behind the CPU ( currently this is locked at 1) so atm there is a penalty of 1 extra resource being kept:  

    * _'Meshes_' with non-uniform-scale.
    * _'Textures_' that are changed from script or c++ code.
    * _'Meshes_' that are changed from script or c++ code.
    * _'Skinned meshes_' modified from script.
    * _'Cloth meshes._'
    * _'Dynamic arrays_' (particles, text, gui).
