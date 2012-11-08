iOS Hardware Guide
==================


Hardware models
---------------


The following table summarizes iOS hardware available in devices of various generations:

(:table width=100%:)
(:cellnr:)

###[iPhone Models](http://en.wikipedia.org/wiki/IPhone#Model_comparison.md)


###Original iPhone
* Screen: 320x480 pixels, LCD at 163ppi
* ARM11, 412 Mhz CPU
(:div style="float:right; padding:5px; color:#BBBBBB; font-size:10px; width:310px;":)
%thumb width=280px float=right padding=5px%Attach:skiSafari.jpg
Fixed-function graphics (no fancy shaders), very slow CPU and GPU.
(:divend:)
* PowerVR MBX Lite 3D graphics processor
    * Slow
* 128MB of memory
* 2 megapixel camera

###iPhone 3G
* Screen: 320x480 pixels, LCD at 163ppi
* ARM11, 412 Mhz CPU
* PowerVR MBX Lite 3D graphics processor
    * Slow
* 128MB of memory
* 2 megapixel camera
* GPS support

(:cellnr:)

###iPhone 3GS
* Screen: 320x480 pixels, LCD at 163ppi
* ARM Cortex A8, 600 MHz CPU
* PowerVR SGX535 graphics processor
    * Shader perfomance at native resolution, compared to iPad2:
(:div style="margin-left:80px; padding:0px; background: #7bc94d; width:200px; height:12px; overflow:hidden; display:inline-block;":)
%thumb width:200px padding-left:84px%Attach:bar.png
(:divend:)
    * Raw shader perfomance, compared to iPad3:
(:div style="margin-left:80px; padding:0px; background: #7bc94d; width:200px; height:12px; overflow:hidden; display:inline-block;":)
%thumb width:200px padding-left:23px%Attach:bar.png
(:divend:)
* 256MB of memory
* 3 megapixel camera with video capture capability
(:div style="float:right; padding:5px; color:#BBBBBB; font-size:10px; width:310px;":)
%thumb width=300px float=right padding=5px%Attach:shadowgun2.jpg
Shader-capable hardware, per-pixel-lighting (bumpmaps) can only be on small portions of the screen at once.
Requires scripting optimization for complex games. This is the average hardware of the app market as of July 2012
(:divend:)
* GPS support
* Compass support

###iPhone 4
* Screen: 960x640 pixels, LCD at 326 ppi, 800:1 contrast ratio.
* Apple A4
    * 1Ghz ARM Cortex-A8 CPU
    * PowerVR SGX535 GPU
        * Shader perfomance at native resolution, compared to iPad2:
(:div style="margin-left:120px; padding:0px; background: #7bc94d; width:200px; height:12px; overflow:hidden; display:inline-block;":)
%thumb width:200px padding-left:36px%Attach:bar.png
(:divend:)
        * Raw shader perfomance, compared to iPad3:
(:div style="margin-left:120px; padding:0px; background: #7bc94d; width:200px; height:12px; overflow:hidden; display:inline-block;":)
%thumb width:200px padding-left:23px%Attach:bar.png
(:divend:)
* 512MB of memory
* Cameras
    * Rear 5.0 MP backside illuminated CMOS image sensor with 720p HD video at 30 fps and LED flash
    * Front 0.3 MP (VGA) with geotagging, tap to focus, and 480p SD video at 30 fps
* GPS support
* Compass Support

(:div style="float:right; padding:5px; color:#BBBBBB; font-size:10px; width:250px;":)
%thumb width=240px float=right padding=5px%Attach:csrCar.jpg
The iPhone 4S, with the new A5 chip, is capable of rendering complex shaders throughout the entire screen. Even image effects may be possible. However, optimizing your shaders is still crucial. But if your game isn't trying to push limits of the device, optimizing scripting and gameplay is probably as much of a waste of time on this generation of devices as it is on PC.
(:divend:)

###iPhone 4S
* Screen: 960x640 pixels, LCD at 326 ppi, 800:1 contrast ratio.
* Apple A5
    * Dual-Core 1Ghz ARM Cortex-A9 MPCore CPU
    * Dual-Core PowerVR SGX543MP2 GPU
        * Shader perfomance at native resolution, compared to iPad2:
(:div style="margin-left:120px; padding:0px; background: #7bc94d; width:200px; height:12px; overflow:hidden; display:inline-block;":)
%thumb width:200px padding-left:196px%Attach:bar.png
(:divend:)
        * Raw shader perfomance, compared to iPad3:
(:div style="margin-left:120px; padding:0px; background: #7bc94d; width:200px; height:12px; overflow:hidden; display:inline-block;":)
%thumb width:200px padding-left:105px%Attach:bar.png
(:divend:)
* 512MB of memory
* Cameras
    * Rear 5.0 MP backside illuminated CMOS image sensor with 720p HD video at 30 fps and LED flash
    * Front 0.3 MP (VGA) with geotagging, tap to focus, and 480p SD video at 30 fps
