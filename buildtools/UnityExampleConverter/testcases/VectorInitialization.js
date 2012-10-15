/*
using UnityEngine;
using System.Collections;

public class VectorInitialization : MonoBehaviour {
    void Start() {
        Vector3 v1 = new Vector3(0.4F, 1, 70);
        Vector2 v2 = new Vector2(0, 5.5F);
        Vector4 v3 = new Vector4(0, 3, 2, 5);
        Vector3 v4 = Vector3.zero;
    }
    void Example() {
        transform.localPosition = new Vector3(0, 0, 0);
        print(transform.localPosition.y);
    }
}
*/
/*
import UnityEngine
import System.Collections

class VectorInitialization(MonoBehaviour):

	def Start():
		v1 as Vector3 = Vector3(0.4F, 1, 70)
		v2 as Vector2 = Vector2(0, 5.5F)
		v3 as Vector4 = Vector4(0, 3, 2, 5)
		v4 as Vector3 = Vector3.zero

	def Example():
		transform.localPosition = Vector3(0, 0, 0)
		print(transform.localPosition.y)
*/
// Move the object to the same position as the parent:
transform.localPosition = Vector3(0, 0, 0);
function Start(){
    var v1 : Vector3 = Vector3(0.4,1, 70);
    var v2 : Vector2 = Vector2(0,5.5);
    var v3 : Vector4 = Vector4(0,3,2,5);
    var v4 : Vector3 = Vector3.zero;
}

// Get the y component of the position relative to the parent
// and print it to the Console
print(transform.localPosition.y);
