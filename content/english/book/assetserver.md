Asset Server (Pro Only)
=======================


Unity Asset Server Overview
---------------------------


The <span class=keyword>Unity Asset Server</span> is an asset and version control system with a graphical user interface integrated into Unity.  It is meant to be used by team members working together on a project on different computers either in-person or remotely.  The Asset Server is highly optimized for handling large binary assets in order to cope with large multi gigabyte project folders. When uploading assets, <span class=keyword>Import Settings</span> and other meta data about each asset is uploaded to the asset server as well. Renaming and moving files is at the core of the system and well supported.

It is available only for Unity Pro, and is an additional license per client.  To purchase an Asset Server Client License, please visit the Unity store at [http://unity3d.com/store](http://unity3d.com/store)

New to Source Control?
----------------------


If you have never used Source Control before, it can be a little unfriendly to get started with any versioning system.  Source Control works by storing an entire collection of all your assets - meshes, textures, materials, scripts, and everything else - in a database on some kind of server.  That server might be your home computer, the same one that you use to run Unity.  It might be a different computer in your local network.  It might be a remote machine colocated in a different part of the world.  It could even be a virtual machine.  There are a lot of options, but the location of the server doesn't matter at all.  The important thing is that you can access it somehow over your network, and that it stores your game data.

In a way, the Asset Server functions as a backup of your Project Folder.  You do not directly manipulate the contents of the Asset Server while you are developing.  You make changes to your Project locally, then when you are done, you <span class=menu>Commit Changes</span> to the Project on the Server.  This makes your local Project and the Asset Server Project identical.

Now, when your fellow developers make a change, the Asset Server is identical to their Project, but not yours.  To synchronize your local Project, you request to <span class=menu>Update from Server</span>.  Now, whatever changes your team members have made will be downloaded from the server to your local Project.

This is the basic workflow for using the Asset Server.  In addition to this basic functionality, the Asset Server allows for rollback to previous versions of assets, detailed file comparison, merging two different scripts, resolving conflicts, and recovering deleted assets.

Setting up the Asset Server
---------------------------


The Asset Server requires a one time server setup and a client configuration for each user.  You can read about how to do that in the [Asset Server Setup page](assetserver-Setup).

The rest of this guide explains how to deploy, administrate, and regularly use the Asset Server.

(:include assetserver-DailyUse:)
