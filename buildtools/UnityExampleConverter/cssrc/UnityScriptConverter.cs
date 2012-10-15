using Boo.Lang;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.MetaProgramming;
using System;
using System.Collections;
using UnityScript;
using UnityScript.Steps;

namespace UnityExampleConverter
{
    [Serializable]
    public class UnityScriptConverter
    {
        protected UnityScriptCompiler _compiler;
        public CompilerInputCollection Input
        {
            get
            {
                return this.Parameters.Input;
            }
        }
        public CompilerReferenceCollection References
        {
            get
            {
                return this.Parameters.References;
            }
        }
        private UnityScriptCompilerParameters Parameters
        {
            get
            {
                return this._compiler.Parameters;
            }
        }
        public UnityScriptConverter()
        {
            this._compiler = new UnityScriptCompiler();
            CompilerPipeline compilerPipeline = UnityScriptCompiler.Pipelines.RawParsing();
            compilerPipeline.Add(new ResolveMonoBehaviourType());
            compilerPipeline.Add(new ApplySemantics());
            compilerPipeline.Add(new ApplyDefaultVisibility());
            compilerPipeline.Add(new TypeInference());
            compilerPipeline.Add(new FixScriptClass());
            compilerPipeline.Add(new RemoveEmptyMethods());
            compilerPipeline.Add(new AddImports());
            compilerPipeline.Add(new RenameArrayDeclaration());
            compilerPipeline.Add(new RenameIEnumerator());
            compilerPipeline.Add(new TransformKnownCalls());
            compilerPipeline.Add(new GenericTransformer());
            this._compiler.Parameters.ScriptMainMethod = "Example";
            this._compiler.Parameters.Pipeline = compilerPipeline;
            List imports = this._compiler.Parameters.Imports;
            imports.Add("UnityEngine");
            imports.Add("System.Collections");
        }
        public void AddReference(string reference)
        {
            this.References.Add(this.Parameters.LoadAssembly(reference, true));
        }
        public CompileUnit[] Run()
        {
            CompilerContext compilerContext = this._compiler.Run();
            if (((ICollection)compilerContext.Errors).Count != 0)
            {
                throw new CompilationErrorsException(compilerContext.Errors);
            }
            CompileUnit compileUnit = compilerContext.CompileUnit;
            CompileUnit node = compileUnit.CloneNode();
            return new CompileUnit[]
		{
			this.ApplyCSharpTransformer(compileUnit),
			this.ApplyBooTransformer(node)
		};
        }
        private CompileUnit ApplyBooTransformer(CompileUnit node)
        {
            node.Accept(new BooTransformer());
            return node;
        }
        private CompileUnit ApplyCSharpTransformer(CompileUnit node)
        {
            node.Accept(new CSharpTransformer());
            return node;
        }
    }
}