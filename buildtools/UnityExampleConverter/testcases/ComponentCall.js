/*
using UnityEngine;
using System.Collections;

public class ComponentCall : MonoBehaviour {
    void Start() {
        AScript aS = GetComponent("AScript") as AScript;
        Transform aS2 = transform.GetComponent("Transform") as Transform;
        ExampleScript someScript = GetComponent<ExampleScript>();
        AnotherExampleScript anotherScript = transform.GetComponent<AnotherExampleScript>();
        someScript.DoSomething();
    }
}
*/
/*
import UnityEngine
import System.Collections

class ComponentCall(MonoBehaviour):

	def Start():
		aS as AScript = GetComponent('AScript')
		aS2 as Transform = transform.GetComponent('Transform')
		someScript as ExampleScript = GetComponent[of ExampleScript]()
		anotherScript as AnotherExampleScript = transform.GetComponent[of AnotherExampleScript]()
		someScript.DoSomething()

*/
// You can access script components in the same way as other components.
function Start () {
    var aS : AScript = GetComponent("AScript");
    var aS2 : Transform = transform.GetComponent("Transform");
    var someScript : ExampleScript  = GetComponent (ExampleScript);
    var anotherScript : AnotherExampleScript = transform.GetComponent(AnotherExampleScript);
    someScript.DoSomething ();
}
