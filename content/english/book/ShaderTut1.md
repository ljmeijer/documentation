Shaders: ShaderLab & Fixed Function shaders
===========================================


This tutorial will teach you how you can create your own shaders and make your game look a lot better!

Unity is equipped with a powerful shading and material language called <span class=keyword>ShaderLab</span>. In style it is similar to CgFX and Direct3D Effects (.FX) languages - it describes everything needed to display a [class-Material | <span class=keyword>Material</span>](class-Material|<span class=keyword>Material</span>.md).

Shaders describe properties that are exposed in Unity's [Material Inspector](class-Material.md) and multiple shader implementations (<span class=keyword>SubShaders</span>) targeted at different graphics hardware capabilities, each describing complete graphics hardware rendering state, fixed function pipeline setup or vertex/fragment programs to use. Vertex and fragment programs are written in the high-level <span class=keyword>Cg/HLSL</span> programming language.

In this tutorial we describe how to write shaders in using both fixed function and programmable pipelines. We assume that the reader has a basic understanding of [OpenGL](http://opengl.org/documentation/red_book.md) or Direct3D render states, fixed function and programmable pipelines and has some knowledge of [Cg](http://developer.nvidia.com/object/cg_toolkit.html.md), [HLSL](http://msdn.microsoft.com/en-us/library/bb509561%28VS.85%29.aspx.md) or [GLSL](http://www.opengl.org/documentation/glsl.md) programming languages. Some shader tutorials and documentation can be found on [NVIDIA](http://developer.nvidia.com/page/home.html.md) and [AMD](http://developer.amd.com/GPU/Pages/default.aspx.md) developer sites.

Getting started
---------------


To create a new shader, either choose <span class=menu>Assets->Create->Shader</span> from the menubar, or duplicate an existing shader, and work from that. The new shader can be edited by double-clicking it in the <span class=keyword>Project View</span>.

We'll start with a very basic shader:


````
Shader "Tutorial/Basic" {
    Properties {
        _Color ("Main Color", Color) = (1,0.5,0.5,1)
    }
    SubShader {
        Pass {
            Material {
                Diffuse [_Color]
            }
            Lighting On
        }
    }
} 
````


This simple shader demonstrates one of the most basic shaders possible. It defines a color property called <span class=component>Main Color</span> and assigns it a default value of rose-like color (red=100% green=50% blue=50% alpha=100%). It then renders the object by invoking a <span class=keyword>Pass</span> and in that pass setting the diffuse material component to the property <span class=component>_Color</span> and turning on per-vertex lighting.

To test this shader, create a new material, select the shader from the drop-down menu (<span class=menu>Tutorial->Basic</span>) and assign the Material to some object. Tweak the color in the Material Inspector and watch the changes. Time to move onto more complex things!


Basic Vertex Lighting
---------------------


If you open an existing complex shader, it can be a bit hard to get a good overview. To get you started, we will dissect the built-in <span class=keyword>VertexLit</span> shader that ships with Unity. This shader uses fixed function pipeline to do standard per-vertex lighting.


````
Shader "VertexLit" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,0.5)
        _SpecColor ("Spec Color", Color) = (1,1,1,1)
        _Emission ("Emmisive Color", Color) = (0,0,0,0)
        _Shininess ("Shininess", Range (0.01, 1)) = 0.7
        _MainTex ("Base (RGB)", 2D) = "white" { }
    }

    SubShader {
        Pass {
            Material {
                Diffuse [_Color]
                Ambient [_Color]
                Shininess [_Shininess]
                Specular [_SpecColor]
                Emission [_Emission]
            }
            Lighting On
            SeparateSpecular On
            SetTexture [_MainTex] {
                constantColor [_Color]
                Combine texture * primary DOUBLE, texture * constant
            }
        }
    }
} 
````


All shaders start with the keyword <span class=component>[Shader](SL-Shader.md)</span> followed by a string that represents the name of the shader. This is the name that is shown in the <span class=keyword>Inspector</span>. All code for this shader must be put within the curly braces after it: <span class=component>{ }</span> (called a block).

* The name should be short and descriptive. It does not have to match the __.shader__ file name.
* To put shaders in submenus in Unity, use slashes - e.g. <span class=component>MyShaders/Test</span> would be shown as <span class=menu>Test</span> in a submenu called <span class=menu>MyShaders</span>, or <span class=menu>MyShaders->Test</span>.

The shader is composed of a <span class=component>Properties</span> block followed by <span class=component>SubShader</span> blocks. Each of these is described in sections below.


Properties
----------


At the beginning of the shader block you can define any properties that artists can edit in the [Material Inspector](class-Material.md). In the _VertexLit_ example the properties look like this:


