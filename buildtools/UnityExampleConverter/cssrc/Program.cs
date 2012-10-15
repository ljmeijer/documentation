using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.IO;
using Boo.Lang.Runtime;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnityExampleConverter
{
    public sealed class MainModule
    {
        public static CompileUnit[] convert(string fileName, string[] references)
        {
            UnityScriptConverter unityScriptConverter = new UnityScriptConverter();
            unityScriptConverter.Input.Add(new FileInput(fileName));
            foreach (string current in references)
                unityScriptConverter.AddReference(current);

            return unityScriptConverter.Run();
        }
        public static void printBooCodeFor(CompileUnit cu)
        {
            Console.WriteLine(cu.ToCodeString());
        }
        public static void printCSharpCodeFor(CompileUnit cu)
        {
            cu.Accept(new CSharpPrinter());
        }
        private static void Main(string[] argv)
        {
            try
            {
                string jsFileName = argv[0];
                string[] references = new string[argv.Length - 1];
                for (int i = 1; i < argv.Length; i++)
                {
                    references[i - 1] = argv[i];
                }
                CompileUnit[] array2 = convert(jsFileName, references);
                CompileUnit cu = array2[0];
                CompileUnit cu2 = array2[1];
                Console.WriteLine("C# Example:");
                MainModule.printCSharpCodeFor(cu);
                Console.WriteLine("Boo Example:");
                MainModule.printBooCodeFor(cu2);
            }
            catch (Exception rhs)
            {
                Console.WriteLine("\n**********************\n" + rhs + "\n**********************\n");
            }
        }
        private MainModule()
        {
        }
    }
}