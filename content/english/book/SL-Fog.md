ShaderLab syntax: Fog
=====================


Fog parameters are controlled with Fog command.


![](http://docwiki.hq.unity3d.com/uploads/Main/SL./PipelineFFP.png)  

Fogging blends the color of the generated pixels down towards a constant color based on distance from camera. Fogging does not modify a blended pixel's alpha value, only its RGB components.

Syntax
------

:__Fog__ __{__ _Fog Commands_ __}__: Specify fog commands inside curly braces.
:__Mode__ Off | Global | Linear | Exp | Exp2: Defines fog mode. Default is global, which translates to Off or Exp2 depending whether fog is turned on in Render Settings.
:__Color__ _ColorValue_: Sets fog color.
:__Density__ _FloatValue_: Sets density for exponential fog.
:__Range__ _FloatValue_ __,__ _FloatValue_: Sets near & far range for linear fog.


Details
-------


Default fog settings are based on [Render Settings](class-RenderSettings.md): fog mode is either <span class=component>Exp2</span> or <span class=component>Off</span>; density & color taken from settings as well.

Note that if you use [fragment programs](SL-ShaderPrograms.md), Fog settings of the shader will still be applied. On platforms where there is no fixed function Fog functionality, Unity will patch shaders at runtime to support the requested Fog mode.
