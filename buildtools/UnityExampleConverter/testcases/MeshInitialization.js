/*
using UnityEngine;
using System.Collections;

public class MeshInitialization : MonoBehaviour {
    void Start() {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }
}
*/
/*
import UnityEngine
import System.Collections

class MeshInitialization(MonoBehaviour):

	def Start():
		mesh as Mesh = Mesh()
		GetComponent[of MeshFilter]().mesh = mesh
*/

function Start () {
	var mesh : Mesh = new Mesh ();
	GetComponent(MeshFilter).mesh = mesh;
}
