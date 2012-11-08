Keeping Track of loaded AssetBundles
------------------------------------


Unity will only allow you to have a single instance of a particular AssetBundle loaded at one time in your application. What this means is that you can’t retrieve an AssetBundle from a WWW object if the same one has been loaded previously and has not been unloaded. In practical terms it means that when you try to access a previously loaded AssetBundle like this:

````
AssetBundle bundle = www.assetBundle;
````

the following error will be thrown

````
Cannot load cached AssetBundle. A file of the same name is already loaded from another AssetBundle
````

and the assetBundle property will return null. Since you can’t retrieve the AssetBundle during the second download if the first one is still loaded, what you need to do is to either _unload_ the AssetBundle when you are no longer using it, or maintain a reference to it and avoid downloading it if it is already in memory. You can decide the right course of action based on your needs, but our recommendation is that you _unload_ the AssetBundle as soon as you are done loading objects. This will free the memory and you will no longer get an error about loading cached AssetBundles. 

If you do want to keep track of which AssetBundles you have downloaded, you could use a wrapper class to help you manage your downloads like the following:

````
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

static public class AssetBundleManager {
   // A dictionary to hold the AssetBundle references
   static private Dictionary<string, AssetBundleRef> dictAssetBundleRefs;
   static AssetBundleManager (){
       dictAssetBundleRefs = new Dictionary<string, AssetBundleRef>();
   }
   // Class with the AssetBundle reference, url and version
   private class AssetBundleRef {
       public AssetBundle assetBundle = null;
       public int version;
       public string url;
       public AssetBundleRef(string strUrlIn, int intVersionIn) {
           url = strUrlIn;
           version = intVersionIn;
       }
   };
   // Get an AssetBundle
   public static AssetBundle getAssetBundle (string url, int version){
       string keyName = url + version.ToString();
       AssetBundleRef abRef;
       if (dictAssetBundleRefs.TryGetValue(keyName, out abRef))
           return abRef.assetBundle;
       else
           return null;
   }
   // Download an AssetBundle
   public static IEnumerator downloadAssetBundle (string url, int version){
       string keyName = url + version.ToString();
       if (dictAssetBundleRefs.ContainsKey(keyName))
           yield return null;
       else {
           using(WWW www = WWW.LoadFromCacheOrDownload (url, version)){
               yield return www;
               if (www.error != null)
                   throw new Exception("WWW download:" + www.error);
               AssetBundleRef abRef = new AssetBundleRef (url, version);
               abRef.assetBundle = www.assetBundle;
               dictAssetBundleRefs.Add (keyName, abRef);
           }
       }
   }
   // Unload an AssetBundle
   public static void Unload (string url, int version, bool allObjects){
       string keyName = url + version.ToString();
       AssetBundleRef abRef;
       if (dictAssetBundleRefs.TryGetValue(keyName, out abRef)){
           abRef.assetBundle.Unload (allObjects);
           abRef.assetBundle = null;
           dictAssetBundleRefs.Remove(keyName);
       }
   }
}
````

An example usage of the class would be:

````
using UnityEditor;

class ManagedAssetBundleExample : MonoBehaviour {
   public string url;
   public int version;
   AssetBundle bundle;
   void OnGUI (){
       if (GUILayout.Label ("Download bundle"){
           bundle = AssetBundleManager.getAssetBundle (url, version);
           if(!bundle)
               StartCoroutine (DownloadAB());
       }
   }
   IEnumerator DownloadAB (){
       yield return StartCoroutine(AssetBundleManager.downloadAssetBundle (url, version));
       bundle = AssetBundleManager.getAssetBundle (url, version);
   }
   void OnDisable (){
       AssetBundleManager.Unload (url, version);
   }
}
````

Please bear in mind, that the AssetBundleManager class in this example is static, and any AssetBundles that you are referencing will not be destroyed when loading a new scene. Use this class as a guide but as recommended initially it is best if you _unload_ AssetBundles right after they have been used. You can always clone a previously Instantiated object, removing the need to load the AssetBundles again.


[back to AssetBundles Intro](AssetBundlesIntro.md)
