ShaderLab syntax: Blending
==========================


Blending is used to make transparent objects.


![](http://docwiki.hq.unity3d.com/uploads/Main/SL./PipelineBlend.png)  

When graphics are rendered, after all shaders have executed and all textures have been applied, the pixels are written to the screen. How they are combined with what is already there is controlled by the Blend command.

Syntax
------


:Blend Off: Turn off blending
:Blend _SrcFactor_ _DstFactor_: Configure & enable blending. The generated color is multiplied by the __SrcFactor__. The color already on screen is multiplied by __DstFactor__ and the two are added together.
:Blend _SrcFactor_ _DstFactor_, _SrcFactorA_ _DstFactorA_: Same as above, but use different factors for blending the alpha channel.
:BlendOp _Min | Max | Sub | RevSub_: Instead of adding blended colors together, do a different operation on them.


Properties
----------


All following properties are valid for both SrcFactor & DstFactor. __Source__ refers to the calculated color, __Destination__ is the color already on the screen.


|    |    |
|:---|:---|
|__One__ |The value of one - use this to let either the source or the destination color come through fully. |
|__Zero__ |The value zero - use this to remove either the source or the destination values. |
|__SrcColor__ |The value of this stage is multiplied by the source color value. |
|__SrcAlpha__ |The value of this stage is multiplied by the source alpha value. |
|__DstColor__ |The value of this stage is multiplied by frame buffer source color value. |
|__DstAlpha__ |The value of this stage is multiplied by frame buffer source alpha value. |
|__OneMinusSrcColor__ |The value of this stage is multiplied by (1 - source color). |
|__OneMinusSrcAlpha__ |The value of this stage is multiplied by (1 - source alpha). |
|__OneMinusDstColor__ |The value of this stage is multiplied by (1 - destination color). |
|__OneMinusDstAlpha__ |The value of this stage is multiplied by (1 - destination alpha). |


Details
-------


Below are the most common blend types:

````

Blend SrcAlpha OneMinusSrcAlpha     // Alpha blending
Blend One One                       // Additive
Blend OneMinusDstColor One          // Soft Additive
Blend DstColor Zero                 // Multiplicative
Blend DstColor SrcColor             // 2x Multiplicative

````

Example
-------

Here is a small example shader that adds a texture to whatever is on the screen already:

````
Shader "Simple Additive" {
    Properties {
        _MainTex ("Texture to blend", 2D) = "black" {}
    }
    SubShader {
        Tags { "Queue" = "Transparent" }
        Pass {
            Blend One One
            SetTexture [_MainTex] { combine texture }
        }
    }
}
````

And a more complex one, Glass. This is a two-pass shader:
1. The first pass renders a lit, alpha-blended texture on to the screen. The alpha channel decides the transparency.
1. The second pass renders a reflection cubemap on top of the alpha-blended window, using additive transparency.

````
Shader "Glass" {
    Properties {
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB) Transparency (A)", 2D) = "white" {}
        _Reflections ("Base (RGB) Gloss (A)", Cube) = "skybox" { TexGen CubeReflect }
    }
    SubShader {
        Tags { "Queue" = "Transparent" }
        Pass {
            Blend SrcAlpha OneMinusSrcAlpha
            Material {
                Diffuse [_Color]
            }
            Lighting On
            SetTexture [_MainTex] {
                combine texture * primary double, texture * primary
            }
        }
        Pass {
            Blend One One
            Material {
                Diffuse [_Color]
            }
            Lighting On
            SetTexture [_Reflections] {
                combine texture
                Matrix [_Reflection]
            }
        }
    }
} 
````
