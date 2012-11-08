Building Your First Tree
========================


We'll now walk you through the creation of your first Tree Creator Tree in Unity.  First, make sure you have included the tree creator package in your project. If you don't, select <span class=menu>Assets->Import Package...</span>, navigate to your Unity installation folder, and open the folder named _Standard Packages_. Select the _Tree Creator.unityPackage_ package to get the needed assets into your project.

Adding a new Tree
-----------------

To create a new <span class=keyword>Tree</span> asset, select <span class=menu>GameObject->Create Other->Tree</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeCreator-CreatingBasic.png)  

You'll see a new Tree asset is created in your Project View, and instantiated in the currently open Scene. This new Tree is very basic with only a single branch, so let's add some character to it.

Adding Branches
---------------



![](http://docwiki.hq.unity3d.com/uploads/Main/TreeCreator-BasicBranch.png)  
_A brand new tree in your scene_

Select the tree to view the <span class=keyword>Tree Creator</span> in the <span class=keyword>Inspector</span>.  This interface provides all the tools for shaping and sculpting your trees. You will see the <span class=keyword>Tree Hierarchy</span> with two nodes present: the <span class=keyword>Tree Root</span> node and a single <span class=keyword>Branch Group</span> node, which we'll call the trunk of the tree.



In the <span class=keyword>Tree Hierarchy</span>, select the <span class=keyword>Branch Group</span>, which acts as the trunk of the tree. Click on the <span class=keyword>Add Branch Group</span> button and you'll see a new <span class=keyword>Branch Group</span> appear connected to the Main Branch. Now you can play with the settings in the <span class=keyword>Branch Group Properties</span> to see alterations of the branches attached to the tree trunk.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeCreator-AddingBranches1.png)  
_Adding branches to the tree trunk._

After creating the branches that are attached to the trunk, we can now add smaller twigs to the newly created branches by attaching another <span class=keyword>Branch Group</span> node. Select the secondary <span class=keyword>Branch Group</span> and click the <span class=keyword>Add Branch Group</span> button again. Tweak the values of this group to create more branches that are attached to the secondary branches.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeCreator-AddingBranches2.png)  
_Adding branches to the secondary branches._

Now the tree's branch structure is in place.  Our game doesn't take place in the winter time, so we should also add some <span class=keyword>Leaves</span> to the different branches, right?

Adding Leaves
-------------


We decorate our tree with leaves by adding <span class=keyword>Leaf Groups</span>, which basically work the same as the Branch groups we've already used.  Select your secondary Branch Group node and then click the <span class=keyword>Add Leaf Group</span> button.  If you're really hardcore, you can add another leaf group to the tiniest branches on the tree as well.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeCreator-AddingLeaves.png)  
_Leaves added to the secondary and smallest branches_

Right now the leaves are rendered as opaque planes. This is because we want to adjust the leaves' values (size, position, rotation, etc.) before we add a material to them. Tweak the Leaf values until you find some settings you like.

Adding Materials
----------------

In order to make our tree realistic looking, we need to apply <span class=keyword>Materials</span> for the branches and the leaves. Create a new Material in your project using ^Assets->Create->Material<span class=menu>.  Rename it to "My Tree Bark", and choose </span>Nature->Tree Creator Bark^^ from the Shader drop-down. From here you can assign the <span class=keyword>Textures</span> provided in the Tree Creator Package to the Base, Normalmap, and Gloss properties of the Bark Material.  We recommend using the texture "BigTree_bark_diffuse" for the Base and Gloss properties, and "BigTree_bark_normal" for the Normalmap property.

Now we'll follow the same steps for creating a Leaf Material.  Create a new Material and assign the shader as <span class=menu>Nature->Tree Creator Leaves</span>.  Assign the texture slots with the leaf textures from the Tree Creator Package.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeCreator-LeavesMaterial.png)  
_Material for the Leaves_

When both Materials are created, we'll assign them to the different Group Nodes of the Tree.  Select your Tree and click any Branch or Leaf node, then expand the <span class=keyword>Geometry</span> section of the <span class=keyword>Branch Group Properties</span>. You will see a Material assignment slot for the type of node you've selected.  Assign the relevant Material you created and view the results.


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeCreator-AddingMaterialToLeaves.png)  
_Setting the leaves material_

To finish off the tree, assign your Materials to all the <span class=keyword>Branch</span> and <span class=keyword>Leaf Group</span> nodes in the Tree.  Now you're ready to put your first tree into a game!


![](http://docwiki.hq.unity3d.com/uploads/Main/TreeCreator-FinalTree.png)  
_Tree with materials on leaves and branches._

Hints.
------

* Creating trees is a trial and error process.
* Don't create too many leaves/branches as this can affect the performance of your game.
* Check the [alpha maps](HOWTO-alphamaps.md) guide for creating custom leaves.

