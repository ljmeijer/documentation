Material
========


Materials are used in conjunction with [Mesh](class-MeshRenderer.md) or [Particle Renderers](class-ParticleRenderer.md) attached to the <span class=keyword>GameObject</span>.  They play an essential part in defining how your object is displayed.  Materials include a reference to the <span class=keyword>Shader</span> used to render the <span class=keyword>Mesh</span> or <span class=keyword>Particles</span>, so these Components can not be displayed without some kind of Material.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-MaterialSimple.png)  
_A Diffuse Shader Material has only two properties - a color and a texture._

Properties
----------

The properties of any Material will change depending on the selected __Shader__.  These are the most often used properties:

|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Shader</span> |The Shader that will be used by the Material. For more information, read the [Built-in Shader Guide](Built-inShaderGuide.md). |
|<span class=component>Main Color</span> |Any kind of color tint can be applied.  Use white for no tint. |
|<span class=component>Base</span> |The <span class=keyword>Texture</span> that will be displayed. |


Details
-------


Materials are used to place [Textures](class-Texture2D.md) onto your GameObjects.  You cannot add a Texture directly without a Material, and doing so will implicitly create a new Material.  The proper workflow is to create a Material, select a Shader, and choose the Texture asset(s) to display along with it.  For more information on Materials, take a look at the Manual's page about [Materials](Materials.md).


###Choosing Shaders

After you create your material, the first thing you should decide is which Shader to use.  You choose it from the drop-down <span class=component>Shader</span> menu.


![](http://docwiki.hq.unity3d.com/uploads/Main/Material-ShaderMenu.png)  
_The <span class=component>Shader</span> drop-down menu_

You can choose any Shader that exists in your project's assets folder or one of the built-in Shaders. You can also create your own Shaders.  For more information on using the built-in Shaders, view the [ShaderLab Reference](Built-inShaderGuide]].Forinformationonwritingyourownshaders,takealookatthe[Shaders](Shaders.md)sectionoftheManualand[[SL-Reference.md).


###Setting shader properties

Depending on the type of shader selected, a number of different properties can appear in the <span class=keyword>Inspector</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-MaterialSpec.png)  
_Properties of a Specular shader_


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-MaterialBump.png)  
_Properties of a Normal mapped shader_


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-MaterialBumpSpec.png)  
_Properties of a Normal mapped Specular shader_

The different types of Shader properties are:


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=keyword>Color pickers</span> |Used to choose colors. |
|<span class=keyword>Sliders</span> |Used to tweak a number value across the allowed range. |
|<span class=keyword>Textures</span> |Used to select textures. |


###Texture placement

The placement of the textures can be altered by changing the <span class=component>Offset</span> and <span class=component>Tiling</span> properties.


![](http://docwiki.hq.unity3d.com/uploads/Main/Material-Placement.png)  
_This texture is tiled 2x2 times by changing the <span class=component>Tiling</span> properties_


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Offset</span> |Slides the Texture around. |
|<span class=component>Tiling</span> |Tiles the Texture along the different axes. |

Hints
-----

* It is a good practice to share a single Material across as many GameObjects as possible.  This has great performance benefits.

