Metro : Project Types
=====================


There are four Project Types in Unity Metro:
* XAML C++ Solution
* XAML C# Solution
* D3D11 C++ Solution
* D3D11 C# Solution

###XAML Solutions

These types will generate a solution with XAML code on top. XAML code can be modified after generation.

###D3D11 Solutions

These type will generate a project with a single D3d11 window without XAML layer on top. This will give faster performance results, so it is preferred if no XAML layer is needed.

###C# Solutions

With C# solution generated you are able to use managed assemblies, such as UnityEngine.dll, Assembly-CSharp.dll, etc.

###C++ Solutions

C++ Solutions provide you a possibility to use statically linked libraries.

When you build a Visual Studio solution, Unity will create files like resources, vcproj, xaml, cpp/h files, if you build a project on top of the same directory, all of the files will be overwritten except these:
* Project files & solution files (.vcproj, .sln, etc.)
* Source files (App.xaml.cs, App.xaml.cpp)
* XAML files (App.xaml, MainPage.xaml, etc.)
* Image files (Assets\SmallTile.png, Assets\StoreLogo.png, etc.)
* Manifest file - Package.appxmanifest


It is safe for you to modify these files, and if you want to revert to previous state, just remove the file, and build your project on top of the folder.
