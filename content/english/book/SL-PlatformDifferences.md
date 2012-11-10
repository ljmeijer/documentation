Platform Specific Rendering Differences
=======================================


Unity runs on various platforms, and in some cases there are differences in how things behave. Most of the time Unity hides the differences from you, but sometimes you can still bump into them.


Render Texture Coordinates
--------------------------


Vertical texture coordinate conventions differ between Direct3D, OpenGL and OpenGL ES:
* In Direct3D, the coordinate is zero at the top, and increases downwards.
* In OpenGL and OpenGL ES, the coordiante is zero at the bottom, and increases upwards.

Most of the time this does not really matter, except when rendering into a [Render Texture](class-RenderTexture.md). In that case, Unity internally flips rendering upside down when rendering into a texture on Direct3D, so that the conventions match between the platforms.

One case where this does not happen, is when [Image Effects](comp-ImageEffects.md) and Anti-Aliasing is used. In this case, Unity renders to screen to get anti-aliasing, and then "resolves" rendering into a RenderTexture for further processing with an Image Effect. The resulting source texture for an image effect is _not flipped upside down_ on Direct3D (unlike all other Render Textures).

If your Image Effect is a simple one (processes one texture at a time), this does not really matter, because [Graphics.Blit](ScriptRef:Graphics.Blit.html) takes care of that.

However, __if you're processing more than one RenderTexture together__ in your Image Effect, most likely they will come out at different vertical orientations (only in Direct3D-like platforms, and only when anti-aliasing is used). You need to manually "flip" the screen texture upside down in your vertex shader, like this:
````

// On D3D when AA is used, the main texture & scene depth texture
// will come out in different vertical orientations.
// So flip sampling of the texture when that is the case (main texture
// texel size will have negative Y).
#if UNITY_UV_STARTS_AT_TOP
if (_MainTex_TexelSize.y < 0)
        uv.y = 1-uv.y;
#endif

````

Check out Edge Detection scene in [Shader Replacement sample project](http://unity3d.com/support/resources/example-projects/shader-replacement.md) for an example of this. Edge detection there uses both screen texture and Camera's [Depth+Normals texture](SL-CameraDepthTexture.md).


AlphaTest and programmable shaders
----------------------------------


Some platforms, most notably mobile (OpenGL ES 2.0) and Direct3D 11, do not have fixed function [alpha testing](SL-AlphaTest.md) functionality. When you are using programmable shaders, it's advised to use Cg/HLSL `clip()` function in the pixel shader instead.



###u40 Details
Direct3D 11 shader compiler is more picky about syntax
------------------------------------------------------


Direct3D 9 and OpenGL use NVIDIA's Cg to compile shaders, but Direct3D 11 (and Xbox 360) use Microsoft's HLSL shader compiler. HLSL compiler is more picky about various subtle shader errors. For example, it won't accept function output values that aren't initialized properly.

Most common places where you'd run into this:
* [Surface shader](SL-SurfaceShaders.md) vertex modifier that has an "out" parameter. Make sure to initialize the output like this:
      void vert (inout appdata_full v, out Input o) 
      {
        __UNITY_INITIALIZE_OUTPUT(Input,o);__
        // ...
      }
* Partially initialized values, e.g. a function returning float4, but the code only sets .xyz values of it. Make sure to set all values, or change to float3 if you only need those.



Using OpenGL Shading Language (GLSL) shaders with OpenGL ES 2.0
---------------------------------------------------------------


OpenGL ES 2.0 provides only limited native support for OpenGL Shading Language (GLSL), for instance OpenGL ES 2.0 layer provides no built-in parameters to the shader.

Unity implements built-in parameters for you exactly in the same way as OpenGL does, however following built-in parameters are missing:
* <span class=component>gl_ClipVertex</span>
* <span class=component>gl_SecondaryColor</span>
* <span class=component>gl_DepthRange</span>
* <span class=component>halfVector</span> property of the <span class=component>gl_LightSourceParameters</span> structure
* <span class=component>gl_FrontFacing</span>
* <span class=component>gl_FrontLightModelProduct</span>
* <span class=component>gl_BackLightModelProduct</span>
* <span class=component>gl_BackMaterial</span>
* <span class=component>gl_Point</span>
* <span class=component>gl_PointSize</span>
* <span class=component>gl_ClipPlane</span>
* <span class=component>gl_EyePlaneR</span>, <span class=component>gl_EyePlaneS</span>, <span class=component>gl_EyePlaneT</span>, <span class=component>gl_EyePlaneQ</span>
* <span class=component>gl_ObjectPlaneR</span>, <span class=component>gl_ObjectPlaneS</span>, <span class=component>gl_ObjectPlaneT</span>, <span class=component>gl_ObjectPlaneQ</span>
* <span class=component>gl_Fog</span>



iPad2 and MSAA and alpha-blended geometry
-----------------------------------------


There is a bug in apple driver resulting in artifacts when MSAA is enabled and alpha-blended geometry is drawn with non RGBA colorMask. To prevent artifacts we force RGBA colorMask when this configuration is encountered, though it will render built-in Glow FX unusable (as it needs DST_ALPHA for intensity value). Also, please update your shaders if you wrote them yourself (see "Render Setup -> ColorMask" in [Pass Docs](ScriptRef:Main.SL-Pass)).
