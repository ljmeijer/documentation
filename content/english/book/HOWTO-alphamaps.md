How do I Import Alpha Textures?
===============================


Unity uses straight <span class=keyword>alpha blending</span>. Hence, you need to expand the color layers... The alpha channel in Unity will be read from the first alpha channel in the Photoshop file.

Setting Up
----------

Before doing this, install these alpha utility photoshop actions: [AlphaUtility.atn.zip](Attach:AlphaUtility.atn.zip.md)

After installing, your Action Palette should contain a folder called AlphaUtility:

![](http://docwiki.hq.unity3d.com/uploads/Main/ImportAlpha_actions.png)  

Getting Alpha Right
-------------------

Let's assume you have your alpha texture on a transparent layer inside photoshop. Something like this:

![](http://docwiki.hq.unity3d.com/uploads/Main/ImportAlpha_StartingOut.png)  


1. Duplicate the layer
1. Select the lowest layer. This will be source for the dilation of the background.
1. Select <span class=menu>Layer->Matting->Defringe</span> and apply with the default properties
1. Run the "Dilate Many" action a couple of times. This will expand the background into a new layer.

![](http://docwiki.hq.unity3d.com/uploads/Main/ImportAlpha_Dilate.png)  
1. Select all the dilation layers and merge them with <span class=menu>Command-E</span>

![](http://docwiki.hq.unity3d.com/uploads/Main/ImportAlpha_afterMerge.png)  
1. Create a solid color layer at the bottom of your image stack. This should match the general color of your document (in this case, greenish). Note that without this layer Unity will take alpha from merged transparency of all layers.
    1. Item6##

Now we need to copy the transparency into the alpha layer.

1. Set the selection to be the contents of your main layer by Command-clicking on it in the Layer Palette.
1. Switch to the channels palette.
1. Create a new channel from the transparency.

![](http://docwiki.hq.unity3d.com/uploads/Main/ImportAlpha_createChannel.png)  


Save your PSD file - you are now ready to go.

Extra
-----


Note that if your image contains transparency (after merging layers), then Unity will take alpha from merged transparency of all layers and it will ignore Alpha masks. A workaround for that is to create a layer with solid color as described in [Item 6](#Item6) on "Getting Alpha Right"
