Reporting crash bugs under Android
==================================

Before submitting a bug with just "it crashes" in the message body, please look through the [Troubleshooting Android development](TroubleShooting#AndroidTroubleShooting.md) page first.

At this point there are no advanced debug tools to investigate on-device app crashes. However you can use <span class=keyword>adb</span> application (found under Android-SDK/platform-tools) with <span class=keyword>logcat</span> parameter. It prints status reports from your device. These reports may include information related to the occurred crash.

If you are sure that the crash you're experiencing happens due to a bug in Unity software, please save the <span class=keyword>adb logcat</span> output, conduct a repro project and use the bugreporter (<span class=menu>Help/Report a bug</span>) to inform us about it. We will get back to you as soon as we can.
