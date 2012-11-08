How to use Wii profiler ?
=========================

The Nintendo Wii profiler works only with development build, this is because a special library must be linked and it adds additional size to elf file.
So first of all enable Wii profiler in Player Settings (Wii) Hio2 Usage select Profiler, build the player with Development checkbox on and you're good to go.

Launch <RVL_SDK>\X86\bin\WiiProfiler.exe, press the 'Power' button on top left corner (if it's grayed out, something is wrong, see troubleshooting). Choose profiling method and press 'Play', after few seconds you should receive the profiling data.

###Troubleshooting
* The status bar says "Waiting for elf to run on NDEV" - please ensure that the player you've built is a development player, and don't forget to enable Wii profiler in Player Settings.
* The status bar says "RvlDeviceManager is already instantiated. There may only be one active at a time!" - this is probably because you're running on Windows x64, the solution to this problem was suggested in Nintendo newsgroup:
    * Open Visual Studio 2008 Command Prompt
    * Go to <RVL_SDK>\X86\bin\
    * Execute 'corflags /32BIT+ WiiProfiler.exe'
    * Try launching WiiProfiler.exe again
