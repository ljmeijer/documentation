using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.Steps;
using System;

namespace UnityExampleConverter
{
	[Serializable]
	public class GenericTransformer : AbstractTransformerCompilerStep
	{
		protected bool isBinaryExp;
		public override void Run()
		{
			Visit(CompileUnit);
		}
		public override void LeaveMethod(Method node)
		{
			node.Modifiers &= ~(TypeMemberModifiers.Public | TypeMemberModifiers.Virtual);
		}
	}
}
