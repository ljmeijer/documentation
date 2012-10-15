/*
using UnityEngine;
using System.Collections;

public class OneLineIf : MonoBehaviour {
    void Start() {
        Texture2D texture = new Texture2D(128, 128);
        renderer.material.mainTexture = texture;
        int y = 0;
        while (y < texture.height) {
            int x = 0;
            while (x < texture.width) {
                Color color = ((x & y) ? Color.white : Color.gray);
                texture.SetPixel(x, y, color);
                ++x;
            }
            ++y;
        }
        texture.Apply();
    }
}
*/
/*
import UnityEngine
import System.Collections

class OneLineIf(MonoBehaviour):

	def Start():
		texture as Texture2D = Texture2D(128, 128)
		renderer.material.mainTexture = texture
		y as int = 0
		while y < texture.height:
			x as int = 0
			while x < texture.width:
				color as Color = (Color.white if (x & y) else Color.gray)
				texture.SetPixel(x, y, color)
				++x
			++y
		texture.Apply()
*/
function Start () {
	// Create a new texture and assign it to the renderer's material
	var texture = new Texture2D(128, 128);
	renderer.material.mainTexture = texture;
	
	// Fill the texture with Sierpinski's fractal pattern!
	for (var y : int = 0; y < texture.height; ++y) {
		for (var x : int = 0; x < texture.width; ++x) {
			var color = (x&y) ? Color.white : Color.gray;
			texture.SetPixel (x, y, color);
		}
	}
	// Apply all SetPixel calls
	texture.Apply();
}
