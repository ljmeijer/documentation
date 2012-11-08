Project Settings
================


Unity for Xbox 360 comes with additional project settings.

###Build Settings: General
1. [Build Type](#BuildType)
1. [Explicit Null Checks](#ExplicitNullChecks)
1. [Compress Libs](#CompressLibs)
1. [Run Method](#RunMethod)

###Player Settings: Publishing Settings
1. [Title Id](#TitleId)
1. [ImageXEX config override](#ImageXEXConfigOverride)
1. [SPA config](#SPAConfig)
1. [Generate _SPAConfig.cs](#Generate_SPAConfig.cs)
1. [Enable Avatar rendering](#EnableAvatarRendering)
1. [Deploy Kinect resources](#DeployKinectResources)

####u40 Details
1. [Deploy Speech resources](#DeploySpeechResources)
1. [Enable Kinect](#EnableKinect)
    1. [Enable Kinect AutoTracking](#EnableKinectAutoTracking)

####u40 Details
    1. [Enable Kinect Fitness](#EnableKinectFitness)

###Player Settings: Other Settings
1. [Enable GPU skinning](#EnableGPUSkinning)
1. [Stripping Level](#StrippingLevel)

---- 

<a id="BuildType"></a>Build Type
--------------------------------

Debug player has full debug output and asserts enabled.
1. Editor-player connection enabled.
1. Unity profiler enabled.
1. Full debug information emitted to standard output.
1. Linked with debug libs.
1. PDBs for managed code emitted to BUILD_TARGET\Media\Managed.

Development player has most of the debug functionality required for normal development.
1. Editor-player connection enabled.
1. Unity profiler enabled.
1. Critical debug information emitted to standard output.
1. Linked with instrumented libs to enable PIX captures.
1. PDBs for managed code emitted to BUILD_TARGET\Media\Managed.

Master player is TCR compliant.
1. All standard output disabled.
1. Linked with retail libs.

<a id="ExplicitNullChecks"></a>Explicit Null Checks
---------------------------------------------------

Development Build feature that enables you to catch null references.
Enabling it will cause the compiler to emit explicit null checks around every managed deref operation and throw a NullPointerException. This does influence performance slightly.
Disabling it will cause the console to crash under the same conditions. See [Debugging](Main.xbox360-debugging.md) for more details.

<a id="CompressLibs"></a>Compress Libs
--------------------------------------

Enables compression of the main executable and script assemblies. Decreases project boot time (esp. from DVD), but increases build time.

<a id="RunMethod"></a>Run Method
--------------------------------

"Build and Run" command behavior can be customized:
1. Copy to HDD - the usual way of testing Xbox 360 applications. The whole project output folder is copied to a devkit.
1. DVD Emulation - a disc layout file _AutoLayout.XGD is created in the project output folder and the Game Disc Emulator is started. Devkit must be connected via the DVD EMU USB port (see _DVD Emulation_ in the Xbox 360 SDK Documentation for details). Note that you will have to close the Game Disc Emulator window prior to the next build.
    1. No timing - the emulator does not emulate DVD behavior or introduce any latency into file read times.
    1. Accurate - the emulator emulates DVD behavior by introducing accurate latency based on the LBAs of the files accessed. Note that the automatically generated layout might be suboptimal for your game.

<a id="TitleId"></a>Title Id
----------------------------

Title id of your game. Format: `ABCD1234`. Contact your developer account manager at Microsoft for details.
A title id is required by certain Xbox features (i.e. storage or Xbox Live services).

<a id="ImageXEXConfigOverride"></a>ImageXEX config override
-----------------------------------------------------------

Specifies a configuration file for the XEX image conversion tool. Unity player is converted to a XEX during the process.
See _XEX Image Converter_ in the Xbox 360 SDK Documentation for details.

<a id="SPAConfig"></a>SPA config
--------------------------------

Specifies a SPA configuration file to be embedded in the executable. This configuration is required by certain Xbox features (i.e. Xbox Live services).
Step-by-step guide:
1. Download the Xbox LIVE Publishing Toolkit from the Xbox Developer site.
1. Prepare a configuration using the Xbox LIVE Game Configuration tool and upload it to PartnerNet. See _LIVE Environments_ in the the Xbox 360 SDK Documentation for details.
1. Generate the .SPA and .SPA.H files for your configuration.
1. Enter the path to the .SPA file.

<a id="Generate_SPAConfig.cs"></a>Generate _SPAConfig.cs
--------------------------------------------------------

Convenience feature enabled only when the SPA config is specified.
Enabling this will have Unity look for a .SPA.H file in the same folder as the specified .SPA file and convert it to a Unity script containing a single `enum SPAConfig`. Hardcoding values is not an option as they may change after rebuilding the SPA files.

<a id="EnableAvatarRendering"></a>Enable Avatar rendering
---------------------------------------------------------

Initializes the Avatar system. See [Avatars](Main.xbox360-avatars.md) for more details.

<a id="DeployKinectResources"></a>Deploy Kinect resources
---------------------------------------------------------

Copies Kinect resources (Database.xmplr and NuiIdentity.bin.be) to the project output folder.


###u40 Details
<a id="DeploySpeechResources"></a>Deploy Speech resources
---------------------------------------------------------

Copies Speech resources (selected languages) to the project output folder.

<a id="EnableKinect"></a>Enable Kinect
--------------------------------------

Enables Kinect systems in _UnityEngine.Kinect_.

<a id="EnableKinectAutoTracking"></a>Enable Kinect AutoTracking
---------------------------------------------------------------

Enables automatic skeleton tracking. If disabled, _UnityEngine.Kinect.Skeleton.SetTrackedSkeletons_ must be called to specify tracked skeletons.
Only visible if _Enable Kinect_ is checked.


###u40 Details
<a id="EnableKinectFitness"></a>Enable Kinect Fitness
-----------------------------------------------------

Enables Kinect Fitness API.

<a id="EnableGPUSkinning"></a>Enable GPU skinning
-------------------------------------------------

Enables Unity to use a GPU skinning path with memexport.

<a id="StrippingLevel"></a>Stripping Level
------------------------------------------

Enables code stripping. Strips managed bytecode and unused native code. Greatly reduces DLL size and boot time.
"micro mscorlib" is not available for Xbox 360. Selecting it will act as "Strip ByteCode".
