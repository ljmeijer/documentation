Asset Import and Creation
=========================


A large part of making a game is utilizing your asset source files in your <span class=keyword>GameObjects</span>. This goes for textures, models, sound effects and behaviour scripts. Using the <span class=keyword>Project View</span> inside Unity, you have quick access to all the files that make up your game:


![](http://docwiki.hq.unity3d.com/uploads/Main/Editor-Project.png)  
_The Project View displays all source files and created <span class=keyword>Prefabs</span>_

This view shows the organization of files in your project's Assets folder. Whenever you update one of your asset files, the changes are immediately reflected in your game!

To import an asset file into your project, move the file into <span class=menu>(your Project folder)->Assets</span> in the Finder, and it will automatically be imported into Unity. To apply your assets, simply drag the asset file from the Project View window into the <span class=keyword>Hierarchy</span> or <span class=keyword>Scene View</span>.  If the asset is meant to be applied to another object, drag the asset over the object.



Hints
-----

* It is always a good idea to add labels to your assets when you are working with big projects or when you want to keep organized all your assets, with this you can search for the labels associated to each asset in the _search field_ in the project view.
* When backing up a project folder __always__ back up _Assets_, _ProjectSettings_ and _Library_ folders. The Library folder contains all meta data and all the connections between objects, thus if the Library folder gets lost, you will lose references from scenes to assets. Easiest is just to back up the whole project folder containing the Assets, ProjectSettings and Library folders.
* Rename and move files to your heart's content inside Project View; nothing will break.
* __Never__ rename or move anything from the Finder or another program; everything will break. In short, Unity stores lots of metadata for each asset (things like import settings, cached versions of compressed textures, etc.) and if you move a file externally, Unity can no longer associate metadata with the moved file.

Continue reading for more information:

(:tocportion:)

