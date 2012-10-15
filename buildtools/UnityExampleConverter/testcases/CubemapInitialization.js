/*
using UnityEngine;
using System.Collections;

public class CubemapInitialization : MonoBehaviour {
    void Start() {
        Cubemap texture = new Cubemap(128, TextureFormat.ARGB32, false);
        renderer.material.mainTexture = texture;
    }
}
*/
/*
import UnityEngine
import System.Collections

class CubemapInitialization(MonoBehaviour):

	def Start():
		texture as Cubemap = Cubemap(128, TextureFormat.ARGB32, false)
		renderer.material.mainTexture = texture
*/
function Start () {
    // Create a new texture and assign it to the renderer's material
    var texture : Cubemap = new Cubemap (128, TextureFormat.ARGB32, false);
    renderer.material.mainTexture = texture;
}
