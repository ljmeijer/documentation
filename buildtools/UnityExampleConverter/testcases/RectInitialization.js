/*
using UnityEngine;
using System.Collections;

public class RectInitialization : MonoBehaviour {
    void Update() {
        if (Input.GetButtonDown("Jump")) {
            float margin = Random.Range(0.0F, 0.3F);
            camera.rect = new Rect(margin, 0, 1, 1);
        }
    }
}
*/
/*
import UnityEngine
import System.Collections

class RectInitialization(MonoBehaviour):

	def Update():
		if Input.GetButtonDown('Jump'):
			margin as single = Random.Range(0.0F, 0.3F)
			camera.rect = Rect(margin, 0, 1, 1)
*/
// Change the width of the viewport each time space key is pressed
function Update () {
    if (Input.GetButtonDown ("Jump")) {
        // choose the margin randomly
        var margin : float = Random.Range (0.0, 0.3);
        // setup the rectangle
        camera.rect = Rect (margin, 0, 1, 1);
    }
}
