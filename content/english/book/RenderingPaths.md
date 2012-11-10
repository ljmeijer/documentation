Rendering Paths
===============


Unity supports different <span class=keyword>Rendering Paths</span>. You should choose which one you use depending on your game content and target platform / hardware. Different rendering paths have different features and performance characteristics that mostly affect Lights and Shadows.

The rendering Path used by your project is chosen in [Player Settings](class-PlayerSettings.md). Additionally, you can override it for each [Camera](class-Camera.md).

If the graphics card can't handle a selected rendering path, Unity will automatically use a lower fidelity one. So on a GPU that can't handle Deferred Lighting, Forward Rendering will be used. If Forward Rendering is not supported, Vertex Lit will be used.


<a id="deferredlighting"></a>
Deferred Lighting
-----------------


<span class=keyword>Deferred Lighting</span> is the rendering path with the most lighting and shadow fidelity. It is best used if you have many realtime lights. It requires a certain level of hardware support, is for __Unity Pro__ only and is not supported on <span class=keyword>Mobile Devices</span>.

For more details see the __[Deferred Lighting page](RenderTech-DeferredLighting.md)__.


<a id="forward"></a>
Forward Rendering
-----------------


<span class=keyword>Forward</span> is a shader-based rendering path. It supports per-pixel lighting (including normal maps & light Cookies) and realtime shadows from one directional light. In the default settings, a small number of the brightest lights are rendered in per-pixel lighting mode. The rest of the lights are calculated at object vertices.

For more details see the __[Forward Rendering page](RenderTech-ForwardRendering.md)__.


<a id="vertexlit"></a>
Vertex Lit
----------


<span class=keyword>Vertex Lit</span> is the rendering path with the lowest lighting fidelity and no support for realtime shadows. It is best used on old machines or limited mobile platforms.

For more details see the __[Vertex Lit page](RenderTech-VertexLit.md)__.


Rendering Paths Comparison
--------------------------



|    |    |    |    |
|:---|:---|:---|:---|
|                                                 | Deferred Lighting | Forward Rendering   | Vertex Lit |
|_%gray%__Features___ | | | |
|Per-pixel lighting (normal maps, light cookies)  | Yes               | Yes                 | -          |
|Realtime shadows                                 | Yes               | 1 Directional Light | -          |
|Dual Lightmaps                                   | Yes               | -                   | -          |
|Depth&Normals Buffers                            | Yes               | Additional render passes | -     |
|Soft Particles                                   | Yes               | -                   | -          |
|Semitransparent objects                          | -                 | Yes                 | Yes        |
|Anti-Aliasing                                    | -                 | Yes                 | Yes        |
|Light Culling Masks                              | Limited           | Yes                 | Yes        |
|Lighting Fidelity                                | All per-pixel     | Some per-pixel      | All per-vertex |
|_%gray%__Performance___ | | | |
|Cost of a per-pixel Light                        | Number of pixels it illuminates | Number of pixels * Number of objects it illuminates | - |
|_%gray%__Platform Support___ | | | |
|PC (Windows/Mac)                                 | Shader Model 3.0+ | Shader Model 2.0+   | Anything            |
|Mobile (iOS/Android)                             | -                 | OpenGL ES 2.0       | OpenGL ES 2.0 & 1.1 |
|Consoles                                         | 360, PS3          | 360, PS3            | -                   |

