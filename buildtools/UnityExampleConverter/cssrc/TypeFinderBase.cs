using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.TypeSystem;
using Boo.Lang.Environments;
using Boo.Lang.Runtime;
using System;

namespace UnityExampleConverter
{
    [Serializable]
    public class TypeFinderBase : DepthFirstVisitor
    {
        protected CompileUnit _source;
        protected LexicalInfo _lookingFor;
        protected object _found;
        public TypeFinderBase(CompileUnit source)
        {
            _source = source;
        }
        public TypeReference TypeFor(Node node)
        {
            object arg_21_0;
            object expr_07 = arg_21_0 = Resolve(node);
            if (!(expr_07 is IType))
            {
                arg_21_0 = RuntimeServices.Coerce(expr_07, typeof(IType));
            }
            IType type = (IType)arg_21_0;
            return My<BooCodeBuilder>.Instance.CreateTypeReference(type);
        }
        public object Resolve(Node node)
        {
            _lookingFor = node.LexicalInfo;
            VisitAllowingCancellation(_source);
            return _found;
        }
        protected bool LookingFor(Node node)
        {
            return node.LexicalInfo == _lookingFor;
        }
        protected void Found(object value)
        {
            _found = value;
            Cancel();
        }
        protected void Found(TypeReference type)
        {
            Found(TypeSystemServices.GetType(type));
        }
    }
}
