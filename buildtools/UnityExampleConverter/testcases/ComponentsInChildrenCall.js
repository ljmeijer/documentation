/*
using UnityEngine;
using System.Collections;

public class ComponentsInChildrenCall : MonoBehaviour {
    public HingeJoint[] hingeJoints;
    void Example() {
        hingeJoints = GetComponentsInChildren<HingeJoint>();
        foreach (HingeJoint joint in hingeJoints) {
            joint.useSpring = false;
        }
    }
}
*/
/*
import UnityEngine
import System.Collections

class ComponentsInChildrenCall(MonoBehaviour):

	public hingeJoints as (HingeJoint)

	def Example():
		hingeJoints = GetComponentsInChildren[of HingeJoint]()
		for joint as HingeJoint in hingeJoints:
			joint.useSpring = false

*/
var hingeJoints : HingeJoint[];

hingeJoints = GetComponentsInChildren (HingeJoint);
for (var joint : HingeJoint in hingeJoints) {
    joint.useSpring = false;
}
