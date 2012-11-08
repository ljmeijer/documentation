Font
====


<span class=keyword>Fonts</span> can be created or imported for use in either the [GUI Text](class-GuiText.md) or the [Text Mesh](class-TextMesh.md) <span class=keyword>Components</span>.


Importing Font files
--------------------


To add a font to your project you need to place the font file in your Assets folder. Unity will then automatically import it. Supported Font formats are TrueType Fonts (.ttf or .dfont files) and OpenType Fonts (.otf files).

To change the <span class=component>Size</span> of the font, highlight it in the <span class=keyword>Project View</span> and you have a number of options in the <span class=keyword>Import Settings</span> in the <span class=keyword>Inspector</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/font_importer.png)  
_Import Settings for a font_


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Font Size</span>  |The size of the font, based on the sizes set in any word processor |
|<span class=component>Character</span> |The text encoding of the font.  You can force the font to display only upper- or lower-case characters here |
|               |Setting this mode to Dynamic causes Unity to use the underlying OS font rendering routines (see below).|
|<span class=component>2.x font placing</span> |Unity 3.x uses a more typographically correct vertical font placement compared to 2.x.  We now use the font  ascent stored in the truetype font data rather than computing it when we render the font texture.  Ticking this Property causes the 2.x vertical positioning to be used. |

_Import Settings specific to non-dynamic fonts_

|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Font Rendering</span>	|The amount of anti-aliasing applied to the font.|

_Import Settings specific to dynamic fonts_

|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Style</span>      |The styling applied to the font, one of Normal, Bold, Italic or BoldAndItalic. |
|<span class=component>Include Font Data</span> |This setting controls the packaging of the font when used with Dynamic font property.  When selected the TTF is included in the output of the build.  When not selected it is assumed that the end user will have the font already installed on their machine.  Note that fonts are subject to copyright and you should only include fonts that you have licensed or created for yourself. |
|<span class=component>Font Names</span> |Only available when Include Font Data is not selected.  Enter a comma-separated list of font names.  These fonts will be tried in turn from left to right and the first one found on the gamers machine will be used.  |

After you import the font, you can expand the font in Project View to see that it has auto-generated some assets.  Two assets are created during import: "font material" and "font texture".

Dynamic fonts
-------------


Unity 3.0 adds support for dynamic font rendering. When you set the <span class=component>Characters</span> drop-down in the Import Settings to <span class=component>Dynamic</span>, Unity will not pre-generate a texture with all font characters. Instead, it will use the FreeType font rendering engine to create the texture on the fly. This has the advantage that it can save in download size and texture memory, especially when you are using a font which is commonly included in user systems, so you don't have to include the font data, or when you need to support asian languages or large font sizes (which would make the font textures very large using normal font textures).

Unicode support
---------------

Unity has full unicode support. Unicode text allows you to display German, French, Danish or Japanese characters that are usually not supported in an ASCII character set. You can also enter a lot of different special purpose characters like arrow signs or the option key sign, if your font supports it.

To use unicode characters, choose either <span class=component>Unicode</span> or <span class=component>Dynamic</span> from the <span class=component>Characters</span> drop-down in the Import Settings.  You can now display unicode characters with this font.  If you are using a <span class=keyword>GUIText</span> or <span class=keyword>Text Mesh</span>, you can enter unicode characters into the Component's <span class=component>Text</span> field in the Inspector.  Note that the Inspector on Mac may not show the unicode characters correctly.

You can also use unicode characters if you want to set the displayed text from scripting.  The Javascript and C# compilers fully support Unicode based scripts. You simply have to save your scripts with UTF-16 encoding.  In <span class=keyword>Unitron</span>, this can be done by opening the script and choosing <span class=menu>Text->Text Encoding->Unicode (UTF 16)</span>.  Now you can add unicode characters to a string in your script and they will display as expected in <span class=keyword>UnityGUI</span>, a GUIText, or a Text Mesh.  On the PC where <span class=keyword>UniSciTE</span> is used for script editing save scripts using the UCS-2 Little Endian encoding.


Changing Font Color
-------------------


There are different ways to change the color of your displayed font, depending on how the font is used.


###GUIText & Text Mesh

If you are using a GUIText or a Text Mesh, you can change its color by using a custom <span class=keyword>Material</span> for the font. In the Project View, click on <span class=menu>Create->Material</span>, and select and set up the newly created Material in the <span class=keyword>Inspector</span>. Make sure you assign the texture from the font asset to the material. If you use the built-in <span class=component>GUI/Text Shader</span> shader for the font material, you can choose the color in the <span class=component>Text Color</span> property of the material.

###UnityGUI

If you are using UnityGUI scripting to display your font, you have much more control over the font's color under different circumstances.  To change the font's color, you create a <span class=keyword>GUISkin</span> from <span class=menu>Assets->Create->GUI Skin</span>, and define the color for the specific control state, e.g. <span class=menu>Label->Normal->Text Color</span>.  For more details, please read the [GUI Skin page](class-GUISkin.md).

Hints
-----

* To display an imported font select the font and choose <span class=menu>GameObject->Create Other->3D Text</span>.
* Using only lower or upper case characters reduces generated texture size.
* The default font that Unity supplies is Arial.  This font is always available and does not appear in the Project window.
