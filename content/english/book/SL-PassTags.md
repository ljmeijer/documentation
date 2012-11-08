ShaderLab syntax: Pass Tags
===========================


Passes use tags to tell how and when they expect to be rendered to the rendering engine.

Syntax
------

:__Tags {__ "_TagName1_" = "_Value1_" "_TagName2_" = "_Value2_" __}__: Specifies __TagName1__ to have __Value1__, __TagName2__ to have __Value2__. You can have as many tags as you like.

Details
-------

Tags are basically key-value pairs. Inside a [Pass](SL-Pass.md) tags are used to control which role this pass has in the lighting pipeline (ambient, vertex lit, pixel lit etc.) and some other options. Note that the following tags recognized by Unity _'must_ be inside Pass section and not inside SubShader!

###LightMode tag

__LightMode__ tag defines Pass' role in the lighting pipeline. See [render pipeline](SL-RenderPipeline.md) for details. These tags are rarely used manually; most often shaders that need to interact with lighting are written as [Surface Shaders](SL-SurfaceShaders.md) and then all those details are taken care of.

Possible values for LightMode tag are:
* __Always__: Always rendered; no lighting is applied.
* __ForwardBase__: Used in [Forward rendering](RenderTech-ForwardRendering.md), ambient, main directional light and vertex/SH lights are applied.
* __ForwardAdd__: Used in [Forward rendering](RenderTech-ForwardRendering.md); additive per-pixel lights are applied, one pass per light.
* __PrepassBase__: Used in [Deferred Lighting](RenderTech-DeferredLighting.md), renders normals & specular exponent.
* __PrepassFinal__: Used in [Deferred Lighting](RenderTech-DeferredLighting.md), renders final color by combining textures, lighting & emission.
* __Vertex__: Used in [Vertex Lit rendering](RenderTech-VertexLit.md) when object is not lightmapped; all vertex lights are applied.
* __VertexLMRGBM__: Used in [Vertex Lit rendering](RenderTech-VertexLit.md) when object is lightmapped; on platforms where lightmap is RGBM encoded.
* __VertexLM__: Used in [Vertex Lit rendering](RenderTech-VertexLit.md) when object is lightmapped; on platforms where lightmap is double-LDR encoded (generally mobile platforms & old dekstop GPUs).
* __ShadowCaster__: Renders object as shadow caster.
* __ShadowCollector__: Gathers object's shadows into screen-space buffer for Forward rendering path.



###RequireOptions tag

A pass can indicate that it should only be rendered when some external conditions are met. This is done by using __RequireOptions__ tag, whose value is a string of space separated options. Currently the options supported by Unity are:
* __SoftVegetation__: Render this pass only if Soft Vegetation is on in [Quality Settings](class-QualitySettings.md).


See Also
--------


SubShaders can be given Tags as well, see [SubShader Tags](SL-SubshaderTags.md).


