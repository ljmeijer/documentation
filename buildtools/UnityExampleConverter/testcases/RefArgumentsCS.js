/*
using UnityEngine;
using System.Collections;

public class RefArgumentsCS : MonoBehaviour {
    public int currentHealth = 0;
    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
        if (stream.isWriting) {
            int healthC = currentHealth;
            stream.Serialize(ref healthC);
        } else {
            int healthZ = 0;
            stream.Serialize(ref healthZ);
            currentHealth = healthZ;
        }
    }
}
*/
/*
import UnityEngine
import System.Collections

class RefArgumentsCS(MonoBehaviour):

	public currentHealth as int = 0

	def OnSerializeNetworkView(stream as BitStream, info as NetworkMessageInfo):
		if stream.isWriting:
			healthC as int = currentHealth
			stream.Serialize(healthC)
		else:
			healthZ as int = 0
			stream.Serialize(healthZ)
			currentHealth = healthZ
*/

// This objects health information

var currentHealth : int = 0;

function OnSerializeNetworkView(stream : BitStream, info : NetworkMessageInfo) {
	if (stream.isWriting) {
		var healthC : int = currentHealth;
		stream.Serialize(healthC);
	} else {
		var healthZ : int = 0;
		stream.Serialize(healthZ);
		currentHealth = healthZ;
	}	
}
