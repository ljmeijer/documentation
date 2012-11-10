Network Manager
===============


The <span class=keyword>Network Manager</span> contains two very important properties for making Networked multiplayer games.


![](http://docwiki.hq.unity3d.com/uploads/Main/NetworkSet.png)  
_The Network Manager_

You can access the Network Manager by selecting <span class=menu>Edit->Project Settings->Network</span> from the menu bar.


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Debug Level</span> |The level of messages that are printed to the console |
|>>><span class=component>Off</span> |Only errors will be printed |
|>>><span class=component>Informational</span> |Significant networking events will be printed |
|>>><span class=component>Full</span> |All networking events will be printed |
|<span class=component>Sendrate</span> |Number of times per second that data is sent over the network |


Details
-------


Adjusting the Debug Level can be enormously helpful in fine-tuning or debugging your game's networking behaviors.  At first, setting it to <span class=component>Full</span> will allow you to see every single network action that is performed.  This will give you an overall sense of how frequently you are using network communication and how much bandwidth you are using as a result.

When you set it to <span class=component>Informational</span>, you will see major events, but not every individual activity.  Assigning unique <span class=component>Network IDs</span> and buffering <span class=component>RPC</span> calls will be logged here.

When it is <span class=component>Off</span>, only errors from networking will be printed to the console.

The data that is sent at the <span class=component>Sendrate</span> intervals (1 second / <span class=component>Sendrate</span> = interval) will vary based on the <span class=keyword>Network View</span> properties of each broadcasting object.  If the Network View is using <span class=component>Unreliable</span>, its data will be send at each interval.  If the Network View is using <span class=component>Reliable Delta Compressed</span>, Unity will check to see if the Object being watched has changed since the last interval.  If it has changed, the data will be sent.

