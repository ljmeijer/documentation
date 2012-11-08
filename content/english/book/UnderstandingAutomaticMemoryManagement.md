Understanding Automatic Memory Management
=========================================


When an object, string or array is created, the memory required to store it is allocated from a central pool called the __heap__. When the item is no longer in use, the memory it once occupied can be reclaimed and used for something else. In the past, it was typically up to the programmer to allocate and release these blocks of heap memory explicitly with the appropriate function calls. Nowadays, runtime systems like Unity's Mono engine manage memory for you automatically. Automatic memory management requires less coding effort than explicit allocation/release and greatly reduces the potential for memory leakage (the situation where memory is allocated but never subsequently released).


Value and Reference Types
-------------------------


When a function is called, the values of its parameters are copied to an area of memory reserved for that specific call. Data types that occupy only a few bytes can be copied very quickly and easily. However, it is common for objects, strings and arrays to be much larger and it would be very inefficient if these types of data were copied on a regular basis. Fortunately, this is not necessary; the actual storage space for a large item is allocated from the heap and a small "pointer" value is used to remember its location. From then on, only the pointer need be copied during parameter passing. As long as the runtime system can locate the item identified by the pointer, a single copy of the data can be used as often as necessary.

Types that are stored directly and copied during parameter passing are called value types. These include integers, floats, booleans and Unity's struct types (eg, <span class=component>Color</span> and <span class=component>Vector3</span>). Types that are allocated on the heap and then accessed via a pointer are called reference types, since the value stored in the variable merely "refers" to the real data. Examples of reference types include objects, strings and arrays.


Allocation and Garbage Collection
---------------------------------


The memory manager keeps track of areas in the heap that it knows to be unused. When a new block of memory is requested (say when an object is instantiated), the manager chooses an unused area from which to allocate the block and then removes the allocated memory from the known unused space. Subsequent requests are handled the same way until there is no free area large enough to allocate the required block size. It is highly unlikely at this point that all the memory allocated from the heap is still in use. A reference item on the heap can only be accessed as long as there are still reference variables that can locate it. If all references to a memory block are gone (ie, the reference variables have been reassigned or they are local variables that are now out of scope) then the memory it occupies can safely be reallocated.

To determine which heap blocks are no longer in use, the memory manager searches through all currently active reference variables and marks the blocks they refer to as "live". At the end of the search, any space between the live blocks is considered empty by the memory manager and can be used for subsequent allocations. For obvious reasons, the process of locating and freeing up unused memory is known as garbage collection (or GC for short).


Optimization
------------


Garbage collection is automatic and invisible to the programmer but the collection process actually requires significant CPU time behind the scenes. When used correctly, automatic memory management will generally equal or beat manual allocation for overall performance. However, it is important for the programmer to avoid mistakes that will trigger the collector more often than necessary and introduce pauses in execution.

There are some infamous algorithms that can be GC nightmares even though they seem innocent at first sight. Repeated string concatenation is a classic example:-

````

function ConcatExample(intArray: int[]) {
	var line = intArray[0].ToString();
	
	for (i = 1; i < intArray.Length; i++) {
		line += ", " + intArray[i].ToString();
	}
	
	return line;
}
````

