/*
using UnityEngine;
using System.Collections;

public class typeofParams : MonoBehaviour {
    public AnimationCurve curve = new AnimationCurve();
    public AnimationClip clip = new AnimationClip();
    void Example() {
        curve.keys = new Keyframe[] {new Keyframe(0, 0, 0, 0), new Keyframe(1, 3, 0, 0), new Keyframe(2, 0.0F, 0, 0)};
        clip.SetCurve("Lower", typeof(Transform), "m_LocalPosition.z", curve);
        clip.SetCurve("Lower", typeof(Transform), "m_LocalPosition.z", curve);
    }
}
*/
/*
import UnityEngine
import System.Collections

class typeofParams(MonoBehaviour):

	public curve as AnimationCurve = AnimationCurve()

	public clip as AnimationClip = AnimationClip()

	def Example():
		curve.keys = (Keyframe(0, 0, 0, 0), Keyframe(1, 3, 0, 0), Keyframe(2, 0.0F, 0, 0))
		clip.SetCurve('Lower', Transform, 'm_LocalPosition.z', curve)
		clip.SetCurve('Lower', typeof(Transform), 'm_LocalPosition.z', curve)
*/
var curve : AnimationCurve = new AnimationCurve();
curve.keys = [ new Keyframe (0, 0, 0, 0), new Keyframe (1, 3, 0, 0), new Keyframe (2, 0.0, 0, 0) ];
var clip : AnimationClip = new AnimationClip();
clip.SetCurve("Lower", Transform, "m_LocalPosition.z", curve);
clip.SetCurve("Lower", typeof(Transform), "m_LocalPosition.z", curve);

