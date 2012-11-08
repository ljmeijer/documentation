Playstation3: Trophies
======================


Unity allows you to use the Trophy system of the PS3 by means of the[PS3TrophyUtility](ScriptRef:PS3TrophyUtility.html) class. The trophy system rewards users upon accomplishing various missions in the game and keeps a record of these accomplishments.

The PS3 Samples -> Trophy unity package included with the Unity PS3 Addon shows how to save and load data to/from the PS3.

_Please refer to https://ps3.scedev.net/docs/ps3-en,Trophy_System-Overview/1/ for more information regarding the Trophy System_

Usage
-----


###1. Initialize the Utility

````
// Initialize save data
PS3TrophyUtility.Init (trophyCommId, trophyCommSig, false);
````

The initialization requires that you pass as arguments the NP Communication ID and NP Communication Signature, provided for your title. The procedure runs on a thread in a non-blocking call, so you need to wait unti it is complete:

````
// Wait until the PS3TrophyUtility is initialized
while (!PS3TrophyUtility.HasCompleted ())
    yield return null;
````


###2. Awarding (Unlocking) Trophies

Before awarding a Trophy you must first verify that it has not already been awarded. If you try to award a trophy that has been awarded the system will return an error.

````
if (PS3TrophyUtility.GetTrophyUnlockState(trophyId) == 0) {
    while (!PS3TrophyUtility.HasCompleted ()) {
        // If the same trophy suddenly gets unlocked by another process, exit this one
        if (PS3TrophyUtility.GetTrophyUnlockState (trophyId) == 1) {
            yield break;
        }
        yield return new WaitForSeconds(0.2f);
    }
    ...

````

Once you have verified that it has not been awarded, you can then Unlock it:

````
    ...
    PS3TrophyUtility.UnlockTrophy (trophyId);
}

````


###3. Displaying currently awarded Trophies

It is possible to use the PS3TrophyUtility.GetTrophyName and PS3TrophyUtility.GetTrophyDescription to get the details of each specific Trophy.

````
string trophyName = PS3TrophyUtility.GetTrophyName (trophyId);
string trophyDesc = PS3TrophyUtility.GetTrophyDescription (trophyId);
````
