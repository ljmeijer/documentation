Audio Low Pass Filter (PRO only)
================================


The <span class=keyword>Audio Low Pass Filter</span> filter passes low frequencies of an [AudioSource](class-AudioSource.md), or all sound reaching an [AudioListener](class-AudioListener.md), and cuts frequencies higher than the <span class=component>Cutoff Frequency</span>.  
The <span class=component>Lowpass Resonance Q</span> (known as Lowpass Resonance Quality Factor) determines how much the filter's self-resonance is dampened. Higher <span class=component>Lowpass Resonance Q</span> indicates a lower rate of energy loss i.e. the oscillations die out more slowly.  
The <span class=keyword>Audio Low Pass Filter</span> has a Rolloff curve associated with it, making it possible to set <span class=component>Cutoff Frequency</span> over distance between the AudioSource and the AudioListener.


![](http://docwiki.hq.unity3d.com/uploads/Main/AudioLowPassFilter.png)  
_The Audio Low Pass filter properties in the inspector._


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Cutoff Frequency</span> |Lowpass cutoff frequency in hz. 10.0 to 22000.0. Default = 5000.0.|
|<span class=component>Lowpass Resonance Q</span> |Lowpass resonance Q value. 1.0 to 10.0. Default = 1.0.|


Adding a low pass filter
------------------------

To add a low pass filter to a given audio source just select the object in the inspector and then select <span class=component>Component->Audio->Audio Low Pass Filter</span>.

Hints
-----

* Sounds propagates very differently given the environment. For example, to compliment a visual fog effect add a subtle low-pass to the Audio Listener.
* The high frequencies of a sound being emitted from behind a door will not reach the listener. To simulate this, simply change the <span class=component>Cutoff Frequency</span> when opening the door.
