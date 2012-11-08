Modifying Source Assets Through Scripting
=========================================


Automatic Instantiation
-----------------------

Usually when you want to make a modification to any sort of game asset, you want it to happen at runtime and you want it to be temporary.  For example, if your character picks up an invincibility power-up, you might want to change the <span class=keyword>shader</span> of the <span class=keyword>material</span> for the player character to visually demonstrate the invincible state.  This action involves modifying the material that's being used.  This modification is not permanent because we don't want the material to have a different shader when we exit <span class=keyword>Play Mode</span>.

However, it is possible in Unity to write scripts that will permanently modify a source asset.  Let's use the above material example as a starting point.

To temporarily change the material's shader, we change the <span class=component>shader</span> property of the <span class=component>material</span> component.

	private var invincibleShader = Shader.Find ("Specular");

	function StartInvincibility {
		[renderer](ScriptRef:Renderer.html).[material](ScriptRef:Renderer-material.html).shader = invincibleShader;
	}

When using this script and exiting Play Mode, the state of the <span class=component>[material](ScriptRef:Material.html)</span> will be reset to whatever it was before entering Play Mode initially. This happens because whenever renderer.material is accessed, the material is automatically instantiated and the instance is returned.  This instance is simultaneously and automatically applied to the renderer.  So you can make any changes that your heart desires without fear of permanence.


Direct Modification
-------------------


###IMPORTANT NOTE
The method presented below will modify actual source asset files used within Unity. These modifications are not undoable. Use them with caution.

Now let's say that we don't want the material to reset when we exit play mode.  For this, you can use [renderer.sharedMaterial](ScriptRef:Renderer-sharedMaterial.html).  The sharedMaterial property will return the actual asset used by this renderer (and maybe others).

The code below will permanently change the material to use the Specular shader.  It will not reset the material to the state it was in before Play Mode.

	private var invincibleShader = Shader.Find ("Specular");

	function StartInvincibility {
		[renderer](ScriptRef:Renderer.html).[sharedMaterial](ScriptRef:Renderer-sharedMaterial.html).shader = invincibleShader;
	}

As you can see, making any changes to a sharedMaterial can be both useful and risky.  Any change made to a sharedMaterial will be permanent, and not undoable.


Applicable Class Members
------------------------


The same formula described above can be applied to more than just materials.  The full list of assets that follow this convention is as follows:

* Materials: renderer.material and renderer.sharedMaterial
* Meshes: meshFilter.mesh and meshFilter.sharedMesh
* Physic Materials: collider.material and collider.sharedMaterial


Direct Assignment
-----------------


If you declare a public variable of any above class: Material, Mesh, or Physic Material, and make modifications to the asset using that variable instead of using the relevant class member, you will not receive the benefits of automatic instantiation before the modifications are applied.

Assets that are not automatically instantiated
----------------------------------------------


###desktop Details
There are two different assets that are never automatically instantiated when modifying them.

* [Texture2D](ScriptRef:Texture2D.html)
* [TerrainData](ScriptRef:TerrainData.html)

Any modifications made to these assets through scripting are always permanent, and never undoable.  So if you're changing your terrain's heightmap through scripting, you'll need to account for instantiating and assigning values on your own.  Same goes for Textures.  If you change the pixels of a texture file, the change is permanent.

###ios Details
[Texture2D](ScriptRef:Texture2D.html) assets are never automatically instantiated when modifying them. Any modifications made to these assets through scripting are always permanent, and never undoable.  So if you change the pixels of a texture file, the change is permanent.

###android Details
[Texture2D](ScriptRef:Texture2D.html) assets are never automatically instantiated when modifying them. Any modifications made to these assets through scripting are always permanent, and never undoable.  So if you change the pixels of a texture file, the change is permanent.
