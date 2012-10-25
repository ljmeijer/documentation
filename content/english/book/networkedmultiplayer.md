Networked Multiplayer
=====================


Realtime networking is a complex field but Unity makes it easy to add networking features to your game. Nevertheless, it is useful to have some idea of the scope of networking before using it in a game. This section explains the fundamentals of networking along with the specifics of Unity's implementation.  If you have never created a network game before then it is strongly recommended that you work through this guide before getting started.

[High Level Overview](net-HighLevelOverview)
--------------------------------------------


This section outlines all the concepts involved in networking and serves as an introduction to deeper topics.

[Networking Elements in Unity](net-UnityNetworkElements)
--------------------------------------------------------


This section of the guide covers Unity's implementation of the concepts explained in the overview.

###[RPC Details](net-RPCDetails)

Remote Procedure Call or RPC is a way of calling a function on a remote machine.  This may be a client calling a function on the server, or the server calling a function on some or all clients.  This section explains RPC concepts in detail.


###[State Synchronization](net-StateSynchronization)

State Synchronization is a method of regularly updating a specific set of data across two or more game instances running on the network.


###[Minimizing Bandwidth](net-MinimizingBandwidth)

Every choice you make about where and how to share data will affect the network bandwidth your game uses. This page explains how bandwidth is used and how to keep usage to a minimum.


###[Network View](net-NetworkView)

Network Views are Components you use to share data across the network and are a fundamental aspect of Unity networking.  This page explains them in detail.


###[Network Instantiate](net-NetworkInstantiate)

A complex subject in networking is ownership of an object and determination of who controls what.  Network Instantiation handles this task for you, as explained in this section.  Also covered are some more sophisticated alternatives for situations where you need more control over object ownership.


###[Master Server](net-MasterServer)

The Master Server is like a game lobby where servers can advertise their presence to clients. It can also enable communication from behind a firewall or home network using a technique called NAT punchthrough (with help from a facilitator) to make sure your players can always connect with each other.  This page explains how to use the Master Server.
