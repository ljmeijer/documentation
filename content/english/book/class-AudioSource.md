Audio Source
============


The <span class=keyword>Audio Source</span> plays back an [Audio Clip](class-AudioClip.md) in the scene. If the Audio Clip is a 3D clip, the source is played back at a given position and will attenuate over distance. The audio can be spread out between speakers (stereo to 7.1) (_Spread_) and morphed between 3D and 2D (_PanLevel_). This can be controlled over distance with falloff curves. Also, if the [listener](class-AudioListener.md) is within one or multiple [Reverb Zones](class-AudioReverbZone.md), reverberations is applied to the source. (PRO only) Individual filters can be applied to each audio source for an even richer audio experience. See [Audio Effects](class-AudioEffect.md) for more details.


![](http://docwiki.hq.unity3d.com/uploads/Main/Editor-AudioSource.png)  
_The Audio Source gizmo in the <span class=keyword>Scene View</span> and its settings in the <span class=keyword>inspector</span>._



Properties
----------



|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Audio Clip</span> |Reference to the sound clip file that will be played. |
|<span class=component>Mute</span> |If enabled the sound will be playing but muted. |
|<span class=component>Bypass Effects</span> |This Is to quickly "by-pass" filter effects applied to the audio source. An easy way to turn all effects on/off.|
|<span class=component>Play On Awake</span> |If enabled, the sound will start playing the moment the scene launches. If disabled, you need to start it using the <span class=component>Play()</span> command from scripting. |
|<span class=component>Loop</span> |Enable this to make the <span class=component>Audio Clip</span> loop when it reaches the end. |
|<span class=component>Priority</span> |Determines the priority of this audio source among all the ones that coexist in the scene. (Priority:  0 = most important. 256 = least important. Default = 128.). Use 0 for music tracks to avoid it getting occasionally swapped out.|
|<span class=component>Volume</span> |How loud the sound is at a distance of one world unit (one meter) from the <span class=keyword>Audio Listener</span>. |
|<span class=component>Pitch</span> |Amount of change in pitch due to slowdown/speed up of the <span class=component>Audio Clip</span>.  Value 1 is normal playback speed. |
|<span class=component>__3D Sound Settings__</span>|Settings that are applied to the audio source if the Audio Clip is a 3D Sound.|
|<span class=component>Pan Level</span> |Sets how much the 3d engine has an effect on the audio source. |
|<span class=component>Spread</span> |Sets the spread angle to 3d stereo or multichannel sound in speaker space. |
|<span class=component>Doppler Level</span> |Determines how much doppler effect will be applied to this audio source (if is set to 0, then no effect is applied).|
|<span class=component>Min Distance</span> |Within the MinDistance, the sound will stay at loudest possible. Outside MinDistance it will begin to attenuate.  Increase the MinDistance of a sound to make it 'louder' in a 3d world, and decrease it to make it 'quieter' in a 3d world.|
|<span class=component>Max Distance</span> |The distance where the sound stops attenuating at. Beyond this point it will stay at the volume it would be at MaxDistance units from the listener and will not attenuate any more.|
|<span class=component>Rolloff Mode</span> |How fast the sound fades. The higher the value, the closer the Listener has to be before hearing the sound.(This is determined by a Graph).|
|>>><span class=component>Logarithmic Rolloff</span> |The sound is loud when you are close to the audio source, but when you get away from the object it decreases significantly fast.|
|>>><span class=component>Linear Rolloff</span> |The further away from the audio source you go, the less you can hear it.|
|>>><span class=component>Custom Rolloff</span> |The sound from the audio source behaves accordingly to how you set the graph of roll offs.|
|<span class=component>__2D Sound Settings__</span>|Settings that are applied to the audio source if the Audio clip is a 2D Sound.|
|<span class=component>Pan 2D</span> |Sets how much the engine has an effect on the audio source. |

<a id="rolloff"></a>
Types of Rolloff
----------------

There are three Rolloff modes: Logarithmic, Linear and Custom Rolloff. The Custom Rolloff can be modified by modifying the volume distance curve as described below. If you try to modify the volume distance function when it is set to Logarithmic or Linear, the type will automatically change to Custom Rolloff.


![](http://docwiki.hq.unity3d.com/uploads/Main/TypesOfRollOff.png)  
_Rolloff Modes that an audio source can have._

Distance Functions
------------------


There are several properties of the audio that can be modified as a function of the distance between the audio source and the audio listener.

%red%<span class=keyword>Volume</span>%%: Amplitude(0.0 - 1.0) over distance.  
%green%<span class=keyword>Pan</span>%%: Left(-1.0) to Right(1.0) over distance.  
%blue%<span class=keyword>Spread</span>%%: Angle (degrees 0.0 - 360.0) over distance.  
%color=#B838CF define=purple%<span class=keyword>Low-Pass</span>%% (only if LowPassFilter is attached to the AudioSource): Cutoff Frequency (22000.0-10.0) over distance.


![](http://docwiki.hq.unity3d.com/uploads/Main/AudioDistanceFunctions.png)  
_Distance functions for Volume, Pan, Spread and Low-Pass audio filter. The current distance to the Audio Listener is marked in the graph._

To modify the distance functions, you can edit the curves directly. For more information, see the guide to [Editing Curves](EditingCurves.md).

Creating Audio Sources
----------------------


Audio Sources don't do anything without an assigned <span class=component>Audio Clip</span>.  The Clip is the actual sound file that will be played back.  The Source is like a controller for starting and stopping playback of that clip, and modifying other audio properties.

To create a new Audio Source:
1. Import your audio files into your Unity Project.  These are now Audio Clips.
1. Go to <span class=menu>GameObject->Create Empty</span> from the menubar.
1. With the new GameObject selected, select <span class=menu>Component->Audio->Audio Source</span>.
1. Assign the <span class=component>Audio Clip</span> property of the Audio Source Component in the Inspector.

__Note:__ If you want to create an <span class=component>Audio Source</span> just for one <span class=component>Audio Clip</span> that you have in the Assets folder then you can just drag that clip to the scene view - a GameObject with an <span class=component>Audio Source</span> component will be created automatically for it. Dragging a clip onto on existing GameObject will attach the clip along with a new <span class=component>Audio Source</span> if there isn't one already there. If the object does already have an <span class=component>Audio Source</span> then the newly dragged clip will replace the one that the source currently uses.


Platform specific details
-------------------------


###ios Details
On mobile platforms compressed audio is encoded as MP3 for speedier decompression. Beware that this compression can remove samples at the end of the clip and potentially break a "perfect-looping" clip. Make sure the clip is right on a specific MP3 sample boundary to avoid sample clipping - tools to perform this task are widely available.
For performance reasons audio clips can be played back using the Apple hardware codec. To enable this, check the "Use Hardware" checkbox in the import settings. See the [Audio Clip](class-AudioClip.md) documentation for more details.

###android Details
On mobile platforms compressed audio is encoded as MP3 for speedier decompression. Beware that this compression can remove samples at the end of the clip and potentially break a "perfect-looping" clip. Make sure the clip is right on a specific MP3 sample boundary to avoid sample clipping - tools to perform this task are widely available.

