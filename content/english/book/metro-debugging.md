Metro: Debugging
================


When you have a crash, or a weird behavior, always check the player log which is located here -  <user>\AppData\Local\Packages\<productname>\TempState. When submitting a bug, please include the player log as well, it can give invaluable information.

Starting from 07-12 you should be able to debug your scripts with Visual Studio. Currently it's only possible to debug C# scripts.
Here are simple steps how to do it (these steps might change in the future builds):

* Build Visual Studio solution. You can ignore Autoconnect Profiler and Script Debugging checkoxes, on Metro they do not do anything.


![](http://docwiki.hq.unity3d.com/uploads/Main/metro-debugging-editor.jpg)  

* Open the newly created solution file. It contains Assembly-CSharp.pdb, that means you are able to debug your C# files.
* The C# files are not included in this project, so you need to include them, to do so - in Solution Explorer right click on the Solution->Add->Existing Project, navigate to your Unity project and include Assembly-CSharp.csproj.
* You now have all of your C# files, and you can place the breakpoints you want.
* Before pressing F5, set Debug Type to Mixed (Managed and Native)
* Click F5 and enjoy, you should see something like this:


![](http://docwiki.hq.unity3d.com/uploads/Main/metro-debugging-vs.jpg)  
