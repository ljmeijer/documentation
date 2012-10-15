/*
using UnityEngine;
using System.Collections;

public class ObjectFindObjectsOfTypeCall : MonoBehaviour {
    void Start() {
        foreach (Renderer render in Object.FindObjectsOfType(typeof(Renderer))) {
            if (render.material.HasProperty("_Color"))
                render.material.SetVector("_Color", new Vector4(0, 1, 0, 1));
            
        }
    }
}
*/
/*
import UnityEngine
import System.Collections

class ObjectFindObjectsOfTypeCall(MonoBehaviour):

	def Start():
		for render as Renderer in Object.FindObjectsOfType(Renderer):
			if render.material.HasProperty('_Color'):
				render.material.SetVector('_Color', Vector4(0, 1, 0, 1))

*/
function Start() {
	for(var render : Renderer in Object.FindObjectsOfType(Renderer)) {
		if(render.material.HasProperty("_Color")){
			render.material.SetVector("_Color",Vector4(0,1,0,1));
	 	}
	}
}
