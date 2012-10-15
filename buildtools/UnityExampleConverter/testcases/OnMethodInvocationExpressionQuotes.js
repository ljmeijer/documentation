/*
using UnityEngine;
using System.Collections;

public class OnMethodInvocationExpressionQuotes : MonoBehaviour {
    public Transform shoulder;
    void Example() {
        animation["wave_hand"].AddMixingTransform(shoulder);
    }
}
*/
/*
import UnityEngine
import System.Collections

class OnMethodInvocationExpressionQuotes(MonoBehaviour):

	public shoulder as Transform

	def Example():
		animation['wave_hand'].AddMixingTransform(shoulder)
*/
var shoulder : Transform;
animation["wave_hand"].AddMixingTransform(shoulder);
