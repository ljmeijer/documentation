Accessing shader properties in Cg
=================================


Shader declares Material properties in a [Properties](SL-Properties.md) block. If you want to access some of those properties in a [shader program](SL-ShaderPrograms.md), you need to declare a Cg/HLSL variable with the same name and a matching type. An example is provided in [Shader Tutorial: Vertex and Fragment Programs](ShaderTut2.md).

For example these shader properties:
````

_MyColor ("Some Color", Color) = (1,1,1,1) 
_MyVector ("Some Vector", Vector) = (0,0,0,0) 
_MyFloat ("My float", Float) = 0.5 
_MyTexture ("Texture", 2D) = "white" {} 
_MyCubemap ("Cubemap", CUBE) = "" {} 

````
would be declared for access in Cg/HLSL code as:
````

fixed4 _MyColor; // low precision type is enough for colors
float4 _MyVector;
float _MyFloat; 
sampler2D _MyTexture;
samplerCUBE _MyCubemap;

````

Cg can also accept <span class=keyword>uniform</span> keyword, but it is not necessary:
````

uniform float4 _MyColor;

````

Property types in ShaderLab map to Cg/HLSL variable types this way:
* Color and Vector properties map to <span class=keyword>float4</span>, <span class=keyword>half4</span> or <span class=keyword>fixed4</span> variables.
* Range and Float properties map to <span class=keyword>float</span>, <span class=keyword>half</span> or <span class=keyword>fixed</span> variables.
* Texture properties map to <span class=keyword>sampler2D</span> variables for regular (2D) textures; Cubemaps map to <span class=keyword>samplerCUBE</span>; and 3D textures map to <span class=keyword>sampler3D</span>.
