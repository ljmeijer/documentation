Troubleshooting Shadows
=======================


This page lists solutions to common [shadow](Shadows.md) problems.


* Shadows are a <span class=keyword>Unity Pro</span> only feature, so without Unity Pro you won't get shadows. Simpler shadow methods, like using a [Projector](class-Projector.md), are still possible of course.
* Shadows also require certain graphics hardware support. See [Shadows](Shadows.md) page for details.
* Check if shadows are not completely disabled in [Quality Settings](class-QualitySettings.md).

##u30 Details
* __Shadows are currently not supported for iOS and Android mobile platforms.__

###Some of my objects do not cast or receive shadows

First, the [Renderer](class-MeshRenderer.md) has to have <span class=component>Receive Shadows</span> on to have shadows on itself; and <span class=component>Cast Shadows</span> on to cast shadows on other objects (both are on by default).

Next, only opaque objects cast and receive shadows; that means if you use built-in [Transparent](shader-TransparentFamily.md) or Particle shaders then you'll get no shadows. In most cases it's possible to [Transparent Cutout](shader-TransparentCutoutFamily.md) shaders (for objects like fences, vegetation etc.). If you use custom written [Geometry render queue](Shaders]],theyhavetobepixel-litanduse[[SL-SubshaderTags.md). Objects using <span class=component>VertexLit</span> shaders do not receive shadows either (but can cast shadows just fine).

Finally, in [Forward rendering path](RenderTech-ForwardRendering.md), only the brightest directional light can cast shadows. If you want to have many shadow casting lights, you need to use [Deferred Lighting](RenderTech-DeferredLighting.md) rendering path.

