How do I make a Spot Light Cookie?
==================================


Unity ships with a few <span class=keyword>Light Cookies</span> in the [Standard Assets](HOWTO-InstallStandardAssets.md). When the Standard Assets are imported to your project, they can be found in <span class=menu>Standard Assets->Light Cookies</span>. This page shows you how to create your own.

A great way to add a lot of visual detail to your scenes is to use cookies - grayscale textures you use to control the precise look of in-game lighting. This is fantastic for making moving clouds and giving an impression of dense foilage. The [Light Component Reference page](class-Light.md) has more info on all this, but the main thing is that for textures to be usable for cookies, the following properties need to be set:

To create a light cookie for a spot light:

1. Paint a cookie texture in Photoshop. The image should be greyscale. White pixels means full lighting intensity, black pixels mean no lighting. The borders of the texture need to be completely black, otherwise the light will appear to leak outside of the spotlight.
1. In the <span class=keyword>Texture Inspector</span> change the <span class=component>Repeat</span> Wrap mode to <span class=component>Clamp</span>
1. Select the Texture and edit the following <span class=keyword>Import Settings</span> in the <span class=keyword>Inspector</span>.

1. Enable <span class=component>Border Mipmaps</span>
1. Enable <span class=component>Build Alpha From Grayscale</span> (this way you can make a grayscale cookie and Unity converts it to an alpha map automatically)
1. Set the Texture Format to <span class=component>Alpha 8 Bit</span>


![](http://docwiki.hq.unity3d.com/uploads/Main/SpotlightCookie.png)  

