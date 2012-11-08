Minimizing Network Bandwidth
============================


Since network communication is potentially slow compared to other aspects of a game, it is important to reduce it to a minimum. It is therefore very important to consider how much data you are exchanging and how frequently the exchanges take place.


How data is synchronized
------------------------


The amount of network bandwidth used depends heavily on whether you use the <span class=component>Unreliable</span> or the <span class=component>Reliable Delta Compression</span> mode to synchronize data (the mode is set from the Network View component).

In <span class=component>Unreliable</span> mode, the whole of the object being synchronized will be transmitted on each iteration of the network update loop. The frequency of this update is determined by the value of [Network.sendRate](ScriptRef:Network-sendRate.html), which is set to 15 updates per second by default. <span class=component>Unreliable</span> mode ensures frequent updates but any dropped or delayed packets will simply be ignored. This is often the best synchronization mode to use when objects change state very frequently and the effect of a missed update is very short-lived. However, you should bear in mind the amount of data that might be sent during each update. For example, synchronizing a Transform involves transmitting nine float values (three Vector3s with three floats each), which equates to 36 Bytes per update. If the server is running with eight clients and using the default update frequency then it will receive  4,320 KBytes/s (8*36*15) or 34.6Kbits/s and transmit 30.2 KBytes/s (8*7*36*15) or 242Kbits/s. You can reduce the bandwidth consumption considerably by lowering the frequency of updates, but the default value of 15 is about right for a game where the action moves quickly.

In <span class=component>Reliable Delta Compressed</span> mode, the data is guaranteed to be sent reliably and arrive in the right order. If packets are lost then they get retransmitted and if they arrive out of order, they will be buffered until all packets in the sequence have arrived. Although this ensures that transmitted data is received correctly, the waiting and retransmission tend to increase bandwidth usage. However, the data is also delta compressed which means only the differences between the last state and the current state are transmitted. If the state is exactly the same then nothing is sent. The benefit of delta compression thus depends on how much the state changes and in which properties.


What data is synchronized
-------------------------


There is plenty of opportunity for creativity in designing the game so that the state _appears_ to be the same on all clients even though it may not be, strictly. An example of this is where animations are synchronized. If an Animation component is observed by a Network View then its properties will be synchronized exactly, so the frames of animation will appear exactly the same on all clients. Although this may be desirable in some cases, typically it will be enough for the character to be seen as walking, running, jumping, etc. The animations can thus be crudely synchronized simply by sending an integer value to denote which animation sequence to play. This will save a great deal of bandwidth compared to synchronizing the whole Animation component.


When to synchronize data
------------------------


It is often unnecessary to keep the game perfectly in sync on all clients, for example, in cases where the players are temporarily in different areas of the game world where they won't encounter each other. This can reduce the bandwidth as well as the load on the server since only the clients that can interact need to be kept in sync. This concept is sometimes referred to as <span class=keyword>Relevant Sets</span> (ie, there is a subset of the total game that is relevant to any particular client at any particular time). Synchronizing clients according to their relevant sets can be handled with RPCs, since they can give greater control over the destination of a state update.


###Level loading

When loading levels, it is seldom necessary to worry about the bandwidth being used since each client can simply wait until all the others have initialized the level to be played. Level loading can often involve transmitting even quite large data items (such as images or audio data).
