Preparing your own character
============================


__1. Model__ your own humanoid [mesh](Meshes) in a 3D package - 3DSMax, Maya, Blender, etc.

* Observe a __sensible topology__ - study character modeling techniques and use polygons only where you need them (for the flow of the static shape and also to allow for movement of joints)
* Observe the __scale__ of your mesh - compare with a "meter cube" and check your 3D package units and file units settings
* Put the character's feet __on the origin__
* Model in a __T-pose__ if you can. This will help allow space to refine polygon detail where you need it (e.g. underarms). This will also make it easier to position your rig inside the mesh.
* __Clean up your model__. Where possible, cap holes, weld verts and remove hidden faces, this will help with skinning, especially automated skinning processes

->Attach:SkinMesh256.png
->Skin Mesh - Modelled, textured and triangulated

__2. Rig__ - Create Skeleton

3D packages provide a number of ways to create joints for your humanoid rig, including ready-made biped skeletons that you can scale to fit your mesh, right through to individual bone creation and parenting to create your own bone structure. Although the details are outside the scope of Unity, here are some general guidelines:
* Study existing humanoid skeletons hierarchies (e.g. bipeds) and where possible use or mimic the bone structure
* Make sure the hips are the parent bone for your skeleton hierarchy
* 15 Bones minimum are required
* Respect a natural hierarchy for example:
    * HIPS - spine - chest - shoulders - arm - forearm - hand (name sensibly from arm - e.g. arm_L - forearm_L etc)
    * HIPS - spine - chest - neck - head
    * HIPS - UpLeg - Leg - foot - toe - toe_end

->Attach:Skeleton256.png
-> Biped Skeleton, positioned in T-pose

__3. Skin__ - Attach Mesh to Skeleton

This process involves binding vertices in your mesh to bones: directly (rigid bind) or with blended influence to a number of bones (soft bind). Various packages use different methods, e.g. assigning individual vertices and painting the weighting of influence per bone onto the mesh. The initial setup is typically automated, finding nearest influence or using "heatmaps". Skinning usually requires a fair amount of work and testing with animations, in order to ensure satisfactory results for the skin deformation when animating the skeleton. Some general guidelines would include:

* Use an automated process initially to set up some skinning (see relevant tutorials on 3DMax, Maya, etc.)
* Animate your rig or import some animation data, such as a character skinning test to evaluate the skinning
* Edit and refine your skinning solution
* If using a soft bind, stick to a max of 4 influences to accurately mirror Unity capabilities

->Attach:Skinning256.png
-> Interactive Skin Bind, one of many skinning methods

(back to [AssetPreparationandImport](AssetPreparationandImport))

(back to [Mecanim introduction](MecanimAnimationSystem))

