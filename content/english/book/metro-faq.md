Metro : FAQ
===========


###How to sign your appx file?
* Editor automatically signs package with certificate specified in Player settings.

###How to install an appx file on your machine?
* Open Windows PowerShell from start menu, navigate to your appx file, execute Add-AppxPackage <yourappx>.appx, if the appx was signed, it will be installed on your machine. "Note:" if you're installing appx file again, you have to uninstall the previous one, simply right-click on the icon, and click Uninstall.

###Unsupported classes and functions
* Not everything is supported in .NET for Metro, see this link for supported classes [http://msdn.microsoft.com/en-us/library/windows/apps/br230232.aspx](http://msdn.microsoft.com/en-us/library/windows/apps/br230232.aspx.md). Same is for CRT functions [http://msdn.microsoft.com/en-us/library/hh674596(v=vs.110).aspx](http://msdn.microsoft.com/en-us/library/hh674596(v=vs.110).aspx.md)
