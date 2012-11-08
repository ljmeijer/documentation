Input
=====


##desktop Details

__Note:__ Keyboard, joystick and gamepad input work on the desktop versions of Unity (including webplayer and Flash) but not on mobiles.

Unity supports keyboard, joystick and gamepad input.

Virtual axes and buttons can be created in the <span class=keyword>Input Manager</span>, and end users can configure Keyboard input in a nice screen configuration dialog.


![](http://docwiki.hq.unity3d.com/uploads/Main/InputSelector.png)  

You can setup joysticks, gamepads, keyboard, and mouse, then access them all through one simple scripting interface.

From scripts, all virtual axes are accessed by their name.

Every project has the following default input axes when it's created:
* <span class=component>Horizontal</span> and <span class=component>Vertical</span> are mapped to w, a, s, d and the arrow keys.
* <span class=component>Fire1</span>, <span class=component>Fire2</span>, <span class=component>Fire3</span> are mapped to Control, Option (Alt), and Command, respectively.
* <span class=component>Mouse X</span> and <span class=component>Mouse Y</span> are mapped to the delta of mouse movement.
* <span class=component>Window Shake X</span> and <span class=component>Window Shake Y</span> is mapped to the movement of the window.


###Adding new Input Axes

If you want to add new virtual axes go to the <span class=menu>Edit->Project Settings->Input</span> menu. Here you can also change the settings of each axis.


![](http://docwiki.hq.unity3d.com/uploads/Main/InputAxis.png)  

You map each axis to two buttons on a joystick, mouse, or keyboard keys.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Name</span> |The name of the string used to check this axis from a script. |
|<span class=component>Descriptive Name</span> |Positive value name displayed in the input tab of the <span class=menu>Configuration</span> dialog for standalone builds. |
|<span class=component>Descriptive Negative Name</span> |Negative value name displayed in the Input tab of the <span class=menu>Configuration</span> dialog for standalone builds. |
|<span class=component>Negative Button</span> |The button used to push the axis in the negative direction. |
|<span class=component>Positive Button</span> |The button used to push the axis in the positive direction. |
|<span class=component>Alt Negative Button</span> |Alternative button used to push the axis in the negative direction. |
|<span class=component>Alt Positive Button</span> |Alternative button used to push the axis in the positive direction. |
|<span class=component>Gravity</span> |Speed in units per second that the axis falls toward neutral when no buttons are pressed. |
|<span class=component>Dead</span> |Size of the analog dead zone.  All analog device values within this range result map to neutral. |
|<span class=component>Sensitivity</span> |Speed in units per second that the the axis will move toward the target value.  This is for digital devices only. |
|<span class=component>Snap</span> |If enabled, the axis value will reset to zero when pressing a button of the opposite direction. |
|<span class=component>Invert</span> |If enabled, the __Negative Buttons__ provide a positive value, and vice-versa. |
|<span class=component>Type</span> |The type of inputs that will control this axis. |
|<span class=component>Axis</span> |The axis of a connected device that will control this axis. |
|<span class=component>Joy Num</span> |The connected Joystick that will control this axis. |

Use these settings to fine tune the look and feel of input. They are all documented with tooltips in the Editor as well.


###Using Input Axes from Scripts
You can query the current state from a script like this:

````
value = Input.GetAxis ("Horizontal"); 
````

An axis has a value between -1 and 1. The neutral position is 0.
This is the case for joystick input and keyboard input.

However, Mouse Delta and Window Shake Delta are how much the mouse or window moved during the last frame. This means it can be larger than 1 or smaller than -1 when the user moves the mouse quickly.

It is possible to create multiple axes with the same name. When getting the input axis, the axis with the largest absolute value will be returned. This makes it possible to assign more than one input device to one axis name. For example, create one axis for keyboard input and one axis for joystick input with the same name. If the user is using the joystick, input will come from the joystick, otherwise input will come from the keyboard. This way you don't have to consider where the input comes from when writing scripts.

###Button Names

To map a key to an axis, you have to enter the key's name in the <span class=component>Positive Button</span> or <span class=component>Negative Button</span> property in the <span class=keyword>Inspector</span>.

The names of keys follow this convention:
* Normal keys: "a", "b", "c" ...
* Number keys: "1", "2", "3",  ...
* Arrow keys: "up", "down", "left", "right"
* Keypad keys: "[1]", "[2]", "[3]", "[+]", "[equals]"
* Modifier keys: "right shift", "left shift", "right ctrl", "left ctrl", "right alt", "left alt", "right cmd", "left cmd"
* Mouse Buttons: "mouse 0", "mouse 1", "mouse 2", ...
* Joystick Buttons (from any joystick): "joystick button 0", "joystick button 1", "joystick button 2",  ...
* Joystick Buttons (from a specific joystick): "joystick 1 button 0", "joystick 1 button 1", "joystick 2 button 0", ...
* Special keys: "backspace", "tab", "return", "escape", "space", "delete", "enter", "insert", "home", "end", "page up", "page down"
* Function keys: "f1", "f2", "f3", ...

The names used to identify the keys are the same in the scripting interface and the Inspector.

````
value = Input.GetKey ("a"); 
````

Mobile Input
============

On iOS and Android, the [Input](ScriptRef:Input.html) class offers access to touchscreen, accelerometer and geographical/location input.

Access to keyboard on mobile devices is provided via the [iOS keyboard](MobileKeyboard#iOS.md).
Multi-Touch Screen
------------------


The iPhone and iPod Touch devices are capable of tracking up to five fingers touching the screen simultaneously. You can retrieve the status of each finger touching the screen during the last frame by accessing the [Input.touches](ScriptRef:Input-touches.html) property array.


###android Details
Android devices don't have a unified limit on how many fingers they track. Instead, it varies from device to device and can be anything from two-touch on older devices to five fingers on some newer devices.

Each finger touch is represented by an [Input.Touch](ScriptRef:Touch.html) data structure:

|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>fingerId</span> |The unique index for a touch.
|<span class=component>position</span> |The screen position of the touch.
|<span class=component>deltaPosition</span> |The screen position change since the last frame.
|<span class=component>deltaTime</span> |Amount of time that has passed since the last state change.
|<span class=component>tapCount</span> |The iPhone/iPad screen is able to distinguish quick finger taps by the user. This counter will let you know how many times the user has tapped the screen without moving a finger to the sides. %android%Android devices do not count number of taps, this field is always 1.%%
|<span class=component>phase</span> |Describes so called "phase" or the state of the touch. It can help you determine if the touch just began, if user moved the finger or if he just lifted the finger.
|END

Phase can be one of the following:

|    |
|:---|
|<span class=component>Began</span> |A finger just touched the screen.
|<span class=component>Moved</span> |A finger moved on the screen.
|<span class=component>Stationary</span> |A finger is touching the screen but hasn't moved since the last frame.
|<span class=component>Ended</span> |A finger was lifted from the screen. This is the final phase of a touch.
|<span class=component>Canceled</span> |The system cancelled tracking for the touch, as when (for example) the user puts the device to her face or more than five touches happened simultaneously. This is the final phase of a touch.

Following is an example script which will shoot a ray whenever the user taps on the screen:
````

var particle : GameObject;
function Update () {
	for (var touch : Touch in Input.touches) {
		if (touch.phase == TouchPhase.Began) {
			// Construct a ray from the current touch coordinates
			var ray = Camera.main.ScreenPointToRay (touch.position);
			if (Physics.Raycast (ray)) {
				// Create a particle if hit
				Instantiate (particle, transform.position, transform.rotation);
			}
		}
	}
}

````

###Mouse Simulation
On top of native touch support Unity iOS/Android provides a mouse simulation. You can use mouse functionality from the standard [Input](ScriptRef:Input.html) class.

Device Orientation
------------------

Unity iOS/Android allows you to get discrete description of the device physical orientation in three-dimensional space. Detecting a change in orientation can be useful if you want to create game behaviors depending on how the user is holding the device.

You can retrieve device orientation by accessing the  [Input.deviceOrientation](ScriptRef:Input-deviceOrientation.html) property. Orientation can be one of the following:

|    |
|:---|
|<span class=component>Unknown</span> |The orientation of the device cannot be determined. For example when device is rotate diagonally.
|<span class=component>Portrait</span> |The device is in portrait mode, with the device held upright and the home button at the bottom.
|<span class=component>PortraitUpsideDown</span> |The device is in portrait mode but upside down, with the device held upright and the home button at the top.
|<span class=component>LandscapeLeft</span> |The device is in landscape mode, with the device held upright and the home button on the right side.
|<span class=component>LandscapeRight</span> |The device is in landscape mode, with the device held upright and the home button on the left side.
|<span class=component>FaceUp</span> |The device is held parallel to the ground with the screen facing upwards.
|<span class=component>FaceDown</span> |The device is held parallel to the ground with the screen facing downwards.

Accelerometer
-------------

As the mobile device moves, a built-in accelerometer reports linear acceleration
changes along the three primary axes in three-dimensional space. Acceleration
along each axis is reported directly by the hardware as G-force values. A value
of 1.0 represents a load of about +1g along a given axis while a value of -1.0
represents -1g. If you hold the device upright (with the home button at the
bottom) in front of you, the X axis is positive along the right, the Y axis is
positive directly up, and the Z axis is positive pointing toward you.

You can retrieve the accelerometer value by accessing the [Input.acceleration](ScriptRef:Input-acceleration.html) property.

The following is an example script which will move an object using the accelerometer:
````

var speed = 10.0;
function Update () {
	var dir : Vector3 = Vector3.zero;

	// we assume that the device is held parallel to the ground
	// and the Home button is in the right hand

	// remap the device acceleration axis to game coordinates:
	//  1) XY plane of the device is mapped onto XZ plane
	//  2) rotated 90 degrees around Y axis
	dir.x = -Input.acceleration.y;
	dir.z = Input.acceleration.x;

	// clamp acceleration vector to the unit sphere
	if (dir.sqrMagnitude > 1)
		dir.Normalize();

	// Make it move 10 meters per second instead of 10 meters per frame...
	dir *= Time.deltaTime;

	// Move object
	transform.Translate (dir * speed);
}

````

###Low-Pass Filter
Accelerometer readings can be jerky and noisy. Applying low-pass filtering on the signal allows you to smooth it and get rid of high frequency noise.

The following script shows you how to apply low-pass filtering to accelerometer readings:
````

var AccelerometerUpdateInterval : float = 1.0 / 60.0;
var LowPassKernelWidthInSeconds : float = 1.0;

private var LowPassFilterFactor : float = AccelerometerUpdateInterval / LowPassKernelWidthInSeconds; // tweakable
private var lowPassValue : Vector3 = Vector3.zero;
function Start () {
	lowPassValue = Input.acceleration;
}

function LowPassFilterAccelerometer() : Vector3 {
	lowPassValue = Mathf.Lerp(lowPassValue, Input.acceleration, LowPassFilterFactor);
	return lowPassValue;
}

````

The greater the value of `LowPassKernelWidthInSeconds`, the slower the filtered value will converge towards the current input sample (and vice versa). You should be able to use the `LowPassFilter()` function instead of `avgSamples()`.

###I'd like as much precision as possible when reading the accelerometer. What should I do?
Reading the [Input.acceleration](ScriptRef:Input-acceleration.html) variable does not equal sampling the hardware. Put simply, Unity samples the hardware at a frequency of 60Hz and stores the result into the variable. In reality, things are a little bit more complicated -- accelerometer sampling doesn't occur at consistent time intervals, if under significant CPU loads. As a result, the system might report 2 samples during one frame, then 1 sample during the next frame.

You can access all measurements executed by accelerometer during the frame. The following code will illustrate a simple average of all the accelerometer events that were collected within the last frame:

````

var period : float = 0.0;
var acc : Vector3 = Vector3.zero;
for (var evnt : iPhoneAccelerationEvent  in iPhoneInput.accelerationEvents) {
	acc += evnt.acceleration * evnt.deltaTime;
	period += evnt.deltaTime;
}
if (period > 0)
	acc *= 1.0/period;
return acc;

````

Further Reading
---------------


The Unity mobile input API is originally based on Apple's API. It may help to learn more about the native API to better understand Unity's Input API.
You can find the Apple input API documentation here:
* [Programming Guide: Event Handling (Apple iPhone SDK documentation)](file:///Library/Developer/Shared/Documentation/DocSets/com.apple.adc.documentation.AppleiPhone2_0.iPhoneLibrary.docset/Contents/Resources/Documents/documentation/iPhone/Conceptual/iPhoneOSProgrammingGuide/EventHandling/chapter_8_section_1.html.md)
* [UITouch Class Reference (Apple iOS SDK documentation)](file:///Library/Developer/Shared/Documentation/DocSets/com.apple.adc.documentation.AppleiPhone2_0.iPhoneLibrary.docset/Contents/Resources/Documents/documentation/UIKit/Reference/UITouch_Class/Reference/Reference.html.md)

__Note:__ The above links reference your locally installed iPhone SDK Reference Documentation and will contain native ObjectiveC code. It is not necessary to understand these documents for using Unity on mobile devices, but may be helpful to some!

<a id="iPhoneInput"></a>

###ios Details

Device geographical location
----------------------------

Device geographical location can be obtained via the [iPhoneInput.lastLocation](ScriptRef:iPhoneInput-lastLocation.html) property. Before calling this property you should start location service updates using [iPhoneSettings.StartLocationServiceUpdates()](ScriptRef:iPhoneSettings.StartLocationServiceUpdates.html) and check the service status via [iPhoneSettings.locationServiceStatus](ScriptRef:iPhoneSettings-locationServiceStatus.html). See the [scripting reference](ScriptRef:iPhoneSettings.StartLocationServiceUpdates.html) for details.

