Detail Meshes
=============


Any Terrain decoration that is not trees or grass should be created as a <span class=keyword>Detail Mesh</span>.  This is perfect for things like rocks, 3D shrubbery, or other static items.  To add these, use the <span class=keyword>Paint Foliage</span> button Attach:TerrainGuide-PaintFoliageButton.png . Then choose <span class=menu>Edit Details button->Add Detail Mesh</span>.  You will see the <span class=keyword>Add Detail Mesh</span> dialog appear.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-AddDetailMeshDialog.png)  
_The Add Detail Mesh dialog_


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Detail</span> |The mesh to be used for the detail. |
|<span class=component>Noise Spread</span> |The size of noise-generated clusters of the <span class=component>Detail</span>. Lower numbers mean less noise. |
|<span class=component>Random Width</span> |Limit for the amount of width variance between all detail objects. |
|<span class=component>Random Height</span> |Limit for the amount of height variance between all detail objects. |
|<span class=component>Healthy Color</span> |Color of healthy detail objects, prominent in the center of <span class=component>Noise Spread</span> clusters. |
|<span class=component>Dry Color</span> |Color of dry detail objects, prominent on the outer edges of <span class=component>Noise Spread</span> clusters. |
|<span class=component>Grayscale Lighting</span> |If enabled, detail objects will not be tinted by any colored light shining on the Terrain. |
|<span class=component>Lightmap Factor</span> |How much the detail objects will be influenced by the Lightmap. |
|<span class=component>Render Mode</span> |Select whether this type of detail object will be lit using Grass lighting or normal Vertex lighting. Detail objects like rocks should use Vertex lighting.|


After you've clicked the <span class=menu>Add</span> button, you'll see the Detail mesh appear in the <span class=keyword>Inspector</span>.  Detail meshes and grass will appear next to each other.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-DetailMeshInspector.png)  
_The added Detail mesh appears in the Inspector, beside any Grass objects_

Painting Detail Meshes
----------------------


Painting a Detail mesh works the same as painting textures, trees, or grass. Select the Detail you want to paint, and paint right onto the Terrain in the Scene View.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-PaintingDetailMeshes.png)  
_Painting Detail meshes is very simple_

__Note:__ When you have a brush selected, move your mouse over the Terrain in the Scene View and press <span class=menu>F</span>.  This will center the Scene View over the mouse pointer position and automatically zoom in to the <span class=component>Brush Size</span> distance.  This is the quickest & easiest way to navigate around your Terrain while creating it.

Editing Details
---------------


To change any import parameters for a Detail Mesh, select it and choose <span class=menu>Edit Details button->Edit</span>.  You will then see the <span class=keyword>Edit Detail Mesh</span> dialog appear, and be able to adjust the parameters described above.

Refreshing Source Assets
------------------------


If you make any updates to your Detail Mesh asset source file, it must be manually re-imported into the Terrain.  To do this, use <span class=menu>Terrain->Refresh Tree and Detail Prototypes</span>.  This is done after you've changed your source asset and saved it, and will refresh the Detail Meshes in your Terrain immediately.

Hints:
------

* The UVs of the detail mesh objects need to be in the 0-1 range because all the separate textures used for all the detail meshes are packed into a single texture atlas.

