Playstation3: NP DRM
====================


The [PS3DRMUtility](ScriptRef:PS3DRMUtility.html) class gives you access to the NP DRM utility for the PlayStation 3. The NP DRM utility performs access rights management for the PlayStation®Network ("NP") commerce service and is used to access NPDRM files.

The PS3 Samples -> DRM unity package included with the Unity PS3 Addon shows a working example of this utility.

_Please refer to https://ps3.scedev.net/docs/ps3-en,NP_DRM-Overview for more information about NP DRM_

Using the utility
-----------------


###1. Initialize the Utility

````
// Init the DRM Utility
PS3DRMUtility.Init();
````

###2. Verify the upgrade license

````
PS3DRMUtility.VerifyUpgradeLicense("XXYYYY-UNTY31337_00-UNITYTESTLICENCE");
````

The previous function is called in a separate thread. You need to wait wait until it completes to query the result of the operation:

````
while (!PS3DRMUtility.HasCompleted())
    yield return 0;
		
if (PS3DRMUtility.GetResult() == 0) 
    Debug.Log ("This is a full version");
else
    Debug.Log ("This is a trial");
}
````
