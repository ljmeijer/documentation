Meshes
======


When a 3D model is imported, Unity represents it internally as a <span class=keyword>Mesh</span>. A Mesh must be attached to a GameObject using a [Mesh Filter](class-MeshFilter.md) component. For the mesh to be visible, the GameObject must also have a [Mesh Renderer](class-MeshRenderer.md) or other suitable rendering component attached. With these components in place, the mesh will be visible at the GameObject's position with its exact appearance dependent on the Material used by the renderer.


![](http://docwiki.hq.unity3d.com/uploads/Main/MeshExample40.png)  
_A [Mesh Filter](class-MeshFilter.md) together with [Mesh Renderer](class-MeshRenderer.md) makes the model appear on screen._

Unity's mesh importer provides many options for controlling the generation of the mesh and associating it with its textures and materials. These options are covered by the following pages:-

(:tocportion:)
