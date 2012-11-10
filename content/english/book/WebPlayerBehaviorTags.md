Customizing the Unity Web Player's Behavior
===========================================


The Unity <span class=keyword>Web Player</span> allows developers to use a few optional parameters to easily control its behavior in a few ways:

* <span class=component>disableContextMenu</span>: This parameter controls whether or not the Unity Web Player displays a context menu when the user right- or control-clicks on the content. Setting it to true prevents the context menu from appearing and allows content to utilize right-mouse behavior. To enable the context menu don't include this parameter.
* <span class=component>disableExternalCall</span>: This parameter controls whether or not the Unity Web Player allows content to communicate with browser-based JavaScript. Setting it to true prevents browser communication and so content cannot call or execute JavaScript in the browser, the default is false.
* <span class=component>disableFullscreen</span>: This parameter controls whether or not the Unity Web Player allows content to be viewed in fullscreen mode. Setting it to true prevents fullscreen viewing and removes the "Go Fullscreen" entry from the context menu, the default is false.

Here is an example script that limits the behavior of the Unity Web Player, the context menu will not be shown. Although there is only one parameter it still must be placed inside <span class=component>params</span> object and passed to <span class=component>unityObject.embedUnity</span> method.
````

var params = {
	disableContextMenu: true
};

unityObject.embedUnity("unityPlayer", "WebPlayer.unity3d", 600, 450, params);

````
In the above example you'll notice that neither <span class=component>disableExternalCall</span> nor <span class=component>disableFullscreen</span> are specified, therefore their default values are used.

