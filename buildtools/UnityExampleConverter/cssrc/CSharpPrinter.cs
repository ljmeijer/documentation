using Boo.Lang;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.Ast.Visitors;
using Boo.Lang.PatternMatching;
using Boo.Lang.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UnityExampleConverter
{
    [Serializable]
    public class CSharpPrinter : DepthFirstVisitor
    {
        protected string _indentation;
        protected int _level;
        protected TextWriter _writer;
        protected static readonly Hash OperatorPrecenceMap = new Hash
	{

		{
			BinaryOperatorType.Multiply,
			10
		},

		{
			BinaryOperatorType.Division,
			10
		},

		{
			BinaryOperatorType.Modulus,
			10
		},

		{
			BinaryOperatorType.Addition,
			9
		},

		{
			BinaryOperatorType.Subtraction,
			9
		},

		{
			BinaryOperatorType.ShiftLeft,
			8
		},

		{
			BinaryOperatorType.ShiftRight,
			8
		},

		{
			BinaryOperatorType.LessThan,
			7
		},

		{
			BinaryOperatorType.GreaterThan,
			7
		},

		{
			BinaryOperatorType.LessThanOrEqual,
			7
		},

		{
			BinaryOperatorType.GreaterThanOrEqual,
			7
		},

		{
			BinaryOperatorType.TypeTest,
			7
		},

		{
			BinaryOperatorType.Inequality,
			6
		},

		{
			BinaryOperatorType.Equality,
			6
		},

		{
			BinaryOperatorType.BitwiseAnd,
			5
		},

		{
			BinaryOperatorType.ExclusiveOr,
			4
		},

		{
			BinaryOperatorType.BitwiseOr,
			3
		},

		{
			BinaryOperatorType.And,
			2
		},

		{
			BinaryOperatorType.Or,
			1
		}
	};
        private bool csharpPrinterInitialized;
        public CSharpPrinter(TextWriter writer)
        {
            if (!csharpPrinterInitialized)
            {
                _indentation = "    ";
                csharpPrinterInitialized = true;
            }
            _writer = writer;
        }
        public CSharpPrinter()
        {
            if (!csharpPrinterInitialized)
            {
                _indentation = "    ";
                csharpPrinterInitialized = true;
            }
        }
        public string Indent()
        {
            string indent = "";
            for (int i = 0; i < _level; i++)
            {
                indent += _indentation;
            }
            return indent;
        }
        public void AddIndent()
        {
            checked
            {
                _level++;
            }
        }
        public void RemoveIndent()
        {
            if (_level <= 0)
            {
                throw new AssertionFailedException("_level > 0");
            }
            checked
            {
                _level--;
            }
        }
        public string GetAccessLevelForField(Field node)
        {
            string text = string.Empty;
            if (node.IsPrivate)
            {
                text += "private ";
            }
            if (node.IsProtected)
            {
                text += "protected ";
            }
            if (node.IsPublic)
            {
                text += "public ";
            }
            if (node.IsStatic)
            {
                text += "static ";
            }
            if (node.IsVirtual)
            {
                text += "virtual ";
            }
            return text;
        }
        public string GetAccessLevelForMethod(Method node)
        {
            string text = string.Empty;
            if (node.IsPrivate)
            {
                text += "private ";
            }
            if (node.IsProtected)
            {
                text += "protected ";
            }
            if (node.IsPublic)
            {
                text += "public ";
            }
            if (node.IsStatic)
            {
                text += "static ";
            }
            if (node.IsVirtual)
            {
                text += "virtual ";
            }
            if (node.IsFinal)
            {
                text += "final ";
            }
            if (node.IsPartial)
            {
                text += "partial ";
            }
            if (node.IsInternal)
            {
                text += "internal ";
            }
            if (node.IsOverride)
            {
                text += "override ";
            }
            return text;
        }
        public override void OnModule(Module node)
        {
            IEnumerator<Import> enumerator = node.Imports.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Import current = enumerator.Current;
                    WriteLine("using " + current.Namespace + ";");
                }
            }
            finally
            {
                enumerator.Dispose();
            }
            WriteLine();
            Visit<TypeMember>(node.Members);
        }
        public override void OnClassDefinition(ClassDefinition node)
        {
            WriteAttributes(node.Attributes);
            Write(new StringBuilder("public class ").Append(node.Name).Append(" : MonoBehaviour").ToString());
            BeginBlock();
            Visit<TypeMember>(node.Members);
            EndBlock();
        }
        public override void OnParameterDeclaration(ParameterDeclaration node)
        {
            Write(node.Type);
            Write(" ");
            Write(node.Name);
        }
        public override void OnGenericReferenceExpression(GenericReferenceExpression node)
        {
            Write(node.Target);
            Write("<");
            WriteCommaSeparatedList(node.GenericArguments);
            Write(">");
        }
        public override void OnMemberReferenceExpression(MemberReferenceExpression node)
        {
            Write(node.Target);
            Write(".");
            Write(node.Name);
        }
        public override void OnReferenceExpression(ReferenceExpression node)
        {
            Write(node.Name);
        }
        public override void OnSimpleTypeReference(SimpleTypeReference node)
        {
            Write(node.Name);
        }
        public override void OnArrayTypeReference(ArrayTypeReference node)
        {
            if (node.Rank.Value != 1L)
            {
                throw new AssertionFailedException("node.Rank.Value == 1");
            }
            Write(node.ElementType);
            Write("[]");
        }
        public override void OnDeclarationStatement(DeclarationStatement node)
        {
            Write(Indent());
            Visit(node.Declaration);
            if (node.Initializer != null)
            {
                Write(" = ");
                Visit(node.Initializer);
            }
            WriteLine(";");
        }
        public override void OnDeclaration(Declaration node)
        {
            Write(node.Type);
            Write(" ");
            Write(node.Name);
        }
        public override void OnTryCastExpression(TryCastExpression node)
        {
            Write(node.Target);
            Write(" as ");
            Write(node.Type);
        }
        public override void OnTypeofExpression(TypeofExpression node)
        {
            Write("typeof(");
            Write(node.Type);
            Write(")");
        }
        public override void OnCustomExpression(CustomExpression node)
        {
            if (node is ByRefExpression)
            {
                Write("ref ");
                Write(((ByRefExpression)node).Expression);
                return;
            }
            if (node is OutputExpression)
            {
                Write("out ");
                Write(((OutputExpression)node).Expression);
                return;

            }
            throw new MatchError(new StringBuilder("`node` failed to match `").Append(node).Append("`").ToString());
        }
        public override void OnMethodInvocationExpression(MethodInvocationExpression node)
        {
            if (node is MethodInvocationExpression && node.Target is GenericReferenceExpression)
            {
                GenericReferenceExpression genericReferenceExpression = (GenericReferenceExpression)node.Target;
                if (genericReferenceExpression.Target is ReferenceExpression)
                {
                    ReferenceExpression referenceExpression = (ReferenceExpression)genericReferenceExpression.Target;
                    if (referenceExpression.Name == "array" && 1 == ((ICollection)genericReferenceExpression.GenericArguments).Count)
                    {
                        TypeReference node2 = genericReferenceExpression.GenericArguments[0];
                        if (1 == ((ICollection)node.Arguments).Count)
                        {
                            Expression node3 = node.Arguments[0];

                            Write("new ");
                            Write(node2);
                            Write("[");
                            Write(node3);
                            Write("]");
                            return;
                        }
                    }
                }
            }
            if (IsInstantiation(node))
            {
                Write("new ");
            }
            Write(node.Target);
            WriteParenthesidCommaSeparatedList(node.Arguments);
        }
        public void WriteParenthesidCommaSeparatedList(ExpressionCollection expressions)
        {
            Write("(");
            WriteCommaSeparatedList(expressions);
            Write(")");
        }
        public bool IsInstantiation(MethodInvocationExpression node)
        {
            return TypeInference.IsInstantiation(node);
        }
        public override void OnMethod(Method node)
        {
            WriteAttributes(node.Attributes);
            Write(Indent());
            Write(GetAccessLevelForMethod(node));
            Write(node.ReturnType);
            Write(" " + node.Name + "(");
            WriteCommaSeparatedList(node.Parameters);
            Write(")");
            BeginBlock();
            Visit(node.Body);
            EndBlock();
        }
        public override void OnReturnStatement(ReturnStatement node)
        {
            Write(Indent() + "return");
            if (node.Expression != null)
            {
                Write(" ");
                Visit(node.Expression);
            }
            WriteLine(";");
        }
        public override void OnNullLiteralExpression(NullLiteralExpression node)
        {
            Write("null");
        }
        public override void OnTryStatement(TryStatement node)
        {
            Write(Indent() + "try");
            BeginBlock();
            Visit(node.ProtectedBlock);
            EndBlock();
            for (int num = 0; num < node.ExceptionHandlers.Count; num += 1)
            {
                Visit(node.ExceptionHandlers[num]);
            }
            WriteLine();
        }
        public override void OnExceptionHandler(ExceptionHandler node)
        {
            Write(Indent() + "catch(");
            Visit(node.Declaration);
            Write(")");
            BeginBlock();
            Visit(node.Block);
            EndBlock();
        }
        public override void OnField(Field node)
        {
            WriteAttributes(node.Attributes);
            Write(Indent());
            Write(GetAccessLevelForField(node));
            Write(node.Type);
            Write(" ");
            Write(node.Name);
            if (node.Initializer != null)
            {
                Write(" = ");
                Write(node.Initializer);
            }
            WriteLine(";");
        }
        public override void OnYieldStatement(YieldStatement node)
        {
            Write(Indent());
            Write("yield return ");
            if (node.Expression == null)
            {
                Write("null");
            }
            else
            {
                Visit(node.Expression);
            }
            WriteLine(";");
        }
        public override void OnIfStatement(IfStatement node)
        {
            Write(Indent() + "if (");
            Visit(node.Condition);
            Write(")");
            if (node.TrueBlock.Statements.Count == 1)
            {
                WriteLine();
                AddIndent();
            }
            else
            {
                BeginBlock();
            }
            Visit(node.TrueBlock);
            RemoveIndent();
            if (node.TrueBlock.Statements.Count == 1)
            {
                Write(Indent());
            }
            else
            {
                Write(Indent() + "}");
            }
            if (node.FalseBlock != null)
            {
                if (node.TrueBlock.Statements.Count != 1)
                {
                    Write(" ");
                }
                if (node.FalseBlock.Statements.Count == 1)
                {
                    WriteLine("else");
                }
                else
                {
                    WriteLine("else {");
                }
                AddIndent();
                Visit(node.FalseBlock);
                if (node.FalseBlock.Statements.Count == 1)
                {
                    RemoveIndent();
                }
                else
                {
                    EndBlock();
                }
            }
            else
            {
                WriteLine();
            }
        }
        public override void OnConditionalExpression(ConditionalExpression node)
        {
            Write("(");
            Write("(");
            Write(node.Condition);
            Write(")");
            Write(" ? ");
            Write(node.TrueValue);
            Write(" : ");
            Write(node.FalseValue);
            Write(")");
        }
        public override void OnForStatement(ForStatement node)
        {
            Write(Indent() + "foreach (");
            Visit<Declaration>(node.Declarations);
            Write(" in ");
            Visit(node.Iterator);
            Write(")");
            BeginBlock();
            Visit(node.Block);
            EndBlock();
        }
        public override void OnWhileStatement(WhileStatement node)
        {
            Write(Indent() + "while (");
            Visit(node.Condition);
            Write(")");
            BeginBlock();
            Visit(node.Block);
            EndBlock();
        }
        public override void OnBinaryExpression(BinaryExpression node)
        {
            if (RequiresParenthesis(node))
            {
                Write("(");
                WriteBinaryExpression(node);
                Write(")");
            }
            else
            {
                WriteBinaryExpression(node);
            }
        }
        public string CSharpOperatorFor(BinaryOperatorType op)
        {
            return (op != BinaryOperatorType.And) ? ((op != BinaryOperatorType.Or) ? BooPrinterVisitor.GetBinaryOperatorText(op) : "||") : "&&";
        }
        public bool RequiresParenthesis(BinaryExpression node)
        {
            return PrecedenceOf(node.ParentNode) > PrecedenceOf(node);
        }
        public int PrecedenceOf(Node node)
        {
            BinaryExpression binaryExpression = node as BinaryExpression;
            return (binaryExpression == null) ? ((!(node is UnaryExpression)) ? 0 : 11) : PrecedenceOf(binaryExpression.Operator);
        }
        public int PrecedenceOf(BinaryOperatorType op)
        {
            object arg_22_0;
            if (!RuntimeServices.ToBool(arg_22_0 = CSharpPrinter.OperatorPrecenceMap[op]))
            {
                arg_22_0 = 0;
            }
            return RuntimeServices.UnboxInt32(arg_22_0);
        }
        public void WriteBinaryExpression(BinaryExpression node)
        {
            Visit(node.Left);
            Write(new StringBuilder(" ").Append(CSharpOperatorFor(node.Operator)).Append(" ").ToString());
            Visit(node.Right);
        }
        public override void OnUnaryExpression(UnaryExpression node)
        {
            if (node.Operator == UnaryOperatorType.LogicalNot)
            {
                Expression operand = node.Operand;

                Write("!");
                Write(operand);
                return;
            }
            if (node.Operator == UnaryOperatorType.UnaryNegation)
            {
                Expression operand = node.Operand;

                Write("-");
                Write(operand);
                return;
            }
            if (node.Operator == UnaryOperatorType.Increment)
            {
                Expression operand = node.Operand;

                Write("++");
                Write(operand);
                return;
            }
            if (node.Operator == UnaryOperatorType.Decrement)
            {
                Expression operand = node.Operand;
                Write("--");
                Write(operand);
                return;
            }
            if (node.Operator == UnaryOperatorType.PostIncrement)
            {
                Expression operand = node.Operand;
                Write(operand);
                Write("++");
                return;
            }
            if (node.Operator == UnaryOperatorType.PostDecrement)
            {
                Expression operand = node.Operand;
                Write(operand);
                Write("--");
                return;
            }
            throw new MatchError(new StringBuilder("`node` failed to match `").Append(node).Append("`").ToString());
        }
        public override void OnIntegerLiteralExpression(IntegerLiteralExpression node)
        {
            Write(node.ToString());
        }
        public override bool EnterExpressionStatement(ExpressionStatement node)
        {
            Write(Indent());
            return true;
        }
        public override void LeaveExpressionStatement(ExpressionStatement node)
        {
            WriteLine(";");
        }
        public override void OnBoolLiteralExpression(BoolLiteralExpression node)
        {
            Write(node.ToString());
        }
        public override void OnDoubleLiteralExpression(DoubleLiteralExpression node)
        {
            Write(node.ToString());
        }
        public override void OnArrayLiteralExpression(ArrayLiteralExpression node)
        {
            Write("new ");
            if (node.Type != null)
            {
                Write(node.Type);
            }
            else
            {
                Write("[]");
            }
            Write(" {");
            WriteCommaSeparatedList(node.Items);
            Write("}");
        }
        public override void OnStringLiteralExpression(StringLiteralExpression node)
        {
            Write("\"");
            Write(node.Value.Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "\\r").Replace("\b", "\\b"));
            Write("\"");
        }
        public override void OnSlicingExpression(SlicingExpression node)
        {
            Write(node.Target);
            Write("[");
            WriteCommaSeparatedList(node.Indices);
            Write("]");
        }
        public override void OnSlice(Slice node)
        {
            Write(node.Begin);
        }
        private void BeginBlock()
        {
            WriteLine(" {");
            AddIndent();
        }
        private void EndBlock()
        {
            RemoveIndent();
            Write(Indent());
            WriteLine("}");
        }
        private void WriteAttributes(AttributeCollection attributes)
        {
            IEnumerator<Boo.Lang.Compiler.Ast.Attribute> enumerator = attributes.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Boo.Lang.Compiler.Ast.Attribute current = enumerator.Current;
                    Write(Indent());
                    Write("[");
                    Write(current.Name);
                    if (((ICollection)current.Arguments).Count > 0)
                    {
                        WriteParenthesidCommaSeparatedList(current.Arguments);
                    }
                    Write("]");
                    WriteLine();
                }
            }
            finally
            {
                enumerator.Dispose();
            }
        }
        private void WriteCommaSeparatedList(object nodes)
        {
            bool flag = true;
            IEnumerator enumerator = RuntimeServices.GetEnumerable(nodes).GetEnumerator();
            while (enumerator.MoveNext())
            {
                object arg_33_0;
                object expr_19 = arg_33_0 = enumerator.Current;
                if (!(expr_19 is Node))
                {
                    arg_33_0 = RuntimeServices.Coerce(expr_19, typeof(Node));
                }
                Node node = (Node)arg_33_0;
                if (!flag)
                {
                    Write(", ");
                }
                flag = false;
                Write(node);
            }
        }
        public void Write(Node node)
        {
            Visit(node);
        }
        public void Write(string text)
        {
            _writer.Write(text);
        }
        public void WriteLine(string text)
        {
            _writer.WriteLine(text);
        }
        public void WriteLine()
        {
            _writer.WriteLine();
        }
    }
}