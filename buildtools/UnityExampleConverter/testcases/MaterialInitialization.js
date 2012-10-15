/*
using UnityEngine;
using System.Collections;

public class MaterialInitialization : MonoBehaviour {
    public string shaderText = "";
    void Example() {
        renderer.material = new Material(shaderText);
    }
}
*/
/*
import UnityEngine
import System.Collections

class MaterialInitialization(MonoBehaviour):

	public shaderText as string = ''

	def Example():
		renderer.material = Material(shaderText)

*/
var shaderText : String = "";
renderer.material = new Material( shaderText );
