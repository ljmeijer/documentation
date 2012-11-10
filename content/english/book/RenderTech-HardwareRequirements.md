Hardware Requirements for Unity's Graphics Features
===================================================


Summary
-------



|    |    |    |    |    |
|:---|:---|:---|:---|:---|
|                       |PC/Mac             |iOS/Android             |Flash   |360/PS3      |
|Deferred lighting      |SM3.0, GPU support |-                       |-       |Yes          |
|Forward rendering      |SM2.0              |OpenGL ES 2.0           |Yes     |Yes          |
|Vertex Lit rendering   |Yes                |Yes                     |Yes     |-            |
|Realtime Shadows       |SM2.0, GPU support |-                       |Kind-of |Yes          |
|Image Effects          |Most need SM2.0    |Most need OpenGL ES 2.0 |Kind-of |Yes          |
|Vertex Shaders         |SM1.1              |OpenGL ES 2.0           |Yes     |Yes          |
|Pixel Shaders          |SM2.0              |OpenGL ES 2.0           |Yes     |Yes          |
|Fixed Function Shaders |Yes                |Yes                     |Yes     |-            |


Realtime Shadows
----------------


Realtime Shadows currently work on desktop & console platforms. On desktops, they generally need Shader Model 2.0 capable GPU. On Windows (Direct3D), the GPU also needs to support shadow mapping features; most discrete GPUs support that since 2003 and most integrated GPUs support that since 2007. Technically, on Direct3D 9 the GPU has to support [D16/D24X8 or DF16/DF24](http://aras-p.info/texts/D3D9GPUHacks.html.md) texture formats; and on OpenGL it has to support GL_ARB_depth_texture extension.

Flash does support realtime shadows, but due to lack of depth bias and shader limitations, they can have self-shadowing artifacts (increase light's shadow bias) and somewhat more "hard" edges.


###u40 Details
Mobile shadows (iOS/Android) require OpenGL ES 2.0 and GL_OES_depth_texture extension. Most notably, the extension is __not__ present on Tegra-based Android devices, so shadows do not work there.


Image Effects
-------------


[Image Effects](comp-ImageEffects.md) require render-to-texture functionality, which is generally supported on anything made in this millenium. However, all except the simplest effects require quite programmable pixel shaders, so for all practical purposes they require Shader Model 2.0 on desktop (discrete GPUs since 2003; integrated GPUs since 2005) and OpenGL ES 2.0 on mobile platforms.

Some image effects work on Flash, but quite a lot of them do not; either due to no support for non-power-of-two textures, shader limitations or lacking features like depth texture support.


Shaders
-------


In Unity, you can write fixed function or programmable shaders. Fixed function is supported everywhere except consoles (Xbox 360 & Playstation 3). Programmable shaders default to Shader Model 2.0 (desktop) and OpenGL ES 2.0 (mobile). On desktop platforms, it is possible to target Shader Model 1.1 for vertex shaders.
