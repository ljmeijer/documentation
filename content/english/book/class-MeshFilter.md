Mesh Filter
===========


The <span class=keyword>Mesh Filter</span> takes a mesh from your assets and passes it to the [Mesh Renderer](class-MeshRenderer.md) for rendering on the screen.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-MeshFilter.png)  
_A Mesh Filter combined with a Mesh Renderer makes the model appear on screen. _


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Mesh</span> |Reference to a [mesh](class-Mesh.md) that will be rendered. The <span class=component>Mesh</span> is located in your Project Folder. |


Details
-------

When importing mesh assets, Unity automatically creates a [Skinned Mesh Renderer](class-SkinnedMeshRenderer.md) if  the mesh is skinned, or a Mesh Filter along with a Mesh Renderer, if it is not.

To see the Mesh in your scene, add a [Mesh Renderer](class-MeshRenderer.md) to the GameObject.  It should be added automatically, but you will have to manually re-add it if you remove it from your object.  If the Mesh Renderer is not present, the Mesh will still exist in your scene (and computer memory) but it will not be drawn.
