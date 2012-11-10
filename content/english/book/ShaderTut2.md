Shaders: Vertex and Fragment Programs
=====================================


This tutorial will teach you how to write custom vertex and fragment programs in Unity shaders. For a basic introduction to <span class=keyword>ShaderLab</span> see the [Getting Started tutorial](ShaderTut1.md). If you want to write shaders that interact with lighting, read about __[Surface Shaders](SL-SurfaceShaders.md)__ instead.

Lets start with a small recap of the general structure of a shader:


````
Shader "MyShaderName" {
    Properties {
        // ... properties here ...
    }
    SubShader {
        // ... subshader for graphics hardware A ...
        Pass {
            // ... pass commands ...
        }
        // ... more passes if needed ...
    }
    SubShader {
        // ... subshader for graphics hardware B ...
    }
    // ... Optional fallback ...
    FallBack "VertexLit"
} 
````

Here at the end we introduce a new command:
    <span class=component>FallBack "VertexLit"</span>

The <span class=component>[Fallback](SL-Fallback.md)</span> command can be used at the end of the shader; it tells which shader should be used if no <span class=keyword>SubShaders</span> from the current shader can run on user's graphics hardware. The effect is the same as including all SubShaders from the fallback shader at the end. For example, if you were to write a normal-mapped shader, then instead of writing a very basic non-normal-mapped subshader for old graphics cards you can just fallback to built-in <span class=keyword>VertexLit</span> shader.

The basic building blocks of the shader are introduced in the [first shader tutorial](ShaderTut1.md) while the full documentation of [Properties](SL-Properties.md), [SubShaders](SL-SubShader.md) and [Passes](SL-Pass.md) are also available.

A quick way of building SubShaders is to use passes defined in other shaders. The command <span class=component>[UsePass](SL-UsePass.md)</span> does just that, so you can reuse shader code in a neat fashion. As an example the following command uses the pass with the name "BASE" from the built-in <span class=keyword>Specular</span> shader:
    <span class=component>UsePass "Specular/BASE"</span>

In order for <span class=component>UsePass</span> to work, a name must be given to the pass one wishes to use. The <span class=component>[Name](SL-Name.md)</span> command inside the pass gives it a name:
    <span class=component>Name "MyPassName"</span>


Vertex and fragment programs
----------------------------


We described a pass that used just a single texture combine instruction in the [first tutorial](ShaderTut1.md). Now it is time to demonstrate how we can use vertex and fragment programs in our pass.

When you use vertex and fragment programs (the so called "programmable pipeline"), most of the hardcoded functionality ("fixed function pipeline") in the graphics hardware is switched off. For example, using a vertex program turns off standard 3D transformations, lighting and texture coordinate generation completely. Similarly, using a fragment program replaces any texture combine modes that would be defined in SetTexture commands; thus SetTexture commands are not needed.

Writing vertex/fragment programs requires a thorough knowledge of 3D transformations, lighting and coordinate spaces - because you have to rewrite the fixed functionality that is built into API's like OpenGL yourself. On the other hand, you can do much more than what's built in!


Using Cg in ShaderLab
---------------------


