Security Sandbox of the Webplayer
=================================



##desktop Details
In Unity 3.0, the webplayer implements a security model very similar to the one used by the Adobe Flash player™. This security restrictions apply only to the webplayer, and to the editor when the active build target is WebPlayer. The security model has several parts:

* Restrictions on accessing data on a domain other than the one hosting your .unity3d file.
* Some limitation on the usage of the Sockets.
* Disallowing invocation of any method we deemed off limits. (things like File.Delete, etc).
* Disallowing the usage of System.Reflection.* to call private/internal methods in classes you did not write yourself.

Currently only the first two parts of the security model are emulated in the Editor. 
Look here for [a detailed list of which methods / classes are available in the webplayer ](ScriptRef:MonoCompatibility.html.md).

The builtin mutiplayer networking functionality of Unity (`UnityEngine.Network`, `UnityEngine.NetworkView` classes etc) is not affected.

This document describes how to make sure your content keeps working with version 3.0 of the Unity webplayer.
------------------------------------------------------------------------------------------------------------

* See [the Unity API reference for information about the WWW class](ScriptRef:WWW.html.md).
* See [the .NET API reference for information about the .NET Socket class](http://msdn.microsoft.com/en-us/library/system.net.sockets.socket.aspx.md).

The WWW class and sockets use the same policy schema but besides that they are completely separate systems. The WWW policy only defines permissions on the web service where the policy is hosted but socket policies apply to all TCP/UDP socket connections.

The Unity editor comes with an "Emulate Web Security" feature, that imposes the webplayer's security model.
This makes it easy to detect problems from the comfort of the editor. You can find this setting in
__Edit->Project Settings->Editor__.


Implications for usage of the WWW class
=======================================


The Unity webplayer expects a http served policy file named "__crossdomain.xml__" to be available on the domain you want to access with the WWW class,
(although this is not needed if it is the same domain that is hosting the unity3d file).

For example, imagine a tetris game, hosted at the following url:

_http://gamecompany.com/games/tetris.unity3d_

needs to access a highscore list from the following url:

_http://highscoreprovider.net/gethighscore.php_

In this case, you would need to place a __crossdomain.xml__ file at the root of the _highscoreprovider.net_ domain like this: _http://highscoreprovider.net/crossdomain.xml_

The contents of the __crossdomain.xml__ file are in the format used by the Flash player. It is very likely that you'll
find the __crossdomain.xml__ file already in place. The policy in the file look like this:
````

<?xml version="1.0"?>
<cross-domain-policy>
<allow-access-from domain="*"/>
</cross-domain-policy>

````
When this file is placed at http://highscoreprovider.net/crossdomain.xml, the owner of that domain declares that
the contents of the webserver may be accessed by any webplayer coming from any domain.

The Unity webplayer does not support the `<allow-http-request-headers-from domain>` and `<site-control permitted-cross-domain-policies>` tags. Note that __crossdomain.xml__ should be an ASCII file.



Implications for usage of Sockets:
==================================


A Unity webplayer needs a socket served policy in order to connect to a particular host. This policy is by default hosted by the target host on port __843__ but it can be hosted on other ports as well. The functional difference with a non-default port is that it must be manually fetched with  [Security.PrefetchSocketPolicy()](ScriptRef:Security.PrefetchSocketPolicy.html)  API call and if it is hosted on a port higher than 1024 the policy can only give access to other ports higher than 1024.

When using the default port it works like this: A Unity webplayer tries to make a TCP socket connection to a host, it first checks that the host server will accept the connection.
It does this by opening a TCP socket on port 843, issues a request, and expects to receive a socket policy over the new connection. The Unity webplayer then checks that the host's policy permits the connection to go ahead and it will proceed without error if so. This process happens transparently to the user's code, which does not need to be modified to use this security model. An example of a socket policy look like this:
````

<?xml version="1.0"?>
<cross-domain-policy>
   <allow-access-from domain="*" to-ports="1200-1220"/> 
</cross-domain-policy>"

````
This policy effectively says "Content from any domain is free to make socket connections at ports 1200-1220".  The Unity webplayer will respect this, and reject
any attempted socket connection using a port outside that range (a SecurityException will be thrown).

When using UDP connections the policy can also be auto fetched when they need to be enforced in a similar manner as with TCP. The difference is that auto fetching with TCP happens when you Connect to something (ensures you are allowed to connect to a server), but with UDP, since it's connectionless, it also happens when you call any API point which sends or receives data (ensures you are allowed to send/receive traffic to/from a server).

The format used for the socket policy is the same as that used by the Flash player except some tags are not supported. The Unity webplayer only supports "*" as a valid value for the domain setting and the "to-ports" setting is mandatory. 
````

<?xml version="1.0" encoding="ISO-8859-1"?>

<!ELEMENT cross-domain-policy (allow-access-from*)>

<!ELEMENT allow-access-from EMPTY>
<!ATTLIST allow-access-from domain CDATA #REQUIRED>
<!ATTLIST allow-access-from to-ports CDATA #REQUIRED>

````

The socket policy applies to both TCP and UDP connection types so both UDP and TCP traffic can be controlled by one policy server.

For your convenience, we provide a small program which simply listens at port 843; when on a connection it receives a request string, it will reply with a valid socket policy.
The server code can be found inside the Unity install folder, in Data/Tools/SocketPolicyServer on Windows or /Unity.app/Contents/Tools/SocketPolicyServer on OS X.  Note that the pre-built executable can be run on Mac since it is a Mono executable.  Just type "mono sockpol.exe" to run it.  Note that this example code shows the correct behaviour of a socket policy server.  Specifically the server expects to receive a zero-terminated string that contains `<policy-file-request/>`.  It only sends to the client the socket policy xml document when this string (and exactly this string) has been received.  Further, it is required that the xml header and xml body are sent with a single socket write.  Breaking the header and body into separate socket write operations can cause security exceptions due to Unity receiving an incomplete policy.  If you experience any problems with your own server please consider using the example that we provide.  This should help you diagnose whether you have server or network issues.

Third party networking libraries, commonly used for multiplayer game networking, should be able to work with these requirements as long as they do not depend on peer 2 peer functionality (see below) but utilize dedicated servers. These sometimes even come out of the box with support for hosting policies.

__Note:__ Whilst the `crossdomain.xml` and socket policy files are both xml documents and are broadly similar, the way that these documents are served are very different.  `Crossdomain.xml` (which applied to http requests) is fetched using http on port 80, where-as the socket policy is fetched from port 843 using a trivial server that implements the `<policy-file-request/>`.  You cannot use an http server to issue the socket policy file, nor set up a server that simply sends the socket policy file in response to a socket connection on port 843.  Note also that each server you connect to requires its own socket policy server.

###Debugging

You can use `telnet` to connect to the socket policy server.  An example session is shown below:
````

host$ telnet localhost 843
Trying 127.0.0.1...
Connected to localhost.
Escape character is '^]'.
<policy-file-request/>
<?xml version='1.0'?>
<cross-domain-policy>
        <allow-access-from domain="*" to-ports="*" />
</cross-domain-policy>Connection closed by foreign host.
host$
````
In this example session, telnet is used to connect to the localhost on port 843.  Telnet responds with the first three lines, and then sits waiting for the user to enter something.  The user has entered the policy request string `<policy-file-request/>`, which the socket policy server receives and responds with the socket policy.  The server then disconnects causing telnet to report that the connection has been closed.

Listening sockets
-----------------


You __cannot__ create listening sockets in the webplayer, it cannot act as a server. Therefore webplayers cannot communicate with each other directly (peer 2 peer). When using TCP sockets you can only connect to remote endpoints provided it is allowed through the socket policy system. For UDP it works the same but the concept is a little bit different as it is a connectionless protocol, you don't have to connect/listen to send/receive packets. It works by enforcing that you can only receive packets from a server if he has responded first with a valid policy with the `allow-access-from domain` tag.

This is all just so annoying, why does all this stuff exist?
------------------------------------------------------------


The socket and WWW security features exist to protect people who install the Unity Web Player. Without these restrictions, an attack such as the following would be possible:

* Bob works at the white house.
* Frank is evil. He writes a unity webgame that pretends to be a game, but in the background does a WWW request to http://internal.whitehouse.gov/LocationOfNuclearBombs.pdf. internal.whitehouse.gov is a server that is not reachable from the internet, but is reachable from Bob's workstation because he works at the white house.
* Frank sends those pdf bytes to http://frank.com/secretDataUploader.php
* Frank places this game on http://www.frank.com/coolgame.unity3d
* Frank somehow convinces Bob to play the game.
* Bob plays the game.
* Game silently downloads the secret document, and sends it to Frank.

With the WWW and socket security features, this attack will fail, because before downloading the pdf, unity checks http://internal.whitehouse.gov/crossdomain.xml,  with the intent to ask that server: "is the data you have on your server available for public usage?".  Placing a crossdomain.xml on a webserver can be seen as the response to that question. In the case of this example, the system operator of internal.whitehouse.gov will not place a crossdomain.xml on its server, which will lead Unity to not download the pdf.

Unfortunately, in order to protect the people who install the Unity Web Player, people who develop in Unity need to take these security measures into account when developing content. The same restrictions are present in all major plugin technologies. (Flash, Silverlight, Shockwave)


Exceptions
----------


In order to find the right balance between protecting Web Player users and making life of content developers easy, we have implemented an exception to the security mechanism described above:

- You are allowed to download images from servers that do not have a crossdomain.xml file. However, the only thing you are allowed to do with these images is use them as textures in your scene. You are not allowed to use GetPixel() on them. You are also no longer allowed to read back from the screen. Both attempts will result in a SecurityException being thrown.
The reasoning is here is that it's okay to download the image, as long as the content developer gets no access to it. So you can display it to the user, but you cannot send the bytes of the image back to some other server.
