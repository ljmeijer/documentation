Rendering Statistics Window
===========================


The <span class=menu>Game View</span> has a <span class=menu>Stats</span> button in the top right corner. When the button is pressed, an overlay window is displayed which shows realtime rendering statistics, which are useful for optimizing performance. The exact statistics displayed vary according to the build target.


![](http://docwiki.hq.unity3d.com/uploads/Main/GameViewStats.png)  
_Rendering Statistics Window._

The Statistics window contains the following information:-

|    |    |
|:---|:---|
|<span class=component>Time per frame and FPS</span> |The amount of time taken to process and render one game frame (and its reciprocal, frames per second). Note that this number only includes the time taken to do the frame update and render the game view; it does not include the time taken in the editor to draw the scene view, inspector and other editor-only processing. |
|<span class=component>Draw Calls</span> |The total number of meshes drawn after batching was applied. Note that where objects are rendered multiple times (for example, objects illuminated by pixel lights), each rendering results in a separate draw call.|
|<span class=component>Batched (Draw Calls)</span> |The number of initially separate draw calls that were added to batches. "Batching" is where the engine attempts to combine the rendering of multiple objects into one draw call in order to reduce CPU overhead. To ensure good batching, you should share materials between different objects as often as possible. |
|<span class=component>Tris</span> and <span class=component>Verts</span> |The number of triangles and vertices drawn. This is mostly important when [optimizing for low-end hardware](OptimizeForIntegratedCards.md) |
|<span class=component>Used Textures</span> |The number of textures used to draw this frame and their memory usage. |
|<span class=component>Render Textures</span> |The number of [Render Textures](class-RenderTexture.md) and their memory usage. The number of times the active Render Texture was switched each frame is also displayed. |
|<span class=component>Screen</span> |The size of the screen, along with its anti-aliasing level and memory usage. |
|<span class=component>VRAM usage</span> |Approximate bounds of current video memory (VRAM) usage. This also shows how much video memory your graphics card has. |
|<span class=component>VBO total</span> |The number of unique meshes (Vertex Buffers Objects or VBOs) that are uploaded to the graphics card. Each different model will cause a new VBO to be created. In some cases scaled objects will cause additional VBOs to be created. In the case of a static batching, several different objects can potentially share the same VBO. |
|<span class=component>Visible Skinned Meshes</span> |The number of skinned meshes rendered. |
|<span class=component>Animations</span> |The number of animations playing. |

