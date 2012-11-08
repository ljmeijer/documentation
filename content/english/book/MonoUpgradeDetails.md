Mono Upgrade Details
====================

In Unity 3 we upgraded the mono runtime from 1.2.5 to 2.6 and on top of that, there are some JavaScript and Boo improvements. Aside from all bug fixes and improvements to mono between the two versions, this page lists some of the highlights.

C# Improvements
---------------

Basically the differences betweeen C# 3.5 and C# 2.0, including:
* Variable type inference. More info [here](http://msdn.microsoft.com/en-us/library/bb383973.aspx.md).
* Linq .
* Lambdas. More info [here](http://msdn.microsoft.com/en-us/library/bb397687.aspx.md).

JavaScript Improvements
-----------------------

* Compiler is now 4x faster;
* 'extends' no longer can be used with interfaces, unityscript now have 'implements' for that purpose (see below);
* Added support for consuming generic types such as generic collections:
````
		var list = new System.Collections.Generic.List.<String>();
		list.Add("foo");

````
* Added support for anonymous functions/closures:
````

		list.Sort(function(x:String, y:String) {
			return x.CompareTo(y);
		});

````
* Which include a simplified lambda expression form with type inference for the parameters and return value:
````

		list.Sort(function(x, y) x.CompareTo(y));

````
* Function types:
````

		function forEach(items, action: function(Object)) {
			for (var item in items) action(item);
		}

````
* Type inferred javascript array comprehensions:
````

		function printArray(a: int[]) {
			print("[" + String.Join(", ", [i.ToString() for (i in a)]) + "]");
		}
		
		var doubles = [i*2 for (i in range(0, 3))];
		var odds = [i for (i in range(0, 6)) if (i % 2 != 0)];
		printArray(doubles);
		printArray(odds);

````

* Added support for declaring and implementing interfaces:
````

		interface IFoo {
			function bar();
		}
		
		class Foo implements IFoo {
			function bar() {
				Console.WriteLine("Foo.bar");
			}
		}

````

* All functions are now implicitly virtual, as a result the 'virtual' keyword has been deprecated and the 'final' keyword has been introduced to allow for non virtual methods to be defined as:
````

		final function foo() {
		}

````
* Value types (structs) can be defined as classes inheriting from System.ValueType:
````

		class Pair extends System.ValueType {
			var First: Object;
			var Second: Object;
			
			function Pair(fst, snd) {
				First = fst;
				Second = snd;
			}
			
			override function ToString() {
				return "Pair(" + First + ", " + Second + ")";
			}
		}

````
Boo Improvements
----------------

* Boo upgrade to version 0.9.4.