Shaders in ShaderLab are usually written in [Cg programming language](http://developer.nvidia.com/page/cg_main.html.md) by embedding "Cg snippets" in the shader text. Cg snippets are compiled into low-level shader assembly by the Unity editor, and the final shader that is included in your game's data files only contains this low-level assembly. When you select a shader in the <span class=keyword>Project View</span>, the <span class=keyword>Inspector</span> shows shader text after Cg compilation, which might help as a debugging aid. Unity automatically compiles Cg snippets for both Direct3D, OpenGL, Flash and so on, so your shaders will just work on all platforms. Note that because Cg code is compiled by the editor, you can't create Cg shaders from scripts at runtime.

In general, Cg snippets are placed inside Pass blocks. They look like this:

  Pass {
      _// ... the usual pass state setup ..._
      
      __CGPROGRAM__
      _// compilation directives for this snippet, e.g.:_
      __#pragma vertex__ vert
      __#pragma fragment__ frag
      
      _// the Cg code itself_
      
      __ENDCG__
      _// ... the rest of pass setup ..._
  }


The following example demonstrates a complete shader with Cg programs that renders object normals as colors:

````
Shader "Tutorial/Display Normals" {
SubShader {
    Pass {

CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

struct v2f {
    float4 pos : SV_POSITION;
    float3 color : COLOR0;
};

v2f vert (appdata_base v)
{
    v2f o;
    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
    o.color = v.normal * 0.5 + 0.5;
    return o;
}

half4 frag (v2f i) : COLOR
{
    return half4 (i.color, 1);
}
ENDCG

    }
}
Fallback "VertexLit"
} 
````


When applied on an object it will result in an image like this (if your graphics card supports vertex & fragment programs of course):


![](http://docwiki.hq.unity3d.com/uploads/Main/ShaderTutNormalsShader.png)  

Our "Display Normals" shader does not have any properties, contains a single SubShader with a single Pass that is empty except for the Cg code. Finally, a fallback to the built-in <span class=keyword>VertexLit</span> shader is defined. Let's dissect the Cg code part by part:

    __CGPROGRAM__
    __#pragma vertex__ vert
    __#pragma fragment__ frag
    _// ... snip ..._
    __ENDCG__

The whole Cg snippet is written between <span class=component>CGPROGRAM</span> and <span class=component>ENDCG</span> keywords. At the start compilation directives are given as <span class=component>#pragma</span> statements:
* <span class=component>#pragma vertex</span> <span class=keyword>name</span> tells that the code contains a vertex program in the given function (<span class=component>vert</span> here).
* <span class=component>#pragma fragment</span> <span class=keyword>name</span> tells that the code contains a fragment program in the given function (<span class=component>frag</span> here).

Following the compilation directives is just plain Cg code. We start by including a [builtin Cg file](SL-BuiltinIncludes.md):
    #include <span class=keyword>UnityCg.cginc</span>

The <span class=keyword>UnityCg.cginc</span> file contains commonly used declarations and functions so that the shaders can be kept smaller (see [shader include files](SL-BuiltinIncludes.md) page for details). Here we'll use <span class=component>appdata_base</span> structure from that file. We could just define them directly in the shader and not include the file of course.

Next we define a "vertex to fragment" structure (here named <span class=component>v2f</span>) - what information is passed from the vertex to the fragment program. We pass the position and color parameters. The color will be computed in the vertex program and just output in the fragment program.

We proceed by defining the vertex program - <span class=component>vert</span> function. Here we compute the position and output input normal as a color:
    o.color = v.normal * 0.5 + 0.5;

Normal components are in -1..1 range, while colors are in 0..1 range, so we scale and bias the normal in the code above. Next we define a fragment program - <span class=component>frag</span> function that just outputs the calculated color and 1 as the alpha component:

    half4 frag (v2f i) : COLOR
    {
        return half4 (i.color, 1);
    }

That's it, our shader is finished! Even this simple shader is very useful to visualize mesh normals.

Of course, this shader does not respond to lights at all, and that's where things get a bit more interesting; read about [Surface Shaders](SL-SurfaceShaders.md) for details.


Using shader properties in Cg code
----------------------------------


When you define properties in the shader, you give them a name like <span class=component>_Color</span> or <span class=component>_MainTex</span>. To use them in Cg you just have to define a variable of a matching name and type. Unity will automatically set Cg variables that have names matching with shader properties.

Here is a complete shader that displays a texture modulated by a color. Of course, you could easily do the same in a texture combiner call, but the point here is just to show how to use properties in Cg:


````
Shader "Tutorial/Textured Colored" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,0.5)
    _MainTex ("Texture", 2D) = "white" { }
}
SubShader {
    Pass {

CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

float4 _Color;
sampler2D _MainTex;

struct v2f {
    float4  pos : SV_POSITION;
    float2  uv : TEXCOORD0;
};

float4 _MainTex_ST;

v2f vert (appdata_base v)
{
    v2f o;
    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
    return o;
}

half4 frag (v2f i) : COLOR
{
    half4 texcol = tex2D (_MainTex, i.uv);
    return texcol * _Color;
}
ENDCG

    }
}
Fallback "VertexLit"
} 
````


The structure of this shader is the same as in the previous example. Here we define two properties, namely <span class=component>_Color</span> and <span class=component>_MainTex</span>. Inside Cg code we define corresponding variables:

    float4 <span class=component>_Color</span>;
    sampler2D <span class=component>_MainTex</span>;

See [Accessing Shader Properties in Cg](SL-PropertiesInPrograms.md) for more information.

The vertex and fragment programs here don't do anything fancy; vertex program uses the <span class=component>TRANSFORM_TEX</span> macro from UnityCG.cginc to make sure texture scale&offset is applied correctly, and fragment program just samples the texture and multiplies by the color property.

Note that because we're writing our own fragment program here, we don't need any [SetTexture](SL-SetTexture.md) commands. How the textures are applied in the shader is entirely controlled by the fragment program.


Summary
-------


We have shown how custom shader programs can be generated in a few easy steps. While the examples shown here are very simple, there's nothing preventing you to write arbitrarily complex shader programs! This can help you to take the full advantage of Unity and achieve optimal rendering results.

The complete ShaderLab reference manual is [here](SL-Reference.md).  We also have a forum for shaders at [forum.unity3d.com](http://forum.unity3d.com.md) so go there to get help with your shaders!  Happy programming, and enjoy the power of Unity and Shaderlab.
