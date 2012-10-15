/*
using UnityEngine;
using System.Collections;

public class AnimationCurveInitialization : MonoBehaviour {
    private AnimationCurve anim;
    private Keyframe[] ks;
    void Start() {
        ks = new Keyframe[50];
        int i = 0;
        while (i < ks.Length) {
            ks[i] = new Keyframe(i, Mathf.Sin(i));
            i++;
        }
        anim = new AnimationCurve(ks);
    }
    void Update() {
        transform.position = new Vector3(Time.time, anim.Evaluate(Time.time), 0);
    }
}
*/
/*
import UnityEngine
import System.Collections

class AnimationCurveInitialization(MonoBehaviour):

	private anim as AnimationCurve

	private ks as (Keyframe)

	def Start():
		ks = array[of Keyframe](50)
		i as int = 0
		while i < ks.Length:
			ks[i] = Keyframe(i, Mathf.Sin(i))
			i++
		anim = AnimationCurve(*ks)

	def Update():
		transform.position = Vector3(Time.time, anim.Evaluate(Time.time), 0)
*/
private var anim : AnimationCurve;
private var ks : Keyframe[];

function Start() {
    ks = new  Keyframe[50];
    for(var i = 0; i < ks.Length ; i++){
        ks[i] = Keyframe(i,Mathf.Sin(i));    
    }
    anim = AnimationCurve(ks);
}

function Update() {
    transform.position = Vector3(Time.time,anim.Evaluate(Time.time),0);
}
