AssetDatabase
=============


AssetDatabase is an API which allows you to access the assets contained in your project. Among other things, it provides methods to find and load assets and also to create, delete and modify them. The Unity Editor uses the AssetDatabase internally to keep track of asset files and maintain the linkage between assets and objects that reference them. Since Unity needs to keep track of all changes to the project folder, you should always use the AssetDatabase API rather than the filesystem if you want to access or modify asset data.

The AssetDatabase interface is only available in the editor and has no function in the built player. Like all other editor classes, it is only available to scripts placed in the Editor folder (just create a folder named “Editor” in the main Assets folder of your project if there isn't one already).

Importing an Asset
------------------


Unity normally imports assets automatically when they are dragged into the project but it is also possible to import them under script control. To do this you can use the [AssetDatabase.ImportAsset](ScriptRef:AssetDatabase.ImportAsset.html) method as in the example below.

````
using UnityEngine;
using UnityEditor;

public class ImportAsset {
	[MenuItem ("AssetDatabase/ImportExample")]
	static void ImportExample ()
	{
		AssetDatabase.ImportAsset("Assets/Textures/texture.jpg", ImportAssetOptions.Default);
	}
}
````

You can also pass an extra parameter of type [AssetDatabase.ImportAssetOptions](ScriptRef:ImportAssetOptions.html) to the AssetDatabase.ImportAsset call. The scripting reference page documents the different options and their effects on the function's behaviour.


Loading an Asset
----------------


The editor loads assets only as needed, say if they are added to the scene or edited from the Inspector panel. However, you can load and access assets from a script using [AssetDatabase.LoadAssetAtPath](ScriptRef:AssetDatabase.LoadAssetAtPath.html), [AssetDatabase.LoadMainAssetAtPath](ScriptRef:AssetDatabase.LoadMainAssetAtPath.html),  [AssetDatabase.LoadAllAssetRepresentationsAtPath](ScriptRef:AssetDatabase.LoadAllAssetRepresentationsAtPath.html) and [AssetDatabase.LoadAllAssetsAtPath ](ScriptRef:AssetDatabase.LoadAllAssetsAtPath .html). See the scripting documentation for further details.

````
using UnityEngine;
using UnityEditor;

public class ImportAsset {
	[MenuItem ("AssetDatabase/LoadAssetExample")]
	static void ImportExample ()
	{
		Texture2D t = AssetDatabase.LoadAssetAtPath("Assets/Textures/texture.jpg", typeof(Texture2D)) as Texture2D;
	}
}
````


File Operations using the AssetDatabase
---------------------------------------


Since Unity keeps metadata about asset files, you should never create, move or delete them using the filesystem. Instead, you can use [AssetDatabase.Contains](ScriptRef:AssetDatabase.Contains.html), [AssetDatabase.CreateAsset](ScriptRef:AssetDatabase.CreateAsset.html), [AssetDatabase.CreateFolder](ScriptRef:AssetDatabase.CreateFolder.html), [AssetDatabase.RenameAsset](ScriptRef:AssetDatabase.RenameAsset.html), [AssetDatabase.CopyAsset](ScriptRef:AssetDatabase.CopyAsset.html), [AssetDatabase.MoveAsset](ScriptRef:AssetDatabase.MoveAsset.html), [AssetDatabase.MoveAssetToTrash](ScriptRef:AssetDatabase.MoveAssetToTrash.html) and [AssetDatabase.DeleteAsset](ScriptRef:AssetDatabase.DeleteAsset.html).


````
public class AssetDatabaseIOExample {
	[MenuItem ("AssetDatabase/FileOperationsExample")]
	static void Example ()
	{
		string ret;
		
		// Create
		Material material = new Material (Shader.Find("Specular"));
		AssetDatabase.CreateAsset(material, "Assets/MyMaterial.mat");
		if(AssetDatabase.Contains(material))
			Debug.Log("Material asset created");
		
		// Rename
		ret = AssetDatabase.RenameAsset("Assets/MyMaterial.mat", "MyMaterialNew");
		if(ret == "")
			Debug.Log("Material asset renamed to MyMaterialNew");
		else
			Debug.Log(ret);
		
		// Create a Folder
		ret = AssetDatabase.CreateFolder("Assets", "NewFolder");
		if(AssetDatabase.GUIDToAssetPath(ret) != "")
			Debug.Log("Folder asset created");
		else
			Debug.Log("Couldn't find the GUID for the path");
		
		// Move
		ret = AssetDatabase.MoveAsset(AssetDatabase.GetAssetPath(material), "Assets/NewFolder/MyMaterialNew.mat");
		if(ret == "")
			Debug.Log("Material asset moved to NewFolder/MyMaterialNew.mat");
		else
			Debug.Log(ret);
		
		// Copy
		if(AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(material), "Assets/MyMaterialNew.mat"))
			Debug.Log("Material asset copied as Assets/MyMaterialNew.mat");
		else
			Debug.Log("Couldn't copy the material");
		// Manually refresh the Database to inform of a change
		AssetDatabase.Refresh();
		Material MaterialCopy = AssetDatabase.LoadAssetAtPath("Assets/MyMaterialNew.mat", typeof(Material)) as Material;
		
		// Move to Trash
		if(AssetDatabase.MoveAssetToTrash(AssetDatabase.GetAssetPath(MaterialCopy)))
			Debug.Log("MaterialCopy asset moved to trash");
		
		// Delete
		if(AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(material)))
			Debug.Log("Material asset deleted");
		if(AssetDatabase.DeleteAsset("Assets/NewFolder"))
			Debug.Log("NewFolder deleted");
		
		// Refresh the AssetDatabase after all the changes
		AssetDatabase.Refresh();
	}
}
````


Using AssetDatabase.Refresh
---------------------------


When you have finished modifying assets, you should call AssetDatabase.Refresh to commit your changes to the database and make them visible in the project.
