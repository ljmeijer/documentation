Animation Layers
================


Unity uses <span class=keyword>Animation Layers</span> for managing complex state machines for different body parts. An example of this is if you have a lower-body layer for walking-jumping, and an upper-body layer for throwing objects / shooting.

You can manage animation layers from the <span class=inspector>Layers Widget</span> in the top-left corner of the <span class=inspector>Animator Controller</span>.  

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimAnimationLayers.png)  

You can add a new layer by pressing the <span class=menu>+</span> on the widget. On each layer, you can specify the body mask (the part of the body on which the animation would be applied), and the Blending type. <span class=component>Override</span> means information from other layers will be ignored, while <span class=component>Additive</span> means that the animation will be added on top of previous layers.

The <span class=component>Mask</span> property is there to specify the body mask used on this layer. For example if you want to use upper body throwing animations, while having your character walk or run, you would use an upper body mask, like this:

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimBodyMaskOnLayers.png)  

For more on Avatar Body Masks, you can read [this section](Avatar Body Mask)

Animation Layer syncing
-----------------------


Sometimes it is useful to be able to re-use the same state machine in different layers. For example if you want to simulate "wounded" behavior, and have "wounded" animations for walk / run / jump instead of the "healthy" ones. You can click the <span class=menu>Sync</span> checkbox on one of your layers, and then select the layer you want to sync with. The state machine structure will then be the same, but the actual animation clips used by the states will be distinct.

![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimLayerSync.png)  

(back to [Mecanim introduction](MecanimAnimationSystem))
