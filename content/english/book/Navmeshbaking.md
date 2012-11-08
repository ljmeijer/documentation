Navmesh Baking
==============


Once the Navmesh geometry and layers are marked up, it's time to bake the Navmesh geometry. 

Inside the Navigation window (<span class=menu>Window->Navigation</span>), go to the <span class=menu>Bake</span> tab (the upper-right corner), and click on the <span class=menu>Bake</span> button (the lower-right corner).

![](http://docwiki.hq.unity3d.com/uploads/Main/NavigationBakeWindow.png)  
_Navigation Bake Window_

Here are the properties that affect Navmesh baking: 

|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Radius</span>|radius of the "typical" agent (preferrably the smallest).|
|<span class=component>Height</span> |height of the "typical" agent (the "clearance" needed to get a character through).|
|<span class=component>Max Slope</span> |all surfaces with higher slope than this, will be discarded.|
|<span class=component>Step height</span> |the height difference below which navmesh regions are considered connected.|
|<span class=component>Drop height</span> |If the value of this property is positive, off-mesh links will be placed for adjacent navmesh surfaces where the height difference is below this value.|
|<span class=component>Jump distance</span> |If the value of this property is positive, off-mesh links will be placed for adjacent navmesh surfaces where the horizontal distance is below this value.|
|<span class=component>Advanced</span>|
|>>><span class=component>Min region area</span> |Regions with areas below this threshold will be discarded. |
|>>><span class=component>Width inaccuracy %</span>|Allowable width inaccuracy|
|>>><span class=component>Height inaccuracy %</span>|Allowable height inaccuracy|
|>>><span class=component>Height mesh</span>|If this options is on, original height information is stored. This has performance implications for speed and memory usage. |

Note that the baked navmesh is part of the scene and agents will be able to traverse it. To remove the navmesh, click on <span class=menu>Clear</span> when you're in the <span class=menu>Bake</span> tab.

(back to [Navigation and Pathfinding](NavmeshandPathfinding.md))
