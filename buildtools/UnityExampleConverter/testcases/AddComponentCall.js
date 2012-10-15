/*
using UnityEngine;
using System.Collections;

public class AddComponentCall : MonoBehaviour {
    public HingeJoint s;
    public BoxCollider s2;
    void Example() {
        gameObject.AddComponent("SphereCollider");
        gameObject.AddComponent<Rigidbody>();
        s = gameObject.AddComponent<HingeJoint>();
        s2 = gameObject.AddComponent("BoxCollider") as BoxCollider;
    }
}
*/
/*
import UnityEngine
import System.Collections

class AddComponentCall(MonoBehaviour):

	public s as HingeJoint

	public s2 as BoxCollider

	def Example():
		gameObject.AddComponent('SphereCollider')
		gameObject.AddComponent[of Rigidbody]()
		s = gameObject.AddComponent[of HingeJoint]()
		s2 = (gameObject.AddComponent('BoxCollider') as BoxCollider)
*/

gameObject.AddComponent ("SphereCollider");
gameObject.AddComponent (Rigidbody);

var s : HingeJoint;
s = gameObject.AddComponent(HingeJoint);
var s2 : BoxCollider;
s2 = gameObject.AddComponent("BoxCollider");
