Loading Resources at Runtime
============================


In some situations, it is useful to make an asset available to a project without loading it in as part of a scene. For example, there may be a character or other object that can appear in any scene of the game but which will only be used infrequently (this might be a "secret" feature, an error message or a highscore alert, say). Furthermore, you may even want to load assets from a separate file or URL to reduce initial download time or allow for interchangeable game content.

Unity supports <span class=keyword>Resource Folders</span> in the project to allow content to be supplied in the main game file yet not be loaded until requested. In Unity Pro, Unity iOS Advanced and Unity Android Advanced, you can also create <span class=keyword>Asset Bundles</span>. These are files completely separate from the main game file which contain assets to be accessed by the game on demand from a file or URL.

Asset Bundles (Unity Pro-only/iOS Advanced/Android Advanced licenses only)
--------------------------------------------------------------------------


An Asset Bundle is an external collection of assets.  You can have many Asset Bundles and therefore many different external collections of assets.  These files exist outside of the built Unity player, usually sitting on a web server for end-users to access dynamically. 

To build an Asset Bundle, you call [BuildPipeline.BuildAssetBundle()](ScriptRef:BuildPipeline.BuildAssetBundle.html) from inside an Editor script.  In the arguments, you specify an array of <span class=keyword>Objects</span> to be included in the built file, along with some other options.  This will build a file that you can later load dynamically in the runtime by using [AssetBundle.Load()](ScriptRef:AssetBundle.Load.html).

Resource Folders
----------------


Resource Folders are collections of assets that are included in the built Unity player, but are not necessarily linked to any GameObject in the Inspector.

To put anything into a Resource Folder, you simply create a new folder inside the <span class=keyword>Project View</span>, and name the folder "Resources".  You can have multiple Resource Folders organized differently in your Project.  Whenever you want to load an asset from one of these folders, you call [Resources.Load()](ScriptRef:Resources.Load.html).


If your target deployable is a <span class=keyword>Streaming Web Player</span>, you can define which scene will include everything in your Resource Folders.  You do this in the <span class=keyword>Player Settings</span>, accessible via <span class=menu>Edit->Project Settings->Player</span>.  Set the <span class=component>First Streamed Level With Resources</span> parameter, and all assets in your Resource Folders will be loaded when this level streams in to the end-user.

###Note:
All assets found in the Resources folders and their dependencies are stored in a file called _resources.assets_. If an asset is already used by another level it is stored in the _.sharedAssets_ file for that level.
The <span class=menu>Edit -> PlayerSettings</span> 'First Streamed Level' setting determines the level at which the _resources.assets_ will be collected and included in the build.

If a level prior to _"First streamed Level"_ is including an asset in a Resource folder, the asset will be stored in assets for that level. if it is included afterwards, the level will reference the asset from the "resources.assets" file.

Only assets that are in the _Resources folder_ can be accessed through Resources.Load. However many more assets might end up in the "resources.assets" file since they are dependencies. (For example a Material in the Resources folder might reference a Texture outside of the Resources folder)


Resource Unloading
------------------


You can unload resources of an AssetBundle by calling [AssetBundle.Unload()](ScriptRef:AssetBundle.Unload.html). If you pass <span class=component>true</span> for the <span class=component>unloadAllLoadedObjects</span> parameter, both the objects held internally by the AssetBundle and the ones loaded from the AssetBundle using [AssetBundle.Load()](ScriptRef:AssetBundle.Load.html) will be destroyed and memory used by the bundle will be released.

Sometimes you may prefer to load an AssetBundle, instantiate the objects desired and release the memory used up by the bundle while keeping the objects around. The benefit is that you free up memory for other tasks, for instance loading another AssetBundle. In this scenario you would pass <span class=component>false</span> as the parameter. After the bundle is destroyed you will not be able to load objects from it any more.

If you want to destroy scene objects loaded using [Resources.Load()](ScriptRef:Resources.Load.html) prior to loading another level, call [Object.Destroy()](ScriptRef:Object.Destroy.html) on them. To release assets, use [Resources.UnloadUnusedAssets()](ScriptRef:Resources.UnloadUnusedAssets.html).

