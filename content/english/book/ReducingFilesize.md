Reducing File Size
==================



Unity post-processes all imported assets
----------------------------------------


Unity always post-processes imported files, thus storing a file as a multi-layered psd file instead of a jpg will make absolutely zero difference in the size of the player you will deploy. Save your files in the format you are working with (eg. .mb files, .psd files, .tiff files) to make your life easier.


Unity strips out unused assets
------------------------------


The amount of assets in your project folder does __not__ influence the size of your built player. Unity is very smart about detecting which assets are used in your game and which are not. Unity follows all references to assets before building a game and generates a list of assets that need to be included in the game. Thus you can safely keep unused assets in your project folder.


Unity prints an overview of the used file size
----------------------------------------------


After Unity has completed building a player, it prints an overview of what type of asset took up the most file size, and it prints which assets were included in the build. To see it just open the editor console log: <span class=menu>Open Editor Log</span> button in the Console window (<span class=menu>Window -> Console</span>).


![](http://docwiki.hq.unity3d.com/uploads/Main/FileSizeOptimization.png)  
_An overview of what took up space_


Optimizing texture size
-----------------------


Often textures take up most space in the build. The first to do is to use compressed texture formats (DXT(<span class=keyword>Desktop platforms</span>) or PVRTC) where you can.

If that doesn't get the size down, try to reduce the size of the textures. The trick here is that you don't need to modfiy the actual source content. Simply select the texture in the Project view and set <span class=component>Max Texture Size</span> in Import Settings. It is a good idea to zoom in on an object that uses the texture, then adjust the <span class=component>Max Texture Size</span> until it starts looking worse in the <span class=keyword>Scene View</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/FileSizeOptimizationTexture.png)  
_Changing the Maximum Texture Size will not affect your texture asset, just its resolution in the game_


###How much memory does my texture take up?


####desktop Details

|    |    |
|:---|:---|
|__Compression__      |__Memory consumption__ |
|<span class=component>RGB Compressed DXT1</span>  |0.5 bpp (bytes/pixel)  |
|<span class=component>RGBA Compressed DXT5</span> |1 bpp |
|<span class=component>RGB 16bit</span>            |2 bpp |
|<span class=component>RGB 24bit</span>            |3 bpp |
|<span class=component>Alpha 8bit</span>           |1 bpp |
|<span class=component>RGBA 16bit</span>           |2 bpp |
|<span class=component>RGBA 32bit</span>           |4 bpp |

####ios Details
|__Compression__      |__Memory consumption__ |
|<span class=component>RGB Compressed PVRTC 2 bits</span> |0.25 bpp (bytes/pixel) |
|<span class=component>RGBA Compressed PVRTC 2 bits</span> |0.25 bpp |
|<span class=component>RGB Compressed PVRTC 4 bits</span> |0.5 bpp |
|<span class=component>RGBA Compressed PVRTC 4 bits</span> |0.5 bpp |
|<span class=component>RGB 16bit</span>            |2 bpp |
|<span class=component>RGB 24bit</span>            |3 bpp |
|<span class=component>Alpha 8bit</span>           |1 bpp |
|<span class=component>RGBA 16bit</span>           |2 bpp |
|<span class=component>RGBA 32bit</span>           |4 bpp |

####android Details
|__Compression__      |__Memory consumption__ |
|<span class=component>RGB Compressed DXT1</span>  |0.5 bpp (bytes/pixel)  |
|<span class=component>RGBA Compressed DXT5</span> |1 bpp |
|<span class=component>RGB Compressed ETC1</span> |0.5 bpp |
|<span class=component>RGB Compressed PVRTC 2 bits</span> |0.25 bpp (bytes/pixel) |
|<span class=component>RGBA Compressed PVRTC 2 bits</span> |0.25 bpp |
|<span class=component>RGB Compressed PVRTC 4 bits</span> |0.5 bpp |
|<span class=component>RGBA Compressed PVRTC 4 bits</span> |0.5 bpp |
|<span class=component>RGB 16bit</span>            |2 bpp |
|<span class=component>RGB 24bit</span>            |3 bpp |
|<span class=component>Alpha 8bit</span>           |1 bpp |
|<span class=component>RGBA 16bit</span>           |2 bpp |
|<span class=component>RGBA 32bit</span>           |4 bpp |
To figure out total texture size: width * height * bpp.
Add 33% if you have Mipmaps.

By default Unity compresses all textures when importing. This can be turned off in the <span class=menu>Preferences</span> for faster workflow. But when building a game, all not-yet-compressed textures will be compressed.



Optimizing mesh and animation size
----------------------------------


[Meshes](class-Mesh.md) and imported Animation Clips can be compressed so they take up less space in your game file. Compression can be turned on in Mesh Import Settings.

Mesh and Animation compression uses quantization, which means it takes less space but the compression can introduce some inaccuracies. Experiment with what level of compression is still acceptable for your models.

Note that mesh compression only produces smaller data files, and does not use less memory at run time. Animation <span class=component>Keyframe reduction</span> produces smaller data files _and_ uses less memory at run time, and generally you should always use keyframe reduction.

Additionally, you can choose not to store normals and/or tangents in your Meshes, to save space both in the game builds and memory at run time. This can be set in <span class=component>Tangent Space Generation</span> drop down in Mesh Import Settings. Rules of thumb:
* Tangents are used for normal-mapping. If you don't use normal-mapping, you probably don't need to store tangents in those meshes.
* Normals are used for lighting. If you don't use realtime lighting on some of your meshes, you probably don't need to store normals in them.


Reducing included dlls in the Players
-------------------------------------


When building a player (Desktop, Android or iOS) it is important to not depend on <span class=keyword>System.dll</span> or <span class=keyword>System.Xml.dll</span>.  Unity does not include <span class=keyword>System.dll</span> or <span class=keyword>System.Xml.dll</span> in the players installation.  That means, if you want to use Xml or some Generic containers which live in <span class=keyword>System.dll</span> then the required dlls will be included in the players.  This usually adds 1mb to the download size, obviously this is not very good for the distribution of your players and you should really avoid it.  If you need to parse some Xml files, you can use a smaller xml library like this one [Mono.Xml.zip](Attach:Mono.Xml.zip.md).  While most Generic containers are contained in mscorlib, Stack<> and few others are in <span class=keyword>System.dll</span>. So you really want to avoid those.


![](http://docwiki.hq.unity3d.com/uploads/Main/FileSizeMonoDependency.png)  
_As you can see, Unity is including System.Xml.dll and System.dll, when building a player_

Unity includes the following DLLs with the players distribution <span class=keyword>mscorlib.dll</span>, <span class=keyword>Boo.Lang.dll</span>, <span class=keyword>UnityScript.Lang.dll</span> and <span class=keyword>UnityEngine.dll</span>.

