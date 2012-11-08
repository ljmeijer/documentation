Animations (Legacy)
===================


Unity's Animation System allows you to create beautifully animated skinned characters. The Animation System supports animation blending, mixing, additive animations, walk cycle time synchronization, animation layers, control over all aspects of the animation playback (time, speed, blend-weights), mesh skinning with 1, 2 or 4 bones per vertex and finally physically based ragdolls.

For best practices on creating a rigged character with optimal performance in Unity, we recommended that you check out the section on [Modeling Optimized Characters](ModelingOptimizedCharacters.md).

The following topics are covered on this page:

* [Importing Character Animations](#ImportAnim)
    * [Inverse Kinematics](#ImportIK)
    * [Adding animations to models that do not contain them](#ImportModelNoAnims)
* [Inserting Into a Unity Scene](#IntoScene)

[Importing Animations](AnimationsImport.md)

[Spliting animations](Splittinganimations.md)

<a id="ImportIK"></a>

###Importing Inverse Kinematics

When importing animated characters from Maya that are created using IK, you have to check the <span class=component>Bake IK & simulation</span> box in the Import Settings. Otherwise, your character will not animate correctly.

<a id="IntoScene"></a>

Bringing the character into the Scene
-------------------------------------


When you have imported your model you drag the object from the <span class=inspector>Project View</span> into the <span class=inspector>Scene View</span> or <span class=inspector>Hierarchy View</span>

![](http://docwiki.hq.unity3d.com/uploads/Main/animation_in_scene.png)  
_The animated character is added by dragging it into the scene_

The character above has three animations in the animation list and no default animation. You can add more animations to the character by dragging animation clips from the <span class=inspector>Project View</span> on to the character (in either the Hierarchy or Scene View). This will also set the default animation. When you hit Play, the default animation will be played.

TIP: You can use this to quickly test if your animation plays back correctly. Also use the <span class=component>Wrap Mode</span> to view different behaviors of the animation, especially looping.
