Protecting Content
==================


Whilst it is possible to use encryption to secure your Assets as they are being transmitted, once the data is in the hands of the client it is possible to find ways to grab the content from them. For instance, there are tools out there which can record 3D data at the driver level, allowing users to extract models and textures as they are sent to the GPU. For this reason, our general stance is that if users are determined to extract your assets, they will be able to. 

However, it is possible for you to use your own data encryption on AssetBundle files if you still want to.

One way to do this is making use of the TextAsset type to store your data as bytes. You can encrypt your data files and save them with a .bytes extension, which Unity will treat as a TextAsset type. Once imported in the Editor the files as TextAssets can be included in your AssetBundle to be placed in a server. In the client side the AssetBundle would be downloaded and the content decrypted from the bytes stored in the TextAsset. With this method the AssetBundles are not encrypted, but the data stored which is stored as TextAssets is.


````
string url = "http://www.mywebsite.com/mygame/assetbundles/assetbundle1.unity3d";
IEnumerator Start () {
    // Start a download of the encrypted assetbundle
    WWW www = new WWW.LoadFromCacheOrDownload (url, 1);

    // Wait for download to complete
    yield return www;

    // Load the TextAsset from the AssetBundle
    TextAsset textAsset = www.assetBundle.Load("EncryptedData", typeof(TextAsset));
 
    // Get the byte data
    byte[] encryptedData = textAsset.bytes;

    // Decrypt the AssetBundle data
    byte[] decryptedData = YourDecryptionMethod(encryptedData);

    // Use your byte array. The AssetBundle will be cached
}
````


An alternative approach is to fully encrypt the AssetBundles from source and then download them using the WWW class. You can give them whatever file extension you like as long as your server serves them up as binary data. Once downloaded you would then use your decryption routine on the data from the .bytes property of your WWW instance to get the decrypted AssetBundle file data and create the AssetBundle from memory using [AssetBundle.CreateFromMemory](ScriptRef:AssetBundle.CreateFromMemory.html).


````
string url = "http://www.mywebsite.com/mygame/assetbundles/assetbundle1.unity3d";
IEnumerator Start () {
    // Start a download of the encrypted assetbundle
    WWW www = new WWW (url);

    // Wait for download to complete
    yield return www;

    // Get the byte data
    byte[] encryptedData = www.bytes;

    // Decrypt the AssetBundle data
    byte[] decryptedData = YourDecryptionMethod(encryptedData);

    // Create an AssetBundle from the bytes array
    AssetBundle bundle = AssetBundle.CreateFromMemory(decryptedData);

    // You can now use your AssetBundle. The AssetBundle is not cached.
}
````


The advantage of this latter approach over the first one is that you can use any method (except AssetBundles.LoadFromCacheOrDownload) to transmit your bytes and the data is fully encrypted - for example sockets in a plugin. The drawback is that it won't be Cached using Unity's automatic caching. You can in all players except the WebPlayer store the file manually on disk and load it using [AssetBundles.CreateFromFile](ScriptRef:AssetBundle.CreateFromFile.html)

A third approach would combine the best of both approaches and store an AssetBundle itself as a TextAsset, inside another normal AssetBundles. The unencrypted AssetBundle containing the encrypted one would be cached. The original AssetBundle could then be loaded into memory, decrypted and instantiated using [AssetBundle.CreateFromMemory](ScriptRef:AssetBundle.CreateFromMemory.html).

````
string url = "http://www.mywebsite.com/mygame/assetbundles/assetbundle1.unity3d";
IEnumerator Start () {
    // Start a download of the encrypted assetbundle
    WWW www = new WWW.LoadFromCacheOrDownload (url, 1);

    // Wait for download to complete
    yield return www;

    // Load the TextAsset from the AssetBundle
    TextAsset textAsset = www.assetBundle.Load("EncryptedData", typeof(TextAsset));
 
    // Get the byte data
    byte[] encryptedData = textAsset.bytes;

    // Decrypt the AssetBundle data
    byte[] decryptedData = YourDecryptionMethod(encryptedData);

    // Create an AssetBundle from the bytes array
    AssetBundle bundle = AssetBundle.CreateFromMemory(decryptedData);

    // You can now use your AssetBundle. The wrapper AssetBundle is cached
}
````


[back to AssetBundles Intro](AssetBundlesIntro.md)
