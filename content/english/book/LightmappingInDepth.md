Lightmapping In-Depth
=====================


If you are about to lightmap your first scene in Unity, this [Quickstart Guide](Main.Lightmapping.md) might help you out.

Lightmapping is fully integrated in Unity, so that you can build entire levels from within the Editor, lightmap them and have your materials automatically pick up the lightmaps without you having to worry about it. Lightmapping in Unity means that all your lights' properties will be mapped directly to the Beast lightmapper and baked into textures for great performance. Unity Pro extends this functionality by Global Illumination, allowing for baking realistic and beautiful lighting, that would otherwise be impossible in realtime. Additionally Unity Pro brings you sky lights and emissive materials for even more interesting scene lighting.

In this page you will find a more in-depth description of all the attributes that you can find in the Lightmapping window. To open the Lightmapping window select __<span class=menu>Window</span> &ndash; <span class=menu>Lightmapping</span>__.



![](http://docwiki.hq.unity3d.com/uploads/Main/LightmappingMain.png)  

Scene filters
-------------

At the top of the inspector are three _Scene Filter_ buttons that enable you to apply the operation to all objects or to restrict it to lights or renderers.

Object
------

Per-object bake settings for lights, mesh renderers and terrains - depending on the current selection.

__Mesh Renderers and Terrains:__


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Lightmap Static</span>|Mesh Renderers and Terrains have to marked as static to be lightmapped.|
|<span class=component>Scale In Lightmap</span>|(Mesh Renderers only) Bigger value will result in more resolution to be dedicated to the give mesh renderer. The final resolution will be proportional (Scale in lightmap)*(Object's word-space surface area)*(Global bake settings Resolution value). A value of 0 will result in the object not being lightmapped (it will still affect other lightmapped objects). |
|<span class=component>Lightmap Size</span>|(Terrains only) Lightmap size for this terrain instance. Terrains are not atlased as other objects - they get their individual lightmaps instead.|
|<span class=component>Atlas</span>|Atlasing information &ndash; will be updated automatically, if <span class=keyword>Lock Atlas</span> is disabled. If <span class=keyword>Lock Atlas</span> is enabled, those parameters won't be modified automatically and can be edited manually. |
|>>><span class=component>Lightmap Index</span>|An index into the lightmap array.|
|>>><span class=component>Tiling</span>|(Mesh Renderers only) Tiling of object's lightmap UVs.|
|>>><span class=component>Offset</span>|(Mesh Renderers only) Offset of object's lightmap UVs.|

__Lights:__


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Lightmapping</span>|The Lightmapping mode: Realtime Only, Auto or Baked Only. See [Dual Lightmaps](#DualLightmaps) description below.|
|<span class=component>Color</span>|The color of the light. Same property is used for realtime rendering.|
|<span class=component>Intensity</span>|The intensity of the light. Same property is used for realtime rendering.|
|<span class=component>Bounce Intensity</span>|A multiplier to the intensity of indirect light emitted from this particular light source.|
|<span class=component>Baked Shadows</span>|Controls whether shadows are casted from objects lit by this light (controls realtime shadows at the same time in case of Auto lights).|
|>>><span class=component>Shadow Radius</span>|(Point and Spot lights only) Increase this value for soft direct shadows - it increases the size of the light for the shadowing (but not lighting) calculations.|
|>>><span class=component>Shadow Angle</span>|(Directional lights only) Increase this value for soft direct shadows - it increases the angular coverage of the light for the shadowing (but not lighting) calculations.|
|>>><span class=component>Shadow Samples</span>|If you've set Shadow Radius or Angle above zero, increase the number of Shadow Samples as well. Higher sample numbers remove noise from the shadow penumbra, but might increase rendering times.|


Bake
----

Global bake settings.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Mode</span>|Controls both offline lightmap baking and runtime lightmap rendering modes. In Dual Lightmaps mode both near and far lightmaps will be baked; only deferred rendering path supports rendering dual lightmaps. Single Lightmaps mode results in only the far lightmap being baked; can also be used to force single lightmaps mode for the deferred rendering path.|
|<span class=component>Use in forward rendering</span>|(Dual lightmaps only) Enables dual lightmaps in forward rendering. Note that this will require you to create your own shaders for the purpose.|
|<span class=component>Quality</span>|Presets for high (good-looking) and low (but fast) quality bakes. They affect the number of final gather rays, contrast threshold and some other final gather and anti-aliasing settings.|
|<span class=component>Bounces</span>|The number of light bounces in the Global Illumination simulation. At least one bounce is needed to give a soft, realistic indirect lighting. 0 means only direct light will be computed.|
|<span class=component>Sky Light Color</span>|Sky light simulates light emitted from the sky from all the directions - great for outdoor scenes.|
|<span class=component>Sky Light Intensity</span>|The intensity of the sky light - a value of 0 disables the sky light.|
|<span class=component>Bounce Boost</span>|Boosts indirect light, can be used to increase the amount of bounced light within the scene without burning out the render too quickly.|
|<span class=component>Bounce Intensity</span>|A multiplier to the intensity of the indirect light.|
|<span class=component>Final Gather Rays</span>|The number of rays shot from every final gather point - higher values give better quality.|
|<span class=component>Contrast Threshold</span>|Color contrast threshold, above which new final gather points will be created by the adaptive sampling algorithm. Higher values make Beast be more tolerant about illumination changes on the surface, thus producing smoother but less-detailed lightmaps. Lower numbers of final gather rays might need higher contrast threshold values not to force additional final gather points to be created.|
|<span class=component>Interpolation</span>|Controls the way the color from final gather points will be interpolated. 0 for linear interpolation, 1 for advanced, gradient-based interpolation. In some cases the latter might introduce artifacts.|
|<span class=component>Interpolation Points</span>|The number of final gather points to interpolate between. Higher values give more smooth results, but can also smooth out details in the lighting.|
|<span class=component>Ambient Occlusion</span>|The amount of ambient occlusion to be baked into the lightmaps. Ambient occlusion is the visibility function integrated over the local hemisphere of size Max Distance, so doesn't take into account any lighting information.|
|<span class=component>Lock Atlas</span>|When Lock Atlas is enabled, automatic atlasing won't be run and lightmap index, tiling and offset on the objects won't be modified.|
|<span class=component>Resolution</span>|The resolution of the lightmaps in texels per world unit, so a value of 50 and a 10unit by 10unit plane will result in the plane occupying 500x500 pixels in the lightmap.|
|<span class=component>Padding</span> |The blank space left between individual items on the atlas, given in texel units (0..1). |
Maps
----

The editable array of all the lightmaps.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Compressed</span>|Toggles compression on all lightmap assets for this scene.|
|<span class=component>Array Size</span>|Size of the lightmaps array (0 to 254).|
|<span class=component>Lightmaps Array</span>|The editable array of all the lightmaps in the current scene. Unassigned slots are treated as black lightmaps. Indices correspond to the Lightmap Index value on Mesh Renderers and Terrains. Unless Lock Atlas is enabled, this array will get auto-resized and populated whenever you bake lightmaps.|

Lightmap Display
----------------

Utilities for controlling how lightmaps are displayed in the editor. Lightmap Display is a sub window of the Scene View, visible whenever the Lightmapping window is visible.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Use Lightmaps</span>|Whether to use the lightmaps during the rendering or not.|
|<span class=component>Shadow Distance</span>|The distance at which Auto lights and Close By lightmaps fade out to just Far Away lightmaps. This setting overrides but not overwrites the QualitySettings.shadowDistance setting.|
|<span class=component>Show Resolution</span>|Toggles the scene view Lightmap Resolution mode, which allows you to preview how you spend your lightmap texels on objects marked as static.|



Details
-------



<a id="DualLightmaps"></a>

###Dual Lightmaps

Dual lightmaps is Unity's approach to make lightmapping work with __specular__, __normal mapping__ and proper blending of baked and realtime shadows. It's also a way to make your lightmaps look good even if the lightmap resolution is low.

Dual lightmaps by default can only be used in the [Deferred Lighting](Main.RenderingPaths.md) rendering path. In Forward rendering path, it's possible to enable Dual Lightmaps by writing custom shaders (use `[dualforward](SL-SurfaceShaders.md)` surface shader directive).

Dual lightmaps use two sets of lightmaps: 
* __Far__: Contains full illumination
* __Near__: Contains indirect illumination from lights marked as __Auto__, full illumination from lights marked as __Bake Only__, emissive materials and sky lights.

__Realtime Only__ lights are never baked. The __Near__ lightmap set is used within the distance from the camera smaller than the Shadow Distance quality setting.  
Within this distance __Auto__ lights are rendered as realtime lights with specular bump and realtime shadows (this makes their shadows blend correctly with shadows from Realtime Only lights) and their indirect light is taken from the lightmap. Outside Shadow Distance __Auto__ lights no longer render in realtime and full illumination is taken from the __Far__ lightmap (__Realtime Only__ lights are still there, but with disabled shadows).

The scene below contains one directional light with lightmapping mode set to the default Auto, a number of static lightmapped objects (buildings, obstacles, immovable details) and some dynamic moving or movable objects (dummies with guns, barrels). The scene is baked and rendered in dual lightmaps mode: behind the shadow distance buildings are fully lit only by lightmaps, while the two dummies are dynamically lit but don't cast shadows anymore; in front of the shadow distance both the dummy and static lightmapped buildings and ground are lit in realtime and cast realtime shadows, but the soft indirect light comes from the near lightmap.


![](http://docwiki.hq.unity3d.com/uploads/Main/DualLightmapsInAction.png)  


![](http://docwiki.hq.unity3d.com/uploads/Main/DualLightmapsInActionDetail.png)  

###Single Lightmaps

Single Lightmaps is a much simpler technique, but it can be used in any [rendering path](Main.RenderingPaths.md). All static illumination (i.e. from baked only and auto lights, sky lights and emissive materials) gets baked into one set of lightmaps. These lightmaps are used on all lightmapped objects regardless of shadow distance.

To match the strength of dynamic shadows to baked shadows, you need to manually adjust the <span class=component>Shadow Strength</span> property of your light:


![](http://docwiki.hq.unity3d.com/uploads/Main/SingleLightmapsShadow2.png)  
_Adjusting Shadow Strength of a light from the original value of 1.0 to 0.7._

###Lightmapped Materials

Unity doesn't require you to select special materials to use lightmaps. Any shader from the built-in shaders (and any Surface Shader you write, for that matter) already supports lightmaps out of box, without you having to worry about it - it just works.

###Lightmap Resolution

With the _Resolution_ bake setting you control how many texels per unit are needed for your scene to look good. If there's a 1x1 unit plane in your scene and the resolution is set to 10 texels per unit, your plane will take up 10x10 texels in the lightmap. Resolution bake setting is a global setting. If you want to modify it for a special object (make it very small or very big in the lightmap) you can use <span class=component>Scale in Lightmap</span> property of Mesh Renderers. Setting Scale in Lightmap to 0 will result in the object not being lightmapped at all (it will still influence lightmaps on other objects). Use the _Lightmap Resolution_ scene view render mode to preview how you spend your lightmap texels.


![](http://docwiki.hq.unity3d.com/uploads/Main/LightmapResolution40.png)  
_Lightmap Resolution scene view mode visualising how the lightmap texels are spent (each square is one texel)._

###UVs

A mesh that you're about to lightmap needs to have UVs suitable for lightmapping. The easiest way to ensure that is to enable the Generate Lightmap UVs option in Mesh Import Settings for a given mesh.

For more information see the [Lightmap UVs](Main.LightmappingUV.md) page.

###Material Properties

The following material properties are mapped to Beast's internal scene representation:
* Color
* Main Texture
* Specular Color
* Shininess
* Transparency
    * Alpha-based: when using a transparent shader, main texture's alpha channel will control the transparency
    * Color-based: Beast's RGB transparency can be enabled by adding a texture property called <span class=keyword>_TransparencyLM</span> to the shader. Bear in mind that this transparency is defined in the opposite way compared to the alpha-based transparency: here a pixel with value (1, 0, 0) will be fully transparent to red light component and fully opaque to green and blue component, which will result in a red shadow; for the same reason white texture will be fully transparent, while black texture - fully opaque.
* Emission
    * Self Illuminated materials will emit light tinted by the Color and Main Texture and masked by the Illum texture. The intensity of emitted light is proportional to the Emission property (0 disables emission).
    * Generally large and dim light sources can be modeled as objects with emissive materials. For small and intense lights normal light types should be used, since emissive materials might introduce noise in the rendering.

_Note: When mapping materials to Beast, Unity detects the 'kind' of the shader by the shader's properties and path/name keywords such as:  'Specular', 'Transparent', 'Self-Illumin', etc._

###Skinned Mesh Renderers
Having skinned meshes that are static makes your content more flexible, since the shape of those meshes can be changed in Unity after import and can be tweaked per level. Skinned Mesh Renderers can be lightmapped in exactly the same way as Mesh Renderers and are sent to the lightmapper in their current pose.

Lightmapping can also be used if the vertices of a mesh are moved at runtime a bit -- the lighting won't be completely accurate, but in a lot of cases it will match well enough.


Advanced
--------


###Automatic Atlasing

Atlasing (UV-packing) is performed automatically every time you perform a bake and normally you don't have to worry about it - it just works.

Object's world-space surface area is multiplied by the per-object Scale In Lightmap value and by the global Resolution and the result determines the size of the object's UV set (more precisely: the size of the [0,1]x[0,1] UV square) in the lightmap. Next, all objects are packed into as few lightmaps as possible, while making sure each of them occupies the amount of space calculated in the previous step. If a UV set for a given object occupies only part of the [0,1]x[0,1] square, in many cases atlasing will move neighboring UV sets closer, to make use of the empty space.

As a result of atlasing, every object to be lightmapped has it's place in one of the lightmaps and that space doesn't overlap with any other object's space. The atlasing information is stored as three values: Lightmap Index, Tiling (scale) and Offset in Mesh Renderers and as one value: Lightmap Index in Terrains and can be viewed and modified via the Object pane of the lightmapping window.


![](http://docwiki.hq.unity3d.com/uploads/Main/LightmapUsers40.png)  
_Right-clicking a lightmap lets you select all game objects that use the chosen lightmap. Lightmaps of the active object from the current selection are highlighted in yellow._

Atlasing can only modify per-object data which is Lightmap Index, Tiling and Offset and can not modify the UV set of an object, as the UV set is stored as part of the shared mesh. Lightmap UVs for a mesh can only be created at import time using Unity's built-in auto-unwrapper or in an external 3D package before importing to Unity.

###Lock Atlas

When Lock Atlas is enabled, automatic atlasing won't be run and Lightmap Index, Tiling and Offset on the objects won't be modified. Beast will rely on whatever is the current atlasing, so it's the user's responsibility to maintain correct atlasing (e.g. no overlapping objects in the lightmaps, no objects referencing a lightmap slot past the lightmap array end, etc.).

Lock Atlas opens up the possibility for alternative workflows when sending your object's for lightmapping. You can then perform atlasing manually or via scripting to fit you specific needs; you can also lock the automatically generated atlasing if you are happy with the current atlasing, have baked more sets of lightmaps for your scene and want to make sure, that after adding one more object to the scene the atlasing won't change making the scene incompatible with other lightmap sets.

Remember that Lock Atlas locks only atlasing, not the mesh UVs. If you change your source mesh and the mesh importer is set to generate lightmap UVs, the UVs might be generated differently and your current lightmap will look incorrectly on the object - to fix this you will need to re-bake the lightmap.

###Custom Beast bake settings

If you need even more control over the bake process, see the [custom Beast settings](LightmappingCustomSettings.md) page.
