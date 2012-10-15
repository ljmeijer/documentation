/*
using UnityEngine;
using System.Collections;

public class ArrayManualFill : MonoBehaviour {
    public string[] toolbarStrings = new string[] {"Toolbar1", "Toolbar2", "Toolbar3"};
    void Start() {
        gameObject.AddComponent("MeshFilter");
        gameObject.AddComponent("MeshRenderer");
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        mesh.vertices = new Vector3[] {new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0)};
        mesh.uv = new Vector2[] {new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1)};
        mesh.triangles = new int[] {0, 1, 2};
    }
}
*/
/*
import UnityEngine
import System.Collections

class ArrayManualFill(MonoBehaviour):

	public toolbarStrings as (string) = ('Toolbar1', 'Toolbar2', 'Toolbar3')

	def Start():
		gameObject.AddComponent('MeshFilter')
		gameObject.AddComponent('MeshRenderer')
		mesh as Mesh = GetComponent[of MeshFilter]().mesh
		mesh.Clear()
		mesh.vertices = (Vector3(0, 0, 0), Vector3(0, 1, 0), Vector3(1, 1, 0))
		mesh.uv = (Vector2(0, 0), Vector2(0, 1), Vector2(1, 1))
		mesh.triangles = (0, 1, 2)
*/
var toolbarStrings : String[] = ["Toolbar1", "Toolbar2", "Toolbar3"];

function Start () {
    gameObject.AddComponent("MeshFilter");
    gameObject.AddComponent("MeshRenderer");
    var mesh : Mesh = GetComponent(MeshFilter).mesh;

    mesh.Clear();
    mesh.vertices = [Vector3(0,0,0), Vector3(0,1,0), Vector3(1, 1, 0)];
    mesh.uv = [Vector2 (0, 0), Vector2 (0, 1), Vector2 (1, 1)];
    mesh.triangles = [0, 1, 2];
}
