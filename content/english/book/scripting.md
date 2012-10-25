Using Scripts
=============


This brief introduction explains how to create and use scripts in a project.  For detailed information about the Scripting API, please view the [Scripting Reference](Path:../ScriptReference/index.html).  For detailed information about creating game play through scripting, please view the [Creating Gameplay](Creating Gameplay) page of this manual.

Behaviour scripts in Unity can be written in <span class=keyword>JavaScript</span>, <span class=keyword>C#</span>, or <span class=keyword>Boo</span>. It is possible to use any combination of the three languages in a single project, although there are certain restrictions in cases where one script incorporates classes defined in another script.


Creating New Scripts
--------------------


Unlike other assets like Meshes or Textures, Script files can be created from within Unity. To create a new script, open the <span class=menu>Assets->Create->JavaScript</span> (or <span class=menu>Assets->Create->C Sharp Script</span> or <span class=menu>Assets->Create->Boo Script</span>) from the main menu. This will create a new script called <span class=component>NewBehaviourScript</span> and place it in the selected folder in <span class=keyword>Project View</span>.  If no folder is selected in Project View, the script will be created at the root level.

![](http://docwiki.hq.unity3d.com/uploads/Main/Scripting-1.png)  

You can edit the script by double-clicking on it in the Project View.  This will launch your default text editor as specified in Unity's preferences. To set the default script editor, change the drop-down item in <span class=menu>Unity->Preferences->External Script editor</span>.

These are the contents of a new, empty behaviour script:

    function Update () {
    } 


A new, empty script does not do a lot on its own, so let's add some functionality.  Change the script to read the following:

    function Update () {
        print("Hello World");
    } 

When executed, this code will print "Hello World" to the console.  But there is nothing that causes the code to be executed yet.  We have to attach the script to an active <span class=keyword>GameObject</span> in the <span class=keyword>Scene</span> before it will be executed.


Attaching scripts to objects
----------------------------


Save the above script and create a new object in the Scene by selecting <span class=menu>GameObject->Create Other->Cube</span>. This will create a new GameObject called "Cube" in the current Scene.

![](http://docwiki.hq.unity3d.com/uploads/Main/Scripting-2.png)  

Now drag the script from the Project View to the Cube (in the Scene or <span class=keyword>Hierarchy View</span>, it doesn't matter). You can also select the Cube and choose <span class=menu>Component->Scripts->New Behaviour Script</span>.  Either of these methods will attach the script to the Cube.  Every script you create will appear in the <span class=menu>Component->Scripts</span> menu.

![](http://docwiki.hq.unity3d.com/uploads/Main/Scripting-3.png)  

If you select the Cube and look at the <span class=keyword>Inspector</span>, you will see that the script is now visible.  This means it has been attached.

![](http://docwiki.hq.unity3d.com/uploads/Main/Scripting-4.png)  

Press <span class=keyword>Play</span> to test your creation. You should see the text "Hello World" appear beside the Play/Pause/Step buttons. Exit play mode when you see it.

![](http://docwiki.hq.unity3d.com/uploads/Main/Scripting-5.png)  


Manipulating the GameObject
---------------------------


A <span class=component>print()</span> statement can be very handy when debugging your script, but it does not manipulate the GameObject it is attached to. Let's change the script to add some functionality:


    function Update () {
        transform.Rotate(0, 5*Time.deltaTime, 0);
    } 


If you're new to scripting, it's okay if this looks confusing.  These are the important concepts to understand:

1. <span class=component>function Update () {}</span> is a container for code that Unity executes multiple times per second (once per frame).
1. <span class=component>transform</span> is a reference to the GameObject's [Transform Component](class-Transform).
1. <span class=component>Rotate()</span> is a function contained in the Transform <span class=keyword>Component</span>.
1. The numbers in-between the commas represent the degrees of rotation around each axis of 3D space: X, Y, and Z.
1. <span class=component>Time.deltaTime</span> is a member of the Time class that evens out movement over one second, so the cube will rotate at the same speed no matter how many frames per second your machine is rendering.  Therefore, <span class=component>5 * Time.deltaTime</span> means 5 degrees per second.

With all this in mind, we can read this code as "every frame, rotate this GameObject's Transform component a small amount so that it will equal five degrees around the Y axis each second."

You can access lots of different Components the same way as we accessed <span class=component>transform</span> already.  You have to add Components to the GameObject using the <span class=menu>Component</span> menu.  All the Components you can access directly are listed under <span class=keyword>Variables</span> on the [GameObject Scripting Reference Page](Path:../ScriptReference/GameObject.html).

For more information about the relationship between GameObjects, Scripts, and Components, please jump ahead to the [GameObjects](GameObjects) page or [Using Components](Using Components) page of this manual.


The Power of Variables
----------------------


Our script so far will always rotate the Cube 5 degrees each second.  We might want it to rotate a different number of degrees per second.  We could change the number and save, but then we have to wait for the script to be recompiled and we have to enter Play mode before we see the results.  There is a much faster way to do it.  We can experiment with the speed of rotation in real-time during Play mode, and it's easy to do.

Instead of typing <span class=component>5</span> into the <span class=component>Rotate()</span> function, we will declare a <span class=component>speed</span> variable and use that in the function.  Change the script to the following code and save it:

    var speed = 5.0;
    
    function Update () {
        transform.Rotate(0, speed*Time.deltaTime, 0);
    }

Now, select the Cube and look at the Inspector. Notice how our <span class=component>speed</span> variable appears.

![](http://docwiki.hq.unity3d.com/uploads/Main/Scripting-6.png)  

This variable can now be modified directly in the Inspector.  Select it, press <span class=menu>Return</span> and change the value.  You can also right- or option-click on the value and drag the mouse up or down.  You can change the variable at any time, even while the game is running.

Hit Play and try modifying the <span class=component>speed</span> value. The Cube's rotation speed will change instantly.  When you exit Play mode, you'll see that your changes are reverted back to their value before entering Play mode.  This way you can play, adjust, and experiment to find the best value, then apply that value permanently.

The technique of changing a variable's value in the Inspector makes it easy to reuse one script on many objects, each with a different variable value.  If you attach the script to multiple Cubes, and change the <span class=component>speed</span> of each cube, they will all rotate at different speeds even though they use the same script.


Accessing Other Components
--------------------------


When writing a script Component, you can access other components on the GameObject from within that script.

###Using the GameObject members

You can directly access any member of the <span class=component>GameObject</span> class.  You can see a list of all the <span class=component>GameObject</span> class members [here](class-GameObject).  If any of the indicated classes are attached to the GameObject as a Component, you can access that Component directly through the script by simply typing the member name.  For example, typing <span class=component>transform</span> is equivalent to <span class=component>gameObject.transform</span>.  The <span class=component>gameObject</span> is assumed by the compiler, unless you specifically reference a different GameObject.

Typing <span class=component>this</span> will be accessing the script Component that you are writing.  Typing <span class=component>this.gameObject</span> is referring to the GameObject that the script is attached to.  You can access the same GameObject by simply typing <span class=component>gameObject</span>.  Logically, typing <span class=component>this.transform</span> is the same as typing <span class=component>transform</span>.  If you want to access a Component that is not included as a GameObject member, you have to use <span class=component>gameObject.GetComponent()</span> which is explained on the next page.

There are many Components that can be directly accessed in any script.  For example, if you want to access the <span class=component>Translate</span> function of the Transform component, you can just write <span class=component>transform.Translate()</span> or <span class=component>gameObject.transform.Translate()</span>.  This works because all scripts are attached to a GameObject.  So when you write <span class=component>transform</span> you are implicitly accessing the Transform Component of the GameObject that is being scripted.  To be explicit, you write <span class=component>gameObject.transform</span>.  There is no advantage in one method over the other, it's all a matter of preference for the scripter.

To see a list of all the Components you can access implicitly, take a look at the [GameObject](ScriptRef:GameObject.html) page in the [Scripting Reference](ScriptRef:index.html).

###Using <span class=component>GetComponent()</span>

There are many Components which are not referenced directly as members of the <span class=component>GameObject</span> class.  So you cannot access them implicitly, you have to access them explicitly.  You do this by calling the <span class=component>GetComponent("component name")</span> and storing a reference to the result.  This is most common when you want to make a reference to another script attached to the GameObject.

Pretend you are writing _Script B_ and you want to make a reference to _Script A_, which is attached to the same GameObject.  You would have to use <span class=component>GetComponent()</span> to make this reference.  In Script B, you would simply write:

<span class=component>scriptA = GetComponent("ScriptA");</span>

For more help with using <span class=component>GetComponent()</span>, take a look at the [GetComponent() Script Reference page](ScriptRef:GameObject.GetComponent.html).


Accessing variables in other script Components
----------------------------------------------


All scripts attached to your GameObjects are Components. Therefore to get access to a public variable (and methods) in a script you make use of the GetComponent method. For example:

    function Start () {
       // Print the position of the transform component, for the gameObject this script is attached to
       Debug.Log(gameObject.GetComponent<Transform>.().position);
    }

In the previous example the GetComponent<T>. function is used to access the position property of the Transform component. The same technique can be used to access a variable in a custom script Component:


    (MyClass.js)
    public var speed : float = 3.14159;
    
    (MyOtherClass.js)
    function Start () {
       // Print the speed variable from the MyClass script Component attached to the gameObject
       Debug.Log(gameObject.GetComponent<MyClass>.().speed);
    }


###Accessing a variable defined in C# from Javascript

To access variables defined in C# scripts the compiled Assembly containing the C# code must exist when the Javascript code is compiled. Unity performs the compilation in different stages as described in the [Script Compilation](Path:../ScriptReference/index.Script_compilation_28Advanced29.html) section in the Scripting Reference. If you want to create a Javascript that uses classes or variables from a C# script just place the C# script in the "Standard Assets", "Pro Standard Assets" or "Plugins" folder and the Javascript outside of these folders. The code inside the "Standard Assets", "Pro Standard Assets" or "Plugins" is compiled first and the code outside is compiled in a later step making the Types defined in the compilation step (your C# script) available to later compilation steps (your Javascript script).

In general the code inside the "Standard Assets", "Pro Standard Assets" or "Plugins" folders, regardless of the language (C#, Javascript or Boo), will be compiled first and available to scripts in subsequent compilation steps.

###Optimizing variable access

In some circumstances you may be using GetComponent multiple times in your code, or multiple times per frame. Every call to GetComponent does a few extra steps internally to get the reference to the component you require. A more efficient approach is to store the reference to the component for example in your Start() function. As you will be storing the reference and not retrieving directly it is always good practice to check for null references:

    (MyClass.js)
    public var speed : float = 3.14159;
    
    (MyOtherClass.js)
    private var myClass : MyClass;
    function Start () {
       // Get a reference to the MyClass script Component attached to the gameObject
       myClass = gameObject.GetComponent<MyClass>.();
    }
    function Update () {
       // Verify that the reference is still valid and print the speed variable
       if(myClass != null)
          Debug.Log (myClass.speed);
    }
    

###Static Variables

It is also possible to declare variables in your classes as static. There will exist one and only one instance of a static variable for a specific class and it can be modified without the need of an instance of a class object:

    (MyClass.js)
    static public var speed : float = 3.14159;
    
    (MyOtherClass.js)
    function Start () {
       Debug.Log (MyClass.speed);
    }

It is recommended to __not__ use static variables for object references to make sure unused objects are removed from memory.

Where to go from here
---------------------


This was just a short introduction on how to use scripts inside the Editor. For more examples, check out the Unity tutorials, available for free on our Asset Store. You should also read through the [Scripting Overview](Path:../ScriptReference/index.html) in the Script Reference, which contains a more thorough introduction into scripting with Unity along with pointers to more in-depth information. If you're really stuck, be sure to visit the [Unity Answers](http://answers.unity3d.com) or [Unity Forums](http://forum.unity3d.com) and ask questions there.  Someone is always willing to help.
