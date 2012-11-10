Built-in Shader Guide
=====================


If you're looking for the best information for using Unity's built-in shaders, you've come to the right place.  Unity includes more than 40 built-in shaders, and of course you can write many more on your own!  This guide will explain each family of the built-in shaders, and go into detail for each specific shader.  With this guide, you'll be able to make the most out of Unity's shaders, to achieve the effect you're aiming for.

Using Shaders
-------------


Shaders in Unity are used through <span class=keyword>Materials</span>, which essentially combine shader code with parameters like textures.  An in-depth explanation of the Shader/Material relationship can be read [here](Materials.md).

Material properties will appear in the <span class=keyword>Inspector</span> when either the Material itself or a <span class=keyword>GameObject</span> that uses the Material is selected.  The Material Inspector looks like this:


![](http://docwiki.hq.unity3d.com/uploads/Main/MatInspector.png)  

Each Material will look a little different in the Inspector, depending on the specific shader it is using.  The shader iself determines what kind of properties will be available to adjust in the Inspector. Material inspector is described in detail in [Material reference page](class-Material.md). Remember that a shader is implemented through a Material.  So while the shader defines the properties that will be shown in the Inspector, each Material actually contains the adjusted data from sliders, colors, and textures.  The most important thing to remember about this is that a single shader can be used in multiple Materials, but a single Material cannot use multiple shaders.


Built-in Unity Shaders
----------------------


(:tocportion:)
