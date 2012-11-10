Reverb Zones.
=============


<span class=keyword>Reverb Zones</span> take an [Audio Clip](class-AudioClip.md) and distort it depending where the audio listener is located inside the reverb zone. They are used when you want to gradually change from a point where there is no ambient effect to a place where there is one, for example when you are entering a cavern.


![](http://docwiki.hq.unity3d.com/uploads/Main/AudioReverbZone.png)  
_The Audio Reverb Zone gizmo seen in the inspector._


Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Min Distance</span> |Represents the radius of the inner circle in the gizmo, this determines the zone where there is a gradually reverb effect and a full reverb zone.|
|<span class=component>Max Distance</span> |Represents the radius of the outer circle in the gizmo, this determines the zone where there is no effect and where the reverb starts to get applied gradually.|
|<span class=component>Reverb Preset</span> |Determines the reverb effect that will be used by the reverb zone.|

This diagram illustrates the properties of the reverb zone.

![](http://docwiki.hq.unity3d.com/uploads/Main/ReverbZoneExpl.png)  
_How the sound works in a reverb zone_


Adding a Reverb Zone
--------------------

To add a Reverb Zone to a given audio source just select the object in the inspector and then select <span class=component>Component->Audio->Audio Reverb Zone</span>.

Hints.
------

* You can mix reverb zones to create combined effects
