Optimizing for integrated graphics cards
========================================

Polygon count matters
---------------------

On most graphics cards today, polygon count does not really matter. The common knowledge is that object count and fillrate is much more important. Unfortunately, not so on the majority of older integrated chips (Intel 945 / GMA 950 and similar). How much it matters depends on the complexity of the vertex shaders or lighting and the speed of the CPU (thats right, most integrated cards transform & light vertices on the CPU).

[Big Bang Brain Games](http://www.freeverse.com/braingames/.md) never went above 25 thousand triangles in a scene using 1-2 per-vertex lights and no pixel lights (essentially a [VertexLit rendering path](RenderTech-VertexLit.md)). Quality Settings were used to speed up performance automatically when frame rate drops. So on higher end machines a higher quality setting was used which had pixel lights enabled.

What slows things down is drawing objects multiple times, using complex vertex shaders and lots of polygons. This means:
* Use [VertexLit rendering path](RenderTech-VertexLit.md) if possible. This will draw each object just once, no matter how many lights are in the scene.
* Try not to use lights at all, even vertex lights. Lights make sense if your geometry moves, or if your lights move. Otherwise bake the illumination using [Lightmapper](Lightmapping.md), it will run faster and look better.
* Optimize your geometry (see section below).
* Use [Rendering Statistics](RenderingStatistics.md) window and [Profiler](Profiler.md)!


Optimize model geometry
-----------------------


When optimizing the geometry of a model, there are two basic rules:
* Don't use excessive amount of faces if you don't have to.
* Keep the number of UV mapping seams and hard edges as low as possible.

Note that the actual number of vertices that graphics hardware has to process is usually not the same as displayed in a 3D application. Modeling applications usually display the geometric vertex count, i.e. number of points that make up a model.

For a graphics card however, some vertices have to be split into separate ones. If a vertex has multiple normals (it's on a "hard edge"), or has multiple UV coordinates, or multiple vertex colors, it has to be split. So the vertex count you see in Unity is almost always different from the one displayed in 3D application.


Bake lighting.
--------------

Bake ligthing either into lightmaps or vertex colors. Unity has a great [Lightmapper](Lightmapping.md) built-in; also you can bake lightmaps in many 3D modeling packages.

The process of generating a lightmapped environment takes only a little longer than just placing a light in the scene in Unity, __but__:
* It usually will run a lot faster; especially if you have many lights.
* And look a lot better since you can bake global illumination.

Even next-gen games still rely on lightmapping a lot. Usually they use lightmapped environments and only use one or two realtime dynamic lights.

