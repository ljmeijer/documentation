Project Browser
===============


In this view, you can access and manage the assets that belong to your project.


![](http://docwiki.hq.unity3d.com/uploads/Main/ProjectBrowser.png)  

The left panel of the browser shows the folder structure of the project as a hierarchical list. When a folder is selected from the list by clicking, its contents will be shown in the panel to the right. The individual assets are shown as icons that indicate their type (script, material, sub-folder, etc). The icons can be resized using the slider at the bottom of the panel; they will be replaced by a hierarchical list view if the slider is moved to the extreme left. The space to the left of the slider shows the currently selected item, including a full path to the item if a search is being performed. 

Above the project structure list is a __Favorites__ section where you can keep frequently-used items for easy access. You can drag items from the project structure list to the Favourites and also save search queries there (see __Searching__ below).

Just above the panel is a "breadcrumb trail" that shows the path to the folder currently being viewed. The separate elements of the trail can be clicked for easy navigation around the folder hierarchy. When searching, this bar changes to show the area being searched (the root Assets folder, the selected folder or the Asset Store) along with a count of free and paid assets available in the store, separated by a slash. There is an option in the _General_ section of Unity's Preferences window to disable the display of Asset Store hit counts if they are not required.


![](http://docwiki.hq.unity3d.com/uploads/Main/ProjBrowserBreadcrumbs.png)  

Along the top edge of the window is the browser's toolbar.


![](http://docwiki.hq.unity3d.com/uploads/Main/ProjBrowserToolbar.png)  

Located at the left side of the toolbar, the <span class=menu>Create</span> menu lets you add new assets and sub-folders to the current folder. To its right are a set of tools to allow you to search the assets in your project.

The Window menu provides the option of switching to a one-column version of the project view, essentially just the hierarchical structure list without the icon view. The lock icon next to the menu enables you to "freeze" the current contents of the view (ie, stop them being changed by events elsewhere) in a similar manner to the inspector lock.

Searching
---------

The browser has a powerful search facility that is especially useful for locating assets in large or unfamiliar projects. The basic search will filter assets according to the text typed in the search box


![](http://docwiki.hq.unity3d.com/uploads/Main/ProjBrowserSearchBasic.png)  

If you type more than one search term then the search is narrowed, so if you type _coastal scene_ it will only find assets with both "coastal" and "scene" in the name (ie, terms are ANDed together).

To the right of the search bar are three buttons. The first allows you to further filter the assets found by the search according to their type.


![](http://docwiki.hq.unity3d.com/uploads/Main/ProjBrowserTypeMenu.png)  

Continuing to the right, the next button filters assets according to their Label (labels can be set for an asset in the Inspector). Since the number of labels can potentially be very large, the label menu has its own mini-search filter box.


![](http://docwiki.hq.unity3d.com/uploads/Main/ProjBrowserLabelMenu.png)  

Note that the filters work by adding an extra term in the search text. A term beginning with "t:" filters by the specified asset type, while "l:" filters by label. You can type these terms directly into the search box rather than use the menu if you know what you are looking for. You can search for more than one type or label at once. Adding several types will expand the search to include all specified types (ie, types will be ORed together). Adding multiple labels will narrow the search to items that have all the specified labels (ie, labels are ANDed).


![](http://docwiki.hq.unity3d.com/uploads/Main/ProjBrowserSearchTypeAndLabel.png)  

The rightmost button saves the search by adding an item to the Favourites section of the asset list.

###Searching the Asset Store

The Project Browser's search can also be applied to assets available from the Unity <span class=keyword>Asset Store</span>. If you choose <span class=menu>Asset Store</span> from the menu in the breadcrumb bar, all free and paid items from the store that match your query will be displayed. Searching by type and label works the same as for a Unity project. The search query words will be checked against the asset name first and then the package name, package label and package description in that order (so an item whose name contains the search terms will be ranked higher than one with the same terms in its package description).


![](http://docwiki.hq.unity3d.com/uploads/Main/ProjBrowserAssetStoreSearch.png)  

If you select an item from the list, its details will be displayed in the inspector along with the option to purchase and/or download it. Some asset types have previews available in this section so you can, for example, play an audio clip or rotate a 3D model before buying. The inspector also gives the option of viewing the asset in the usual Asset Store window to see additional details.



Shortcuts
---------


The following keyboard shortcuts are available when the browser view has focus. Note that some of them only work when the view is using the two-column layout (you can switch between the one- and two-column layouts using the panel menu in the very top right corner).


|    |    |
|:---|:---|
|__F__ |Frame selection |
|__Tab__ |Shift focus between first column and second column  (Two columns)|
|__Ctrl/Cmd + F__ |Focus search field|
|__Ctrl/Cmd + A__ |Select all visible items in list|
|__Ctrl/Cmd + D__ |Duplicate selected assets|
|__Delete__ |Delete with dialog|
|__Delete + Shift__ |Delete without dialog|
|__Backspace + Cmd__ |Delete without dialogs (OSX)|
|__Enter__ |Begin rename selected (OSX)|
|__Cmd + down arrow__ |Open selected assets (OSX)|
|__Cmd + up arrow__ |Jump to parent folder (OSX, Two columns)|
|__F2__ |Begin rename selected (Win)|
|__Enter__ |Open selected assets (Win)|
|__Backspace__ |Jump to parent folder (Win, Two columns)|
|__Right arrow__ |Expand selected item (tree views and search results). If the item is already expanded, this will select its first child item. |
|__Left arrow__ |Collapse selected item (tree views and search results). If the item is already collapsed, this will select its parent item. |
|__Alt + right arrow__ |Expand item when showing assets as previews |
|__Alt + left arrow__ |Collapse item when showing assets as previews |
