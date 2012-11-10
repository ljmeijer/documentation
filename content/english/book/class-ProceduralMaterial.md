Procedural Material Assets
==========================


Procedural Material Assets are textures that are generated for you at run-time.  See [Procedural Materials](Main.ProceduralMaterials.md) in the User Guide for more information.  A Procedural Material asset can contain one or more procedural materials.  These can be viewed in the Inspector just like regular materials. Note however that often procedural materials have many tweakable parameters.  As with Material assets the Inspector shows a preview of the Procedural Material at the bottom of the window.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-ProceduralMaterial1.png)  
_A Procedural Material viewed in the Inspector._

The Inspector window has 4 main panes.

1. Substance Archive Manager.
1. Properties.
1. Generated Textures.
1. Preview.


Substance Archive Manager
-------------------------


The archive view shows you all the procedural materials that the Procedural Material asset contains.  Select the procedural material you are interested in from the row of previews.  Procedural Materials can be Added and Deleted to the Procedural Material Asset archive using the plus and minus buttons.  Adding a procedural material will create a new material using the prototype encoded in the archive.  The third, Duplicate button will create a new procedural material that is a copy of the currently selected one, including all its settings.  Procedural materials can be renamed by typing in a new name in the material header name field.


Properties
----------


###Material Properties

These are the regular properties of the material, which are dependent on which shader is chosen. They work the same as for regular materials.

###Procedural Properties

The properties of any Procedural Material will change according to how the procedural material was created.

|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Generate at Load</span> |Generate the substance when the scene loads. If disabled, it will only be generated when prompted from scripting. |
|<span class=component>Random Seed</span> |Procedural materials often need some randomness. The Random Seed can be used to vary the generated appearance.  Often this will be zero.  Just click the Randomize button to get a different seed and observe how the material changes. |


Generated Textures
------------------



![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-ProceduralMaterial2.png)  
_The Generated Textures pane._

This area allows you to visualize textures that the procedural material generates.  The dropdown below each of the generated textures allows you to choose which texture map should supply the alpha channel for that texture.  You could, for example, specify that the base alpha comes from the Transparency image, or from the Specular image.  The screen-shot below shows the base alpha channel coming from the Specular image.


###Per-Platform Overrides

When you are building for different platforms, you have to think on the resolution of your textures for the target platform, the size and the quality. You can override these options and assign specific values depending on the platform you are deploying to. Note that if you don't select any value to override, the Editor will pick the default values when building your project.


|    |    |
|:---|:---|
|<span class=component>Target Size</span> |The targeted size of the generated textures. Most procedural textures are designed to be resolution independent and will respect the chosen target size, but in rare cases they will use a fixed size instead, or have the possible sizes limited to within a certain range. The actual size of the generated textures can be read in the preview at the bottom of the Inspector. |
|<span class=component>Texture Format</span> |What internal representation is used for the texture in memory, once it is generated. This is a tradeoff between size and quality: |
|>>><span class=component>Compressed</span> |Compressed RGB texture. This will result in considerably less memory used. |
|>>><span class=component>RAW</span> |Uncompressed truecolor, this is the highest quality. At 256 KB for a 256x256 texture. |


Preview
-------


The procedural material preview operates in an identical manner to the material preview. However, unlike the regular material preview it shows the pixel dimensions of the generated textures.


