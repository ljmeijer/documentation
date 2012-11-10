High Level Networking Concepts
==============================


This section covers general networking concepts that should be understood before developing a game with Unity's networking architecture.

What is Networking?
-------------------


Networking is communication between two or more computers. A fundamental idea is that of the relationship between the <span class=keyword>client</span> (the computer that is requesting information) and the <span class=keyword>server</span> (the computer responding to the information request).  The server can either be a dedicated host machine used by all clients, or simply a player machine running the game (client) but also acting as the server for other players.  Once a server has been established and a client has connected to it, the two computers can exchange data as demanded by gameplay.

Creating a network game requires a lot of attention to some very specific details.  Even though network actions are easy to design and create in Unity, networking remains rather complex. A major design decision in Unity is to make networking as robust and flexible as possible. This means that you, as the game creator, are responsible for things that might be handled in an automatic but less robust way in other engines.  The choices you make potentially have a major effect on the design of your game, so it is best to make them as early in the design stage as possible. Understanding networking concepts will help you plan your game design well and avoid problems during the implementation.


Networking Approaches
---------------------


There are two common and proven approaches to structuring a network game which are known as <span class=keyword>Authoritative Server</span> and <span class=keyword>Non-Authoritative Server</span>. Both approaches rely on a server connecting clients and passing information between them. Both also offer privacy for end users since clients never actually connect directly with each other or have their IP addresses revealed to other clients.  


###Authoritative Server

The authoritative server approach requires the server to perform all world simulation, application of game rules and processing of input from the player clients.  Each client sends their input (in the form of keystrokes or requested actions) to the server and continuously receives the current state of the game from the server.  The client never makes any changes to the game state itself.  Instead, it tells the server what it wants to do, and the server then handles the request and replies to the client to explain what happened as a result.

Fundamentally, there is a layer of separation between what the player wants to do and what actually happens.  This allows the server to listen to every client's requests before deciding how to update the game state.

An advantage of this approach is that it makes cheating much harder for clients. For example, clients do not have the possibility of cheating by telling the server (and thereby other clients) that an enemy has been killed, since they don't get to make that decision by themselves. They can only tell the server that a weapon was fired and from there, it is up to the server to determine whether or not a kill was made.

Another example of an authoritative server would be a multiplayer game that relies on physics. If each client is allowed to run its own physics simulation then small variations between clients could cause them to drift out of sync with each other gradually. However, if the simulation of all physics objects is handled on a central server then the updated state can be sent back to the clients, guaranteeing they are all consistent.

A potential disadvantage with authoritative servers is the time it takes for the messages to travel over the network. If the player presses a control to move forward and it takes a tenth of a second for the response to return from the server then the delay will be perceptible to the player. One solution to this is to use so-called <span class=keyword>client-side prediction</span>. The essence of this technique is that the client is allowed to update its own local version of the game state but it must be able to receive corrections from the server's authoritative version where necessary. Typically, this should only be used for simple game actions and not significant logical changes to game state. For example, it would be unwise to report to a player that an enemy has been killed only for the server to override this decision.

Since client-side prediction is an advanced subject, we don't attempt to cover it in this guide but books and web resources are available if you want to investigate it further.

An authoritative server has a greater processing overhead than a non-authoritative one. When the server is not required to handle all changes to game state, a lot of this load can be distributed between the clients.

###Non-Authoritative Server

A non-authoritative server does not control the outcome of every user input. The clients themselves process user input and game logic locally, then send the result of any determined actions to the server. The server then synchronizes all actions with the world state. This is easier to implement from a design perspective, as the server really just relays messages between the clients and does no extra processing beyond what the clients do.

There is no need for any kind of _prediction_ methods as the clients handle all physics and events themselves and relay what happened to the server. They are the _owners_ of their objects and are the only agents permitted to send local modifications of those objects over the network.

Methods of Network Communication
--------------------------------


Now that we've covered the basic architectures of networked games, we will explore the lower-levels of how clients and servers can talk to each other.

There are two relevant methods: <span class=keyword>Remote Procedure Calls</span> and <span class=keyword>State Synchronization</span>.  It is not uncommon to use both methods at different points in any particular game.


###Remote Procedure Calls

Remote Procedure Calls (RPCs) are used to invoke functions on other computers across the network, although the "network" can also mean the message channel between the client and server when they are both running on the same computer. Clients can send RPCs to the server, and the server can send RPCs to one or more clients.  Most commonly, they are used for actions that happen infrequently.  For example, if a client flips a switch to open a door, it can send an RPC to the server telling it that the door has been opened.  The server can then send another RPC to all clients, invoking their local functions to open that same door. They are used for managing and executing individual events.


###State Synchronization

