Input Manager
=============


##desktop Details
The <span class=keyword>Input Manager</span> is where you define all the different input axes and game actions for your project.


![](http://docwiki.hq.unity3d.com/uploads/Main/InputSetAll.png)  
_The Input Manager_

To see the Input Manager choose: <span class=menu>Edit->Project Settings->Input</span>.


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Axes</span> |Contains all the defined input axes for the current project: <span class=component>Size</span> is the number of different input axes in this project, <span class=component>Element 0, 1, ...</span> are the particular axes to modify. |
|<span class=component>Name</span> |The string that refers to the axis in the game launcher and through scripting. |
|<span class=component>Descriptive Name</span> |A detailed definition of the <span class=component>Positive Button</span> function that is displayed in the game launcher. |
|<span class=component>Descriptive Negative Name</span> |A detailed definition of the <span class=component>Negative Button</span> function that is displayed in the game launcher. |
|<span class=component>Negative Button</span> |The button that will send a negative value to the axis. |
|<span class=component>Positive Button</span> |The button that will send a positive value to the axis. |
|<span class=component>Alt Negative Button</span> |The secondary button that will send a negative value to the axis. |
|<span class=component>Alt Positive Button</span> |The secondary button that will send a positive value to the axis. |
|<span class=component>Gravity</span> |How fast will the input recenter. Only used when the <span class=component>Type</span> is <span class=component>key / mouse button</span>. |
|<span class=component>Dead</span> |Any positive or negative values that are less than this number will register as zero.  Useful for joysticks. |
|<span class=component>Sensitivity</span> |For keyboard input, a larger value will result in faster response time. A lower value will be more smooth. For Mouse delta the value will scale the actual mouse delta. |
|<span class=component>Snap</span> |If enabled, the axis value will be immediately reset to zero after it receives opposite inputs. Only used when the <span class=component>Type</span> is <span class=component>key / mouse button</span>. |
|<span class=component>Invert</span> |If enabled, the positive buttons will send negative values to the axis, and vice versa. |
|<span class=component>Type</span> |Use <span class=component>Key / Mouse Button</span> for any kind of buttons, Mouse Movement for mouse delta and scrollwheels, <span class=component>Joystick Axis</span> for analog joystick axes and <span class=component>Window Movement</span> for when the user shakes the window. |
|<span class=component>Axis</span> |Axis of input from the device (joystick, mouse, gamepad, etc.) |
|<span class=component>Joy Num</span> |Which joystick should be used. By default this is set to retrieve the input from all joysticks. This is only used for input axes and not buttons. |


Details
-------


All the axes that you set up in the Input Manager serve two purposes:

* They allow you to reference your inputs by axis name in scripting
* They allow the players of your game to customize the controls to their liking

All defined axes will be presented to the player in the game launcher, where they will see its name, detailed description, and default buttons.  From here, they will have the option to change any of the buttons defined in the axes.  Therefore, it is best to write your scripts making use of axes instead of individual buttons, as the player may want to customize the buttons for your game.


![](http://docwiki.hq.unity3d.com/uploads/Main/Input-GameLauncher.png)  
_The game launcher's Input window is displayed when your game is run_

See also: [Input](Input.md).

Hints
-----

* Axes are not the best place to define "hidden" or secret functions, as they will be displayed very clearly to the player in the game launcher.


###ios Details
This section is not supported on iOS devices.

For more info on how to work with input on iOS devices, please refer to the [iOS Input](Input#iPhoneInput.md) page.


###android Details
This section is not supported on Android devices.

For more info on how to work with input on Android devices, please refer to the [Android Input](Input#AndroidInput.md) page.
