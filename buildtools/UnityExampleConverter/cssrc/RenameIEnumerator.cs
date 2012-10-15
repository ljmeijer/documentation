using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.Steps;
using System;

namespace UnityExampleConverter
{
    [Serializable]
    public class RenameIEnumerator : AbstractTransformerCompilerStep
    {
        public override void Run()
        {
            this.Visit(this.CompileUnit);
        }
        public override void OnSimpleTypeReference(SimpleTypeReference node)
        {
            if (node.Name == "System.Collections.IEnumerator")
            {
                node.Name = "IEnumerator";
            }
        }
    }
}