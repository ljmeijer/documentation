Working with UnityObject
========================


<span class=keyword>UnityObject</span> is a JavaScript script that simplifies Unity content embedding into HTML. It has functions to detect the Unity <span class=keyword>Web Player</span> plugin, initiate Web Player installation and embed Unity content. Although it's possible to deploy <span class=component>UnityObject.js</span> file on the web server alongside the HTML file it's best to load it directly from the Unity server at <span class=component>[=http://webplayer.unity3d.com/download_webplayer-3.x/3.0/uo/UnityObject.js=]</span>. That way you will always reference the most up to date version of UnityObject. Please note that the <span class=component>UnityObject.js</span> file hosted on the Unity server is minified to make it smaller and save traffic. If you want to explore the source code you can find the original file in the <span class=component>Data\Resources</span> folder on Windows and the <span class=component>Contents/Resources</span> folder on Mac OS X.  UnityObject by defaults sends anonymous data to GoogleAnalytics which is used to help us identify installation type and conversion rate.

Functions
---------


###embedUnity

Embeds Unity content into HTML.

_Parameters:_

* <span class=component>id</span> - HTML element (placeholder) to be replaced by Unity content.
* <span class=component>src</span> - Path to the web player data file. Can be relative or absolute.
* <span class=component>width</span> - Width of Unity content. Can be specified in pixel values (i.e. <span class=component>600</span>, <span class=component>"450"</span>) or in percentage values (i.e. <span class=component>"50%"</span>, <span class=component>"100%"</span>).
* <span class=component>height</span> - Height of Unity content. Can be specified in pixel values (i.e. <span class=component>600</span>, <span class=component>"450"</span>) or in percentage values (i.e. <span class=component>"50%"</span>, <span class=component>"100%"</span>).
* <span class=component>params</span> - _Optional._ Object containing list of parameters. See [Customizing the Unity Web Player loading screen](CustomizingtheUnityWebPlayerloadingscreen.md) and [Customizing the Unity Web Player's Behavior](WebPlayerBehaviorTags.md) for possible values.
* <span class=component>attributes</span> - _Optional._ Object containing list of attributes. These will be added to underlying <span class=component><object></span> or <span class=component><embed></span> tag depending on the browser.
* <span class=component>callback</span> - _Optional._ Function that will be called once Web Player is loaded. Function must accept single argument that contains following properties:
    * <span class=component>success</span> - Boolean value indicating whether operation has succeeded.
    * <span class=component>id</span> - Identifier of the Web Player object that has been loaded (same as placeholder).
    * <span class=component>ref</span> - Web Player object that has been loaded.

_Notes:_

This function usually returns before the operation fully completes. Thus it is not safe to access the Web Player object immediately. A callback function can be provided to get notification on completion. Alternatively call <span class=component>getObjectById</span> repeatedly until it doesn't return a <span class=component>null</span> value.

_Example:_

````

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>Unity Web Player | Example</title>
		<script type="text/javascript" src="http://webplayer.unity3d.com/download_webplayer-3.x/3.0/uo/UnityObject.js"></script>
		<script type="text/javascript">
		<!--
		if (typeof unityObject != "undefined") {
			unityObject.embedUnity("unityPlayer", "Example.unity3d", 600, 450, null, null, unityLoaded);
		}
		function unityLoaded(result) {
			if (result.success) {
				var unity = result.ref;
				var version = unity.GetUnityVersion("3.x.x");
				alert("Unity Web Player loaded!\nId: " + result.id + "\nVersion: " + version);
			}
			else {
				alert("Please install Unity Web Player!");
			}
		}
		-->
		</script>
	</head>
	<body>
		<!-- This will be replaced by Unity content. -->
		<div id="unityPlayer">Unity content can't be played. Make sure you are using compatible browser with JavaScript enabled.</div>
	</body>
</html>

````

###getObjectById

Retrieves the Web Player object.

_Parameters:_

* <span class=component>id</span> - Identifier of the Web Player object.
* <span class=component>callback</span> - _Optional._ Function that will be called once Web Player is retrieved. This function must accept a single parameter that contains the Web Player object.

Returns the Web Player object or <span class=component>null</span> if the Web Player is not loaded yet.

_Example:_

````

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>Unity Web Player | Example</title>
		<script type="text/javascript" src="http://webplayer.unity3d.com/download_webplayer-3.x/3.0/uo/UnityObject.js"></script>
		<script type="text/javascript">
		<!--
		if (typeof unityObject != "undefined") {
			unityObject.embedUnity("unityPlayer", "Example.unity3d", 600, 450, null, null, function(result) {
				if (result.success) {
					var versionButton = document.getElementById("versionButton");
					versionButton.disabled = false;
				}
			});
		}
		function versionButtonClick() {
			var unity = unityObject.getObjectById("unityPlayer");
			var version = unity.GetUnityVersion("3.x.x");
			alert(version);
		}
		-->
		</script>
	</head>
	<body>
		<!-- This will be replaced by Unity content. -->
		<div id="unityPlayer">Unity content can't be played. Make sure you are using compatible browser with JavaScript enabled.</div>
		<div>
			<input id="versionButton" type="button" value="Version" disabled="disabled" onclick="versionButtonClick();" />
		</div>
	</body>
</html>

````

###enableFullInstall

Installs the full Web Player if not available. Normally only a small part of the Web Player is installed and the remaining files are automatically downloaded later. The default value is <span class=component>false</span>.

_Parameters:_

* <span class=component>value</span> - Boolean value that enables or disables the feature.

###enableAutoInstall

Automatically starts Web Player installation if not available. Some platforms don't support this feature. Default value is <span class=component>false</span>.

_Parameters:_

* <span class=component>value</span> - Boolean value that enables or disables the feature.

###enableJavaInstall

Enables Java based installation. Some platforms doesn't support this feature. Default value is <span class=component>true</span>.

_Parameters:_

* <span class=component>value</span> - Boolean value that enables or disables the feature.

###enableClickOnceInstall

Enables ClickOnce based installation. Some platforms doesn't support this feature. Default value is <span class=component>true</span>.

_Parameters:_

* <span class=component>value</span> - Boolean value that enables or disables the feature.

###enableGoogleAnalytics

Notifies Unity about Web Player installation. This doesn't do anything if the Web Player is already installed. Default value is <span class=component>true</span>.

_Parameters:_

* <span class=component>value</span> - Boolean value that enables or disables the feature.

###addLoadEvent

Registers a function that will be called once the web page is loaded.

_Parameters:_

* <span class=component>event</span> - Function that will be called once the web page is loaded. This function does not expect any parameters.

###addDomLoadEvent

Registers a function that will be called once the web page's DOM is loaded.

_Parameters:_

* <span class=component>event</span> - Function that will be called once web page's DOM is loaded. This function does not expect any parameters.

