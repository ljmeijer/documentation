Building AssetBundles
=====================


There are three class methods you can use to build AssetBundles: 

* [BuildPipeline.BuildAssetBundle](ScriptRef:BuildPipeline.BuildAssetBundle.html) allows you to build AssetBundles of any type of asset.

* [BuildPipeline.BuildStreamedSceneAssetBundle](ScriptRef:BuildPipeline.BuildStreamedSceneAssetBundle.html) is used when you want to include only scenes to be streamed and loaded as the data becomes available.

* [BuildPipeline.BuildAssetBundleExplicitAssetNames](ScriptRef:BuildPipeline.BuildAssetBundleExplicitAssetNames.html) is the same as BuildPipeline.BuildAssetBundle but has an extra parameter to specify a custom string identifier (name) for each object.


An example of how to build an AssetBundle
-----------------------------------------


Building asset bundles is done through editor scripting. There is basic example of this in the scripting documentation for [BuildPipeline.BuildAssetBundle](ScriptRef:BuildPipeline.BuildAssetBundle.html). 

For the sake of this example, copy and paste the script from the link above into a new C# script called ExportAssetBundles. This script should be placed in a folder named Editor, so that it works inside the Unity Editor.


![](http://docwiki.hq.unity3d.com/uploads/Main/ExportAssetBundlesScript.png)  

Now in the <span class=menu>Assets</span> menu, you should see two new menu options.


![](http://docwiki.hq.unity3d.com/uploads/Main/AssetBundleMenuOptions.png)  
1. <span class=menu>Build AssetBundle From Selection - Track dependencies</span>. This will build the current object into an asset bundle and include all of its dependencies. For example if you have a prefab that consists of several hierarchical layers then it will recursively add all the child objects and components to the asset bundle.

1. <span class=menu>Build AssetBundle From Selection - No dependency tracking</span>. This is the opposite of the previous and will only include the single asset you have selected.

For this example, you should create a new prefab. First create a new Cube by going to <span class=menu>GameObject -> Create Other -> Cube</span>, which will create a new cube in the Hierarchy View. Then drag the Cube from the Hierarchy View into the Project View, which will create a prefab of that object.

You should then right click the Cube prefab in the project window and select <span class=menu>Build AssetBundle From Selection - Track dependencies</span>. 
At this point you will be presented with a window to save the “bundled” asset. If you created a new folder called "AssetBundles" and saved the cube as <span class=component>Cube.unity3d</span>, your project window will now look something like this.


![](http://docwiki.hq.unity3d.com/uploads/Main/AssetBundlesCube.png)  

At this point you can move the AssetBundle <span class=component>Cube.unity3d</span> elsewhere on your local storage, or upload it to a server of your choice.


Building AssetBundles in a production enviroment
------------------------------------------------


When first using AssetBundles it may seem enough to manually build them as seen in the previous example. But as a project grows in size and the number of Assets increases doing this process by hand is not efficient. A better approach is to write a function that builds all of the AssetBundles for a project. You can for example use a text file that maps Asset files to AssetBundle files.


[back to AssetBundles Intro](AssetBundlesIntro.md)