![](http://docwiki.hq.unity3d.com/uploads/Main/ShaderTutProperties.png)  

The properties are listed on separate lines within the <span class=component>[Properties](SL-Properties.md)</span> block. Each property starts with the internal name (<span class=component>Color</span>, <span class=component>MainTex</span>). After this in parentheses comes the name shown in the inspector and the type of the property. After that, the default value for this property is listed:


![](http://docwiki.hq.unity3d.com/uploads/Main/ShaderTutPropertyDetail.png)  

The list of possible types are in the [Properties Reference](SL-Properties.md). The default value depends on the property type. In the example of a color, the default value should be a four component vector.

We now have our properties defined, and are ready to start writing the actual shader.


The Shader Body
---------------


Before we move on, let's define the basic structure of a shader file.

Different graphic hardware has different capabilities. For example, some graphics cards support fragment programs and others don't; some can lay down four textures per pass while the others can do only two or one; etc. To allow you to make full use of whatever hardware your user has, a shader can contain multiple <span class=keyword>SubShaders</span>. When Unity renders a shader, it will go over all subshaders and use the first one that the hardware supports.


````
Shader "Structure Example" {
    Properties { /* ...shader properties... }
    SubShader {
    	// ...subshader that uses vertex/fragment programs...
    }
    SubShader {
    	// ...subshader that uses four textures per pass...
    }
    SubShader {
    	// ...subshader that uses two textures per pass...
    }
    SubShader {
    	// ...subshader that might look ugly but runs on anything :)
    }
} 
````

This system allows Unity to support all existing hardware and maximize the quality on each one. It does, however, result in some long shaders.

Inside each SubShader block you set the rendering state shared by all passes; and define rendering passes themselves. A complete list of available commands can be found in the [SubShader Reference](SL-SubShader.md).


Passes
------


Each subshader is a collection of passes. For each pass, the object geometry is rendered, so there must be at least one pass. Our VertexLit shader has just one pass:

````
// ...snip...
Pass {
    Material {
        Diffuse [_Color]
        Ambient [_Color]
        Shininess [_Shininess]
        Specular [_SpecColor]
        Emission [_Emission]
    }
    Lighting On
    SeparateSpecular On
    SetTexture [_MainTex] {
        constantColor [_Color]
        Combine texture * primary DOUBLE, texture * constant
    }
}
// ...snip... 
````

Any commands defined in a pass configures the graphics hardware to render the geometry in a specific way.

In the example above we have a <span class=component>[Material](SL-Material.md)</span> block that binds our property values to the fixed function lighting material settings. The command <span class=component>Lighting On</span> turns on the standard vertex lighting, and <span class=component>SeparateSpecular On</span> enables the use of a separate color for the specular highlight.

All of these command so far map very directly to the fixed function OpenGL/Direct3D hardware model. Consult [OpenGL red book](http://opengl.org/documentation/red_book.md) for more information on this.

The next command, <span class=component>[SetTexture](SL-SetTexture.md)</span>, is very important. These commands define the textures we want to use and how to mix, combine and apply them in our rendering. <span class=component>SetTexture</span> command is followed by the property name of the texture we would like to use (<span class=component>_MainTex</span> here) This is followed by a <span class=keyword>combiner block</span> that defines how the texture is applied. The commands in the combiner block are executed for each pixel that is rendered on screen.

Within this block we set a constant color value, namely the Color of the Material, <span class=component>_Color</span>. We'll use this constant color below.

In the next command we specify how to mix the texture with the color values. We do this with the <span class=component>Combine</span> command that specifies how to blend the texture with another one or with a color. Generally it looks like this:
    <span class=component>Combine</span> <span class=keyword>ColorPart</span>, <span class=keyword>AlphaPart</span>

Here <span class=component>ColorPart</span> and <span class=component>AlphaPart</span> define blending of color (RGB) and alpha (A) components respectively. If <span class=component>AlphaPart</span> is omitted, then it uses the same blending as <span class=component>ColorPart</span>.

In our VertexLit example:
    <span class=component>Combine</span> texture * primary DOUBLE__,__ texture * constant

Here <span class=component>texture</span> is the color coming from the current texture (here <span class=component>_MainTex</span>). It is multiplied (*) with the <span class=component>primary</span> vertex color.  Primary color is the vertex lighting color, calculated from the Material values above. Finally, the result is multiplied by two to increase lighting intensity (<span class=component>DOUBLE</span>). The alpha value (after the comma) is <span class=component>texture</span> multiplied by <span class=component>constant</span> value (set with <span class=component>constantColor</span> above). Another often used combiner mode is called <span class=component>previous</span> (not used in this shader). This is the result of any previous <span class=component>SetTexture</span> step, and can be used to combine several textures and/or colors with each other.

Summary
-------


Our VertexLit shader configures standard vertex lighting and sets up the texture combiners so that the rendered lighting intensity is doubled.

We could put more passes into the shader, they would get rendered one after the other. For now, though, that is not nessesary  as we have the desired effect. We only need one SubShader as we make no use of any advanced features - this particular shader will work on any graphics card that Unity supports.

The VertexLit shader is one of the most basic shaders that we can think of. We did not use any hardware specific operations, nor did we utilize any of the more special and cool commands that ShaderLab and Cg has to offer.

In the [next chapter](ShaderTut2.md) we'll proceed by explaining how to write custom vertex & fragment programs using Cg language.
