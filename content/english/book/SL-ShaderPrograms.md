Writing vertex and fragment shaders
===================================


<span class=keyword>ShaderLab</span> shaders encompass more than just "hardware shaders". They do many things. They describe properties that are displayed in the Material Inspector, contain multiple shader implementations for different graphics hardware, configure fixed function hardware state and so on. The actual programmable shaders - like vertex and fragment programs - are just a part of the whole ShaderLab's "shader" concept. Take a look at [shader tutorial](ShaderTut2.md) for a basic introduction. Here we'll call the low-level hardware shaders <span class=keyword>shader programs</span>.

__If you want to write shaders that interact with lighting, take a look at [Surface Shaders](SL-SurfaceShaders.md) documentation__. The rest of this page will assume shaders that do not interact with Unity lights (e.g. special effects, [Image Effects](comp-ImageEffects.md) etc.)

Shader programs are written in Cg / HLSL language, by embedding "snippets" in the shader text, somewhere inside the [Pass](SL-Pass.md) command. They usually look like this:

  Pass {
      _// ... the usual pass state setup ..._
      
      __CGPROGRAM__
      _// compilation directives for this snippet, e.g.:_
      __#pragma vertex__ vert
      __#pragma fragment__ frag
      
      _// the Cg code itself_
      
      __ENDCG__
      _// ... the rest of pass setup ..._
  }


Cg snippets
-----------


Cg program snippets are written between <span class=component>CGPROGRAM</span> and <span class=component>ENDCG</span>.

At the start of the snippet compilation directives can be given as <span class=component>#pragma</span> statements. Directives indicating which shader functions to compile:
* <span class=component>#pragma vertex _name_</span> - compile function _name_ as the vertex shader.
* <span class=component>#pragma fragment _name_</span> - compile function _name_ as the fragment shader.

###u40 Details
* <span class=component>#pragma geometry _name_</span> - compile function _name_ as DX10 geometry shader. Having this option automatically turns on <span class=component>#pragma target 4.0</span>, see [below](#target).
* <span class=component>#pragma hull _name_</span> - compile function _name_ as DX11 hull shader. Having this option automatically turns on <span class=component>#pragma target 5.0</span>, see [below](#target).
* <span class=component>#pragma domain _name_</span> - compile function _name_ as DX11 domain shader. Having this option automatically turns on <span class=component>#pragma target 5.0</span>, see [below](#target).

Other compilation directives:
* <span class=component>#pragma target _name_</span> - which shader target to compile to. See [shader targets](#target) for details.
* <span class=component>#pragma only_renderers _space separated names_</span> - compile shader only for given renderers. By default shaders are compiled for all renderers. See [renderers](#renderers) for details.
* <span class=component>#pragma exclude_renderers _space separated names_</span> - do not compile shader for given renderers. By default shaders are compiled for all renderers. See [renderers](#renderers) for details.
* <span class=component>#pragma glsl</span> - when compiling shaders for desktop OpenGL platforms, convert Cg/HLSL into GLSL (instead of default setting which is ARB vertex/fragment programs). Use this to enable derivative instructions, texture sampling with explicit LOD levels, etc.
* <span class=component>#pragma glsl_no_auto_normalization</span> - when compiling shaders for mobile GLSL (iOS/Android), turn off automatic normalization of normal & tangent vectors. By default, normals and tangents are normalized in the vertex shader on iOS/Android platforms.
* <span class=component>#pragma fragmentoption _option_</span> - adds _option_ to the compiled OpenGL fragment program. See the [ARB fragment program](http://www.opengl.org/registry/specs/ARB/fragment_program.txt.md) specification for a list of allowed options. This directive has no effect on vertex programs or programs that are compiled to non-OpenGL targets.

Each snippet must contain a vertex program, a fragment program, or both. Thus a <span class=component>#pragma vertex</span> or <span class=component>#pragma fragment</span> directive is required, or both.

<a id="target"></a>
Shader targets
--------------


By default, Unity compiles shaders into roughly shader model 2.0 equivalent. Using <span class=component>#pragma target</span> allows shaders to be compiled into other capability levels. Currently these targets are supported:
* <span class=component>#pragma target 2.0</span> _(default)_ - roughly shader model 2.0
    * Shader Model 2.0 on Direct3D 9.
    * [ARB_vertex_program](http://www.opengl.org/registry/specs/ARB/vertex_program.txt.md) with 256 instruction limit and [ARB_fragment_program](http://www.opengl.org/registry/specs/ARB/fragment_program.txt.md) with 96 instruction limit (32 texture + 64 arithmetic), 16 temporary registers and 4 texture indirections.
* <span class=component>#pragma target 3.0</span> - compile to shader model 3.0:
    * Shader Model 3.0 on Direct3D 9.
    * ARB_vertex_program with no instruction limit and ARB_fragment_program with 1024 instruction limit (512 texture + 512 arithmetic), 32 temporary registers and 4 texture indirections. It is possible to override these limits using <span class=component>#pragma profileoption</span> directive. E.g. `#pragma profileoption MaxTexIndirections=256` raises texture indirections limit to 256. Note that some shader model 3.0 features, like derivative instructions, aren't supported by ARB_vertex_program/ARB_fragment_program. You can use <span class=component>#pragma glsl</span> to translate to GLSL instead which has fewer restrictions.
  When compiling to 3.0 or larger target, both vertex and fragment programs need to be present.

###u40 Details
* <span class=component>#pragma target 4.0</span> - compile to DX10 shader model 4.0. This target is currently only supported by DirectX 11 renderer.
* <span class=component>#pragma target 5.0</span> - compile to DX11 shader model 5.0. This target is currently only supported by DirectX 11 renderer.


<a id="renderers"></a>
Rendering platforms
-------------------


Unity supports several rendering APIs (e.g. Direct3D 9 and OpenGL), and by default all shader programs are compiled into for supported renderers. You can indicate which renderers to compile to using <span class=component>#pragma only_renderers</span> or <span class=component>#pragma exclude_renderers</span> directives. This is useful if you know you will only target Mac OS X (where there's no Direct3D), or only Windows (where Unity defaults to D3D), or if some particular shader is only possible in one renderer and not others. Currently supported renderer names are:
* <span class=component>d3d9</span> - Direct3D 9.
* <span class=component>d3d11</span> - Direct3D 11.
* <span class=component>opengl</span> - OpenGL.
* <span class=component>gles</span> - OpenGL ES 2.0.
* <span class=component>xbox360</span> - Xbox 360.
* <span class=component>ps3</span> - PlayStation 3.
* <span class=component>flash</span> - Flash.

For example, this line would only compile shader into D3D9 mode:
  #pragma only_renderers d3d9


Subsections
-----------


(:tocportion:)
