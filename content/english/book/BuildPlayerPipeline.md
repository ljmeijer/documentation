Build Player Pipeline
=====================


When building a player, you sometimes want to modify the built player in some way. For example you might want to add a custom icon, copy some documentation next to the player or build an Installer. Doing this manually can become tedious and if you know how to write sh or perl scripts you can automate this task.

Mac OSX
-------

After building a player Unity automatically looks for a sh or perl script called __PostprocessBuildPlayer__ (without any extension) in your Project's Assets/Editor folder. If the file is found, it is invoked when the player finishes building.

In this script you can post process the player in any way you like. For example build an installer out of the player.

You can use perl, sh or any other commandline compatible language.

Unity passes some useful command line arguments to the script, so you know what kind of player it is and where it is stored.

The current directory will be set to be the project folder, that is the folder containing the Assets folder.

````
#!/usr/bin/perl

my $installPath = $ARGV[0];

# The type of player built:
# "dashboard", "standaloneWin32", "standaloneOSXIntel", "standaloneOSXPPC", "standaloneOSXUniversal", "webplayer"
my $target = $ARGV[1];

# What optimizations are applied. At the moment either "" or "strip" when Strip debug symbols is selected.
my $optimization = $ARGV[2];

# The name of the company set in the project settings
my $companyName = $ARGV[3];

# The name of the product set in the project settings
my $productName = $ARGV[4];

# The default screen width of the player.
my $width = $ARGV[5];

# The default screen height of the player 
my $height = $ARGV[6];

print ("\n*** Building at '$installPath' with target: $target \n");

````

Note that some languages, such as Python, pass the name of the script as one of the command line arguments. If you are using one of these languages then the arguments will effectively be shifted along one place in the array (so the install path will be in ARGV[1], etc).

In order to see this feature in action please visit the Example Projects page on our website and download the PostprocessBuildPlayer example package file and import it for use into your own project. It uses the Build Player Pipeline feature to offer customized post-processing of web player builds in order to demonstrate the types of custom build behavior you can implement in your own PostprocessBuildPlayer script.


Windows
-------


On Windows, the PostprocessBuildPlayer script is not supported, but you can use editor scripting to achieve the same effect. You can use [BuildPipeline.BuildPlayer](ScriptRef:BuildPipeline.BuildPlayer.html) to run the build and then follow it with whatever postprocessing code you need:-

````
using UnityEditor;
using System.Diagnostics;

public class ScriptBatch : MonoBehaviour 
{
    [MenuItem("MyTools/Windows Build With Postprocess")]
    public static void BuildGame ()
    {
        // Get filename.
        string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
 
        // Build player.
        BuildPipeline.BuildPlayer(levels, path + "BuiltGame.exe", BuildTarget.StandaloneWindows, BuildOptions.None);

        // Copy a file from the project folder to the build folder, alongside the built game.
        FileUtil.CopyFileOrDirectory("Assets/WebPlayerTemplates/Readme.txt", path + "Readme.txt");

        // Run the game (Process class from System.Diagnostics).
        Process proc = new Process();
        proc.StartInfo.FileName = path + "BuiltGame.exe";
        proc.Start();
    }
}
````
