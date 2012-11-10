GUI Texture
===========


<span class=keyword>GUI Textures</span> are displayed as flat images in 2D. They are made especially for user interface elements, buttons, or decorations.  Their positioning and scaling is performed along the x and y axes only, and they are measured in <span class=keyword>Screen Coordinates</span>, rather than <span class=keyword>World Coordinates</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-GUITexture.png)  
_The GUI Texture <span class=keyword>Inspector</span>_

__Please Note__: Unity 2.0 introduced <span class=keyword>UnityGUI</span>, a GUI Scripting system.  You may prefer creating user interface elements with UnityGUI instead of GUI Textures.  Read more about how to use UnityGUI in the [GUI Scripting Guide](GUIScriptingGuide.md).


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Texture</span>     |Reference to the [Texture](class-Texture2D.md) that will be used as the texture's display. |
|<span class=component>Color</span>       |Color that will tint the <span class=component>Texture</span> drawn on screen. |
|<span class=component>Pixel Inset</span> |Used for pixel-level control of the scaling and positioning of the GUI Texture. All values are measured relative to the position of the GUI Texture's <span class=keyword>Transform</span>. |
|>>><span class=component>X</span> |Left-most pixel position of the texture.   |
|>>><span class=component>Y</span> |Bottom-most pixel position of the texture. |
|>>><span class=component>Width</span> |Right-most pixel position of the texture.  |
|>>><span class=component>Height</span> |Top-most pixel position of the texture.    |
|<span class=component>Left Border</span>   |Number of pixels from the left that are not affected by scale.   |
|<span class=component>Right Border</span>  |Number of pixels from the right that are not affected by scale.  |
|<span class=component>Top Border</span>    |Number of pixels from the top that are not affected by scale.    |
|<span class=component>Bottom Border</span> |Number of pixels from the bottom that are not affected by scale. |

Details
-------


To create a GUITexture:

1. Select a Texture in the <span class=keyword>Project View</span>
1. Choose <span class=menu>GameObject->Create Other->GUI Texture</span> from the menu bar

GUI Textures are perfect for presenting game interface backgrounds, buttons, or other elements to the player.  Through scripting, you can easily provide visual feedback for different "states" of the texture -- when the mouse is hovering over the texture, or is actively clicking it for example.  Here is the basic breakdown of how the GUI Texture is calculated:


![](http://docwiki.hq.unity3d.com/uploads/Main/GUITexture-Layout.jpg)  
_GUI Textures are laid out according to these rules_


![](http://docwiki.hq.unity3d.com/uploads/Main/GUITexture-Example.png)  
_The GUI elements seen here were all created with GUI Textures_


###Borders

The number of pixels that will not scale with the texture at each edge of the image.  As you rarely know the resolution your game runs in, chances are your GUI will get scaled. Some GUI textures have a border at the edge that is meant to be an exact number of pixels. In order for this to work, set the border sizes to match those from the texture.


###Pixel Inset

The purpose of the <span class=component>Pixel Inset</span> is to prevent textures from scaling with screen resolution, and keeping thim in a fixed pixel size. This allows you to render a texture without any scaling.  This means that players who run your game in higher resolutions will see your textures in smaller areas of the screen, allowing them to have more screen real-estate for your gameplay graphics.

To use it effectively, you need to set the scale of the GUI Texture's Transform to (0, 0, 0). Now, the <span class=component>Pixel Inset</span> is in full control of the texture's size and you can set the <span class=component>Pixel Inset</span> values to be the exact pixel size of your Texture.


Hints
-----


* The depth of each layered GUI Texture is determined by its individual Z Transform position, not the global Z position.
* GUI Textures are great for making menu screens, or pause/escape menu screens.
* You should use <span class=component>Pixel Inset</span> on any GUI Textures that you want to be a specific number of pixels for the width and height.
