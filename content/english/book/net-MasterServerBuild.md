Building the Unity Networking Servers on your own
=================================================


The source code for all the individual networking servers can be downloaded from the [Unity website](http://www.unity3d.com/master-server/index.html.md). This includes the connection tester, facilitator, master server and proxy server.

All source packages include the RakNet 3.732 networking library which handles the basic networking functions and provides plugins used by the networking servers.

The packages include three different types of project files, ready for compilation:
* An Xcode 3.0 project for Mac OS X
* A Makefile for Linux and Mac OS X
* A Visual Studio 2008 solution

The Xcode and Visual Studio projects can just be opened, compiled and built. To build with the Makefile just run "make". It should work with a standard compilation setup on Linux and Mac OS X, if you have _gcc_ then it should work. On Linux you might need to install the ncurses library.

Structure
---------


###The Master Server

The Master Server uses an internal _database_ structure to keep track of host information. 

Hosts send messages with the RUM_UPDATE_OR_ADD_ROW message identifier and all their host information embedded. This is processed in the _OnReceive()_ function in the LightweightDatabaseServer.cpp file. This is where all message initially appear and therefore a good place to start if you want to trace how a message is processed. A table is created within the database structure for each _game type_ which is set when you use [MasterServer.RegisterHost](ScriptRef:MasterServer.RegisterHost.html) function. All game types are grouped together in a table, if the table does not exist it is dynamically created in the _CreateDefaultTable()_ function.

The host information data is modified by the master server. The IP and port of the game which is registering, as seen by the master server, is injected into the host data. This way we can for sure detect the correct external IP and port in cases where the host has a private address (NAT address). The IP and port in the host data sent by the game server is the private address and port and this is stored for later use. If the master server detects that a client is requesting the host data for a game server and the server has the _same_ IP address then he uses the private address of the server instead of the external one. This is to handle cases where  the client and server are on the same local network, using the same router with NAT addresses. Thus they will have the same external address and cannot connect to each other through it, they need to use the private addresses and those will work in this case.

Clients send messages with the ID_DATABASE_QUERY_REQUEST message identifier and what game type they are looking for. The table or host list is fetched from the database structure and sent to the client. If it isn't found and empty host list is sent.

All messages sent to the master server must contain version information which is checked in the _CheckVersion()_ function. At the moment each version of Unity will set a new master server version internally and this is checked here. So if the master server communication routine will change at any point it will be able to detect older versions here and possibly refer to another version of the master server (if at all needed) or modify the processing of that message to account for differences.

###The Facilitator

The facilitator uses the NAT punchthrough plugin from RakNet directly with no modifications. This is essentially just a peer listening on a port with the NAT punchthrough plugin loaded. When a server and a client with NAT addresses are both connected to this peer, they will be able to perform NAT punchthrough to connect to each other. When the [Network.InitializeServer](ScriptRef:Network.InitializeServer) uses NAT, the connection is set up automatically for you.
