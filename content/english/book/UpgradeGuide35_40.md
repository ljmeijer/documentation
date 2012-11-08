GameObject active state
-----------------------


Unity 4.0 changes how the active state of GameObjects is handled. GameObject's active state is now inherited by child GameObjects, so that any GameObject which is inactive will also cause its children to be inactive. We believe that the new behavior makes more sense than the old one, and should have always been this way. Also, the upcoming new GUI system heavily depends on the new 4.0 behavior, and would not be possible without it. Unfortunately, this may require some work to fix existing projects to work with the new Unity 4.0 behavior, and here is the change:

###The old behavior:

* Whether a GameObject is active or not was defined by its <span class=component>.active</span> property.
* This could be queried and set by checking the <span class=component>.active</span> property.
* A GameObject's active state had no impact on the active state of child GameObjects. If you want to activate or deactivate a GameObject and all of its children, you needed to call <span class=component>GameObject.SetActiveRecursively</span>.
* When using <span class=component>SetActiveRecursively</span> on a GameObject, the previous active state of any child GameObject would be lost. When you deactivate and then activated a GameObject and all its children using <span class=component>SetActiveRecursively</span>, any child which had been inactive before the call to <span class=component>SetActiveRecursively</span>, would become active, and you had to manually keep track of the active state of children if you want to restore it to the way it was.
* Prefabs could not contain any active state, and were always active after prefab instantiation.

###The new behavior:

* Whether a GameObject is active or not is defined by its own <span class=component>.activeSelf</span> property, and that of all of its parents. The GameObject is active if its own <span class=component>.activeSelf</span> property and that of all of its parents is <span class=component>true</span>. If any of them are <span class=component>false</span>, the GameObject is inactive.
* This can be queried using the <span class=component>.activeInHierarchy</span> property.
* The <span class=component>.activeSelf</span> state of a GameObject can be changed by calling <span class=component>GameObject.SetActive</span>. When calling <span class=component>SetActive (false)</span> on a previously active GameObject, this will deactivate the GameObject and all its children. When calling <span class=component>SetActive (true)</span> on a previously inactive GameObject, this will activate the GameObject, if all its parents are active. Children will be activated when all their parents are active (i.e., when all their parents have <span class=component>.activeSelf</span> set to <span class=component>true</span>).
* This means that <span class=component>SetActiveRecursively</span> is no longer needed, as active state is inherited from the parents. It also means that, when deactivating and activating part of a hierarchy by calling <span class=component>SetActive</span>, the previous active state of any child GameObject will be preserved.
* Prefabs can contain active state, which is preserved on prefab instantiation.

###Example:

You have three GameObjects, A, B and C, so that B and C are children of A. 
* Deactivate C by calling <span class=component>C.SetActive(false)</span>.
* Now, <span class=component>A.activeInHierarchy == true</span>, <span class=component>B.activeInHierarchy == true</span> and <span class=component>C.activeInHierarchy == false</span>.
* Likewise, <span class=component>A.activeSelf == true</span>, <span class=component>B.activeSelf == true</span> and <span class=component>C.activeSelf == false</span>.
* Now we deactivate the parent A by calling <span class=component>A.SetActive(false)</span>.
* Now, <span class=component>A.activeInHierarchy == false</span>, <span class=component>B.activeInHierarchy == false</span> and <span class=component>C.activeInHierarchy == false</span>.
* Likewise, <span class=component>A.activeSelf == false</span>, <span class=component>B.activeSelf == true</span> and <span class=component>C.activeSelf == false</span>.
* Now we activate the parent A again by calling <span class=component>A.SetActive(true)</span>.
* Now, we are back to <span class=component>A.activeInHierarchy == true</span>, <span class=component>B.activeInHierarchy == true</span> and <span class=component>C.activeInHierarchy == false</span>.
* Likewise, <span class=component>A.activeSelf == true</span>, <span class=component>B.activeSelf == true</span> and <span class=component>C.activeSelf == false</span>.

###The new active state in the editor

