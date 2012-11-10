Audio Echo Filter (PRO only)
============================


The <span class=keyword>Audio Echo Filter</span> repeats a sound after a given <span class=component>Delay</span>, attenuating the repetitions based on the <span class=component>Decay Ratio</span>.  
The <span class=component>Wet Mix</span> determines the amplitude of the filtered signal, where the <span class=component>Dry Mix</span> determines the amplitude of the unfiltered sound output.


![](http://docwiki.hq.unity3d.com/uploads/Main/AudioEchoFilter.png)  
_The <span class=keyword>Audio Echo Filter</span> properties in the inspector._


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Delay</span> |Echo delay in ms. 10 to 5000. Default = 500.|
|<span class=component>Decay Ratio</span> |Echo decay per delay. 0 to 1. 1.0 = No decay, 0.0 = total decay (ie simple 1 line delay). Default = 0.5.L|
|<span class=component>Wet Mix</span> |Volume of echo signal to pass to output. 0.0 to 1.0. Default = 1.0.|
|<span class=component>Dry Mix</span> |Volume of original signal to pass to output. 0.0 to 1.0. Default = 1.0.|



Adding an Echo filter
---------------------

To add an Echo filter to a given audio source just select the object in the inspector and then select <span class=component>Component->Audio->Audio Echo Filter</span>.

Hints
-----

* Hard surfaces reflects the propagation of sound. For example a large canyon can be made more convincing with the <span class=keyword>Audio Echo Filter</span>.
* Sound propagates slower than light - we all know that from lightning and thunder. To simulate this, add an <span class=keyword>Audio Echo Filter</span> to an event sound, set the <span class=component>Wet Mix</span> to 0.0 and modulate the <span class=component>Delay</span> to the distance between [AudioSource](class-AudioSource.md) and [AudioListener](class-AudioListener.md).
