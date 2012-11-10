How do I use Water?
===================


__Note:__ The content on this page applies to the desktop editor mode only.

Unity includes several water prefabs (including needed shaders, scripts and art assets) within the [Standard Assets and Pro Standard Assets packages](HOWTO-InstallStandardAssets.md). Unity includes a basic water, while Unity Pro includes water with real-time reflections and refractions, and in both cases those are provided as separate daylight and nighttime water prefabs.


![](http://docwiki.hq.unity3d.com/uploads/Main/Water_Reflective.png)  
_Reflective daylight water (Unity Pro)_


![](http://docwiki.hq.unity3d.com/uploads/Main/Water_ReflectiveRefractive.png)  
_Reflective/Refractive daylight water (Unity Pro)_

Water setup
-----------


In most cases you just need to place one of the existing Prefabs into your scene (make sure to have the [Standard Assets installed](HOWTO-InstallStandardAssets.md)):
* Unity has <span class=keyword>Daylight Simple Water</span> and <span class=keyword>Nighttime Simple Water</span> in <span class=menu>Standard Assets->Water</span>.
* Unity Pro has <span class=keyword>Daylight Water</span> and <span class=keyword>Nighttime Water</span> in <span class=menu>Pro Standard Assets->Water</span> (but it needs some assets from <span class=menu>Standard Assets->Water</span> as well). Water mode (Simple, Reflective, Refractive) can be set in the Inspector.

The prefab uses an oval-shaped mesh for the water. If you need to use a different [Mesh](class-Mesh.md) the easiest way is to simply change it in the <span class=component>Mesh Filter</span> of the water object:


![](http://docwiki.hq.unity3d.com/uploads/Main/Water_ChangeMesh.png)  


Creating water from scratch (Advanced)
--------------------------------------


The simple water in Unity requires attaching a script to a plane-like mesh and using the water shader:
1. Have mesh for the water. This should be a flat mesh, oriented horizontally. UV coordinates are not required. The water GameObject should use the Water <span class=component>layer</span>, which you can set in the <span class=keyword>Inspector</span>.
1. Attach <span class=component>WaterSimple</span> script (from <span class=menu>Standard Assets/Water/Sources</span>) to the object.
1. Use <span class=menu>FX/Water (simple)</span> shader in the material, or tweak one of provided water materials (<span class=menu>Daylight Simple Water</span> or <span class=menu>Nighttime Simple Water</span>).

The reflective/refractive water in Unity Pro requires similar steps to set up from scratch:
1. Have mesh for the water. This should be a flat mesh, oriented horizontally. UV coordinates are not required. The water GameObject should use the Water <span class=component>layer</span>, which you can set in the <span class=keyword>Inspector</span>.
1. Attach <span class=component>Water</span> script (from <span class=menu>Pro Standard Assets/Water/Sources</span>) to the object.
    * Water rendering mode can be set in the Inspector: Simple, Reflective or Refractive.
1. Use <span class=menu>FX/Water</span> shader in the material, or tweak one of provided water materials (<span class=menu>Daylight Water</span> or <span class=menu>Nighttime Water</span>).


Properties in water materials
-----------------------------

These properties are used in Reflective & Refractive water shader. Most of them are used in simple water shader as well.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Wave scale</span> |Scaling of waves normal map. The smaller the value, the larger water waves. |
|<span class=component>Reflection/refraction distort</span> |How much reflection/refraction is distorted by the waves normal map. |
|<span class=component>Refraction color</span> |Additional tint for refraction. |
|<span class=component>Environment reflection/refraction</span> |Render textures for real-time reflection and refraction. |
|<span class=component>Normalmap</span> |Defines the shape of the waves. The final waves are produced by combining two these normal maps, each scrolling at different direction, scale and speed. The second normal map is half as large as the first one. |
|<span class=component>Wave speed</span> |Scrolling speed for first normal map (1st and 2nd numbers) and the second normal map (3rd and 4th numbers). |
|<span class=component>Fresnel</span> |A texture with alpha channel controlling the Fresnel efffect - how much reflection vs. refraction is visible, based on viewing angle. |

The rest of properties are not used by Reflective & Refractive shader by itself, but need to be set up in case user's video card does not suppor it and must fallback to the simpler shader:


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Reflective color/cube and fresnel</span> |A texture that defines water color (RGB) and Fresnel effect (A) based on viewing angle. |
|<span class=component>Horizon color</span> |The color of the water at horizon. (Used only in the simple water shader) |
|<span class=component>Fallback texture</span> |Texture used to represent the water on really old video cards, if none of better looking shaders can't run on it. |


Hardware support
----------------


* Reflective + Refractive water works on graphics cards with pixel shader 2.0 support (GeForce FX and up, Radeon 9500 and up, Intel 9xx). On older cards, Reflective water is used.
* Reflective water works on graphics cards with pixel shader 1.4 support (GeForce FX and up, Radeon 8500 and up, Intel 9xx). On older cards, Simple water is used.
* Simple water works about everywhere, with various levels of detail depending on hardware capabilities.

