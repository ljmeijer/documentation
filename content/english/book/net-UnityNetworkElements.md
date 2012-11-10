Networking Elements in Unity
============================


Unity's native networking supports everything discussed on the previous page.  Server creation and client connection, sharing data between connected clients, determining which player controls which objects, and punching through network configuration variations are all supported out of the box.  This page will walk you through the Unity-specific implementation of these networking practices.


Creating a Server
-----------------


Before you can begin playing a networked game, you have to determine the different computers you will be communicating with.  To do this, you have to create a server.  This can be a machine that is also running the game or it can be a dedicated machine that is not participating in the game.  To create the server, you simply call [Network.InitializeServer()](ScriptRef:Network.InitializeServer.html) from a script.  When you want to connect to an existing server as a client, you call [Network.Connect()](ScriptRef:Network.Connect.html) instead.

In general, you will find it very useful to familiarize yourself with the entire [Network class](ScriptRef:Network.html).


Communicating using Network Views
---------------------------------


The <span class=keyword>Network View</span> is a Component that sends data across the network.  Network Views make your GameObject capable of sending data using RPC calls or State Synchronization.  The way you use Network Views will determine how your game's networking behaviors will work.  Network Views have few options, but they are incredibly important for your networked game.

For more information on using Network Views, please read the [Network View Guide page](net-NetworkView.md) and [Component Reference page](class-NetworkView.md).


Remote Procedure Calls
----------------------


Remote Procedure Calls (RPCs) are functions declared in scripts that are attached to a GameObject that contains a Network View.
The Network View must point to the script which contains the RPC function. The RPC function can then be called from any script within that GameObject.

For more information on using RPCs in Unity, please read the [RPC Details page](net-RPCDetails.md).


State Synchronization
---------------------


State Synchronization is the continual sharing of data across all game clients. This way a player's position can be synchronized over all clients, so it seems it is controlled locally when data is actually being delivered over a network. To synchronize state within a GameObject you just need to add a NetworkView to that object and tell it what to observe. The observed data is then synchronized across all clients in the game.

For more information on using State Synchronization in Unity, please read the [State Synchronization page](net-StateSynchronization.md).


Network.Instantiate()
---------------------


<span class=component>Network.Instantiate()</span> lets you instantiate a prefab on all clients in a natural and easy way. Essentially this is an <span class=component>Instantiate()</span> call, but it performs the instantiation on all clients.

Internally Network.Instantiate is simply a buffered RPC call which is executed on all clients (also locally). It allocates a NetworkViewID and assigns it to the instantiated prefab which makes sure it synchronizes across all clients correctly.

For more information please read the [Network Instantiate](net-NetworkInstantiate.md) page.


NetworkLevelLoad()
------------------


Dealing with sharing data, state of client players, and loading levels can be a bit overwhelming.  The [Network Level Load](net-NetworkLevelLoad.md) page contains a helpful example for managing this task.


Master Server
-------------


The <span class=keyword>Master Server</span> helps you match games.  When you start a server you connect to the master server, and it provides a list of all the active servers.

The <span class=keyword>Master Server</span> is a meeting place for servers and clients where servers are advertised and compatible clients can connect to running games. This prevents the need for fiddling with IP addresses for all parties involved. It can even help users host games without them needing to mess with their routers where, under normal circumstances, that would be required. It can help clients bypass the server's firewall and get to private IP addresses which are normally not accessible through the public internet. This is done with help from a facilitator which _facilitates_ connection establishment.

For more information please read the [Master Server page](net-MasterServer.md).


Minimizing Bandwidth
--------------------


Using the minimum amount of bandwidth to make your game run correctly is essential. There are different methods for sending data, different techniques for deciding _what_ or _when_ to send and other tricks at your disposal.

For tips and tricks to reduce bandwidth usage, please read the [Minimizing Bandwith page](net-MinimizingBandwidth.md).


Debugging Networked Games
-------------------------


Unity comes with several facilities to help you debug your Networked game.

1. The [Network Manager](class-NetworkManager.md) can be used for logging all incoming and outgoing network traffic.
1. Using the Inspector and Hierarchy View effectively you can track object creation and inspect view id's etc.
1. You can launch Unity two times on the same machine, and open different projects in each. On Windows, this can be done by just launching another Unity instance and opening the project from the project wizard. On Mac OS X, multiple Unity instances can be opened from the terminal, and a <span class=menu>-projectPath</span> argument can be specified:
    /Applications/Unity/Unity.app/Contents/MacOS/Unity -projectPath "/Users/MyUser/MyProjectFolder/"
    /Applications/Unity/Unity.app/Contents/MacOS/Unity -projectPath "/Users/MyUser/MyOtherProjectFolder/"


Make sure you make the player run in the background when debugging networking because, for example, if you have two instances running at once, one of them doesn't have focus. This will break the networking loop and cause undesirable results. You can enable this in Edit->Project Settings->Player in the editor or with [Application.runInBackground](ScriptRef:Application-runInBackground.html)

