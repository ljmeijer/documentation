Providing vertex data to vertex programs
========================================


For Cg/HLSL [vertex programs](SL-ShaderPrograms.md), the vertex data must be passed in as a structure. Several commonly used vertex structures are defined in [SL-BuiltinIncludes | <span class=keyword>UnityCG.cginc</span> include file](SL-BuiltinIncludes|<span class=keyword>UnityCG.cginc</span>includefile.md), and in most cases it's enough just to use them. The structures are:
* <span class=keyword>appdata_base</span>: vertex consists of position, normal and one texture coordinate.
* <span class=keyword>appdata_tan</span>: vertex consists of position, tangent, normal and one texture coordinate.
* <span class=keyword>appdata_full</span>: vertex consists of position, tangent, normal, two texture coordinates and color.

For example, this shader colors the mesh based on it's normals and just uses <span class=keyword>appdata_base</span> as vertex program input:
````

Shader "VertexInputSimple" {
  SubShader {
    Pass {
      CGPROGRAM
      #pragma vertex vert
      #pragma fragment frag
      #include "UnityCG.cginc"
     
      struct v2f {
          float4 pos : SV_POSITION;
          fixed4 color : COLOR;
      };
      
      v2f vert (appdata_base v)
      {
          v2f o;
          o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
          o.color.xyz = v.normal * 0.5 + 0.5;
          o.color.w = 1.0;
          return o;
      }

      fixed4 frag (v2f i) : COLOR0 { return i.color; }
      ENDCG
    }
  } 
}

````

If you want to access different vertex data, you have to declare vertex structure yourself. The structure __members must be__ from the following list:
* <span class=keyword>float4 vertex</span> is the vertex position
* <span class=keyword>float3 normal</span> is the vertex normal
* <span class=keyword>float4 texcoord</span> is the first UV coordinate
* <span class=keyword>float4 texcoord1</span> is the second UV coordinate
* <span class=keyword>float4 tangent</span> is the tangent vector (used for normal mapping)
* <span class=keyword>float4 color</span> is per-vertex color

Examples
--------


###Visualizing UVs

The following shader example uses vertex position and first texture coordinate as vertex shader input (defined in structure <span class=keyword>appdata</span>). It is very useful to debug UV coordinates of the mesh. UV coordinates are visualized as red and green colors, and coordinates outside of 0..1 range have additional blue tint applied.

````

Shader "!Debug/UV 1" {
SubShader {
    Pass {
        Fog { Mode Off }
CGPROGRAM
#pragma vertex vert
#pragma fragment frag

// vertex input: position, UV
struct appdata {
    float4 vertex : POSITION;
    float4 texcoord : TEXCOORD0;
};

struct v2f {
    float4 pos : SV_POSITION;
    float4 uv : TEXCOORD0;
};
v2f vert (appdata v) {
    v2f o;
    o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
    o.uv = float4( v.texcoord.xy, 0, 0 );
    return o;
}
half4 frag( v2f i ) : COLOR {
    half4 c = frac( i.uv );
    if (any(saturate(i.uv) - i.uv))
        c.b = 0.5;
    return c;
}
ENDCG
    }
}
}
````



