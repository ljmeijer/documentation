Web Player Streaming
====================


Web Player Streaming is critical for providing a great web gaming experience for the end user.  The idea behind web games is that the user can view your content almost immediately and start playing the game as soon as possible instead of making him wait for a progress bar. This is very achievable, and we will explain how.


Tuning for Portals
------------------


This section will focus on publishing to online game portals. Streaming is useful for all kinds of contents, and it can easily be applied to many other situations.

Online game portals expect that some form of game play really starts after downloading at most 1 MB of data. If you don't reach this makes it that much less likely for a portal to accept your content. From the user's perspective, the game needs to start quickly. Otherwise his time is being wasted and he might as well close the window.

On a 128 kilobit cable connection you can download 16 KB per second or 1 MB per minute. This is the low end of bandwidth online portals target.

The game would optimally be set up to stream something like this:

1. 50 KB display the logo and menu (4 seconds)
1. 320 KB let the user play a tiny tutorial level or let him do some fun interaction in the menu (20 seconds)
1. 800 KB let the user play the first small level (50 seconds)
1. Finish downloading the entire game within 1-5 MB (1-5 minutes)

The key point to keep in mind is to think in wait times for a user on a slow connection. Never let him wait.

Now, don't panic if your web player currently is 10 MB.  It seems daunting to optimize it, but it turns out that with a little effort it is usually quite easy to structure your game in this fashion.  Think of each above step as an individual scene.  If you've made the game, you've done the hard part already.  Structuring some scenes around this loading concept is a comparative breeze!

If you open the console log (<span class=menu>Open Editor Log</span> button in the Console window(<span class=keyword>Desktop Platforms</span>); <span class=menu>Help -> Open Editor console log</span> menu <span class=keyword>OSX</span>) after or during a build, you can see the size of each individual scene file.  The console will show something like this:

````

***Player size statistics***
Level 0 'Main Menu' uses 95.0 KB compressed.
Level 1 'Character Builder' uses 111.5 KB compressed.
Level 2 'Level 1' uses 592.0 KB compressed.
Level 3 'Level 2' uses 2.2 MB compressed.
Level 4 'Level 3' uses 2.3 MB compressed.
Total compressed size 5.3 MB. Total decompressed size 9.9 MB.

````

This game could use a little more optimization!  For more information, we recommend you read the [reducing file size page](ReducingFilesize.md).


The Most Important Steps
------------------------


1. Load the menu first. Showing an animated logo is a great way to make time go by unnoticed, thus letting the download progress further.

1. Make the first level be short and not use a lot of assets. This way, the first level can be loaded quickly, and by keeping the player occupied playing it for a minute or two you can be sure that the download of all remaining assets can be completed in the background. Why not have a mini tutorial level where the user can learn the controls of the game? No reason for high-res textures here or loads of objects, or having all your enemies in the first level.  Use the one with the lowest poly-count.  And yes, this means you might have to design your game with the web player experience in mind.

1. There is no reason why all music must be available when the game starts. Externalize the music and load it via the [WWW](ScriptRef:WWW.html) class. Unity compresses audio with the high quality codec, Ogg Vorbis. However even when compressed, audio takes up a lot of space, and if you have to fit things into 3 MB, if you have 5 minutes of music all the compression in the world won't save you. Sacrifices are needed. Load a very short track that you can loop until more music has been downloaded. Only load more music when the player is hooked on the first level.

1. Optimize your textures using their Import Settings. After you externalize music, textures easily take up 90% of the game. Typical texture sizes are too big for web deployment. In a small browser window, sometimes big textures don't even increase the visual fidelity at all. Make sure you use textures that are only as big as they must be (and be ready for more sacrifices here). Halving the texture resolution actually makes the texture size a quarter of what it was. And of course all textures should be DXT compressed.

1. Generally reduce the size of your web players. There is a manual page committed to the utilities Unity offers for optimizing file size [here](ReducingFilesize.md). Although Unity uses cutting edge LZMA-based compression which usually compresses game data to anywhere from one half to a third of the uncompressed size, you'll need to try everything you can.

1. Try to avoid Resources.Load.  While Resources.Load can be very handy, Unity will not be able to order your assets by when they are first used when you use Resources.Load, because any script could attempt to load the Resource.  You can set which level will include all assets that can be loaded through Resources.Load in the <span class=menu>Edit->Project Settings->Player</span> using the <span class=component>First Streamed Level With Resources</span> property.  Obviously you want to move Resources.Load assets as late as possible into the game or not use the feature at all.


Publishing Streaming Web Players
--------------------------------


Streaming in Unity is level based, and there is an easy workflow to set this up. Internally, Unity does all the dirty work of tracking assets and organizing them in the compressed data files optimally, ordering it by the first scene that uses them.  You simply have to ensure that the first levels in the Build Settings use as few assets as possible. This comes naturally for a "menu level", but for a good web experience you really need make sure that the first actual game levels the player is going to play are small too.

In order to use streaming in Unity, you select <span class=component>Web Player Streamed</span> in the Build Settings. Then the content automatically starts as soon as all assets used by the first level are loaded. Try to keep the "menu level" to something like 50-100 KB. The stream continues to load as fast as it can, and meanwhile live decompresses.  When you look at the Console during/after a build, you can see how large

You can query the progress of the stream by level, and once a level is available it can be loaded. Use [GetStreamProgressForLevel](ScriptRef:Application.GetStreamProgressForLevel.html) for displaying a progress bar and [CanStreamedLevelBeLoaded](ScriptRef:Application.CanStreamedLevelBeLoaded.html) to check if all the data is available to load a specific level.

This form of streaming is of course linear, which matches how games work in most cases. Sometimes that's not enough. Therefore Unity also provides you with API's to load a .unity3d file manually using the [WWW](ScriptRef:WWW.html) class. Video and audio can be streamed as well, and can start playing almost immediately, without requiring the movie to be downloaded first. Finally Textures can easily be downloaded via the [WWW](ScriptRef:WWW.html) class, as can any textual or binary data your game might depend on.

