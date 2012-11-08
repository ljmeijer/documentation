Playstation3: Frequently Asked Questions
========================================


1. The game stopped with an error: prx.c:sys_prx_load_module:Error: res(id)=0x80010004
--------------------------------------------------------------------------------------

The System Modules Reserve (MB) value is too low and Unity cannot load a PRX module. You need to increase it's value in the Player Settings.

2. An empty scene is already using a lot of video memory.
---------------------------------------------------------

When you use Deferred Rendering Unity has to create extra RenderTargets (buffers) to store the information required to render using the deferred technique. If you switch to use Forward Rendering in the Player Settings the player will use less memory, but you will loose the performance benefits of Deferred rendering.

3. Can now no longer build. "Error building Player: UnauthorizedAccessException: Access to the path is denied."
---------------------------------------------------------------------------------------------------------------

That error typically means that Target Manager has the target folder mapped and the app is running on the PS3. If you have multiple PS3s in target manager, make sure the one you're using is set as Default target so Unity can reset it while creating the package (this way it'll avoid that error). You can also reset it manually before building if for some reason you don't want to change the default PS3.

4. When the player is built I get a message in the log saying that it cant find TITLECONFIG_FULL.XML
----------------------------------------------------------------------------------------------------

If Unity only finds TitleConfig.XML it considers you have a full game. If Unity finds both TitleConfig.XML and TitleConfig_FULL.XML then it considers a trial mode with the ability to be unlocked and it would take TitleConfig.XML as the title config of the trial and TitleConfig_FULL.XML as the full game.
