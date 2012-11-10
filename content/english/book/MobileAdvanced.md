Advanced Unity Mobile Scripting
===============================

<a id="iOS"></a>

##ios Details
Advanced iOS scripting
======================

Determining Device Generation
-----------------------------

Different device generations support different functionality and have widely varying performance. You should query the device's generation and decide which functionality should be disabled to compensate for slower devices.

You can find the device generation from the [iPhone.generation](ScriptRef:iPhone-generation.html) property. The reported generation can be one of the following:
* <span class=component>iPhone</span>
* <span class=component>iPhone3G</span>
* <span class=component>iPhone3GS</span>
* <span class=component>iPhone4</span>
* <span class=component>iPodTouch1Gen</span>
* <span class=component>iPodTouch2Gen</span>
* <span class=component>iPodTouch3Gen</span>
* <span class=component>iPodTouch4Gen</span>
* <span class=component>iPad1Gen</span>


You can find more information about different device generations, performance and supported functionality in our [iPhone Hardware Guide](Main.iphone-Hardware.md).


Device Properties
-----------------

There are a number of device-specific properties that you can access:-

|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>[SystemInfo.deviceUniqueIdentifier](ScriptRef:SystemInfo-deviceUniqueIdentifier.html)</span> |Unique device identifier.
|<span class=component>[SystemInfo.deviceName](ScriptRef:SystemInfo-deviceName.html)</span> |User specified name for device.
|<span class=component>[SystemInfo.deviceModel](ScriptRef:SystemInfo-deviceModel.html)</span> |Is it iPhone or iPod Touch?
|<span class=component>[SystemInfo.operatingSystem](ScriptRef:SystemInfo-operatingSystem.html)</span> |Operating system name and version.
|END


Anti-Piracy Check
-----------------

Pirates will often hack an application from the AppStore (by removing Apple DRM protection) and then redistribute it for free. Unity iOS comes with an anti-piracy check which allows you to determine if your application was altered __after__ it was submitted to the AppStore.

You can check if your application is genuine (not-hacked) with the [Application.genuine](ScriptRef:Application-genuine.html) property. If this property returns <span class=keyword>false</span> then you might notify the user that he is using a hacked application or maybe disable access to some functions of your application.

__Note:__ accessing the [Application.genuine](ScriptRef:Application-genuine.html) property is a fairly expensive operation and so you shouldn't do it during frame updates or other time-critical code. 


Vibration Support
-----------------

You can trigger a vibration by calling [Handheld.Vibrate](ScriptRef:Handheld.Vibrate.html). Note that iPod Touch devices lack vibration hardware and will just ignore this call.

(:include UpdateOrder:)


<a id="Android"></a>

###android Details
Advanced Android scripting
==========================

Determining Device Generation
-----------------------------

Different Android devices support different functionality and have widely varying performance. You should target specific devices or device families and decide which functionality should be disabled to compensate for slower devices. There are a number of device specific properties that you can access to which device is being used.

__Note:__ Android Marketplace does some additional compatibility filtering, so you should not be concerned if an ARMv7-only app optimised for OGLES2 is offered to some old slow devices.

Device Properties
-----------------


|**_Property:_** |**_Function:_** |
|:---|:---|
|<span class=component>[SystemInfo.deviceUniqueIdentifier](ScriptRef:SystemInfo-deviceUniqueIdentifier.html)</span> |Unique device identifier.
|<span class=component>[SystemInfo.deviceName](ScriptRef:SystemInfo-deviceName.html)</span> |User specified name for device.
|<span class=component>[SystemInfo.deviceModel](ScriptRef:SystemInfo-deviceModel.html)</span> |Is it iPhone or iPod Touch?
|<span class=component>[SystemInfo.operatingSystem](ScriptRef:SystemInfo-operatingSystem.html)</span> |Operating system name and version.
|END


Anti-Piracy Check
-----------------

Pirates will often hack an application (by removing Apple DRM protection) and then redistribute it for free. Unity Android comes with an anti-piracy check which allows you to determine if your application was altered __after__ it was submitted to the AppStore.

You can check if your application is genuine (not-hacked) with the [Application.genuine](ScriptRef:Application-genuine.html) property. If this property returns <span class=keyword>false</span> then you might notify user that he is using a hacked application or maybe disable access to some functions of your application.

__Note:__ [Application.genuineCheckAvailable](ScriptRef:Application-genuineCheckAvailable.html) should be used along with <span class=keyword>Application.genuine</span> to verify that application integrity can actually be confirmed. Accessing the [Application.genuine](ScriptRef:Application-genuine.html) property is a fairly expensive operation and so you shouldn't do it during frame updates or other time-critical code. 


Vibration Support
-----------------

You can trigger a vibration by calling [Handheld.Vibrate](ScriptRef:Handheld.Vibrate.html). However, devices lacking vibration hardware will just ignore this call.

