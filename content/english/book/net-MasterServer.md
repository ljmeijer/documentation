Master Server
=============


The Master Server is a meeting place that puts game instances in touch with the player clients who want to connect to them. It can also hide port numbers and IP addresses and perform other technical tasks that arise when setting up network connections, such as firewall handling and NAT punchthrough.

Each individual running game instance provides a <span class=keyword>Game Type</span> to the Master Server. When a player connects and queries the Master Server for their matching <span class=keyword>Game Type</span>, the server responds with the list of running games along with the number of players in each and whether or not a password is needed to play. The two functions used to exchange this data are [MasterServer.RegisterHost()](ScriptRef:MasterServer.RegisterHost.html) for the Server, and [MasterServer.RequestHostList()](ScriptRef:MasterServer.RequestHostList.html) for the player client.

When calling <span class=component>RegisterHost</span>, you need to pass three arguments - _gameTypeName_ (which is the previously mentioned <span class=keyword>Game Type</span>), _gameName_ and _comment_ - for the host being registered. <span class=component>RequestHostList</span> takes as an argument the _gameTypeName_ of the hosts you are interested in connecting to. All the registered hosts of that type will then be returned to the requesting client. This is an asynchronous operation and the complete list can be retrieved with <span class=component>PollHostList()</span> after it has arrived in full.

The NAT punchthrough duty of the Master Server is actually handled by a separate process called the <span class=keyword>Facilitator</span> but Unity's Master Server runs both services in parallel.

The <span class=keyword>Game Type</span> is an identifying name that should be unique for each game (although Unity does not offer any central registration system to guarantee this). It makes sense to choose a distinctive name that is unlikely to be used by anyone else. If there are several different versions of you game then you may need to warn a user that their client is not compatible with the running server version. The version information can be passed in the comment field (this is actually binary data and so the version can be passed in any desired form). The game name is simply the name of the particular game instance as supplied by whoever set it up.

