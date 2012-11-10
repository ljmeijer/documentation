Metro: Getting Started
======================



Currently if you want to build a Metro player, you have to do it on Windows 8, this may change in the future. On Metro platform we don't use Mono, we use Microsoft's .NET together with WinRT, because of this major change comparing to other Unity platforms some of the API may not yet work, but ~95% of API does work. Also because we use Microsoft .NET, this will also allow you to debug your scripts with Visual Studio (currently this only works if you write your code with C#), later on we'll explain how do it.

Unity will support three Metro targets X86, X64 and ARM.

The player log is located under <user>\AppData\Local\Packages\<productname>\TempState.

###Things that are not yet supported:
* Network classes
* AnimationEvent callback functions with arguments (you have to provide a function with no arguments or with AnimationEvent argument)
* GameObject.SendMessage (partially works, but function which accepts the message must match the message sent, because the argument conversion doesn't work)
* Cloth

###Requirements:
* Windows 8 RTM 9200 build (starting from 08-17 build), older Windows 8 versions are no longer supported
* Visual Studio 2012 (11.0.50727.1 )

###Before you can proceed you need to acquire Windows 8 developer license, this can be done in two following ways:
* Build an empty Metro application from Visual Studio and deploy it, if you're doing this first time, a dialog window for getting developer license should open, follow the steps.
* See this link -  [http://msdn.microsoft.com/en-us/library/windows/apps/hh696646(v=vs.110).aspx](http://msdn.microsoft.com/en-us/library/windows/apps/hh696646(v=vs.110).aspx.md)

###Following is only needed if you want to produce and install package (appx) files:
* Although you can use Unity provided UnityTest.pfx certificate (password: unity) it's best to generate your own. You can do that by going to Player settings and clicking Create... button under Publishing Settings (Metro) > Certificate. Specify publisher name, password (optional) and click Create.
* Whichever certificate you use it must be installed. Instructions can be found here [http://technet.microsoft.com/en-us/library/dd441378(office.13).aspx](http://technet.microsoft.com/en-us/library/dd441378(office.13).aspx.md)
* By default Windows allows installing apps from Windows store only. To change that launch GPEdit.msc, browse to Computer Configuration > Administrative Templates > Windows Components > App Package Deployment, double-click "Allow all trusted apps to install" and select Enabled > OK.

###Further reading:
(:tocportion:)
