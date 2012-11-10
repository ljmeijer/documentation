Networking on Mobile devices.
=============================


iOS and Android
===============


Networking for mobile devices (iOS / Android)
---------------------------------------------

The Unity iOS/Android Networking engine is fully compatible with networking for desktop devices, so your existing networking code should work on iOS/Android devices. However, you may want to re-engineer your code if it is mainly to be used with Wi-Fi or cellular networks. Moreover, depending on the mobile, the networking chip may also be the bottleneck since pings between mobile devices (or between the mobile device and the desktop) are about 40-60 ms, even in high performance Wi-Fi networks.

Using Networking you can create a game that can be played simultaneously from desktop and iOS over Wi-Fi or cellular networks. In the latter case, your game server should have a public IP address (accessible through the internet). 

__Note:__
EDGE / 3G data connections go to sleep very quickly when no data is sent. Thus sometimes you may need to "wake-up" networking. Just make the WWW class connect to your site (and yield until it finishes) before making the Unity networking connection..

