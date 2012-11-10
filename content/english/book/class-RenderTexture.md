Render Texture
==============


<span class=keyword>Render Textures</span> are special types of <span class=keyword>Textures</span> that are created and updated at runtime. To use them, you first create a new Render Texture and designate one of your [Cameras](class-Camera.md) to render into it. Then you can use the Render Texture in a <span class=keyword>Material</span> just like a regular Texture. The [Water](HOWTO-Water.md) prefabs in Unity Standard Assets are an example of real-world use of Render Textures for making real-time reflections and refractions.

Render Textures are a Unity Pro feature.


Properties
----------


The Render Texture <span class=keyword>Inspector</span> is different from most Inspectors, but very similar to the [Texture Inspector](class-Texture2D.md).


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-RenderTexture.png)  
_The Render Texture Inspector is almost identical to the Texture Inspector_

The Render Texture inspector displays the current contents of Render Texture in realtime and can be an invaluable debugging tool for effects that use render textures.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Size</span> |The size of the Render Texture in pixels. Observe that only power-of-two values sizes can be chosen. |
|<span class=component>Aniso Level</span> |Increases Texture quality when viewing the texture at a steep angle. Good for floor and ground textures |
|<span class=component>Filter Mode</span> |Selects how the Texture is filtered when it gets stretched by 3D transformations: |
|>>><span class=component>No Filtering</span> |The Texture becomes blocky up close |
|>>><span class=component>Bilinear</span> |The Texture becomes blurry up close |
|>>><span class=component>Trilinear</span> |Like Bilinear, but the Texture also blurs between the different mip levels |
|<span class=component>Wrap Mode</span> |Selects how the Texture behaves when tiled: |
|>>><span class=component>Repeat</span> |The Texture repeats (tiles) itself |
|>>><span class=component>Clamp</span> |The Texture's edges get stretched |


Example
-------


A very quick way to make a live arena-camera in your game:
1. Create a new Render Texture asset using <span class=menu>Assets->Create->Render Texture</span>.
1. Create a new Camera using <span class=menu>GameObject->Create Other->Camera</span>.
1. Assign the Render Texture to the <span class=component>Target Texture</span> of the new Camera.
1. Create a wide, tall and thin box
1. Drag the Render Texture onto it to create a Material that uses the render texture.
1. Enter Play Mode, and observe that the box's texture is updated in real-time based on the new Camera's output.


![](http://docwiki.hq.unity3d.com/uploads/Main/RenderTextureLiveCam.png)  
_Render Textures are set up as demonstrated above_

Hints
=====

* Unity renders everything in the texture assigned to RenderTexture.active.
