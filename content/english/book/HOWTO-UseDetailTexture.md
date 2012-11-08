How do I use Detail Textures?
=============================


A <span class=keyword>Detail texture</span> is a small, fine pattern which is faded in as you approach a surface, for example wood grain, imperfections in stone, or earthly details on a terrain.  They are explicitly used with the [Diffuse Detail shader](shader-NormalDiffuseDetail.md).

Detail textures must tile in all directions. Color values from 0-127 makes the object it's applied to darker, 128 doesn't change anything, and lighter colors make the object lighter. It's very important that the image is centered around 128 - otherwise the object it's applied to will get lighter or darker as you approach.

1. Draw or find a grayscale image of the detail texture.

![](http://docwiki.hq.unity3d.com/uploads/Main/HOWTO-detail1.png)  
_The Detail Texture_  
  

![](http://docwiki.hq.unity3d.com/uploads/Main/HOWTO-detail2.png)  
_The Levels_

1. Save the image next to your main texture.
1. In Unity, select the image and under "Generate Mip Maps", enable <span class=component>Fades Out</span> and set the sliders to something like this in the <span class=keyword>Import Settings</span> in the <span class=keyword>Inspector</span>.
1. The top slider determines how small the texture should before before beginning to fade out, and the bottom determines how far away it is before the detail texture completely disapear.
  

![](http://docwiki.hq.unity3d.com/uploads/Main/HOWTO-detailmipmaps.png)  
s.
1. In the <span class=keyword>Material Inspector</span> on the right, select <span class=menu>Diffuse Detail</span> from the Shader drop-down:

![](http://docwiki.hq.unity3d.com/uploads/Main/HOWTO-detail3.png)  

1. Drag your texture from the <span class=keyword>Project View</span> to the <span class=component>Detail</span> texture slot.
1. Set the <span class=component>Tiling</span> values to a high value

![](http://docwiki.hq.unity3d.com/uploads/Main/HOWTO-detail4.png)  



