Lightmapping Quickstart
=======================


This an introductory description of lightmapping in Unity. For more advanced topics see [in-depth description of lightmapping in Unity](Main.LightmappingInDepth.md)

Unity has a built-in lightmapper: it's __[Beast](http://www.illuminatelabs.com/products/beast.md)__ by Illuminate Labs. Lightmapping is fully integrated in Unity. This means that Beast will bake lightmaps for your scene based on how your scene is set up within Unity, taking into account meshes, materials, textures and lights. It also means that lightmapping is now an integral part of the rendering engine - once your lightmaps are created you don't need to do anything else, they will be automatically picked up by the objects.


![](http://docwiki.hq.unity3d.com/uploads/Main/LightmapEditor-ApartmentScene.png)  

Preparing the scene and baking the lightmaps
--------------------------------------------


Selecting __<span class=menu>Window</span> &ndash; <span class=menu>Lightmapping</span>__ from the menu will open the Lightmapping window:

1. Make sure any mesh you want to be lightmapped has proper UVs for lightmapping. The easiest way is to choose the __<span class=menu>Generate Lightmap UVs</span>__ option in [mesh import settings](Main.class-Mesh.md).
1. In the __<span class=menu>Object</span>__ pane mark any Mesh Renderer, Skinned Mesh Renderer or Terrain as __<span class=menu>static</span>__ &ndash; this will tell Unity, that those objects won't move nor change and they can be lightmapped.

![](http://docwiki.hq.unity3d.com/uploads/Main/LightmapperObject40.png)  
1. To control the resolution of the lightmaps, go to the __<span class=menu>Bake</span>__ pane and adjust the __<span class=menu>Resolution</span>__ value. (To have a better understanding on how you spend your lightmap texels, look at the small __<span class=menu>Lightmap Display</span>__ window within the <span class=menu>Scene View</span> and select __<span class=menu>Show Resolution</span>__).

![](http://docwiki.hq.unity3d.com/uploads/Main/LightmapperBakeAndShowResolution40.png)  
1. Press __<span class=menu>Bake</span>__
1. A progress bar appears in Unity Editor's status bar, in the bottom right corner.
1. When baking is done, you can see all the baked lightmaps at the bottom of the Lightmap Editor window.

Scene and game views will update - your scene is now lightmapped!

Tweaking Bake Settings
----------------------


Final look of your scene depends a lot on your lighting setup and bake settings. Let's take a look at an example of some basic settings that can improve lighting quality.

This is a basic scene with a couple of cubes and one point light in the centre. The light is casting hard shadows and the effect is quite dull and artificial.  

![](http://docwiki.hq.unity3d.com/uploads/Main/LightmappedCubesTut1.png)  

Selecting the light and opening the <span class=menu>Object</span> pane of the <span class=menu>Lightmapping</span> window exposes <span class=component>Shadow Radius</span> and <span class=component>Shadow Samples</span> properties. Setting Shadow Radius to 1.2, Shadow Samples to 100 and re-baking produces soft shadows with wide penumbra - our image already looks much better.  

![](http://docwiki.hq.unity3d.com/uploads/Main/LightmappedCubesTut2.png)  


With Unity Pro we can take the scene one step further by enabling Global Illumination and adding a Sky Light. In the <span class=menu>Bake</span> pane we set the number of <span class=component>Bounces</span> to 1 and the <span class=component>Sky Light Intensity</span> to 0.5. The result is much softer lighting with subtle diffuse interreflection effects (color bleeding from the green and blue cubes) - much nicer and it's still only 3 cubes and a light!

![](http://docwiki.hq.unity3d.com/uploads/Main/LightmappedCubesTut3.png)  


Lightmapping In-Depth
---------------------


For more information about the various lightmapping-related settings, please refer to the [in-depth description of lightmapping in Unity](Main.LightmappingInDepth.md).

