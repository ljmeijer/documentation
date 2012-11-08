ShaderLab syntax: Shader
========================


<span class=component>Shader</span> is the root command of a shader file. Each file must define one (and only one) Shader. It specifies how any objects whose material uses this shader are rendered.

Syntax
------

__Shader__ "_name_" __{__ [Properties] Subshaders [Fallback] __}__ Defines a shader. It will appear in the material inspector listed under __name__. Shaders optionally can define a list of __properties__ that show up as material settings. After this comes a list of SubShaders, and optionally a fallback.

Details
-------


###Properties

Shaders can have a list of [properties](SL-Properties.md). Any properties declared in a shader are shown in the material inspector inside Unity. Typical properties are the object color, textures, or just arbitrary values to be used by the shader.

###SubShaders & Fallback

Each shader is comprised of a list of [sub-shaders](SL-SubShader.md). You must have at least one. When loading a shader, Unity will go through the list of subshaders, and pick the first one that is supported by the end user's machine. If no subshaders are supported, Unity will try to use [fallback shader](SL-Fallback.md).

Different graphic cards have different capabilities. This raises an eternal issue for game developers; you want your game to look great on the latest hardware, but don't want it to be available only to those 3% of the population. This is where subshaders come in. Create one subshader that has all the fancy graphic effects you can dream of, then add more subshaders for older cards. These subshaders may implement the effect you want in a slower way, or they may choose not to implement some details.

Examples
--------


Here is one of the simplest shaders possible:

````
// colored vertex lighting
Shader "Simple colored lighting" {
    // a single color property
    Properties {
        _Color ("Main Color", Color) = (1,.5,.5,1)
    }
    // define one subshader
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

This shader defines a color property <span class=component>_Color</span> (that shows up in material inspector as _Main Color_) with a default value of <span class=component>(1, 0.5, 0.5, 1)</span>. Then a single subshader is defined. The subshader consists of one [Pass](SL-Pass.md) that turns on vertex lighting and sets up basic material for it.

Subsections
-----------


(:tocportion:)

