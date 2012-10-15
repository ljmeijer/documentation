/*
using UnityEngine;
using System.Collections;

public class MaterialPropertyBlockInitialization : MonoBehaviour {
    public Mesh aMesh;
    public MaterialPropertyBlock materialProperty = new MaterialPropertyBlock();
    public Material aMaterial = new Material(Shader.Find("VertexLit"));
    void Update() {
        int tagID = Shader.PropertyToID("_Color");
        materialProperty.AddColor(tagID, Color.red);
        Graphics.DrawMesh(aMesh, new Vector3(0, 0, 0), Quaternion.identity, aMaterial, 0, null, 0, materialProperty);
        materialProperty.Clear();
        materialProperty.AddColor(tagID, Color.green);
        Graphics.DrawMesh(aMesh, new Vector3(5, 0, 0), Quaternion.identity, aMaterial, 0, null, 0, materialProperty);
        materialProperty.Clear();
        materialProperty.AddColor(tagID, Color.blue);
        Graphics.DrawMesh(aMesh, new Vector3(-5, 0, 0), Quaternion.identity, aMaterial, 0, null, 0, materialProperty);
        materialProperty.Clear();
    }
}
*/
/*
import UnityEngine
import System.Collections

class MaterialPropertyBlockInitialization(MonoBehaviour):

	public aMesh as Mesh

	public materialProperty as MaterialPropertyBlock = MaterialPropertyBlock()

	public aMaterial as Material = Material(Shader.Find('VertexLit'))

	def Update():
		tagID as int = Shader.PropertyToID('_Color')
		materialProperty.AddColor(tagID, Color.red)
		Graphics.DrawMesh(aMesh, Vector3(0, 0, 0), Quaternion.identity, aMaterial, 0, null, 0, materialProperty)
		materialProperty.Clear()
		materialProperty.AddColor(tagID, Color.green)
		Graphics.DrawMesh(aMesh, Vector3(5, 0, 0), Quaternion.identity, aMaterial, 0, null, 0, materialProperty)
		materialProperty.Clear()
		materialProperty.AddColor(tagID, Color.blue)
		Graphics.DrawMesh(aMesh, Vector3(-5, 0, 0), Quaternion.identity, aMaterial, 0, null, 0, materialProperty)
		materialProperty.Clear()

*/
var aMesh : Mesh;
var materialProperty : MaterialPropertyBlock = new MaterialPropertyBlock();
var aMaterial : Material = new Material(Shader.Find("VertexLit"));

function Update() {
	var tagID : int = Shader.PropertyToID("_Color");
	materialProperty.AddColor(tagID,Color.red);
	Graphics.DrawMesh(aMesh, Vector3(0,0,0), Quaternion.identity, aMaterial, 0, null, 0, materialProperty);
	materialProperty.Clear();
	materialProperty.AddColor(tagID,Color.green);
	Graphics.DrawMesh(aMesh, Vector3(5,0,0), Quaternion.identity, aMaterial, 0, null, 0, materialProperty);
	materialProperty.Clear();
	materialProperty.AddColor(tagID,Color.blue);
	Graphics.DrawMesh(aMesh, Vector3(-5,0,0), Quaternion.identity, aMaterial, 0, null, 0, materialProperty);
	materialProperty.Clear();
}
