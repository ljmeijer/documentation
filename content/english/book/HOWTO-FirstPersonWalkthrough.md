How to make a simple first person walkthrough
=============================================


Here's how you can make a simple first person walk-through with your own artwork:

1. Import your level. See [here](HOWTO-importObject.md) on how to import geometry from your art package into Unity.
1. Select the imported model file and enable <span class=component>Generate Colliders</span> in the <span class=keyword>Import Settings</span> in the <span class=keyword>Inspector</span>.
1. Locate the <span class=menu>Standard Assets->Prefabs->First Person Controller</span> in the <span class=keyword>Project View</span> and drag it into the <span class=keyword>Scene View</span>.
1. Make sure that the scale of your level is correct. The First Person Controller is exactly 2 meters high, so if your level doesn't fit the size of the controller, you should adjust the scale of the level size within your modeling application. Getting scale right is critical for physical simulation, and other reasons documented at the bottom of [this page](class-Rigidbody.md). Using the wrong scale can make objects feel like they are floating or too heavy. If you can't change the scale in your modeling app, you can change the scale in the <span class=keyword>Import Settings...</span> of the model file.
1. Move the First Person Controller to be at the start location using the <span class=keyword>Transform</span> handles. It is critical that the first person controller does not intersect any level geometry, when starting the game (otherwise it will be stuck!).
1. Remove the default camera "Main Camera" in the hierarchy view. The First person controller already has its own camera.
1. Hit <span class=keyword>Play</span> to walk around in your own level.
