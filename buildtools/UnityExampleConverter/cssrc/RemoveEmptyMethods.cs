using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.Steps;
using System;

namespace UnityExampleConverter
{
	[Serializable]
	public class RemoveEmptyMethods : AbstractTransformerCompilerStep
	{
		public override void Run()
		{
			Visit(CompileUnit);
		}
		public override void LeaveMethod(Method node)
		{
			if (node.Body.IsEmpty)
			{
				RemoveCurrentNode();
			}
		}
	}
}
