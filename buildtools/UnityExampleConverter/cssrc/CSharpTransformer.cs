using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.TypeSystem;
using Boo.Lang.Runtime;
using System;
using System.Reflection;

namespace UnityExampleConverter
{
	[Serializable]
	public class CSharpTransformer : DepthFirstTransformer
	{
		public override void OnSimpleTypeReference(SimpleTypeReference node)
		{
			node.Name = UnityScriptTypeNameToCSharpTypeName(node.Name);
		}
		public string UnityScriptTypeNameToCSharpTypeName(string typeName)
		{
			return (typeName != "boolean") ? ((typeName != "String") ? ((typeName != "Array") ? CSharpTransformerModule.SimplifyUnityTypeName(typeName) : "ArrayList") : "string") : "bool";
		}
		public override void LeaveMethodInvocationExpression(MethodInvocationExpression node)
		{
			var externalMethod = node.Target.Entity as ExternalMethod;
			if (externalMethod != null)
			{
				ParameterInfo[] parameters = externalMethod.MethodInfo.GetParameters();
				int i = 0;
				int length = parameters.Length;
				if (length < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (i < length)
				{
					int num = i;
					i++;
					ParameterInfo[] expr_55 = parameters;
					if (expr_55[RuntimeServices.NormalizeArrayIndex(expr_55, num)].ParameterType.IsByRef)
					{
						ParameterInfo[] expr_72 = parameters;
						if (expr_72[RuntimeServices.NormalizeArrayIndex(expr_72, num)].IsOut)
						{
							NodeCollection<Expression> arg_AC_0 = node.Arguments;
							int arg_AC_1 = num;
							OutputExpression outputExpression = new OutputExpression();
							Expression expression = outputExpression.Expression = node.Arguments[num];
							arg_AC_0[arg_AC_1] = outputExpression;
						}
						else
						{
							NodeCollection<Expression> arg_E1_0 = node.Arguments;
							int arg_E1_1 = num;
							ByRefExpression byRefExpression = new ByRefExpression();
							Expression expression2 = byRefExpression.Expression = node.Arguments[num];
							arg_E1_0[arg_E1_1] = byRefExpression;
						}
					}
				}
			}
		}
		public override void OnReferenceExpression(ReferenceExpression node)
		{
			if (TypeInference.IsTypeLiteral(node))
			{
				TypeofExpression typeofExpression = new TypeofExpression(LexicalInfo.Empty);
				TypeReference typeReference = typeofExpression.Type = TypeReference.Lift(node);
				this.ReplaceCurrentNode(typeofExpression);
			}
		}
	}
}
