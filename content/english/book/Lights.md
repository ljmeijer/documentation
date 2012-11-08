Lights
======


<span class=keyword>Lights</span> are an essential part of every scene.  While meshes and textures define the shape and look of a scene, lights define the color and mood of your 3D environment. You'll likely work with more than one light in each scene.  Making them work together requires a little practice but the results can be quite amazing.


![](http://docwiki.hq.unity3d.com/uploads/Main/LightTwoLights.png)  
_A simple, two-light setup_

Lights can be added to your scene from the <span class=menu>GameObject->Create Other</span> menu. Once a light has been added, you can manipulate it like any other GameObject. Additionally, you can add a Light Component to any selected GameObject by using <span class=menu>Component->Rendering->Light</span>.

There are many different options within the Light Component in the <span class=keyword>Inspector</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/LightInspectorV3.png)  
_Light Component properties in the Inspector_

By simply changing the <span class=component>Color</span> of a light, you can give a whole different mood to the scene.


![](http://docwiki.hq.unity3d.com/uploads/Main/LightMood1.png)  
_Bright, sunny lights_


![](http://docwiki.hq.unity3d.com/uploads/Main/LightMood2.png)  
_Dark, medieval lights_


![](http://docwiki.hq.unity3d.com/uploads/Main/LightMood3.png)  
_Spooky night lights_

The lights you create this way are <span class=keyword>realtime</span> lights - their lighting is calculated each frame while the game is running. If you know the light will not change, you can make your game faster and look much better by using [Lightmapping](Lightmapping.md).

Rendering paths
---------------

Unity supports different Rendering Paths, these paths affect mainly Lights and Shadows, so choosing the correct rendering path depending on your game requirements can improve your project's performance.
For more info about rendering paths you can visit the [Rendering paths section](RenderingPaths.md).


More information
----------------

For more information about using Lights, check the [Lights page](class-Light.md) in the [Reference Manual](Reference.md).
