How do I Use Normal Maps?
=========================


<span class=keyword>Normal maps</span> are grayscale images that you use as a height map on your objects in order to give an appearance of raised or recessed surfaces. Assuming you have a model that looks like this:


![](http://docwiki.hq.unity3d.com/uploads/Main/Bumpmap1.png)  
_The 3D Model_


![](http://docwiki.hq.unity3d.com/uploads/Main/Bumpmap2.png)  
_The Texture_

We want to make the light parts of the object appear raised.

1. Draw a grayscale height map of your texture in Photoshop. White is high, black is low. Something like this: [<<](<<.md) Attach:Bumpmap3.png

1. Save the image next to your main texture.
1. In Unity, select the image and select the 24 bit RGB format and enable <span class=component>Generate Normal Map</span> in the <span class=keyword>Import Settings</span> in the <span class=keyword>Inspector</span>: [<<](<<.md)
  

![](http://docwiki.hq.unity3d.com/uploads/Main/Bumpmap4.png)  

1. In the <span class=keyword>Material Inspector</span> of your model, select 'Bumped Diffuse' from the Shader drop-down: [<<](<<.md) Attach:Bumpmap5.png

1. Drag your texture from the Project window to the 'Normalmap' texture slot: [<<](<<.md) Attach:Bumpmap6.png

Your object now has a normal map applied:


![](http://docwiki.hq.unity3d.com/uploads/Main/Bumpmap7.png)  

Hints
-----

* To make the bumps more noticable, either use the Bumpyness slider in the Texture Import Settings or blur the texture in Photoshop. Experiment with both approaches to get a feel for it.
