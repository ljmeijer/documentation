/*
using UnityEngine;
using System.Collections;

public class OperationInsideAParam : MonoBehaviour {
    void Example() {
        transform.position = new Vector3(0, 0, 0);
        GL.Vertex3(Screen.width - Screen.width / 4, Screen.height / 2, 1);
    }
}
*/
/*
import UnityEngine
import System.Collections

class OperationInsideAParam(MonoBehaviour):

	def Example():
		transform.position = Vector3(0, 0, 0)
		GL.Vertex3((Screen.width - (Screen.width / 4)), (Screen.height / 2), 1)
*/
transform.position = new Vector3(0,0,0);
GL.Vertex3(Screen.width - Screen.width/4, Screen.height/2, 1);
