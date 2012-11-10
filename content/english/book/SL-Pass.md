ShaderLab syntax: Pass
======================

The Pass block causes the geometry of an object to be rendered once.

Syntax
------

:__Pass__ __{__ _[Name and Tags] [RenderSetup] [TextureSetup]_ __}__ : The basic pass command contains an optional list of render setup commands, optionally followed by a list of textures to use.

Name and tags
-------------


A Pass can define its [Name](SL-Name.md) and arbitrary number of [Tags](SL-PassTags.md) - name/value strings that communicate Pass' intent to the rendering engine.

Render Setup
------------


A pass sets up various states of the graphics hardware, for example should alpha blending be turned on, should fog be used, and so on. The commands are these:

:__Material__ __{__ _Material Block_ __}__: Defines a material to use in a vertex lighting pipeline. See [material page](SL-Material.md) for details.
:__Lighting__ On | Off: Turn vertex lighting on or off. See [material page](SL-Material.md) for details.
:__Cull__ Back | Front | Off: Set polygon culling mode.
:__ZTest__ (Less | Greater | LEqual | GEqual | Equal | NotEqual | Always): Set depth testing mode.
:__ZWrite__ On | Off: Set depth writing mode.
:__Fog__ __{__ _Fog Block_ __}__: Set fog parameters.
:__AlphaTest__ (Less | Greater | LEqual | GEqual | Equal | NotEqual | Always) _CutoffValue_: Turns on alpha testing.
:__Blend__ _SourceBlendMode_ _DestBlendMode_: Sets alpha blending mode.
:__Color__ _Color value_: Sets color to use if vertex lighting is turned off.
:__ColorMask__ RGB | A | 0 | any combination of R, G, B, A: Set color writing mask. Writing _ColorMask 0_ turns off rendering to all color channels.
:__Offset__ _OffsetFactor_ __,__ _OffsetUnits_: Set depth offset. Note that this command intentionally only accepts constants (i.e., not shader parameters) as of Unity 3.0.
:__SeparateSpecular__ On | Off: Turns separate specular color for vertex lighting on or off. See [material page](SL-Material.md) for details.
:__ColorMaterial__ AmbientAndDiffuse | Emission: Uses per-vertex color when computing vertex lighting. See [material page](SL-Material.md) for details.

Texture Setup
-------------


After the render state setup, you can specify a number of textures and their combining modes to apply using [SetTexture](SL-SetTexture.md) commands:
>__SetTexture__ _texture property_ { _[Combine options]_ }

The texture setup configures fixed function multitexturing pipeline, and is ignored if custom [fragment shaders](SL-ShaderPrograms.md) are used.


Details
-------


###Per-pixel Lighting

The per-pixel lighting pipeline works by rendering objects in multiple passes. Unity renders the object once to get ambient and any vertex lights in. Then it renders each pixel light affecting the object in a separate additive pass. See [Render Pipeline](SL-RenderPipeline.md) for details.

###Per-vertex Lighting

Per-vertex lighting is the standard Direct3D/OpenGL lighting model that is computed for each vertex. <span class=component>Lighting on</span> turns it on. Lighting is affected by <span class=keyword>Material</span> block, <span class=keyword>ColorMaterial</span> and <span class=keyword>SeparateSpecular</span> commands.  See [material page](SL-Material.md) for details.

See Also
--------


There are several special passes available for reusing common functionality or implementing various high-end effects:
* [UsePass](SL-UsePass.md) includes named passes from another shader.
* [GrabPass](SL-GrabPass.md) grabs the contents of the screen into a texture, for use in a later pass.

Subsections
-----------


(:tocportion:)

