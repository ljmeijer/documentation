using Boo.Lang.Compiler.Ast;
using NUnit.Framework;
using System;
namespace UnityExampleConverter.Tests
{
    [TestFixture]
    [Serializable]
    public class CSharpPrinterTest
    {
        [Test]
        public void UnaryMinus()
        {
            string arg_58_0 = "-42";
            UnaryExpression unaryExpression = new UnaryExpression(LexicalInfo.Empty);
            UnaryOperatorType unaryOperatorType = unaryExpression.Operator = UnaryOperatorType.UnaryNegation;
            UnaryExpression arg_4F_0 = unaryExpression;
            IntegerLiteralExpression integerLiteralExpression = new IntegerLiteralExpression(LexicalInfo.Empty);
            long num = integerLiteralExpression.Value = 42L;
            bool flag = integerLiteralExpression.IsLong = false;
            Expression expression = arg_4F_0.Operand = integerLiteralExpression;
            CSharpAssertModule.AssertCSharpCode(arg_58_0, unaryExpression);
        }
        [Test]
        public void PostIncrement()
        {
            string arg_47_0 = "i++";
            UnaryExpression unaryExpression = new UnaryExpression(LexicalInfo.Empty);
            UnaryOperatorType unaryOperatorType = unaryExpression.Operator = UnaryOperatorType.PostIncrement;
            UnaryExpression arg_3E_0 = unaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "i";
            Expression expression = arg_3E_0.Operand = referenceExpression;
            CSharpAssertModule.AssertCSharpCode(arg_47_0, unaryExpression);
        }
        [Test]
        public void PostDecrement()
        {
            string arg_47_0 = "i--";
            UnaryExpression unaryExpression = new UnaryExpression(LexicalInfo.Empty);
            UnaryOperatorType unaryOperatorType = unaryExpression.Operator = UnaryOperatorType.PostDecrement;
            UnaryExpression arg_3E_0 = unaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "i";
            Expression expression = arg_3E_0.Operand = referenceExpression;
            CSharpAssertModule.AssertCSharpCode(arg_47_0, unaryExpression);
        }
        [Test]
        public void Increment()
        {
            string arg_47_0 = "++i";
            UnaryExpression unaryExpression = new UnaryExpression(LexicalInfo.Empty);
            UnaryOperatorType unaryOperatorType = unaryExpression.Operator = UnaryOperatorType.Increment;
            UnaryExpression arg_3E_0 = unaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "i";
            Expression expression = arg_3E_0.Operand = referenceExpression;
            CSharpAssertModule.AssertCSharpCode(arg_47_0, unaryExpression);
        }
        [Test]
        public void Decrement()
        {
            string arg_47_0 = "--i";
            UnaryExpression unaryExpression = new UnaryExpression(LexicalInfo.Empty);
            UnaryOperatorType unaryOperatorType = unaryExpression.Operator = UnaryOperatorType.Decrement;
            UnaryExpression arg_3E_0 = unaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "i";
            Expression expression = arg_3E_0.Operand = referenceExpression;
            CSharpAssertModule.AssertCSharpCode(arg_47_0, unaryExpression);
        }
        [Test]
        public void Addition()
        {
            string arg_74_0 = "foo + bar";
            BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.Addition;
            BinaryExpression arg_40_0 = binaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "foo";
            Expression expression = arg_40_0.Left = referenceExpression;
            BinaryExpression arg_6B_0 = binaryExpression;
            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
            string text2 = referenceExpression2.Name = "bar";
            Expression expression2 = arg_6B_0.Right = referenceExpression2;
            CSharpAssertModule.AssertCSharpCode(arg_74_0, binaryExpression);
        }
        [Test]
        public void Multiplication()
        {
            string arg_74_0 = "foo * bar";
            BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.Multiply;
            BinaryExpression arg_40_0 = binaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "foo";
            Expression expression = arg_40_0.Left = referenceExpression;
            BinaryExpression arg_6B_0 = binaryExpression;
            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
            string text2 = referenceExpression2.Name = "bar";
            Expression expression2 = arg_6B_0.Right = referenceExpression2;
            CSharpAssertModule.AssertCSharpCode(arg_74_0, binaryExpression);
        }
        [Test]
        public void Subtraction()
        {
            string arg_74_0 = "foo - bar";
            BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.Subtraction;
            BinaryExpression arg_40_0 = binaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "foo";
            Expression expression = arg_40_0.Left = referenceExpression;
            BinaryExpression arg_6B_0 = binaryExpression;
            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
            string text2 = referenceExpression2.Name = "bar";
            Expression expression2 = arg_6B_0.Right = referenceExpression2;
            CSharpAssertModule.AssertCSharpCode(arg_74_0, binaryExpression);
        }
        [Test]
        public void Division()
        {
            string arg_74_0 = "foo / bar";
            BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.Division;
            BinaryExpression arg_40_0 = binaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "foo";
            Expression expression = arg_40_0.Left = referenceExpression;
            BinaryExpression arg_6B_0 = binaryExpression;
            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
            string text2 = referenceExpression2.Name = "bar";
            Expression expression2 = arg_6B_0.Right = referenceExpression2;
            CSharpAssertModule.AssertCSharpCode(arg_74_0, binaryExpression);
        }
        [Test]
        public void And()
        {
            string arg_75_0 = "foo && bar";
            BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.And;
            BinaryExpression arg_41_0 = binaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "foo";
            Expression expression = arg_41_0.Left = referenceExpression;
            BinaryExpression arg_6C_0 = binaryExpression;
            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
            string text2 = referenceExpression2.Name = "bar";
            Expression expression2 = arg_6C_0.Right = referenceExpression2;
            CSharpAssertModule.AssertCSharpCode(arg_75_0, binaryExpression);
        }
        [Test]
        public void Or()
        {
            string arg_75_0 = "foo || bar";
            BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.Or;
            BinaryExpression arg_41_0 = binaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "foo";
            Expression expression = arg_41_0.Left = referenceExpression;
            BinaryExpression arg_6C_0 = binaryExpression;
            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
            string text2 = referenceExpression2.Name = "bar";
            Expression expression2 = arg_6C_0.Right = referenceExpression2;
            CSharpAssertModule.AssertCSharpCode(arg_75_0, binaryExpression);
        }
        [Test]
        public void Assignment()
        {
            string arg_75_0 = "foo = bar";
            BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.Assign;
            BinaryExpression arg_41_0 = binaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "foo";
            Expression expression = arg_41_0.Left = referenceExpression;
            BinaryExpression arg_6C_0 = binaryExpression;
            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
            string text2 = referenceExpression2.Name = "bar";
            Expression expression2 = arg_6C_0.Right = referenceExpression2;
            CSharpAssertModule.AssertCSharpCode(arg_75_0, binaryExpression);
        }
        [Test]
        public void Equality()
        {
            string arg_75_0 = "foo == bar";
            BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.Equality;
            BinaryExpression arg_41_0 = binaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "foo";
            Expression expression = arg_41_0.Left = referenceExpression;
            BinaryExpression arg_6C_0 = binaryExpression;
            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
            string text2 = referenceExpression2.Name = "bar";
            Expression expression2 = arg_6C_0.Right = referenceExpression2;
            CSharpAssertModule.AssertCSharpCode(arg_75_0, binaryExpression);
        }
        [Test]
        public void Inequality()
        {
            string arg_75_0 = "foo != bar";
            BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.Inequality;
            BinaryExpression arg_41_0 = binaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "foo";
            Expression expression = arg_41_0.Left = referenceExpression;
            BinaryExpression arg_6C_0 = binaryExpression;
            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
            string text2 = referenceExpression2.Name = "bar";
            Expression expression2 = arg_6C_0.Right = referenceExpression2;
            CSharpAssertModule.AssertCSharpCode(arg_75_0, binaryExpression);
        }
        [Test]
        public void Greater()
        {
            string arg_75_0 = "foo > bar";
            BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.GreaterThan;
            BinaryExpression arg_41_0 = binaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "foo";
            Expression expression = arg_41_0.Left = referenceExpression;
            BinaryExpression arg_6C_0 = binaryExpression;
            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
            string text2 = referenceExpression2.Name = "bar";
            Expression expression2 = arg_6C_0.Right = referenceExpression2;
            CSharpAssertModule.AssertCSharpCode(arg_75_0, binaryExpression);
        }
        [Test]
        public void GreaterOrEqual()
        {
            string arg_75_0 = "foo >= bar";
            BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.GreaterThanOrEqual;
            BinaryExpression arg_41_0 = binaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "foo";
            Expression expression = arg_41_0.Left = referenceExpression;
            BinaryExpression arg_6C_0 = binaryExpression;
            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
            string text2 = referenceExpression2.Name = "bar";
            Expression expression2 = arg_6C_0.Right = referenceExpression2;
            CSharpAssertModule.AssertCSharpCode(arg_75_0, binaryExpression);
        }
        [Test]
        public void Less()
        {
            string arg_74_0 = "foo < bar";
            BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.LessThan;
            BinaryExpression arg_40_0 = binaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "foo";
            Expression expression = arg_40_0.Left = referenceExpression;
            BinaryExpression arg_6B_0 = binaryExpression;
            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
            string text2 = referenceExpression2.Name = "bar";
            Expression expression2 = arg_6B_0.Right = referenceExpression2;
            CSharpAssertModule.AssertCSharpCode(arg_74_0, binaryExpression);
        }
        [Test]
        public void LessOrEqual()
        {
            string arg_74_0 = "foo <= bar";
            BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.LessThanOrEqual;
            BinaryExpression arg_40_0 = binaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "foo";
            Expression expression = arg_40_0.Left = referenceExpression;
            BinaryExpression arg_6B_0 = binaryExpression;
            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
            string text2 = referenceExpression2.Name = "bar";
            Expression expression2 = arg_6B_0.Right = referenceExpression2;
            CSharpAssertModule.AssertCSharpCode(arg_74_0, binaryExpression);
        }
        [Test]
        public void AdditionMultiplication()
        {
            string arg_127_0 = "(foo + bar) * (bar + foo)";
            BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.Multiply;
            BinaryExpression arg_97_0 = binaryExpression;
            BinaryExpression binaryExpression2 = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType2 = binaryExpression2.Operator = BinaryOperatorType.Addition;
            BinaryExpression arg_60_0 = binaryExpression2;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "foo";
            Expression expression = arg_60_0.Left = referenceExpression;
            BinaryExpression arg_8B_0 = binaryExpression2;
            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
            string text2 = referenceExpression2.Name = "bar";
            Expression expression2 = arg_8B_0.Right = referenceExpression2;
            Expression expression3 = arg_97_0.Left = binaryExpression2;
            BinaryExpression arg_11D_0 = binaryExpression;
            BinaryExpression binaryExpression3 = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType3 = binaryExpression3.Operator = BinaryOperatorType.Addition;
            BinaryExpression arg_E1_0 = binaryExpression3;
            ReferenceExpression referenceExpression3 = new ReferenceExpression(LexicalInfo.Empty);
            string text3 = referenceExpression3.Name = "bar";
            Expression expression4 = arg_E1_0.Left = referenceExpression3;
            BinaryExpression arg_110_0 = binaryExpression3;
            ReferenceExpression referenceExpression4 = new ReferenceExpression(LexicalInfo.Empty);
            string text4 = referenceExpression4.Name = "foo";
            Expression expression5 = arg_110_0.Right = referenceExpression4;
            Expression expression6 = arg_11D_0.Right = binaryExpression3;
            CSharpAssertModule.AssertCSharpCode(arg_127_0, binaryExpression);
        }
        [Test]
        public void AdditionOfUnaryMultiplication()
        {
            string arg_152_0 = "-((foo + bar) * (bar + foo))";
            UnaryExpression unaryExpression = new UnaryExpression(LexicalInfo.Empty);
            UnaryOperatorType unaryOperatorType = unaryExpression.Operator = UnaryOperatorType.UnaryNegation;
            UnaryExpression arg_148_0 = unaryExpression;
            BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.Multiply;
            BinaryExpression arg_B5_0 = binaryExpression;
            BinaryExpression binaryExpression2 = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType2 = binaryExpression2.Operator = BinaryOperatorType.Addition;
            BinaryExpression arg_7E_0 = binaryExpression2;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "foo";
            Expression expression = arg_7E_0.Left = referenceExpression;
            BinaryExpression arg_A9_0 = binaryExpression2;
            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
            string text2 = referenceExpression2.Name = "bar";
            Expression expression2 = arg_A9_0.Right = referenceExpression2;
            Expression expression3 = arg_B5_0.Left = binaryExpression2;
            BinaryExpression arg_13B_0 = binaryExpression;
            BinaryExpression binaryExpression3 = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType3 = binaryExpression3.Operator = BinaryOperatorType.Addition;
            BinaryExpression arg_FF_0 = binaryExpression3;
            ReferenceExpression referenceExpression3 = new ReferenceExpression(LexicalInfo.Empty);
            string text3 = referenceExpression3.Name = "bar";
            Expression expression4 = arg_FF_0.Left = referenceExpression3;
            BinaryExpression arg_12E_0 = binaryExpression3;
            ReferenceExpression referenceExpression4 = new ReferenceExpression(LexicalInfo.Empty);
            string text4 = referenceExpression4.Name = "foo";
            Expression expression5 = arg_12E_0.Right = referenceExpression4;
            Expression expression6 = arg_13B_0.Right = binaryExpression3;
            Expression expression7 = arg_148_0.Operand = binaryExpression;
            CSharpAssertModule.AssertCSharpCode(arg_152_0, unaryExpression);
        }
        [Test]
        public void TertiaryOperator()
        {
            string arg_EF_0 = "((x == y) ? foo : bar)";
            ConditionalExpression conditionalExpression = new ConditionalExpression(LexicalInfo.Empty);
            ConditionalExpression arg_8A_0 = conditionalExpression;
            BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
            BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.Equality;
            BinaryExpression arg_53_0 = binaryExpression;
            ReferenceExpression referenceExpression = new ReferenceExpression(LexicalInfo.Empty);
            string text = referenceExpression.Name = "x";
            Expression expression = arg_53_0.Left = referenceExpression;
            BinaryExpression arg_7E_0 = binaryExpression;
            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
            string text2 = referenceExpression2.Name = "y";
            Expression expression2 = arg_7E_0.Right = referenceExpression2;
            Expression expression3 = arg_8A_0.Condition = binaryExpression;
            ConditionalExpression arg_B6_0 = conditionalExpression;
            ReferenceExpression referenceExpression3 = new ReferenceExpression(LexicalInfo.Empty);
            string text3 = referenceExpression3.Name = "foo";
            Expression expression4 = arg_B6_0.TrueValue = referenceExpression3;
            ConditionalExpression arg_E5_0 = conditionalExpression;
            ReferenceExpression referenceExpression4 = new ReferenceExpression(LexicalInfo.Empty);
            string text4 = referenceExpression4.Name = "bar";
            Expression expression5 = arg_E5_0.FalseValue = referenceExpression4;
            CSharpAssertModule.AssertCSharpCode(arg_EF_0, conditionalExpression);
        }
    }
}
