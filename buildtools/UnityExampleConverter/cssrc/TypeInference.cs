using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.MetaProgramming;
using Boo.Lang.Compiler.Pipelines;
using Boo.Lang.Compiler.Steps;
using Boo.Lang.Compiler.TypeSystem;
using Boo.Lang.Compiler.TypeSystem.Services;
using System;
using System.Collections;
using UnityScript;
using UnityScript.Steps;

namespace UnityExampleConverter
{
    [Serializable]
    public class TypeInference : AbstractVisitorCompilerStep
    {
        protected static readonly object InstantiationAnnotation = new object();
        protected static readonly object TypeLiteral = new object();
        protected CompileUnit _inferredUnit;
        public static bool IsInstantiation(MethodInvocationExpression node)
        {
            return node.ContainsAnnotation(TypeInference.InstantiationAnnotation);
        }
        public static bool IsTypeLiteral(ReferenceExpression node)
        {
            return node.ContainsAnnotation(TypeInference.TypeLiteral);
        }
        public override void Run()
        {
            _inferredUnit = SetUpTypeInferenceSource();
            Visit(CompileUnit);
        }
        public override void LeaveDeclaration(Declaration node)
        {
            if (node.Type == null)
            {
                node.Type = TypeFor(node);
            }
        }
        public override void LeaveField(Field node)
        {
            if (node.Type == null)
            {
                node.Type = TypeFor(node);
            }
        }
        public override void LeaveMethod(Method node)
        {
            if (node.ReturnType == null)
            {
                node.ReturnType = ReturnTypeFor(node);
            }
        }
        public override void LeaveMethodInvocationExpression(MethodInvocationExpression node)
        {
            var methodInvocationExpression = new MethodInvocationFinder(_inferredUnit).Resolve(node) as MethodInvocationExpression;
            if (methodInvocationExpression != null)
            {
                IEntity entity = methodInvocationExpression.Target.Entity;
                if (IsInstantiationMarker(entity))
                {
                    node.Annotate(InstantiationAnnotation);
                }
                node.Target.Entity = entity;
                int i = 0;
                int num = Math.Min(((ICollection)node.Arguments).Count, ((ICollection)methodInvocationExpression.Arguments).Count);
                if (num < 0)
                {
                    throw new ArgumentOutOfRangeException("max");
                }
                while (i < num)
                {
                    int index = i;
                    i++;
                    node.Arguments[index].ExpressionType = methodInvocationExpression.Arguments[index].ExpressionType;
                }
            }
        }
        public override void LeaveArrayLiteralExpression(ArrayLiteralExpression node)
        {
            if (node.Type == null)
            {
                node.Type = (ArrayTypeReference)new ArrayLiteralFinder(this._inferredUnit).TypeFor(node);
            }
        }
        public override void OnReferenceExpression(ReferenceExpression node)
        {
            if (AstUtil.IsStandaloneReference(node) && node.ParentNode.NodeType != NodeType.TypeofExpression && !AstUtil.IsTargetOfMethodInvocation(node))
            {
                Node node2 = new ReferenceFinder(_inferredUnit).Resolve(node) as Node;
                if (node2 != null)
                {
                    if (node2.Entity is IType)
                    {
                        node.Annotate(TypeInference.TypeLiteral);
                    }
                }
            }
        }
        private bool IsInstantiationMarker(object entity)
        {
            return ((entity is IConstructor) || (entity is IType)) || (entity == BuiltinFunction.InitValueType);
        }
        public TypeReference ReturnTypeFor(Method node)
        {
            return new MethodReturnTypeFinder(_inferredUnit).TypeFor(node);
        }
        public TypeReference TypeFor(Field node)
        {
            return new FieldTypeFinder(_inferredUnit).TypeFor(node);
        }
        public TypeReference TypeFor(Declaration node)
        {
            return new DeclarationTypeFinder(_inferredUnit).TypeFor(node);
        }
        public CompileUnit SetUpTypeInferenceSource()
        {
            CompilerPipeline compilerPipeline = UnityScriptCompiler.Pipelines.AdjustBooPipeline(new ResolveExpressions());
            compilerPipeline.RemoveAt(compilerPipeline.Find(typeof(ApplySemantics)));
            compilerPipeline.BreakOnErrors = false;
            var unityScriptCompiler = new UnityScriptCompiler();
            CopyUnityScriptCompilerParametersTo(unityScriptCompiler);
            unityScriptCompiler.Parameters.Pipeline = compilerPipeline;

            unityScriptCompiler.Parameters.AddToEnvironment(
                    typeof(TypeInferenceRuleProvider),
                    GetCustomTypeInferenceRuleProvider);

            var compilerContext = unityScriptCompiler.Run(CompileUnit.CloneNode());
            if (((ICollection)compilerContext.Errors).Count != 0)
            {
                throw new CompilationErrorsException(compilerContext.Errors);
            }
            return compilerContext.CompileUnit;
        }
        public void CopyUnityScriptCompilerParametersTo(UnityScriptCompiler compiler)
        {
            var unityScriptCompilerParameters = (UnityScriptCompilerParameters)Parameters;
            compiler.Parameters.ScriptBaseType = unityScriptCompilerParameters.ScriptBaseType;
            compiler.Parameters.ScriptMainMethod = unityScriptCompilerParameters.ScriptMainMethod;
            compiler.Parameters.References = unityScriptCompilerParameters.References;
        }
        internal object GetCustomTypeInferenceRuleProvider()
        {
            return new CustomTypeInferenceRuleProvider("UnityEngineInternal.TypeInferenceRuleAttribute");
        }
    }
}
