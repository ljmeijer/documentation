Movie Texture
=============

__Note:__ This is a __Pro/Advanced__ feature only.

##desktop Details
<span class=keyword>Movie Textures</span> are animated <span class=keyword>Textures</span> that are created from a video file.  By placing a video file in your project's <span class=menu>Assets Folder</span>, you can import the video to be used exactly as you would use a regular [Texture](class-Texture2D.md).

Video files are imported via Apple QuickTime. Supported file types are what your QuickTime installation can play (usually __.mov__, __.mpg__, __.mpeg__, __.mp4__, __.avi__, __.asf__). On Windows movie importing requires Quicktime to be installed ([download here](http://www.apple.com/quicktime/download/.md)).


Properties
----------


The Movie Texture <span class=keyword>Inspector</span> is very similar to the regular [Texture](class-Texture2D.md) Inspector.


![](http://docwiki.hq.unity3d.com/uploads/Main/MovieTextureInInspector.png)  
_Video files are Movie Textures in Unity_


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>Aniso Level</span> |Increases Texture quality when viewing the texture at a steep angle. Good for floor and ground textures |
|<span class=component>Filtering Mode</span> |Selects how the Texture is filtered when it gets stretched by 3D transformations |
|<span class=component>Loop</span> |If enabled, the movie will loop when it finishes playing |
|<span class=component>Quality</span> |Compression of the Ogg Theora video file.  A higher value means higher quality, but larger file size |


Details
-------


When a video file is added to your Project, it will automatically be imported and converted to <span class=keyword>Ogg Theora</span> format.  Once your Movie Texture has been imported, you can attach it to any <span class=keyword>GameObject</span> or <span class=keyword>Material</span>, just like a regular Texture.

###Playing the Movie

Your Movie Texture will not play automatically when the game begins running.  You must use a short script to tell it when to play.

````

// this line of code will make the Movie Texture begin playing
renderer.material.mainTexture.Play();

````

Attach the following script to toggle Movie playback when the space bar is pressed:

````

function Update () {
	if (Input.GetButtonDown ("Jump")) {
		if (renderer.material.mainTexture.isPlaying) {
			renderer.material.mainTexture.Pause();
		}
		else {
			renderer.material.mainTexture.Play();
		}
	}
}

````

For more information about playing Movie Textures, see the [Movie Texture Script Reference](ScriptRef:MovieTexture.html) page


###Movie Audio

When a Movie Texture is imported, the audio track accompanying the visuals are imported as well.  This audio appears as an <span class=keyword>AudioClip</span> child of the Movie Texture.


![](http://docwiki.hq.unity3d.com/uploads/Main/MovieTextureAudio.png)  
_The video's audio track appears as a child of the Movie Texture in the <span class=keyword>Project View</span>_

To play this audio, the Audio Clip must be attached to a GameObject, like any other Audio Clip.  Drag the Audio Clip from the Project View onto any GameObject in the Scene or Hierarchy View.  Usually, this will be the same GameObject that is showing the Movie.  Then use [audio.Play()](ScriptRef: GameObject-audio.html) to make the the movie's audio track play along with its video.

####ios Details
Movie Textures are not supported on iOS. Instead, full-screen streaming playback is provided using [Handheld.PlayFullScreenMovie](ScriptRef:Handheld.PlayFullScreenMovie.html).

###You need to keep your videos inside the _StreamingAssets_ folder located in your Project directory.


Unity iOS supports any movie file types that play correctly on an iOS device, implying files with the extensions __.mov__, __.mp4__, __.mpv__, and __.3gp__ and using one of the following compression standards:
* H.264 Baseline Profile Level 3.0 video
* MPEG-4 Part 2 video

For more information about supported compression standards, consult the iPhone SDK [MPMoviePlayerController Class Reference](http://developer.apple.com/library/ios/#documentation/MediaPlayer/Reference/MPMoviePlayerController_Class/MPMoviePlayerController/MPMoviePlayerController.html.md).

As soon as you call [iPhoneUtils.PlayMovie](ScriptRef:iPhoneUtils.PlayMovie.html) or [iPhoneUtils.PlayMovieURL](ScriptRef:iPhoneUtils.PlayMovie.html), the screen will fade from your current content to the designated background color. It might take some time before the movie is ready to play but in the meantime, the player will continue displaying the background color and may also display a progress indicator to let the user know the movie is loading. When playback finishes, the screen will fade back to your content.

###The video player does not respect switching to mute while playing videos

As written above, video files are played using Apple's embedded player (as of SDK 3.2 and iPhone OS 3.1.2 and earlier). This contains a bug that prevents Unity switching to mute.

###The video player does not respect the device's orientation
The Apple video player and iPhone SDK do not provide a way to adjust the orientation of the video. A common approach is to manually create two copies of each movie in landscape and portrait orientations. Then, the orientation of the device can be determined before playback so the right version of the movie can be chosen.


####android Details
Movie Textures are not supported on Android. Instead, full-screen streaming playback is provided using [Handheld.PlayFullScreenMovie](ScriptRef:Handheld.PlayFullScreenMovie.html).

###You need to keep your videos inside of the _StreamingAssets_ folder located in your Project directory.


Unity Android supports any movie file type supported by Android, (ie, files with the extensions __.mp4__ and __.3gp__) and using one of the following compression standards:
* H.263
* H.264 AVC
* MPEG-4 SP

However, device vendors are keen on expanding this list, so some Android devices are able to play formats other than those listed, such as HD videos.

For more information about the supported compression standards, consult the Android SDK [Core Media Formats documentation](http://developer.android.com/guide/appendix/media-formats.html.md).

As soon as you call [iPhoneUtils.PlayMovie](ScriptRef:iPhoneUtils.PlayMovie.html) or [iPhoneUtils.PlayMovieURL](ScriptRef:iPhoneUtils.PlayMovie.html), the screen will fade from your current content to the designated background color. It might take some time before the movie is ready to play. In the meantime, the player will continue displaying the background color and may also display a progress indicator to let the user know the movie is loading. When playback finishes, the screen will fade back to your content.
