Generic Functions
=================


Some functions in the script reference (for example, the various GetComponent functions) are listed with 
a variant that has a letter T or a type name in angle brackets after the function name:-
````

function FuncName.<T>(): T;

````
These are known as generic functions. The significance they have for scripting is that you get
to specify the types of parameters and/or the return type when you call the function. In JavaScript, this can
be used to get around the limitations of dynamic typing:-
````

// The type is correctly inferred since it is defined in the function call.
var obj = GetComponent.<Rigidbody>();

````
In C#, it can save a lot of keystrokes and casts:-
````

Rigidbody rb = go.GetComponent<Rigidbody>();

// ...as compared with:-

Rigidbody rb = (Rigidbody) go.GetComponent(typeof(Rigidbody));

````
Any function that has a generic variant listed on its script reference page will allow this
special calling syntax.
