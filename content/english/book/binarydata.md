Storing and loading binary data in an AssetBundle
=================================================


The first step is to save your binary data file with the ".bytes" extension. Unity will treat this file as a [TextAsset](ScriptRef:TextAsset.html). As a TextAsset the file can be included when you build your AssetBundle. Once you have downloaded the AssetBundle in your application and loaded the TextAsset object, you can use the .bytes property of the TextAsset to retrieve your binary data.

````
string url = "http://www.mywebsite.com/mygame/assetbundles/assetbundle1.unity3d";
IEnumerator Start () {
    // Start a download of the given URL
    WWW www = WWW.LoadFromCacheOrDownload (url, 1);

    // Wait for download to complete
    yield return www;

    // Load and retrieve the AssetBundle
    AssetBundle bundle = www.assetBundle;

    // Load the TextAsset object
    TextAsset txt = bundle.Load("myBinaryAsText", typeof(TextAsset)) as TextAsset;

    // Retrieve the binary data as an array of bytes
    byte[] bytes = txt.bytes;
}
````


[back to AssetBundles Intro](AssetBundlesIntro.md)
