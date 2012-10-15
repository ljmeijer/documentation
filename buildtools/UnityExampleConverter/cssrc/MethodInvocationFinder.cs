using Boo.Lang.Compiler.Ast;
using System;

namespace UnityExampleConverter
{
    [Serializable]
    public class MethodInvocationFinder : TypeFinderBase
    {
        public MethodInvocationFinder(CompileUnit source)
            : base(source)
        {
        }
        public override void LeaveMethodInvocationExpression(MethodInvocationExpression node)
        {
            if (LookingFor(node))
            {
                Found(node);
            }
        }
    }
}