Including scripts in AssetBundles
=================================


AssetBundles can contain scripts as TextAssets but as such they will not be actual executable code. If you want to include code in your AssetBundles that can be executed in your application it needs to be pre-compiled into an assembly and loaded using the Mono Reflection class (Note: Reflection is not available on iOS). You can create your assemblies in any normal C# IDE (e.g. Monodevelop, Visual Studio) or any text editor using the mono/.net compilers. 

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

    // Load the assembly and get a type (class) from it
    var assembly = System.Reflection.Assembly.Load(txt.bytes);
    var type = assembly.GetType("MyClassDerivedFromMonoBehaviour");

    // Instantiate a GameObject and add a component with the loaded class
    GameObject go = new GameObject();
    go.AddComponent(type);
}
````


[back to AssetBundles Intro](AssetBundlesIntro.md)
