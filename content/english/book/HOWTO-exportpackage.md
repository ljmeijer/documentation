How do I reuse assets between projects?
=======================================


As you build your game, Unity stores a lot of metadata about your assets (import settings, links to other assets, etc.). If you want to take your assets into a different project, there is a specific way to do that.  Here's how to easily move assets between projects and still preserve all this info.

1. In the <span class=keyword>Project View</span>, select all the asset files you want to export.
1. Choose <span class=menu>Assets->Export Package...</span> from the menubar.
1. Name and save the package anywhere you like.
1. Open the project you want to bring the assets into.
1. Choose <span class=menu>Assets->Import Package...</span> from the menubar.
1. Select your package file saved in step 3.


Hints
-----


* When exporting a package Unity can export all dependencies as well. So for example if you select a <span class=keyword>Scene</span> and export a package with all dependencies, then all models, textures and other assets that appear in the scene will be exported as well.  This can be a quick way of exporting a bunch of assets without manually locating them all.
* If you store your Exported Package in the Standard Packages folder next to your Unity application, they will appear in the <span class=component>Create New Project</span> dialog.
