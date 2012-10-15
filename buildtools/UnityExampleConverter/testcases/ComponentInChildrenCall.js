/*
using UnityEngine;
using System.Collections;

public class ComponentInChildrenCall : MonoBehaviour {
    void Start() {
        ExampleScript someScript = GetComponentInChildren<ExampleScript>();
        AnotherExampleScript anotherScript = transform.GetComponentInChildren<AnotherExampleScript>();
        someScript.DoSomething();
    }
}
*/
/*
import UnityEngine
import System.Collections

class ComponentInChildrenCall(MonoBehaviour):

	def Start():
		someScript as ExampleScript = GetComponentInChildren[of ExampleScript]()
		anotherScript as AnotherExampleScript = transform.GetComponentInChildren[of AnotherExampleScript]()
		someScript.DoSomething()

*/
// You can access script components in the same way as other components.
function Start () {
    var someScript : ExampleScript  = GetComponentInChildren(ExampleScript);
    var anotherScript : AnotherExampleScript = transform.GetComponentInChildren(AnotherExampleScript);
    someScript.DoSomething ();
}
