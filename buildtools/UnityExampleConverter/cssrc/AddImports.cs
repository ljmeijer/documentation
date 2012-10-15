using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.Steps;

namespace UnityExampleConverter
{
    public class AddImports : AbstractTransformerCompilerStep
    {
        public override void Run()
        {
            Visit(CompileUnit);
        }
        public override void OnModule(Module node)
        {
            var imports = new[] { "UnityEngine", "System.Collections" };
            foreach (var importName in imports)
            {
                var targetImport = new Import(LexicalInfo.Empty, importName);
                if (node.Imports.Contains(targetImport))
                    node.Imports.Add(targetImport);
            }
        }
    }
}