* GPS support
* Compass Support

###[iPod Touch Models](http://en.wikipedia.org/wiki/IPod_Touch#Specifications.md)

(:cellnr:)

(:div style="float:right; padding:5px; color:#BBBBBB; font-size:10px; width:212px;":)
%thumb width=200px float=right padding=5px%Attach:tripletown.jpg
Fixed-function graphics (no fancy shaders), very slow CPU and GPU.
(:divend:)

###iPod Touch 1st generation
* Screen: 320x480 pixels, LCD at 163ppi
* ARM11, 412 Mhz CPU
* PowerVR MBX Lite 3D graphics processor
    * Slow
* 128MB of memory

###iPod Touch 2nd generation
* Screen: 320x480 pixels, LCD at 163ppi
* ARM11, 533 Mhz CPU
* PowerVR MBX Lite 3D graphics processor
    * Slow
* 128MB of memory
* Speaker and microphone

(:cellnr:)

(:div style="float:right; padding:5px; color:#BBBBBB; font-size:10px; width:242px;":)
%thumb width=230px float=right padding=5px%Attach:csrRacing.jpg
Shader-capable hardware, per-pixel-lighting (bumpmaps) can only be on small portions of the screen at once.
Requires scripting optimization for complex games. This is the average hardware of the app market as of July 2012
(:divend:)

###iPod Touch 3rd generation
* Comparable to iPhone 3GS

###iPod Touch 4th generation
* Comparable to iPhone 4

(:cellnr:)

###[iPad Models](http://en.wikipedia.org/wiki/IPad#Technical_specifications.md)

(:div style="float:right; padding:5px; color:#BBBBBB; font-size:10px; width:250px;":)
%thumb width=240px float=right padding=5px%Attach:airmail.jpg
Similar to iPod Touch 4th Generation and iPhone 4.
(:divend:)

###iPad
* Screen: 1024x768 pixels, LCD at 132 ppi, LED-backlit.
* Apple A4
    * 1Ghz MHz ARM Cortex-A8 CPU
    * PowerVR SGX535 GPU
        * Shader perfomance at native resolution, compared to iPad2:
(:div style="margin-left:120px; padding:0px; background: #7bc94d; width:200px; height:12px; overflow:hidden; display:inline-block;":)
%thumb width:200px padding-left:30px%Attach:bar.png
(:divend:)
        * Raw shader perfomance, compared to iPad3:
(:div style="margin-left:120px; padding:0px; background: #7bc94d; width:200px; height:12px; overflow:hidden; display:inline-block;":)
%thumb width:200px padding-left:23px%Attach:bar.png
(:divend:)
* Wifi + Blueooth + (3G Cellular HSDPA, 2G cellular EDGE on the 3G version)
* Accelerometer, ambient light sensor, magnetometer (for digital compass)
* Mechanical keys: Home, sleep, screen rotation lock, volume.

(:cellnr:)
(:div style="float:right; padding:5px; color:#BBBBBB; font-size:10px; width:250px;":)
%thumb width=240px float=right padding=5px%Attach:deadtrigger.jpg
The A5 can do full screen bumpmapping, assuming the shader is simple enough. However, it is likely that your game will perform best with bumpmapping only on crucial objects. Full screen image effects still out of reach. Scripting optimization less important.
(:divend:)

###iPad 2
* Screen: 1024x768 pixels, LCD at 132 ppi, LED-backlit.
* Apple A5
    * Dual-Core 1Ghz ARM Cortex-A9 MPCore CPU
    * Dual-Core PowerVR SGX543MP2 GPU
        * Shader perfomance at native resolution, compared to iPad2:
(:div style="margin-left:120px; padding:0px; background: #7bc94d; width:200px; height:12px; overflow:hidden; display:inline-block;":)
%thumb width:200px padding-left:200px%Attach:bar.png
(:divend:)
        * Raw shader perfomance, compared to iPad3:
(:div style="margin-left:120px; padding:0px; background: #7bc94d; width:200px; height:12px; overflow:hidden; display:inline-block;":)
%thumb width:200px padding-left:125px%Attach:bar.png
(:divend:)
* Same as Previous

(:cellnr:)

(:div style="float:right; padding:5px; color:#BBBBBB; font-size:10px; width:250px;":)
%thumb width=240px float=right padding=5px%Attach:bladeslinger.jpg
The iPad 3 has been shown to be capable of render-to-texture effects such as reflective water and fullscreen image effects. However, optimized shaders are still crucial. But if your game isn't trying to push limits of the device, optimizing scripting and gameplay is probably as much of a waste of time on this generation of devices as it is on PC.
(:divend:)

###iPad 3
* Screen: 2048 × 1536 pixels, LCD at 264 ppi, LED-backlit.
* Apple A5X
    * Dual-Core 1Ghz ARM Cortex-A9 MPCore CPU
    * Quad-Core PowerVR SGX543MP4 GPU
        * Shader perfomance at native resolution, compared to iPad2:
