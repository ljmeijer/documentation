/*
using UnityEngine;
using System.Collections;

public class OnMemberExpressionQuotes : MonoBehaviour {
    void Update() {
        if (Input.GetButtonDown("Fire1"))
            animation.PlayQueued("shoot", QueueMode.PlayNow);
        
    }
}
*/
/*
import UnityEngine
import System.Collections

class OnMemberExpressionQuotes(MonoBehaviour):

	def Update():
		if Input.GetButtonDown('Fire1'):
			animation.PlayQueued('shoot', QueueMode.PlayNow)
*/
function Update () {
    if (Input.GetButtonDown("Fire1"))    
        animation.PlayQueued("shoot", QueueMode.PlayNow);
}
