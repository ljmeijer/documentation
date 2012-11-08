Playstation3: Video Playback
============================



Full-screen and Render-to-texture video playback on PS3 can be done using functions in the _[PS3VideoPlayer](ScriptRef:PS3VideoPlayer.html)_ class.

The PS3 Samples -> Video unity package included with the PS3 Addon has working example of video playback both fullscreen and as a RenderTexture.

Prerequisites
-------------


1. Video files must be placed in the _PROJECT\Assets\StreamingAssets_ folder. See [Project Structure](ps3-projectstructure.md) for more details.
1. Specify a relative path when loading video files on the PS3: _Raw/movie.pam_.


Fullscreen video
----------------


You can render fulscreen, in the background by:

1. Passing a null value to the render texture parameter when initializing the VideoPlayer with _[PS3VideoPlayer.Init](ScriptRef:PS3VideoPlayer.Init.html)_
1. Updating the VideoPlayer in _OnPostRender_ by calling _[PS3VideoPlayer.Update](ScriptRef:PS3VideoPlayer.Update.html)_


Video as RenderTexture
----------------------


You can render to a Texture by:

1. Passin a render texture when initializing the VideoPlayer with _[PS3VideoPlayer.Init](ScriptRef:PS3VideoPlayer.Init.html)_
1. Updating the VideoPlayer in _OnPreRender_ by calling _[PS3VideoPlayer.Update](ScriptRef:PS3VideoPlayer.Update.html)_


You can find more infomation about the PAM file format and converting movies to it in the official PS3 documentation : https://ps3.scedev.net/docs/Video_Starting_Guide/1
