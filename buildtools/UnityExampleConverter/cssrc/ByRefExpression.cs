using Boo.Lang.Compiler.Ast;
using System;

namespace UnityExampleConverter
{
    [Serializable]
    public class ByRefExpression : CustomExpression
    {
        protected Expression _expression;
        public Expression Expression
        {
            get
            {
                return _expression;
            }
            set
            {
                _expression = value;
            }
        }
    }
}