/*
using UnityEngine;
using System.Collections;

public class IfBlock : MonoBehaviour {
    int Example() {
        if (true)
            return false;
        else {
            int s = 0;
            return true;
        }
        if (false) {
            int a = 1;
            return true;
        } else
            return false;
        if (a < 10)
            a++;
        else
            return a + 1;
        if (false) {
            int a2 = 1;
            return true;
        } else {
            int a3 = 40;
            return a;
        }
    }
}
*/
/*
import UnityEngine
import System.Collections

class IfBlock(MonoBehaviour):

	def Example() as int:
		if true:
			return false
		else:
			s as int = 0
			return true
		if false:
			a as int = 1
			return true
		else:
			return false
		if a < 10:
			a++
		else:
			return (a + 1)
		if false:
			a2 as int = 1
			return true
		else:
			a3 as int = 40
			return a

*/
if(true) {
	return false;
} else {
	var s : int = 0;
	return true;
}

if(false) {
	var a : int = 1;
	return true;
} else {
	return false;
}

if (a < 10)
	a++;
else
	return a + 1;


if(false) {
	var a2 : int = 1;
	return true;
} else {
	var a3 : int = 40;
	return a;
}
