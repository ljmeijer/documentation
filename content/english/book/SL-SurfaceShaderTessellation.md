Surface Shaders with DX11 Tessellation
======================================


[Surface Shaders](SL-SurfaceShaders.md) have some support for DirectX 11 GPU Tessellation. Idea is:
* Tessellation is indicated by `tessellate:FunctionName` modifier. That function computes triangle edge and inside tessellation factors.
* When tessellation is used, "vertex modifier" (`vertex:FunctionName`) is invoked _after_ tessellation, for each generated vertex in the domain shader. Here you'd typically to displacement mapping.
* Surface shaders can optionally compute [phong tessellation](https://www.google.lt/search?q=phong+tessellation.md) to smooth model surface even without any displacement mapping.


Current limitations of tessellation support:
* Only triangle domain - no quads, no isoline tessellation.
* When tessellation is used, shader is automatically compiled into Shader Model 5.0 target, which means it will only work on DX11.


No GPU tessellation, displacement in the vertex modifier
--------------------------------------------------------


Let's start with a surface shader that does some displacement mapping _without_ using tessellation. It just moves vertices along their normals based on amount coming from a displacement map:

    Shader "Tessellation Sample" {
        Properties {
            _MainTex ("Base (RGB)", 2D) = "white" {}
            _DispTex ("Disp Texture", 2D) = "gray" {}
            _NormalMap ("Normalmap", 2D) = "bump" {}
            _Displacement ("Displacement", Range(0, 1.0)) = 0.3
            _Color ("Color", color) = (1,1,1,0)
            _SpecColor ("Spec color", color) = (0.5,0.5,0.5,0.5)
        }
        SubShader {
            Tags { "RenderType"="Opaque" }
            LOD 300
            
            CGPROGRAM
            #pragma surface surf BlinnPhong addshadow fullforwardshadows vertex:disp nolightmap
            #pragma target 5.0

            struct appdata {
                float4 vertex : POSITION;
                float4 tangent : TANGENT;
                float3 normal : NORMAL;
                float2 texcoord : TEXCOORD0;
            };

            sampler2D _DispTex;
            float _Displacement;

            __void disp (inout appdata v)__
            {
                float d = tex2Dlod(_DispTex, float4(v.texcoord.xy,0,0)).r * _Displacement;
                __v.vertex.xyz += v.normal * d;__
            }

            struct Input {
                float2 uv_MainTex;
            };

            sampler2D _MainTex;
            sampler2D _NormalMap;
            fixed4 _Color;

            void surf (Input IN, inout SurfaceOutput o) {
                half4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
                o.Albedo = c.rgb;
                o.Specular = 0.2;
                o.Gloss = 1.0;
                o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_MainTex));
            }
            ENDCG
        }
        FallBack "Diffuse"
    }

The above shader is fairly standard, points of intetest:
* Vertex modifier `disp` samples the displacement map and moves vertices along their normals.
* It uses custom "vertex data input" structure (`appdata`) instead of default `appdata_full`. This is not needed yet, but it's more efficient for tessellation to use as small structure as possible.
* Since our vertex data does not have 2nd UV coordinate, we add `nolightmap` directive to exclude lightmaps.

Here's how some simple objects would look like with this shader:


![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderTess1-none.png)  


Fixed amount of tessellation
----------------------------


