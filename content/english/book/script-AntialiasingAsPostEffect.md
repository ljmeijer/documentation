Antialiasing (PostEffect)
=========================


The <span class=keyword>Antialiasing (PostEffect)</span> offers a set of algorithms designed to give a smoother appearance to graphics. When two areas of different colour adjoin in an image, the shape of the pixels can form a very distinctive "staircase" along the boundary. This effect is known as <span class=component>aliasing</span> and hence antialiasing refers to any measure which reduces the effect.


![](http://docwiki.hq.unity3d.com/uploads/Main/AAComparison.png)  
<span class=component>The cube on the left is rendered without antialiasing while the one on the right shows the effect of the FXAA1PresetB algorithm</span>

The antialiasing algorithms are image based, which is very useful for deferred rendering where traditional multisampling is not properly supported. 
The algorithms currently supported are NVIDIA's FXAA, FXAA II, FXAA III (tweakable and console optimized), simpler edge blurs (NFAA, SSAA) that blur only local edges and an adaption of the DLAA algorithm that also addresses long edges. SSAA is the fastest technique, followed by NFAA, FXAAII, FXAA II, DLAA and the the other FXAA's. Typically, the quality of antialiasing trades off against the speed of the algorithm but there may be situations where the choice of algorithm makes little difference.

For those especially interested in console and NaCl deployment, the optimized <span class=component>FXAA III</span> implementation offers the best tradeoff between quality and performance and can furthermore be tweaked towards sharper or blurrier looks.

As with the other [image effects](comp-ImageEffects.md), this effect is only available in Unity Pro and you must have the [Pro Standard Assets](HOWTO-InstallStandardAssets.md) installed before it becomes available.

Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>AA Technique</span> |The algorithm to be used. |

(:include imagefx-SM3:)

