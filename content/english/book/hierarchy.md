Hierarchy
=========


![](http://docwiki.hq.unity3d.com/uploads/Main/Editor-Hierarchy.png)  

The <span class=keyword>Hierarchy</span> contains every <span class=keyword>GameObject</span> in the current Scene. Some of these are direct instances of asset files like 3D models, and others are instances of [Prefabs](Prefabs), custom objects that will make up much of your game. You can select objects in the Hierarchy and drag one object onto another to make use of <span class=keyword>Parenting</span> (see below). As objects are added and removed in the scene, they will appear and disappear from the Hierarchy as well.

Parenting
---------


Unity uses a concept called <span class=keyword>Parenting</span>. To make any GameObject the child of another, drag the desired child onto the desired parent in the Hierarchy.  A child will inherit the movement and rotation of its parent. You can use a parent object's foldout arrow to show or hide its children as necessary.

![](http://docwiki.hq.unity3d.com/uploads/Main/Editor-PreParent.png)  
_Two unparented objects_

![](http://docwiki.hq.unity3d.com/uploads/Main/Editor-PostParent.png)  
_One object parented to another_

To learn more about Parenting, please review the Parenting section of the [Transform Component page](class-Transform#Parenting).

