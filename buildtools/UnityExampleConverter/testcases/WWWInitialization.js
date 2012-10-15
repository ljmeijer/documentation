/*using UnityEngine;
using System.Collections;

public class WWWInitialization : MonoBehaviour {
    public WWW w;
    void Start() {
        w = new WWW("TEST");
    }
}
*/
/*
import UnityEngine
import System.Collections

class WWWInitialization(MonoBehaviour):

	public w as WWW

	def Start():
		w = WWW('TEST')


*/
var w : WWW;

function Start() { 
	w = new WWW("TEST");
}
