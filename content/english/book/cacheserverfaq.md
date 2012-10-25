Cache Server FAQ
================


###Will the size of my Cache Server database grow indefinitely as more and more resources get imported and stored?
The Cache Server removes assets that have not been used for a period of time automatically (of course if those assets are needed again, they will be re-created during next usage). 

###Does the cache server work only with the asset server?

The cache server is designed to be transparent to source/version control systems and so you are not restricted to using Unity's asset server.

###What changes will cause the imported file to get regenerated?

When Unity is about to import an asset, it generates an MD5 hash of all source data.

For a texture this consists of:
* The source asset:  "myTexture.psd" file
* The meta file: "myTexture.psd.meta" (Stores all importer settings)
* The internal version number of the texture importer
* A hash of version numbers of all [AssetPostprocessors](ScriptRef:AssetPostprocessor.html)

If that hash is different from what is stored on the Cache Server, the asset will be reimported, otherwise the cached version will be downloaded. The client Unity editor will only pull assets from the server as they are needed - assets don't get pushed to each project as they change.


###How do I work with Asset dependencies?

The Cache Server does not handle dependencies. Unity's asset pipeline does not deal with the concept of dependencies. It is built in such a way as to avoid dependencies between assets. <span class=component>AssetPostprocessors</span> are a common technique used to customize the Asset importer to fit your needs. For example, you might want to add MeshColliders to some GameObjects in an fbx file based on their name or tag.

It is also easy to use <span class=component>AssetPostprocessors</span> to introduce dependencies. For example you might use data from a text file next to the asset to add additional components to the imported game objects. This is not supported in the Cache Server. If you want to use the Cache Server, you will have to remove dependency on other assets in the project folder. Since the Cache Server doesn't know anything about the dependency in your postprocessor, it will not know that anything has changed thus use an old cached version of the asset.

In practice there are plenty of ways you can do asset postprocessing to work well with the cache server.
You can use:
* The Path of the imported asset
* Any import settings of the asset
* The source asset itself or any data generated from it passed to you in the asset postprocessor.

###Are there any issues when working with materials?
Modifying materials that already exist might cause trouble. When using the Cache Server, Unity validates that the references to materials are maintained. But since no postprocessing calls will be invoked, the contents of the material can not be changed when a model is imported through the Cache Server. Thus you might get different results when importing with or without Cache Server. It is best to never modify materials that already exist on disk.

###Are there any asset types which will not be cached by the server?

There are a few kinds of asset data which the server doesn't cache. There isn't really anything to be gained by caching script files and so the server will ignore them. Also, native files used by 3D modelling software (Maya, 3D Max, etc) are converted to FBX using the application itself. Currently, the asset server caches neither the native file nor the intermediate FBX file generated in the import process. However, it is possible to benefit from the server by exporting files as FBX from the modelling software and adding those to the Unity project.
