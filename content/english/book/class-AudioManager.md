Audio Manager
=============


The <span class=keyword>Audio Manager</span> allows you to tweak the maximum volume of all sounds playing in the scene.
To see it choose <span class=menu>Edit->Project Settings->Audio</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/AudioSet.png)  


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Volume</span> |The volume of all sounds playing. |
|<span class=component>Rolloff Scale</span> |Sets the global attenuation rolloff factor for Logarithmic rolloff based sources (see [Audio Source](class-AudioSource.md)). The higher the value the faster the volume will attenuate, conversely the lower the value, the slower it attenuate (value of 1 will simulate the "real world").|
|<span class=component>Speed of Sound</span> |The speed of sound. 343 is the real world speed of sound, if you are using a meters as your units. You can adjust this value to make your objects have more or less Doppler effect with larger or smaller speed. |
|<span class=component>Doppler Factor</span> |How audible the Doppler effect is. When it is zero it is turned off. 1 means it should be quite audible for fast moving objects. |
|<span class=component>Default Speaker Mode</span> |Defines which speaker mode should be the default for your project. Default is 2 for stereo speaker setups (see [AudioSpeakerMode](ScriptRef:AudioSpeakerMode.html) in the scripting API reference for a list of modes).|
|<span class=component>DSP Buffer Size</span>|The size of the DSP buffer can be set to optimise for latency or performance|
|>>><span class=component>Default</span>|Default buffer size|
|>>><span class=component>Best Latency</span>|Trades off performance in favour of latency|
|>>><span class=component>Good Latency</span>|Balance between latency and performance|
|>>><span class=component>Best Performance</span>|Trades off latency in favour of performance|

Details
-------


If you want to use Doppler Effect set <span class=component>Doppler Factor</span> to 1. Then tweak both <span class=component>Speed of Sound</span> and <span class=component>Doppler Factor</span> until you are satisfied.  
Speaker mode can be changed runtime from your application through scripting. See [Audio Settings](ScriptRef:AudioSettings.html).

