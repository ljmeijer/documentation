Text Mesh
=========


The <span class=keyword>Text Mesh</span> generates 3D geometry that displays text strings.


![](http://docwiki.hq.unity3d.com/uploads/Main/Inspector-TextMesh.png)  
_The Text Mesh <span class=keyword>Inspector</span>_

You can create a new Text Mesh from <span class=menu>GameObject->Create Other->3D Text</span>.


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Text</span> |The text that will be rendered |
|<span class=component>Offset Z</span> |How far should the text be offset from the transform.position.z when drawing |
|<span class=component>Character Size</span> |The size of each character (This scales the whole text) |
|<span class=component>Line Spacing</span> |How much space will be in-between lines of text. |
|<span class=component>Anchor</span> |Which point of the text shares the position of the Transform. |
|<span class=component>Alignment</span> |How lines of text are aligned (Left, Right, Center). |
|<span class=component>Tab Size</span> |How much space will be inserted for a tab '\t' character. This is a multiplum of the 'spacebar' character offset. |
|<span class=component>Font</span> |The [TrueType Font](class-Font.md) to use when rendering the text. |


Details
-------


Text Meshes can be used for rendering road signs, graffiti etc.  The Text Mesh places text in the 3D scene. To make generic 2D text for GUIs, use a [GUI Text](class-GuiText.md) component instead.

Follow these steps to create a Text Mesh with a custom Font:
1. Import a font by dragging a TrueType Font - a __.ttf__ file - from the Explorer (Windows) or Finder (OS X) into the <span class=keyword>Project View</span>.
1. Select the imported font in the Project View.
1. Choose <span class=menu>GameObject->Create Other->3D Text</span>.
You have now created a text mesh with your custom TrueType Font.  You can scale the text and move it around using the <span class=keyword>Scene View's</span> <span class=keyword>Transform</span> controls.

__Note:__ If you want to change the font for a Text Mesh, need to set the component's font property and also set the texture of the font material to the correct font texture. This texture can be located using the font asset's foldout. If you forget to set the texture then the text in the mesh will appear blocky and misaligned. 

Hints
-----

* When entering text into the <span class=component>Text</span> property, you can create a line break by holding <span class=menu>Alt</span> and pressing <span class=menu>Return</span>.
* You can download free TrueType Fonts from [1001freefonts.com](http://www.1001freefonts.com/fonts/afonts.htm.md) (download the Windows fonts since they contain TrueType Fonts).
* If you are scripting the <span class=component>Text</span> property, you can add line breaks by inserting the escape character "\n" in your strings.

