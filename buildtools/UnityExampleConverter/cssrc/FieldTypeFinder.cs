using Boo.Lang.Compiler.Ast;
using System;

namespace UnityExampleConverter
{
    [Serializable]
    public class FieldTypeFinder : TypeFinderBase
    {
        public FieldTypeFinder(CompileUnit source)
            : base(source)
        {
        }
        public override void OnField(Field node)
        {
            if (this.LookingFor(node))
            {
                this.Found(node.Type);
            }
        }
    }
}