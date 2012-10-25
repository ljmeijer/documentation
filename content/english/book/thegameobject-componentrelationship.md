The GameObject-Component Relationship
=====================================


As described previously in [GameObjects](GameObjects), a GameObject contains Components.  We'll explore this relationship by discussing a GameObject and its most common Component -- the <span class=component>Transform</span> Component.  With any Unity Scene open, create a new GameObject (using <span class=menu>Shift-Control-N</span> on Windows or <span class=menu>Shift-Command-N</span> on Mac), select it and take a look at the <span class=keyword>Inspector</span>.

![](http://docwiki.hq.unity3d.com/uploads/Main/EmptyGO.png)  
_The Inspector of an Empty GameObject_

Notice that an empty GameObject still contains a Name, a [Tag](Tags), and a [Layer](Layers). Every GameObject also contains a [Transform Component](class-Transform). 


The Transform Component
-----------------------


It is impossible to create a GameObject in Unity without a Transform Component. The Transform Component is one of the most important Components, since all of the GameObject's Transform properties are enabled by its use of this Component.  It defines the GameObject's position, rotation, and scale in the game world/Scene View.  If a GameObject did not have a Transform Component, it would be nothing more than some information in the computer's memory.  It effectively would not exist in the world.

The Transform Component also enables a concept called <span class=keyword>Parenting</span>, which is utilized through the <span class=keyword>Unity Editor</span> and is a critical part of working with GameObjects. To learn more about the Transform Component and Parenting, read the [Transform Component Reference page](class-Transform).


Other Components
----------------


The Transform Component is critical to all GameObjects, so each GameObject has one. But GameObjects can contain other Components as well.

![](http://docwiki.hq.unity3d.com/uploads/Main/GameObject-maincamera.png)  
_The Main Camera, added to each scene by default_

Looking at the Main Camera GameObject, you can see that it contains a different collection of Components.  Specifically, a [Camera Component](class-Camera), a [GUILayer](class-GUILayer), a [Flare Layer](class-FlareLayer), and an [Audio Listener](class-AudioListener).  All of these Components provide additional functionality to the GameObject.  Without them, there would be nothing rendering the graphics of the game for the person playing!  Rigidbodies, Colliders, Particles, and Audio are all different Components (or combinations of Components) that can be added to any given GameObject.

