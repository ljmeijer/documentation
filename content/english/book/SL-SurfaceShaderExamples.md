Surface Shader Examples
=======================


Here are some examples of [Surface Shader Lighting Examples](SL-SurfaceShaders|<span class=keyword>SurfaceShaders</span>]].Theexamplesbelowfocusonusingbuilt-inlightingmodels;examplesonhowtoimplementcustomlightingmodelsarein[[SL-SurfaceShaderLightingExamples.md).

Simple
------


We'll start with a very simple shader and build up on that. Here's a shader that just sets surface color to "white". It uses built-in Lambert (diffuse) lighting model.


  Shader "Example/Diffuse Simple" {
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float4 color : COLOR;
      };
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = 1;
      }
      ENDCG
    }
    Fallback "Diffuse"
  }

Here's how it looks like on a model with two [lights](class-Light.md) set up:   

![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderSimple.png)  

Texture
-------


An all-white object is quite boring, so let's add a texture. We'll add a [Properties block](SL-Properties.md) to the shader, so we get a texture selector in our Material. Other changes are in bold below.

  Shader "Example/Diffuse Texture" {
    __Properties {__
      ___MainTex ("Texture", 2D) = "white" {}__
    __}__
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          __float2 uv_MainTex;__
      };
      __sampler2D _MainTex;__
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = __tex2D (_MainTex, IN.uv_MainTex).rgb__;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }


![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderDiffuseTex.png)  

Normal mapping
--------------


Let's add some normal mapping:

  Shader "Example/Diffuse Bump" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      ___BumpMap ("Bumpmap", 2D) = "bump" {}__
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
        float2 uv_MainTex;
        float2 uv_BumpMap;
      };
      sampler2D _MainTex;
      __sampler2D _BumpMap;__
      void surf (Input IN, inout SurfaceOutput o) {
        o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
        __o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));__
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }


![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderDiffuseBump.png)  


Rim Lighting
------------


Now, try to add some Rim Lighting to highlight the edges of an object. We'll add some emissive light based on angle between surface normal and view direction. For that, we'll use `viewDir` built-in surface shader variable.

  Shader "Example/Rim" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _BumpMap ("Bumpmap", 2D) = "bump" {}
      ___RimColor ("Rim Color", Color) = (0.26,0.19,0.16,0.0)__
      ___RimPower ("Rim Power", Range(0.5,8.0)) = 3.0__
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
          float2 uv_BumpMap;
          __float3 viewDir;__
      };
      sampler2D _MainTex;
      sampler2D _BumpMap;
      __float4 _RimColor;__
      __float _RimPower;__
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
          __half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));__
          __o.Emission = _RimColor.rgb * pow (rim, _RimPower);__
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }


![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderRim.png)  


Detail Texture
--------------


For a different effect, let's add a detail texture that is combined with the base texture. Detail texture uses the same UVs, but usually different Tiling in the Material, so we have to use different input UV coordinates.

  Shader "Example/Detail" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _BumpMap ("Bumpmap", 2D) = "bump" {}
      ___Detail ("Detail", 2D) = "gray" {}__
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
          float2 uv_BumpMap;
          __float2 uv_Detail;__
      };
      sampler2D _MainTex;
      sampler2D _BumpMap;
      __sampler2D _Detail;__
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          __o.Albedo *= tex2D (_Detail, IN.uv_Detail).rgb * 2;__
          o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }

Using a checker texture does not make much practical sense, but illustrates what happens:   

![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderDetailTex.png)  


Detail Texture in Screen Space
------------------------------


How about a detail texture in screen space? It does not make much sense for a soldier head model, but illustrates how a built-in `screenPos` input might be used:

  Shader "Example/ScreenPos" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _Detail ("Detail", 2D) = "gray" {}
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
          __float4 screenPos;__
      };
      sampler2D _MainTex;
      sampler2D _Detail;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          __float2 screenUV = IN.screenPos.xy / IN.screenPos.w;__
          __screenUV *= float2(8,6);__
          __o.Albedo *= tex2D (_Detail, screenUV).rgb * 2;__
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }

