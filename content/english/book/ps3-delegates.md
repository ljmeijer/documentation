Playstation3: System Notifications
==================================


If you want to process notifications sent from the system to your application you can subscribe a delegate to the [PS3SystemUtility.OnSystemNotification](ScriptRef:PS3SystemUtility.OnSystemNotification.html) property. The notifications can be sent by the System, Pad controllers, Move controllers or the Camera. The list of notification ids are available in the [PS3SystemConstants](ScriptRef:PS3SystemConstants.html) enumeration.

###Example

The following example handles the events when the GUI menu screen of the system software has been opened or closed:

````
using UnityEngine;
using System.Collections;

public class Notifications : MonoBehaviour {
   void OnEnable() {
       PS3SystemUtility.OnSystemNotification += HandlePS3Notification;
   }
   void OnDisable() {
       PS3SystemUtility.OnSystemNotification -= HandlePS3Notification;
   }
   void HandlePS3Notification(uint subsystem, uint index, uint notification, uint status) {
       // handle system menu notices
       if (subsystem == (uint)PS3SystemConstants.System) {
           switch (notification) {
               case (uint)PS3SystemConstants.SystemMenuOpen:
                   Debug.Log("menu opened");
                   break;
               case (uint)PS3SystemConstants.SystemMenuClosed:
                   Debug.Log("menu closed");
                   break;
               default:
                   break;
           }
       }
   }
}
````
