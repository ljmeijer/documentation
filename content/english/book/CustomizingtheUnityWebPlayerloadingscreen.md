Customizing the Unity Web Player loading screen
===============================================


By default the Unity <span class=keyword>Web Player</span> displays a small Unity logo and a progress bar while loading web player content. It is possible to customize the appearance of that loading screen, including both the logo and progress bar display.

Please note that modifying the loader images is only possible with <span class=keyword>Unity Pro</span>.

There are six optional parameters that can be passed to <span class=component>UnityObject</span>, which can be used to customize the appearance of the Unity Web Player loading screen. Those optional parameters are:

* <span class=component>backgroundcolor</span>: The background color of the web player content display region during loading, the default is white.
* <span class=component>bordercolor</span>: The color of the one pixel border drawn around the web player content display region during loading, the default is white.
* <span class=component>textcolor</span>: The color of error message text (when data file fails to load for example). The default is black or white, depending on the background color.
* <span class=component>logoimage</span>: The path to a custom logo image, the logo image is drawn centered within the web player content display region during loading.
* <span class=component>progressbarimage</span>: The path to a custom image used as the progress bar during loading. The progress bar image's width is clipped based on the amount of file loading completed, therefore it starts with a zero pixel width and animates to its original width when the loading is complete. The progress bar is drawn beneath the logo image.
* <span class=component>progressframeimage</span>: The path to a custom image used to frame the progress bar during loading.

All color values provided must be 6-digit hexidecimal colors, (eg. FFFFFF, 020F16, etc.). The image paths provided can be either relative or absolute links. All images must be PNG files in RGB format (without transparency) or RGBA format (with transparency) stored at eight bits per channel. Finally, the <span class=component>progressframeimage</span> and the <span class=component>progressbarimage</span> should be the same height.

Here is an example script that customizes the appearance of the Unity Web Player loading screen. The background color is set to light gray (<span class=component>A0A0A0</span>), border color to black (<span class=component>000000</span>), text color to white (<span class=component>FFFFFF</span>) and loader images to <span class=component>MyLogo.png</span>, <span class=component>MyProgressBar.png</span> and <span class=component>MyProgressFrame.png</span>. All parameters are grouped into single <span class=component>params</span> object and passed to <span class=component>unityObject.embedUnity</span> method.
````

var params = {
	backgroundcolor: "A0A0A0",
	bordercolor: "000000",
	textcolor: "FFFFFF",
	logoimage: "MyLogo.png",
	progressbarimage: "MyProgressBar.png",
	progressframeimage: "MyProgressFrame.png"
};

unityObject.embedUnity("unityPlayer", "WebPlayer.unity3d", 600, 450, params);

````

