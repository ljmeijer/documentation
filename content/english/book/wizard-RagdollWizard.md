Ragdoll Wizard
==============


Unity has a simple wizard that lets you quickly create your own ragdoll. You simply have to drag the different limbs on the respective properties in the wizard. Then select create and Unity will automatically generate all <span class=keyword>Colliders</span>, <span class=keyword>Rigidbodies</span> and <span class=keyword>Joints</span> that make up the Ragdoll for you.


Creating the Character
----------------------


Ragdolls make use of <span class=keyword>Skinned Meshes</span>, that is a character mesh rigged up with bones in the 3D modeling application.  For this reason, you must build ragdoll characters in a 3D package like Maya or Cinema4D.

When you've created you character and rigged it, save the asset normally in your <span class=keyword>Project Folder</span>.  When you switch to Unity, you'll see the character asset file.  Select that file and the <span class=keyword>Import Settings</span> dialog will appear inside the inspector. Make sure that <span class=component>Mesh Colliders</span> is not enabled.


Using the Wizard
----------------


It's not possible to make the actual source asset into a ragdoll.  This would require modifying the source asset file, and is therefore impossible.  You will make an instance of the character asset into a ragdoll, which can then be saved as a <span class=keyword>Prefab</span> for re-use.

Create an instance of the character by dragging it from the <span class=keyword>Project View</span> to the <span class=keyword>Hierarchy View</span>.  Expand its <span class=keyword>Transform Hierarchy</span> by clicking the small arrow to the left of the instance's name in the Hierarchy.  Now you are ready to start assigning your ragdoll parts.

Open the Ragdoll Wizard by choosing <span class=menu>GameObject->Create Other->Ragdoll</span> from the menu bar.  You will now see the Wizard itself.


![](http://docwiki.hq.unity3d.com/uploads/Main/RagdollWizard.png)  
_The Ragdoll Wizard_

Assigning parts to the wizard should be self-explanatory.  Drag the different Transforms of your character instance to the appropriate property on the wizard.  This should be especially easy if you created the character asset yourself.

When you are done, click the <span class=menu>Create Button</span>.  Now when you enter <span class=keyword>Play Mode</span>, you will see your character go limp as a ragdoll.

The final step is to save the setup ragdoll as a Prefab.  Choose <span class=menu>Assets->Create->Prefab</span> from the menu bar.  You will see a New Prefab appear in the Project View.  Rename it to "Ragdoll Prefab". Drag the ragdoll character instance from the Hierarchy on top of the "Ragdoll Prefab".  You now have a completely set-up, re-usable ragdoll character to use as much as you like in your game.
