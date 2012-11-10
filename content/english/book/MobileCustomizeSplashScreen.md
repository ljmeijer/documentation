Customizing the Splash screen of Your Mobile Application
========================================================



##ios Details
Under iOS Basic, a default splash screen will be displayed while your game loads, oriented according to the <span class=component>Default Screen Orientation</span> option in the [Player Settings](class-PlayerSettings.md).

Users with an iOS Pro license can use any texture in the project as a splash screen. The size of the texture depends on the target device (320x480 pixels for 1-3rd gen devices, 1024x768 for iPad, 640x960 for 4th gen devices) and supplied textures will be scaled to fit if necessary. You can set the splash screen textures using the [iOS Player Settings](Main.class-PlayerSettings.md).


<a id="Android"></a>

##android Details
Under Android Basic, a default splash screen will be displayed while your game loads, oriented according to the <span class=component>Default Screen Orientation</span> option in the [Player Settings](class-PlayerSettings.md).

Android Pro users can use any texture in the project as a splash screen. You can set the texture from the Splash Image section of the Android [Player Settings](Main.class-PlayerSettings.md). You should also select the <span class=component>Splash scaling</span> method from the following options:-
* <span class=component>Center (only scale down)</span> will draw your image at its natural size unless it is too large, in which case it will be scaled down to fit.
* <span class=component>Scale to fit (letter-boxed)</span> will draw your image so that the longer dimension fits the screen size exactly. Empty space around the sides in the shorter dimension will be filled in black.
* <span class=component>Scale to fill (cropped)</span> will scale your image so that the shorter dimension fits the screen size exactly. The image will be cropped in the longer dimension.

