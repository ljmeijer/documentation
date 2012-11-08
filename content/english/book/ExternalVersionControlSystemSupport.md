Using External Version Control Systems with Unity
=================================================


Unity offers an [Asset Server](AssetServer.md) add-on product for easy integrated versioning of your projects. If you for some reason are not able use the Unity Asset Server, it is possible to store your project in any other version control system, such as Subversion, Perforce or Bazaar. This requires some initial manual setup of your project. 

Before checking your project in, you have to tell Unity to modify the project structure slightly to make it compatible with storing assets in an external version control system. This is done by selecting <span class=menu>Edit->Project Settings->Editor</span> in the application menu and enabling External Version Control support by selecting <span class=component>Metafiles</span> in the dropdown for Version Control. This will create a text file for every asset in the `Assets` directory containing the necessary bookkeeping information required by Unity. The files will have a `.meta` file extension with the first part being the full file name of the asset it is associated with. Moving and renaming assets within Unity should also update the relevant  `.meta` files. However, if you move or rename assets from an external tool, make sure to syncronize the relevant `.meta` files as well. 

When checking the project into a version control system, you should add the `Assets` and the `ProjectSettings` directories to the system. The `Library` directory should be completely ignored - when using external version control, it's only a local cache of imported assets.

When creating new assets, make sure both the asset itself and the associated `.meta` file is added to version control.

Example: Creating a new project and importing it to a Subversion repository.
----------------------------------------------------------------------------


First, let's assume that we have a subversion repository at `svn://my.svn.server.com/` and want to create a project at `svn://my.svn.server.com/MyUnityProject`.
Then follow these steps to create the initial import in the system:

1. Create a new project inside Unity and lets call it `InitialUnityProject`. You can add any initial assets here or add them later on.
1. Enable <span class=keyword>Meta files</span> in <span class=menu>Edit->Project Settings->Editor</span>
1. Quit Unity (We do this to assure that all the files are saved).
1. Delete the `Library` directory inside your project directory.
1. Import the project directory into Subversion. If you are using the command line client, this is done like this from the directory where your initial project is located:
`svn import -m"Initial project import" InitialUnityProject svn://my.svn.server.com/MyUnityProject`  
If successful, the project should now be imported into subversion and you can delete the `InitialUnityProject` directory if you wish.
1. Check out the project back from subversion
`svn co svn://my.svn.server.com/MyUnityProject`  
And check that the `Assets` and `ProjectSettings` directory are versioned.

1. Open the checked out project with Unity by launching it while holding down the <span class=keyword>Option</span> or the left <span class=keyword>Alt</span> key. Opening the project will recreate the `Library` directory in step 4 above.

1. __Optional:__ Set up an ignore filter for the unversioned `Library` directory:
`svn propedit svn:ignore MyUnityProject/`  
Subversion will open a text editor. Add the Library directory.

1. Finally commit the changes. The project should now be set up and ready:
`svn ci -m"Finishing project import" MyUnityProject`


