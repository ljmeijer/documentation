Importing Assets
================


Unity will automatically detect files as they are added to your Project folder's <span class=keyword>Assets</span> folder.  When you put any asset into your Assets folder, you will see the asset appear in your <span class=keyword>Project View</span>.


![](http://docwiki.hq.unity3d.com/uploads/Main/ProjectBrowser.png)  
_The Project View is your window into the Assets folder, normally accessible from the file manager_

When you are organizing your Project View, there is one very important thing to remember:

###%red% Never move any assets or organize this folder from the Explorer (Windows) or Finder (OS X).  Always use the Project View!%%

There is a lot of meta data stored about relationships between asset files within Unity.  This data is all dependent on where Unity expects to find these assets.  If you move an asset from within the Project View, these relationships are maintained.  If you move them outside of Unity, these relationships are broken.  You'll then have to manually re-link lots of dependencies, which is something you probably don't want to do.

So just remember to only save assets to the Assets folder from other applications, and never rename or move files outside of Unity.  Always use Project View.  You can safely open files for editing from anywhere, of course.


Creating and Updating Assets
----------------------------


When you are building a game and you want to add a new asset of any type, all you have to do is create the asset and save it somewhere in the Assets folder.  When you return to Unity or launch it, the added file(s) will be detected and imported.

Additionally, as you update and save your assets, the changes will be detected and the asset will be re-imported in Unity.  This allows you to focus on refining your assets without struggling to make them compatible with Unity.  Updating and saving your assets normally from its native application provides optimum, hassle-free workflow that feels natural.


Asset Types
-----------


There are a handful of basic asset types that will go into your game.  The types are:

* Mesh Files & Animations
* Texture Files
* Sound Files

We'll discuss the details of importing each of these file types and how they are used.


###Meshes & Animations

Whichever 3D package you are using, Unity will import the meshes and animations from each file.  For a list of applications that are supported by Unity, please see [this page](HOWTO-importObject.md).

Your mesh file does not need to have an animation to be imported.  If you do use animations, you have your choice of importing all animations from a single file, or importing separate files, each with one animation.  For more information about importing animations, please see page about [Animation Import](Animations.md).

Once your mesh is imported into Unity, you can drag it to the <span class=keyword>Scene</span> or <span class=keyword>Hierarchy</span> to create an instance of it.  You can also add <span class=keyword>Components</span> to the instance, which will not be attached to mesh file itself.

Meshes will be imported with UVs and a number of default <span class=keyword>Materials</span> (one material per UV).  You can then assign the appropriate texture files to the materials and complete the look of your mesh in Unity's game engine.


###Textures

Unity supports all image formats.  Even when working with layered Photoshop files, they are imported without disturbing the Photoshop format.  This allows you to work with a single texture file for a very care-free and streamlined experience.

You should make your textures in dimensions that are to the power of two (e.g. 32x32, 64x64, 128x128, 256x256, etc.)  Simply placing them in your project's Assets folder is sufficient, and they will appear in the Project View.

Once your texture has been imported, you should assign it to a [Material](class-Material.md).  The material can then be applied to a mesh, <span class=keyword>Particle System</span>, or <span class=keyword>GUI Texture</span>.  Using the <span class=keyword>Import Settings</span>, it can also be converted to a <span class=keyword>Cubemap</span> or <span class=keyword>Normalmap</span> for different types of applications in the game.  For more information about importing textures, please read the [Texture Component page](class-Texture2D.md).


###Sounds


####desktop Details
Unity features support for two types of audio: <span class=keyword>Uncompressed Audio</span> or <span class=keyword>Ogg Vorbis</span>.  Any type of audio file you import into your project will be converted to one of these formats.


###File Type Conversion


|    |    |
|:---|:---|
|<span class=component>.AIFF</span> |Converted to uncompressed audio on import, best for short sound effects. |
|<span class=component>.WAV</span> |Converted to uncompressed audio on import, best for short sound effects. |
|<span class=component>.MP3</span> |Converted to Ogg Vorbis on import, best for longer music tracks. |
|<span class=component>.OGG</span> |Compressed audio format, best for longer music tracks. |


###Import Settings

If you are importing a file that is not already compressed as Ogg Vorbis, you have a number of options in the <span class=keyword>Import Settings</span> of the Audio Clip.  Select the Audio Clip in the <span class=keyword>Project View</span> and edit the options in the <span class=keyword>Audio Importer</span> section of the <span class=keyword>Inspector</span>. Here, you can compress the Clip into Ogg Vorbis format, force it into Mono or Stereo playback, and tweak other options.  There are positives and negatives for both Ogg Vorbis and uncompressed audio.  Each has its own ideal usage scenarios, and you generally should not use either one exclusively.

Read more about using Ogg Vorbis or Uncompressed audio on the [Audio Clip Component Reference page](class-AudioClip.md).

####ios Details
Unity features support for two types of audio: <span class=keyword>Uncompressed Audio</span> or <span class=keyword>MP3 Compressed audio</span>.  Any type of audio file you import into your project will be converted to one of these formats.

####File Type Conversion


|    |    |
|:---|:---|
|<span class=component>.AIFF</span> |Imports as uncompressed audio for short sound effects. Can be compressed in Editor on demand. |
|<span class=component>.WAV</span> |Imports as uncompressed audio for short sound effects. Can be compressed in Editor on demand. |
|<span class=component>.MP3</span> |Imports as Apple Native compressed format for longer music tracks. Can be played on device hardware.|
|<span class=component>.OGG</span> |OGG compressed audio format, __incompatible__ with the iPhone device. Please use MP3 compressed sounds on the iPhone.|

####Import Settings

When you are importing an audio file, you can select its final format and choose to force it to stereo or mono channels.  To access the <span class=keyword>Import Settings</span>, select the Audio Clip in the <span class=keyword>Project View</span> and find the <span class=keyword>Audio Importer</span> in the Inspector. Here, you can compress the Clip into Ogg Vorbis format, force it into Mono or Stereo playback, and tweak other options, such as the very important Decompress On Load setting.

Read more about using MP3 Compressed or Uncompressed audio on the [Audio Clip Component Reference page](class-AudioClip.md).

#####android Details
Unity features support for two types of audio: <span class=keyword>Uncompressed Audio</span> or <span class=keyword>MP3 Compressed audio</span>.  Any type of audio file you import into your project will be converted to one of these formats.

####File Type Conversion


|    |    |
|:---|:---|
|<span class=component>.AIFF</span> |Imports as uncompressed audio for short sound effects. Can be compressed in Editor on demand. |
|<span class=component>.WAV</span> |Imports as uncompressed audio for short sound effects. Can be compressed in Editor on demand. |
|<span class=component>.MP3</span> |Imports as MP3 compressed format for longer music tracks.|
|<span class=component>.OGG</span> |Note: the OGG compressed audio format is __incompatible__ with some Android devices, so Unity does not support it for the Android platform. Please use MP3 compressed sounds instead.|

####Import Settings

When you are importing an audio file, you can select its final format and choose to force it to stereo or mono channels.  To access the <span class=keyword>Import Settings</span>, select the Audio Clip in the <span class=keyword>Project View</span> and find the <span class=keyword>Audio Importer</span> in the Inspector. Here, you can compress the Clip into Ogg Vorbis format, force it into Mono or Stereo playback, and tweak other options, such as the very important Decompress On Load setting.

Read more about using MP3 Compressed or Uncompressed audio on the [Audio Clip Component Reference page](class-AudioClip.md).

Once sound files are imported, they can be attached to any <span class=keyword>GameObject</span>.  The Audio file will create an [Audio Source Component](class-AudioSource.md) automatically when you drag it onto a GameObject.
