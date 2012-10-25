Tracker Modules
===============


Tracker Modules are essentially just packages of audio samples that have been modeled, arranged and sequenced programatically.  The concept was introduced in the 1980's (mainly in conjunction with the Amiga computer) and has been popular since the early days of game development and demo culture.

Tracker Module files are similar to MIDI files in many ways. The tracks are scores that contain information about when to play the instruments, and at what pitch and volume and from this, the melody and rhythm of the original tune can be recreated. However, MIDI has a disadvantage in that the sounds are dependent on the sound bank available in the audio hardware, so MIDI music can sound different on different computers. In contrast, tracker modules include high quality PCM samples that ensure a similar experience regardless of the audio hardware in use.


Supported formats
-----------------


Unity supports the four most common module file formats, namely Impulse Tracker (__.it__), Scream Tracker (__.s3m__), Extended Module File Format (__.xm__), and the original Module File Format (__.mod__).


Benefits of Using Tracker Modules
---------------------------------


Tracker module files differ from mainstream PCM formats (__.aif__, __.wav__, __.mp3__, and __.ogg__) in that they can be very small without a corresponding loss of sound quality. A single sound sample can be modified in pitch and volume (and can have other effects applied), so it essentially acts as an "instrument" which can play a tune without the overhead of recording the whole tune as a sample. As a result, tracker modules lend themselves to games, where music is required but where a large file download would be a problem.


Third Party Tools and Further References
----------------------------------------


Currently, the most popular tools to create and edit Tracker Modules are MilkyTracker for OSX and OpenMPT for Windows. For more information and discussion, please see the blog post [http://blogs.unity3d.com/2010/06/29/mod-in-unity/ | .mod in Unity](http://blogs.unity3d.com/2010/06/29/mod-in-unity/ | .mod in Unity) from June 2010.
