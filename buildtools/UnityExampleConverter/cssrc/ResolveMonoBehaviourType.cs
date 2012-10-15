using Boo.Lang.Compiler.Steps;
using Boo.Lang.Compiler.TypeSystem.Reflection;
using System;
using UnityScript;

namespace UnityExampleConverter
{
    [Serializable]
    public class ResolveMonoBehaviourType : AbstractCompilerStep
    {
        public override void Run()
        {
            Type type = this.FindReferencedType("UnityEngine.MonoBehaviour");
            if (type == null)
            {
                type = typeof(MonoBehaviour);
            }
            (Parameters as UnityScriptCompilerParameters).ScriptBaseType = type;
        }
        public Type FindReferencedType(string typeName)
        {
            foreach (var reference in Parameters.References)
            {
                var assemblyRef = reference as IAssemblyReference;
                if (assemblyRef == null) continue;
                var type = assemblyRef.Assembly.GetType(typeName);
                if (type != null) return type;
            }
            return null;
        }
    }
}
