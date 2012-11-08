Compute Shaders
===============


Compute Shaders are programs that run on the graphics card, outside of the normal rendering pipeline. They can be used for massively parallel GPGPU algorithms, or to accelerate parts of game rendering. In order to efficiently use them, often an in-depth knowledge of GPU architectures and parallel algorithms is needed; as well as knowledge of [DirectCompute](http://msdn.microsoft.com/en-us/library/windows/desktop/ff476331.aspx.md), [OpenCL](http://en.wikipedia.org/wiki/OpenCL.md) or [CUDA](http://en.wikipedia.org/wiki/CUDA.md).

Compute shaders in Unity are built on top of DirectX 11 DirectCompute technology; and currently require Windows Vista or later and a GPU capable of Shader Model 5.0.

Compute shader assets
---------------------


Similar to [normal shaders](Shaders.md), Compute Shaders are asset files in your project, with `*.compute` file extension. They are written in DirectX 11 style [HLSL](http://msdn.microsoft.com/en-us/library/windows/desktop/bb509561.aspx.md) language, with minimal amount of `#pragma` compilation directives to indicate which functions to compile as compute shader kernels.

Here's a minimal example of a compute shader file:
````

// test.compute
#pragma kernel FillWithRed

RWTexture2D<float4> res;

[numthreads(1,1,1)]
void FillWithRed (uint3 dtid : SV_DispatchThreadID)
{
    res[dtid.xy] = float4(1,0,0,1);
}

````
The example above does not do anything remotely interesting, just fills output texture with red color.

The language is standard DX11 HLSL, with the only exception of a `#pragma kernel FillWithRed` directive. One compute shader asset file must contain at least one "compute kernel" that can be invoked, and that function is indicated by the #pragma directive. There can be more kernels in the file; just add multiple `#pragma kernel` lines.

The `#pragma kernel` line can optionally be followed by a number of preprocessor macros to define while compiling that kernel, for example:
````

#pragma kernel KernelOne SOME_DEFINE DEFINE_WITH_VALUE=1337
#pragma kernel KernelTwo OTHER_DEFINE
// ...

````


Invoking compute shaders
------------------------


In your script, define a variable of `ComputeShader` type, assign a reference to the asset, and then you can invoke them with [ComputeShader.Dispatch](ScriptRef:ComputeShader.Dispatch.html) function. See scripting reference of [ComputeShader class](ScriptRef:ComputeShader.html) for more details.

Closely related to compute shaders is a [ComputeBuffer](ScriptRef:ComputeBuffer.html) class, which defines arbitrary data buffer ("structured buffer" in DX11 lingo). [Render Textures](ScriptRef:RenderTexture.html) can also be written into from compute shaders, if they have "random access" flag set ("unordered access view" in DX11), see [RenderTexture.enableRandomWrite](ScriptRef:RenderTexture-enableRandomWrite.html).
