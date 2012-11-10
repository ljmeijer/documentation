Using Depth Textures
====================


It is possible to create [Render Textures](class-RenderTexture.md) where each pixel contains a high precision "depth" value (see [RenderTextureFormat.Depth](ScriptRef:RenderTextureFormat.Depth.html)). This is mostly used when some effects need scene's depth to be available (for example, soft particles, screen space ambient occlusion, translucency would all need scene's depth).

Pixel values in the depth texture range from 0 to 1 with a nonlinear distribution. Precision is usually 24 or 16 bits, depending on depth buffer used. When reading from depth texture, a high precision value in 0..1 range is returned. If you need to get distance from the camera, or otherwise linear value, you should compute that manually.

Depth textures in Unity are implemented differently on different platforms.
* On Direct3D 9 (Windows), depth texture is either a native depth buffer, or a single channel 32 bit floating point texture ("R32F" Direct3D format).
    * Graphics card must support either native depth buffer (INTZ format) or floating point render textures in order for them to work.
    * When rendering into the depth texture, [fragment program](SL-ShaderPrograms.md) must output the value needed.
    * When reading from depth texture, red component of the color contains the high precision value.
* On OpenGL (Mac OS X), depth texture is the native OpenGL depth buffer (see [ARB_depth_texture](http://www.opengl.org/registry/specs/ARB/depth_texture.txt.md)).
    * Graphics card must support OpenGL 1.4 or [ARB_depth_texture](http://www.opengl.org/registry/specs/ARB/depth_texture.txt.md) extension.
    * Depth texture corresponds to Z buffer contents that are rendered, it __does not__ use the result from the fragment program.
* OpenGL ES 2.0 (iOS/Android) is very much like OpenGL above.
    * GPU must support [GL_OES_depth_texture](http://www.khronos.org/registry/gles/extensions/OES/OES_depth_texture.txt.md) extension.
* Direct3D 11 (Windows) has native depth texture capability just like OpenGL.
* Flash (Stage3D) uses a color-encoded depth texture to emulate the high precision required for it.

Using depth texture helper macros
---------------------------------


Most of the time depth textures are used to render depth from the camera. [SL-BuiltinIncludes | `UnityCG.cginc` include file](SL-BuiltinIncludes|`UnityCG.cginc`includefile.md) contains some macros to deal with the above complexity in this case:
* <span class=component>UNITY_TRANSFER_DEPTH(o)</span>: computes eye space depth of the vertex and outputs it in <span class=component>o</span> (which must be a float2). Use it in a vertex program when rendering into a depth texture. On platforms with native depth textures this macro does nothing at all, because Z buffer value is rendered implicitly.
* <span class=component>UNITY_OUTPUT_DEPTH(i)</span>: returns eye space depth from <span class=component>i</span> (which must be a float2). Use it in a fragment program when rendering into a depth texture. On platforms with native depth textures this macro always returns zero, because Z buffer value is rendered implicitly.
* <span class=component>COMPUTE_EYEDEPTH(i)</span>: computes eye space depth of the vertex and outputs it in <span class=component>o</span>. Use it in a vertex program when __not__ rendering into a depth texture.
* <span class=component>DECODE_EYEDEPTH(i)</span>: given high precision value from depth texture <span class=component>i</span>, returns corresponding eye space depth. This macro just returns <span class=component>i*FarPlane</span> on Direct3D. On platforms with native depth textures it linearizes and expands the value to match camera's range.

For example, this shader would render depth of its objects:
````

Shader "Render Depth" {
SubShader {
    Tags { "RenderType"="Opaque" }
    Pass {
        Fog { Mode Off }
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

struct v2f {
    float4 pos : SV_POSITION;
    float2 depth : TEXCOORD0;
};

v2f vert (appdata_base v) {
    v2f o;
    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
    UNITY_TRANSFER_DEPTH(o.depth);
    return o;
}

half4 frag(v2f i) : COLOR {
    UNITY_OUTPUT_DEPTH(i.depth);
}
ENDCG
    }
}
}
````
