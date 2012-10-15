/*
using UnityEngine;
using System.Collections;

public class KeyframeInitialization : MonoBehaviour {
    public Keyframe k;
    void Example() {
        k = new Keyframe(10, 20);
        k.inTangent = 45;
    }
}
*/
/*
import UnityEngine
import System.Collections

class KeyframeInitialization(MonoBehaviour):

	public k as Keyframe

	def Example():
		k = Keyframe(10, 20)
		k.inTangent = 45
*/
var k : Keyframe;
k = Keyframe(10, 20);
k.inTangent = 45;
