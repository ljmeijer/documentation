Audio Reverb Filter (PRO only)
==============================


The <span class=keyword>Audio Reverb Filter</span> takes an [Audio Clip](class-AudioClip.md) and distorts it to create a personalized reverb effect.


![](http://docwiki.hq.unity3d.com/uploads/Main/AudioReverbFilter.png)  
_The Audio Reverb filter properties in the inspector._


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Reverb Preset</span> |Custom reverb presets, select user to create your own customized reverbs.|
|<span class=component>Dry Level</span> |Mix level of dry signal in output in mB. Ranges from -10000.0 to 0.0. Default is 0.|
|<span class=component>Room</span> |Room effect level at low frequencies in mB. Ranges from -10000.0 to 0.0. Default is 0.0.|
|<span class=component>Room HF</span> |Room effect high-frequency level in mB. Ranges from -10000.0 to 0.0. Default is 0.0.|
|<span class=component>Room LF</span> |Room effect low-frequency level in mB. Ranges from -10000.0 to 0.0. Default is 0.0.|
|<span class=component>Decay Time</span> |Reverberation decay time at low-frequencies in seconds. Ranges from 0.1 to 20.0. Default is 1.0.|
|<span class=component>Decay HFRatio</span> |Decay HF Ratio : High-frequency to low-frequency decay time ratio. Ranges from 0.1 to 2.0. Default is 0.5.|
|<span class=component>Reflections Level</span> |Early reflections level relative to room effect in mB. Ranges from -10000.0 to 1000.0. Default is -10000.0.|
|<span class=component>Reflections Delay</span> |Early reflections delay time relative to room effect in mB. Ranges from -10000.0 to 2000.0. Default is 0.0.|
|<span class=component>Reverb Level</span> |Late reverberation level relative to room effect in mB. Ranges from -10000.0 to 2000.0. Default is 0.0.|
|<span class=component>Reverb Delay</span> |Late reverberation delay time relative to first reflection in seconds. Ranges from 0.0 to 0.1. Default is 0.04.|
|<span class=component>HFReference</span> |Reference high frequency in Hz. Ranges from 20.0 to 20000.0. Default is 5000.0.|
|<span class=component>LFReference</span> |Reference low-frequency in Hz. Ranges from 20.0 to 1000.0. Default is 250.0.|
|<span class=component>Reflections Delay</span> |Late reverberation level relative to room effect in mB. Ranges from -10000.0 to 2000.0. Default is 0.0.|
|<span class=component>Diffusion</span> |Reverberation diffusion (echo density) in percent. Ranges from 0.0 to 100.0. Default is 100.0.|
|<span class=component>Density</span> |Reverberation density (modal density) in percent. Ranges from 0.0 to 100.0. Default is 100.0.|

__Note:__ These values can only be modified if your <span class=component>Reverb Preset</span> is set to <span class=component>User</span>, else these values will be grayed out and they will have default values for each preset.

Adding a reverb pass filter
---------------------------

To add a reverb pass filter to a given audio source just select the object in the inspector and then select <span class=component>Component->Audio->Audio reverb Filter</span>.
