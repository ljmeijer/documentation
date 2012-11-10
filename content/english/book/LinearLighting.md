Linear Lighting (Pro Only)
==========================

overview
--------

Linear lighting refers to the process of illuminating a scene with all inputs being linear. Normally textures exist with gamma pre-applied to them this means that when the textures are sampled in a material that they are non linear. If these textures are used in the standard lighting equations it will lead to the result from the equation being incorrect as they expect all input to be linearized before use.

Linear lighting refers to the process of ensuring that both inputs and outputs of a shader are in the correct color space, this results in more correct lighting.

Existing (Gamma) Pipeline
-------------------------

In the existing rendering pipeline all colors and textures are sampled in gamma space, that is gamma correction is not removed from images or colors before they are used in a shader. Due to this a situation arises where the inputs to the shader are in gamma space, the lighting equation uses these inputs as if they were in linear space and finally no gamma correction is applied to the final pixel. Much of the time this looks acceptable as the two wrongs go some way to cancelling each other out. But it is not correct.

Linear Lighting Pipeline
------------------------

If linear lighting is enabled inputs to the shader program are supplied with the gamma correction removed from them. For colors this conversion is applied implicitly if you are in linear space. Textures are sampled using hardware sRGB reads, the source texture is supplied in gamma space and then on sampling in the graphics hardware the result is converted automatically. These inputs are then supplied to the shader and lighting occurs as it normally would. The resultant value is then written to the framebuffer. This value will either be gamma corrected and written to the framebuffer, of left in linear space for later gamma correction; this depends on the current rendering configuration.

Differences Between Linear and Gamma Lighting
---------------------------------------------

When using linear lighting input values to the lighting equations are different than in gamma space. This means that as lights striking surfaces will have a different response curve to what the existing Unity rendering pipeline has.

###Light Falloff
The falloff from distance and normal based lighting is changed in two ways. Firstly when rendering in linear mode the additional gamma correct that is performed will make light radius' appear larger. Secondly lighting edges will also be harsher. This more correctly models lighting intensity falloff on surfaces.

![](http://docwiki.hq.unity3d.com/uploads/Main/lightfalloff.png)  

###Linear Intensity Response
When you are using gamma space lighting the colors and textures that are supplied to a shader have a gamma correction applied to them. When they are used in a shader the colors of high luminance are actually brighter then they should be for linear lighting. This means that as light intensity increases the surface will get brighter in a non linear way. This leads to lighting that can be too bright in many places, and can also give models and scenes a washed out feel. When you are using linear lighting, as light intensity increases the response from the surface remains linear. This leads to much more realistic surface shading and a much nicer color response in the surface.

![](http://docwiki.hq.unity3d.com/uploads/Main/lineargammahead.png)  
[-Infinite, 3D Head Scan by Lee Perry-Smith is licensed under a Creative Commons Attribution 3.0 Unported License. Available from: http://www.ir-ltd.net/infinite-3d-head-scan-released-]

###Linear and Gamma Blending
When performing blending into the framebuffer the blending occurs in the color space or the framebuffer. When using gamma rendering this means that non linear colors get blended together. This is incorrect. When using linear space rendering blending occurs in linear space, this is correct and leads to expected results.

![](http://docwiki.hq.unity3d.com/uploads/Main/LinearGammaBlending.png)  

Using Linear Lighting
---------------------

Linear lighting results in a different look to the rendered scene. If you author a project for linear lighting it will most likely not look correct if you change to gamma lighting. Because of this if you move to linear lighting from gamma lighting it may take some time to update the project so that it looks as good as before the switch. That being said enabling linear lighting in Unity is quite simple. The feature is implemented on a per project level and is exposed in the Player Settings which can be located at <span class=keyword>Edit -> Project Settings -> Player -> Other Settings</span>

![](http://docwiki.hq.unity3d.com/uploads/Main/GammaPlayerSetting.png)  

###Lightmapping
When you are using linear lighting all lighting and textures are linearized, this means that the values that are passed to the lightmapper also need to be modified. When you switch between linear lighting and gamma lighting or back you will need to rebake lightmaps. The Unity lightmapping interface will warn you when the lightmaps are in the incorrect color space.

###Supported Platforms
Linear rendering is not supported on all platforms. The build targets that currently support the feature are:
* Windows & Mac (editor, standalone, web player)
* Xbox 360
* PlayStation 3

Even though these targets support linear lighting, it is not guaranteed that the graphics hardware on the device will be able to render the scene properly. You can check the desired color space and the active supported color space by looking at <span class=keyword>QualitySettings.desiredColorSpace</span> and <span class=keyword>QualitySettings.activeColorSpace</span> if the desired color space is linear but the active color space is gamma then the player has fallen back to gamma space. This can be used to show a warning box telling the user that the application will not look correct for them or to force an exit from the player.

###Linear and Non HDR
When not using HDR a special framebuffer type is used that supports sRGB read and sRGB write (Degamma on read, Gamma on write). This means that just like a texture the values in the framebuffer are gamma corrected. When this framebuffer is used for blending or bound as texture the values have the gamma removed before being used. When these buffers are written to the value that is being written is converted from linear space to gamma space. If you are rendering in linear mode, all post process effects will have their source and target buffers created with sRGB read and write enabled so that post process and post process blending occurs in linear space.

###Linear and HDR
When using HDR, rendering is performed into floating point buffers. These buffers have enough resolution to not require conversion to an from gamma space whenever the buffer is accessed, this means that when rendering in linear mode the render targets you use will store the colors in linear space. This means that all blending and post process effects will implicitly be performed in linear space. When the the backbuffer is written to, gamma correction is applied. 

###GUI and Linear Authored Textures
When rendering Unity GUI we do not perform the rendering in linear space. This means that GUI textures should not have their gamma removed on read. This can be achieved in two ways.
* Set the texture type to GUI in the texture importer
* Check the 'Bypass sRGB Sampling' checkbox int the advanced texture importer

It is also important that lookup textures and other textures which are authored to have their RGB values to mean something specific should bypass sRGB sampling.

This will force the sampled texture to not have gamma removed before being used by the graphics hardware. This is also useful for other texture types such as masks where you wish the value that is passed to the shader to be the exact same value that is in the authored texture.
