Instantiating Prefabs at runtime
================================


By this point you should understand the concept of <span class=keyword>Prefabs</span> at a fundamental level.  They are a collection of predefined <span class=keyword>GameObjects</span> & <span class=keyword>Components</span> that are re-usable throughout your game.  If you don't know what a Prefab is, we recommend you read the [Prefabs](Prefabs.md) page for a more basic introduction.

Prefabs come in very handy when you want to instantiate complicated GameObjects at runtime.  The alternative to instantiating Prefabs is to create GameObjects from scratch using code.  Instantiating Prefabs has many advantages over the alternative approach:

* You can instantiate a Prefab from one line of code, with complete functionality.  Creating equivalent GameObjects from code takes an average of five lines of code, but likely more.
* You can set up, test, and modify the Prefab quickly and easily in the Scene and Inspector.
* You can change the Prefab being instanced without changing the code that instantiates it. A simple rocket might be altered into a super-charged rocket, and no code changes are required.


Common Scenarios
----------------


To illustrate the strength of Prefabs, let's consider some basic situations where they would come in handy:

1. Building a wall out of a single "brick" Prefab by creating it several times in different positions.
1. A rocket launcher instantiates a flying rocket Prefab when fired. The Prefab contains a Mesh, <span class=keyword>Rigidbody</span>, <span class=keyword>Collider</span>, and a child GameObject with its own trail <span class=keyword>Particle System</span>.
1. A robot exploding to many pieces. The complete, operational robot is destroyed and replaced with a wrecked robot Prefab. This Prefab would consist of the robot split into many parts, all set up with Rigidbodies and Particle Systems of their own. This technique allows you to blow up a robot into many pieces, with just one line of code, replacing one object with a Prefab.


###Building a wall

This explanation will illustrate the advantages of using a Prefab vs creating objects from code.

First, lets build a brick wall from code:

````

// JavaScript
function Start () {
    for (var y = 0; y < 5; y++) {
        for (var x = 0; x < 5; x++) {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent(Rigidbody);
            cube.transform.position = Vector3 (x, y, 0);
        }
    }
}


// C#
public class Instantiation : MonoBehaviour {

	void Start() {
		for (int y = 0; y < 5; y++) {
			for (int x = 0; x < 5; x++) {
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.AddComponent<Rigidbody>();
				cube.transform.position = new Vector3(x, y, 0);
			}
		}
	}
}

````

* To use the above script we simply save the script and drag it onto an empty GameObject.
* Create an empty GameObject with <span class=menu>GameObject->Create Empty</span>.

If you execute that code, you will see an entire brick wall is created when you enter <span class=keyword>Play Mode</span>.  There are two lines relevant to the functionality of each individual brick: the <span class=component>CreatePrimitive()</span> line, and the <span class=component>AddComponent()</span> line.  Not so bad right now, but each of our bricks is un-textured.  Every additional action to want to perform on the brick, like changing the texture, the friction, or the Rigidbody <span class=component>mass</span>, is an extra line.

If you create a Prefab and perform all your setup before-hand, you use one line of code to perform the creation and setup of each brick.  This relieves you from maintaining and changing a lot of code when you decide you want to make changes.  With a Prefab, you just make your changes and Play.  No code alterations required.

If you're using a Prefab for each individual brick, this is the code you need to create the wall.

````
// JavaScript

var brick : Transform;
function Start () {
    for (var y = 0; y < 5; y++) {
        for (var x = 0; x < 5; x++) {
            Instantiate(brick, Vector3 (x, y, 0), Quaternion.identity);
        }
    }
}


// C#
public Transform brick;

void Start() {
	for (int y = 0; y < 5; y++) {
		for (int x = 0; x < 5; x++) {
			Instantiate(brick, new Vector3(x, y, 0), Quaternion.identity);
		}
	}
}

````

This is not only very clean but also very reusable. There is nothing saying we are instantiating a cube or that it must contain a rigidbody. All of this is defined in the Prefab and can be quickly created in the Editor.

Now we only need to create the Prefab, which we do in the Editor.  Here's how:

1. Choose <span class=menu>GameObject->Create Other->Cube</span>
1. Choose <span class=menu>Component->Physics->Rigidbody</span>
1. Choose <span class=menu>Assets->Create->Prefab</span>
1. In the <span class=keyword>Project View</span>, change the name of your new Prefab to "Brick"
1. Drag the cube you created in the <span class=keyword>Hierarchy</span> onto the "Brick" Prefab in the <span class=keyword>Project View</span>
1. With the Prefab created, you can safely delete the Cube from the Hierarchy (<span class=menu>Delete</span> on Windows, <span class=menu>Command-Backspace</span> on Mac)

