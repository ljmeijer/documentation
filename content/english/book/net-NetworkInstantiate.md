Network Instantiate
===================


The [Network.Instantiate](ScriptRef:Network.Instantiate.html) function offers a straightforward way to instantiate a prefab on all clients, similar to the effect of [Object.Instantiate](ScriptRef:Object.Instantiate.html) on a single client. The instantiating client is the one that controls the object (ie, the Input class is only accessible from scripts running on the client instance) but changes will be reflected across the network.


The argument list for <span class=component>Network.Instantiate()</span> is as follows:

````

static function Instantiate (prefab : Object, position : Vector3, rotation : Quaternion, group : int) : Object

````

As with Object.Instantiate, the first three parameters describe the prefab to be instantiated along with its desired position and rotation. The  _group_ parameter allows you to define subgroups of objects to control the filtering of messages and can be set to zero if filtering is not required (see the _Communication Groups_ section below).

Technical Details
-----------------


Behind the scenes, network instantiation is built around an RPC call which contains an identifier for the prefab along with the position and other details. The RPC call is always buffered in the same manner as other RPC calls, so that instantiated objects will appear on new clients when they connect. See the [RPC](net-RPCDetails.md) page for further details about buffering.


Communication Groups
--------------------


Communication groups can be used to select the clients that will receive particular messages. For example, two connected players might be in separate areas of the game world and may never be able to meet. There is thus no reason to transfer game state between the two player clients but you may still want to allow chat communication between them. In this case, instantiation would need to be restricted for gameplay objects but not for the objects that implement the chat feature and so they would be put in separate groups.