![](http://docwiki.hq.unity3d.com/uploads/Main/SL-DebugUV1.png)  
_Debug UV1 shader applied to a torus knot model_

Similarly, this shader vizualizes the second UV set of the model:
````
Shader "!Debug/UV 2" {
SubShader {
    Pass {
        Fog { Mode Off }
CGPROGRAM
#pragma vertex vert
#pragma fragment frag

// vertex input: position, second UV
struct appdata {
    float4 vertex : POSITION;
    float4 texcoord1 : TEXCOORD1;
};

struct v2f {
    float4 pos : SV_POSITION;
    float4 uv : TEXCOORD0;
};
v2f vert (appdata v) {
    v2f o;
    o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
    o.uv = float4( v.texcoord1.xy, 0, 0 );
    return o;
}
half4 frag( v2f i ) : COLOR {
    half4 c = frac( i.uv );
    if (any(saturate(i.uv) - i.uv))
        c.b = 0.5;
    return c;
}
ENDCG
    }
}
}
````

###Visualizing vertex colors

The following shader uses vertex position and per-vertex colors as vertex shader input (defined in structure <span class=keyword>appdata</span>).

````
Shader "!Debug/Vertex color" {
SubShader {
    Pass {
        Fog { Mode Off }
CGPROGRAM
#pragma vertex vert
#pragma fragment frag

// vertex input: position, color
struct appdata {
    float4 vertex : POSITION;
    fixed4 color : COLOR;
};

struct v2f {
    float4 pos : SV_POSITION;
    fixed4 color : COLOR;
};
v2f vert (appdata v) {
    v2f o;
    o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
    o.color = v.color;
    return o;
}
fixed4 frag (v2f i) : COLOR0 { return i.color; }
ENDCG
    }
}
}
````


![](http://docwiki.hq.unity3d.com/uploads/Main/SL-DebugColors.png)  
_Debug Colors shader applied to a model that has illumination baked into colors_


###Visualizing normals

The following shader uses vertex position and normal as vertex shader input (defined in structure <span class=keyword>appdata</span>). Normal's X,Y,Z components are visualized as R,G,B colors. Because the normal components are in -1..1 range, we scale and bias them so that the output colors are in displayable 0..1 range.

````
Shader "!Debug/Normals" {
SubShader {
    Pass {
        Fog { Mode Off }
CGPROGRAM
#pragma vertex vert
#pragma fragment frag

// vertex input: position, normal
struct appdata {
    float4 vertex : POSITION;
    float3 normal : NORMAL;
};

struct v2f {
    float4 pos : SV_POSITION;
    fixed4 color : COLOR;
};
v2f vert (appdata v) {
    v2f o;
    o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
    o.color.xyz = v.normal * 0.5 + 0.5;
    o.color.w = 1.0;
    return o;
}
fixed4 frag (v2f i) : COLOR0 { return i.color; }
ENDCG
    }
}
}
````


![](http://docwiki.hq.unity3d.com/uploads/Main/SL-DebugNormals.png)  
_Debug Normals shader applied to a model. You can see that the model has hard shading edges._


###Visualizing tangents and binormals

Tangent and binormal vectors are used for normal mapping. In Unity only the tangent vector is stored in vertices, and binormal is derived from normal and tangent.

The following shader uses vertex position and tangent as vertex shader input (defined in structure <span class=keyword>appdata</span>). Tangent's X,Y,Z components are visualized as R,G,B colors. Because the normal components are in -1..1 range, we scale and bias them so that the output colors are in displayable 0..1 range.

````
Shader "!Debug/Tangents" {
SubShader {
    Pass {
        Fog { Mode Off }
CGPROGRAM
#pragma vertex vert
#pragma fragment frag

// vertex input: position, tangent
struct appdata {
    float4 vertex : POSITION;
    float4 tangent : TANGENT;
};

struct v2f {
    float4    pos : SV_POSITION;
    fixed4    color : COLOR;
};
v2f vert (appdata v) {
    v2f o;
    o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
    o.color = v.tangent * 0.5 + 0.5;
    return o;
}
fixed4 frag (v2f i) : COLOR0 { return i.color; }
ENDCG
    }
}
}
````


![](http://docwiki.hq.unity3d.com/uploads/Main/SL-DebugTangents.png)  
_Debug Tangents shader applied to a model._

The following shader visualizes binormals. It uses vertex position, normal and tangent as vertex input. Binormal is calculated from normal and tangent. Just like normal or tangent, it needs to be scaled and biased into a displayable 0..1 range.

````
Shader "!Debug/Binormals" {
SubShader {
    Pass {
        Fog { Mode Off }
CGPROGRAM
#pragma vertex vert
#pragma fragment frag

// vertex input: position, normal, tangent
struct appdata {
    float4 vertex : POSITION;
    float3 normal : NORMAL;
    float4 tangent : TANGENT;
};

struct v2f {
    float4    pos : SV_POSITION;
    float4    color : COLOR;
};
v2f vert (appdata v) {
    v2f o;
    o.pos = mul( UNITY_MATRIX_MVP, v.vertex );
    // calculate binormal
    float3 binormal = cross( v.normal, v.tangent.xyz ) * v.tangent.w;
    o.color.xyz = binormal * 0.5 + 0.5;
    o.color.w = 1.0;
    return o;
}
fixed4 frag (v2f i) : COLOR0 { return i.color; }
ENDCG
    }
}
}
````


![](http://docwiki.hq.unity3d.com/uploads/Main/SL-DebugBinormals.png)  
_Debug Binormals shader applied to a model. Pretty!_
