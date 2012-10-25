Project Browser
===============


In this view, you can access and manage the assets that belong to your project.

![](http://docwiki.hq.unity3d.com/uploads/Main/ProjectBrowser.png)  

The left panel of the browser shows the folder structure of the project as a hierarchical list. When a folder is selected from the list by clicking, its contents will be shown in the panel to the right. The individual assets are shown as icons that indicate their type (script, material, sub-folder, etc). The icons can be resized using the slider at the bottom of the panel.

Just above the panel is a "breadcrumb trail" that shows the path to the folder currently being viewed. The separate elements of the trail can be clicked for easy navigation around the folder hierarchy.

![](http://docwiki.hq.unity3d.com/uploads/Main/ProjBrowserBreadcrumbs.png)  

Toolbar
-------


Along the top edge of the window is the browser's toolbar.

![](http://docwiki.hq.unity3d.com/uploads/Main/ProjBrowserToolbar.png)  

To the left, the Create menu lets you add new assets and sub-folders to the current folder. To the right are a set of tools to allow you to search the assets in your project.

###Searching the project
The browser has a powerful search facility that is especially useful for locating assets in large or unfamiliar projects. The basic search will filter assets according to the text typed in the search box

![](http://docwiki.hq.unity3d.com/uploads/Main/ProjBrowserSearchBasic.png)  

You will notice that the breadcrumb trail changes to a menu that determines where the search takes place. This can be the root Assets folder or the folder that was selected when the search text was typed (including all sub-folders). Additionally, you can use the same search mechanism to look for applicable items for purchase on the Unity Asset Store.

If you type more than one search term then the search is narrowed, so if you type _coastal scene_ it will only find assets with both "coastal" and "scene" in the name.

To the right of the search bar are three buttons. The first allows you to further filter the assets found by the search according to their type.

![](http://docwiki.hq.unity3d.com/uploads/Main/ProjBrowserTypeMenu.png)  

Continuing to the right, the next button filters assets according to their Label (labels can be set for an asset in the Inspector). Since the number of labels can potentially be very large, the label menu has its own mini-search filter box.

![](http://docwiki.hq.unity3d.com/uploads/Main/ProjBrowserLabelMenu.png)  

Note that the filters work by adding an extra term in the search text. A term beginning with "t:" filters by the specified asset type, while "l:" filters by label. You can type these terms directly into the search box rather than use the menu if you know what you are looking for. You can search for more than one type or label at once. Adding several types will expand the search to include all specified types. Adding multiple labels will narrow the search to items that have all the specified labels.

![](http://docwiki.hq.unity3d.com/uploads/Main/ProjBrowserSearchTypeAndLabel.png)  

The rightmost button saves the search by adding an item to the Favourites section of the asset list.


Shortcuts
---------


The following keyboard shortcuts are available when the browser view has focus. Note that some of them only work when the view is using the two-column layout (you can switch between the one- and two-column layouts using the panel menu in the very top right corner).

||__Tab__ ||Shift focus between first column and second column  (Two columns)||
||__Ctrl/Cmd + F__ ||Focus search field||
||__Ctrl/Cmd + A__ ||Select all visible items in list||
||__Ctrl/Cmd + D__ ||Duplicate selected assets||
||__Delete__ ||Delete with dialog||
||__Delete + Shift__ ||Delete without dialog||
||__Backspace + Cmd__ ||Delete without dialogs (OSX)||
||__Enter__ ||Begin rename selected (OSX)||
||__Cmd + down arrow__ ||Open selected assets (OSX)||
||__Cmd + up arrow__ ||Jump to parent folder (OSX, Two columns)||
||__F2__ ||Begin rename selected (Win)||
||__Enter__ ||Open selected assets (Win)||
||__Backspace__ ||Jump to parent folder (Win, Two columns)||

