Visual Studio C# Integration
============================


What does this feature get me?
------------------------------

A more sophisticated C# development environment.  
Think smart autocompletion, computer-assisted changes to source files, smart syntax highlighting and more.

What's the difference between Express and Pro?
----------------------------------------------

VisualStudio C# 2010 is a product from Microsoft. It comes in an Express and a Profesional edition.  
The Express edition is free, and you can download it from here: http://www.microsoft.com/express/vcsharp/   
The Professional edition is not free, you can find out more information about it here: http://www.microsoft.com/visualstudio/en-us/products/professional/default.mspx

Unity's VisualStudio integration has two components:  
1) Unity creating and maintaining VisualStudio project files. __Works with Express and with Profesional.__  
2) Unity automatically opening VisualStudio when you doubleclick on a script, or error in Unity. __Works with Professional only.__


I've got Visual Studio Express, how do I use it?
------------------------------------------------

* In Unity, select from the menu <span class=menu>Assets->Sync VisualStudio Project</span>
* Find the newly created .sln file in your Unity project (one folder up from your Assets folder)
* Open that file with Visual Studio Express.
* You can now edit all your script files, and switch back to Unity to use them.


I've got Visual Studio Profesional, how do I use it?
----------------------------------------------------

* In Unity, go to Edit->Preferences, and make sure that Visual Studio is selected as your preferred external editor.
* Doubleclick a C# file in your project. Visual Studio should automatically open that file for you.
* You can edit the file, save, and switch back to Unity.


A few things to watch out for:
------------------------------


* Even though Visual Studio comes with its own C# compiler, and you can use it to check if you have errors in your c# scripts, Unity still uses its own C# compiler to compile your scripts. Using the Visual Studio compiler is still quite useful, because it means you don't have to switch to Unity all the time to check if you have any errors or not.

* Visual Studio's C# compiler has some more features than Unity's C# compiler currently has. This means that some code (especially newer c# features) will not give an error in Visual Studio but will give an error in Unity.

* Unity automatically creates and maintains a Visual Studio .sln and .csproj file. Whenever somebody adds/renames/moves/deletes a file from within Unity, Unity regenerates the .sln and .csproj files. You can add files to your solution from Visual Studio as well. Unity will then import those new files, and the next time Unity creates the project files again, it will create them with this new file included.

* Unity does not regenerate the Visual Studio project files after an AssetServer update, or a SVN update. You can manually ask Unity to regenerate the Visual Studio project files trough the menu: <span class=menu>Assets->Sync VisualStudio Project</span>
