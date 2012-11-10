Audio High Pass Filter (PRO only)
=================================


The <span class=keyword>Audio High Pass Filter</span> passes high frequencies of an AudioSource and cuts off signals with frequencies lower than the <span class=component>Cutoff Frequency</span>.  
The <span class=component>Highpass resonance Q</span> (known as Highpass Resonance Quality Factor) determines how much the filter's self-resonance is dampened. Higher <span class=component>Highpass resonance Q</span> indicates a lower rate of energy loss i.e. the oscillations die out more slowly.


![](http://docwiki.hq.unity3d.com/uploads/Main/AudioHighPassFilter.png)  
_The Audio high Pass filter properties in the inspector._


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Cutoff Frequency</span> |Highpass cutoff frequency in hz. 10.0 to 22000.0. Default = 5000.0.|
|<span class=component>Highpass Resonance Q</span> |Highpass resonance Q value. 1.0 to 10.0. Default = 1.0.|


Adding a high pass filter
-------------------------

To add a high pass filter to a given audio source just select the object in the inspector and then select <span class=component>Component->Audio->Audio High Pass Filter</span>.
