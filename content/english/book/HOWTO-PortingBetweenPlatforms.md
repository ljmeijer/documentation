Porting a Project Between Platforms
===================================


Most of Unity's API and project structure is identical for all supported platforms and in some cases a project can simply be rebuilt to run on different devices. However, fundamental differences in the hardware and deployment methods mean that some parts of a project may not port between platforms without change. Below are details of some common cross-platform issues and suggestions for solving them.


Input
-----


The most obvious example of different behaviour between platforms is in the input methods offered by the hardware. 


###Keyboard and joypad

The <span class=keyword>Input.GetAxis</span> function is very convenient on desktop platforms as a way of consolidating keyboard and joypad input. However, this function doesn't make sense for the mobile platforms which rely on touchscreen input. Likewise, the standard desktop keyboard input doesn't port over to mobiles well for anything other than typed text. It is worthwhile to add a layer of abstraction to your input code if you are considering porting to other platforms in the future. As a simple example, if you were making a driving game then you might create your own input class and wrap the Unity API calls in your own functions:-


````
// Returns values in the range -1.0 .. +1.0 (== left .. right).
function Steering() {
	return Input.GetAxis("Horizontal");
}


// Returns values in the range -1.0 .. +1.0 (== accel .. brake).
function Acceleration() {
	return Input.GetAxis("Vertical");
}


var currentGear: int;

// Returns an integer corresponding to the selected gear.
function Gears() {
	if (Input.GetKeyDown("p"))
		currentGear++;
	else if (Input.GetKeyDown("l"))
		currentGear--;
	
	return currentGear;
}
````


One advantage of wrapping the API calls in a class like this is that they are all concentrated in a single source file and are consequently easy to locate and replace. However, the more important idea is that you should design your input functions according to the logical meaning of the inputs in your game. This will help to isolate the rest of the game code from the specific method of input used with a particular platform. For example, the Gears function above could be modified so that the actual input comes from touches on the screen of a mobile device. Using an integer to represent the chosen gear works fine for all platforms, but mixing the platform-specific API calls with the rest of the code would cause problems. You may find it convenient to use platform dependent compilation to combine the different implementation of the input functions in the same source file and avoid manual swaps.


###Touches and clicks

The <span class=keyword>Input.GetMouseButtonXXX</span> functions are designed so that they have a reasonably obvious interpretation on mobile devices even though there is no "mouse" as such. A single touch on the screen is reported as a left click and the <span class=keyword>Input.mousePosition</span> property gives the position of the touch as long as the finger is touching the screen. This means that games with simple mouse interaction can often work transparently between the desktop and mobile platforms. Naturally, though, the conversion is often much less straightforward than this. A desktop game can make use of more than one mouse button and a mobile game can detect multiple touches on the screen at a time.

As with API calls, the problem can be managed partly by representing input with logical values that are then used by the rest of the game code. For example, a pinch gesture to zoom on a mobile device might be replaced by a plus/minus keystroke on the desktop; the input function could simply return a float value specifying the zoom factor. Likewise, it might be possible to use a two-finger tap on a mobile to replace a right button click on the desktop. However, if the properties of the input device are an integral part of the game then it may not be possible to remodel them on a different platform. This may mean that game cannot be ported at all or that the input and/or gameplay need to be modified extensively.



###Accelerometer, compass, gyroscope and GPS

These inputs derive from the mobility of handheld devices and so may not have any meaningful equivalent on the desktop. However, some use cases simply mirror standard game controls and can be ported quite easily. For example, a driving game might implement the steering control from the tilt of a mobile device (determined by the accelerometer). In cases like this, the input API calls are usually fairly easy to replace, so the accelerometer input might be replaced by keystrokes, say. However, it may be necessary to recalibrate inputs or even vary the difficulty of the game to take account of the different input method. Tilting a device is slower and eventually more strenuous than pressing keys and may also make it harder to concentrate on the display. This may result in the game's being more difficult to master on a mobile device and so it may be appropriate to slow down gameplay or allow more time per level. This will require the game code to be designed so that these factors can be adjusted easily.


Memory, storage and CPU performance
-----------------------------------


Mobile devices inevitably have less storage, memory and CPU power available than desktop machines and so a game may be difficult to port simply because its performance is not acceptable on lower powered hardware. Some resource issues can be managed but if you are pushing the limits of the hardware on the desktop then the game is probably not a good candidate for porting to a mobile platform.


###Movie playback

Currently, mobile devices are highly reliant on hardware support for movie playback. The result is that playback options are limited and certainly don't give the flexibility that the MovieTexture asset offers on desktop platforms. Movies can be played back fullscreen on mobiles but there isn't any scope for using them to texture objects within the game (so it isn't possible to display a movie on a TV screen within the game, for example). In terms of portability, it is fine to use movies for introductions, cutscenes, instructions and other simple pieces of presentation. However, if movies need to be visible within the game world then you should consider whether the mobile playback options will be adequate. 


###Storage requirements

Video, audio and even textures can use a lot of storage space and you may need to bear this in mind if you want to port your game. Storage space (which often also corresponds to download time) is typically not an issue on desktop machines but this is not the case with mobiles. Furthermore, mobile app stores often impose a limit on the maximum size of a submitted product. It may require some planning to address these concerns during the development of your game. For example, you may need to provide cut-down versions of assets for mobiles in order to save space. Another possibility is that the game may need to be designed so that large assets can be downloaded on demand rather than being part of the initial download of the application.


###Automatic memory management

The recovery of unused memory from "dead" objects is handled automatically by Unity and often happens imperceptibly on desktop machines. However, the lower memory and CPU power on mobile devices means that garbage collections can be more frequent and the time they take can impinge more heavily on performance (causing unwanted pauses in gameplay, etc). Even if the game runs in the available memory, it may still be necessary to optimise code to avoid garbage collection pauses. More information can be found on our [memory management page](UnderstandingAutomaticMemoryManagement.md).


###CPU power

A game that runs well on a desktop machine may suffer from poor framerate on a mobile device simply because the mobile CPU struggles with the game's complexity. Extra attention may therefore need to be paid to code efficiency when a project is ported to a mobile platform. A number of simple steps to improve efficiency are outlined on [this page](iphone-performance.md) in our manual.
