ShaderLab syntax: Texture Combiners
===================================


After the basic vertex lighting has been calculated, textures are applied. In ShaderLab this is done using __SetTexture__ command.

_SetTexture commands have no effect when [fragment programs](SL-ShaderPrograms.md) are used; as in that case pixel operations are completely described in the shader._


![](http://docwiki.hq.unity3d.com/uploads/Main/SL./PipelineFFP.png)  

Texturing is the place to do old-style combiner effects. You can have multiple SetTexture commands inside a pass - all textures are applied in sequence, like layers in a painting program. SetTexture commands must be placed at the end of a [Pass](SL-Pass.md).

Syntax
------

:__SetTexture__ _[TexturePropertyName]_ __{__ _Texture Block_ __}__: Assigns a texture. _TextureName_ must be defined as a texture property. How to apply the texture is defined inside the _TextureBlock_.

The texture block controls how the texture is applied. Inside the texture block can be up to three commands: `combine`, `matrix` and `constantColor`.

Texture block `combine` command
-------------------------------


:`combine` _src1_ * _src2_: Multiplies src1 and src2 together. The result will be darker than either input.
:`combine` _src1_ + _src2_: Adds  src1 and src2 together. The result will be lighter than either input.
:`combine` _src1_ - _src2_:  Subtracts src2 from src1.
:`combine` _src1_ +- _src2_: Adds src1 to src2, then subtracts 0.5 (a signed add).
:`combine` _src1_ `lerp` (_src2_) _src3_: Interpolates between src3 and src1, using the alpha of src2. Note that the interpolation is opposite direction: src1 is used when alpha is one, and src3 is used when alpha is zero.
:`combine` _src1_ * _src2_ + _src3_: Multiplies src1 with the alpha component of src2, then adds src3.
:`combine` _src1_ * _src2_ +- _src3_: Multiplies src1 with the alpha component of src2, then does a signed add with src3.
:`combine` _src1_ * _src2_ - _src3_:  Multiplies src1 with the alpha component of src2, then subtracts src3.

All the __src__ properties can be either one of _previous_, _constant_, _primary_ or _texture_.  
* __Previous__ is the the result of the previous SetTexture.
* __Primary__ is the color from the [lighting calculation](SL-Material.md) or the vertex color if it is [bound](SL-BindChannels.md).
* __Texture__ is the color of the texture specified by _[_TextureName]_ in the SetTexture (see above).
* __Constant__ is the color specified in __ConstantColor__.

Modifiers:
* The formulas specified above can optionally be followed by the keywords __Double__ or __Quad__ to make the resulting color 2x or 4x as bright.
* All the __src__ properties, except `lerp` argument, can optionally be preceded by __one -__ to make the resulting color negated.
* All the __src__ properties can be followed by __alpha__ to take only the alpha channel.


Texture block `constantColor` command
-------------------------------------


:__ConstantColor__ _color_: Defines a constant color that can be used in the combine command.


Texture block `matrix` command
------------------------------


:__matrix__ _[MatrixPropertyName]_: Transforms texture coordinates used in this command with the given matrix.



Details
=======


Before [fragment programs](SL-ShaderPrograms.md) existed, older graphics cards used a layered approach to textures. The textures are applied one after each other, modifying the color that will be written to the screen. For each texture, the texture is typically combined with the result of the previous operation.


![](http://docwiki.hq.unity3d.com/uploads/Main/SL./SetTextureGraph.png)  

Note that on "true fixed function" devices (OpenGL, OpenGL ES 1.1, Wii) the value of each SetTexture stage is clamped to 0..1 range. Everywhere else (Direct3D, OpenGL ES 2.0) the range may or may not be higher. This might affect SetTexture stages that can produce values higher than 1.0.


Separate Alpha & Color computation
----------------------------------


By default, the combiner formula is used for calculating both the RGB and alpha component of the color. Optionally, you can specify a separate formula for the alpha calculation. This looks like this:

````
SetTexture [_MainTex] { combine previous * texture, previous + texture } 
````

Here, we multiply the RGB colors and add the alpha.


Specular highlights
-------------------


By default the __primary__ color is the sum of the diffuse, ambient and specular colors (as defined in the [Lighting calculation](SL-Material.md)). If you specify __SeparateSpecular On__ in the pass options, the specular color will be added in _after_ the combiner calculation, rather than before. This is the default behavior of the built-in VertexLit shader.


Graphics hardware support
-------------------------


Modern graphics cards with [fragment shader](SL-ShaderPrograms.md) support ("shader model 2.0" on desktop, OpenGL ES 2.0 on mobile) support all <span class=component>SetTexture</span> modes and at least 4 texture stages (many of them support 8). If you're running on really old hardware (made before 2003 on PC, or before iPhone3GS on mobile), you might have as low as two texture stages. The shader author should write separate [SubShaders](SL-SubShader.md) for the cards he or she wants to support.


Examples
========


Alpha Blending Two Textures
---------------------------

This small examples takes two textures. First it sets the first combiner to just take the ___MainTex__, then is uses the alpha channel of ___BlendTex__ to fade in the RGB colors of ___BlendTex__

````
Shader "Examples/2 Alpha Blended Textures" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _BlendTex ("Alpha Blended (RGBA) ", 2D) = "white" {}
    }
    SubShader {
        Pass {
            // Apply base texture
            SetTexture [_MainTex] {
                combine texture
            }
            // Blend in the alpha texture using the lerp operator
            SetTexture [_BlendTex] {
                combine texture lerp (texture) previous
            }
        }
    }
} 
````


