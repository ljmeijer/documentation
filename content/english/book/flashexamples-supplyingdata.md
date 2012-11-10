Example: Supplying Data from Flash to Unity
===========================================


If you wish to supply data from Flash to Unity, it must be one of the supported types. You can also create classes to represent the data (by providing a matching C# or JavaScript implementation).

First, create an AS3 implementation of your object and include the class in your project (in an folder called ActionScript):

````
public class ExampleObject
{
    public var anInt : int;
    public var someString : String;
    public var aBool : Boolean;
}
````


Now create a C# or JavaScript object which matches the AS3 implementation.

The [NotRenamed](http://unity3d.com/support/documentation/ScriptReference/NotRenamedAttribute.html.md) attribute used below prevents name mangling of constructors, methods, fields and properties. 

The [NotConverted](http://unity3d.com/support/documentation/ScriptReference/NotConvertedAttribute.html.md) attribute instructs the build pipeline not to convert a type or member to the target platform. Normally when you build to Flash, each of your C#/JavaScript scripts are converted to an ActionScript (`.as`) script. Adding the [NotConverted] attribute overrides this process, allowing you to provide your own version of the .as script, manually. The dummy C#/JavaScript which you provide allows Unity to know the signature of the class (i.e. which functions it should be allowed to call), and your .as script provides the implementations of those functions. Note that the ActionScript version will only be used when you build to Flash. In editor or when built to other platforms, Unity will use your C#/JavaScript version.

###C#
````
[NotConverted]
[NotRenamed]
public class ExampleObject
{
    [NotRenamed]
    public int anInt;
    
    [NotRenamed]
    public string someString;
	
    [NotRenamed]
    public bool aBool;
}
````

###JavaScript
````

@NotConverted
@NotRenamed
class ExampleObject
{
    @NotRenamed
    public var anInt : int;
    
    @NotRenamed
    public var someString : String;
    
    @NotRenamed
    public var aBool : boolean;
}

````

Now you need a way in AS3 to retrieve your object, e.g.:

````
public static function getExampleObject() : ExampleObject
{
    return new ExampleObject();
}
````


Then you can then retrieve the object and access its data:

````
ExampleObject exampleObj = UnityEngine.Flash.ActionScript.Expression<ExampleObject>("MyStaticASClass.getExampleObject()");
Debug.Log(exampleObj.someString);
````
