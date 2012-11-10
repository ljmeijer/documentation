How do I install or upgrade Standard Assets?
============================================


Unity ships with multiple <span class=keyword>Standard Assets</span> packages.  These are collections of assets that are widely used by most Unity customers.  When you create a new project from the Project Wizard you can optionally include these asset collections.  These assets are copied from the Unity install folder into your new project.  This means that if you upgrade Unity to a new version you will not get the new version of these assets and so upgrading them is needed.  Also, consider that a newer version of e.g. an effect might behave differently for performance or quality reasons and thus requires retweaking of parameters.  It's important to consider this before upgrading if you don't want your game to suddenly look or behave differently.  Check with the package contents and Unity's release notes.

Standard Assets contain useful things like a first person controller, skyboxes, lens flares, [Water prefabs](HOWTO-Water.md), [Image Effects](comp-ImageEffects.md) and so on.



![](http://docwiki.hq.unity3d.com/uploads/Main/HOWTO-InstallPackages.png)  
_The Standard Assets packages listed when creating new project_


Upgrading
---------


Sometimes you might want to upgrade your Standard Assets, for example because a new version of Unity ships with new Standard Assets:

1. Open your project.
1. Choose package you want to update from <span class=menu>Assets->Import Package</span> submenu.
1. A list of new or replaced assets will be presented, click <span class=menu>Import</span>.

For the cleanest possible upgrade, it should be considered to remove the old package contents first, as some scripts, effects or prefabs might have become deprecated or unneeded and Unity packages don't have a way of deleting (unneeded) files (but make sure to have a security copy of the old version available). 

