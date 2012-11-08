Textures
========


Decorate the landscape of your terrain by tiling <span class=keyword>Terrain Textures</span> across the entire terrain.  You can blend and combine Terrain Textures to make smooth transitions from one map to another, or to keep the surroundings varied.

Terrain Textures are also called splat maps.  What this means is you can define several repeating high resolution textures and blend between them arbitrarily, using alpha maps which you paint directly onto the Terrain.  Because the textures are not large compared to the size of the terrain, the distribution size of the Textures is very small.

__Note:__ Using an amount of textures in a multiple of four provides the greatest benefit for performance and storage of the Terrain alpha maps.

To being working with textures, click on the <span class=keyword>Paint Textures</span> button \

![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-SplatMapsButton.png)  
in the Inspector.

Adding a Terrain Texture
------------------------


Before you can begin painting Terrain Textures, you will add at least one to the Terrain from your Project folder.  Click the <span class=menu>Options Button->Add Texture...</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-AddTextureMenu.png)  

This will bring up the Add Terrain Texture dialog.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-AddTextureDialog1.png)  
_The Add Terrain Texture dialog_

From here, select a tileable texture in the <span class=component>Splat</span> property.  You can either drag a texture to the property from the Project View, or choose one from the drop-down.

Now, set the <span class=component>Tile Size X</span> and <span class=component>Tile Size Y</span> properties.  The larger the number, the larger each "tile" of the texture will be scaled. Textures with large <span class=component>Tile Sizes</span> will be repeated fewer times across the entire Terrain.  Smaller numbers will repeat the texture more often with smaller tiles.


###u40 Details
In Unity 4, you can also assign a normal map texture. For the normal map to have any effect, the terrain must be using a normal map-capable shader; assign a material with normal mapped terrain shader in [Terrain Settings](terrain-OtherSettings.md) tab.

Click the <span class=menu>Add</span> Button and you'll see your first Terrain Texture tile across the entire Terrain.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-FirstTextureAdded.png)  

Repeat this process for as many Terrain Textures as you like.

Painting Terrain Textures
-------------------------


Once you've added at least two Terrain Textures, you can blend them together in various ways.  This part gets really fun, so let's jump right to the good stuff.

Select the Terrain Texture you want to use.  The currently selected Terrain Texture will be highlighted in blue.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-PaintTexture1.png)  

Select the Brush you want to use.  The currently selected Brush will be highlighted in blue.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-PaintTexture2.png)  

Select the Brush <span class=component>Size</span>, <span class=component>Opacity</span>, and <span class=component>Target Strength</span>.

__Size__ refers to the width of the brush relative to your terrain grid squares

__Opacity__ is the transparency or amount of texture applied for a given amount of time you paint

__Target Strength__ is the maximum opacity you can reach by painting continuously. 


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-PaintTexture3.png)  

Click and drag on the terrain to draw the Terrain Texture.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-PaintTexture3.5.png)  

Use a variety of Textures, Brushes, Sizes, and Opacities to create a great variety of blended styles.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-PaintTexture4.png)  

__Note:__When you have a brush selected, move your mouse over the Terrain in the Scene View and press <span class=menu>F</span>.  This will center the Scene View over the mouse pointer position and automatically zoom in to the <span class=component>Brush Size</span> distance.  This is the quickest & easiest way to navigate around your Terrain while creating it.
