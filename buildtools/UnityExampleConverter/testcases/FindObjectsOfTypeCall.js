/*
using UnityEngine;
using System.Collections;

public class FindObjectsOfTypeCall : MonoBehaviour {
    void OnMouseDown() {
        HingeJoint[] hinges = FindObjectsOfType(typeof(HingeJoint)) as HingeJoint[];
        foreach (HingeJoint hinge in hinges) {
            hinge.useSpring = false;
        }
    }
}
*/
/*
import UnityEngine
import System.Collections

class FindObjectsOfTypeCall(MonoBehaviour):

	def OnMouseDown():
		hinges as (HingeJoint) = FindObjectsOfType(HingeJoint)
		for hinge as HingeJoint in hinges:
			hinge.useSpring = false
*/
// When clicking on the object, it will disable all springs on all 
// hinges in the scene.

function OnMouseDown () {
	var hinges : HingeJoint[] = FindObjectsOfType(HingeJoint) as HingeJoint[];
	for (var hinge : HingeJoint in hinges) {
		hinge.useSpring = false;
	}
}
