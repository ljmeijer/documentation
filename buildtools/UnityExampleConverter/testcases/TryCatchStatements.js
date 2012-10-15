/*
using UnityEngine;
using System.Collections;

public class TryCatchStatements : MonoBehaviour {
    public float div;
    void Start() {
        try {
            float anyDivision = -1 / div;
            Debug.Log(anyDivision);
        }
        catch(System.DivideByZeroException dbz) {
            Debug.Log("Division by zero");
        }
        catch(System.Exception exc) {
            Debug.Log("Random Exception");
        }

    }
}
*/
/*
import UnityEngine
import System.Collections

class TryCatchStatements(MonoBehaviour):

	public div as single

	def Start():
		try:
			anyDivision as single = ((-1) / div)
			Debug.Log(anyDivision)
		except dbz as System.DivideByZeroException:
			Debug.Log('Division by zero')
		except exc as System.Exception:
			Debug.Log('Random Exception')

*/
var div:float;
function Start() {
	try {
		var anyDivision : float = - 1 / div;
		Debug.Log(anyDivision);
	} catch (dbz : System.DivideByZeroException) {
		Debug.Log("Division by zero");
	} catch (exc : System.Exception) {
		Debug.Log("Random Exception");
	}
}
