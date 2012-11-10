Getting Started with Native Client Development
==============================================


Native Client (_NaCl_) is a new technology by Google which allows you to embed native executable code in web pages to allow deployment of very performant web apps without requiring the install of plugins. Currently, NaCl is only supported in Google Chrome on Windows, Mac OS X and Linux (with Chrome OS support being worked on), but the technology is open source, so it could be ported to other browser platforms in the future.

Unity 3.5 offers support to run Unity Web Player content (.unity3d files) using NaCl to allow content to be run without requiring a plugin install in Chrome. This is an early release - it should be stable to use, but it does not yet support all features supported in the Unity Web Player, because NaCl is an evolving platform, and does not support everything we can do in a browser plugin.

Building and Testing games on NaCl
----------------------------------


Building and testing games on NaCl is very simple. You need to have Google Chrome installed. Simply choose "Web Player" in Build Settings, and tick the "Enable NaCl" checkbox. This will make sure the generated unity3d file can be run on NaCl (by including GLSL ES shaders needed for NaCl, and by disabling dynamic fonts not supported by NaCl), and install the NaCl runtime and a html file to launch the game in NaCl. If you click Build & Run, Unity will install your player as an app in Chrome and launch it automatically.

Shipping Games with NaCl
------------------------


In its current state, NaCl is not enabled for generic web pages in Chrome by default. While you can embed a NaCl player into any web page, and direct your users to manually enable NaCl in chrome://flags, the only way to currently ship NaCl games and have them work out of the box is to deploy them on the [Chrome Web Store](https://chrome.google.com/webstore.md) (for which NaCl is enabled by default). Note that the Chrome Web Store is fairly unrestrictive, and allows you to host content embedded into your own web site, or to use your own payment processing system if you like. The plan is that this restriction will be lifted when Google has finished a new technology called portable NaCl (PNaCl), which lets you ship executables as LLVM bitcode, thus making NaCl apps independent of any specific CPU architectures. Then NaCl should be enabled for any arbitrary web site.

###Notes on Build size

When you make a NaCl build, you will probably notice that the _unity_nacl_files_3.x.x_ folder is very large, over 100 MB. If you are wondering, if all this much data needs to be downloaded on each run for NaCl content, the answer is generally "no". There are two ways to serve apps on the Chrome Web Store, as a hosted or packaged app. If you serve your content as a packaged app, all data will be downloaded on install as a compressed archive, which will then be stored on the user's disk. If you serve your content as a hosted app, data will be downloaded from the web each time. But the nacl runtime will only download the relevant architecture (i686 or x86_64) from the _unity_nacl_files_3.x.x_ folder, and when the web server is configured correctly, the data will be compressed on transfer, so the actual amount of data to be transferred should be around 10 MB (less when physics stripping is used). The _unity_nacl_files_3.x.x_ folder contains a _.htaccess_ file to set up Apache to compress the data on transfer. If  you are using a different web server, you may have to set this up yourself.

Limitations in NaCl
-------------------


NaCl does not yet support all the features in the regular Unity Web Player. Support for many of these will be coming in future versions of Chrome and Unity. Currently, NaCl these features are unsupported by NaCl:

* Webcam Textures
* Joystick Input
* Caching
* Substances
* Dynamic Fonts
* Networking of any kind other then WWW class.
* The Profiler does not work, because it requires a network connection to the Editor.
* As with the standard webplayer plugin, native C/C++ plugins are not currently supported by NaCl.

The following features are supported, but have some limitations:

* Depth textures:
>Depth textures are required for real-time shadows and other effects. Depth textures are supported in Unity NaCl, but Chrome's OpenGL ES 2.0 implementation does not support the required extensions on windows, so Depth textures will only work on OS X and Linux.

* Other graphics features:
>NaCl uses OpenGL ES 2.0, which does not support all extensions included in the normal OpenGL. This means that some features relying on extensions, such as linear and HDR lighting will not currently work on NaCl. Also Shaders need to be able to compile as GLSL shaders. Currently, not all built-in Unity shaders support this, for instance, the Screen Space Ambient Occlusion is not supported on GLSL.

* Cursor locking:
>Cursor locking is supported, but only in fullscreen mode. Cursor locking in windowed mode is planned for a later Chrome release.

* NullReferenceExceptions:
>NaCl does not have support for hardware exception handling. That means that a NullReferenceException in scripting code results in a crash in NaCl. You can, however pass `softexceptions="1"` to the embed parameters (set automatically by Unity when building a development player), to tell mono to do checking for NullReferences in software, which results in slower script execution but no crashes.

While Google does not give any system requirements for NaCl other then requiring at least OS X 10.6.7 on the Mac, we've found it to not work very well with old systems - especially when these systems have old GPUs or graphics drivers, or a low amount of installed main memory. If you need to target old hardware, you may find that the Web Player will give you a better experience.

Fullscreen mode:
----------------


Fullscreen mode is supported by setting Screen.fullScreen, but you can only enter fullscreen mode in a frame where the user has released the mouse button. NaCl will not actually change the hardware screen resolution, which is why Screen.resolutions will only ever return the current desktop resolution. However, Chrome supports rendering into smaller back buffers, and scaling those up when blitting to the screen. So, requesting smaller resolutions then the desktop resolution is generally supported for fullscreen mode, but will result in GPU based scaling, instead of changing the screen mode.

WWW class:
----------


The WWW class is supported in NaCl, but follows different security policies then the Unity Web Player. While the Unity Web Player uses [crossdomain.xml](SecuritySandbox.md) policy files, similar to flash, Unity NaCl has to follow the cross-origin security model followed by NaCl, documented [here](http://www.w3.org/TR/cors/.md). Basically, in order to access html documents on a different domain then the player is hosted, you need to configure your web server to send a `Access-Control-Allow-Origin` respond header for the requests, which allows the domain hosting the player.

Communicating with browser javascript in NaCl
---------------------------------------------


Interacting with the web page using JavaScript is supported, and is very similar to [using the Unity Web Player](UnityWebPlayerandbrowsercommunication.md), with one exception: The syntax for sending messages to Unity from html javascript is different, because it has to go through the NaCl module. When you are using the default Unity-generated html, then this code will work:

`document.getElementById('UnityEmbed').postMessage("GameObject.Message(parameter)");`

Logging
-------


Since NaCl does not allow access to the user file system, it will not write log files. Instead it outputs all logging to stdout. To see the player logs from NaCl: 

* Do a Build & Run in the edtior once to make sure your game is installed into Chrome as an app.
* On Mac OS X, start Chrome from a Terminal, and start the app by clicking on it's icon. You should see the Unity player log output in the terminal.
* On Windows it's the same, but you need to set the NACL_EXE_STDOUT and NACL_EXE_STDERR environment variables, and start Chrome with the --no-sandbox option. See Google's [documentation](https://sites.google.com/a/chromium.org/dev/nativeclient/how-tos/debuggingtips.md).
