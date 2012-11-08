Asset Workflow
==============


Here we'll explain the steps to use a single asset with Unity.  These steps are general and are meant only as an overview for basic actions.  For the example, we'll talk about using a 3D mesh.


Create Rough Asset
------------------


Use any supported 3D modeling package to create a rough version of your asset.  Our example will use Maya.  Work with the asset until you are ready to save. For a list of applications that are supported by Unity, please see [this page](HOWTO-importObject.md).


Import
------


When you save your asset initially, you should save it normally to the <span class=keyword>Assets</span> folder in your Project folder.  When you open the Unity project, the asset will be detected and imported into the project.  When you look in the <span class=keyword>Project View</span>, you'll see the asset located there, right where you saved it. Please note that Unity uses the FBX exporter provided by your modeling package to convert your models to the FBX file format. You will need to have the FBX exporter of your modeling package available for Unity to use. Alternatively, you can directly export as FBX from your application and save in the Projects folder. For a list of applications that are supported by Unity, please see [this page](HOWTO-importObject.md).


Import Settings
---------------


If you select the asset in the <span class=keyword>Project View</span> the import settings for this asset will appear in the <span class=keyword>Inspector</span>. The options that are displayed will change based on the type of asset that is selected.


Adding Asset to the Scene
-------------------------


Simply click and drag the mesh from the Project View to the <span class=keyword>Hierarchy</span> or <span class=keyword>Scene View</span> to add it to the Scene.  When you drag a mesh to the scene, you are creating a <span class=keyword>GameObject</span> that has a <span class=component>Mesh Renderer</span> <span class=keyword>Component</span>.  If you are working with a texture or a sound file, you will have to add it to a GameObject that already exists in the Scene or Project.


Putting Different Assets Together
---------------------------------


Here is a brief description of the relationships between the most common assets

* A Texture is applied to a <span class=keyword>Material</span>
* A Material is applied to a GameObject (with a Mesh Renderer Component)
* An <span class=component>Animation</span> is applied to a GameObject (with an Animation Component)
* A sound file is applied to a GameObject (with an <span class=component>Audio Source</span> Component)


Creating a Prefab
-----------------


<span class=keyword>Prefabs</span> are a collection of GameObjects & Components that can be re-used in your scenes.  Several identical objects can be created from a single Prefab, called instancing.  Take trees for example.  Creating a tree Prefab will allow you to instance several identical trees and place them in your scene.  Because the trees are all linked to the Prefab, any changes that are made to the Prefab will automatically be applied to all tree instances.  So if you want to change the mesh, material, or anything else, you just make the change once in the Prefab and all the other trees inherit the change.  You can also make changes to an instance, and choose <span class=menu>GameObject->Apply Changes to Prefab</span> from the main menu.  This can save you lots of time during setup and updating of assets.

When you have a GameObject that contains multiple Components and a hierarchy of child GameObjects, you can make a Prefab of the top-level GameObject (or <span class=keyword>root</span>), and re-use the entire collection of GameObjects.

Think of a Prefab as a blueprint for a structure of GameObjects.  All the Prefab clones are identical to the blueprint.  Therefore, if the blueprint is updated, so are all the clones.  There are different ways you can update the Prefab itself by changing one of its clones and applying those changes to the blueprint.  To read more about using and updating Prefabs, please view the [Prefabs](Prefabs.md) page.

To actually create a Prefab from a GameObject in your scene, simply drag the GameObject from the scene into the project, and you should see the Game Object's name text turn blue. Name the new Prefab whatever you like. You have now created a re-usable prefab.

Updating Assets
---------------


You have imported, instantiated, and linked your asset to a Prefab.  Now when you want to edit your source asset, just double-click it from the Project View.  The appropriate application will launch, and you can make any changes you want.  When you're done updating it, just Save it.  Then, when you switch back to Unity, the update will be detected, and the asset will be re-imported.  The asset's link to the Prefab will also be maintained.  So the effect you will see is that your Prefab will update.  That's all you have to know to update assets.  Just open it and save!
<a id="AssetLabels"></a>
Optional - Adding Labels to the Assets.
---------------------------------------

Is always a good idea to add labels to your assets if you want to keep organized all your assets, with this you can search for the labels associated to each asset in the search field in the project view or in the object selector.

Steps for adding a label to an asset:
* Select the asset you want to add the label to (From the project view).
* In the inspector click on the "Add Label" icon (Attach:AssetLabelAdd.png) if you dont have any Labels associated to that asset.
    * If you have a label associated to an asset then just click where the labels are.
* Start writing your labels.

__Notes:__
* You can have more than one label for any asset.
* To separate/create labels, just press __space__ or __enter__ when writing asset label names.

