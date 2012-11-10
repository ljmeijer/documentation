Network Level Loading
=====================


Below is a simple example of a way to load a level in a multiplayer game. It makes sure no network messages are being processed while the level is being loaded. It also makes sure no messages are sent, until everything is ready. Lastly, when the level is loaded it sends a message to all scripts so that they know the level is loaded and can react to that. The <span class=component>SetLevelPrefix</span> function helps with keeping unwanted networks updates out of a new loaded level. Unwanted updates might be updates from the previous level for example. The example also uses groups to separate game data and level load communication into groups. Group 0 is used for game data traffic and group 1 for level loading. Group 0 is blocked while the level is being loaded but group 1 kept open, it could also ferry chat communication so that can stay open during level loading.

````

var supportedNetworkLevels : String[] = [ "mylevel" ];
var disconnectedLevel : String = "loader";
private var lastLevelPrefix = 0;

function Awake ()
{
    // Network level loading is done in a separate channel.
    DontDestroyOnLoad(this);
    networkView.group = 1;
    Application.LoadLevel(disconnectedLevel);
}

function OnGUI ()
{
	if (Network.peerType != NetworkPeerType.Disconnected)
	{
		GUILayout.BeginArea(Rect(0, Screen.height - 30, Screen.width, 30));
		GUILayout.BeginHorizontal();
		
		for (var level in supportedNetworkLevels)
		{
			if (GUILayout.Button(level))
			{
				Network.RemoveRPCsInGroup(0);
				Network.RemoveRPCsInGroup(1);
				networkView.RPC( "LoadLevel", RPCMode.AllBuffered, level, lastLevelPrefix + 1);
			}
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}

@RPC
function LoadLevel (level : String, levelPrefix : int)
{
	lastLevelPrefix = levelPrefix;

		// There is no reason to send any more data over the network on the default channel,
		// because we are about to load the level, thus all those objects will get deleted anyway
		Network.SetSendingEnabled(0, false);	

		// We need to stop receiving because first the level must be loaded first.
		// Once the level is loaded, rpc's and other state update attached to objects in the level are allowed to fire
		Network.isMessageQueueRunning = false;
		
		// All network views loaded from a level will get a prefix into their NetworkViewID.
		// This will prevent old updates from clients leaking into a newly created scene.
		Network.SetLevelPrefix(levelPrefix);
		Application.LoadLevel(level);
		yield;
		yield;

		// Allow receiving data again
		Network.isMessageQueueRunning = true;
		// Now the level has been loaded and we can start sending out data to clients
		Network.SetSendingEnabled(0, true);


		for (var go in FindObjectsOfType(GameObject))
			go.SendMessage("OnNetworkLoadedLevel", SendMessageOptions.DontRequireReceiver);	
}

function OnDisconnectedFromServer ()
{
	Application.LoadLevel(disconnectedLevel);
}

@script RequireComponent(NetworkView)

````