The comment field can be used in more advanced ways if the Master Server is suitably modified (see [below](#advanced) for further information on how to do this). For example, you could reserve the first ten bytes of the comment field for a password and then extract the password in the Master Server when it receives the host update. It can then reject the host update if a password check fails. 


Registering a game
------------------


Before registering a game, it is important to enable or disable the NAT functionality depending on whether or not it is supported by the host; you can do this with the <span class=component>useNat</span> parameter of [Network.InitializeServer](ScriptRef:Network.InitializeServer.html).

A server might be started with code similar to this:-

````

function OnGUI() {
	if (GUILayout.Button ("Start Server"))
	{
		// Use NAT punchthrough if no public IP present
		Network.InitializeServer(32, 25002, !Network.HavePublicAddress());
		MasterServer.RegisterHost("MyUniqueGameType", "JohnDoes game", "l33t game for all");
	}
}

````

Here we just decide if NAT punchthrough is needed by checking whether or not the machine has a public address. There is a more sophisticated function available called [Network.TestConnection](ScriptRef:Network.TestConnection.html) which can tell you if the host machine can do NAT or not. It also does connectivity testing for public IP addresses to see if a firewall is blocking the game port. Machines which have public IP addresses always pass the NAT test but if the test fails then the host will __not__ be able to connect to NAT clients. In such a case, the user should be informed that port forwarding must be enabled for the game to work. Domestic broadband connections will usually have a NAT address but will not be able to set up port forwarding (since they don't have a personal public IP address). In these cases, if the NAT test fails, the user should be informed that running a server is inadvisable given that only clients on the same local network will be able to connect.

If a host enables NAT functionality without needing it then it will still be accessible. However, clients which cannot do NAT punchthrough might incorrectly think they cannot connect on the basis that the server has NAT enabled. 


Connecting to a game
--------------------


A <span class=component>HostData</span> object is sent during host registrations or queries. It contains the following information about the host:-

|    |    |
|:---|:---|
|boolean |<span class=component>useNat</span> |Indicates if the host uses NAT punchthrough. 
|String |<span class=component>gameType</span> |The game type of the host. 
|String |<span class=component>gameName</span> |The game name of the host.
|int |<span class=component>connectedPlayers</span> |The number of currently connected players/clients.
|int |<span class=component>playerLimit</span> |The maximum number of concurrent players/clients allowed.
|String[] |<span class=component>IP</span> |The internal IP address of the host. On a server with a public address the external and internal addresses are the same. This field is defined as an array since all the IP addresses associated with all the active interfaces of the machine need to be checked when connecting internally.
|int |<span class=component>port</span> |The port of the host.
|boolean |<span class=component>passwordProtected</span> |Indicates whether you need to supply a password to be able to connect to this host.
|String |<span class=component>comment</span> |Any comment which was set during host registration.
|String |<span class=component>guid</span> |The network GUID of the host. This is needed to connect using NAT punchthrough.

This information can be used by clients to see the connection capabilities of the hosts. When NAT is enabled you need to use the GUID of the host when connecting. This is automatically handled for you when the <span class=component>HostData</span> is retrieved as you connect. The connection routine might look something like this:

````

function Awake() {
	MasterServer.RequestHostList("MadBubbleSmashGame");
}

function OnGUI() {
	var data : HostData[] = MasterServer.PollHostList();
	// Go through all the hosts in the host list
	for (var element in data)
	{
		GUILayout.BeginHorizontal();	
		var name = element.gameName + " " + element.connectedPlayers + " / " + element.playerLimit;
		GUILayout.Label(name);	
		GUILayout.Space(5);
		var hostInfo;
		hostInfo = "[";
		for (var host in element.ip)
			hostInfo = hostInfo + host + ":" + element.port + " ";
		hostInfo = hostInfo + "]";
		GUILayout.Label(hostInfo);	
		GUILayout.Space(5);
		GUILayout.Label(element.comment);
		GUILayout.Space(5);
		GUILayout.FlexibleSpace();
		if (GUILayout.Button("Connect"))
		{
			// Connect to HostData struct, internally the correct method is used (GUID when using NAT).
			Network.Connect(element);			
		}
		GUILayout.EndHorizontal();	
	}
}

````

This example prints out all of the relevant host information returned by the Master Server. Other useful data like ping information or geographic location of hosts can be added to this.

NAT punchthrough
----------------


The availability of NAT punchthrough may determine whether or not a particular computer is suitable to use as a server. While some clients might be able to connect, there are others that might have trouble connecting to any NAT server.

By default, NAT punchthrough is provided with the help of the Master Server but it need not be done this way. The Facilitator is the process that is actually used for the NAT punchthrough service. If two machines are connected to the Facilitator then it will appear as if they can both connect to each other as long as it uses the external IP and port. The Master Server is used to provide this external IP and port information which is otherwise hard to determine. That is why the Master Server and Facilitator are so tightly integrated. The Master Server and Facilitator have the same IP address by default, to change either one use [MasterServer.ipAddress](ScriptRef:MasterServer-ipAddress.html), [MasterServer.port](ScriptRef:MasterServer-port.html), [Network.natFacilitatorIP](ScriptRef:Network-natFacilitatorIP.html) and [Network.natFacilitatorPort](ScriptRef:Network-natFacilitatorPort.html)

<a id="advanced"></a>
Advanced
--------


Unity Technologies also has a fully deployed Master Server available for testing purposes and this is actually the server that will be used by default. However, the source code is freely available for anyone to use and the server can be deployed on Windows, Linux and Mac OS. In addition to simply building the project from source, there might be cases where you want to modify the way in which the Master Server handles information and how it communicates. For example, you may be able to optimize the handling of host data or limit the number of clients returned on the host list. Such changes will require modifications to the source code; information about how to go about this can be found on the [Master Server Build page](net-MasterServerBuild.md).
