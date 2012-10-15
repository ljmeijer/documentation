/*
using UnityEngine;
using System.Collections;

public class FloatDeclarationAndInitialization : MonoBehaviour {
    public float f1 = 3;
    public float f2 = 4;
    public float f3;
    void Update() {
        f3 = f1 + 1;
        f1 = 50 * Time.deltaTime;
    }
}
*/
/*
import UnityEngine
import System.Collections

class FloatDeclarationAndInitialization(MonoBehaviour):

	public f1 as single = 3

	public f2 as single = 4

	public f3 as single

	def Update():
		f3 = (f1 + 1)
		f1 = (50 * Time.deltaTime)
*/
var f1 : float = 3;
var f2 : float = 4;
var f3 : float;
function Update() {
	f3 = f1 + 1;
	f1 = 50 * Time.deltaTime;
}
