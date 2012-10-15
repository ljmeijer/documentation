/*
using UnityEngine;
using System.Collections;

public class ColorInitialization : MonoBehaviour {
    public Color color = new Color(0.3F, 0.4F, 0.6F);
    void Example() {
        print(color.grayscale);
    }
}
*/
/*
import UnityEngine
import System.Collections

class ColorInitialization(MonoBehaviour):

	public color as Color = Color(0.3F, 0.4F, 0.6F)

	def Example():
		print(color.grayscale)

*/
var color : Color = Color(.3, .4, .6);
print(color.grayscale);
