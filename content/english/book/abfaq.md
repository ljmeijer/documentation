AssetBundles FAQ
================


1. [What are AssetBundles?](#whatare)
1. [What are they used for?](#whatfor)
1. [How do I create an AssetBundle?](#howtocreate)
1. [How do I use an AssetBundle?](#howtouse)
1. [How do I use AssetBundles in the Editor?](#howtouseeditor)
1. [How do I cache AssetBundles?](#howdoIcache)
1. [Are AssetBundles cross-platform?](#crossplatform)
1. [How are assets in AssetBundles identified](#howidentified)
1. [Can I reuse my AssetBundles in another game?](#reusebundles)
1. [Will an AssetBundle built now be usable with future versions of Unity?](#futureplayer)
1. [How can I list the objects in an AssetBundle?](#futureplayer)


----

1. %item value=1%<a id="whatare"></a>What are AssetBundles?

AssetBundles are a collection of assets, packaged for loading at runtime. With Asset Bundles, you can dynamically load and unload new content into your application. AssetBundles can be used to implement post-release DLC. 


1. %item value=2%<a id="whatfor"></a>What are they used for?

They can be used to reduce the amount of space on disk used by your game, when first deployed. It can also be used to add new content to an already published game.


1. %item value=3%<a id="howtocreate"></a>How do I create an AssetBundle?

To create an AssetBundle you need to use the BuildPipeline editor class. All scripts using Editor classes must be placed in a folder named Editor, anywhere in the Assets folder. Here is an example of such a script in C#:

(:showhide name="Creating an AssetBundle":)
````
using UnityEngine;
using UnityEditor;

public class ExportAssetBundles {
    [MenuItem("Assets/Build AssetBundle")]
        static void ExportResource () {
            string path = "Assets/myAssetBundle.unity3d";
            Object[] selection =  Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
            BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets);
        }
    }
}
````

An Editor script does not need to be applied to a GameObject, it is instead used by the Editor. This previous example will create a new item in the “Assets” menu of your editor called “Build AssetBundle”.

To use this example:
* Create a C# script file named ExportAssetBundles.cs, inside an folder named Editor, in the Project View.
* Select the Asset or Assets in your project folder that you wish to make into an AssetBundle.
* Select Build AssetBundle from the Assets menu.  Click “Save” to create the AssetBundle.
* The first line of the ExportResource function sets the path of your AssetBundle.
* The next line sets the selection to be made into an AssetBundle as the objects selected in the Project window.

The BuildAssetBundle function is the line that creates the AssetBundle and saves it to the specified location.  The first parameter specifies the mainAsset, which is a special Asset that can be obtained directly with the mainAsset property when loading Assets from the AssetBundle. It is not mandatory to set a main Asset, if this is not going to be used you can use null for the parameter. The second parameter is the array of objects that will make up the AssetBundle. The third parameter is the location on disk that the AssetBundle will be saved to.  The final parameter are the build flags or options used when building AssetBundles. The bitwise OR ( ‘|’ ) combines the options passed to build the AssetBundles. In this example BuildAssetBundleOptions.CollectDependencies sets it to include other Assets referenced by the objects and BuildAssetBundleOptions.CompleteAssets make sure that assets are completely included.

Building AssetBundles should be a pre-publish step which happens only once and with a single function call, for example, with a Menu Item that builds all the AssetBundles. As you develop your application you should write helper scripts that can build all your AssetBundles for a target platform with a single click or in batchmode without user intervention.

There are also other function to create AssetBundles. You can read more about this here: http://docwiki.hq.unity3d.com/index.php?n=Main.BuildingAssetBundles
(:showhideend:)

1. %item value=4%<a id="howtouse"></a>How do I use an AssetBundle?

There are two main steps involved when working with AssetBundles. The first step is to download the AssetBundle from a server or disk location. This is done with the WWW class. The second step is to load the Assets from the AssetBundle, to be used in the application. Here is an example C# script:

(:showhide name="Using an AssetBundle":)
````
using UnityEngine;
using System.Collections;

public class BundleLoader : MonoBehaviour{
    public string url;
    public int version;
    public IEnumerator LoadBundle(){
        using(WWW www = WWW.LoadFromCacheOrDownload(url, version){
            yield return www;
            AssetBundle assetBundle = www.assetBundle;
            GameObject gameObject = assetBundle.mainAsset as GameObject;
            Instantiate(gameObject );
            assetBundle.Unload(false);
        }
    }
    void Start(){
        StartCoroutine(LoadBundle());
    }
}
````

This script is added to a GameObject as Component. The AssetBundle is loaded in the following way:

* The url and version values need to be set in the Inspector prior to running this script. The url is the location of the AssetBundle file, usually a server on the Internet. The version number allows the developer to associate a number to the AssetBundle when written to the cache in disk. When downloading an AssetBundle Unity will check if the file already exists in the cache. If it does, it compare the version of the stored asset with the version requested. If it is different then the AssetBundle will be redownloaded. If it’s the same, then it will load the AssetBundle from disk and avoid having to redownload the file. Please refer to the WWW.LoadFromCacheOrDownload function in the scripting reference for more information about these parameters.
* When the Start function of this script is called, it will start loading the AssetBundle by calling the function as a Coroutine.The function will yield on the WWW object as it downloads the AssetBundle. By using this, the function will simply stop in that point until the WWW object is done downloading, but it will not block the execution of the rest of the code, it yields until it is done.
* Once the WWW object has downloaded AssetBundle file, the .assetBundle property is used to retrieve an AssetBundle object. This object is the interface to load objects from the AssetBundle file.
* In this example a reference to a prefab in the AssetBundle is retrieved from the AssetBundle using the .mainAsset property. This property is set when building the AssetBundle passing an Object as the first parameter.  The main asset in the AssetBundle can be used to store a TextAsset with a list of objects inside the AssetBundle and any other information about them.

Please note that for simplicity the previous example is not doing any safety checks. Please look at the code [here](DownloadingAssetBundles.md) for a more complete example.
(:showhideend:)

1. %item value=5%<a id="howtouseeditor"></a>How do I use AssetBundles in the Editor?

As creating applications is an iterative process, you will very likely modify your Assets many times, which would require rebuilding the AssetBundles after every change to be able to test them. Even though it is possible to load AssetBundles in the Editor, that is not the recommended workflow. Instead, while testing in the Editor you should use the helper function Resources.LoadAssetAtPath to avoid having to use and rebuild AssetBundles. The function lets you load the Asset as if it were being loaded from an AssetBundle, but will skip the building process and your Assets are always up to date.

The following is an example helper script, that you can use to load your Assets depending on if you are running in the Editor or not. Put this code in C# script named AssetBundleLoader.cs:

(:showhide name="Using an AssetBundle in the Editor":)
````

using UnityEngine;
using System.Collections;

public class AssetBundleLoader {
    public Object Obj; // The object retrieved from the AssetBundle
   
    public IEnumerator LoadBundle<T> (string url, int version, string assetName, string assetPath) where T : Object {
        Obj = null;
#if UNITY_EDITOR
        Obj = Resources.LoadAssetAtPath(assetPath, typeof(T));
        if (Obj == null)
            Debug.LogError ("Asset not found at path: " + assetPath);
        yield break;
#else

        WWW download;
        if ( Caching.enabled )  {       
            while (!Caching.ready)
                yield return null;
           download = WWW.LoadFromCacheOrDownload( url, version );
        }
        else {
            download = new WWW (url);
        }

        yield return download;
        if ( download.error != null ) {
            Debug.LogError( download.error );
            download.Dispose();
            yield break;
        }

        AssetBundle assetBundle = download.assetBundle;
        download.Dispose();
        download = null;

        if (assetName == "" || assetName == null)
        Obj = assetBundle.mainAsset;
        else
            Obj = assetBundle.Load(assetName, typeof(T));
       
        assetBundle.Unload(false);
#endif
    }
}
````

We can now use the AssetBundleLoader script to load an Asset from an AssetBundle if we are running the built application or load the Asset directly from the Project folder if running in the Editor:

````
using UnityEngine;
using System.Collections;

public class ExampleLoadingBundle : MonoBehaviour {
    public string url = "http://www.mygame.com/myBundle.unity3d"; // URL where the AssetBundle is
    public int version = 1; // The version of the AssetBundle

    public string assetName = "MyPrefab"; // Name of the Asset to be loaded from the AssetBundle
    public string assetPath; // Path to the Asset in the Project folder

    private Object ObjInstance; // Instance of the object
    void Start(){
        StartCoroutine(Download());
    }

    IEnumerator Download () {
        AssetBundleLoader assetBundleLoader = new AssetBundleLoader ();
        yield return StartCoroutine(assetBundleLoader.LoadBundle <GameObject> (url, version, assetName, assetPath));
        if (assetBundleLoader.Obj != null)
            ObjInstance = Instantiate (assetBundleLoader.Obj);
    }

    void OnGUI(){
        GUILayout.Label (ObjInstance ? ObjInstance.name + " instantiated" : "");
    }
}
````

The previous script should be saved to a file named ExampleLoadingBundle.cs inside the Assets folder. After setting the public variables to their correct values and running it, it will use the AssetBundleLoader class to load an Asset. It is then instantiated and this will be shown by using the GUI.
(:showhideend:)

1. %item value=6%<a id="howdoIcache"></a>How do I cache AssetBundles?

You can use [WWW.LoadFromCacheOrDownload](ScriptRef:WWW.LoadFromCacheOrDownload.html) which automatically takes care of saving your AssetBundles to disk. Be aware that on the Webplayer you are limited to 50MB in total (shared between all webplayers). You can buy a separate caching license for your game if you require more space.


1. %item value=7%<a id="crossplatform"></a>Are AssetBundles cross-platform?

AssetBundles are compatible between some platforms. Use the following table as a guideline. 


|    |    |    |    |    |
|:---|:---|:---|:---|:---|
| __Platform compatibility for AssetBundles__ |||||
| |Standalone |Webplayer |  iOS   |Android |
|Editor | Y | Y | Y | Y |
|Standalone | Y | Y |  |  |
|Webplayer | Y | Y |  |  ||
|iOS |  |  | Y |  ||
|Android |  |  |  | Y ||

For example, a bundle created while the Webplayer build target was active would be compatible with the editor and with standalone builds. However, it would not be compatible with apps built for the iOS or Android platforms.


1. %item value=8%<a id="howidentified"></a>How are assets in AssetBundles identified?

When you build AssetBundles the assets are identified internally by their filename without the extension. For example a Texture located in your Project folder at "Assets/Textures/myTexture.jpg" is identified and loaded using "myTexture" if you use the default method. You can have more control over this by supplying your own array of ids (strings)  for each object when Building your AssetBundle with [BuildPipeline.BuildAssetBundleExplicitAssetNames](ScriptRef:BuildPipeline.BuildAssetBundleExplicitAssetNames.html).


1. %item value=9%<a id="reusebundles"></a>Can I reuse my AssetBundles in another game?

AssetBundles allow you to share content between different games. The requirement is that any Assets which are referenced by GameObjects in your AssetBundle must either be included in the AssetBundle or exist in the application (loaded in the current scene). To make sure the referenced Assets are included in the AssetBundle when they are built you can pass the [BuildAssetBundleOptions.CollectDependencies](ScriptRef:BuildAssetBundleOptions.CollectDependencies.html) option.


1. %item value=10%<a id="futureplayer"></a>Will an AssetBundle built now be usable with future versions of Unity?

AssetBundles can contain a structure called a <span class=keyword>type tree</span> which allows information about asset types to be understood correctly between different versions of Unity. On desktop platforms, the type tree is included by default but can be disabled by passing the [BuildAssetBundleOptions.DisableWriteTypeTree](ScriptRef:BuildAssetBundleOptions.DisableWriteTypeTree.html) to the BuildAssetBundle function. Webplayers intrinsically rely on the type tree and so it is always included (ie, the DisableWriteTypeTree option has no effect). Type trees are never included for mobile and console asset bundles and so you will need to rebuild these bundles whenever the serialization format changes. This can happen in new versions of Unity. (Except for bugfix releases) It also happens if you add or remove serialized fields in monobehaviour's that are included in the asset bundle. When loading an AssetBundle Unity will give you an error message if the AssetBundle must be rebuilt.

1. %item value=11%<a id="futureplayer"></a>How can I list the objects in an AssetBundle?

You can use [AssetBundle.LoadAll](ScriptRef:AssetBundle.LoadAll.html) to retrieve an array containing all objects from the AssetBundle. It is not possible to get a list of the identifiers directly. A common workaround is to keep a separate TextAsset to hold the names of the assets in the AssetBundle.


[back to AssetBundles Intro](AssetBundlesIntro.md)

