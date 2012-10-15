/*
using UnityEngine;
using System.Collections;

public class CarrierReturnScape : MonoBehaviour {
    void Update() {
        foreach (char c in Input.inputString) {
            if (c == "\b") {
            } else
                if (c == "\n" || c == "\r") {
                } else {
                }
        }
    }
}
*/
/*import UnityEngine
import System.Collections

class CarrierReturnScape(MonoBehaviour):

	def Update():
		for c as char in Input.inputString:
			if c == '\b':
				pass
			elif (c == '\n') or (c == '\r'):
				pass
			else:
				pass

*/
function Update () {
	for (var c : char in Input.inputString) {

		if (c == "\b") {
			
		} else if (c == "\n" || c == "\r") {
			
		} else {
			
		}
    }
}