The key detail here is that the new pieces don't get added to the string in place, one by one. What actually happens is that each time around the loop, the previous contents of the line variable become dead - a whole new string is allocated to contain the original piece plus the new part at the end. Since the string gets longer with increasing values of i, the amount of heap space being consumed also increases and so it is easy to use up hundreds of bytes of free heap space each time this function is called. If you need to concatenate many strings together then a much better option is the Mono library's [System.Text.StringBuilder](http://msdn.microsoft.com/en-gb/library/system.text.stringbuilder.aspx.md) class.

However, even repeated concatenation won't cause too much trouble unless it is called frequently, and in Unity that usually implies the frame update. Something like:-

````

var scoreBoard: GUIText;
var score: int;

function Update() {
	var scoreText: String = "Score: " + score.ToString();
	scoreBoard.text = scoreText;
}
````

...will allocate new strings each time Update is called and generate a constant trickle of new garbage. Most of that can be saved by updating the text only when the score changes:-

````

var scoreBoard: GUIText;
var scoreText: String;
var score: int;
var oldScore: int;

function Update() {
	if (score != oldScore) {
		scoreText = "Score: " + score.ToString();
		scoreBoard.text = scoreText;
		oldScore = score;
	}
}
````


Another potential problem occurs when a function returns an array value:-

````

function RandomList(numElements: int) {
	var result = new float[numElements];
	
	for (i = 0; i < numElements; i++) {
		result[i] = Random.value;
	}
	
	return result;
}
````

This type of function is very elegant and convenient when creating a new array filled with values. However, if it is called repeatedly then fresh memory will be allocated each time. Since arrays can be very large, the free heap space could get used up rapidly, resulting in frequent garbage collections. One way to avoid this problem is to make use of the fact that an array is a reference type. An array passed into a function as a parameter can be modified within that function and the results will remain after the function returns. A function like the one above can often be replaced with something like:-

````

function RandomList(arrayToFill: float[]) {
	for (i = 0; i < arrayToFill.Length; i++) {
		arrayToFill[i] = Random.value;
	}
}
````

This simply replaces the existing contents of the array with new values. Although this requires the initial allocation of the array to be done in the calling code (which looks slightly inelegant), the function will not generate any new garbage when it is called.


Requesting a Collection
-----------------------

As mentioned above, it is best to avoid allocations as far as possible. However, given that they can't be completely eliminated, there are two main strategies you can use to minimise their intrusion into gameplay:-

###Small heap with fast and frequent garbage collection

This strategy is often best for games that have long periods of gameplay where a smooth framerate is the main concern. A game like this will typically allocate small blocks frequently but these blocks will be in use only briefly. The typical heap size when using this strategy on iOS is about 200KB and garbage collection will take about 5ms on an iPhone 3G. If the heap increases to 1MB, the collection will take about 7ms. It can therefore be advantageous sometimes to request a garbage collection at a regular frame interval. This will generally make collections happen more often than strictly necessary but they will be processed quickly and with minimal effect on gameplay:-

````

if (Time.frameCount % 30 == 0)
{
   [[http://msdn.microsoft.com/en-gb/library/xe0c2357.aspx|System.GC.Collect]]();
}

````

However, you should use this technique with caution and check the profiler statistics to make sure that it is really reducing collection time for your game.

###Large heap with slow but infrequent garbage collection

This strategy works best for games where allocations (and therefore collections) are relatively infrequent and can be handled during pauses in gameplay. It is useful for the heap to be as large as possible without being so large as to get your app killed by the OS due to low system memory. However, the Mono runtime avoids expanding the heap automatically if at all possible. You can expand the heap manually by preallocating some placeholder space during startup (ie, you instantiate a "useless" object that is allocated purely for its effect on the memory manager):-

````

function Start() {
	var tmp = new System.Object[1024];

	// make allocations in smaller blocks to avoid them to be treated in a special way, which is designed for large blocks
        for (var i : int = 0; i < 1024; i++)
		tmp[i] = new byte[1024];

	// release reference
        tmp = null;
}


````

A sufficiently large heap should not get completely filled up between those pauses in gameplay that would accommodate a collection. When such a pause occurs, you can request a collection explicitly:-

````

[[http://msdn.microsoft.com/en-gb/library/xe0c2357.aspx|System.GC.Collect]]();

````

Again, you should take care when using this strategy and pay attention to the profiler statistics rather than just assuming it is having the desired effect.

Reusable Object Pools
---------------------


There are many cases where you can avoid generating garbage simply by reducing the number of objects that get created and destroyed. There are certain types of objects in games, such as projectiles, which may be encountered over and over again even though only a small number will ever be in play at once. In cases like this, it is often possible to reuse objects rather than destroy old ones and replace them with new ones. 

See [here](iphone-PracticalScriptingOptimizations#Object%20Pooling.md) for more information on Object Pools and their implementation.

Further Information
-------------------


Memory management is a subtle and complex subject to which a great deal of academic effort has been devoted. If you are interested in learning more about it then [memorymanagement.org](http://www.memorymanagement.org/.md) is an excellent resource, listing many publications and online articles. Further information about object pooling can be found on the [Wikipedia page](http://en.wikipedia.org/wiki/Object_pool_pattern.md) and also at [Sourcemaking.com](http://sourcemaking.com/design_patterns/object_pool.md).
