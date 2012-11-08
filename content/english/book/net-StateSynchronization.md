State Synchronization Details
=============================


You can enable State Synchronization for a given Network View by choosing either <span class=component>Reliable Delta Compressed</span> or <span class=component>Unreliable</span> from the <span class=component>State Synchronization</span> drop-down.  You must then choose what kind of data will be synchronized using the _Observed_ property.

Unity can synchronize Transform, Animation, Rigidbody and MonoBehaviour components.

[Transforms](class-Transform.md) are serialized by storing position, rotation and scale. Parenting information is not transferred over the network.

[Animation](class-Animation.md) serializes each running animation state, that is the time, weight, speed and enabled properties.

[Rigidbody](class-Rigidbody.md) serializes position, rotation, velocity and angular velocity.

Scripts (MonoBehaviours) call the function [OnSerializeNetworkView()](ScriptRef:Network.OnSerializeNetworkView.html).


Reliability and bandwidth
-------------------------


Network Views currently support two reliability levels Reliable Delta Compressed and Unreliable.

Both have their advantages and disadvantages, and the specific details of the game will determine which is the best to use.

For additional information about minimizing bandwidth, please read the [Minimizing Bandwidth page](net-MinimizingBandwidth.md).

###Reliable Delta Compressed

<span class=component>Reliable Delta Compressed</span> mode will automatically compare the data that was last received by the client to the current state. If no data has changed since the last update then no data will be sent. However, the data will be compared on a per property basis. For example, if the Transform's position has changed but its rotation has not then only the position will be sent across the network. Bandwidth is saved by transmitting only the changed data.

Unity will also ensure that every UDP packet arrives reliably by resending it until receipt is determined.  This means that if a packet is dropped, any packets sent later will not be applied until the dropped packet is re-sent and received.  Until then, all later packets will be kept waiting in a buffer.


###Unreliable

In <span class=component>Unreliable</span> mode, Unity will send packets without checking that they have been received. This means that it doesn't know which information has been received and so it is not safe to send only the changed data - the whole state will be sent with each update.

Deciding which method to use
----------------------------


The Network layer uses UDP, which is an unreliable, unordered protocol but it can used to send ordered packets reliably, just like TCP does. To do this, Unity internally uses ACKs and NACKs to control packet transmission, ensuring no packets are dropped. The downside to using reliable ordered packets is that if a packet is dropped or delayed, everything stops until that packet has arrived safely. This can cause transmission delays where there is significant network lag.

Unreliable transmission is useful when you know that data will change every frame anyway. For example, in a racing game, you can practically rely that the player's car is always moving, so the effects of a missed packet will soon be fixed by the next one.

In general, you should use Unreliable sending where quick, frequent updates are more important than missed packets. Conversely, when data doesn't change so frequently, you can use reliable delta compression to save bandwidth.

Prediction
----------


When the server has [full authority](Main.net-HighLevelOverview.md) over the world state, the clients only change the game state according to updates they receive from the server. One problem with this is that the delay introduced by waiting for the server to respond can affect gameplay. For example, when a player presses a key to move forward, he won't actually move until the updated state is received from the server. This delay depends on the latency of the connection so the worse the connection the less snappy the control system becomes.

One possible solution to this is <span class=keyword>Client-side Prediction</span> which means the client predicts the expected movement update from the server by using approximately the same internal model. So the player responds immediately to input but the server sees its position from the last update. When the state update finally arrives from the server, the client will compare what he predicted with what actually happened. This might differ because the server might know more about the environment around the player, the client just knows what he needs to know. Errors in prediction are corrected as they happen and if they are corrected continuously then the result will smoother and less noticeable.


Dead reckoning or interpolation/extrapolation
---------------------------------------------


It is possible to apply the basic principle of client-side prediction to the opponents of the player. <span class=keyword>Extrapolation</span> is the process of storing the last few known values of position, velocity and direction for an opponent and use these to predict where he should be in the immediate future. When the next state update finally arrives with the correct position, the client state will be updated with the exact information, which may make the character jump suddenly if the prediction was bad. In FPS games the behavior of players can be very erratic so this kind of prediction has limited success. If the lag gets high enough the opponent will jump severely as the prediction errors accumulate.

<span class=keyword>Interpolation</span> can be used when packets get dropped on the way to the client. This would normally cause the NPC's movement to pause and then jump to the newest position when the new packet finally arrives. By delaying the world state by some set amount of time (like 100 ms) and then interpolating between the last known position and the new one, the movement between these two points, where packets were dropped, will be smooth.
