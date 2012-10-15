using System.IO;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.IO;

namespace UnityExampleConverter.Tests
{
    public static class CSharpAssertModule
    {
        public static void AssertCSharpCode(string expected, Node node)
        {
            var output = new StringWriter();
            node.Accept(new CSharpPrinter(output));

            StringsModule.AssertAreEqualIgnoringNewLineDifferences(
                StringsModule.NormalizeIndentation(expected),
                output.ToString().TrimEnd());
        }

        public static void AssertCSharpConversion(string expectedCSharpCode, string unityScriptCode)
        {
            var input = new StringInput("Script", unityScriptCode);
            CompileUnit[] array = Convert(input);
            AssertCSharpCode(expectedCSharpCode, array[0]);
        }
        	
        public static CompileUnit[] Convert(ICompilerInput input)
        {
            var converter = new UnityScriptConverter();
            converter.Input.Add(input);
            converter.References.Add(typeof (UnityEngine.MonoBehaviour).Assembly);
            converter.References.Add(typeof (ExampleScript).Assembly);
            return converter.Run();
        }
    }
}
