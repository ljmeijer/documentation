Inspector
=========



![](http://docwiki.hq.unity3d.com/uploads/Main/Editor-Inspector.png)  

Games in Unity are made up of multiple <span class=keyword>GameObjects</span> that contain meshes, scripts, sounds, or other graphical elements like <span class=keyword>Lights</span>. The <span class=keyword>Inspector</span> displays detailed information about your currently selected GameObject, including all attached <span class=keyword>Components</span> and their properties. Here, you modify the functionality of GameObjects in your scene. You can read more about the [GameObject-Component relationship](GameObjects.md), as it is very important to understand.

Any property that is displayed in the Inspector can be directly modified.  Even script variables can be changed without modifying the script itself.  You can use the Inspector to change variables at runtime to experiment and find the magic gameplay for your game.  In a script, if you define a public variable of an object type (like GameObject or Transform), you can drag and drop a GameObject or Prefab into the Inspector to make the assignment.


![](http://docwiki.hq.unity3d.com/uploads/Main/Editor-InspectorDragDrop.png)  

Click the question mark beside any Component name in the Inspector to load its Component Reference page. Please view the  [Component Reference](Components.md) for a complete and detailed guide to all of Unity's Components.


![](http://docwiki.hq.unity3d.com/uploads/Main/componentsmenu.png)  
_Add Components from the <span class=menu>Component</span> menu_

You can click the tiny gear icon (or right-click the Component name) to bring up a context menu for the specific Component.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-contextmenu.png)  

The Inspector will also show any Import Settings for a selected asset file.



![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-ImportSettings.png)  
_Click <span class=menu>Apply</span> to reimport your asset._


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-Layers_Tags.png)  

Use the <span class=menu>Layer</span> drop-down to assign a rendering Layer to the GameObject.  Use the <span class=menu>Tag</span> drop-down to assign a Tag to this GameObject.

Prefabs
-------


If you have a Prefab selected, some additional buttons will be available in the Inspector.  For more information about Prefabs, please view the [Prefab manual page](Prefabs.md).

