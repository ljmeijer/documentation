using Boo.Lang.Compiler.Ast;
using System;

namespace UnityExampleConverter
{
	[Serializable]
	public class ReferenceFinder : TypeFinderBase
	{
		public ReferenceFinder(CompileUnit source)
			: base(source)
		{
		}
		public override void OnMemberReferenceExpression(MemberReferenceExpression node)
		{
			if (LookingFor(node))
			{
				Found(node);
			}
			else
			{
				base.OnMemberReferenceExpression(node);
			}
		}
		public override void OnReferenceExpression(ReferenceExpression node)
		{
			if (LookingFor(node))
			{
				Found(node);
			}
		}
	}
}
