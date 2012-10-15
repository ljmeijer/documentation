/*
using UnityEngine;
using System.Collections;

public class VarArgsConstructorInvocation : MonoBehaviour {
    void Start() {
        AnimationCurve curve = new AnimationCurve(new Keyframe(0, 0, 0, 0), new Keyframe(1, 1, 0, 0));
    }
}
*/
/*
import UnityEngine
import System.Collections

class VarArgsConstructorInvocation(MonoBehaviour):

	def Start():
		curve as AnimationCurve = AnimationCurve(Keyframe(0, 0, 0, 0), Keyframe(1, 1, 0, 0))
*/
function Start () {
	var curve = AnimationCurve (Keyframe(0, 0, 0, 0), Keyframe(1, 1, 0, 0));
}
