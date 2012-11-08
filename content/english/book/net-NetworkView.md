Network Views
=============


Network Views are the main component involved in sharing data across the network. They allow two kinds of network communication: <span class=keyword>State Synchronization</span> and <span class=keyword>Remote Procedure Calls</span>.

Network Views keep watch on particular objects to detect changes. These changes are then shared to the other clients on the network to ensure the change of state is noted by all of them. This concept is known as _state synchronization_ and you can read about it further on the [State Synchronization page](net-StateSynchronization.md).

There are some situations where you would not want the overhead of synchronizing state between clients, for example, when sending out the position of a new object or respawned player. Since events like this are infrequent, it does not make sense to synchronize the state of the involved objects.  Instead, you can use a _remote procedure call_ to tell the clients or server to perform operations like this. More information about Remote Procedure Calls can be found on the [RPC manual page](net-RPCDetails.md).


Technical Details
-----------------


A Network View is identified across the network by its <span class=component>NetworkViewID</span> which is basically just a identifier which is negotiated to be unique among the networked machines. It is represented as a 128 bit number but is automatically compressed down to 16 bits when transferred over the network if possible.

Each packet that arrives on the client side needs to be applied to a specific Network View as specified by the NetworkViewID. Using this, Unity can find the right Network View, unpack the data and apply the incoming packet to the Network View's observed object.

More details about using Network Views in the Editor can be found on the  [Network View Component Reference page](class-NetworkView.md).

If you use [Network.Instantiate()](ScriptRef:Network.Instantiate.html) to create your Networked objects, you do not need to worry about allocating Network Views and assigning them yourself appropriately. It will all work automatically behind the scenes.

However, you can manually set the <span class=component>NetworkViewID</span> values for each Network View by using [Network.AllocateViewID](ScriptRef:Network.AllocateViewID.html). The Scripting Reference documentation shows an example of how an object can be instantiated manually on every client with an RPC function and then the NetworkViewID manually set with <span class=component>AllocateViewID</span>.