(:div style="margin-left:120px; padding:0px; background: #7bc94d; width:200px; height:12px; overflow:hidden; display:inline-block;":)
%thumb width:200px padding-left:174px%Attach:bar.png
(:divend:)
        * Raw shader perfomance, compared to iPad3:
(:div style="margin-left:120px; padding:0px; background: #7bc94d; width:200px; height:12px; overflow:hidden; display:inline-block;":)
%thumb width:200px padding-left:200px%Attach:bar.png
(:divend:)


(:tableend:)

Graphics Processing Unit and Hidden Surface Removal
---------------------------------------------------

The iPhone/iPad graphics processing unit (GPU) is a Tile-Based Deferred Renderer. In contrast with most GPUs in desktop computers, the iPhone/iPad GPU focuses on minimizing the work required to render an image as early as possible in the processing of a scene.  That way, only the visible pixels will consume processing resources.

The GPU's frame buffer is divided up into tiles and rendering happens tile by tile. First, triangles for the whole frame are gathered and assigned to the tiles. Then, visible fragments of each triangle are chosen.  Finally, the selected triangle fragments are passed to the rasterizer (triangle fragments occluded from the camera are rejected at this stage).

In other words, the iPhone/iPad GPU implements a <span class=keyword>Hidden Surface Removal</span> operation at reduced cost. Such an architecture consumes less memory bandwidth, has lower power consumption and utilizes the texture cache better. Tile-Based Deferred Rendering allows the device to reject occluded fragments before actual rasterization, which helps to keep overdraw low.

For more information see also:-
* [POWERVR MBX Technology Overview](http://www.imgtec.com/factsheets/SDK/PowerVR%20Technology%20Overview.1.0.2e.External.pdf.md)
* [Apple Notes on iPhone/iPad GPU and OpenGL ES](http://developer.apple.com/iphone/library/documentation/3DDrawing/Conceptual/OpenGLES_ProgrammingGuide/OpenGLESPlatforms/OpenGLESPlatforms.html#//apple_ref/doc/uid/TP40008793-CH106-SW1.md)
* [Apple Performance Advices for OpenGL ES in General](http://developer.apple.com/library/ios/#documentation/3DDrawing/Conceptual/OpenGLES_ProgrammingGuide/Performance/Performance.html.md)
* [Apple Performance Advices for OpenGL ES Shaders](http://developer.apple.com/library/ios/#documentation/3DDrawing/Conceptual/OpenGLES_ProgrammingGuide/BestPracticesforShaders/BestPracticesforShaders.html.md)

###MBX series

Older devices such as the original iPhone, iPhone 3G and iPod Touch 1st and 2nd Generation are equipped with the <span class=keyword>MBX</span> series of GPUs. The MBX series supports only <span class=keyword>OpenGL ES1.1</span>, the fixed function Transform/Lighting pipeline and two textures per fragment.

###SGX series

Starting with the iPhone 3GS, newer devices are equipped with the <span class=keyword>SGX</span> series of GPUs. The SGX series features support for the <span class=keyword>OpenGL ES2.0</span> rendering API and vertex and pixel shaders. The Fixed-function pipeline is not supported natively on such GPUs, but instead is emulated by generating vertex and pixel shaders with analogous functionality on the fly.

The SGX series fully supports MultiSample anti-aliasing.


###Texture Compression

The only texture compression format supported by iOS is <span class=keyword>PVRTC</span>. PVRTC provides support for RGB and RGBA (color information plus an alpha channel) texture formats and can compress a single pixel to two or four bits.

The PVRTC format is essential to reduce the memory footprint and to reduce consumption of memory bandwidth (ie, the rate at which data can be read from memory, which is usually very limited on mobile devices).


###Vertex Processing Unit
The iPhone/iPad has a dedicated unit responsible for vertex processing which runs calculations in parallel with rasterization. In order to achieve better parallelization, the iPhone/iPad processes vertices one frame ahead of the rasterizer.


Unified Memory Architecture
---------------------------

Both the CPU and GPU on the iPhone/iPad share the same memory. The advantage is that you don't need to worry about running out of video memory for your textures (unless, of course, you run out of main memory too). The disadvantage is that you share the same memory bandwidth for gameplay and graphics. The more memory bandwidth you dedicate to graphics, the less you will have for gameplay and physics.


Multimedia CoProcessing Unit
----------------------------

The iPhone/iPad main CPU is equipped with a powerful SIMD (Single Instruction, Multiple Data) coprocessor supporting either the <span class=keyword>VFP</span> or the <span class=keyword>NEON</span> architecture. The Unity iOS run-time takes advantage of these units for multiple tasks such as calculating skinned mesh transformations, geometry batching, audio processing and other calculation-intensive operations.
