using Boo.Lang.Compiler.Ast;
using System;

namespace UnityExampleConverter
{
    [Serializable]
    public class MethodReturnTypeFinder : TypeFinderBase
    {
        public MethodReturnTypeFinder(CompileUnit source)
            : base(source)
        {
        }
        public override void OnMethod(Method node)
        {
            if (LookingFor(node))
            {
                Found(node.ReturnType);
            }
        }
    }
}