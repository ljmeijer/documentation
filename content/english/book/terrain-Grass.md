Grass
=====


The <span class=keyword>Paint Foliage</span> button Attach:TerrainGuide-PaintFoliageButton.png allows you to paint grass, rocks, or other decorations around the Terrain.  To paint grass, choose <span class=menu>Edit Details button->Add Grass Texture</span>.  You don't need to create a mesh for grass, just a texture.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-AddGrassTextureDialog.png)  
_The Add Grass Texture dialog_

At this dialog, you can fine-tune the appearance of the grass with the following options:


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Detail Texture</span> |The texture to be used for the grass. |
|<span class=component>Min Width</span> |Minimum width of each grass section in meters. |
|<span class=component>Max Width</span> |Maximum width of each grass section in meters. |
|<span class=component>Min Height</span> |Minimum height of each grass section in meters. |
|<span class=component>Max Height</span> |Maximum height of each grass section in meters. |
|<span class=component>Noise Spread</span> |The size of noise-generated clusters of grass. Lower numbers mean less noise. |
|<span class=component>Healthy Color</span> |Color of healthy grass, prominent in the center of <span class=component>Noise Spread</span> clusters. |
|<span class=component>Dry Color</span> |Color of dry grass, prominent on the outer edges of <span class=component>Noise Spread</span> clusters. |
|<span class=component>Grayscale Lighting</span> |If enabled, grass textures will not be tinted by any colored light shining on the Terrain. |
|<span class=component>Lightmap Factor</span> |How much the grass will be influenced by the Lightmap. |
|<span class=component>Billboard</span> |If checked, this grass will always rotate to face the main <span class=keyword>Camera</span>. |

After you've clicked the <span class=menu>Add</span> button, you'll see the grass appear selectable in the <span class=keyword>Inspector</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-AddedGrassInspector.png)  
_The added grass appears in the Inspector_

Painting Grass
--------------


Painting grass works the same as painting textures or trees.  Select the grass you want to paint, and paint right onto the Terrain in the <span class=keyword>Scene View</span>


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-PaintingGrass.png)  
_Painting grass is easy as pie_

__Note:__When you have a brush selected, move your mouse over the Terrain in the Scene View and press <span class=menu>F</span>.  This will center the Scene View over the mouse pointer position and automatically zoom in to the <span class=component>Brush Size</span> distance.  This is the quickest & easiest way to navigate around your Terrain while creating it.

Editing Grass
-------------


To change any import parameters for a particular Grass Texture, select it choose <span class=menu>Edit Details button->Edit</span>.  You can also double-click it.  You will then see the <span class=keyword>Edit Grass</span> dialog appear, and be able to adjust the parameters described above.

You'll find that changing a few parameters can make a world of difference.  Even changing the <span class=component>Max/Min Width</span> and <span class=component>Height</span> parameters can vastly change the way the grass looks, even with the same number of grass objects painted on the Terrain.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-GrassParam1.png)  
_Grass created with the default parameters_


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-GrassParam2.png)  
_The same number of painted grass objects, now wider and taller_

