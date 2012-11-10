Social API
==========


Social API is Unity's point of  access to social features, such as:
* User profiles
* Friends lists
* Achievements
* Statistics / Leaderboards

It provides a unified interface to different social back-ends, such as <span class=keyword>XBox Live</span> or <span class=keyword>GameCenter</span>, and is meant to be used primarily by programmers on the game project. 

The Social API is mainly an asynchronous API, and the typical way to use it is by making a function call and registering for a callback to when that function completes. The asynchronous function may have side effects, such as populating certain state variables in the API, and the callback could contain data from the server to be processed. 

The Social class resides in the UnityEngine namespace and so is always available but the other Social API classes are kept in their own namespace, UnityEngine.SocialPlatforms. Furthermore, implementations of the Social API are in a sub-namespace, like SocialPlatforms.GameCenter.

Here is an example (JavaScript) of how one might use the Social API:

````

import UnityEngine.SocialPlatforms;

function Start () {
    // Authenticate and register a ProcessAuthentication callback
    // This call needs to be made before we can proceed to other calls in the Social API
    Social.localUser.Authenticate (ProcessAuthentication);
}

// This function gets called when Authenticate completes
// Note that if the operation is successful, Social.localUser will contain data from the server. 
function ProcessAuthentication (success: boolean) {
    if (success) {
        Debug.Log ("Authenticated, checking achievements");

        // Request loaded achievements, and register a callback for processing them
        Social.LoadAchievements (ProcessLoadedAchievements);
    }
    else
        Debug.Log ("Failed to authenticate");
}

// This function gets called when the LoadAchievement call completes
function ProcessLoadedAchievements (achievements: IAchievement[]) {
    if (achievements.Length == 0)
        Debug.Log ("Error: no achievements found");
    else
        Debug.Log ("Got " + achievements.Length + " achievements");
    
    // You can also call into the functions like this
    Social.ReportProgress ("Achievement01", 100.0, function(result) {
        if (result)
            Debug.Log ("Successfully reported achievement progress");
        else
            Debug.Log ("Failed to report achievement");
    });
}

````

Here is the same example using C#.

````

using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SocialExample : MonoBehaviour {
	
    void Start () {
        // Authenticate and register a ProcessAuthentication callback
        // This call needs to be made before we can proceed to other calls in the Social API
        Social.localUser.Authenticate (ProcessAuthentication);
    }

    // This function gets called when Authenticate completes
    // Note that if the operation is successful, Social.localUser will contain data from the server. 
    void ProcessAuthentication (bool success) {
        if (success) {
            Debug.Log ("Authenticated, checking achievements");

            // Request loaded achievements, and register a callback for processing them
            Social.LoadAchievements (ProcessLoadedAchievements);
        }
        else
            Debug.Log ("Failed to authenticate");
    }

    // This function gets called when the LoadAchievement call completes
    void ProcessLoadedAchievements (IAchievement[] achievements) {
        if (achievements.Length == 0)
            Debug.Log ("Error: no achievements found");
        else
            Debug.Log ("Got " + achievements.Length + " achievements");
	    
        // You can also call into the functions like this
        Social.ReportProgress ("Achievement01", 100.0, result => {
            if (result)
                Debug.Log ("Successfully reported achievement progress");
            else
                Debug.Log ("Failed to report achievement");
        });
    }
}

````
For more info on the Social API, check out the [Social API Scripting Reference](ScriptRef:Social.html)
