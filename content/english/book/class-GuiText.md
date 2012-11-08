GUI Text
========


<span class=keyword>GUI Text</span> displays text of any font you import in screen coordinates.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-GUIText.png)  
_The GUI Text <span class=keyword>Inspector</span>_

__Please Note__: Unity 2.0 introduced <span class=keyword>UnityGUI</span>, a GUI Scripting system.  You may prefer creating user interface elements with UnityGUI instead of GUI Texts.  Read more about how to use UnityGUI in the [GUI Scripting Guide](GUIScriptingGuide.md).


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Text</span>     |The string to display. |
|<span class=component>Anchor</span>   |The point at which the <span class=component>Text</span> shares the position of the <span class=keyword>Transform</span>. |
|<span class=component>Alignment</span>    |How multiple lines are aligned within the <span class=keyword>GUIText</span>. |
|<span class=component>Pixel Offset</span> |Offset of the text relative to the position of the GUIText in the screen.|
|<span class=component>Line Spacing</span> |How much space will be in-between lines of <span class=component>Text</span>. |
|<span class=component>Tab Size</span> |How much space will be inserted for a tab ('\t') character. As a multiplum of the space character offset. |
|<span class=component>Font</span>     |The [Font](class-Font.md) to use when rendering the text. |
|<span class=component>Material</span> |Reference to the <span class=keyword>Material</span> containing the characters to be drawn. If set, this property overrides the one in the [Font](class-Font.md) asset. |
|<span class=component>Pixel Correct</span> |If enabled, all <span class=component>Text</span> characters will be drawn in the size of the imported font texture. If disabled, the characters will be resized based on the Transform's <span class=component>Scale</span>. |


Details
-------


GUI Texts are used to print text onto the screen in 2D. The <span class=keyword>Camera</span> has to have a [GUI Layer](class-GUILayer.md) attached in order to render the text.  Cameras include a GUI Layer by default, so don't remove it if you want to display a GUI Text.  GUI Texts are positioned using only the X and Y axes.  Rather than being positioned in World Coordinates, GUI Texts are positioned in Screen Coordinates, where (0,0) is the bottom-left and (1,1) is the top-right corner of the screen

To import a font see the [Font page](class-Font.md).


###Pixel Correct

By default, GUI Texts are rendered with <span class=component>Pixel Correct</span> enabled. This makes them look crisp and they will stay the same size in pixels independent of the screen resolution.

Hints
-----

* When entering text into the <span class=component>Text</span> property, you can create a line break by holding <span class=menu>Alt</span> and pressing <span class=menu>Return</span>.
* If you are scripting the <span class=component>Text</span> property, you can add line breaks by inserting the escape character "\n" in your strings.
* You can download free true type fonts from [1001freefonts.com](http://www.1001freefonts.com/fonts/afonts.htm.md) (download the Windows fonts since they contain TrueType fonts).
