Surface Shader Lighting Examples
================================


Here are some examples of [Surface Shaders](SL-SurfaceShaderLighting|<span class=keyword>customlightingmodels</span>]]in[[SL-SurfaceShaders.md). General Surface Shader examples are in [this page](SL-SurfaceShaderExamples.md).

Because Deferred Lighting does not play well with some custom per-material lighting models, in most examples below we make the shaders compile to Forward Rendering only.


Diffuse
-------


We'll start with a shader that uses built-in Lambert lighting model:

  Shader "Example/Diffuse Texture" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
      };
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
      }
      ENDCG
    }
    Fallback "Diffuse"
  }

Here's how it looks like with a texture and without an actual texture (one directional light is in the scene):   

![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderDiffuseTexture.png)  


Now, let's do exactly the same, but write out _our own lighting model_ instead of using built-in Lambert one. [Surface Shader Lighting Models](SL-SurfaceShaderLighting.md) are just some functions that we need to write. Here's a simple Lambert one. Note that the "shader part" itself did not change at all (grayed out):

  %gray%Shader "Example/Diffuse Texture" {
  %gray%  Properties {
  %gray%    _MainTex ("Texture", 2D) = "white" {}
  %gray%  }
  %gray%  SubShader {
  %gray%    Tags { "RenderType" = "Opaque" }
  %gray%    CGPROGRAM
      #pragma surface surf __SimpleLambert__
      
      half4 LightingSimpleLambert (SurfaceOutput s, half3 lightDir, half atten) {
          half NdotL = dot (s.Normal, lightDir);
          half4 c;
          c.rgb = s.Albedo * _LightColor0.rgb * (NdotL * atten * 2);
          c.a = s.Alpha;
          return c;
      }
      
  %gray%    struct Input {
  %gray%        float2 uv_MainTex;
  %gray%    };
  %gray%    sampler2D _MainTex;
  %gray%    void surf (Input IN, inout SurfaceOutput o) {
  %gray%        o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
  %gray%    }
  %gray%    ENDCG
  %gray%  }
  %gray%  Fallback "Diffuse"
  %gray%}

So our simple Diffuse lighting model is `LightingSimpleLambert` function. It computes lighting by doing a dot product between surface normal and light direction, and then applies light attenuation and color.


Diffuse Wrap
------------


Here's Wrapped Diffuse - a modification of Diffuse lighting, where illumination "wraps around" the edges of objects. It's useful for faking subsurface scattering effect. Again, the surface shader itself did not change at all, we're just using different lighting function.

  %gray%Shader "Example/Diffuse Wrapped" {
  %gray%  Properties {
  %gray%    _MainTex ("Texture", 2D) = "white" {}
  %gray%  }
  %gray%  SubShader {
  %gray%    Tags { "RenderType" = "Opaque" }
  %gray%    CGPROGRAM
      #pragma surface surf __WrapLambert__
      
      half4 LightingWrapLambert (SurfaceOutput s, half3 lightDir, half atten) {
          half NdotL = dot (s.Normal, lightDir);
          half diff = __NdotL * 0.5 + 0.5__;
          half4 c;
          c.rgb = s.Albedo * _LightColor0.rgb * (diff * atten * 2);
          c.a = s.Alpha;
          return c;
      }
      
  %gray%    struct Input {
  %gray%        float2 uv_MainTex;
  %gray%    };
  %gray%    sampler2D _MainTex;
  %gray%    void surf (Input IN, inout SurfaceOutput o) {
  %gray%        o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
  %gray%    }
  %gray%    ENDCG
  %gray%  }
  %gray%  Fallback "Diffuse"
  %gray%}



![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderDiffuseWrap.png)  


Toon Ramp
---------


Here's a "Ramp" lighting model that uses a texture ramp to define how surface responds to angle between light and the normal. This can be used for variety of effects, including Toon lighting.

  %gray%Shader "Example/Toon Ramp" {
  %gray%  Properties {
  %gray%    _MainTex ("Texture", 2D) = "white" {}
      ___Ramp ("Shading Ramp", 2D) = "gray" {}__
  %gray%  }
  %gray%  SubShader {
  %gray%    Tags { "RenderType" = "Opaque" }
  %gray%    CGPROGRAM
      #pragma surface surf __Ramp__
      
      sampler2D _Ramp;
      
      half4 LightingRamp (SurfaceOutput s, half3 lightDir, half atten) {
          half NdotL = dot (s.Normal, lightDir);
          half diff = NdotL * 0.5 + 0.5;
          __half3 ramp = tex2D (_Ramp, float2(diff)).rgb;__
          half4 c;
          c.rgb = s.Albedo * _LightColor0.rgb * ramp * (atten * 2);
          c.a = s.Alpha;
          return c;
      }
      
  %gray%    struct Input {
  %gray%        float2 uv_MainTex;
  %gray%    };
  %gray%    sampler2D _MainTex;
  %gray%    void surf (Input IN, inout SurfaceOutput o) {
  %gray%        o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
  %gray%    }
  %gray%    ENDCG
  %gray%  }
  %gray%  Fallback "Diffuse"
  %gray%}



![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderToonRamp.png)  


![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderToonRampItself.png)  


Simple Specular
---------------


Here's a simple specular lighting model. It's quite simple to what built-in BlinnPhong actually does; we just put it here to illustrate how it's done.

  %gray%Shader "Example/Simple Specular" {
  %gray%  Properties {
  %gray%    _MainTex ("Texture", 2D) = "white" {}
  %gray%  }
  %gray%  SubShader {
  %gray%    Tags { "RenderType" = "Opaque" }
  %gray%    CGPROGRAM
      #pragma surface surf SimpleSpecular
      
      half4 LightingSimpleSpecular (SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {
          half3 h = normalize (lightDir + viewDir);
          
          half diff = max (0, dot (s.Normal, lightDir));
          
          float nh = max (0, dot (s.Normal, h));
          float spec = pow (nh, 48.0);
          
          half4 c;
          c.rgb = (s.Albedo * _LightColor0.rgb * diff + _LightColor0.rgb * spec) * (atten * 2);
          c.a = s.Alpha;
          return c;
      }
      
  %gray%    struct Input {
  %gray%        float2 uv_MainTex;
  %gray%    };
  %gray%    sampler2D _MainTex;
  %gray%    void surf (Input IN, inout SurfaceOutput o) {
  %gray%        o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
  %gray%    }
  %gray%    ENDCG
  %gray%  }
  %gray%  Fallback "Diffuse"
  %gray%}



![](http://docwiki.hq.unity3d.com/uploads/Main/SurfaceShaderSimpleSpecular.png)  

