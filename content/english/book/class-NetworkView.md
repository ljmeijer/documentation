Network View
============


<span class=keyword>Network Views</span> are the gateway to creating networked multiplayer games in Unity.  They are simple to use, but they are extremely powerful.  For this reason, it is recommended that you understand the fundamental concepts behind networking before you start experimenting with Network Views.  You can learn and discover the fundamental concepts in the [Network Reference Guide](NetworkReferenceGuide.md).


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-NetworkView.png)  
_The Network View <span class=keyword>Inspector</span>_

In order to use any networking capabilities, including <span class=keyword>State Synchronization</span> or <span class=keyword>Remote Procedure Calls</span>, your <span class=keyword>GameObject</span> must have a Network View attached.


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>State Synchronization</span> |The type of [State Synchronization](net-StateSynchronization.md) used by this Network View |
|>>><span class=component>Off</span> |No State Synchronization will be used. This is the best option if you only want to send [RPCs](net-RPCDetails.md) |
|>>><span class=component>Reliable Delta Compressed</span> |The difference between the last state and the current state will be sent, if nothing has changed nothing will be sent. This mode is ordered. In the case of packet loss, the lost packet is re-sent automatically |
|>>><span class=component>Unreliable</span> |The complete state will be sent. This uses more bandwidth, but the impact of packet loss is minimized |
|<span class=component>Observed</span> |The <span class=keyword>Component</span> data that will be sent across the network |
|<span class=component>View ID</span> |The unique identifier for this Network View. These values are read-only in the Inspector |
|>>><span class=component>Scene ID</span> |The number id of the Network View in this particular scene |
|>>><span class=component>Type</span> |Either saved to the <span class=component>Scene</span> or <span class=component>Allocated</span> at runtime |


Details
-------


When you add a Network View to a GameObject, you must decide two things

1. What kind of data you want the Network View to send
1. How you want to send that data


###Choosing data to send

The <span class=component>Observed</span> property of the Network View can contain a single Component.  This can be a <span class=keyword>Transform</span>, an <span class=keyword>Animation</span>, a <span class=keyword>RigidBody</span>, or a script.  Whatever the <span class=component>Observed</span> Component is, data about it will be sent across the network. You can select a Component from the drop-down, or you can drag any Component header directly to the variable. If you are not directly sending data, just using RPC calls, then you can turn off synchronization (no data directly sent) and nothing needs to be set as the Observed property. RPC calls just need a single network view present so you don't need to add a view specifically for RPC if a view is already present.


###How to send the data

You have 2 options to send the data of the <span class=component>Observed</span> Component: <span class=keyword>State Synchronization</span> and <span class=keyword>Remote Procedure Calls</span>.

To use State Synchronization, set <span class=component>State Synchronization</span> of the Network View to <span class=component>Reliable Delta Compressed</span> or <span class=component>Unreliable</span>.  The data of the <span class=component>Observed</span> Component will now be sent across the network automatically. 

<span class=component>Reliable Delta Compressed</span> is ordered.  Packets are always received in the order they were sent.  If a packet is dropped, that packet will be re-sent.  All later packets are queued up until the earlier packet is received. Only the difference between the last transmissions values and the current values are sent and nothing is sent if there is no difference.

If it is observing a Script, you must explicitly Serialize data within the script.  You do this within the <span class=component>OnSerializeNetworkView()</span> function.

````

function OnSerializeNetworkView (stream : BitStream, info : NetworkMessageInfo) {
	var horizontalInput : float = Input.GetAxis ("Horizontal");
	stream.Serialize (horizontalInput);
}

````

The above function always writes (an update from the stream) into horizontalInput, when receiving an update and reads from the variable writing into the stream otherwise. If you want to do different things when receiving updates or sending you can use the <span class=component>isWriting</span> attribute of the BitStream class.

````

function OnSerializeNetworkView (stream : BitStream, info : NetworkMessageInfo) {
	var horizontalInput : float = 0.0;
	if (stream.isWriting) {
		// Sending
		horizontalInput = Input.GetAxis ("Horizontal");
		stream.Serialize (horizontalInput);
	} else {

		// Receiving
		stream.Serialize (horizontalInput);
		// ... do something meaningful with the received variable
	}
}

````

<span class=component>OnSerializeNetworkView</span> is called according to the <span class=component>sendRate</span> specified in the network manager project settings. By default this is 15 times per second.

If you want to use Remote Procedure Calls in your script all you need is a NetworkView component present in the same GameObject the script is attached to. The NetworkView can be used for something else, or in case it's only used for sending RPCs it can have no script observed and state synchronization turned off. The function which is to be callable from the network must have the  <span class=component>@RPC</span> attribute. Now, from any script attached to the same GameObject, you call [networkView.RPC()](ScriptRef:NetworkView.RPC.html) to execute the Remote Procedure Call.

````

var playerBullet : GameObject;

function Update () {
	if (Input.GetButtonDown ("Fire1")) {
		networkView.RPC ("PlayerFire", RPCMode.All);
	}
}

@RPC
function PlayerFire () {
	Instantiate (playerBullet, playerBullet.transform.position, playerBullet.transform.rotation);
}

````

RPCs are transmitted reliably and ordered. For more information about RPCs, see the [RPC Details](net-RPCDetails.md) page.


Hints
-----


* Read through the [Network Reference Guide](NetworkReferenceGuide.md) if you're still unclear about how to use Network Views
* State Synchronization does not need to be disabled to use Remote Procedure Calls
* If you have more than one Network View and want to call an RPC on a specific one, use <span class=component>GetComponents(NetworkView)[i].RPC()</span>.
