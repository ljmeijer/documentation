Playstation3: Controllers
=========================


Unity for PS3 takes advantage of all the official controllers : Pad, Move and Navigation.

To query button states:
* Call _Input.GetKey*()_ with a _KeyCode_. See table for reference.
    * e.g: Use Input.GetKey(KeyCode.Joystick1Button0) to see if Button 0 of the Pad 1 is pressed.
* Call _Input.GetButton*()_ with a name set in the _InputManager_.
    * Joystick 0 button names are formed as "joystick button #".
    * Joystick 1-11 button names are formed as "joystick # button #" (Joysticks 1 through 7 represent __PAD__ controllers while Joysticks 8 through 11 represent __MOVE__ controllers)
To query analog axis values:
* Call Input.GetAxis*() with a name set in the InputManager.
* _Axis 3_ is "_Axis 9_ minus _Axis 10_" for backwards compatibility.
* _Axis 8_ is not used.

###Pad controllers:


![](http://docwiki.hq.unity3d.com/uploads/Main/ps3_pad.png)  



|    |    |    |    |    |
|:---|:---|:---|:---|:---|
| __No.__ | __Button Name__ | __Query String__ | __Axis#__ | __Comments__ |
| 0 | Cross | Joystick [1..7] Button0 | N/A | |
| 1 | Circle | Joystick [1..7] Button1 | N/A | |
| 2 | Square | Joystick [1..7] Button2 | N/A | |
| 3 | Triangle | Joystick [1..7] Button3 | N/A  | |
| 4 | Left Shoulder (L1) | Joystick [1..7] Button4 | N/A  | |
| 5 | Right Shoulder (R1) | Joystick [1..7] Button5 | N/A  | |
| 6 | Select | Joystick [1..7] Button6 | N/A | |
| 7 | Start | Joystick [1..7] Button7 | N/A  | |
| 8 | Left Stick (L3) | Joystick [1..7] Button8 | Axis 1 (X) - Horizontal, Axis 2 (Y) - Vertical | Range [-1; 1] |
| 9 | Right Stick (R3) | Joystick [1..7] Button9 | Axis 4 - Horizontal, Axis 5 - Vertical | Range [-1; 1] |
| 10 | Left Trigger (L2) | N/A | Axis 9 | Range [0; 1] |
| 11 | Right Trigger (R2) | N/A | Axis 10 | Range [0; 1] |
| 12 | Dpad | N/A | Axis 6 - Horizontal, Axis 7 - Vertical | Set {-1; 0; 1} |


###Move & Navigation controllers:

* The buttons & analog sticks are accessed through the default Unity [Input](ScriptRef:Input.html) API just like the Pad controller.
* You can access the Playstation 3 Move controller sphere/handle rotation, position and sphere tracking via the [PS3Move](ScriptRef:PS3Move.html) API provided in the scripts.
* If you want to display the camera texture (for calibration) you can access it via the ___PS3CameraTexture__ sampler2D inside the shader.


![](http://docwiki.hq.unity3d.com/uploads/Main/ps3_move.png)  


|    |    |    |    |    |
|:---|:---|:---|:---|:---|
| __No.__ | __Button Name__ | __Query String__ | __Axis#__ | __Comments__ |
| 0 | Cross | Joystick [8..11] Button0 | N/A | |
| 1 | Circle | Joystick [8..11] Button1 | N/A | |
| 2 | Square | Joystick [8..11] Button2 | N/A | |
| 3 | Triangle | Joystick [8..11] Button3 | N/A  | |
| 4 | T | Joystick [8..11] Button4 | N/A  | |
| 5 | Move | Joystick [8..11] Button5 | N/A  | |
| 6 | Select | Joystick [8..11] Button6 | N/A | |
| 7 | Start | Joystick [8..11] Button7 | N/A  | |

