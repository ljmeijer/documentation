using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.TypeSystem;
using System;
using System.Collections;
namespace UnityExampleConverter
{
    [Serializable]
    public class BooTransformer : DepthFirstTransformer
    {
        public override void OnSimpleTypeReference(SimpleTypeReference node)
        {
            node.Name = this.UnityScriptTypeNameToBooTypeName(node.Name);
        }
        public override void LeaveMethod(Method node)
        {
            TypeReference returnType = node.ReturnType;
            if (returnType is SimpleTypeReference)
            {
                SimpleTypeReference simpleTypeReference = (SimpleTypeReference)returnType;
                if (simpleTypeReference.Name == "void")
                {
                    node.ReturnType = null;
                }
            }
        }
        public override void LeaveClassDefinition(ClassDefinition node)
        {
            node.Modifiers &= ~TypeMemberModifiers.Public;
        }
        public override void LeaveMethodInvocationExpression(MethodInvocationExpression node)
        {
            IMethodBase methodBase = node.Target.Entity as IMethodBase;
            if (methodBase != null && methodBase.AcceptVarArgs)
            {
                IParameter[] parameters = methodBase.GetParameters();
                if (parameters.Length == ((ICollection)node.Arguments).Count)
                {
                    IType expressionType = node.Arguments[-1].ExpressionType;
                    if (expressionType == parameters[parameters.Length + -1].Type)
                    {
                        node.Arguments[-1] = new UnaryExpression(UnaryOperatorType.Explode, node.Arguments[-1]);
                    }
                }
            }
        }
        public override void LeaveDeclarationStatement(DeclarationStatement node)
        {
            if (node.Declaration.Type != null)
            {
                Expression initializer = node.Initializer;
                if (initializer is TryCastExpression)
                {
                    TryCastExpression tryCastExpression = (TryCastExpression)initializer;

                    Expression target = tryCastExpression.Target;
                    TypeReference type = tryCastExpression.Type;
                    node.Initializer = target;
                }
            }
        }
        public override void LeaveArrayLiteralExpression(ArrayLiteralExpression node)
        {
            node.Type = null;
        }
        public string UnityScriptTypeNameToBooTypeName(string typeName)
        {
            return (!(typeName == "float")) ? ((!(typeName == "boolean")) ? ((!(typeName == "String")) ? ((!(typeName == "Array")) ? CSharpTransformerModule.SimplifyUnityTypeName(typeName) : "ArrayList") : "string") : "bool") : "single";
        }
    }
}