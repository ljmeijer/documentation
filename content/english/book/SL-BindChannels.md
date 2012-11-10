ShaderLab syntax: BindChannels
==============================


<span class=keyword>BindChannels</span> command allows you to specify how vertex data maps to the graphics hardware.

_BindChannels has no effect when programmable vertex shaders are used, as in that case bindings are controlled by vertex shader inputs._

By default, Unity figures out the bindings for you, but in some cases you want custom ones to be used. 

For example you could map the primary UV set to be used in the first texture stage and the secondary UV set to be used in the second texture stage; or tell the hardware that vertex colors should be taken into account.

Syntax
------

:__BindChannels__ __{__ __Bind__ "_source_", _target_ __}__ : Specifies that vertex data _source_ maps to hardware _target_.

__Source__ can be one of:
* <span class=component>Vertex</span>: vertex position
* <span class=component>Normal</span>: vertex normal
* <span class=component>Tangent</span>: vertex tangent
* <span class=component>Texcoord</span>: primary UV coordinate
* <span class=component>Texcoord1</span>: secondary UV coordinate
* <span class=component>Color</span>: per-vertex color

__Target__ can be one of:
* <span class=component>Vertex</span>: vertex position
* <span class=component>Normal</span>: vertex normal
* <span class=component>Tangent</span>: vertex tangent
* <span class=component>Texcoord0</span>, <span class=component>Texcoord1</span>, ...: texture coordinates for corresponding texture stage
* <span class=component>Texcoord</span>: texture coordinates for all texture stages
* <span class=component>Color</span>: vertex color

Details
-------


Unity places some restrictions on which sources can be mapped to which targets. Source and target must match for <span class=component>Vertex</span>, <span class=component>Normal</span>, <span class=component>Tangent</span> and <span class=component>Color</span>. Texture coordinates from the mesh (<span class=component>Texcoord</span> and <span class=component>Texcoord1</span>) can be mapped into texture coordinate targets (<span class=component>Texcoord</span> for all texture stages, or <span class=component>TexcoordN</span> for a specific stage).

There are two typical use cases for BindChannels:
* Shaders that take vertex colors into account.
* Shaders that use two UV sets.

Examples
--------


````
// Maps the first UV set to the first texture stage
// and the second UV set to the second texture stage
BindChannels {
   Bind "Vertex", vertex
   Bind "texcoord", texcoord0
   Bind "texcoord1", texcoord1
} 
````


````
// Maps the first UV set to all texture stages
// and uses vertex colors
BindChannels {
   Bind "Vertex", vertex
   Bind "texcoord", texcoord
   Bind "Color", color
} 
````

