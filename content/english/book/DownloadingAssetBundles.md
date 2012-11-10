Downloading AssetBundles
------------------------


This section assumes you already learned how to build asset bundles. If you have not, please see [Building AssetBundles](BuildingAssetBundles.md)

There are two ways to download an AssetBundle
1. __Non-caching:__ This is done using a creating a new [WWW object](ScriptRef:WWW.WWW.html). The AssetBundles are not cached to Unity’s Cache folder in the local storage device.
1. __Caching:__ This is done using the [WWW.LoadFromCacheOrDownload](ScriptRef:WWW.LoadFromCacheOrDownload.html) call. The AssetBundles are cached to Unity’s Cache folder in the local storage device. The WebPlayer shared cache allows up to 50 MB of cached AssetBundles. PC/Mac Standalone applications and iOS/Android applications have a limit of 4 GB. WebPlayer applications that make use of a dedicated cache are limited to the number of bytes specified in the caching license agreement. Please refer to the scripting documentation for other platforms.

Here's an example of a non-caching download:

````
using System;
using UnityEngine;
using System.Collections; class NonCachingLoadExample : MonoBehaviour {
   public string BundleURL;
   public string AssetName;
   IEnumerator Start() {
	   // Download the file from the URL. It will not be saved in the Cache
	   using (WWW www = new WWW(BundleURL)) {
		   yield return www;
		   if (www.error != null)
			   throw new Exception("WWW download had an error:" + www.error);
		   AssetBundle bundle = www.assetBundle;
		   if (AssetName == "")
			   Instantiate(bundle.mainAsset);
		   else
			   Instantiate(bundle.Load(AssetName));
                   // Unload the AssetBundles compressed contents to conserve memory
                   bundle.Unload(false);
	   }
   }
}
````

The recommended way to download AssetBundles is to use [WWW.LoadFromCacheOrDownload](ScriptRef:WWW.LoadFromCacheOrDownload.html). For example:

````
using System;
using UnityEngine;
using System.Collections;

public class CachingLoadExample : MonoBehaviour {
	public string BundleURL;
	public string AssetName;
	public int version;

	void Start() {
		StartCoroutine (DownloadAndCache());
	}

	IEnumerator DownloadAndCache (){
		// Wait for the Caching system to be ready
		while (!Caching.ready)
			yield return null;

		// Load the AssetBundle file from Cache if it exists with the same version or download and store it in the cache
		using(WWW www = WWW.LoadFromCacheOrDownload (BundleURL, version)){
			yield return www;
			if (www.error != null)
				throw new Exception("WWW download had an error:" + www.error);
			AssetBundle bundle = www.assetBundle;
			if (AssetName == "")
				Instantiate(bundle.mainAsset);
			else
				Instantiate(bundle.Load(AssetName));
                	// Unload the AssetBundles compressed contents to conserve memory
                	bundle.Unload(false);
		}
	}
}
````

When you access the `.assetBundle` property, the downloaded data is extracted and the AssetBundle object is created. At this point, you are ready to load the objects contained in the bundle. The second parameter passed to LoadFromCacheOrDownload specifies which version of the AssetBundle to download. If the AssetBundle doesn't exist in the cache or has a version lower than requested, LoadFromCacheOrDownload will download the AssetBundle. Otherwise the AssetBundle will be loaded from cache.


###Putting it all together

Now that the components are in place you can build a scene that will allow you to load your AssetBundle and display the contents on screen. 


![](http://docwiki.hq.unity3d.com/uploads/Main/AssetBundlesExampleFinalProject.png)  
Final project structure

First create an empty game object by going to  <span class=menu>GameObject->CreateEmpty</span>. Drag the CachingLoadExample script onto the empty game object you just created. Then type the the URL of your AssetBundle in the BundleURL field. As we have placed this in the project directory you can copy the file directory location and add the prefix `file://`, for example `file://C:/UnityProjects/AssetBundlesGuide/Assets/AssetBundles/Cube.unity3d`

You can now hit play in the Editor and you should see the Cube prefab being loaded from the AssetBundle. 



###Loading AssetBundles in the Editor

When working in the Editor requiring AssetBundles to be built and loaded can slow down the development process. For instance, if an Asset from an AssetBundle is modified this will then require the AssetBundle to be rebuilt and in a production environment it is most likely that all AssetBundles are built together and therefore making the process of updating a single AssetBundle a lengthy operation. A better approach is to have a separate code path in the Editor that will load the Asset directly instead of loading it from an AssetBundle. To do this it is possible to use Resources.LoadAssetAtPath (Editor only). 


````
// C# Example
// Loading an Asset from disk instead of loading from an AssetBundle
// when running in the Editor
using System.Collections;
using UnityEngine;

class LoadAssetFromAssetBundle : MonoBehaviour
{
	public Object Obj;

	public IEnumerator DownloadAssetBundle<T>(string asset, string url, int version) where T : Object {
		Obj = null;
#if UNITY_EDITOR
		Obj = Resources.LoadAssetAtPath("Assets/" + asset, typeof(T));
		yield return null;
#else
		// Wait for the Caching system to be ready
		while (!Caching.ready)
			yield return null;

		// Start the download
		using(WWW www = WWW.LoadFromCacheOrDownload (url, version)){
			yield return www;
			if (www.error != null)
                		throw new Exception("WWW download:" + www.error);
			AssetBundle assetBundle = www.assetBundle;
			Obj = assetBundle.Load(asset, typeof(T));
			// Unload the AssetBundles compressed contents to conserve memory
			bundle.Unload(false);
		}
#endif
	}
}
````


[back to AssetBundles Intro](AssetBundlesIntro.md)
