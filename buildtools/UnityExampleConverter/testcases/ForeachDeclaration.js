/*
using UnityEngine;
using System.Collections;

public class ForeachDeclaration : MonoBehaviour {
    void OnCollisionStay(Collision collision) {
        foreach (ContactPoint contact in collision.contacts) {
            print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }
    void forAnimation() {
        foreach (AnimationState state in animation) {
            state.speed = 0.5F;
        }
    }
}
*/
/*
import UnityEngine
import System.Collections

class ForeachDeclaration(MonoBehaviour):

	def OnCollisionStay(collision as Collision):
		for contact as ContactPoint in collision.contacts:
			print(((contact.thisCollider.name + ' hit ') + contact.otherCollider.name))
			Debug.DrawRay(contact.point, contact.normal, Color.white)

	def forAnimation():
		for state as AnimationState in animation:
			state.speed = 0.5F
*/

function OnCollisionStay(collision : Collision) {
    // Check if the collider we hit has a rigidbody
    // Then apply the force
    for (var contact : ContactPoint in collision.contacts) {
        print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
        // Visualize the contact point
        Debug.DrawRay(contact.point, contact.normal, Color.white);
    }
}

function forAnimation() {
	for (var state : AnimationState in animation) {
		state.speed = 0.5;
	}
}