We've created our Brick Prefab, so now we have to attach it to the <span class=component>brick</span> variable in our script.  Select the empty GameObject that contains the script. Notice that a new variable has appeared in the Inspector, called "brick".


![](http://docwiki.hq.unity3d.com/uploads/Main/InspectorWithCubeVar.png)  
_This variable can accept any GameObject or Prefab_

Now drag the "Brick" Prefab from the Project View onto the <span class=component>brick</span> variable in the Inspector.  Press Play and you'll see the wall built using the Prefab.

This is a workflow pattern that can be used over and over again in Unity. In the beginning you might wonder why this is so much better, because the script creating the cube from code is only 2 lines longer.

But because you are using a Prefab now, you can adjust the Prefab in seconds. Want to change the mass of all those instances? Adjust the Rigidbody in the Prefab only once. Want to use a different <span class=keyword>Material</span> for all the instances?  Drag the Material onto the Prefab only once. Want to change friction?  Use a different <span class=keyword>Physic Material</span> in the Prefab's collider. Want to add a Particle System to all those boxes?  Add a child to the Prefab only once.


###Instantiating rockets & explosions

Here's how Prefabs fit into this scenario:

1. A rocket launcher instantiates a rocket Prefab when the user presses fire. The Prefab contains a mesh, Rigidbody, Collider, and a child GameObject that contains a trail particle system.
1. The rocket impacts and instantiates an explosion Prefab. The explosion Prefab contains a Particle System, a light that fades out over time, and a script that applies damage to surrounding GameObjects.

While it would be possible to build a rocket GameObject completely from code, adding Components manually and setting properties, it is far easier to instantiate a Prefab. You can instantiate the rocket in just one line of code, no matter how complex the rocket's Prefab is.  After instantiating the Prefab you can also modify any properties of the instantiated object (e.g. you can set the velocity of the rocket's Rigidbody).

Aside from being easier to use, you can update the prefab later on. So if you are building a rocket, you don't immediately have to add a Particle trail to it. You can do that later. As soon as you add the trail as a child GameObject to the Prefab, all your instantiated rockets will have particle trails. And lastly, you can quickly tweak the properties of the rocket Prefab in the Inspector, making it far easier to fine-tune your game.

This script shows how to launch a rocket using the <span class=component>Instantiate()</span> function.

````
// JavaScript

// Require the rocket to be a rigidbody.
// This way we the user can not assign a prefab without rigidbody
var rocket : Rigidbody;
var speed = 10.0;

function FireRocket () {
    var rocketClone : Rigidbody = Instantiate(rocket, transform.position, transform.rotation);
    rocketClone.velocity = transform.forward * speed;
    // You can also acccess other components / scripts of the clone
    rocketClone.GetComponent(MyRocketScript).DoSomething();
}

// Calls the fire method when holding down ctrl or mouse
function Update () {
    if (Input.GetButtonDown("Fire1")) {
        FireRocket();
    }
}


// C#

// Require the rocket to be a rigidbody.
// This way we the user can not assign a prefab without rigidbody
public Rigidbody rocket;
public float speed = 10f;

void FireRocket () {
	Rigidbody rocketClone = (Rigidbody) Instantiate(rocket, transform.position, transform.rotation);
	rocketClone.velocity = transform.forward * speed;
	
	// You can also acccess other components / scripts of the clone
	rocketClone.GetComponent<MyRocketScript>().DoSomething();
}

// Calls the fire method when holding down ctrl or mouse
void Update () {
	if (Input.GetButtonDown("Fire1")) {
		FireRocket();
	}
}

````


###Replacing a character with a ragdoll or wreck

Let's say you have a fully rigged enemy character and he dies.  You could simply play a death animation on the character and disable all scripts that usually handle the enemy logic. You probably have to take care of removing several scripts, adding some custom logic to make sure that no one will continue attacking the dead enemy anymore, and other cleanup tasks.

A far better approach is to immediately delete the entire character and replace it with an instantiated wrecked prefab. This gives you a lot of flexibility. You could use a different material for the dead character, attach completely different scripts, spawn a Prefab containing the object broken into many pieces to simulate a shattered enemy, or simply instantiate a Prefab containing a version of the character.

Any of these options can be achieved with a single call to <span class=component>Instantiate()</span>, you just have to hook it up to the right prefab and you're set!

The important part to remember is that the wreck which you <span class=component>Instantiate()</span> can be made of completely different objects than the original. For example, if you have an airplane, you would model two versions. One where the plane consists of a single GameObject with <span class=keyword>Mesh Renderer</span> and scripts for airplane physics. By keeping the model in just one GameObject, your game will run faster since you will be able to make the model with less triangles and since it consists of fewer objects it will render faster than using many small parts. Also while your plane is happily flying around there is no reason to have it in separate parts.