To visualize these changes, in the Unity 4.0 editor, any GameObject which is inactive (either because it's own <span class=component>.activeSelf</span> property is set to <span class=component>false</span>, or that of one of it's parents), will be greyed out in the hierarchy, and have a greyed out icon in the inspector. The GameObject's own <span class=component>.activeSelf</span> property is reflected by it's active checkbox, which can be toggled regardless of parent state (but it will only activate the GameObject if all parents are active).

###How this affects existing projects:

* To make you aware of places in your code where this might affect you, the <span class=component>GameObject.active</span> property and the <span class=component>GameObject.SetActiveRecursively()</span> function have been deprecated.
* They are, however still functional. Reading the value of <span class=component>GameObject.active</span> is equivalent to reading <span class=component>GameObject.activeInHierarchy</span>, and setting <span class=component>GameObject.active</span> is equivalent to calling <span class=component>GameObject.SetActive()</span>. Calling <span class=component>GameObject.SetActiveRecursively()</span> is equivalent to calling <span class=component>GameObject.SetActive()</span> on the GameObject and all of it's children.
* Exiting scenes from 3.5 are imported by setting the <span class=component>selfActive</span> property of any GameObject in the scene to it's previous <span class=component>active</span> property.
* As a result, any project imported from previous versions of Unity should still work as expected (with compiler warnings, though), as long as it does not rely on having active children of inactive GameObjects (which is no longer possible in Unity 4.0).
* If your project relies on having active children of inactive GameObjects, you need to change your logic to a model which works in Unity 4.0.


Changes to the asset processing pipeline
----------------------------------------

During the development of 4.0 our asset import pipeline has changed in some significant ways internal in order to improve performance, memory usage and determinism. For the most part these changes does not have an impact on the user with one exception: Objects in assets are not made persistent until the very end of the import pipeline and any previously imported version of an assets will be completely replaced.

The first part means that during post processing you cannot get the correct references to objects in the asset and the second part means that if you use the references to a previously imported version of the asset during post processing do store modification those modifications will be lost.

###Example of references being lost because they are not persistent yet
Consider this small example:
````

public class ModelPostprocessor : AssetPostprocessor
{
    public void OnPostprocessModel(GameObject go)
    {
        PrefabUtility.CreatePrefab("Prefabs/" + go.name, go);
    }
}

````

In Unity 3.5 this would create a prefab with all the correct references to the meshes and so on because all the meshes would already have been made persistent, but since this is not the case in Unity 4.0 the same post processor will create a prefab where all the references to the meshes are gone, simply because Unity 4.0 does not yet know how to resolve the references to objects in the original model prefab. To correctly copy a modelprefab in to prefab you should use <span class=component>OnPostProcessAllAssets</span> to go through all imported assets, find the modelprefab and create new prefabs as above.


###Example of references to previously imported assets being discarded
The second example is a little more complex but is actually a use case we have seen in 3.5 that broke in 4.0. Here is a simple <span class=component>ScriptableObject</span> with a references to a mesh.
````

public class Referencer : ScriptableObject
{
    public Mesh myMesh;	
}

````

We use this <span class=component>ScriptableObject</span> to create an asset with references to a mesh inside a model, then in our post processor we take that reference and give it a different name, the end result being that when we have reimported the model the name of the mesh will be what the post processor determines.

````

public class Postprocess : AssetPostprocessor
{
	public void OnPostprocessModel(GameObject go)
	{
		Referencer myRef  = (Referencer)AssetDatabase.LoadAssetAtPath("Assets/MyRef.asset", typeof(Referencer));
		myRef.myMesh.name = "AwesomeMesh";
	}
}

````

This worked fine in Unity 3.5 but in Unity 4.0 the already imported model will be completely replaced, so changing the name of the mesh from a previous import will have no effect. The Solution here is to find the mesh by some other means and change its name. What is most important to note is that in Unity 4.0 you should ONLY modify the given input to the post processor and not rely on the previously imported version of the same asset.

