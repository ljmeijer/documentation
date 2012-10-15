/*
using UnityEngine;
using System.Collections;

public class HashTableInitialization : MonoBehaviour {
    public Hashtable h;
    void Example() {
        h = new Hashtable();
        h.Add("1", "one");
        h.Add("2", "two");
        if (h.ContainsValue("one"))
            Debug.Log("Value 'one', has been found!");
        
    }
}
*/
/*
import UnityEngine
import System.Collections

class HashTableInitialization(MonoBehaviour):

	public h as Hashtable

	def Example():
		h = Hashtable()
		h.Add('1', 'one')
		h.Add('2', 'two')
		if h.ContainsValue('one'):
			Debug.Log('Value \'one\', has been found!')

*/
// Searchs for a value on the hash table

var h : Hashtable;
h = new Hashtable();
h.Add("1","one");
h.Add("2","two");
if(h.ContainsValue("one")) {
    Debug.Log("Value 'one', has been found!");
}
