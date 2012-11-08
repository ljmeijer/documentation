Procedural Materials
====================


Unity incorporates a new asset type known as <span class=keyword>Procedural Materials</span>. These are essentially the same as standard Materials except that the textures they use can be generated at runtime rather than being predefined and stored.

The script code that generates a texture procedurally will typically take up much less space in storage and transmission than a bitmap image and so Procedural Materials can help reduce download times. Additionally, the generation script can be equipped with parameters that can be changed in order to vary the visual properties of the material at runtime. These properties can be anything from color variations to the size of bricks in a wall. Not only does this mean that many variations can be generated from a single Procedural Material but also that the material can be animated on a frame-by-frame basis. Many interesting visual effects are possible - imagine a character gradually turning to stone or acid damaging a surface as it touches.

Unity's Procedural Material system is based around an industry standard product called Substance, developed by [Allegorithmic](http://www.allegorithmic.com/.md)


Supported Platforms
-------------------


In Unity, Procedural Materials are fully supported for standalone and webplayer build targets only (Windows and Mac OS X). For all other platforms, Unity will pre-render or _bake_ them into ordinary Materials during the build. Although this clearly negates the runtime benefits of procedural generation, it is still useful to be able to create variations on a basic material in the editor.


Adding Procedural Materials to a Project
----------------------------------------


A Procedural Material is supplied as a Substance Archive file (SBSAR) which you can import like any other asset (drag and drop directly onto the Assets folder or use <span class=menu>Assets->Import New Asset...</span>). A Substance Archive asset contains one or more Procedural Materials and contains all the scripts and images required by these. Uncompiled SBS files are not supported.

Although they are implemented differently, Unity handles a Procedural Material just like any other Material. To assign a Procedural Material to a mesh, for example, you just drag and drop it onto the mesh exactly as you would with any other Material.


Procedural Properties
---------------------


Each Procedural Material is a custom script which generates a particular type of material. These scripts are similar to Unity scripts in that they can have variables exposed for assignment in the inspector. For example, a "Brick Wall" Procedural Material could expose properties that let you set the number of courses of bricks, the colors of the bricks and the color of the mortar. This potentially offers infinite material variations from a single asset. These properties can also be set from a script at runtime in much the same way as the public variables of a MonoBehaviour script.

Procedural Materials can also incorporate complex texture animation. For example, you could animate the hands of the clock or cockroaches running across a floor.


![](http://docwiki.hq.unity3d.com/uploads/Main/SubstanceCockroach.png)  


Creating Procedural Materials From Scratch
------------------------------------------


Procedural Materials can work with any combination of procedurally generated textures and stored bitmaps. Additionally, included bitmap images can be filtered and modified before use. Unlike a standard Material, a Procedural Material can use vector images in the form of SVG files which allows for resolution-independent textures.

The design tools available for creating Procedural Materials from scratch use visual, node-based editing similar to the kind found in artistic tools. This makes creation accessible to artists who may have little or no coding experience. As an example, here is a screenshot from Allegorithmic's Substance Designer which shows a "brick wall" Procedural Material under construction: 


![](http://docwiki.hq.unity3d.com/uploads/Main/SubstanceDesigner.png)  


Obtaining Procedural Materials
------------------------------


Since Unity's Procedural Materials are based on the industry standard Substance  product, Procedural Material assets are readily available from internet sources, including Unity's own Asset Store. Allegorithmic's Substance Designer can be used to create Procedural Materials, but there are other applications (3D modelling apps, for example) that incorporate the Substance technology and work just as well with Unity.


Performance and Optimization
----------------------------


Procedural Materials inherently tend to use less storage than bitmap images. However, the trade-off is that they are based around scripts and running those scripts to generate materials requires some CPU and GPU resources. The more complex your Procedural Materials are, the greater their runtime overhead.

Procedural Materials support a form of caching whereby the material is only updated if its parameters have changed since it was last generated. Further to this, some materials may have many properties that could theoretically be changed and yet only a few will ever need to change at runtime. In such cases, you can inform Unity about the variables that will not change to help it cache as much data as possible from the previous generation of the material. This will often improve performance significantly.

>Procedural Materials can refer to hidden, system-wide, variables, such as elapsed time or number of Procedural Material instances (this data can be useful for animations). Changes in the values of these variables can still force a Procedural Material to update even if none of the explicitly defined parameters change.

Procedural Materials can also be used purely as a convenience in the editor (ie, you can generate a standard Material by setting the parameters of a Procedural Material and then "baking" it). This will remove the runtime overhead of material generation but naturally, the baked materials can't be changed or animated during gameplay.


Using the Substance Player to Analyze Performance
-------------------------------------------------


Since the complexity of a Procedural Material can affect runtime performance, Allegorithmic incorporates profiling features in its _Substance Player_ tool. This tool is available to download for free from [Allegorithmic's website](http://www.allegorithmic.com/.md).

Substance Player uses the same optimized rendering engine as the one integrated into Unity, so its rendering measurement is more representative of performance in Unity than that of Substance Designer.