Let's add fixed amount of tessellation, i.e. the same tessellation level for the whole mesh. This approach is suitable if your model's faces are roughly the same size on screen. Some script could then change the tessellation level from code, based on distance to the camera.

    Shader "Tessellation Sample" {
        Properties {
            _'_Tess ("Tessellation", Range(1,32)) = 4_'
            _MainTex ("Base (RGB)", 2D) = "white" {}
            _DispTex ("Disp Texture", 2D) = "gray" {}
            _NormalMap ("Normalmap", 2D) = "bump" {}
            _Displacement ("Displacement", Range(0, 1.0)) = 0.3
            _Color ("Color", color) = (1,1,1,0)
            _SpecColor ("Spec color", color) = (0.5,0.5,0.5,0.5)
        }
        SubShader {
            Tags { "RenderType"="Opaque" }
            LOD 300
            
            CGPROGRAM
            #pragma surface surf BlinnPhong addshadow fullforwardshadows vertex:disp __tessellate:tessFixed__ nolightmap
            #pragma target 5.0

            struct appdata {
                float4 vertex : POSITION;
                float4 tangent : TANGENT;
                float3 normal : NORMAL;
                float2 texcoord : TEXCOORD0;
            };

            __float _Tess;__

            __float4 tessFixed()__
            {
                __return _Tess;__
            }

            sampler2D _DispTex;
            float _Displacement;

            void disp (inout appdata v)
            {
                float d = tex2Dlod(_DispTex, float4(v.texcoord.xy,0,0)).r * _Displacement;
                v.vertex.xyz += v.normal * d;
            }

            struct Input {
                float2 uv_MainTex;
            };

            sampler2D _MainTex;
            sampler2D _NormalMap;
            fixed4 _Color;

            void surf (Input IN, inout SurfaceOutput o) {
                half4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
                o.Albedo = c.rgb;
                o.Specular = 0.2;
                o.Gloss = 1.0;
                o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_MainTex));
            }
            ENDCG
        }
        FallBack "Diffuse"
    }

The tessellation function, `tessFixed` in our shader, returns four tessellation factors as a single float4 value: tree factors for each edge of the triangle, and one factor for the inside of the triangle. Here, we just return a constant value that is set in material properties.


![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderTess2-fixed.png)  



Distance-based tessellation
---------------------------


We can also change tessellation level based on distance from the camera. For example, we could define two distance values; distance at which tessellation is at maximum (say, 10 meters), and distance towards which tessellation level gradually decreases (say, 20 meters).


    Shader "Tessellation Sample" {
        Properties {
            _Tess ("Tessellation", Range(1,32)) = 4
            _MainTex ("Base (RGB)", 2D) = "white" {}
            _DispTex ("Disp Texture", 2D) = "gray" {}
            _NormalMap ("Normalmap", 2D) = "bump" {}
            _Displacement ("Displacement", Range(0, 1.0)) = 0.3
            _Color ("Color", color) = (1,1,1,0)
            _SpecColor ("Spec color", color) = (0.5,0.5,0.5,0.5)
        }
        SubShader {
            Tags { "RenderType"="Opaque" }
            LOD 300
            
            CGPROGRAM
            #pragma surface surf BlinnPhong addshadow fullforwardshadows vertex:disp __tessellate:tessDistance__ nolightmap
            #pragma target 5.0
            __#include "Tessellation.cginc"__

            struct appdata {
                float4 vertex : POSITION;
                float4 tangent : TANGENT;
                float3 normal : NORMAL;
                float2 texcoord : TEXCOORD0;
            };

            float _Tess;

            __float4 tessDistance (appdata v0, appdata v1, appdata v2) {__
                __float minDist = 10.0;__
                __float maxDist = 25.0;__
                __return UnityDistanceBasedTess(v0.vertex, v1.vertex, v2.vertex, minDist, maxDist, _Tess);__
            }

            sampler2D _DispTex;
            float _Displacement;

            void disp (inout appdata v)
            {
                float d = tex2Dlod(_DispTex, float4(v.texcoord.xy,0,0)).r * _Displacement;
                v.vertex.xyz += v.normal * d;
            }

            struct Input {
                float2 uv_MainTex;
            };

            sampler2D _MainTex;
            sampler2D _NormalMap;
            fixed4 _Color;

            void surf (Input IN, inout SurfaceOutput o) {
                half4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
                o.Albedo = c.rgb;
                o.Specular = 0.2;
                o.Gloss = 1.0;
                o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_MainTex));
            }
            ENDCG
        }
        FallBack "Diffuse"
    }

Here the tessellation function takes three parameters; the vertex data of three triangle corners before tessellation. This is needed to compute tessellation levels, which depend on vertex positions now. We include a built-in helper file `Tessellation.cginc` and call `UnityDistanceBasedTess` function from it to do all the work. That function computes distance of each vertex to the camera and derives final tessellation factors.



![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderTess3-distance.png)  


Edge length based tessellation
------------------------------


Purely distance based tessellation is good only when triangle sizes are quite similar. In the image above, you can see that objects that have small triangles are tessellated too much, while objects that have large triangles aren't tessellated enough.

