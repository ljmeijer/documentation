Audio Files
===========


As with Meshes or Textures, the workflow for <span class=keyword>Audio File</span> assets is designed to be smooth and trouble free.  Unity can import almost every common file format but there are a few details that are useful to be aware of when working with Audio Files.

Audio in Unity is either _Native_ or _Compressed_.  Unity supports most common formats (see the list below) and will import an audio file when it is added to the project. The default mode is _Native_, where the audio data from the original file is imported unchanged. However, Unity can also compress the audio data on import, simply by enabling the _Compressed_ option in the importer. (iOS projects can make use of the hardware decoder - see the iOS documentation for further details). The difference between Native and Compressed modes are as follows:-

* <span class=keyword>Native</span>: Use Native (WAV, AIFF) audio for short sound effects. The audio data will be larger but sounds won't need to be decoded at runtime.

* <span class=keyword>Compressed</span>: The audio data will be small but will need to be decompressed at runtime, which entails a processing overhead. Depending on the target, Unity will encode the audio to either Ogg Vorbis(Mac/PC/Consoles) or MP3 (Mobile platforms). For the best sound quality, supply the audio in an uncompressed format such as WAV or AIFF (containing PCM data) and let Unity do the encoding. If you are targeting Mac and PC platforms only (including both standalones and webplayers) then importing an Ogg Vorbis file will not degrade the quality. However, on mobile platforms, Ogg Vorbis  and MP3 files will be re-encoded to MP3 on import, which will introduce a slight quality degradation.

Any Audio File imported into Unity is available from scripts as an <span class=keyword>Audio Clip</span> instance, which is effectively just a container for the audio data. The clips must be used in conjunction with <span class=keyword>Audio Sources</span> and an <span class=keyword>Audio Listener</span> in order to actually generate sound. When you attach your clip to an object in the game, it adds an Audio Source component to the object, which has <span class=component>Volume</span>, <span class=component>Pitch</span> and a numerous other properties.  While a Source is playing, an Audio Listener can "hear" all sources within range, and the combination of those sources gives the sound that will actually be heard through the speakers.  There can be only one Audio Listener in your scene, and this is usually attached to the <span class=keyword>Main Camera</span>.

Supported Formats
-----------------


|    |    |    |
|:---|:---|:---|
|!Format|!Compressed as (Mac/PC)|!Compressed as (Mobile)|
|MPEG(1/2/3)    | Ogg Vorbis | MP3 | 
|Ogg Vorbis     | Ogg Vorbis | MP3 |
|WAV            | Ogg Vorbis | MP3 |
|AIFF           | Ogg Vorbis | MP3 |
|MOD            | - | - |
|IT             | - | - |
|S3M            | - | - |
|XM             | - | - |



See the [Sound chapter](Sound.md) in the [Creating Gameplay](CreatingGameplay.md) section of this manual for more information on using sound in Unity.

(:include class-AudioClip:)