Alpha Controlled Self-illumination
----------------------------------

This shader uses the alpha component of the ___MainTex__ to decide where to apply lighting. It does this by applying the texture to two stages; In the first stage, the alpha value of the texture is used to blend between the vertex color and solid white. In the second stage, the RGB values of the texture are multiplied in.


````
Shader "Examples/Self-Illumination" {
    Properties {
        _MainTex ("Base (RGB) Self-Illumination (A)", 2D) = "white" {}
    }
    SubShader {
        Pass {
            // Set up basic white vertex lighting
            Material {
                Diffuse (1,1,1,1)
                Ambient (1,1,1,1)
            }
            Lighting On

            // Use texture alpha to blend up to white (= full illumination)
            SetTexture [_MainTex] {
                constantColor (1,1,1,1)
                combine constant lerp(texture) previous
            }
            // Multiply in texture
            SetTexture [_MainTex] {
                combine previous * texture
            }
        }
    }
} 
````


We can do something else for free here, though; instead of blending to solid white, we can add a self-illumination color and blend to that. Note the use of __ConstantColor__ to get a _SolidColor from the properties into the texture blending.


````
Shader "Examples/Self-Illumination 2" {
    Properties {
        _IlluminCol ("Self-Illumination color (RGB)", Color) = (1,1,1,1)
        _MainTex ("Base (RGB) Self-Illumination (A)", 2D) = "white" {}
    }
    SubShader {
        Pass {
            // Set up basic white vertex lighting
            Material {
                Diffuse (1,1,1,1)
                Ambient (1,1,1,1)
            }
            Lighting On

            // Use texture alpha to blend up to white (= full illumination)
            SetTexture [_MainTex] {
                // Pull the color property into this blender
                constantColor [_IlluminCol]
                // And use the texture's alpha to blend between it and
                // vertex color
                combine constant lerp(texture) previous
            }
            // Multiply in texture
            SetTexture [_MainTex] {
                combine previous * texture
            }
        }
    }
} 
````


And finally, we take all the lighting properties of the vertexlit shader and pull that in:

````
Shader "Examples/Self-Illumination 3" {
    Properties {
        _IlluminCol ("Self-Illumination color (RGB)", Color) = (1,1,1,1)
        _Color ("Main Color", Color) = (1,1,1,0)
        _SpecColor ("Spec Color", Color) = (1,1,1,1)
        _Emission ("Emmisive Color", Color) = (0,0,0,0)
        _Shininess ("Shininess", Range (0.01, 1)) = 0.7
        _MainTex ("Base (RGB)", 2D) = "white" {}
    }

    SubShader {
        Pass {
            // Set up basic vertex lighting
            Material {
                Diffuse [_Color]
                Ambient [_Color]
                Shininess [_Shininess]
                Specular [_SpecColor]
                Emission [_Emission]
            }
            Lighting On

            // Use texture alpha to blend up to white (= full illumination)
            SetTexture [_MainTex] {
                constantColor [_IlluminCol]
                combine constant lerp(texture) previous
            }
            // Multiply in texture
            SetTexture [_MainTex] {
                combine previous * texture
            }
        }
    }
} 
````