I removed normal mapping from the shader above, just to make it shorter:   

![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderDetailTexScreenPos.png)  


Cubemap Reflection
------------------


Here's a shader that does cubemapped reflection using built-in `worldRefl` input. It's actually very similar to built-in Reflective/Diffuse shader:

  Shader "Example/WorldRefl" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      ___Cube ("Cubemap", CUBE) = "" {}__
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
          __float3 worldRefl;__
      };
      sampler2D _MainTex;
      __samplerCUBE _Cube;__
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * 0.5;
          __o.Emission = texCUBE (_Cube, IN.worldRefl).rgb;__
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }

And since it assigns the reflection color as Emission, we get a very shiny soldier:   

![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderWorldRefl.png)  


If you want to do reflections that are affected by normal maps, it needs to be slightly more involved: `INTERNAL_DATA` needs to be added to the Input structure, and `WorldReflectionVector` function used to compute per-pixel reflection vector after you've written the Normal output.

  Shader "Example/WorldRefl Normalmap" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _BumpMap ("Bumpmap", 2D) = "bump" {}
      _Cube ("Cubemap", CUBE) = "" {}
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
          float2 uv_BumpMap;
          float3 worldRefl;
          __INTERNAL_DATA__
      };
      sampler2D _MainTex;
      sampler2D _BumpMap;
      samplerCUBE _Cube;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * 0.5;
          o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
          o.Emission = texCUBE (_Cube, __WorldReflectionVector (IN, o.Normal)__).rgb;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }

Here's a normal mapped shiny soldier:   

![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderWorldReflNormalmap.png)  


Slices via World Space Position
-------------------------------


Here's a shader that "slices" the object by discarding pixels in nearly horizontal rings. It does that by using `clip()` Cg/HLSL function based on world position of a pixel. We'll use `worldPos` built-in surface shader variable.

  Shader "Example/Slices" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _BumpMap ("Bumpmap", 2D) = "bump" {}
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      __Cull Off__
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
          float2 uv_BumpMap;
          __float3 worldPos;__
      };
      sampler2D _MainTex;
      sampler2D _BumpMap;
      void surf (Input IN, inout SurfaceOutput o) {
          __clip (frac((IN.worldPos.y+IN.worldPos.z*0.1) * 5) - 0.5);__
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }


![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderSlices.png)  



Normal Extrusion with Vertex Modifier
-------------------------------------


It is possible to use a "vertex modifier" function that will modify incoming vertex data in the vertex shader. This can be used for procedural animation, extrusion along normals and so on. Surface shader compilation directive `vertex:functionName` is used for that, with a function that takes `inout appdata_full` parameter.

Here's a shader that moves vertices along their normals by the amount specified in the material:

  Shader "Example/Normal Extrusion" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      ___Amount ("Extrusion Amount", Range(-1,1)) = 0.5__
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert __vertex:vert__
      struct Input {
          float2 uv_MainTex;
      };
      __float _Amount;__
      __void vert (inout appdata_full v) {__
          __v.vertex.xyz += v.normal * _Amount;__
      __}__
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }

Moving vertices along their normals makes a fat soldier:   

![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderNormalExtrusion.png)  



Custom data computed per-vertex
-------------------------------


Using a vertex modifier function it is also possible to compute custom data in a vertex shader, which then will be passed to the surface shader function per-pixel. The same compilation directive `vertex:functionName` is used, but the function should take two parameters: `inout appdata_full` and `out Input`. You can fill in any Input member that is not a built-in value there.

Example below defines a custom `float3 customColor` member, which is computed in a vertex function:


###u30 Details
  Shader "Example/Custom Vertex Data" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert __vertex:vert__
      struct Input {
          float2 uv_MainTex;
          __float3 customColor;__
      };
      void vert (inout appdata_full v, __out Input o__) {
          __o.customColor = abs(v.normal);__
      }
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          __o.Albedo *= IN.customColor;__
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }

