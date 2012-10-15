using Boo.Lang.Runtime;
using System;
using System.Runtime.CompilerServices;

namespace UnityExampleConverter
{
    public sealed class CSharpTransformerModule
    {
        public static string SimplifyUnityTypeName(string typeName)
        {
            return (!typeName.StartsWith("UnityEngine.")) ? typeName : typeName.Substring(RuntimeServices.NormalizeStringIndex(typeName, "UnityEngine.".Length));
        }
        private CSharpTransformerModule()
        {
        }
    }
}