Metro FAQ : WACK
================


Starting from 09-14 build, Unity should pass WACK, you might still fail some tests if you use unsupported API in your scripts.

__WACK for Windows RT devices__ - [http://msdn.microsoft.com/en-us/windows/apps/jj572486.aspx](http://msdn.microsoft.com/en-us/windows/apps/jj572486.aspx.md).

Below is a table of functions/classes which should be used as alternative if you'll fail __'Supported API test'__, not all functions/classes are listed here, but in time we'll add more and more.

(:table border=1 cellpadding=5 cellspacing=0:)
(:cell:) __Unsupported function / class__
(:cell:) __More information__
(:cell:) __Alternative function / class__
(:cellnr:) Hashtable
(:cell:) &nbsp; 
(:cell:) System.Collections.Generic.Dictionary
(:cellnr:) ArrayList
(:cell:) &nbsp; 
(:cell:) System.Collections.Generic.List
(:cellnr:) Stack
(:cell:) &nbsp; 
(:cell:) System.Collections.Generic.Stack
(:cellnr:) System.Type::op_equality
(:cell:) This function is used when you compare two types, for ex., Type t; bool res = t == typeof (Vector3); 
(:cell:) System.Type.Equals
(:cellnr:) String.Format
(:cell:) There's no longer overloads like String.Format(string fmt, object arg1) and similar
(:cell:) String.Format(fmt, new object[]{...});
(:tableend:)
