Installing Multiple Versions of Unity
=====================================

You can install more than one version of Unity on your machine as long as you follow the correct naming conventions for your folders.  You need to rename each of the Unity folders themselves, so that the hierarchy looks like:

````

Unity_3.4.0
---Editor
---MonoDevelop
Unity_4.0b7
---Editor
---MonoDevelop

````

If you rename each Editor folder inside a single Unity folder you will overwrite the MonoDevelop folder and this will cause serious stability problems and unexpected crashes.  