###u40 Details
  Shader "Example/Custom Vertex Data" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert __vertex:vert__
      struct Input {
          float2 uv_MainTex;
          __float3 customColor;__
      };
      void vert (inout appdata_full v, __out Input o__) {
          __UNITY_INITIALIZE_OUTPUT(Input,o);__
          __o.customColor = abs(v.normal);__
      }
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          __o.Albedo *= IN.customColor;__
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }

In this example `customColor` is set to the absolute value of the normal:   

![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderCustomVertexData.png)  

More practical uses could be computing any per-vertex data that is not provided by built-in Input variables; or optimizing shader computations. For example, it's possible to compute Rim lighting at object's vertices, instead of doing that in the surface shader per-pixel.


Final Color Modifier
--------------------


It is possible to use a "final color modifier" function that will modify final color computed by the shader. Surface shader compilation directive `finalcolor:functionName` is used for that, with a function that takes `Input IN, SurfaceOutput o, inout fixed4 color` parameters.

Here's a simple shader that applies tint to final color. This is different from just applying tint to surface Albedo color: this tint will also affect any color that came from lightmaps, light probes and similar extra sources.

  Shader "Example/Tint Final Color" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      ___ColorTint ("Tint", Color) = (1.0, 0.6, 0.6, 1.0)__
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert __finalcolor:mycolor__
      struct Input {
          float2 uv_MainTex;
      };
      __fixed4 _ColorTint;__
      __void mycolor (Input IN, SurfaceOutput o, inout fixed4 color)__
      {
          __color *= _ColorTint;__
      }
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
           o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }



![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderFinalColorSimple.png)  


Custom Fog with Final Color Modifier
------------------------------------


Common use case for final color modifier (see above) would be implementing completely custom Fog. Fog needs to affect the final computed pixel shader color, which is exactly what the `finalcolor` modifier does.

Here's a shader that applies fog tint based on distance from screen center. This combines both the vertex modifier with custom vertex data (`fog`) and final color modifier. When used in forward rendering additive pass, Fog needs to fade to black color, and this example handles that as well with a check for `UNITY_PASS_FORWARDADD`.


###u30 Details
  Shader "Example/Fog via Final Color" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      ___FogColor ("Fog Color", Color) = (0.3, 0.4, 0.7, 1.0)__
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert __finalcolor:mycolor vertex:myvert__
      struct Input {
          float2 uv_MainTex;
          __half fog;__
      };
      void myvert (inout appdata_full v, out Input data)
      {
          __float4 hpos = mul (UNITY_MATRIX_MVP, v.vertex);__
          __data.fog = min (1, dot (hpos.xy, hpos.xy) * 0.1);__
      }
      fixed4 _FogColor;
      void mycolor (Input IN, SurfaceOutput o, inout fixed4 color)
      {
          __fixed3 fogColor = _FogColor.rgb;__
          __#ifdef UNITY_PASS_FORWARDADD__
          __fogColor = 0;__
          __#endif__
          __color.rgb = lerp (color.rgb, fogColor, IN.fog);__
      }
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
           o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }

###u40 Details
  Shader "Example/Fog via Final Color" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      ___FogColor ("Fog Color", Color) = (0.3, 0.4, 0.7, 1.0)__
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert __finalcolor:mycolor vertex:myvert__
      struct Input {
          float2 uv_MainTex;
          __half fog;__
      };
      void myvert (inout appdata_full v, out Input data)
      {
          __UNITY_INITIALIZE_OUTPUT(Input,v);__
          __float4 hpos = mul (UNITY_MATRIX_MVP, v.vertex);__
          __data.fog = min (1, dot (hpos.xy, hpos.xy) * 0.1);__
      }
      fixed4 _FogColor;
      void mycolor (Input IN, SurfaceOutput o, inout fixed4 color)
      {
          __fixed3 fogColor = _FogColor.rgb;__
          __#ifdef UNITY_PASS_FORWARDADD__
          __fogColor = 0;__
          __#endif__
          __color.rgb = lerp (color.rgb, fogColor, IN.fog);__
      }
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
           o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }



![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderFinalColorFog.png)  

