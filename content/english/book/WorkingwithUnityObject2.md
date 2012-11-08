Working with UnityObject2
=========================


__Please note that <span class=component>UnityObject2</span> should be used in all new deployments [UnityObject](WorkingwithUnityObject.md), as UnityObject is now deprecated__.

<span class=keyword>UnityObject2</span> is a JavaScript script that simplifies Unity content embedding into HTML and allows you to customize the install process. Having a custom install UI that matches your game and website, will create a more engaging and pleasurable experience for the end-user. It has functions to detect the Unity <span class=keyword>Web Player</span> plugin, initiate Web Player installation and embed Unity content. Although it's possible to deploy <span class=component>UnityObject2.js</span> file on the web server alongside the HTML file it's best to load it directly from the Unity server at <span class=component>[=http://webplayer.unity3d.com/download_webplayer-3.x/3.0/uo/UnityObject2.js=]</span>. That way you will always reference the most up to date version of UnityObject2. Please note that the <span class=component>UnityObject2.js</span> file hosted on the Unity server is minified to make it smaller and save traffic. If you want to explore the source code you can find the original file in the <span class=component>Data\Resources</span> folder on Windows and the <span class=component>Contents/Resources</span> folder on Mac OS X.  UnityObject2 by defaults sends anonymous data to GoogleAnalytics which is used to help us identify installation type and conversion rate. UnityObject2 depends on jQuery.


<a id="constructor"></a>
Constructor
-----------

You will need to create a new instance of the unityObject2 for each Unity content present on the page.

_Parameters:_

* <span class=component>configuration</span> - A object containing the configuration for this instance. Those are the available members:
    * <span class=component>width</span> - Default: 100%, Width of Unity content. Can be specified in pixel values (i.e. 600, "450") or in percentage values (i.e. "50%", "100%"). Note that percentage values are relative to the parent element.
    * <span class=component>height</span> - Default: 100%, Height of Unity content. Can be specified in pixel values (i.e. 600, "450") or in percentage values (i.e. "50%", "100%"). Note that percentage values are relative to the parent element.
    * <span class=component>fullInstall</span> - Default: false, Installs the full Web Player if not available. Normally only a small part of the Web Player is installed and the remaining files are automatically downloaded later.
    * <span class=component>enableJava</span> - Default: true, Enables Java based installation. Some platforms doesn't support this feature.
    * <span class=component>enableClickOnce</span> - Default: true, Enables ClickOnce based installation. Only works on Internet Explorer browsers.
    * <span class=component>enableUnityAnalytics</span> - Default: true, Notifies Unity about Web Player installation. This doesn't do anything if the Web Player is already installed.
    * <span class=component>enableGoogleAnalytics</span> -Default: true, Notifies Unity about Web Player installation using Google Analytics. This doesn't do anything if the Web Player is already installed.
    * <span class=component>params</span> - Default: {}, Extra parameters to be used when embedding the Player. Those are usefull to customize the Unity experience:
        * <span class=component>backgroundcolor</span> -  Default: "FFFFFF", The background color of the web player content display region during loading, the default is white. <span class=keyword>Pro Only</span>
        * <span class=component>bordercolor</span> - Default: "FFFFFF",  The color of the one pixel border drawn around the web player content display region during loading. <span class=keyword>Pro Only</span>
        * <span class=component>textcolor</span> - Default: "000000", The color of error message text (when data file fails to load for example). <span class=keyword>Pro Only</span>
        * <span class=component>logoimage</span> - Default: unity Logo, The path to a custom logo image, the logo image is drawn centered within the web player content display region during loading. <span class=keyword>Pro Only</span>
        * <span class=component>progressbarimage</span> - The path to a custom image used as the progress bar during loading. The progress bar image's width is clipped based on the amount of file loading completed, therefore it starts with a zero pixel width and animates to its original width when the loading is complete. The progress bar is drawn beneath the logo image. <span class=keyword>Pro Only</span>
        * <span class=component>progressframeimage</span> - The path to a custom image used to frame the progress bar during loading. <span class=keyword>Pro Only</span>
        * <span class=component>disableContextMenu</span> - This parameter controls whether or not the Unity Web Player displays a context menu when the user right- or control-clicks on the content. Setting it to true prevents the context menu from appearing and allows content to utilize right-mouse behavior. To enable the context menu don't include this parameter.
        * <span class=component>disableExternalCall</span> - This parameter controls whether or not the Unity Web Player allows content to communicate with browser-based JavaScript. Setting it to true prevents browser communication and so content cannot call or execute JavaScript in the browser, the default is false.
        * <span class=component>disableFullscreen</span> - This parameter controls whether or not the Unity Web Player allows content to be viewed in fullscreen mode. Setting it to true prevents fullscreen viewing and removes the "Go Fullscreen" entry from the context menu, the default is false.
    * <span class=component>attributes</span> - Default: {}, Object containing list of attributes. These will be added to underlying <span class=component><object></span> or <span class=component><embed></span> tag depending on the browser.
    * <span class=component>debugLevel</span> - Default: 0, Enables/Disables logging, useful when developing to be able to see the progress on the browser console. Set it greater to 0 to enable.

_Notes_:
All color values provided must be 6-digit hexidecimal colors, (eg. FFFFFF, 020F16, etc.). The image paths provided can be either relative or absolute links and all image files must be RGB (without transparency) or RGBA (with transparency) 8-bit/channel PNG files. Finally, the progressframeimage and the progressbarimage should be the same height.

Functions
---------


###observeProgress
You can register a callback that will receive notifications during the plugin installation and/or initialization.

_Parameters:_

* <span class=component>callback</span> - Callback function that will receive information about the plugin installation/initialization. This callback will receive an <span class=component>progress</span> object.
    * <span class=component>progress</span> - It contains information about the current step of the plugin installation/initialization.
        * <span class=component>pluginStatus</span> - Will contain a string identifying the plugin status, can be one of those:
            * <span class=component>unsupported</span>` - The current Browser/OS is not supported
            * <span class=component>missing</span> - Supported platform, but the plugin haven't be installed yet.
            * <span class=component>installed</span> - The plugin have finished installing, or was already installed.
            * <span class=component>first</span> - called after the plugin have been installed at the first frame of the game is played (This will not be called if the plugin was already installed previously)
        * <span class=component>targetEl</span> - The DOM Element serving as a container for the webplayer (This is the same element you pass to UnityObject2.initPlugin)
        * <span class=component>bestMethod</span> - If the plugin is missing will contain the best installation path for the current platform, can be one of the following strings:
            * <span class=component>JavaInstall</span> - It will use our "One Click" Java Applet to install the plugin
            * <span class=component>ClickOnceIE</span> - It will use Internet Explorer's Click Once install
            * <span class=component>Manual</span> - It will ask the user to download a file and install it manually.
        * <span class=component>unityObj</span>- A reference to the previously created unityObject2 instance responsible for this callback
        * <span class=component>ua</span> - Contains some User Agent information used to decide the pluginStatus and bestMethod.

<a id="initPlugin"></a>
###initPlugin
This will actually try to start up your game. And call the callback you previously registered at the appropriated moments. Note that 

_Parameters:_
* <span class=component>containerElement</span> - The DOM Element serving as a container for the webplayer
* <span class=component>gameURL</span> - URL to the web player data file (.unity3d). Can be relative or absolute.

_Notes_:
This function should be called after the containerElement is present on the DOM, to be safe, you could wait for the DOM to load completely before calling it.

###installPlugin
Tries to install the plugin using the specified <span class=component>method</span>. If no method is passed, it will try to use this.getBestInstallMethod().

_Parameters:_
* <span class=component>method</span> - Default: this.<span class=component>getBestInstallMethod</span>(). A string specifying which method to use for installation. It can be one of the following values: JavaInstall, ClickOnceIE, Manual.

_Notes_:
Not all methods are available in every platform/browser. Manual will download an exe/dmg installer and the user will need to perform a manual installation.


###getUnity
This will return a reference to the player, so you can Call SendMessage from it for instance.

_Notes_:
Will return null if the WebPlayer has not been initialized yet.


_Example:_
This exemplifies a very simple UnityObject2 usage. If the user already has the plugin installed, the WebPlayer will load normally, otherwise it will reveal a hidden `div.missing` and attach a click event to the install button. After installation is succeeded, the screen is hidden, and the webplayer is loaded normally.
````

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Unity Web Player | "Sample"</title>
	<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
	<script type="text/javascript">
		<!--
		var unityObjectUrl = "http://webplayer.unity3d.com/download_webplayer_beta/3.0/uo/UnityObject2.js";
		if (document.location.protocol == 'https:')
			unityObjectUrl.replace("http://", "https://ssl-");
		document.write('<script type="text\/javascript" src="' + unityObjectUrl + '"><\/script>');
		-->
	</script>
        <script type="text/javascript">
		var u = new UnityObject2();
		u.observeProgress(function (progress) {
			var $missingScreen = jQuery(progress.targetEl).find(".missing");
			switch(progress.pluginStatus) {
				case "unsupported":
					showUnsupported();
				break;
				case "broken":
					alert("You will need to restart your browser after installation.");
				break;
				case "missing":
					$missingScreen.find("a").click(function (e) {
						e.stopPropagation();
						e.preventDefault();
						u.installPlugin();
						return false;
					});
					$missingScreen.show();
				break;
				case "installed":
					$missingScreen.remove();
				break;
				case "first":
				break;
			}
		});
		jQuery(function(){
			u.initPlugin(jQuery("#unityPlayer")[0], "Example.unity3d");
		});
        </script>
    </head>
	<body>
		<p class="header">
			<span>Unity Web Player | </span>WebPlayer
		</p>
		<div class="content">
			<div id="unityPlayer">
				<div class="missing">
					<a href="http://unity3d.com/webplayer/" title="Unity Web Player. Install now!">
						<img alt="Unity Web Player. Install now!" src="http://webplayer.unity3d.com/installation/getunity.png" width="193" height="63" />
					</a>
				</div>
			</div>
		</div>
		<p class="footer">&laquo; created with <a href="http://unity3d.com/unity/" title="Go to unity3d.com">Unity</a> &raquo;</p>
	</body>
</html>

````

