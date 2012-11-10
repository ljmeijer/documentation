Account Setup
=============


There are some steps you must follow before you can build and run any code (including Unity-built games) on your iOs device.  These steps are prerequisite to publishing your own iOS games.

1. Apply to Apple to Become a Registered iPhone/iPad Developer
--------------------------------------------------------------

You do this through Apple's website: http://developer.apple.com/iphone/program/


2. Upgrade your Operating System and iTunes Installation
--------------------------------------------------------

Please note that these are Apple's requirements as part of using the iPhone SDK, but the requirements can change from time to time.

3. Download the iPhone SDK
--------------------------

Download the latest iOS SDK from the [iOS dev center](http://developer.apple.com/iphone.md) and install it.  Do __not__ download the beta version of the SDK - you should use only the latest shipping version. Note that downloading and installing the iPhone SDK will also install XCode.

4. Get Your Device Identifier
-----------------------------

Connect your iOS device to the Mac with the USB cable and launch XCode. XCode will detect your phone as a new device and you should register it with the "Use For Development" button. This will usually open the Organizer window but if it doesn't then go to Window->Organizer. You should see your iOS device) in the devices list on the left; select it and note your device's identifier code (which is about 40 characters long).

5. Add Your Device
------------------

Log in to the [iPhone developer center](http://developer.apple.com/iphone.md) and enter the program portal (button on the right). Go to the Devices page via the link on left side and then click the Add Device button on the right. Enter a name for your device (alphanumeric characters only) and your device's identifier code (noted in step 5 above).  Click the Submit button when done.

6. Create a Certificate
-----------------------

From the iPhone Developer Program Portal, click the Certificates link on the left side and follow the instructions listed under How-To...

7. Download and Install the WWDR Intermediate Certificate
---------------------------------------------------------

The download link is in the same "Certificates" section (just above the "Important Notice" rubric) as WWDR Intermediate Certificate.  Once downloaded, double-click the certificate file to install it.

8. Create a Provisioning File
-----------------------------

Provisioning profiles are a bit complex, and need to be set up according to the way you have organized your team.  It is difficult to give general instructions for provisioning, so we recommend that you look at the [Provisioning How-to section](http://developer.apple.com/iphone/manage/provisioningprofiles/howto.action.md) on the Apple Developer website.
