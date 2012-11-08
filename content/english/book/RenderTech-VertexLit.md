Vertex Lit Rendering Path Details
=================================


This page describes details of <span class=keyword>Vertex Lit</span> [rendering path](RenderingPaths.md).

Vertex Lit path generally renders each object in one pass, with lighting from all lights calculated at object vertices.

It's the fastest rendering path and has widest hardware support (however, keep in mind: it does not work on consoles).

Since all lighting is calculated at vertex level, this rendering path does not support most of per-pixel effects: shadows, normal mapping, light cookies, highly detailed specular highlights are not supported.
