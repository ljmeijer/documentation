GameObject
==========


<span class=keyword>GameObjects</span> are containers for all other [Components](Components.md). All objects in your game are inherently GameObjects.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-GameObject.png)  
_An empty GameObject_


Creating GameObjects
--------------------


GameObjects do not add any characteristics to the game by themselves.  Rather, they are containers that hold Components, which implement actual functionality. For example, a [Light](class-Light.md) is a Component which is attached to a GameObject. 

If you want to create a Component from script, you should create and empty GameObject and then add required Component using <span class=component>gameObject.AddComponent(_ClassName_)</span> function. You can't create Component and then make a reference from object to it.

From scripts, Components can easily communicate with each other through message sending or the <span class=component>GetComponent(_TypeName_)</span> function. This allows you to write small, reusable scripts that can be attached to multiple GameObjects and reused for different purposes.

Details
-------


Aside from being a container for the components, GameObjects have a <span class=keyword>Tag</span>, a <span class=keyword>Layer</span> and a <span class=keyword>Name</span>.

Tags are used to quickly find objects, utilizing the Tag name. Layers can be used to cast rays, render, or apply lighting to certain groups of objects only. Tags and Layers can be set with the [Tag Manager](class-TagManager.md), found in <span class=menu>Edit->Project Settings->Tags</span>.


Static Checkbox
---------------

In Unity, there is a new checkbox in the GameObject called <span class=component>Static</span>. This checkbox is used for:
* preparing static geometry for automatic batching
* calculating [Occlusion Culling](OcclusionCulling.md)


![](http://docwiki.hq.unity3d.com/uploads/Main/StaticTagInspector.png)  
_The Static checkbox is used when generating Occlusion data_

When generating Occlusion data, marking a GameObject as <span class=component>Static</span> will enable it to cull (or disable) mesh objects that cannot be seen behind the Static object.  Therefore, any environmental objects that are not going to be moving around in your scene __should be marked__ as Static.

For more information about how Occlusion Culling works in Unity please read the [Occlusion Culling](OcclusionCulling.md) page.


Hints
-----


* For more information see the [GameObject scripting reference page](ScriptRef:GameObject.html).
* More information about how to use layers can be found [here](Layers.md).
* More information about how to use tags can be found [here](Tags.md).