State Synchronization is used to share data that is constantly changing.  The best example of this would be a player's position in an action game.  The player is always moving, running around, jumping, etc.  All the other players on the network, even the ones that are not controlling this player locally, need to know where he is and what he is doing.  By constantly relaying data about this player's position, the game can accurately represent that position to the other players.

This kind of data is regularly and frequently sent across the network.  Since this data is time-sensitive, and it requires time to travel across the network from one machine to another, it is important to reduce the amount of data that is sent as far as possible.  In simpler terms, state synchronization naturally requires a lot of bandwidth, so you should aim to use as little bandwidth as possible.


###Connecting servers and clients together

Connecting servers and clients together can be a complex process. Machines can have private or public IP addresses and they can have local or external firewalls blocking access. Unity networking aims to handle as many situations as possible but there is no universal solution.

Private addresses are IP addresses which are not accessible directly from the internet (they are also called Network Address Translation or NAT addresses after the method used to implement them). Simply explained, the private address goes through a local router which translates the address into a public address. By doing this, many machines with private addresses can use a single public IP address to communicate with the internet. This is fine until someone elsewhere on the internet wants to initiate contact with one of the private addresses. The communication must happen via the public address of the router, which must then pass the message on to the private address. A technique called NAT punchthrough uses a shared server known as a _facilitator_ to mediate communication in such a way that the private address can be reached from the public address. This works by having the private address first contact the facilitator, which "punches" a hole through the local router. The facilitator can now see the public IP address and port which the private address is using. Using this information, any machine on the internet can now connect directly with the otherwise unreachable private address. (Note that the details of NAT punchthrough are somewhat more complicated than this in practice.)

Public addresses are more straightforward. Here, the main issue is that connectivity can be blocked by an internal or external firewall (an internal firewall is one that runs locally on the computer it is protecting). For an internal firewall, the user can be asked to remove restrictions from a particular port so as to make the game server accessible. An external firewall, by contrast, is not under the control of the users. Unity can attempt to use NAT punchthrough to get access through an external firewall but this technique is not guaranteed to succeed. Our testing suggests that it generally works in practice but there doesn't appear to be any formal research that confirms this finding.

The connectivity issues just mentioned affect servers and clients differently. Client requests involve only outgoing network traffic which is relatively straightforward. If the client has a public address then this almost always works since outgoing traffic is typically only blocked on corporate networks that impose severe access restrictions. If the client has a private address it can connect to all servers except servers with private addresses which cannot do NAT punchthrough (more will be said about this later). The server end is more complicated because the server needs to be able to accept incoming connections from unknown sources. With a public address, the server needs to have the game port open to the internet (ie, not blocked by a firewall). or else it cannot accept any connections from clients and is thus unusable. If the server has a private address it must be able to do NAT punchthrough to allow connections and clients must also permit NAT punchthrough in order to connect to it.

Unity provides tools to test all these different connectivity situations. When it is established that a connection can be made, there are two methods by which it can happen: direct connections (where a client needs to know the DNS name or IP address of the server) and connections via the Master Server. The Master Server allows servers to advertise their presence to clients which need not know anything about particular game servers beforehand.


Minimizing Network Bandwidth
----------------------------


When working with State Synchronization across multiple clients, you don't necessarily need to synchronize every single detail in order to make objects appear synchronized. For example, when synchronizing a character avatar you only need to send its position and rotation between clients. Even though the character itself is much more complex and might contain a deep <span class=keyword>Transform</span> hierarchy, data about the entire hierarchy does not need to be shared.

A lot of data in your game is effectively static, and clients need neither transfer it initially nor synchronize it. Using infrequent or one-time RPC calls should be sufficient to make a lot of your functionality work. Take advantage of the data you know will exist in every installation of your game and keep the client working by itself as much as possible. For example, you know that assets like textures and meshes exist on all installations and they usually don't change, so they will never have to be synchronized. This is a simple example but it should get you thinking about what data is absolutely critical to share from one client to another. This is the only data that you should ever share.

It can be difficult to work out exactly what needs to be shared and what doesn't, especially if you have never made a network game before.  Bear in mind that you can use a single RPC call with a level name to make all clients load the entire specified level and add their own networked elements automatically.  Structuring your game to make each client as self-sufficient as possible will result in reduced bandwidth.


Multiplayer Game Performance
----------------------------


The physical location and performance of the server itself can greatly affect the playability of a game running on it. Clients which are located a continent away from the server may experience a great deal of lag. This is a physical limitation of the internet and the only real solution is to arrange for the server to be as close as possible to the clients who will use it, or at least on the same continent.

Extra Resources
---------------


We've collected the following links to additional resources about networking:-

* http://developer.valvesoftware.com/wiki/Source_Multiplayer_Networking
* http://developer.valvesoftware.com/wiki/Lag_Compensation
* http://developer.valvesoftware.com/wiki/Working_With_Prediction
* http://www.gamasutra.com/resource_guide/20020916/lambright_01.htm
