/*
using UnityEngine;
using System.Collections;

public class ComponentsCall : MonoBehaviour {
    public HingeJoint[] hingeJoints;
    void Example() {
        hingeJoints = GetComponents<HingeJoint>();
        foreach (HingeJoint joint in hingeJoints) {
            joint.useSpring = false;
        }
    }
}
*/
/*
import UnityEngine
import System.Collections

class ComponentsCall(MonoBehaviour):

	public hingeJoints as (HingeJoint)

	def Example():
		hingeJoints = GetComponents[of HingeJoint]()
		for joint as HingeJoint in hingeJoints:
			joint.useSpring = false

*/
var hingeJoints : HingeJoint[];

hingeJoints = GetComponents (HingeJoint);
for (var joint : HingeJoint in hingeJoints) {
    joint.useSpring = false;
}


