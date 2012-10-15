/*
using UnityEngine;
using System.Collections;

public class Coroutine : MonoBehaviour {
    IEnumerator WaitAndPrint(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        yield return 5;
        yield return null;
        print("WaitAndPrint " + Time.time);
    }
    IEnumerator Example() {
        print("Starting " + Time.time);
        StartCoroutine(WaitAndPrint(2.0F));
        print("Before WaitAndPrint Finishes " + Time.time);
        yield return StartCoroutine(WaitAndPrint(2.0F));
    }
}
*/
/*
import UnityEngine
import System.Collections

class Coroutine(MonoBehaviour):

	def WaitAndPrint(waitTime as single) as IEnumerator:
		yield WaitForSeconds(waitTime)
		yield 5
		yield 
		print(('WaitAndPrint ' + Time.time))

	def Example() as IEnumerator:
		print(('Starting ' + Time.time))
		StartCoroutine(WaitAndPrint(2.0F))
		print(('Before WaitAndPrint Finishes ' + Time.time))
		yield StartCoroutine(WaitAndPrint(2.0F))
*/
print ("Starting " + Time.time);

StartCoroutine(WaitAndPrint(2.0));
print ("Before WaitAndPrint Finishes " + Time.time);
yield StartCoroutine(WaitAndPrint(2.0));

function WaitAndPrint (waitTime : float) {
    // suspend execution for waitTime seconds
    yield WaitForSeconds (waitTime);
    yield 5;
    yield;
    print ("WaitAndPrint "+ Time.time);
}
