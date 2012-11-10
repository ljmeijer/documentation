ShaderLab syntax: Properties
============================


Shaders can define a list of parameters to be set by artists in Unity's [material inspector](Materials.md). The Properties block in the shader file defines them.

Syntax
------

:__Properties__ { _Property_ [_Property ..._] }: Defines the property block. Inside braces multiple properties are defined as follows.
:_name_ ("_display name_", __Range__ (_min_, _max_)) = _number_: Defines a float property, represented as a slider from _min_ to _max_ in the inspector.
:_name_ ("_display name_", __Color__) = (_number_,_number_,_number_,_number_): Defines a color property.
:_name_ ("_display name_", __2D__) = "_name_" { _options_ }: Defines a 2D texture property.
:_name_ ("_display name_", __Rect__) = "_name_" { _options_ }: Defines a rectangle (non power of 2) texture property.
:_name_ ("_display name_", __Cube__) = "_name_" { _options_ }: Defines a cubemap texture property.
:_name_ ("_display name_", __Float__) = _number_: Defines a float property.
:_name_ ("_display name_", __Vector__) = (_number_,_number_,_number_,_number_): Defines a four component vector property.

Details
-------


Each property inside the shader is referenced by __name__ (in Unity, it's common to start shader property names with underscore). The property will show up in material inspector as __display name__. For each property a default value is given after equals sign:
* For _Range_ and _Float_ properties it's just a single number.
* For _Color_ and _Vector_ properties it's four numbers in parentheses.
* For texture (_2D_, _Rect_, _Cube_) the default value is either an empty string, or one of builtin default textures: "_white_", "_black_", "_gray_" or "_bump_".

Later on in the shader, property values are accessed using property name in square brackets: __[name]__.

Example
-------


````
Properties {
    // properties for water shader
    _WaveScale ("Wave scale", Range (0.02,0.15)) = 0.07 // sliders
    _ReflDistort ("Reflection distort", Range (0,1.5)) = 0.5
    _RefrDistort ("Refraction distort", Range (0,1.5)) = 0.4
    _RefrColor ("Refraction color", Color)  = (.34, .85, .92, 1) // color
    _ReflectionTex ("Environment Reflection", 2D) = "" {} // textures
    _RefractionTex ("Environment Refraction", 2D) = "" {}
    _Fresnel ("Fresnel (A) ", 2D) = "" {}
    _BumpMap ("Bumpmap (RGB) ", 2D) = "" {}
} 
````


###Texture property options

The _options_ inside curly braces of the texture property are optional. The available options are:

* __TexGen__ _texgenmode_: Automatic texture coordinate generation mode for this texture. Can be one of _ObjectLinear_, _EyeLinear_, _SphereMap_, _CubeReflect_, _CubeNormal_; these correspond directly to OpenGL texgen modes. Note that TexGen is ignored if custom vertex programs are used.
* __LightmapMode__ If given, this texture will be affected by per-renderer lightmap parameters. That is, the texture to use can be not in the material, but taken from the settings of the Renderer instead, see [Renderer scripting documentation](ScriptRef:Renderer-lightmapIndex.html).

###Example

````
// EyeLinear texgen mode example
Shader "Texgen/Eye Linear" {
    Properties {
        _MainTex ("Base", 2D) = "white" { TexGen EyeLinear }
    }
    SubShader {
        Pass {
            SetTexture [_MainTex] { combine texture }
        }
    }
} 
````

