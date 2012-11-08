Line Renderer
=============


The <span class=keyword>Line Renderer</span> takes an array of two or more points in 3D space and draws a straight line between each one. A single Line Renderer Component can thus be used to draw anything from a simple straight line, to a complex spiral. The line is always continuous; if you need to draw two or more completely separate lines, you should use multiple GameObjects, each with its own Line Renderer.

The Line Renderer does not render one pixel thin lines. It renders billboard lines that have width and can be textured. It uses the same algorithm for line rendering as the [Trail Renderer](class-TrailRenderer.md).


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-LineRenderer.png)  
_The Line Renderer <span class=keyword>Inspector</span>_

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Materials</span>     |The first material from this list is used to render the lines. |
|<span class=component>Positions</span>     |Array of Vector3 points to connect. |
|>>><span class=component>Size</span>       |The number of segments in this line. |
|<span class=component>Parameters</span>    |List of parameters for each line: |
|>>><span class=component>StartWidth</span> |Width at the first line position. |
|>>><span class=component>EndWidth</span>   |Width at the last line position. |
|>>><span class=component>Start Color</span>|Color at the first line position. |
|>>><span class=component>End Color</span>  |Color at the last line position. |
|<span class=component>Use World Space</span>   |If enabled, the object's position is ignored, and the lines are rendered around world origin. |

Details
-------


To create a line renderer:
1. Choose <span class=menu>GameObject->Create Empty</span>
1. Choose <span class=menu>Component->Miscellaneous->Line Renderer</span>
1. Drag a texture or <span class=keyword>Material</span> on the Line Renderer. It looks best if you use a particle shader in the Material.

Hints
-----

* Line Renderers are good to use for effects when you need to lay out all the vertices in one frame.
* The lines may seem to rotate as you move the <span class=keyword>Camera</span>. This is intentional.
* The Line Renderer should be the only Renderer on a GameObject.
