using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.Steps;
using System;
using System.Collections;

namespace UnityExampleConverter
{
	[Serializable]
	public class RenameArrayDeclaration : AbstractTransformerCompilerStep
	{
		public override void Run()
		{
			Visit(CompileUnit);
		}
		public override void OnMethodInvocationExpression(MethodInvocationExpression node)
		{
			if (node is MethodInvocationExpression && node.Target is GenericReferenceExpression)
			{
				var genericReferenceExpression = (GenericReferenceExpression)node.Target;
				if (genericReferenceExpression.Target is MemberReferenceExpression)
				{
					var memberReferenceExpression = (MemberReferenceExpression)genericReferenceExpression.Target;
					if (memberReferenceExpression.Target is MemberReferenceExpression)
					{
						var memberReferenceExpression2 = (MemberReferenceExpression)memberReferenceExpression.Target;
						if (memberReferenceExpression2.Target is MemberReferenceExpression)
						{
							var memberReferenceExpression3 = (MemberReferenceExpression)memberReferenceExpression2.Target;
							if (memberReferenceExpression3.Target is ReferenceExpression)
							{
								var referenceExpression = (ReferenceExpression)memberReferenceExpression3.Target;
								if (referenceExpression.Name == "Boo" && memberReferenceExpression3.Name == "Lang" && memberReferenceExpression2.Name == "Builtins" && memberReferenceExpression.Name == "array" && 1 == ((ICollection)genericReferenceExpression.GenericArguments).Count)
								{
									TypeReference node2 = genericReferenceExpression.GenericArguments[0];
									if (1 == ((ICollection)node.Arguments).Count && node.Arguments[0] is CastExpression)
									{
										var castExpression = (CastExpression)node.Arguments[0];
										Expression target = castExpression.Target;
										if (castExpression.Type is SimpleTypeReference)
										{
											var simpleTypeReference = (SimpleTypeReference)castExpression.Type;
											if (simpleTypeReference.Name == "int")
											{
												var methodInvocationExpression = new MethodInvocationExpression(LexicalInfo.Empty);
												var arg_255_0 = methodInvocationExpression;
												var genericReferenceExpression2 = new GenericReferenceExpression(LexicalInfo.Empty);
												GenericReferenceExpression arg_226_0 = genericReferenceExpression2;
												var referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
												string text = referenceExpression2.Name = "array";
												Expression expression = arg_226_0.Target = referenceExpression2;
												TypeReferenceCollection typeReferenceCollection = genericReferenceExpression2.GenericArguments = TypeReferenceCollection.FromArray(new TypeReference[]
											{
												TypeReference.Lift(node2)
											});
												Expression expression2 = arg_255_0.Target = genericReferenceExpression2;
												ExpressionCollection expressionCollection = methodInvocationExpression.Arguments = ExpressionCollection.FromArray(new Expression[]
											{
												Expression.Lift(target)
											});
												ReplaceCurrentNode(methodInvocationExpression);
											}
										}

									}
								}
							}
						}
					}
				}
			}
		}
	}
}
