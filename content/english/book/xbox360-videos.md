Video Playback
==============



Full-screen video playback on the Xbox can be done using functions in the _UnityEngine.X360VideoPlayer_ class.

1. Video files must be placed in the _PROJECT\Assets\StreamingAssets_ folder. See [Project Structure](xbox360-projectstructure.md) for more details.
1. Specify an absolute path when loading video files on the Xbox: _game:\Media\Raw\_.
1. Playing a video will automatically disable the gamer's background music (see TCR 024).
1. Playback is based on XMedia2 library. See the Xbox 360 SDK Documentation for details.