Instead, tessellation levels could be computed based on triangle edge length on the screen - the longer the edge, the larger tessellation factor should be applied.


    Shader "Tessellation Sample" {
        Properties {
            _'_EdgeLength ("Edge length", Range(2,50)) = 15_'
            _MainTex ("Base (RGB)", 2D) = "white" {}
            _DispTex ("Disp Texture", 2D) = "gray" {}
            _NormalMap ("Normalmap", 2D) = "bump" {}
            _Displacement ("Displacement", Range(0, 1.0)) = 0.3
            _Color ("Color", color) = (1,1,1,0)
            _SpecColor ("Spec color", color) = (0.5,0.5,0.5,0.5)
        }
        SubShader {
            Tags { "RenderType"="Opaque" }
            LOD 300
            
            CGPROGRAM
            #pragma surface surf BlinnPhong addshadow fullforwardshadows vertex:disp __tessellate:tessEdge__ nolightmap
            #pragma target 5.0
            #include "Tessellation.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float4 tangent : TANGENT;
                float3 normal : NORMAL;
                float2 texcoord : TEXCOORD0;
            };

            __float _EdgeLength;__

            __float4 tessEdge (appdata v0, appdata v1, appdata v2)__
            {
                __return UnityEdgeLengthBasedTess (v0.vertex, v1.vertex, v2.vertex, _EdgeLength);__
            }

            sampler2D _DispTex;
            float _Displacement;

            void disp (inout appdata v)
            {
                float d = tex2Dlod(_DispTex, float4(v.texcoord.xy,0,0)).r * _Displacement;
                v.vertex.xyz += v.normal * d;
            }

            struct Input {
                float2 uv_MainTex;
            };

            sampler2D _MainTex;
            sampler2D _NormalMap;
            fixed4 _Color;

            void surf (Input IN, inout SurfaceOutput o) {
                half4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
                o.Albedo = c.rgb;
                o.Specular = 0.2;
                o.Gloss = 1.0;
                o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_MainTex));
            }
            ENDCG
        }
        FallBack "Diffuse"
    }

Here again, we just call `UnityEdgeLengthBasedTess` function from `Tessellation.cginc` to do all the actual work.



![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderTess4-edgelength.png)  


For performance reasons, it's advisable to call `UnityEdgeLengthBasedTessCull` function instead, which will do patch frustum culling. This makes the shader a bit more expensive, but saves a lot of GPU work for parts of meshes that are outside of camera's view.



Phong Tessellation
------------------



[Phong Tessellation](https://www.google.lt/search?q=phong+tessellation.md) modifies positions of the subdivided faces so that the resulting surface follows the mesh normals a bit. It's quite an effective way of making low-poly meshes become more smooth.

Unity's surface shaders can compute Phong tessellation automatically using `tessphong:VariableName` compilation directive. Here's an example shader:

    Shader "Phong Tessellation" {
        Properties {
            _EdgeLength ("Edge length", Range(2,50)) = 5
            _'_Phong ("Phong Strengh", Range(0,1)) = 0.5_'
            _MainTex ("Base (RGB)", 2D) = "white" {}
            _Color ("Color", color) = (1,1,1,0)
        }
        SubShader {
            Tags { "RenderType"="Opaque" }
            LOD 300
            
            CGPROGRAM
            #pragma surface surf Lambert vertex:dispNone tessellate:tessEdge __tessphong:_Phong__ nolightmap
            #include "Tessellation.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord : TEXCOORD0;
            };

            void dispNone (inout appdata v) { }

            __float _Phong;__
            float _EdgeLength;

            float4 tessEdge (appdata v0, appdata v1, appdata v2)
            {
                return UnityEdgeLengthBasedTess (v0.vertex, v1.vertex, v2.vertex, _EdgeLength);
            }

            struct Input {
                float2 uv_MainTex;
            };

            fixed4 _Color;
            sampler2D _MainTex;

            void surf (Input IN, inout SurfaceOutput o) {
                half4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
                o.Albedo = c.rgb;
                o.Alpha = c.a;
            }

            ENDCG
        }
        FallBack "Diffuse"
    }

Here's a comparison between regular shader (top row) and one that uses Phong tessellation (bottom row). You can see that even without any displacement mapping,
the surface becomes more round.


![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderPhongTess.png)  

