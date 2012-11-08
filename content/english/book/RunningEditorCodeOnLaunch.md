Running Editor Script Code on Launch
====================================


Sometimes, it is useful to be able to run some editor script code in a project as soon as Unity launches without requiring action from the user. You can do this by applying the <span class=keyword>InitializeOnLoad</span> attribute to a class which has a __static constructor__. A static constructor is a function with the same name as the class, declared static and without a return type or parameters (see [here](http://docs.go-mono.com/index.aspx?link=ecmaspec%3a17.11.md) for more information):-

````
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class Startup {
    static Startup()
    {
        Debug.Log("Up and running");
    }
}
````

A static constructor is always guaranteed to be called before any static function or instance of the class is used, but the InitializeOnLoad attribute ensures that it is called as the editor launches.

An example of how this technique can be used is in setting up a regular callback in the editor (its "frame update", as it were). The EditorApplication class has a delegate called [update](ScriptRef:EditorApplication-update.html) which is called many times a second while the editor is running. To have this delegate enabled as the project launches, you could use code like the following:-

````
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
class MyClass
{
    static MyClass ()
    {
        EditorApplication.update += Update;
    }

    static void Update ()
    {
        Debug.Log("Updating");
    }
}
````
