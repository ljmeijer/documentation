/*
using UnityEngine;
using System.Collections;

public class GUIContentInitialization : MonoBehaviour {
    void OnGUI() {
        GUI.Button(new Rect(10, 10, 100, 20), new GUIContent("Click me", "This is the tooltip"));
        GUI.Label(new Rect(10, 40, 100, 40), GUI.tooltip);
    }
}
*/
/*
import UnityEngine
import System.Collections

class GUIContentInitialization(MonoBehaviour):

	def OnGUI():
		GUI.Button(Rect(10, 10, 100, 20), GUIContent('Click me', 'This is the tooltip'))
		GUI.Label(Rect(10, 40, 100, 40), GUI.tooltip)
*/

function OnGUI () {
	// Make a button using a custom GUIContent parameter to pass in the tooltip.
	GUI.Button (Rect (10,10,100,20), GUIContent ("Click me", "This is the tooltip"));
	// Display the tooltip from the element that has mouseover or keyboard focus
	GUI.Label (Rect (10,40,100,40), GUI.tooltip);
}
