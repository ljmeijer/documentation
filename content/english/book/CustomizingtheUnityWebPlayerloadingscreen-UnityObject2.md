Customizing the Unity Web Player loading screen
===============================================


Customize the loading screen with _UnityObject2_ is similiar to the way it's done with [UnityObject](CustomizingtheUnityWebPlayerloadingscreen.md).

Please note that modifying the loader images is only possible with <span class=keyword>Unity Pro</span>.

Here is an example script that customizes the appearance of the Unity Web Player loading screen. The background color is set to light gray (<span class=component>A0A0A0</span>), border color to black (<span class=component>000000</span>), text color to white (<span class=component>FFFFFF</span>) and loader images to <span class=component>MyLogo.png</span>, <span class=component>MyProgressBar.png</span> and <span class=component>MyProgressFrame.png</span>. 
````

var params = {
	backgroundcolor: "A0A0A0",
	bordercolor: "000000",
	textcolor: "FFFFFF",
	logoimage: "MyLogo.png",
	progressbarimage: "MyProgressBar.png",
	progressframeimage: "MyProgressFrame.png"
};
var u = UnityObject2({ params: params });
u.initPlugin(jQuery("#unityPlayer")[0], "Example.unity3d");

````

See [UnityObject2](WorkingwithUnityObject2#constructor.md) for more details.

