Mesh Renderer
=============


The <span class=keyword>Mesh Renderer</span> takes the geometry from the [Mesh Filter](class-MeshFilter.md) and renders it at the position defined by the object's [Transform](class-Transform.md) component.


![](http://docwiki.hq.unity3d.com/uploads/Main/InspectorMeshRend35.png)  

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Cast Shadows</span> (Pro only) |If enabled, this <span class=keyword>Mesh</span> will create shadows when a shadow-creating [Light](class-Light.md) shines on it |
|<span class=component>Receive Shadows</span> (Pro only) |If enabled, this Mesh will display any shadows being cast upon it |
|<span class=component>Materials</span> |A list of <span class=keyword>Materials</span> to render model with |
|<span class=component>Light Probe Anchor</span>|A <span class=keyword>Transform</span> used to determine the interpolation position when the light probe system is used|
|<span class=component>Use Light Probes</span>|Enable probe-based lighting for this mesh|

Details
-------


Meshes imported from 3D packages can use multiple [Materials](Materials.md). For each Material there is an entry in Mesh Renderer's Materials list, so each submesh in the Mesh is rendered with a different material. If there are more materials assigned to the MeshRenderer then submeshes in the Mesh, then the first submesh will be rendered with each of the remaining materials - this lets you set up multi-pass rendering with multiple materials.

A mesh can receive light from the <span class=keyword>light probe</span> system if the <span class=component>Use Light Probes</span> option is enabled (see the [light probes](LightProbes.md) manual page for further details). A single point is used as the mesh's notional position for light probe interpolation. By default, this is the centre of the mesh's bounding box, but you can override this by dragging a <span class=keyword>Transform</span> to the <span class=component>Light Probe Anchor</span> property. It may be useful to set the anchor in cases where an object contains two adjoining meshes; since each mesh has a separate bounding box, the two will be lit discontinuously at the join by default. However, if you set both meshes to use the same anchor point, they will be consistently lit.
