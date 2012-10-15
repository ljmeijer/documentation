/*
using UnityEngine;
using System.Collections;

public class ForeachItemInArray : MonoBehaviour {
    public HingeJoint[] hingeJoints;
    void Example() {
        hingeJoints = gameObject.GetComponents<HingeJoint>();
        foreach (HingeJoint joint in hingeJoints) {
            joint.useSpring = false;
        }
    }
}
*/
/*
import UnityEngine
import System.Collections

class ForeachItemInArray(MonoBehaviour):

	public hingeJoints as (HingeJoint)

	def Example():
		hingeJoints = gameObject.GetComponents[of HingeJoint]()
		for joint as HingeJoint in hingeJoints:
			joint.useSpring = false
*/
var hingeJoints : HingeJoint[];
hingeJoints = gameObject.GetComponents (HingeJoint);
for (var joint : HingeJoint in hingeJoints) {
	joint.useSpring = false;
}
