Color Correction Lookup Texture
===============================


<span class=keyword>Color Correction Lut</span> (<span class=component>Lut</span> stands for _lookup texture_) is an optimized way of performing color grading in a post effect. Instead of tweaking the individual color channels via curves as in [Color Correction Curves](script-ColorCorrectionCurves.md), only a single texture is used to produce the corrected image. The lookup will be performed by using the original image color as a vector that is used to address the lookup texture.

Advantages include better performance and more professional workflow opportunities, where all color transforms can be defined in professional image manipulation software (such as Photoshop or Gimp) and thus a more precise result can be achieved.


![](http://docwiki.hq.unity3d.com/uploads/Main/NeutralLutExample2.png)  
_Simple scene with neutral color correction applied._


![](http://docwiki.hq.unity3d.com/uploads/Main/ContrastEnhancedLutExample2.png)  
_Same scene using the included "ContrastEnhanced" lookup texture._

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Based On</span> |A 2D representation of the 3D lookup texture that will be used to generate the corrected image. |

Lookup Texture Requirements
---------------------------


The 2D texture representation is required to be laid out in a certain way that it represents an unwrapped volume texture (imagine an image sequence of "depth slices").

The following image shows an example of such an unwrapped texture which effectively enhances image contrast. It should be included in the standard packages.


![](http://docwiki.hq.unity3d.com/uploads/Main/3DUnwrappedContrastEnhance.png)  
_The image shows a texture of the dimension 256x16, yielding a 16x16x16 color lookup texture (lut). If the resulting quality is too low, a 1024x32 texture  might yield better results (at the cost of memory)._

Texture importer requirements include enabling Read/Write support and disabling texture compression. Otherwise, unwanted image artifcats will likely occur.

Example Workflow
----------------


Always keep the basic neutral lookup texture (lut) ready as this will be the basis for generating all other corrective lut's.

* Take a screenshot of your game

* Import into e.g. Photoshop and apply color adjustments (such as contrast, brightness, color levels adjustments) until a satisfying result has been reached

* Perform the same steps to the neutral lut and save as a new lut

* Assign new lut to the effect and hit <span class=component>Convert & Apply</span>

(:include imagefx-SM3:)