To build a wrecked airplane Prefab, the typical steps are:
1. Model your airplane with lots of different parts in your favorite modeler
1. Create an empty Scene
1. Drag the model into the empty Scene
1. Add Rigidbodies to all parts, by selecting all the parts and choosing <span class=menu>Component->Physics->Rigidbody</span>
1. Add Box Colliders to all parts by selecting all the parts and choosing <span class=menu>Component->Physics->Box Collider</span>
1. For an extra special effect, add a smoke-like Particle System as a child GameObject to each of the parts
1. Now you have an airplane with multiple exploded parts, they fall to the ground by physics and will create a Particle trail due to the attached particle system. Hit Play to preview how your model reacts and do any necessary tweaks.
1. Choose <span class=menu>Assets->Create Prefab</span>
1. Drag the root GameObject containing all the airplane parts into the Prefab


````
// JavaScript

var wreck : GameObject;

// As an example, we turn the game object into a wreck after 3 seconds automatically
function Start () {
    yield WaitForSeconds(3);
    KillSelf();
}

// Calls the fire method when holding down ctrl or mouse
function KillSelf () {
    // Instantiate the wreck game object at the same position we are at
    var wreckClone = Instantiate(wreck, transform.position, transform.rotation);

    // Sometimes we need to carry over some variables from this object
    // to the wreck
    wreckClone.GetComponent(MyScript).someVariable = GetComponent(MyScript).someVariable;

    // Kill ourselves
    Destroy(gameObject);


// C#

public GameObject wreck;

// As an example, we turn the game object into a wreck after 3 seconds automatically
IEnumerator Start() {
	yield return new WaitForSeconds(3);
	KillSelf();
}

// Calls the fire method when holding down ctrl or mouse
void KillSelf () {
	// Instantiate the wreck game object at the same position we are at
	GameObject wreckClone = (GameObject) Instantiate(wreck, transform.position, transform.rotation);
	
	// Sometimes we need to carry over some variables from this object
	// to the wreck
	wreckClone.GetComponent<MyScript>().someVariable = GetComponent<MyScript>().someVariable;
	
	// Kill ourselves
	Destroy(gameObject);
}

} 
````


The First Person Shooter tutorial explains how to replace a character with a ragdoll version and also synchronize limbs with the last state of the animation. You can find that tutorial on the [Tutorials](Tutorials.md) page.


###Placing a bunch of objects in a specific pattern

Lets say you want to place a bunch of objects in a grid or circle pattern.  Traditionally this would be done by either:

1. Building an object completely from code. This is tedious! Entering values from a script is both slow, unintuitive and not worth the hassle.
1. Make the fully rigged object, duplicate it and place it multiple times in the scene. This is tedious, and placing objects accurately in a grid is hard.

So use <span class=component>Instantiate()</span> with a Prefab instead!  We think you get the idea of why Prefabs are so useful in these scenarios.  Here's the code necessary for these scenarios:

````
// JavaScript

// Instantiates a prefab in a circle

var prefab : GameObject;
var numberOfObjects = 20;
var radius = 5;

function Start () {
    for (var i = 0; i < numberOfObjects; i++) {
        var angle = i * Mathf.PI * 2 / numberOfObjects;
        var pos = Vector3 (Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
        Instantiate(prefab, pos, Quaternion.identity);
    }
}


// C#
// Instantiates a prefab in a circle

public GameObject prefab;
public int numberOfObjects = 20;
public float radius = 5f;

void Start() {
	for (int i = 0; i < numberOfObjects; i++) {
		float angle = i * Mathf.PI * 2 / numberOfObjects;
		Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
		Instantiate(prefab, pos, Quaternion.identity);
	}
}

````

````
// JavaScript

// Instantiates a prefab in a grid

var prefab : GameObject;
var gridX = 5;
var gridY = 5;
var spacing = 2.0;

function Start () {
    for (var y = 0; y < gridY; y++) {
        for (var x=0;x<gridX;x++) {
            var pos = Vector3 (x, 0, y) * spacing;
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }
}


// C#

// Instantiates a prefab in a grid

public GameObject prefab;
public float gridX = 5f;
public float gridY = 5f;
public float spacing = 2f;

void Start() {
	for (int y = 0; y < gridY; y++) {
		for (int x = 0; x < gridX; x++) {
			Vector3 pos = new Vector3(x, 0, y) * spacing;
			Instantiate(prefab, pos, Quaternion.identity);
		}
	}
} 

````
