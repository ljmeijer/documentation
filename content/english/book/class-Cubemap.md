Cubemap Texture
===============


A <span class=keyword>Cubemap Texture</span> is a collection of six separate square Textures that are put onto the faces of an imaginary cube. Most often they are used to display infinitely faraway reflections on objects, similar to how [Skybox](class-Skybox.md) displays faraway scenery in the background. The [Reflective](shader-ReflectiveFamily.md) built-in shaders in Unity use Cubemaps to display reflection.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-CubeMap.png)  
_A mountain scene Cubemap displayed as a reflection on this sphere_

You create Cubemap in one of several ways:
1. Use <span class=menu>Assets->Create->Cubemap</span>, set its properties, and drag six [Texture](class-Texture2D.md) assets onto corresponding Cubemap "faces". Note that the textures must be re-applied if changed because the textures are baked into the Cubemap Asset and are in no way linked to the textures.
1. Use the [Texture](class-Texture2D.md) Import Settings to create a Cubemap from a single imported texture asset.
1. Render your scene into a cubemap from script. Code example in [Camera.RenderToCubemap](ScriptRef:Camera.RenderToCubemap.html) page contains a script for rendering cubemaps straight from the editor.

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Right (+X)</span> |Texture for the right global side of the Cubemap face. |
|<span class=component>Left (-X)</span> |Texture for the up global side of the Cubemap face. |
|<span class=component>Top (+Y)</span> |Texture for the top global side of the Cubemap face. |
|<span class=component>Bottom (-Y)</span> |Texture for the bottom global side of the Cubemap face. |
|<span class=component>Front (+Z)</span> |Texture for the forward global side of the Cubemap face. |
|<span class=component>Back (-Z)</span> |Texture for the rear global side of the Cubemap face. |
|<span class=component>Face Size</span> |Width and Height in pixels across each individual Cubemap face. Textures will be internally scaled to fit this size, there is no need to manually scale the assets. |
|<span class=component>Mipmap</span> |Enable to create mipmaps. |
|<span class=component>Format</span> |Format of the created cubemap. |


