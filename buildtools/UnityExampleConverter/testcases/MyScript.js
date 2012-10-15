/*
using UnityEngine;
using System.Collections;

public class MyScript : MonoBehaviour {
    void Start() {
        MyScript foo = GetComponent<MyScript>();
        foo.DoSomething();
    }
}
*/
/*
import UnityEngine
import System.Collections

class MyScript(MonoBehaviour):

	def Start():
		foo as MyScript = GetComponent[of MyScript]()
		foo.DoSomething()
*/
function Start () {
        var foo : MyScript = GetComponent(MyScript);
        foo.DoSomething();
}

