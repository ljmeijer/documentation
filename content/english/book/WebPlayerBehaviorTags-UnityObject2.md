Customizing the Unity Web Player's Behavior
===========================================


The Unity <span class=keyword>Web Player</span> allows developers to use a few optional parameters to easily control its behavior in a few ways:

* <span class=component>disableContextMenu</span>: This parameter controls whether or not the Unity Web Player displays a context menu when the user right- or control-clicks on the content. Setting it to true prevents the context menu from appearing and allows content to utilize right-mouse behavior. To enable the context menu don't include this parameter.
* <span class=component>disableExternalCall</span>: This parameter controls whether or not the Unity Web Player allows content to communicate with browser-based JavaScript. Setting it to true prevents browser communication and so content cannot call or execute JavaScript in the browser, the default is false.
* <span class=component>disableFullscreen</span>: This parameter controls whether or not the Unity Web Player allows content to be viewed in fullscreen mode. Setting it to true prevents fullscreen viewing and removes the "Go Fullscreen" entry from the context menu, the default is false.

Using <span class=component>UnityObject2</span> you control those parameters like this:
````

var params = {
	disableContextMenu: true
};
var u = UnityObject2({ params: params });
u.initPlugin(jQuery("#unityPlayer")[0], "Example.unity3d");

````
In the above example you'll notice that neither <span class=component>disableExternalCall</span> nor <span class=component>disableFullscreen</span> are specified, therefore their default values are used.

See [UnityObject2](WorkingwithUnityObject2#constructor.md) for more details.

