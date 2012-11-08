Network Reference Guide
=======================


Networking is a very large, detailed topic.  In Unity, it is extremely simple to create network functionality.  However, it is still best to understand the breadth and depth involved with creating any kind of network game.  The following page will explain the fundamentals of networking concepts, and the Unity-specific executions of these concepts for you to use.  If you have never created a network game before, it is highly recommended that you read this guide in detail before attempting to create one.

[High Level Overview](net-HighLevelOverview.md)
-----------------------------------------------


This section will outline all the concepts involved in networking. It will serve as an introduction to deeper topics.


[Networking Elements in Unity](net-UnityNetworkElements.md)
-----------------------------------------------------------


This section of the guide will cover Unity's execution of the ideas discussed above.


[Network View](net-NetworkView.md)
----------------------------------


Network Views are Components you use to share data across the network.  They are extremely important to understand.  This page will explain them in detail.


[RPC Details](net-RPCDetails.md)
--------------------------------


RPC stands for Remote Procedure Call.  It is a way of calling a function on a remote machine.  This may be a client calling a function on the server, or the server calling a function on all or specific clients, etc.  This page explains RPC concepts in detail.


[State Synchronization](net-StateSynchronization.md)
----------------------------------------------------


State Synchronization is a method of regularly updating a specific set of data across two or more game instances running on the network.


[Network Instantiate](net-NetworkInstantiate.md)
------------------------------------------------


One difficult subject in networking is ownership of an object.  Who controls what?  Network Instantiation will determine this logic for you.  This page will explain how to do this.  It will also explain the complex alternatives, for situations when you just need more control.


[Master Server](net-MasterServer.md)
------------------------------------


The Master Server is like a game lobby where servers can advertise their presence to clients. It is also a solution to enabling communication from behind a firewall or home network.  When needed it makes it possible to use a technique called NAT punchthrough (with help from a facilitator) to make sure your players can always connect with each other.  This page will explain how to use the Master Server.


[Minimizing Bandwidth](net-MinimizingBandwidth.md)
--------------------------------------------------


Every choice you make about where and how to share data will affect the bandwidth your game uses.  This page will share some details about bandwidth usage and how to keep it to a minimum.


###ios Details
[Special details about networking on iOS](MobileNetworking.md)
--------------------------------------------------------------

Boot up with Networking for iOS.

###android Details
[Special details about networking on Android](MobileNetworking.md)
------------------------------------------------------------------


