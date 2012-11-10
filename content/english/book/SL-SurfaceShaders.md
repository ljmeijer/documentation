Writing Surface Shaders
=======================


Writing shaders that interact with lighting is complex. There are different light types, different shadow options, different rendering paths (forward and deferred rendering), and the shader should somehow handle all that complexity.

<span class=keyword>Surface Shaders</span> in Unity is a code generation approach that makes it much easier to write lit shaders than using low level [vertex/pixel shader programs](SL-ShaderPrograms.md). Note that there is no custom languages, magic or ninjas involved in Surface Shaders; it just generates all the repetitive code that would have to be written by hand. You still write shader code in Cg / HLSL.

For some examples, take a look at [SL-SurfaceShaderExamples | <span class=keyword>Surface Shader Examples</span>](SL-SurfaceShaderExamples|<span class=keyword>SurfaceShaderExamples</span>.md) and [SL-SurfaceShaderLightingExamples | <span class=keyword>Surface Shader Custom Lighting Examples</span>](SL-SurfaceShaderLightingExamples|<span class=keyword>SurfaceShaderCustomLightingExamples</span>.md).



How it works
------------


You define a "surface function" that takes any UVs or data you need as input, and fills in output structure `SurfaceOutput`. SurfaceOutput basically describes _properties of the surface_ (it's albedo color, normal, emission, specularity etc.). You write this code in Cg / HLSL.

Surface Shader compiler then figures out what inputs are needed, what outputs are filled and so on, and generates actual [vertex&pixel shaders](SL-ShaderPrograms.md), as well as rendering passes to handle forward and deferred rendering.

Standard output structure of surface shaders is this:
````

struct SurfaceOutput {
    half3 Albedo;
    half3 Normal;
    half3 Emission;
    half Specular;
    half Gloss;
    half Alpha;
};

````


Samples
-------



###u30 Details
See [SL-SurfaceShaderExamples | <span class=keyword>Surface Shader Examples</span>](SL-SurfaceShaderExamples|<span class=keyword>SurfaceShaderExamples</span>.md) and [SL-SurfaceShaderLightingExamples | <span class=keyword>Surface Shader Custom Lighting Examples</span>](SL-SurfaceShaderLightingExamples|<span class=keyword>SurfaceShaderCustomLightingExamples</span>.md) pages.

###u40 Details
See [SL-SurfaceShaderExamples | <span class=keyword>Surface Shader Examples</span>](SL-SurfaceShaderExamples|<span class=keyword>SurfaceShaderExamples</span>.md), [SL-SurfaceShaderLightingExamples | <span class=keyword>Surface Shader Custom Lighting Examples</span>](SL-SurfaceShaderLightingExamples|<span class=keyword>SurfaceShaderCustomLightingExamples</span>.md) and [SL-SurfaceShaderTessellation | <span class=keyword>Surface Shader Tessellation</span>](SL-SurfaceShaderTessellation|<span class=keyword>SurfaceShaderTessellation</span>.md) pages.


Surface Shader compile directives
---------------------------------


Surface shader is placed inside `CGPROGRAM..ENDCG` block, just like any other shader. The differences are:
* It must be placed inside [SubShader](SL-SubShader.md) block, not inside [Pass](SL-Pass.md). Surface shader will compile into multiple passes itself.
* It uses `#pragma surface ...` directive to indicate it's a surface shader.

The `#pragma surface` directive is:

    #pragma surface __surfaceFunction__ __lightModel__ _[optionalparams]_

Required parameters:
* surfaceFunction - which Cg function has surface shader code. The function should have the form of `void surf (Input IN, inout SurfaceOutput o)`, where Input is a structure you have defined. Input should contain any texture coordinates and extra automatic variables needed by surface function.
* lightModel - lighting model to use. Built-in ones are `Lambert` (diffuse) and `BlinnPhong` (specular). See [Custom Lighting Models](SL-SurfaceShaderLighting.md) page for how to write your own.


Optional parameters:
* `alpha` - Alpha blending mode. Use this for semitransparent shaders.
* `alphatest:VariableName` - Alpha testing mode. Use this for transparent-cutout shaders. Cutoff value is in float variable with VariableName.
* `vertex:VertexFunction` - Custom vertex modification function. See Tree Bark shader for example.
* `finalcolor:ColorFunction` - Custom final color modification function. See [Surface Shader Examples](SL-SurfaceShaderExamples.md).
* `exclude_path:prepass` or `exclude_path:forward` - Do not generate passes for given rendering path.
* `addshadow` - Add shadow caster & collector passes. Commonly used with custom vertex modification, so that shadow casting also gets any procedural vertex animation.
* `dualforward` - Use [dual lightmaps](LightmappingInDepth#DualLightmaps.md) in [forward](RenderTech-ForwardRendering.md) rendering path.
* `fullforwardshadows` - Support all shadow types in [Forward](RenderTech-ForwardRendering.md) rendering path.
* `decal:add` - Additive decal shader (e.g. terrain AddPass).
* `decal:blend` - Semitransparent decal shader.
* `softvegetation` - Makes the surface shader only be rendered when Soft Vegetation is on.
* `noambient` - Do not apply any ambient lighting or spherical harmonics lights.
* `novertexlights` - Do not apply any spherical harmonics or per-vertex lights in Forward rendering.
* `nolightmap` - Disables lightmap support in this shader (makes a shader smaller).
* `nodirlightmap` - Disables directional lightmaps support in this shader (makes a shader smaller).
* `noforwardadd` - Disables [Forward](RenderTech-ForwardRendering.md) rendering additive pass. This makes the shader support one full directional light, with all other lights computed per-vertex/SH. Makes shaders smaller as well.
* `approxview` - Computes normalized view direction per-vertex instead of per-pixel, for shaders that need it. This is faster, but view direction is not entirely correct when camera gets close to surface.
* `halfasview` - Pass half-direction vector into the lighting function instead of view-direction. Half-direction will be computed and normalized per vertex. This is faster, but not entirely correct.

###u40 Details
* `tessellate:TessFunction` - use DX11 GPU tessellation; the function computes tessellation factors. See [Surface Shader Tessellation](SL-SurfaceShaderTessellation.md) for details.


Additionally, you can write `#pragma debug` inside CGPROGRAM block, and then surface compiler will spit out a lot of comments of the generated code. You can view that using Open Compiled Shader in shader inspector.


Surface Shader input structure
------------------------------


The input structure `Input` generally has any texture coordinates needed by the shader. Texture coordinates must be named "`uv`" followed by texture name (or start it with "`uv2`" to use second texture coordinate set).

Additional values that can be put into Input structure:
* `float3 viewDir` - will contain view direction, for computing Parallax effects, rim lighting etc.
* `float4` with `COLOR` semantic - will contain interpolated per-vertex color.
* `float4 screenPos` - will contain screen space position for reflection effects. Used by WetStreet shader in Dark Unity for example.
* `float3 worldPos` - will contain world space position.
* `float3 worldRefl` - will contain world reflection vector _if surface shader does not write to o.Normal_. See Reflect-Diffuse shader for example.
* `float3 worldNormal` - will contain world normal vector _if surface shader does not write to o.Normal_.
* `float3 worldRefl; INTERNAL_DATA` - will contain world reflection vector _if surface shader writes to o.Normal_. To get the reflection vector based on per-pixel normal map, use `WorldReflectionVector (IN, o.Normal)`. See Reflect-Bumped shader for example.
* `float3 worldNormal; INTERNAL_DATA` - will contain world normal vector _if surface shader writes to o.Normal_. To get the normal vector based on per-pixel normal map, use `WorldNormalVector (IN, o.Normal)`.


Further Documentation
---------------------


(:tocportion:)
