Height
======


Using any of the Terrain editing tools is very simple. You will literally paint the Terrain from within the <span class=keyword>Scene View</span>.  For the height tools and all others, you just have to select the tool, and click the Terrain in Scene View to manipulate it in real-time.

Raising & Lowering Height
-------------------------


The first tool on the left is the <span class=keyword>Raise Height</span> tool \

![](http://docwiki.hq.unity3d.com/uploads/Main/RaiseHeightTool.png)  
.

With this tool, you paint brush strokes that will raise the height of the <span class=keyword>Terrain</span>.  Clicking the mouse once will increment the height.  Keeping the mouse button depressed and moving the mouse will continually raise the height until the maximum height is reached.


![](http://docwiki.hq.unity3d.com/uploads/Main/RaiseHeight1.png)  

You can use any of the brushes to achieve different results


![](http://docwiki.hq.unity3d.com/uploads/Main/DifferentBrushesRaising.png)  

If you want to lower the height when you click, hold the <span class=menu>Shift</span> key.


![](http://docwiki.hq.unity3d.com/uploads/Main/LowerHeight1.png)  

__Note:__When you have a brush selected, move your mouse over the Terrain in the Scene View and press <span class=menu>F</span>.  This will center the Scene View over the mouse pointer position and automatically zoom in to the <span class=component>Brush Size</span> distance.  This is the quickest & easiest way to navigate around your Terrain while creating it.

###Paint Height

The second tool from the left is the <span class=keyword>Paint Height</span> tool \

![](http://docwiki.hq.unity3d.com/uploads/Main/PaintHeightTool.png)  
.

This tool allows you to specify a target height, and move any part of the terrain toward that height.  Once the terrain reaches the target height, it will stop moving and rest at that height.

To specify the target height, hold <span class=menu>Shift</span> and click on the terrain at the height you desire.  You can also manually adjust the <span class=component>Height</span> slider in the Inspector.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-PaintHeightSlider.png)  

Now you've specified the target height, and any clicks you make on the terrain will move the terrain up or down to reach that height.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-PaintedSteps.png)  


###Smoothing Height

The third tool from the left is the <span class=keyword>Smoothing Height</span> tool \

![](http://docwiki.hq.unity3d.com/uploads/Main/SmoothingHeightTool.png)  
.

This tool allows you to soften any height differences within the area you're painting.  Like the other brushes, paint the areas you want to smooth in the Scene View.


![](http://docwiki.hq.unity3d.com/uploads/Main/TerrainGuide-SmoothedSteps.png)  


Working with Heightmaps
-----------------------


If you like, you can import a greyscale Heightmap created in Photoshop, or from real-world geography data and apply it to your Terrain.  To do this, choose <span class=menu>Terrain->Import Heightmap - Raw...</span>, then select the desired RAW file. You'll then see some import settings.  These will be set for you, but you have the option of changing the size of your Terrain from this dialog if you like. When you're ready, click the <span class=menu>Import</span> button. Once the Heightmap has been applied to the Terrain, you can edit it normally with all the Tools described above.
Note that the Unity Heightmap importer can only import grayscale raw files. Thus you can't create a raw heightmap using RGB channels, you must use grayscale.

Unity works with RAW files which make use of full 16-bit resolution. Any other heightmap editing application like Bryce, Terragen, or Photoshop can work with a Unity Heightmap at full resolution.

You also have the option of exporting your Heightmap to RAW format.  Choose <span class=menu>Terrain->Export Heightmap - Raw...</span> and you'll see a export settings dialog.  Make any changes you like, and click <span class=menu>Export</span> to save your new Heightmap.  

Unity also provides an easy way to flatten your terrain. Choose <span class=menu>Terrain->Flatten...</span>.  This lets you flatten your terrain to a height you specify in the wizard.

