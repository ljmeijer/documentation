Light
=====


<span class=keyword>Lights</span> will bring personality and flavor to your game. You use lights to illuminate the scenes and objects to create the perfect visual mood. Lights can be used to simulate the sun, burning match light, flashlights, gun-fire, or explosions, just to name a few.


![](http://docwiki.hq.unity3d.com/uploads/Main/LightInspectorV3.png)  
_The Light <span class=keyword>Inspector</span>_

There are four types of lights in Unity:
* <span class=keyword>Point lights</span> shine from a location equally in all directions, like a light bulb.
* <span class=keyword>Directional lights</span> are placed infinitely far away and affect everything in the scene, like the sun.
* <span class=keyword>Spot lights</span> shine from a point in a direction and only illuminate objects within a cone - like the headlights of a car.
* <span class=keyword>Area lights</span> (only available for lightmap baking) shine in all directions to one side of a rectangular section of a plane.

Lights can also cast <span class=keyword>Shadows</span>.  Shadows are a Pro-only feature.  Shadow properties can be adjusted on a per-light basis.

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Type</span> |The current type of light object: |
|>>><span class=component>Directional</span> |A light placed infinitely far away. It affects everything in the scene. |
|>>><span class=component>Point</span> |A light that shines equally in all directions from its location, affecting all objects within its <span class=component>Range</span>. |
|>>><span class=component>Spot</span> |A light that shines everywhere within a cone defined by <span class=component>Spot Angle</span> and <span class=component>Range</span>. Only objects within this region are affected by the light. |
|>>><span class=component>Area</span>|A light that shines in all directions to one side of a rectangular area of a plane, affecting all objects within its <span class=component>Range</span>. The rectangle is defined by the X and Y properties. Area lights are only available during lightmap baking and have no effect on objects at runtime.|
|<span class=component>Range</span> |How far light is emitted from the center of the object. <span class=component>Point</span>/<span class=component>Spot</span> light only. |
|<span class=component>Spot Angle</span> |Determines the angle of the cone in degrees. <span class=component>Spot</span> light only. |
|<span class=component>Color</span> |The color of the light emitted. |
|<span class=component>Intensity</span> |Brightness of the light. Default value for a <span class=component>Point</span>/<span class=component>Spot</span> light is 1. Default value for a <span class=component>Directional</span> light is 0.5 |
|<span class=component>Cookie</span> |The alpha channel of this texture is used as a mask that determines how bright the light is at different places. If the light is a <span class=component>Spot</span> or a <span class=component>Directional</span> light, this must be a 2D texture. If the light is a <span class=component>Point</span> light, it must be a <span class=keyword>Cubemap</span>. |
|<span class=component>Cookie Size</span> |Scales the projection of a Cookie. <span class=component>Directional</span> light only. |
|<span class=component>Shadow Type</span> (Pro only) |<span class=component>No</span>, <span class=component>Hard</span> or <span class=component>Soft</span> [shadows](Shadows.md) that will be cast by this light. Only applicable to desktop build targets. Soft shadows are more expensive. |
|>>><span class=component>Strength</span> |The darkness of the shadows.  Values are between 0 and 1. |
|>>><span class=component>Resolution</span> |Detail level of the shadows. |
|>>><span class=component>Bias</span> |Offset used when comparing the pixel position in light space with the value from the shadow map. See _Shadow Mapping and the Bias Property_ below |
|>>><span class=component>Softness</span> |Scales the penumbra region (the offset of blur samples). <span class=component>Directional</span> light only. |
|>>><span class=component>Softness Fade</span> |Shadow softness fade based on the distance from the camera. <span class=component>Directional</span> light only. |
|<span class=component>Draw Halo</span> |If checked, a spherical halo of light will be drawn with a radius equal to <span class=component>Range</span>. |
|<span class=component>Flare</span> |Optional reference to the [Flare](class-Flare.md) that will be rendered at the light's position. |
|<span class=component>Render Mode</span> |Importance of this light. This can affect lighting fidelity and performance, see _Performance Considerations_ below. Options include:
|>>><span class=component>Auto</span> |The rendering method is determined at runtime depending on the brightness of nearby lights and current [Quality Settings](class-QualitySettings.md) for desktop build target. |
|>>><span class=component>Important</span> |This light is always rendered at per-pixel quality. Use this for very important effects only (e.g. headlights of a player's car). |
|>>><span class=component>Not Important</span> |This light is always rendered in a faster, vertex/object light mode. |
|<span class=component>Culling Mask</span> |Use to selectively exclude groups of objects from being affected by the light; see [Layers](Layers.md). |
|<span class=component>Lightmapping</span> |The Lightmapping mode: <span class=component>RealtimeOnly</span>, <span class=component>Auto</span> or <span class=component>BakedOnly</span>; see the [Dual Lightmaps](LightmappingInDepth#DualLightmaps.md) description. |
|<span class=component>X</span>|(Area lights only) The width of the rectangular light area.|
|<span class=component>Y</span>|(Area lights only) The height of the rectangular light area.|

Details
-------


There are four basic light types in Unity. Each type can be customized to fit your needs.

You can create a texture that contains an alpha channel and assign it to the <span class=component>Cookie</span> variable of the light.  The Cookie will be projected from the light. The Cookie's alpha mask modulates the light amount, creating light and dark spots on surfaces. They are a great way af adding lots of complexity or atmosphere to a scene.

All [built-in shaders](Built-inShaderGuide.md) in Unity seamlessly work with any type of light. <span class=keyword>VertexLit</span> shaders cannot display Cookies or Shadows, however.

In Unity Pro with a build target of webplayer or standalone, all Lights can optionally cast [Shadows](Shadows.md).  This is done by selecting either <span class=component>Hard Shadows</span> or <span class=component>Soft Shadows</span> for the <span class=component>Shadow Type</span> property of each individual Light.  For more information about shadows, please read the [Shadows](Shadows.md) page.



###Point Lights


![](http://docwiki.hq.unity3d.com/uploads/Main/LightPoint.png)  

Point lights shine out from a point in all directions. They are the most common lights in computer games - typically used for explosions, light bulbs, etc.  They have an average cost on the graphics processor (though point light shadows are the most expensive).


![](http://docwiki.hq.unity3d.com/uploads/Main/Light-Point.png)  
_Point Light_

Point lights can have cookies - [Cubemap](class-Cubemap.md) texture with alpha channel. This Cubemap gets projected out in all directions.


![](http://docwiki.hq.unity3d.com/uploads/Main/Light-PointCookie.png)  
_Point Light with a Cookie_



###Spot Lights


![](http://docwiki.hq.unity3d.com/uploads/Main/LightSpot.png)  

Spot lights only shine in one direction, in a cone.  They are perfect for flashlights, car headlights or lamp posts.  They are the most expensive on the graphics processor.


![](http://docwiki.hq.unity3d.com/uploads/Main/Light-Spot.png)  
_Spot Light_

Spot lights can also have cookies - a texture projected down the cone of the light. This is good for creating an effect of light shining through the window. It is very important that the texture is black at the edges, has <span class=component>Border Mipmaps</span> option on and its wrapping mode is set to <span class=component>Clamp</span>. For more info on this, see [Textures](class-Texture2D.md).


![](http://docwiki.hq.unity3d.com/uploads/Main/Light-SpotCookie.png)  
_Spot Light with a Cookie_


###Directional Lights


![](http://docwiki.hq.unity3d.com/uploads/Main/LightDir.png)  

Directional lights are used mainly in outdoor scenes for sun & moonlight.  The light affect all surfaces of objects in your scene.  They are the least expensive on the graphics processor. Shadows from directional lights (for platforms that support shadows) are explained in depth on [this page](DirectionalShadowDetails.md).


![](http://docwiki.hq.unity3d.com/uploads/Main/Light-Direct.png)  
_Directional Light_

When directional light has a cookie, it is projected down the center of the light's Z axis. The size of the cookie is controlled with <span class=component>Cookie Size</span> property. Set the cookie texture's wrapping mode to <span class=component>Repeat</span> in the <span class=keyword>Inspector</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/Light-DirectCookie.png)  
_Directional Light projecting a cloud-like cookie texture_

A cookie is a great way to add some quick detail to large outdoor scenes. You can even slide the light slowly over the scene to give the impression of moving clouds.


Area Lights
-----------


Area lights cast light from one side of a rectangular area of a plane. 


![](http://docwiki.hq.unity3d.com/uploads/Main/AreaLightDiagram.png)  

Light is cast on all objects within the light's range. The size of the rectangle is determined by the X and Y properties and and the plane's normal (ie, the side to which light is cast) is the same as the light's positive Z direction. Light is emitted from the whole surface of the rectangle, so shading and shadows from affected object tend to be much softer than with point or directional light sources. 

Since the lighting calculation is quite processor-intensive, area lights are not available at runtime and can only be used as a lightmap effect.

Performance considerations
--------------------------


Lights can be rendered in one of two methods: <span class=keyword>vertex</span> lighting and <span class=keyword>pixel</span> lighting. Vertex lighting only calculates the lighting at the vertices of the game models and interpolates the lighting over the surfaces of the models. Pixel lights are calculated at every screen pixel, and hence are much more expensive.  Some older graphics cards only support vertex lighting.

While pixel lighting is slower to render, it does allow some effects that are not possible with vertex lighting. Normal-mapping, light cookies and realtime shadows are only rendered for pixel lights. Spotlight shapes and Point light highlights are much better when rendered in pixel mode as well. The three light types above would look like this when rendered in vertex light mode:


![](http://docwiki.hq.unity3d.com/uploads/Main/Light-PointVertex.png)  
_Point light in Vertex lighting mode._


![](http://docwiki.hq.unity3d.com/uploads/Main/Light-SpotVertex.png)  
_Spot light in Vertex lighting mode._


![](http://docwiki.hq.unity3d.com/uploads/Main/Light-DirectVertex.png)  
_Directional light in Vertex lighting mode._

Lights have a big impact on rendering speed - therefore a tradeoff has to be made betwen lighting quality and game speed. Since pixel lights are much more expensive than vertex lights, Unity will only render the brightest lights at per-pixel quality.  The actual number of pixel lights can be set in the [Quality Settings](class-QualitySettings.md) for webplayer and standalone build targets. 

You can explicitly control if a light should be rendered as a vertex or pixel light using the <span class=component>Render Mode</span> property. By default Unity will classify the light automatically based on how much the object is affected by the light.

The actual lights that are rendered as pixel lights are determined on an object-by-object case. This means:

* Huge objects with bright lights could use all the pixel lights (depending on the quality settings). If the player is far from these, nearby lights will be rendered as vertex lights.  Therefore, it is better to split huge objects up in a couple of small ones.

See Optimizing Graphics performance on [Desktop](OptimizingGraphicsPerformance#DesktopOptimizingGraphicsPerformance.md), [iOS](OptimizingGraphicsPerformance#iPhoneOptimizingGraphicsPerformance.md) or [Android](OptimizingGraphicsPerformance#AndroidOptimizingGraphicsPerformance.md) page for more information.


Creating Cookies
----------------


For more information on creating cookies, please see the [tutorial on how to create a Spot light cookie](HOWTO-LightCookie.md).


Shadow Mapping and the Bias Property
------------------------------------


Shadows are implemented using a technique known as shadow mapping. This is analogous to the depth mapping used by a camera to determine which surfaces are obscured by others. The scene is internally rendered by a camera at the position of the light to create a depth map which stores the distance to each surface illuminated by the light. This kind of depth map is referred to as a shadow map, for obvious reasons. When the scene is rendered to the main view camera, each pixel position in the view is transformed into the light's space so that its distance can be compared to the corresponding pixel in the shadow map. If the pixel is more distant than the shadow map pixel then it is presumably obscured from the light by another object and so it will get no illumination.


![](http://docwiki.hq.unity3d.com/uploads/Main/GoodShadowBias.png)  
_Cylinder with correct shadowing_

A surface directly illuminated by a light can sometimes appear to be partly in shadow. This is because pixels that should be exactly at the distance specified in the shadow map will sometimes be deemed farther away (a consequence of using a low resolution image for the map). The result is arbitrary patterns of pixels in shadow when they should really be lit, giving a visual effect known as "shadow acne".


![](http://docwiki.hq.unity3d.com/uploads/Main/ShadowAcne.png)  
_Shadow acne in the form of small dots on the cylinder_

To prevent shadow acne, a bias value can be added to the distance in the shadow map to ensure that pixels on the borderline will definitely pass the comparison as they should. This is the value set by the Bias property associated with a light when it has shadows enabled. It is a mistake to set the bias too high, however, since areas of a shadow near to the object casting it can then sometimes be falsely illuminated. This effect is known as "Peter Panning" (ie, the disconnected shadow makes the object look as if it is flying some way above the ground like Peter Pan).


![](http://docwiki.hq.unity3d.com/uploads/Main/PeterPanning.png)  
_Peter Panning makes the object look raised above the ground_

The bias value for a light may need a bit of tweaking to make sure that neither shadow acne nor Peter Panning occur. It is generally easier to gauge the right value by eye rather than attempt to calculate it.


Hints
-----


* Spot lights with cookies can be extremely effective for making light coming in from windows.
* Low-intensity point lights are good for providing depth to a scene.
* For maximum performance, use a [VertexLit](Built-inShaderGuide.md) shader. This shader only does per-vertex lighting, giving a much higher throughput on low-end cards.
* Auto lights can cast dynamic shadows over lightmapped objects without adding extra illumination. For this to work the Auto lights must be active when the Lightmap is baked. Otherwise they render as real time lights.
