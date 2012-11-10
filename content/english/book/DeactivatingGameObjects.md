Deactivating GameObjects
========================


A GameObject can be temporarily removed from the scene by marking it as inactive. This can be done using its [activeSelf](ScriptRef:GameObject-activeSelf.html) property from a script or with the activation checkbox in the inspector


![](http://docwiki.hq.unity3d.com/uploads/Main/GOActiveBox.png)  

_A GameObject's activation checkbox_

Effect of deactivating a parent GameObject
------------------------------------------


When a parent object is deactivated, the deactivation also overrides the <span class=keyword>activeSelf</span> setting on all its child objects, so the whole hierarchy from the parent down is made inactive. Note that this does _not_ change the value of the <span class=keyword>activeSelf</span> property on the child objects, so they will return to their original state once the parent is reactivated. This means that you can't determine whether or not a child object is currently active in the scene by reading its <span class=keyword>activeSelf</span> property. Instead, you should use the [activeInHierarchy](ScriptRef:GameObject-activeInHierarchy.html) property, which takes the overriding effect of the parent into account.

This overriding behaviour was introduced in Unity 4.0. In earlier versions, there was a function called <span class=keyword>SetActiveRecursively</span> which could be used to activate or deactivate the children of a given parent object. However, this function worked differently in that the activation setting of each child object was changed - the whole hierarchy could be switched off and on but the child objects had no way to "remember" the state they were originally in. To avoid breaking legacy code, <span class=keyword>SetActiveRecursively</span> has been kept in the API for 4.0 but its use is not recommended and it may be removed in the future. In the unusual case where you actually want the children's <span class=keyword>activeSelf</span> settings to be changed, you can use code like the following:-

````
// JavaScript
function DeactivateChildren(g: GameObject, a: boolean) {
	g.activeSelf = a;
	
	for (var child: Transform in g.transform) {
		DeactivateChildren(child.gameObject, a);
	}
}


// C#
void DeactivateChildren(GameObject g, bool a) {
	g.activeSelf = a;
	
	foreach (Transform child in g.transform) {
		DeactivateChildren(child.gameObject, a);
	}
}
````
