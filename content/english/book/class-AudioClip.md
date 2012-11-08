Audio Clip
==========


<span class=keyword>Audio Clips</span> contain the audio data used by [Audio Sources](class-AudioSource.md).  Unity supports mono, stereo and multichannel audio assets (up to eight channels). The audio file formats that Unity can import are __.aif__, __.wav__, __.mp3__, and __.ogg__. Unity can also import [tracker modules](TrackerModules.md) in the __.xm__, __.mod__, __.it__, and __.s3m__ formats. The tracker module assets behave the same way as any other audio assets in Unity although no waveform preview is available in the asset import inspector.


![](http://docwiki.hq.unity3d.com/uploads/Main/AudioClipImporter35.png)  
_The Audio Clip <span class=keyword>Inspector</span>_

Properties
----------


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Audio Format</span> |The specific format that will be used for the sound at runtime. |
|>>><span class=component>Native</span> |This option offers higher quality at the expense of larger file size and is best for very short sound effects. |
|>>><span class=component>Compressed</span> |The compression results in smaller files but with somewhat lower quality compared to native audio.  This format is best for medium length sound effects and music. |
|<span class=component>3D Sound</span> |If enabled, the sound will play back in 3D space.  Both Mono and Stereo sounds can be played in 3D. |
|<span class=component>Force to mono</span> |If enabled, the audio clip will be down-mixed to a single channel sound. |
|<span class=component>Load Type</span> |The method Unity uses to load audio assets at runtime.|
|>>><span class=component>Decompress on load</span> |Audio files will be decompressed as soon as they are loaded. Use this option for smaller compressed sounds to avoid the performance overhead of decompressing on the fly. Be aware that decompressing sounds on load will use about ten times more memory than keeping them compressed, so don't use this option for large files. |
|>>><span class=component>Compressed in memory</span> |Keep sounds compressed in memory and decompress while playing. This option has a slight performance overhead (especially for Ogg/Vorbis compressed files) so only use it for bigger files where decompression on load would use a prohibitive amount of memory. Note that, due to technical limitations, this option will silently switch to _Stream From Disc_ (see below) for Ogg Vorbis assets on platforms that use FMOD audio.
|>>><span class=component>Stream from disc</span> |Stream audio data directly from disc. The memory used by this option is typically a small fraction of the file size, so it is very useful for music or other very long tracks. For performance reasons, it is usually advisable to stream only one or two files from disc at a time but the of streams that can comfortably be handled depends on the hardware.
|<span class=component>Compression</span> |Amount of Compression to be applied to a <span class=component>Compressed</span> clip. Statistics about the file size can be seen under the slider. A good approach to tuning this value is to drag the slider to a place that leaves the playback "good enough" while keeping the file small enough for your distribution requirements. |

###ios Details
|<span class=component>Hardware Decoding</span> |(iOS only) On iOS devices, Apple's hardware decoder can be used resulting in lower CPU overhead during decompression. Check out platform specific details for more info.|
|<span class=component>Gapless looping</span> |(Android/iOS only) Use this when compressing a seamless looping audio source file (in a non-compressed PCM format) to ensure perfect continuity is preserved at the seam. Standard MPEG encoders introduce a short silence at the loop point, which will be audible as a brief "click" or "pop".

Importing Audio Assets
----------------------


Unity supports both _Compressed_ and _Native_ Audio.  Any type of file (except MP3/Ogg Vorbis) will be initially imported as _Native_. Compressed audio files must be decompressed by the CPU while the game is running, but have smaller file size. If _Stream_ is checked the audio is decompressed _on the fly_, otherwise it is decompressed completely as soon as it loads. Native PCM formats (WAV, AIFF) have the benefit of giving higher fidelity without increasing the CPU overhead, but files in these formats are typically much larger than compressed files. Module files (.mod,.it,.s3m..xm) can deliver very high quality with an extremely low footprint.

As a general rule of thumb, _Compressed_ audio (or modules) are best for long files like background music or dialog, while _Native_ is better for short sound effects. You should tweak the amount of Compression using the compression slider. Start with high compression and gradually reduce the setting to the point where the loss of sound quality is perceptible. Then, increase it again slightly until the perceived loss of quality disappears.

<a id="PositionalAudio"></a>
Using 3D Audio
--------------

If an audio clip is marked as a <span class=component>3D Sound</span> then it will be played back so as to simulate its position in the game world's 3D space. 3D sounds emulate the distance and location of sounds by attenuating volume and panning across speakers. Both mono and multiple channel sounds can be positioned in 3D. For multiple channel audio, use the _spread_ option on the [Audio Source](class-AudioSource.md) to spread and split out the discrete channels in speaker space. Unity offers a variety of options to control and fine-tune the audio behavior in 3D space - see the [Audio Source](class-AudioSource.md) component reference for further details.   

Platform specific details
-------------------------


###ios Details
On mobile platforms compressed audio is encoded as MP3 to take advantage of hardware decompression. 

To improve performance, audio clips can be played back using the Apple hardware codec. To enable this option, check the "Hardware Decoding" checkbox in the Audio Importer. 
Note that only one hardware audio stream can be decompressed at a time, including the background iPod audio. 

If the hardware decoder is not available, the decompression will fall back on the software decoder (on iPhone 3GS or later, Apple's software decoder is used in preference to Unity's own decoder (FMOD)).

###android Details
On mobile platforms compressed audio is encoded as MP3 to take advantage of hardware decompression. 


