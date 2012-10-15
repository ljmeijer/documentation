using Boo.Lang.Compiler.Ast;
using System;
namespace UnityExampleConverter
{
    [Serializable]
    public class ArrayLiteralFinder : TypeFinderBase
    {
	    public ArrayLiteralFinder(CompileUnit source) : base(source)
	    {
	    }
	    public override void LeaveArrayLiteralExpression(ArrayLiteralExpression node)
	    {
		    if (LookingFor(node))
		    {
			    Found(node.Type);
		    }
	    }
    }
}