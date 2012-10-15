/*
using UnityEngine;
using System.Collections;

public class TypeInfCollider : MonoBehaviour {
    public RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);
    void Example() {
        int i = 0;
        while (i < hits.Length) {
            Renderer renderer = hits[i].collider.renderer;
            i++;
        }
    }
}
*/
/*
import UnityEngine
import System.Collections

class TypeInfCollider(MonoBehaviour):

	public hits as (RaycastHit) = Physics.RaycastAll(transform.position, transform.forward, 100.0F)

	def Example():
		i as int = 0
		while i < hits.Length:
			renderer as Renderer = hits[i].collider.renderer
			i++
*/

var hits : RaycastHit[] = Physics.RaycastAll (transform.position, transform.forward, 100.0);
for (var i = 0;i < hits.Length; i++) {
	var renderer = hits[i].collider.renderer;
}
