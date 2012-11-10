Shadow Size Computation
=======================



##u30 Details
__Note on Mobile platforms__: realtime shadows are not supported on iOS & Android.


Unity computes [shadow map](Shadows.md) sizes this way:

First light's "coverage box" on the screen is computed. This is what rectangle on the screen the light possibly illuminates:
* For Directional lights that is the whole screen.
* For Spot lights it's the bounding rectangle of light's pyramid projected on the screen.
* For Point lights it's the bounding rectangle of light's sphere projected on the screen.
Then the larger value of this box' width & height is chosen; call that `pixel size`.

At "High" shadow resolution, the size of the shadow map then is:
* Directional lights: `NextPowerOfTwo( pixel size * 1.9 )`, but no more than `2048`.
* Spot lights: `NextPowerOfTwo( pixel size )`, but no more than `1024`.
* Point lights: `NextPowerOfTwo( pixel size * 0.5 )`, but no more than `512`.

When graphics card has 512MB or more video memory, the upper shadow map limits are increased (4096 for Directional, 2048 for Spot, 1024 for Point lights).

At "Medium" shadow resolution, shadow map size is 2X smaller than at "High" resolution. And at "Low" resolution, it's 4X smaller than at "High" resolution.

The seemingly low limit on Point lights is because they use cubemaps for shadows. That means six cubemap faces at this resolution must be in video memory. They are also quite expensive to render, as potential shadow casters must be rendered into up to six cubemap faces. 


Shadow size computation when running close to memory limits
-----------------------------------------------------------


When running close to video memory limits, Unity will automatically drop shadow map resolution computed above.

Generally memory for the screen (backbuffer, frontbuffer, depth buffer) has to be in video memory; and memory for render textures has to be in video memory, Unity will use both to determine allowed memory usage of shadow maps. When allocating a shadow map according to size computed above, it's size will be reduced until it fits into `(TotalVideoMemory - ScreenMemory - RenderTextureMemory) / 3`.

Assuming all regular textures, vertex data and other graphics objects can be swapped out of video memory, maximum VRAM that could be used by a shadow map would be `(TotalVideoMemory-ScreenMemory-RenderTextureMemory)`. But exact amounts of memory taken by screen and render textures can never be determined, and some objects can not be swapped out, and performance would be horrible if all textures would be constantly swapping in and out. So Unity does not allow a shadow map to exceed one third of "generally available" video memory, which works quite well in practice.

