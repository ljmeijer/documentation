/*
using UnityEngine;
using System.Collections;

public class InstantiateCast : MonoBehaviour {
    public Rigidbody projectile;
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.forward * 10);
        }
    }
}
*/
/*
import UnityEngine
import System.Collections

class InstantiateCast(MonoBehaviour):

	public projectile as Rigidbody

	def Update():
		if Input.GetButtonDown('Fire1'):
			clone as Rigidbody
			clone = (Instantiate(projectile, transform.position, transform.rotation) as Rigidbody)
			clone.velocity = transform.TransformDirection((Vector3.forward * 10))
*/
var projectile : Rigidbody;
function Update () {
	if (Input.GetButtonDown("Fire1")) {
		var clone : Rigidbody;
		clone = Instantiate(projectile, transform.position, transform.rotation);
		clone.velocity = transform.TransformDirection (Vector3.forward * 10);
	}
}

