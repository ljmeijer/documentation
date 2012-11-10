Performance of Unity shaders
============================


There are a number of factors that can affect the overall performance of your game.  This page will talk specifically about the performance considerations for [Built-in Shaders](Built-inShaderGuide.md). Performance of a shader mostly depends on two things: shader itself and which [Rendering Path](RenderingPaths.md) is used by the project or specific camera. For performance tips when writing your own shaders, see [ShaderLab Shader Performance](SL-ShaderPerformance.md) page.

Rendering Paths and shader performance
--------------------------------------


From the rendering paths Unity supports, [Deferred Lighting](RenderTech-DeferredLighting.md) and [Vertex Lit](RenderTech-VertexLit.md) paths have the most predictable performance. In Deferred lighting, each object is generally drawn twice, no matter what lights are affecting it. Similarly, in Vertex Lit each object is generally drawn once. So then, the performance differences in shaders mostly depend on how many textures they use and what calculations they do.


###Shader Performance in Forward rendering path

In [Forward](RenderTech-ForwardRendering.md) rendering path, performance of a shader depends on __both__ the shader itself and the lights in the scene. The following section explains the details. There are two basic categories of shaders from a performance perspective, <span class=keyword>Vertex-Lit</span>, and <span class=keyword>Pixel-Lit</span>.

<span class=keyword>Vertex-Lit</span> shaders in Forward rendering path are always cheaper than Pixel-Lit shaders. These shaders work by calculating lighting based on the mesh vertices, using all lights at once.  Because of this, no matter how many lights are shining on the object, it will only have to be drawn once.

<span class=keyword>Pixel-Lit</span> shaders calculate final lighting at each pixel that is drawn.  Because of this, the object has to be drawn once to get the ambient & main directional light, and once for each additional light that is shining on it.  Thus the formula is N rendering passes, where N is the final number of pixel lights shining on the object.  This increases the load on the CPU to process and send off commands to the graphics card, and on the graphics card to process the vertices and draw the pixels.  The size of the Pixel-lit object on the screen will also affect the speed at which it is drawn.  The larger the object, the slower it will be drawn.

So pixel lit shaders come at performance cost, but that cost allows for some spectacular effects: shadows, normal-mapping, good looking specular highlights and light cookies, just to name a few.

Remember that lights can be forced into a pixel ("important") or vertex/SH ("not important") mode.  Any vertex lights shining on a Pixel-Lit shader will be calculated based on the object's vertices or whole object, and will not add to the rendering cost or visual effects that are associated with pixel lights.


General shader performance
--------------------------


Out of [Built-in Shaders](Built-inShaderGuide.md), they come roughly in this order of increasing complexity:
* <span class=keyword>Unlit</span>. This is just a texture, not affected by any lighting.
* <span class=keyword>VertexLit</span>.
* <span class=keyword>Diffuse</span>.
* <span class=keyword>Normal mapped</span>. This is a bit more expensive than Diffuse: it adds one more texture (normal map), and a couple of shader instructions.
* <span class=keyword>Specular</span>. This adds specular highlight calculation.
* <span class=keyword>Normal Mapped Specular</span>. Again, this is a bit more expensive than Specular.
* <span class=keyword>Parallax Normal mapped</span>. This adds parallax normal-mapping calculation.
* <span class=keyword>Parallax Normal Mapped Specular</span>. This adds both parallax normal-mapping and specular highlight calculation.

Additionally, Unity has several simplified shaders targeted at mobile platforms, under "Mobile" category. These shaders work on other platforms as well, so if you can live with their simplifications (e.g. approximate specular, no per-material color support etc.), try using them!


