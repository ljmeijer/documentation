Flash: Embedding Unity Generated Flash Content in Larger Flash Projects
=======================================================================


embeddingapi.swc
----------------


If you want to embed your Unity generated Flash content within a larger Flash project, you can do so using the <span class=keyword>embeddingapi.swc</span>. This SWC provides functionality to load and communicate with Unity published Flash content. In the <span class=keyword>embeddingapi.swc</span> file, you will find two classes and two interfaces. Each of these, and their available functions, are described below.

When your Unity Flash project is built, a copy of the embeddingapi.swc file will be placed in the same location as your built SWF. You can then use this in your Flash projects as per other SWCs. For more details on [what SWCs are](http://www.adobe.com/mena_fr/devnet/flash/articles/concept_swc.html.md) and how to use them, see [Adobe's documentation](http://livedocs.adobe.com/flex/3/html/help.html?content=building_overview_5.html.md).

  

Stage3D Restrictions
--------------------


When embedding your Unity Flash content within another Flash project, it is useful to understand the Flash display model. All Stage3D content is displayed behind the Flash Stage. This means that any Flash display list content added to the Stage will always render in front of your 3D content. For more information on this, please refer to [Adobe's "How Stage3D Works" page](http://www.adobe.com/devnet/flashplayer/articles/how-stage3d-works.html.md).

  

IUnityContent
-------------


<span class=component>IUnityContent</span> is implemented by Unity built Flash content. This interface is how you communicate with or modify the Untiy content.
		
###Methods:


|    |    |
|:---|:---|
|getTextureFromNativeId(id : int) : TextureBase;|Enables retrieving of textures. A full example project using this can be found on the [forums](http://forum.unity3d.com/threads/128057-Flash-Simple-AS3-Bridge-Demo-Loading-textures-from-web.?p=864642&viewfull=1#post864642.md).|
|sendMessage(objectPath : String, methodName : String, value : Object = null) : Boolean;|The <span class=component>sendMessage</span> function can be used to call a method on an object in the Unity content.|
|setContentHost(contentHost : IUnityContentHost) : void;|Sets the host (which must implement <span class=component>IUnityContentHost</span>) for the Unity content. The host can then listen for when the Unity content has loaded/started.|
|setSize(width : int, height : int) : void;|Modifies the size of the Unity content|
|setPosition(x:int = 0, y:int = 0):void;|Enables you to reposition the Unity content within the content host.|
|startFrameLoop() : void;|Starts the Unity content.|
|stopFrameLoop() : void;|Stops the unity content.|
|forceUnload():void;|Unloads the Unity flash content.|

  

IUnityContentHost
-----------------


This must be implemented by whichever class will host the Unity content.

###Methods:


|    |    |
|:---|:---|
|unityInitComplete() : void;|Called when the Unity engine is done initializing and the first level is loaded.|
|unityInitStart() : void;|Called when the content is loaded and the initialization of the Unity engine is started.|

  

UnityContentLoader
------------------


The <span class=component>UnityContentLoader</span> class can be used to load Unity published Flash content and extends the AS3 [Loader](http://help.adobe.com/en_US/FlashPlatform/reference/actionscript/3/flash/display/Loader.html.md) class. As with standard AS3 Loader instances, you can add event listeners to its <span class=component>contentLoaderInfo</span> in order to know the progress of the load and when it is complete.


###Constructor:

````

UnityContentLoader(contentURL : String, contentHost : IUnityContentHost = null, params : UnityLoaderParams = null, autoLoad : Boolean = true) : void;

````

Creates a <span class=component>UnityContentLoader</span> instance which you can attach event listeners to and use to load the unity content.
* <span class=component>contentURL</span>: The URL of the Unity published SWF to load.
* <span class=component>contentHost</span>: The host for the content. This should be your own ActionScript class that implements <span class=component>IUnityContentHost</span>.
* <span class=component>params</span>: Supply a <span class=component>UnityLoaderParams</span> instance if you wish to override the default load details.
* <span class=component>autoLoad</span>: If set to true, the load will begin as soon as the <span class=component>UnityContentLoader</span> has been created (rather than needing to call <span class=component>loadUnity()</span> separately). If you wish to track progress of the load using events, this should be set to false. You can then call <span class=component>loadUnity()</span> manually once the relevant event listeners have been added.

###Accessible Properties:

|    |    |
|:---|:---|
|unityContent : IUnityContent;|Once the content has finished loading, you can access the Unity content to perform functionality such as <span class=component>sendMessage()</span>.|

###Methods:

|    |    |
|:---|:---|
|loadUnity() : void;|Instructs the <span class=component>UnityContentLoader</span> to load the Unity content from the URL supplied in the constructor.|
|forceUnload() : void;|Unloads the unity content from the host.|
|unload() : void;|Overrides the default unload() method of the AS3 [Loader](http://help.adobe.com/en_US/FlashPlatform/reference/actionscript/3/flash/display/Loader.html.md) class and calls forceUnload.|
|unloadAndStop(gc:Boolean = true):void|Unloads the unity content then calls the default Loader implementation of unloadAndStop(gc).|
  


UnityLoaderParams
-----------------


###Constructor:

Parameters can be supplied to the <span class=component>UnityContentLoader</span> when created to provide additional loader configuration.
	
````

function UnityLoaderParams(scaleToStage : Boolean = false, width : int = 640, height : int = 480, usePreloader : Boolean = false, autoInit : Boolean = true, catchGlobalErrors : Boolean = true) : void;

````

* <span class=component>scaleToStage</span>: Whether the Unity content remains at a fixed size or whether it scales as the parent Flash window resizes.
* <span class=component>width</span>: The width of the Unity content.
* <span class=component>height</span>: The height of the Unity content.
* <span class=component>usePreloader</span>: Whether or not to show the Unity preloader.
* <span class=component>autoInit</span>: This is not currently used.
* <span class=component>catchGlobalErrors</span>: Whether to catch errors and display them in a red box in the top left corner of the swf.
	
  


Example
-------


The following example shows how to load Unity published Flash content into a host SWF. It shows how to supply custom <span class=component>UnityLoaderParams</span> and track progress of the file load. Once the Unity content has been added to the host, a function in the Unity content is called using the <span class=component>sendMessage</span> function.

  
````

public class MyLoader extends Sprite implements IUnityContentHost
{
  private var unityContentLoader:UnityContentLoader;

  public function MyLoader()
  {
      var params:UnityLoaderParams = new UnityLoaderParams(false,720,400,false);
      unityContentLoader = new UnityContentLoader("UnityContent.swf", this, params, false);
      unityContentLoader.contentLoaderInfo.addEventListener(ProgressEvent.PROGRESS, onUnityContentLoaderProgress);
      unityContentLoader.contentLoaderInfo.addEventListener(Event.COMPLETE, onUnityContentLoaderComplete);
      unityContentLoader.loadUnity();
  }

  private function onUnityContentLoaderProgress(event:ProgressEvent):void
  {
      //Respond to load progress
  }
		
  private function onUnityContentLoaderComplete(event:Event):void
  {
     addChild(unityContentLoader);
     unityContentLoader.unityContent.setContentHost(this);
  }

  //unityInitStart has to be implemented by whatever implements IUnityContenthost
  //This is called when the content is loaded and the initialization of the unity engine is started.
  public function unityInitStart():void
  {
    //Unity engine started	
  }
	
  //unityInitComplete has to be implemented by whatever implements IUnityContenthost
  //This is called when the unity engine is done initializing and the first level is loaded.
  public function unityInitComplete():void
  {
     unityContentLoader.unityContent.sendMessage("Main Camera","SetResponder",{responder:this});
  }

  ...
  
}


````
