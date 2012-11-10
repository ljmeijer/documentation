Flash: Setup
============


Installing Unity for Flash
--------------------------

To view the SWF files that Unity creates, your web browser will need Adobe Flash Player 11.2 or newer, which you can obtain from http://get.adobe.com/flashplayer/.  If you have Flash Player already installed, please visit http://kb2.adobe.com/cps/155/tn_15507.html to check that you have at least version 11.2. Adobe Flash Player 11 introduced the Stage 3D Accelerated Graphics Rendering feature that Unity requires for 3d rendering.

For system requirements see http://www.adobe.com/products/flashplayer/tech-specs.html

Flash Player Switcher
---------------------

This will allow you to switch between debug (slow) and regular (fast) versions of the Flash Player. Ensure you have Adobe AIR installed, or download it from http://get.adobe.com/air/. The Flash Player Switcher can be obtained from: https://github.com/jvanoostveen/Flash-Player-Switcher/downloads (select FlashPlayerSwitcher.air). Note: it currently supports only Mac OS X.

Other Adobe Tools/Platforms
---------------------------


No other Adobe tools or platforms are required to develop with Unity and create SWF files. To embed the SWF that Unity builds into your own Flash Application you will need one of Adobe FlashBuilder/PowerFlasher FDT/FlashDeveloper/etc and be an experienced Flash developer.  You will need to know:
* Your embedding application needs to be set to -swf-version=15 / fp11.2
* Your flash embeds wmode needs to be set to direct
