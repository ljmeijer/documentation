using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.Steps;
using System;

namespace UnityExampleConverter
{
    [Serializable]
    public class FixScriptClass : AbstractVisitorCompilerStep
    {
        public override void Run()
        {
            Visit(this.CompileUnit);
        }
        public override void LeaveClassDefinition(ClassDefinition node)
        {
            RemovePartialModifier(node);
            SimplifyBaseTypeName(node);
        }
        public void RemovePartialModifier(ClassDefinition node)
        {
            node.Modifiers &= ~TypeMemberModifiers.Partial;
        }
        public void SimplifyBaseTypeName(ClassDefinition node)
        {
            if (node.BaseTypes.Count != 0)
            {
                var simpleTypeReference = node.BaseTypes[0] as SimpleTypeReference;
                if (simpleTypeReference != null && simpleTypeReference.Name == "UnityEngine.MonoBehaviour")
                {
                    simpleTypeReference.Name = "MonoBehaviour";
                }
            }
        }
    }
}
