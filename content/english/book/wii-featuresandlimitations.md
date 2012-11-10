Features And Limitations
========================


Features
--------


* PhysX Physics
* FMOD Audio
    * Filters
    * Streamed
    * ADPCM compression
* Video playback
    * THP file playback
* Unity shaders
    * Fixed functionality shaders
* Lighmapping
* Occlusion culling
* .NET Based Scripting With C#, JavaScript, and Boo
* Disc, WiiWare title deploying
* Disc, WiiWare libary based project deploying
    * You're responsible for producing the final elf file, this gives the possibility to implement the feature yourself which is not yet available in Unity Wii.
* Lights
    * Directional Light
    * Point Light
    * Spot Light
    * Specular light (only with directional lights)

Limitations
-----------


* Not supported:
    * Terrain
    * Surface shaders
    * Vertex, Pixel shaders
    * WWW class
    * Loading scene asynchronously (use Loading Screen utility as alternative)
    * Shadows

* Mono
    * The threads are currently not supported on Mono side, as there's no POSIX threads implementation on Wii, don't use classes from System.Threading namespace.


