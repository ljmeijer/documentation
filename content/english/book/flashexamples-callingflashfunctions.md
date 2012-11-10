Example: Calling ActionScript Functions from Unity
==================================================


This example shows how you can call different AS3 functions from Unity. You will encounter three scripts:
* An AS3 class (ExampleClass.as) containing different function examples. Any AS3 classes you create must be placed within an "ActionScript" folder in your project.
* A C#/JavaScript class (ExampleClass.cs/js) which mimics the AS3 implementation. You only need one of these.
* An example of how to call the functions from Unity.

When built to Flash, the AS3 implementation of ExampleClass is used. When run in-editor or built to any platform other than Flash the C#/JavaScript implementation will be used.

By creating an ActionScript version of your classes, this will enable you to use native AS3 libraries when building for Flash Player. This is particularly useful when you need to work around a .net library which isn't yet supported for Flash export.

  

ExampleClass.as
---------------


````

public class ExampleClass
{
  public static function aStaticFunction() : void
  {
    trace("aStaticFunction - AS3 Implementation");
  }

  public static function aStaticFunctionWithParams(a : int) : void
  {
    trace("aStaticFunctionWithParams - AS3 Implementation");
  }

  public static function aStaticFunctionWithReturnType() : int
  {
    trace("aStaticFunctionWithReturnType - AS3 Implementation");
    return 1;
  }

  public function aFunction() : void
  {
    trace("aFunction - AS3 Implementation");
  }
}

````

  

ExampleClass - C#/JavaScript Implementation
-------------------------------------------


You can create the class to mimic the AS3 implementation in either C# or JavaScript. The implementations are very similar. Both examples are provided below.

###C# Implementation (ExampleClass.cs)
````

using UnityEngine;

[NotRenamed]
[NotConverted]
public class ExampleClass
{
    [NotRenamed]
    public static void aStaticFunction()
    {
        Debug.Log("aStaticFunction - C# Implementation");
    }
    
    [NotRenamed]
    public static void aStaticFunctionWithParams(int a)
    {
        Debug.Log("aStaticFunctionWithParams - C# Implementation");
    }
    
    [NotRenamed]
    public static int aStaticFunctionWithReturnType()
    {
        Debug.Log("aStaticFunctionWithReturnType - C# Implementation");
        return 1;
    }
    
    [NotRenamed]
    public void aFunction()
    {
        Debug.Log("aFunction - C# Implementation");
    }
}

````


###JavaScript Implementation (ExampleClass.js)
````

@NotConverted
@NotRenamed
class ExampleClass
{
    @NotRenamed
    static function aStaticFunction()
    {
        Debug.Log("aStaticFunction - JS Implementation");
    }
  
    @NotRenamed
    static function aStaticFunctionWithParams(a : int)
    {
        Debug.Log("aStaticFunctionWithParams - JS Implementation");
    }
  
    @NotRenamed
    static function aStaticFunctionWithReturnType() : int
    {
      Debug.Log("aStaticFunctionWithReturnType - JS Implementation");
      return 1;
    }
  
    @NotRenamed
    function aFunction()
    {
        Debug.Log("aFunction - JS Implementation");
    }
}


````
  

How to Call the Functions
-------------------------


The below code will call the methods in the ActionScript (.as) implementation when building for Flash. This will allow you to use native AS3 libraries in your flash export projects. When building to a non-Flash platform or running in editor, the C#/JS implementation of the class will be used.

````

ExampleClass.aStaticFunction();
ExampleClass.aStaticFunctionWithParams(1);
int returnedValue = ExampleClass.aStaticFunctionWithReturnType();

ExampleClass exampleClass = new ExampleClass();
exampleClass.aFunction();

````
