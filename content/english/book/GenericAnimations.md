Generic Animations in Mecanim
=============================


The full power of Mecanim is most evident when you are working with humanoid animations. However, non-humanoid animations are also supported although without the avatar system and other features. In Mecanim terminology, non-humanoid animations are referred to as <span class=keyword>Generic Animations</span>.

To start working with a generic skeleton, go to the Rig tab in the FBX importer and choose <span class=component>Generic</span> from the Animation Type menu.


![](http://docwiki.hq.unity3d.com/uploads/Main/MecanimImportRigGeneric.png)  

Root node in generic animations
-------------------------------

While in the case of humanoid animations, we have the knowledge about the center of mass and orientation, in the case of Generic animations, the skeleton can be arbitrary, and we need to specify a reference bone, or the "root node". Selecting the root node allows us to establish correspondence between animation clips for a generic model, and blend properly between animations that are not "in place". The root node is also essential for separating animation of bones relative to reach other and motion of the root in the world (controlled from `[OnAnimatorMove](ScriptRef:MonoBehavior.OnAnimatorMove)`)
