Optimizing the Size of the Built iOS Player
===========================================


The two main ways of reducing the size of the player are by changing the <span class=keyword>Active Build Configuration</span> within Xcode and by changing the <span class=keyword>Stripping Level</span> within Unity.

Building in Release Mode
------------------------


You can choose between the <span class=keyword>Debug</span> and <span class=keyword>Release</span> options on the <span class=keyword>Active Build Configuration</span> drop-down menu in Xcode. Building as <span class=keyword>Release</span> instead of <span class=keyword>Debug</span> can reduce the size of the built player by as much as 2-3MB, depending on the game.


![](http://docwiki.hq.unity3d.com/uploads/Main/iphone-activeBuildConfig.png)  
_The Active Build Configuration drop-down_

In Release mode, the player will be built without any debug information, so if your game crashes or has other problems there will be no stack trace information available for output. This is fine for deploying a finished game but you will probably want to use Debug mode during development.


iOS Stripping Level (Advanced License feature)
----------------------------------------------


The size optimizations activated by stripping work in the following way:-

1. <span class=keyword>Strip assemblies</span> level: the scripts' bytecode is analyzed so that classes and methods that are not referenced from the scripts can be removed from the DLLs and thereby excluded from the AOT compilation phase. This optimization reduces the size of the main binary and accompanying DLLs and is safe as long as no reflection is used.

1. <span class=keyword>Strip ByteCode</span> level: any .NET DLLs (stored in the Data folder) are stripped down to metadata only. This is possible because all the code is already precompiled during the AOT phase and linked into the main binary.

1. <span class=keyword>Use micro mscorlib</span> level: a special, smaller version of mscorlib is used. Some components are removed from this library, for example, Security, Reflection.Emit, Remoting, non Gregorian calendars, etc. Also, interdependencies between internal components are minimized. This optimization reduces the main binary and mscorlib.dll size but it is not compatible with some System and System.Xml assembly classes, so use it with care.

These levels are cumulative, so level 3 optimization implicitly includes levels 2 and 1, while level 2 optimization includes level 1.

__Note:__ <span class=component>Micro mscorlib</span> is a heavily stripped-down version of the core library. Only those items that are required by the Mono runtime in Unity remain. Best practice for using micro mscorlib is not to use any classes or other features of .NET that are not required by your application. GUIDs are a good example of something you could omit; they can easily be replaced with custom made pseudo GUIDs and doing this would result in better performance and app size. 

Tips
----

###How to Deal with Stripping when Using Reflection
Stripping depends highly on static code analysis and sometimes this can't be done effectively, especially when dynamic features like reflection are used. In such cases, it is necessary to give some hints as to which classes shouldn't be touched. Unity supports a per-project custom stripping _blacklist_. Using the blacklist is a simple matter of creating a <span class=component>link.xml</span> file and placing it into the <span class=component>Assets</span> folder. An example of the contents of the <span class=component>link.xml</span> file follows. Classes marked for preservation will not be affected by stripping:-
````

<linker>
       <assembly fullname="System.Web.Services">
               <type fullname="System.Web.Services.Protocols.SoapTypeStubInfo" preserve="all"/>
               <type fullname="System.Web.Services.Configuration.WebServicesConfigurationSectionHandler" preserve="all"/>
       </assembly>

       <assembly fullname="System">
               <type fullname="System.Net.Configuration.WebRequestModuleHandler" preserve="all"/>
               <type fullname="System.Net.HttpRequestCreator" preserve="all"/>
               <type fullname="System.Net.FileWebRequestCreator" preserve="all"/>
       </assembly>
</linker>

````

__Note:__ it can sometimes be difficult to determine which classes are getting stripped in error even though the application requires them. You can often get useful information about this by running the stripped application on the simulator and checking the Xcode console for error messages.

###Simple Checklist for Making Your Distribution as Small as Possible

1. Minimize your assets: enable PVRTC compression for textures and reduce their resolution as far as possible. Also, minimize the number of uncompressed sounds. There are some additional tips for file size reduction [here](Main.ReducingFilesize.md).
1. Set the iOS Stripping Level to <span class=keyword>Use micro mscorlib</span>.
1. Set the script call optimization level to <span class=keyword>Fast but no exceptions</span>.
1. Don't use anything that lives in System.dll or System.Xml.dll in your code. These libraries are __not__ compatible with micro mscorlib.
1. Remove unnecessary code dependencies.
1. Set the  API Compatibility Level to <span class=keyword>.Net 2.0 subset</span>. Note that .Net 2.0 subset has limited compatibility with other libraries.
1. Set the Target Platform to <span class=keyword>armv6 (OpenGL ES1.1)</span>.
1. Don't use JS Arrays.
1. Avoid generic containers in combination with value types, including structs.

###Can I produce apps of less than 20 megabytes with Unity?
Yes. An empty project would take about 13 MB in the AppStore if all the size optimizations were turned off. This gives you a budget of about 7MB for compressed assets in your game. If you own an Advanced License (and therefore have access to the stripping option), the empty scene with just the main camera can be reduced to about 6 MB in the AppStore (zipped and DRM attached) and you will have about 14 MB available for compressed assets.  

###Why did my app increase in size after being released to the AppStore?
When they publish your app, Apple first encrypt the binary file and then compresses it via zip. Most often Apple's DRM increases the binary size by about 4 MB or so. As a general rule, you should expect the final size to be approximately equal to the size of the zip-compressed archive of all files (except the executable) plus the size of the uncompressed executable file.
