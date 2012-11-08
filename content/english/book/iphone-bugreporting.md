Reporting crash bugs on iOS
===========================

Before submitting a bug report, please check the [iOS Troubleshooting](TroubleShooting#iPhoneTroubleShooting.md) page, where you will find solutions to common crashes and other problems.

If your application crashes in the Xcode debugger then you can add valuable information to your bug report as follows:-
1. Click Continue (<span class=component>Run->Continue</span>) twice
1. Open the debugger console (<span class=component>Run->Console</span>) and enter (in the console): __thread apply all bt__
1. Copy __all__ console output and send it together with your bugreport.

If your application crashes on the iOS device then you should retrieve the crash report as described [here](http://developer.apple.com/iphone/library/technotes/tn2008/tn2151.html#ACQUIRING_CRASH_REPORTS.md) on Apple's website. Please attach the crash report, your built application and console log to your bug report before submitting.
