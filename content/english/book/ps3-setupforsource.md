Playstation3: Setup for Source Licensees
========================================


Developing for PlayStation®3
-----------------------------

You must be a PlayStation®3 Registered Developer and own the appropriate hardware. See the [PS3 Setup](ps3-setup.md) page for a seat setup checklist.

Prerequisites for compiling/debugging with source code
------------------------------------------------------

* Visual Studio 2008 and SP1

Additional packages required for profiling
------------------------------------------

* Tuner for code profiling - https://ps3.scedev.net/projects/tuner
* GPAD for graphics profiling - https://ps3.scedev.net/projects/gpad
* You can also check https://ps3.scedev.net/projects/all#ardl_17 for all the performance tools / tutorial videos.

Compiling the source
--------------------

The project contains 3 configurations:
* __ppu master__ : The UnityPlayer is compiled and archived as a static library. The executable player is built by the editor when building your project by linking it against the AOT'd script assemblies.
* __ppu release__ : The UnityDevelopmentPlayer is compiled and archived as a static library. The executable player is built by the editor when building your project by linking it against the AOT'd script assemblies. Required for building development builds.
* __ppu debug__ : The UnityPlayer is compiled and linked as executable and can be used for debugging. This requires the project you want to debug to be built *first* by the editor with the "Install in Builds folder" check box set.

Running a PS3 Unity Project from the PC
---------------------------------------

From Unity:
* Open the Build Settings window.
* Switch to PS3 Platform.
* Select "PC Hosted" as the Target Media.
* Click on Build & Run. (Please note that for this to work you have to have your DevKit/TestKit connected in Target Manager)
        
From ProDG Target Manager:
* Select the Target PS3.
* Right click on it and make sure the Reset mode is set to Debug.
* Right-click on the Target PS3 and select "Load and Run executable".
* Navigate to the folder where the .self file and Media folder are located.
* Select the .self file and make sure "Set file server directory" and "Use ELF directory" are ticked.
* Click on Open and wait for the Player to run.

Debugging your project:
-----------------------

Please note that all debugging for the PS3 is done inside the ProDG Debugger. You can check https://ps3.scedev.net/docs/sn_videos_mp4/1 for
training videos on different PS3 development aspects including debugging/profiling.

In _'Target Manager_' right click on your your target name and click "Set File System Directory (/app_home/)". Navigate and select <PATH_TO_SOURCE_TREE>/build/PS3Player.

In _'VisualStudio_' select your default project to be PS3Player. Now press the F5/F10 (Run, Run and stop at main) and it will launch the ProDG Debugger.
