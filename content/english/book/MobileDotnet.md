Using .NET API 2.0 compatibility level
======================================

<a id="iOS"></a>

##ios Details
Now Unity iOS supports two .NET API compatibility levels: .NET 2.0 and a subset of .NET 2.0 .You can select the appropriate level in the [Player Settings](class-PlayerSettings.md).

.NET API 2.0
------------

Unity supports the <span class=component>.NET 2.0</span> API profile. This is close to the full .NET 2.0 API and offers the best compatibility with pre-existing .NET code.  However, the application's build size and startup time will be relatively poor.

__Note:__ Unity iOS does not support namespaces in scripts. If you have a third party library supplied as source code then the best approach is to compile it to a DLL outside Unity and then drop the DLL file into your project's Assets folder.

.NET 2.0 Subset
---------------

Unity also supports the <span class=component>.NET 2.0 Subset</span> API profile. This is close to the Mono "monotouch" profile, so many limitations of the "monotouch" profile also apply to Unity's .NET 2.0 Subset profile. More information on the limitations of the "monotouch" profile can be found [here](http://monotouch.net/Documentation/Limitations.md). The advantage of using this profile is reduced build size (and startup time) but this comes at the expense of compatibility with existing .NET code.

<a id="Android"></a>

###android Details
Unity Android supports two .NET API compatibility levels: .NET 2.0 and a subset of .NET 2.0 You can select the appropriate level in the [Player Settings](class-PlayerSettings.md).

.NET API 2.0
------------

Unity supports the <span class=component>.NET 2.0</span> API profile; It is close to the full .NET 2.0 API and offers the best compatibility with pre-existing .NET code. However, the application's build size and startup time will be relatively poor.

__Note:__ Unity Android does not support namespaces in scripts. If you have a third party library supplied as source code then the best approach is to compile it to a DLL outside Unity and then drop the DLL file into your project's Assets folder.

.NET 2.0 Subset
---------------

Unity also supports the <span class=component>.NET 2.0 Subset</span> API profile. This is close to the Mono "monotouch" profile, so many limitations of the "monotouch" profile also apply to Unity's .NET 2.0 Subset profile. More information on the limitations of the "monotouch" profile can be found [here](http://monotouch.net/Documentation/Limitations.md). The advantage of using this profile is reduced build size (and startup time) but this comes at the expense of compatibility with existing .NET code.
