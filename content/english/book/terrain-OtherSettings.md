Other Settings
==============


There are a number of options under the <span class=menu>Terrain Settings</span> button Attach:terrain-TerrainSettings.png in the Terrain Inspector.


![](http://docwiki.hq.unity3d.com/uploads/Main/terrain-OtherSettings.png)  
_All additional Terrain Settings_

Base Terrain
------------


* <span class=component>Pixel Error</span> controls the amount of allowable errors in the display of Terrain Geometry.  This is essentially a geometry LOD setting; the higher the value, the less dense terrain geometry will be.
* <span class=component>Base Map Dist.</span>: The distance that Terrain Textures will be displayed in high-resolution. After this distance, a low-resolution composited texture will be displayed.
* <span class=component>Cast Shadows</span>: Should terrain cast shadows?


###u40 Details
<span class=component>Material</span> slot allows assigning a custom material for the terrain. The material should be using a [shader](Shaders.md) that is capable of rendering terrain, for example <span class=component>Nature/Terrain/Diffuse</span> (this shader is used if no material is assigned) or <span class=component>Nature/Terrain/Bumped Specular</span>.

Tree & Detail Settings
----------------------


* <span class=component>Draw</span>: if enabled, all trees, grass, and detail meshes will be drawn.
* <span class=component>Detail Distance</span> distance from the camera that details will stop being displayed.
* <span class=component>Tree Distance</span>: distance from the camera that trees will stop being displayed.  The higher this is, the further-distance trees can be seen.
* <span class=component>Billboard Start</span>: distance from the camera that trees will start appearing as Billboards instead of Meshes.
* <span class=component>Fade Length</span>: total distance delta that trees will use to transition from Billboard orientation to Mesh orientation.
* <span class=component>Max Mesh Trees</span>: total number of allowed mesh trees to be capped in the Terrain.

Wind Settings
-------------


* <span class=component>Speed</span>: the speed that wind blows through grass.
* <span class=component>Size</span>: the areas of grass that are affected by wind all at once.
* <span class=component>Bending</span>: amount that grass will bend due to wind.
* <span class=component>Grass Tint</span>: overall tint amount for all Grass and Detail Meshes.

