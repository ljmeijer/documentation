Audio Filters (PRO only)
========================


[AudioSources](class-AudioSource.md) and the [AudioListener](class-AudioListener.md) can have filter components applied, by adding the filter components to the same GameObject the AudioSource or AudioListener is on. Filter effects are serialized in the component order as seen here:


![](http://docwiki.hq.unity3d.com/uploads/Main/FilterGraph1.png)  

Enabling/Disabling a filter component will _bypass_ the filter. Though highly optimized, some filters are still CPU intensive. Audio CPU usage can monitored in the [profiler](Profiler#Audio.md) under the Audio Tab.


See these pages for more information on each filter type:
* [Low Pass Filter](class-AudioLowPassFilter.md)
* [High Pass Filter](class-AudioHighPassFilter.md)
* [Echo Filter](class-AudioEchoFilter.md)
* [Distortion Filter](class-AudioDistorionFilter.md)
* [Reverb Filter](class-AudioReverbFilter.md)
* [Chorus Filter](class-AudioChorusFilter.md)

