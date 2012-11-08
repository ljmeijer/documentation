Loading and unloading objects from an AssetBundle
-------------------------------------------------


Having created an AssetBundle object from the downloaded data, you can load the objects contained in it using three different methods: 

* [AssetBundle.Load](ScriptRef:AssetBundle.Load.html) will load an object using its name identifier as a parameter. The name is the one visible in the Project view. You can optionally pass an object type as an argument to the Load method to make sure the object loaded is of a specific type.

* [AssetBundle.LoadAsync](ScriptRef:AssetBundle.LoadAsync.html) works the same as the Load method described above but it will not block the main thread while the asset is loaded. This is useful when loading large assets or many assets at once to avoid pauses in your application.

* [AssetBundle.LoadAll](ScriptRef:AssetBundle.LoadAll.html) will load all the objects contained in your AssetBundle. As with AssetBundle.Load, you can optionally filter objects by their type.


To unload assets you need to use [AssetBundle.Unload](ScriptRef:AssetBundle.Unload.html). This method takes a boolean parameter which tells Unity whether to unload all data (including the loaded asset objects) or only the compressed data from the downloaded bundle. If your application is using some objects from the AssetBundle and you want to free some memory you can pass false to unload the compressed data from memory. If you want to completely unload everything from the AssetBundle you should pass true which will destroy the Assets loaded from the AssetBundle.

Loading objects from an AssetBundles asynchronously
---------------------------------------------------


You can use the [AssetBundle.LoadAsync](ScriptRef:AssetBundle.LoadAsync.html) method to load objects Asynchronously and reduce the likelihood of having hiccups in your application.

````
using UnityEngine;

// Note: This example does not check for errors. Please look at the example in the DownloadingAssetBundles section for more information
IEnumerator Start () {
	// Start a download of the given URL
	WWW www = WWW.LoadFromCacheOrDownload (url, 1);

	// Wait for download to complete
	yield return www;

	// Load and retrieve the AssetBundle
	AssetBundle bundle = www.assetBundle;

	// Load the object asynchronously
	AssetBundleRequest request = bundle.LoadAsync ("myObject", typeof(GameObject));

	// Wait for completion
	yield return request;

	// Get the reference to the loaded object
	GameObject obj = request.asset as GameObject;

        // Unload the AssetBundles compressed contents to conserve memory
        bundle.Unload(false);
}
````

[back to AssetBundles Intro](AssetBundlesIntro.md)
