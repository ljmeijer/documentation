GLSL Shader Programs
====================


In addition to using [Cg/HSL shader programs](SL-ShaderPrograms.md), OpenGL Shading Language (GLSL) shaders can be written directly.

However, _'use of raw GLSL is only recommended for testing_', or when you know you will only target Mac OS X or OpenGL ES 2.0 compatible mobile devices. In majority of normal cases, Unity will cross-compile Cg/HLSL into optimized GLSL (this is done by default for mobile platforms, and can be optionally turned on for desktop platforms via `#pragma glsl`).

GLSL snippets
-------------


GLSL program snippets are written between <span class=component>GLSLPROGRAM</span> and <span class=component>ENDGLSL</span> keywords.

In GLSL, all shader function entry points have to be called <span class=component>main()</span>. When Unity loads the GLSL shader, it loads the source once for the vertex program, with <span class=component>VERTEX</span> preprocessor define, and once more for the fragment program, with <span class=component>FRAGMENT</span> preprocessor define. So the way to separate vertex and fragment program parts in GLSL snippet is to surround them with <span class=component>#ifdef VERTEX</span> .. <span class=component>#endif</span> and <span class=component>#ifdef FRAGMENT</span> .. <span class=component>#endif</span>. Each GLSL snippet must contain both a vertex program and a fragment program.

Standard include files match those provided for Cg shaders; they just have <span class=component>.glslinc</span> extension: <span class=component>UnityCG.glslinc</span>.

Vertex shader inputs come from predefined GLSL variables (gl_Vertex, gl_MultiTexCoord0, ...) or are user defined attributes. Usually only the tangent vector needs a user defined attribute:
    attribute vec4 Tangent;

Data from vertex to fragment programs is passed through _varying_ variables, for example:
    varying vec3 lightDir; // vertex shader computes this, fragment shader uses this

