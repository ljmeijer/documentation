Creating Scenes
===============


<span class=keyword>Scenes</span> contain the objects of your game.  They can be used to create a main menu, individual levels, and anything else.  Think of each unique Scene file as a unique level.  In each Scene, you will place your environments, obstacles, and decorations, essentially designing and building your game in pieces.

Instancing Prefabs
------------------


Use the method described in the last section to create a <span class=keyword>Prefab</span>.  You can also read more details about Prefabs [here](Prefabs).  Once you've created a Prefab, you can quickly and easily make copies of the Prefab, called an <span class=keyword>Instance</span>.  To create an instance of any Prefab, drag the Prefab from the <span class=keyword>Project View</span> to the <span class=keyword>Hierarchy</span> or <span class=keyword>Scene View</span>. Now you have a unique instance of your Prefab to position and tweak as you like.

Adding Component & Scripts
--------------------------


When you have a Prefab or any <span class=keyword>GameObject</span> highlighted, you can add additional functionality to it by using <span class=keyword>Components</span>.  Please view the [Component Reference](Components) for details about all the different Components.  <span class=keyword>Scripts</span> are a type of Component.  To add a Component, just highlight your GameObject and select a Component from the <span class=menu>Component</span> menu.  You will then see the Component appear in the <span class=keyword>Inspector</span> of the GameObject.  Scripts are also contained in the <span class=menu>Component</span> menu by default.

If adding a Component breaks the GameObject's connection to its Prefab, you can always use <span class=menu>GameObject->Apply Changes to Prefab</span> from the menu to re-establish the link.

Placing GameObjects
-------------------


Once your GameObject is in the scene, you can use the <span class=keyword>Transform Tools</span> to position it wherever you like.  Additionally, you can use the <span class=component>Transform</span> values in the Inspector to fine-tune placement and rotation.  Please view the [Transform Component page](class-Transform) for more information about positioning and rotating GameObjects.

Working with Cameras
--------------------


<span class=keyword>Cameras</span> are the eyes of your game.  Everything the player will see when playing is through one or more cameras.  You can position, rotate, and parent cameras just like any other GameObject.  A camera is just a GameObject with a Camera Component attached to it.  Therefore it can do anything a regular GameObject can do, and then some camera-specific functions too.  There are also some helpful Camera scripts that are installed with the standard assets package when you create a new project.  You can find them in <span class=menu>Components->Camera-Control</span> from the menu.  There are some additional aspects to cameras which will be good to understand.  To read about cameras, view the [Camera component page](class-Camera).

Lights
------


Except for some very few cases, you will always need to add <span class=keyword>Lights</span> to your scene.  There are three different types of lights, and all of them behave a little differently from each other.  The important thing is that they add atmosphere and ambience to your game.  Different lighting can completely change the mood of your game, and using lights effectively will be an important subject to learn.  To read about the different lights, please view the [Light component page](class-Light).
