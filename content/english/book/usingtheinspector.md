Using the Inspector
===================


The <span class=keyword>Inspector</span> is used to view and edit <span class=keyword>Properties</span> of many different types.

Games in Unity are made up of multiple <span class=keyword>GameObjects</span> that contain meshes, scripts, sounds, or other graphical elements like Lights. When you select a <span class=keyword>GameObject</span> in the Hierarchy or Scene View, the <span class=keyword>Inspector</span> will show and let you modify the <span class=keyword>Properties</span> of that GameObject and all the <span class=keyword>Components</span> and <span class=keyword>Materials</span> on it. The same will happen if you select a <span class=keyword>Prefab</span> in the Project View. This way you modify the functionality of GameObjects in your game. You can read more about the [GameObject-Component relationship](GameObjects#Relationship), as it is very important to understand.

![](http://docwiki.hq.unity3d.com/uploads/Main/GenericInspector.png)  
_Inspector shows the properties of a GameObject and the Components and Materials on it._

When you create a <span class=keyword>script</span> yourself, which works as a custom Component type, the member variables of that script are also exposed as <span class=keyword>Properties</span> that can be edited directly in the Inspector when that script component has been added to a <span class=keyword>GameObject</span>. This way script variables can be changed without modifying the script itself.

Furthermore, the Inspector is used for showing import options of assets such as textures, 3D models, and fonts when selected. Some scene and project-wide settings are also viewed in the <span class=keyword>Inspector</span>, such as all the [Settings Managers](comp-ManagerGroup).

Any property that is displayed in the Inspector can be directly modified. There are two main types of Properties: <span class=keyword>Values</span> and <span class=keyword>References</span>.

(:tocportion:)

