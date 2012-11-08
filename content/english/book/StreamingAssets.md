Streaming Assets
================


Most assets in Unity are combined into the project when it is built. However, it is sometimes useful to place files into the normal filesystem on the target machine to make them accessible via a pathname. An example of this is the deployment of a movie file on iOS devices; the original movie file must be available from a location in the filesystem to be played by the PlayMovie function.

Any files placed in a folder called StreamingAssets in a Unity project will be copied verbatim to a particular folder on the target machine. On a desktop computer (Mac OS or Windows) the location of the files can be obtained with the following code:-

  [@path = = Application.dataPath + "/StreamingAssets";

On iOS, you should use:-

  [@path = Application.dataPath + "/Raw";

...while on Android, you should use:-

  [@path = "jar:file://" + Application.dataPath + "!/assets/";

Note that on Android, the files are contained within a compressed .jar file (which is essentially the same format as standard zip-compressed files). This means that if you do not use Unity's WWW class to retrieve the file then you will need to use additional software to see inside the .jar archive and obtain the file.
