Getting Started with Flash Development
======================================


What is Unity Flash?
--------------------

The Flash build option allows Unity to publish swf (ShockWave Flash) files.  These swf files can be played by a Flash plugin installed into your browser.  Most computers in the world will either have a Flash Player installed, or can have one installed by visiting the Adobe Flash website.  Just like a WebPlayer build creates a file with your 3d assets, audio, physics and scripts, Unity can build a SWF file.  All the scripts from your game are automatically converted to ActionScript, which is the scripting language that the Flash Player works with.

Note that the Unity Flash build option exports SWF files for playback in your browser.  The SWF is not intended for playback on mobile platforms.

Performance Comparison
----------------------

We do not currently have direct comparisons of Unity webplayer content vs Flash SWF content.  Much of our webplayer code is executed as native code, so for example, PhysX runs as native code.  By comparison, when building a SWF file all of the physics runtime code (collision detection, newtonian physics) is converted to ActionScript.  Typically you should expect the SWF version to run more slowly than the Unity webplayer version.  We are, of course, doing everything we can to optimize for Flash.

Further reading:
----------------

(:tocportion:)


Other Examples:
---------------

* Forums post - [Loading Textures from Web (in AS3)](http://forum.unity3d.com/threads/128057-Flash-Simple-AS3-Bridge-Demo-Loading-textures-from-web.?p=864642&viewfull=1#post864642.md)

Useful Resources:
-----------------

* [Scripting Reference: ActionScript](http://unity3d.com/support/documentation/ScriptReference/ActionScript.html.md)
* [Flash Development section on the Unity forums](http://forum.unity3d.com/forums/36-Flash-Development.md)
* [Flash questions on Unity Answers](http://answers.unity3d.com/questions/topics/flash.html.md)

