/*using UnityEngine;
using System.Collections;

public class OutArgumentCS : MonoBehaviour {
    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100.0F))
            float distanceToGround = hit.distance;
        
    }
}
*/
/*
import UnityEngine
import System.Collections

class OutArgumentCS(MonoBehaviour):

	def Update():
		hit as RaycastHit
		if Physics.Raycast(transform.position, -Vector3.up, hit, 100.0F):
			distanceToGround as single = hit.distance
*/

function Update () {
	var hit : RaycastHit;
	if (Physics.Raycast (transform.position, -Vector3.up, hit, 100.0)) {
		var distanceToGround = hit.distance;
	}
}
