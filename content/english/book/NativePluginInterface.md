Low-level Native Plugin Interface
=================================


In addition to the basic script interface, [Native Code Plugins](Plugins.md) in Unity can receive callbacks when certain events happen. This is mostly used to implement low-level rendering in your plugin and enable it to work with Unity's multithreaded rendering.

__Note:__ The rendering callbacks to plugins are not currently supported on mobile platforms.

Access to the Graphics Device
-----------------------------


A plugin can receive notification about events on the graphics device by exporting a `UnitySetGraphicsDevice` function. This will be called when the graphics device is created, before it is destroyed, and also before and after the device is "reset" (this only happens with Direct3D 9). The function has parameters which will receive the device pointer, device type and the kind of event that is taking place.

    // If exported by a plugin, this function will be called when graphics device is created, destroyed,
    // and before and after it is reset (ie, resolution changed).
    extern "C" void EXPORT_API __UnitySetGraphicsDevice__ (void* device, int deviceType, int eventType);

Possible values for deviceType:

    enum GfxDeviceRenderer {
        kGfxRendererOpenGL = 0,              // OpenGL
        kGfxRendererD3D9 = 1,                // Direct3D 9
        kGfxRendererD3D11 = 2,               // Direct3D 11
        kGfxRendererGCM = 3,                 // Sony PlayStation 3 GCM
        kGfxRendererNull = 4,                // "null" device (used in batch mode)
        kGfxRendererHollywood = 5,           // Nintendo Wii
        kGfxRendererXenon = 6,               // Xbox 360
        kGfxRendererOpenGLES = 7,            // OpenGL ES 1.1
        kGfxRendererOpenGLES20Mobile = 8,    // OpenGL ES 2.0 mobile variant
        kGfxRendererMolehill = 9,            // Flash 11 Stage3D
        kGfxRendererOpenGLES20Desktop = 10,  // OpenGL ES 2.0 desktop variant (i.e. NaCl)
    };

Possible values for eventType:

    enum GfxDeviceEventType {
        kGfxDeviceEventInitialize = 0,
        kGfxDeviceEventShutdown = 1,
        kGfxDeviceEventBeforeReset = 2,
        kGfxDeviceEventAfterReset = 3,
    };


Plugin Callbacks on the Rendering Thread
----------------------------------------


Rendering in Unity can be multithreaded if the platform and number of available CPUs will allow for it. When multithreaded rendering is used, the rendering API commands happen on a thread which is completely separate from the one that runs MonoBehaviour scripts. Consequently, it is not always possible for your plugin to start doing some rendering immediately, since might interfere with whatever the render thread is doing at the time.

In order to do __any__ rendering from the plugin, you should call [GL.IssuePluginEvent](ScriptRef:GL.IssuePluginEvent.html) from your script, which will cause your plugin to be called from the render thread. For example, if you call GL.IssuePluginEvent from the camera's OnPostRender function, you get a plugin callback immediately after the camera has finished rendering.

    // If exported by a plugin, this function will be called for GL.IssuePluginEvent script calls.
    // The function will be called on a rendering thread; note that when multithreaded rendering is used,
    // the render thread WILL BE DIFFERENT from the main thread, on which all scripts & other game logic are executed!
    // You have responsibility for ensuring any necessary synchronization with other plugin script calls takes place.
    extern "C" void EXPORT_API __UnityRenderEvent__ (int eventID);


Example
-------



###u30 Details
An example of a low-level rendering plugin __[can be downloaded here](Attach:RenderingPluginExample.zip.md)__. This simply draws a rotating triangle from C++ code after all regular rendering is done. The project works with Windows (Visual Studio 2008) and Mac OS X (Xcode 3.2) and uses Direct3D 9 or OpenGL depending on the platform. Direct3D 9 code part also demonstrates how to handle "lost" devices.


###u40 Details
An example of a low-level rendering plugin __[can be downloaded here](Attach:RenderingPluginExample40.zip.md)__. It demonstrates two things:
* Renders a rotating triangle from C++ code after all regular rendering is done.
* Fills a procedural texture from C++ code, using Texture.GetNativeTexturePtr to access it.

The project works with Windows (Visual Studio 2008) and Mac OS X (Xcode 3.2) and uses Direct3D 9, Direct3D 11 or OpenGL depending on the platform. Direct3D 9 code part also demonstrates how to handle "lost" devices.

