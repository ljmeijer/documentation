Preparing your application for "In App Purchases"
=================================================


This chapter does __not__ aim to cover how to integrate your game with Apple's "StoreKit" API. It is assumed that you already have integration with "StoreKit" via a [native code plugin](Main.Plugins.md).

Apple's "StoreKit" documentation defines four kinds of __Products__ that could be sold via the "In App Purchase" process: 
* Content
* Functionality
* Services
* Subscriptions

This chapter covers the first case only and focuses mainly on the downloadable content concept. [AssetBundles](ScriptRef:AssetBundle.html) are ideal candidates for use as downloadable content, and two scenarios will be covered:
* How to export asset bundles for use on iOS
* How download and cache them on iOS

Exporting your assets for use on iOS
------------------------------------

Having separate projects for downloadable content can be a good idea, allowing better separation between content that comes with your main application and content that is downloaded later.

Please note: Any game scripts included in downloadable content must also be present in the main executable.

1. Create an <span class=component>Editor</span> folder inside the Project View.
1. Create an <span class=component>ExportBundle.js</span> script there and place the following code inside:
````

@MenuItem ("Assets/Build AssetBundle From Selection - Track dependencies")
static function ExportBundle(){
        
        var str : String = EditorUtility.SaveFilePanel("Save Bundle...", Application.dataPath, Selection.activeObject.name, "assetbundle");
        if (str.Length != 0){
             BuildPipeline.BuildAssetBundle(Selection.activeObject, Selection.objects, str, BuildAssetBundleOptions.CompleteAssets, BuildTarget.iPhone);
        }
}

````
1. Design your objects that need to be downloadable as prefabs
1. Select a prefab that needs to be exported and mouse right click

![](http://docwiki.hq.unity3d.com/uploads/Main/iPhoneAssetBundleExport.png)  
If the first two steps were done properly, then the _Build AssetBundle From Selection - Track dependencies_ context menu item should be visible.
1. Select it if you want to include everything that this asset uses.
1. A save dialog will be shown, enter the desired asset bundle file name. An __.assetbundle__ extension will be added automatically. The Unity iOS runtime accepts only asset bundles built with the same version of the Unity editor as the final application. Read [BuildPipeline.BuildAssetBundle](ScriptRef:BuildPipeline.BuildAssetBundle.html) for details.

Downloading your assets on iOS
------------------------------

1. Asset bundles can be downloaded and loaded by using the [WWW class](ScriptRef:WWW-assetBundle.html) and instantiating a main asset. Code sample:
````

	var download : WWW;
	
	var url = "http://somehost/somepath/someassetbundle.assetbundle";
	
	download = new WWW (url);
	
	yield download;
	
	assetBundle = download.assetBundle;

	if (assetBundle != null) {
		// Alternatively you can also load an asset by name (assetBundle.Load("my asset name"))
		var go : Object = assetBundle.mainAsset;
			
		if (go != null)
			instanced = Instantiate(go);
		else
			Debug.Log("Couldnt load resource");	
	} else {
		Debug.Log("Couldnt load resource");	
	}

````
1. You can save required files to a Documents folder next to your game's Data folder.
````

        public static string GetiPhoneDocumentsPath () { 
                // Your game has read+write access to /var/mobile/Applications/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/Documents 
                // Application.dataPath returns              
                // /var/mobile/Applications/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/myappname.app/Data 
                // Strip "/Data" from path 
                string path = Application.dataPath.Substring (0, Application.dataPath.Length - 5); 
                // Strip application name 
                path = path.Substring(0, path.LastIndexOf('/'));  
                return path + "/Documents"; 
        }

````

1. Cache a downloaded asset bundle using the .NET file API and for reuse it in the future by loading it via [WWW class](ScriptRef:WWW.html) and __file:///pathtoyourapplication/Documents/savedassetbundle.assetbundle__. Sample code for caching:
````

	// Code designed for caching on iPhone, cachedAssetBundle path must be different when running in Editor
	// See code snippet above for getting the path to your Documents folder
	private var cachedAssetBundle : String = "path to your Documents folder" + "/savedassetbundle.assetbundle"; 
	var cache = new System.IO.FileStream(cachedAssetBundle, System.IO.FileMode.Create);
	cache.Write(download.bytes, 0, download.bytes.Length);
	cache.Close();
	Debug.Log("Cache saved: " + cachedAssetBundle);

````
>__Note:__ You can test reading files from the Documents folder if you enable file sharing.  Setting <span class=component>UIFileSharingEnabled</span> to true in your <span class=component>Info.plist</span> allows you to access the Documents folder from iTunes.
