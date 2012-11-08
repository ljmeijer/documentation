HTML code to load Unity content with UnityObject2
=================================================


Loading unity content with UnityObject2 is similiar to the way it's done with [UnityObject](HTMLcodetoloadUnityWebPlayercontent.md), except the URL used for the unityObjectURL is: 
"http://webplayer.unity3d.com/download_webplayer-3.x/3.0/uo/UnityObject2.js";

You can now instantiante the <span class=component>UnityObject2</span> class to assist you in various Unity related tasks. The most inportant one is to embed Unity content. This is performed by instantiating <span class=component>UnityObject2</span> and calling <span class=component>initPlugin</span> on the new instance. See [UnityObject2.initPlugin](WebPlayerDeployment-UnityObject2#initPlugin.md)

````

var u = new UnityObject2();
u.initPlugin(jQuery("#unityPlayer")[0], "Example.unity3d");

````

Finally, the HTML placeholder is placed inside the <span class=component><body></span> section. It could be as simple as <span class=component><div id="unityPlayer" /></span>. However for maximum compatibility it's best to place some warning message in case the browser doesn't support JavaScript and the placeholder isn't replaced by UnityObject.

````

<div id="unityPlayer">
	<div class="missing">
		<a href="http://unity3d.com/webplayer/" title="Unity Web Player. Install now!">
			<img alt="Unity Web Player. Install now!" src="http://webplayer.unity3d.com/installation/getunity.png" width="193" height="63" />
		</a>
	</div>
</div>

````

