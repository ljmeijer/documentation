Analytics
=========


The Unity editor is configured to send anonymous usage data back to Unity.  This information is used to help improve the features of the editor.  The analytics are collected using Google Analytics.  Unity makes calls to a URI hosted by Google.  The URN part of the URI contains details that describe what editor features or events have been used.

Examples of collected data
--------------------------

The following are examples of data that Unity might collect.

__Which menu items have been used.__  If some menu items are used rarely or not at all we could in the future simplify the menuing system.

__Build times.__  By collecting how long builds take to make we can focus engineering effort on optimizing the correct code.

__Lightmap baking.__  Again, timing and reporting how long it takes for light maps to bake can help us decide how much effort to spend on optimizing this area.

Disabling Analytics
-------------------


If you do not want to send anonymous data to Unity then the sending of Analytics can be disabled.  To do this untick the box in the Unity Preferences General tab.


![](http://docwiki.hq.unity3d.com/uploads/Main/Editor-Analytics.png)  
_Editor analytics in the preferences pane._



