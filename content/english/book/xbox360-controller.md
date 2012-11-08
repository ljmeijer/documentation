Controller
==========



![](http://docwiki.hq.unity3d.com/uploads/Main/Xbox360-Controller-Front.png)  


###Notes:
1. To query button states:
    1. Call _Input.GetKey*()_ with a _KeyCode_. See table for reference.
    1. Call _Input.GetButton*()_ with a name set in the _InputManager_.
        1. Joystick 0 button names are formed as "joystick button #".
        1. Joystick 1-3 button names are formed as "joystick # button #".
1. To query analog axis values:
    1. Call Input.GetAxis*() with a name set in the InputManager.
1. _Axis 3_ is "_Axis 9_ minus _Axis 10_" for backwards compatibility.
1. _Axis 8_ is not used.



|    |    |    |    |    |
|:---|:---|:---|:---|:---|
| __No.__ | __Button Name__ | __KeyCode__ | __Axis#__ | __Comments__ |
| 1 | A (Green) | JoystickButton0 | N/A | |
| 2 | B (Red) | JoystickButton1 | N/A | |
| 3 | X (Blue) | JoystickButton2 | N/A | |
| 4 | Y (Yellow) | JoystickButton3 | N/A  | |
| 5 | Left Stick | JoystickButton8 | Axis 1 (X) - Horizontal, Axis 2 (Y) - Vertical | Range [-1; 1] |
| 6 | Right Stick | JoystickButton9 | Axis 4 - Horizontal, Axis 5 - Vertical | Range [-1; 1] |
| 7 | Dpad | N/A | Axis 6 - Horizontal, Axis 7 - Vertical | Set {-1; 0; 1} |
| 8 | Back | JoystickButton6 | N/A | |
| 9 | Start | JoystickButton7 | N/A  | |
| 10 | Left Trigger | N/A | Axis 9 | Range [0; 1] |
| 11 | Right Trigger | N/A | Axis 10 | Range [0; 1] |
| 12 | Left Bumper | JoystickButton4 | N/A  | |
| 13 | Right Bumper | JoystickButton5 | N/A  | |

