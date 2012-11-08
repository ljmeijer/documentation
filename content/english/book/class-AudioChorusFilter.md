Audio Chorus Filter (PRO only)
==============================


The <span class=keyword>Audio Chorus Filter</span> takes an [Audio Clip](class-AudioClip.md) and processes it creating a chorus effect. 

The chorus effect modulates the original sound by a sinusoid low frequency oscillator (LFO).  The output sounds like there are multiple sources emitting the same sound with slight variations - resembling a choir.


![](http://docwiki.hq.unity3d.com/uploads/Main/AudioChorusFilter.png)  
_The Audio high Pass filter properties in the inspector._


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Dry Mix</span> |Volume of original signal to pass to output. 0.0 to 1.0. Default = 0.5.|
|<span class=component>Wet Mix 1</span> |Volume of 1st chorus tap. 0.0 to 1.0. Default = 0.5.|
|<span class=component>Wet Mix 2</span> |Volume of 2nd chorus tap. This tap is 90 degrees out of phase of the first tap. 0.0 to 1.0. Default = 0.5.|
|<span class=component>Wet Mix 3</span> |Volume of 3rd chorus tap. This tap is 90 degrees out of phase of the second tap. 0.0 to 1.0. Default = 0.5.|
|<span class=component>Delay</span> |The LFO's delay in ms. 0.1 to 100.0. Default = 40.0 ms|
|<span class=component>Rate</span> |The LFO's modulation rate in Hz. 0.0 to 20.0. Default = 0.8 Hz.|
|<span class=component>Depth</span> |Chorus modulation depth. 0.0 to 1.0. Default = 0.03.|
|<span class=component>Feed Back</span> |Chorus feedback. Controls how much of the wet signal gets fed back into the filter's buffer. 0.0 to 1.0. Default = 0.0.|

Adding a chorus filter
----------------------

To add a chorus filter to a given audio source just select the object in the inspector and then select <span class=component>Component->Audio->Audio Chorus Filter</span>.

Hints
-----

* You can tweak the chorus filter to create a flanger effect by lowering the feedback and decreasing the delay, as the flanger is a variant of the chorus.
* Creating a simple, dry echo is done by setting <span class=component>Rate</span> and <span class=component>Depth</span> to 0 and tweaking the mixes and <span class=component>Delay</span>
