Shadows in Unity
================



Unity Pro makes it possible to use real-time <span class=keyword>shadows</span> on any light. Objects can cast shadows onto each other and onto parts of themselves ("self shadowing"). All types of [Lights](class-Light.md) - Directional, Spot and Point - support shadows.

Using shadows can be as simple as choosing <span class=menu>Hard Shadows</span> or <span class=menu>Soft Shadows</span> on a [Light](class-Light.md). However, if you want optimal shadow quality and performance, there are some additional things to consider.

The [Shadow Troubleshooting](ShadowTroubleshooting.md) page contains solutions to common shadowing problems.

Curiously enough, the best shadows are non-realtime ones! Whenever your game level geometry and lighting is static, just precompute lightmaps in your 3D application. Computing shadows offline will always result in better quality and performance than displaying them in real time. _Now onto the realtime ones..._


Tweaking shadow quality
-----------------------


Unity uses so called [shadow maps](http://en.wikipedia.org/wiki/Shadow_mapping.md) to display shadows. Shadow mapping is a texture based approach, it's easiest to think of it as "shadow textures" projecting out from lights onto the scene. Thus much like regular texturing, quality of shadow mapping mostly depends on two factors:
* The <span class=keyword>resolution</span> (size) of the shadow maps. The larger the shadow maps, the better the shadow quality.
* The <span class=keyword>filtering</span> of the shadows. <span class=keyword>Hard shadows</span> take the nearest shadow map pixel. <span class=keyword>Soft shadows</span> average several shadow map pixels, resulting in smoother looking shadows (but soft shadows are more expensive to render).

Different <span class=component>Light</span> types use different algorithms to calculate shadows.
* For Directional lights, the crucial settings for shadow quality are <span class=menu>Shadow Distance</span> and <span class=menu>Shadow Cascades</span>, found in [Quality Settings](class-QualitySettings.md). <span class=menu>Shadow Resolution</span> is also taken into account, but the first thing to try to improve directional shadow quality is reducing shadow distance. All the details about directional light shadows can be found here: [Directional Shadow Details](DirectionalShadowDetails.md).
* For Spot and Point lights, <span class=menu>Shadow Resolution</span> determines shadow map size. Additionally, for lights that cover small area on the screen, smaller shadow map resolutions are used.

Details on how shadow map sizes are computed are in [Shadow Size Details](ShadowSizeDetails.md) page.


Shadow performance
------------------


Realtime shadows are quite performance hungry, so use them sparingly. For each light to render its shadows, first any potential shadow casters must be rendered into the shadow map, then all shadow receivers are rendered with the shadow map. This makes shadow casting lights even more expensive than <span class=keyword>Pixel lights</span>, but hey, computers are getting faster as well!

<span class=keyword>Soft shadows</span> are more expensive to render than <span class=keyword>Hard shadows</span>. The cost is entirely on the graphics card though (it's only longer shaders), so Hard vs. Soft shadows don't make any impact on the CPU or memory.

[Quality Settings](class-QualitySettings.md) contains a setting called <span class=menu>Shadow Distance</span> - this is how far from the camera shadows are drawn. Often it makes no sense to calculate and display shadows that are 500 meters away from the camera, so use as low shadow distance as possible for your game. This will help performance (and will improve quality of directional light shadows, see above).

<a id="hardware"></a>
Hardware support for shadows
----------------------------


Built-in shadows require a fragment program (pixel shader 2.0) capable graphics card. This is the list of supported cards:
* On Windows:
    * ATI Radeon 9500 and up, Radeon X series, Radeon HD series.
    * NVIDIA GeForce 6xxx, 7xxx, 8xxx, 9xxx, GeForce GT, GTX series.
    * Intel GMA X3000 (965) and up.
* On Mac OS X:
    * Mac OS X 10.4.11 or later.
    * ATI Radeon 9500 and up, Radeon X, Radeon HD series.
    * NVIDIA GeForce FX, 6xxx, 7xxx, 8xxx, 9xxx, GT, GTX series.
    * Intel GMA 950 and later.
        * Soft shadows are disabled because of driver bugs (hard shadows will be used instead).

###u40 Details
* Mobile (iOS & Android):
    * OpenGL ES 2.0
    * GL_OES_depth_texture support. Most notably, Tegra-based Android devices do not have it, so shadows are not supported there.

###u30 Details
* Mobile (iOS & Android):
    * Shadows are not supported

Notes
-----


* [Forward rendering path](RenderTech-ForwardRendering.md) supports only one directional shadow casting light. [Vertex Lit](RenderTech-VertexLit.md) rendering path does not support realtime shadows.
* Vertex-lit lights don't have shadows.
* Vertex-lit materials won't receive shadows (but do cast shadows).
* Transparent objects don't cast or receive shadows. Transparent Cutout objects do cast and receive shadows.

