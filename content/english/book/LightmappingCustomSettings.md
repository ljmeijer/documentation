Custom Beast Settings
=====================


If you need a different baking setup than the one Unity is using by default, you can specify it by using custom Beast settings.

Beast reads bake settings defined in XML format. Normally Unity generates the XML file based on the configuration you have chosen in Bake pane of the Lightmap Editor window and a number of other internal settings. You can override those settings by specifying your own settings in Beast's XML format.

To have Unity automatically generate the XML file for you, click the tab menu in the upper-right corner of the Lightmap Editor window and select _Generate Beast settings file_. You will notice that the BeastSettings.xml file appeared in the project next to your lightmaps and that the Lightmap Editor informs you, that your XML settings will override Unity's settings during the next bake. Click the _open_ button to edit your custom settings.


![](http://docwiki.hq.unity3d.com/uploads/Main/XMLSettings40.png)  

A sample Beast configuration file is given below:-

````
<?xml version="1.0" encoding="ISO-8859-1"?>
<ILConfig>
  <AASettings>
    <samplingMode>Adaptive</samplingMode>
    <clamp>false</clamp>
    <contrast>0.1</contrast>
    <diagnose>false</diagnose>
    <minSampleRate>0</minSampleRate>
    <maxSampleRate>2</maxSampleRate>
    <filter>Gauss</filter>
    <filterSize>
      <x>2.2</x>
      <y>2.2</y>
    </filterSize>
  </AASettings>
  <RenderSettings>
    <bias>0</bias>
    <maxShadowRays>10000</maxShadowRays>
    <maxRayDepth>6</maxRayDepth>
  </RenderSettings>
  <EnvironmentSettings>
    <giEnvironment>SkyLight</giEnvironment>
    <skyLightColor>
      <r>0.86</r>
      <g>0.93</g>
      <b>1</b>
      <a>1</a>
    </skyLightColor>
    <giEnvironmentIntensity>0</giEnvironmentIntensity>
  </EnvironmentSettings>
  <FrameSettings>
    <inputGamma>1</inputGamma>
  </FrameSettings>
  <GISettings>
    <enableGI>true</enableGI>
    <fgPreview>false</fgPreview>
    <fgRays>1000</fgRays>
    <fgContrastThreshold>0.05</fgContrastThreshold>
    <fgGradientThreshold>0</fgGradientThreshold>
    <fgCheckVisibility>true</fgCheckVisibility>
    <fgInterpolationPoints>15</fgInterpolationPoints>
    <fgDepth>1</fgDepth>
    <primaryIntegrator>FinalGather</primaryIntegrator>
    <primaryIntensity>1</primaryIntensity>
    <primarySaturation>1</primarySaturation>
    <secondaryIntegrator>None</secondaryIntegrator>
    <secondaryIntensity>1</secondaryIntensity>
    <secondarySaturation>1</secondarySaturation>
    <fgAOInfluence>0</fgAOInfluence>
    <fgAOMaxDistance>0.223798</fgAOMaxDistance>
    <fgAOContrast>1</fgAOContrast>
    <fgAOScale>2.0525</fgAOScale>
  </GISettings>
  <SurfaceTransferSettings>
    <frontRange>0.0</frontRange>
    <frontBias>0.0</frontBias>
    <backRange>2.0</backRange>
    <backBias>-1.0</backBias>
    <selectionMode>Normal</selectionMode>
  </SurfaceTransferSettings>
  <TextureBakeSettings>
    <bgColor>
      <r>1</r>
      <g>1</g>
      <b>1</b>
      <a>1</a>
    </bgColor>
    <bilinearFilter>true</bilinearFilter>
    <conservativeRasterization>true</conservativeRasterization>
    <edgeDilation>3</edgeDilation>
  </TextureBakeSettings>
</ILConfig>

````

The toplevel XML elements are described in the sections below along with their subelements.

Adaptive Sampling (_<AASettings>_ element)
------------------------------------------


Beast uses an adaptive sampling scheme when sampling light maps. The light must differ more than a user set contrast threshold for Beast to place additional samples in an area. The sample area is defined by a Min and Max sample rate. The user sets the rate in the -4..4 range which means that Beast samples from 1/256 sample per pixel to 256 samples per pixel (the formula is: 4 to the power of samplerate). It is recommended to use at least one sample per pixel for production use (Min sample rate = 0). Undersampling is most useful when doing camera renders or baking textures with big UV-patches. When Beast has taken all necessary samples for an area, the final pixel value is weighed together using a filter. The look the filter produces is dependent on the filter type used and the size of the filter kernel. The available filters are:

* Box: Each sample is treated as equally important. The fastest filter to execute but it gives blurry results.
* Triangle: The filter kernel is a tent which means that distant samples are consideredless important.
* Gauss: Uses the Gauss function as filter kernel. This gives the best results (removes noise, preserves details).

There are more filters available, but these three are the most useful. The kernel (filter) size is given in pixels in the range 1..3. Beast actually uses all sub pixels when filtering, which yields better results than doing it afterwards in Photoshop.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>AASettings</span>||
|>>><span class=component>samplingMode</span>|The sampling strategy to use. Default is Adaptive. Adaptive: Adaptive anti-aliasing scheme for under/over sampling (from 1/256 up to 256 samples per pixel). SuperSampling: Anti-aliasing scheme for super sampling (from 1 up to 128 samples per pixel).|
|>>><span class=component>minSampleRate</span>|Sets the min sample rate, default is 0 (ie one sample per pixel).|
|>>><span class=component>maxSampleRate</span>|Sets the max sample rate, the formula used is 4^maxSampleRate (1, 4, 16, 64, 256 samples per pixel)|
|>>><span class=component>contrast</span>|The contrast value which controls if more samples are necessary - a lower value forces more samples.|
|>>><span class=component>filter</span>|Sets which filter type to use. Most useful ones for Baking are Box, Triangle and Gauss.|
|>>><span class=component>filterSize</span>|Sets the filter size in pixels, from 1 to 3.|
|>>><span class=component>diagnose</span>|Enable to diagnose the sampling. The brighter a pixel is, the more samples were taken at that position.|

Texture Bake (_<TextureBakeSettings>_ element)
----------------------------------------------


These settings help getting rid of any artifacts that are purely related to how lightmaps are rasterized and read from a texture.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>TextureBakeSettings</span>||
|>>><span class=component>edgeDilation</span>|Expands the rendered region with the number of pixels specified. This is needed to prevent the artifacts occurring when GPU filters in empty pixels from around the rendered region. Should be set to 0 though, since a better algorithm is part of the import pipeline.|
|>>><span class=component>bilinearFilter</span>|Is used to make sure that the data in the lightmap is "correct" when the GPU applies bilinear filtering. This is most noticable when the atlases are tightly packed. If there is only one pixel between two different UV patches, the bilinear functionality in Beast will make sure the that pixel is filled with the color from the correct patch. This minimizes light seams.|
|>>><span class=component>conservativeRasterization</span>|Is used when the UV-chart does not cover the entire pixel. If such a layout is used, Beast may miss the texel by mistake. If conservative rasterization is used Beast will guarantee that it will find a UV-layout if present. Note that Beast will pick any UV-layout in the pixel. Conservative Rasterization often needs to be turned on if the UV atlases are tightly packed in low resolutions or if there are very thin objects present.|
|>>><span class=component>bgColor</span>|The background color of the lightmap. Should be set to white (1,1,1,1).|

Environment (_<EnvironmentSettings>_ element)
---------------------------------------------


The environment settings in Beast control what happens if a ray misses all geometry in the scene. The environment can either be a constant color or an HDR image in lat-long format for Image Based Lighting (IBL). Note that environments should only be used for effects that can be considered to be infinitely far away, meaning that only the directional component matters.

Defining an environment is usually a very good way to get very pleasing outdoor illumination results, but might also increase bake times.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>EnvironmentSettings</span>||
|>>><span class=component>giEnvironment</span>|The type of Environment: None, Skylight or IBL.|
|>>><span class=component>giEnvironmentIntensity</span>|A scale factor for the intensity, used for avoiding gamma correction errors and to scale HDR textures to something that fits your scene. (in Unity: _Sky Light Intensity_)|
|>>><span class=component>skyLightColor</span>|A constant environment color. Used if type is Skylight. It is often a good idea to keep the color below 1.0 in intensity to avoid boosting by gamma correction. Boost the intensity instead with the giEnvironmentIntensity setting. (in Unity: _Sky Light Color_)|
|>>><span class=component>iblImageFile</span>|High-dynamic range IBL background image in Long-Lat format, .HDR or .EXR, absolute path.|

Render Settings/Shadows (_<RenderSettings>_ element)
----------------------------------------------------


Settings for ray-traced shadows.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>RenderSettings</span>||
|>>><span class=component>bias</span>|An error threshold to avoid double intersections of shadow rays. For example, a shadow ray should not intersect the same triangle as the primary ray did, but because of limited numerical precision this can happen. The bias value moves the intersection point to eliminate this problem. If set to zero this value is computed automatically depending on the scene size.|
|>>><span class=component>maxShadowRays</span>|The maximum number of shadow rays per point that will be used to generate a soft shadow for any light source. Use this to shorten render times at the price of soft shadow quality. This will lower the maximum number of rays sent for any light sources that have a shadowSamples setting higher than this value, but will not raise the number if shadowSamples is set to a lower value.|
|>>><span class=component>maxRayDepth</span>|The maximum amount of bounces a ray can have before being considered done. A bounce can be a reflection or a refraction. Increase the value if a ray goes through many transparent triangles before hitting an opaque object and you get light in areas that should be in the shadow. Common failure case: trees with alpha-tested leaves placed in a shadow of a mountain.|
|>>><span class=component>giTransparencyDepth</span>|Maximum transparency depth for global illumination rays, i.e. the number of transparent surfaces the ray can go through, before you can assume it has been absorbed. Lower values speed up rendering, in scenes with, e.g. dense foliage, but may cause overlapping transparent objects to cast too much shadow. The default is 2.|


Global Illumination (_<GISettings>_ element)
--------------------------------------------


The Global Illumination system allows you to use two separate algorithms to calculate indirect lighting. You can for instance calculate multiple levels of light bounces with a fast algorithm like the Path Tracer, and still calculate the final bounce with Final Gather to get a fast high-quality global illumination render. Both subsystems have individual control of Intensity and Saturation to boost the effects if necessary.

It's recommended to use FinalGather as the primary integrator and either None or PathTracer as the secondary integrator. Unity uses the first option (so final gather only) as the default, since it produces the best quality renders in most cases. Path Tracer should be used if many indirect bounces are needed and Final Gather-only solution with acceptable quality would take to much time to render.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>GISettings</span>||
|>>><span class=component>enableGI</span>|Setting to true enables Global Illumination.|
|>>><span class=component>primaryIntegrator</span>|The integrator used for the final calculations of indirect light. FinalGather is default.|
|>>><span class=component>secondaryIntegrator</span>|The integrator used for initial bounces of indirect light. Default is None, PathTracer is optional.|
|>>><span class=component>primaryIntensity</span>|As a post process, converts the color of the primary integrator result from RGB to HSV and scales the V value. (in Unity: _Bounce Intensity_)|
|>>><span class=component>primarySaturation</span>|As a post process, converts the color of the primary integrator result from RGB to HSV and scales the S value.|
|>>><span class=component>secondaryIntensity</span>|As a post process, converts the color of the secondary integrator result from RGB to HSV and scales the V value.|
|>>><span class=component>secondarySaturation</span>|As a post process, converts the color of the secondary integrator result from RGB to HSV and scales the S value.|
|>>><span class=component>diffuseBoost</span>|This setting can be used to exaggerate light bouncing in dark scenes. Setting it to a value larger than 1 will push the diffuse color of materials towards 1 for GI computations. The typical use case is scenes authored with dark materials, this happens easily when doing only direct lighting since it is easy to compensate dark materials with strong light sources. Indirect light will be very subtle in these scenes since the bounced light will fade out quickly. Setting a diffuse boost will compensate for this. Note that values between 0 and 1 will decrease the diffuse setting in a similar way making light bounce less than the materials says, values below 0 is invalid. The actual computation taking place is a per component pow(colorComponent, (1.0 / diffuseBoost)). (in Unity: _Bounce Boost_)|
|>>><span class=component>fgPreview</span>|Enable for a quick preview of the final image lighting.|

###Final Gather

The settings below control the quality or correctness of the Final Gather solution. The normal usage scenario is this:

1. For each baking set up Contrast Threshold and Number of Rays may be adjusted. There are no perfect settings for these since they depend on the complexity of the geometry and light setup.
1. Check Visibility and Light Leakage reduction are expensive operations and should only be used to remedy actual light leakage problems. These settings will only help if the light leakage is caused by the Global Illumination calculations. A very common light leakage situation occurs with a wall as a single plane with no thickness. The light leaking through in that situation does not come from GI.
1. Gradient threshold should only be changed if there are white halos around corners.

Steps 2 and 3 should not need much tweaking in most scenes.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>GISettings</span>||
|>>><span class=component>fgContrastThreshold</span>|Controls how sensitive the final gather should be for contrast differences between the points during precalculation. If the contrast difference is above this threshold for neighbouring points, more points will be created in that area. This tells the algorithmto place points where they are really needed, e.g. at shadow boundaries or in areas where the indirect light changes quickly. Hence this threshold controls the number of points created in the scene adaptively. Note that if a low number of final gather rays are used, the points will have high variance and hence a high contrast difference. In that the case contrast threshold needs to be raised to prevent points from clumping together or using more rays per sample. (in Unity: _Contrast Threshold_)|
|>>><span class=component>fgRays</span>|The maximum number of rays taken in each Final Gather sample. More rays gives better results but take longer to evaluate. (in Unity: _Final Gather Rays_)|
|>>><span class=component>fgCheckVisibility</span>|Turn this on to reduce light leakage through walls. When points are collected to interpolate between, some of them can be located on the other side of geometry. As a result light will bleed through the geometry. To prevent this Beast can reject points that are not visible.|
|>>><span class=component>fgCheckVisibilityDepth</span>|Controls for how many bounces the visibility checks should be performed. Adjust this only if experiencing light leakage when using multi bounce Final Gather.|
|>>><span class=component>fgLightLeakReduction</span>|This setting can be used to reduce light leakage through walls when using final gather as primary GI and path tracing as secondary GI. Leakage, which can happen when e.g. the path tracer filters in values on the other side of a wall, is reduced by using final gather as a secondary GI fallback when sampling close to walls or corners. When this is enabled a final gather depth of 3 will be used automatically, but the higher depths will only be used close to walls or corners. Note that this is only usable when path tracing is used as secondary GI.|
|>>><span class=component>fgLightLeakRadius</span>|Controls how far away from walls the final gather will be called again, instead of the secondary GI. If 0.0 is used Beast will try to estimate a good value. If this does not eliminate the leakage it can be set to a higher value manually.|
|>>><span class=component>fgGradientThreshold</span>|Controls how the irradiance gradient is used in the interpolation. Each point stores its irradiance gradient which can be used to improve the interpolation. In some situations using the gradient can result in white "halos" and other artifacts. This threshold can be used to reduce those artifacts (set it low or to 0). (in Unity: _Interpolation_)|
|>>><span class=component>fgInterpolationPoints</span>|Sets the number of final gather points to interpolate between. A higher value will give a smoother result, but can also smooth out details. If light leakage is introduced through walls when this value is increased, checking the sample visibility solves that problem. (in Unity: _Interpolation Points_)|
|>>><span class=component>fgNormalThreshold</span>|Controls how sensitive the final gather should be for differences in the points normals. A lower value will give more points in areas of high curvature.|
|>>><span class=component>fgDepth</span>|Controls the number of indirect light bounces. A higher value gives a more correct result, but the cost is increased rendering time. For cheaper multi bounce GI, use Path Tracer as the secondary integrator instead of increasing depth. (in Unity: _Bounces_)|
|>>><span class=component>fgAttenuationStart</span>|The distance where attenuation is started. There is no attenuation before this distance. This can be used to add a falloff effect to the final gather lighting. When fgAttenuationStop is set higher than 0.0 this is enabled.|
|>>><span class=component>fgAttenuationStop</span>|Sets the distance where attenuation is stopped (fades to zero). There is zero intensity beyond this distance. To enable attenuation set this value higher than 0.0. The default value is 0.0.|
|>>><span class=component>fgFalloffExponent</span>|This can be used to adjust the rate by which lighting falls off by distance. A higher exponent gives a faster falloff.|
|>>><span class=component>fgAOInfluence</span>|Blend the Final Gather with Ambient Occlusion. Range between 0..1. 0 means no occlusion, 1 is full occlusion. If Final Gather is used with multiple depths or with Path Tracing as Secondary GI the result can become a bit "flat". A great way to get more contrast into the lighting is to factor in a bit of ambient occlusion into the calculation. This Ambient Occlusion algorithm affects only final gather calculations. The Ambient Occlusion exposed in the Lightmapping window is calculated differently - by a separate, geometry-only pass.|
|>>><span class=component>fgAOMaxDistance</span>|Max distance for the occlusion rays. Beyond this distance a ray is considered to be unoccluded. Can be used to avoid full occlusion for closed scenes such as rooms or to limit the AO contribution to creases.|
|>>><span class=component>fgAOContrast</span>|Can be used to adjust the contrast for ambient occlusion.|
|>>><span class=component>fgAOScale</span>|A scaling of the occlusion values. Can be used to increase or decrease the shadowing effect.|

###Path Tracer

Use path tracing to get fast multi bounce global illumination. It should not be used as primary integrator for baking since the results are quite noisy which does not look good in light maps. It can be used as primary integrator to adjust the settings, to make sure the cache spacing and accuracy is good. The intended usage is to have it set as secondary integrator and have single bounce final gather as primary integrator. Accuracy and Point Size can be adjusted to make sure that the cache is sufficiently fine grained.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>GISettings</span>||
|>>><span class=component>ptAccuracy</span>|Sets the number of paths that are traced for each sample element (pixel, texel or vertex). For preview renderings, a low value like 0.5 to 0.1 can be used. This means that 1/2 to 1/10 of the pixels will generate a path. For production renderings values above 1.0 may be used, if necessary to get good quality.|
|>>><span class=component>ptPointSize</span>|Sets the maximum distance between the points in the path tracer cache. If set to 0 a value will be calculated automatically based on the size of the scene. The automatic value will be printed out during rendering, which is a good starting value if the point size needs to be adjusted.|
|>>><span class=component>ptCacheDirectLight</span>|When this is enabled the path tracer will also cache direct lighting from light sources. This increases performance since fewer direct light calculations are needed. It gives an approximate result, and hence can affect the quality of the lighting. For instance indirect light bounces from specular highlights might be lost.|
|>>><span class=component>ptCheckVisibility</span>|Turn this on to reduce light leakage through walls. When points are collected to interpolate between, some of them can be located on the other side of geometry. As a result light will bleed through the geometry. To prevent this Beast can reject points that are not visible. Note: If using this turn off light leakage reduction for Final Gather.|

Frame Settings (_<FrameSettings>_ element)
------------------------------------------


Allow to control the amount of threads Beast uses and also the gamma correction of the input and output.


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>FrameSettings</span>||
|>>><span class=component>inputGamma</span>|Keep at 1, as this setting is set appropriately per texture.|

Surface Transfer (_<SurfaceTransferSettings>_ element)
------------------------------------------------------


SurfaceTransferSettings are used to allow for transferring the lighting from LOD0 (the level of detail that is shown when the camera is close to an object) to LOD's with lower fidelity. Keep the settings at their defaults.
