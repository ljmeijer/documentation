using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.Steps;
using Boo.Lang.Compiler.TypeSystem;
using System;
using System.Collections;

namespace UnityExampleConverter
{
    [Serializable]
    public class TransformKnownCalls : AbstractTransformerCompilerStep
    {
        protected bool isBinaryExp;
        public override void Run()
        {
            Visit(CompileUnit);
        }
        public override void LeaveBinaryExpression(BinaryExpression node)
        {
            if (node is BinaryExpression && node.Operator == BinaryOperatorType.Assign)
            {
                Expression left = node.Left;
                if (true && node.Right is MethodInvocationExpression)
                {
                    MethodInvocationExpression methodInvocationExpression = (MethodInvocationExpression)node.Right;
                    if (true && methodInvocationExpression.Target is MemberReferenceExpression)
                    {
                        MemberReferenceExpression memberReferenceExpression = (MemberReferenceExpression)methodInvocationExpression.Target;
                        if (true)
                        {
                            Expression target = memberReferenceExpression.Target;
                            if (true && memberReferenceExpression.Name == "AddComponent" && 1 == ((ICollection)methodInvocationExpression.Arguments).Count && methodInvocationExpression.Arguments[0] is StringLiteralExpression)
                            {
                                StringLiteralExpression stringLiteralExpression = (StringLiteralExpression)methodInvocationExpression.Arguments[0];
                                if (true)
                                {
                                    string value = stringLiteralExpression.Value;
                                    if (true)
                                    {
                                        BinaryExpression binaryExpression = new BinaryExpression(LexicalInfo.Empty);
                                        BinaryOperatorType binaryOperatorType = binaryExpression.Operator = BinaryOperatorType.Assign;
                                        Expression expression = binaryExpression.Left = Expression.Lift(left);
                                        BinaryExpression arg_1D2_0 = binaryExpression;
                                        TryCastExpression tryCastExpression = new TryCastExpression(LexicalInfo.Empty);
                                        TryCastExpression arg_1B1_0 = tryCastExpression;
                                        MethodInvocationExpression methodInvocationExpression2 = new MethodInvocationExpression(LexicalInfo.Empty);
                                        MethodInvocationExpression arg_182_0 = methodInvocationExpression2;
                                        MemberReferenceExpression memberReferenceExpression2 = new MemberReferenceExpression(LexicalInfo.Empty);
                                        string text = memberReferenceExpression2.Name = "AddComponent";
                                        Expression expression2 = memberReferenceExpression2.Target = Expression.Lift(target);
                                        Expression expression3 = arg_182_0.Target = memberReferenceExpression2;
                                        ExpressionCollection expressionCollection = methodInvocationExpression2.Arguments = ExpressionCollection.FromArray(new Expression[]
									{
										Expression.Lift(value)
									});
                                        Expression expression4 = arg_1B1_0.Target = methodInvocationExpression2;
                                        TypeReference typeReference = tryCastExpression.Type = TypeReference.Lift(value);
                                        Expression expression5 = arg_1D2_0.Right = tryCastExpression;
                                        this.ReplaceCurrentNode(binaryExpression);
                                        this.isBinaryExp = true;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (node.Operator == BinaryOperatorType.Assign)
            {
                Expression left = node.Left;
                if (node.Right is MethodInvocationExpression)
                {
                    MethodInvocationExpression methodInvocationExpression3 = (MethodInvocationExpression)node.Right;
                    if (true && methodInvocationExpression3.Target is ReferenceExpression)
                    {
                        ReferenceExpression referenceExpression = (ReferenceExpression)methodInvocationExpression3.Target;
                        if (true && referenceExpression.Name == "AddComponent" && 1 == ((ICollection)methodInvocationExpression3.Arguments).Count && methodInvocationExpression3.Arguments[0] is StringLiteralExpression)
                        {
                            StringLiteralExpression stringLiteralExpression2 = (StringLiteralExpression)methodInvocationExpression3.Arguments[0];
                            if (true)
                            {
                                string value = stringLiteralExpression2.Value;
                                if (true)
                                {
                                    BinaryExpression binaryExpression2 = new BinaryExpression(LexicalInfo.Empty);
                                    BinaryOperatorType binaryOperatorType2 = binaryExpression2.Operator = BinaryOperatorType.Assign;
                                    Expression expression6 = binaryExpression2.Left = Expression.Lift(left);
                                    BinaryExpression arg_3A3_0 = binaryExpression2;
                                    TryCastExpression tryCastExpression2 = new TryCastExpression(LexicalInfo.Empty);
                                    TryCastExpression arg_382_0 = tryCastExpression2;
                                    MethodInvocationExpression methodInvocationExpression4 = new MethodInvocationExpression(LexicalInfo.Empty);
                                    MethodInvocationExpression arg_353_0 = methodInvocationExpression4;
                                    ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
                                    string text2 = referenceExpression2.Name = "AddComponent";
                                    Expression expression7 = arg_353_0.Target = referenceExpression2;
                                    ExpressionCollection expressionCollection2 = methodInvocationExpression4.Arguments = ExpressionCollection.FromArray(new Expression[]
								{
									Expression.Lift(value)
								});
                                    Expression expression8 = arg_382_0.Target = methodInvocationExpression4;
                                    TypeReference typeReference2 = tryCastExpression2.Type = TypeReference.Lift(value);
                                    Expression expression9 = arg_3A3_0.Right = tryCastExpression2;
                                    this.ReplaceCurrentNode(binaryExpression2);
                                    this.isBinaryExp = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        public override void LeaveMethodInvocationExpression(MethodInvocationExpression node)
        {
            if (node is MethodInvocationExpression && true && node.Target is MemberReferenceExpression)
            {
                MemberReferenceExpression memberReferenceExpression = (MemberReferenceExpression)node.Target;
                if (true)
                {
                    Expression target = memberReferenceExpression.Target;
                    if (true && memberReferenceExpression.Name == "GetComponent" && 1 == ((ICollection)node.Arguments).Count && node.Arguments[0] is StringLiteralExpression)
                    {
                        StringLiteralExpression stringLiteralExpression = (StringLiteralExpression)node.Arguments[0];
                        if (true)
                        {
                            string value = stringLiteralExpression.Value;
                            if (true)
                            {
                                TryCastExpression tryCastExpression = new TryCastExpression(LexicalInfo.Empty);
                                TryCastExpression arg_13A_0 = tryCastExpression;
                                MethodInvocationExpression methodInvocationExpression = new MethodInvocationExpression(LexicalInfo.Empty);
                                MethodInvocationExpression arg_10B_0 = methodInvocationExpression;
                                MemberReferenceExpression memberReferenceExpression2 = new MemberReferenceExpression(LexicalInfo.Empty);
                                string text = memberReferenceExpression2.Name = "GetComponent";
                                Expression expression = memberReferenceExpression2.Target = Expression.Lift(target);
                                Expression expression2 = arg_10B_0.Target = memberReferenceExpression2;
                                ExpressionCollection expressionCollection = methodInvocationExpression.Arguments = ExpressionCollection.FromArray(new Expression[]
							{
								Expression.Lift(value)
							});
                                Expression expression3 = arg_13A_0.Target = methodInvocationExpression;
                                TypeReference typeReference = tryCastExpression.Type = TypeReference.Lift(value);
                                this.ReplaceCurrentNode(tryCastExpression);
                                return;
                            }
                        }
                    }
                }
            }
            if (node is MethodInvocationExpression && true && node.Target is ReferenceExpression)
            {
                ReferenceExpression referenceExpression = (ReferenceExpression)node.Target;
                if (true && referenceExpression.Name == "GetComponent" && 1 == ((ICollection)node.Arguments).Count && node.Arguments[0] is StringLiteralExpression)
                {
                    StringLiteralExpression stringLiteralExpression2 = (StringLiteralExpression)node.Arguments[0];
                    if (true)
                    {
                        string value = stringLiteralExpression2.Value;
                        if (true)
                        {
                            TryCastExpression tryCastExpression2 = new TryCastExpression(LexicalInfo.Empty);
                            TryCastExpression arg_280_0 = tryCastExpression2;
                            MethodInvocationExpression methodInvocationExpression2 = new MethodInvocationExpression(LexicalInfo.Empty);
                            MethodInvocationExpression arg_251_0 = methodInvocationExpression2;
                            ReferenceExpression referenceExpression2 = new ReferenceExpression(LexicalInfo.Empty);
                            string text2 = referenceExpression2.Name = "GetComponent";
                            Expression expression4 = arg_251_0.Target = referenceExpression2;
                            ExpressionCollection expressionCollection2 = methodInvocationExpression2.Arguments = ExpressionCollection.FromArray(new Expression[]
						{
							Expression.Lift(value)
						});
                            Expression expression5 = arg_280_0.Target = methodInvocationExpression2;
                            TypeReference typeReference2 = tryCastExpression2.Type = TypeReference.Lift(value);
                            this.ReplaceCurrentNode(tryCastExpression2);
                            return;
                        }
                    }
                }
            }
            if (node is MethodInvocationExpression && true && node.Target is MemberReferenceExpression)
            {
                MemberReferenceExpression memberReferenceExpression3 = (MemberReferenceExpression)node.Target;
                if (true)
                {
                    Expression target = memberReferenceExpression3.Target;
                    if (true && memberReferenceExpression3.Name == "GetComponent" && 1 == ((ICollection)node.Arguments).Count && node.Arguments[0] is ReferenceExpression)
                    {
                        ReferenceExpression e = (ReferenceExpression)node.Arguments[0];
                        if (true)
                        {
                            MethodInvocationExpression methodInvocationExpression3 = new MethodInvocationExpression(LexicalInfo.Empty);
                            MethodInvocationExpression arg_3D8_0 = methodInvocationExpression3;
                            GenericReferenceExpression genericReferenceExpression = new GenericReferenceExpression(LexicalInfo.Empty);
                            GenericReferenceExpression arg_3A9_0 = genericReferenceExpression;
                            MemberReferenceExpression memberReferenceExpression4 = new MemberReferenceExpression(LexicalInfo.Empty);
                            string text3 = memberReferenceExpression4.Name = "GetComponent";
                            Expression expression6 = memberReferenceExpression4.Target = Expression.Lift(target);
                            Expression expression7 = arg_3A9_0.Target = memberReferenceExpression4;
                            TypeReferenceCollection typeReferenceCollection = genericReferenceExpression.GenericArguments = TypeReferenceCollection.FromArray(new TypeReference[]
						{
							TypeReference.Lift(e)
						});
                            Expression expression8 = arg_3D8_0.Target = genericReferenceExpression;
                            this.ReplaceCurrentNode(methodInvocationExpression3);
                            return;
                        }
                    }
                }
            }
            if (node is MethodInvocationExpression && true && node.Target is ReferenceExpression)
            {
                ReferenceExpression referenceExpression3 = (ReferenceExpression)node.Target;
                if (true && referenceExpression3.Name == "GetComponent" && 1 == ((ICollection)node.Arguments).Count && node.Arguments[0] is ReferenceExpression)
                {
                    ReferenceExpression e = (ReferenceExpression)node.Arguments[0];
                    if (true)
                    {
                        MethodInvocationExpression methodInvocationExpression4 = new MethodInvocationExpression(LexicalInfo.Empty);
                        MethodInvocationExpression arg_4F9_0 = methodInvocationExpression4;
                        GenericReferenceExpression genericReferenceExpression2 = new GenericReferenceExpression(LexicalInfo.Empty);
                        GenericReferenceExpression arg_4CA_0 = genericReferenceExpression2;
                        ReferenceExpression referenceExpression4 = new ReferenceExpression(LexicalInfo.Empty);
                        string text4 = referenceExpression4.Name = "GetComponent";
                        Expression expression9 = arg_4CA_0.Target = referenceExpression4;
                        TypeReferenceCollection typeReferenceCollection2 = genericReferenceExpression2.GenericArguments = TypeReferenceCollection.FromArray(new TypeReference[]
					{
						TypeReference.Lift(e)
					});
                        Expression expression10 = arg_4F9_0.Target = genericReferenceExpression2;
                        this.ReplaceCurrentNode(methodInvocationExpression4);
                        return;
                    }
                }
            }
            if (node is MethodInvocationExpression && true && node.Target is MemberReferenceExpression)
            {
                MemberReferenceExpression memberReferenceExpression5 = (MemberReferenceExpression)node.Target;
                if (true)
                {
                    Expression target = memberReferenceExpression5.Target;
                    if (true && memberReferenceExpression5.Name == "GetComponents" && 1 == ((ICollection)node.Arguments).Count && node.Arguments[0] is ReferenceExpression)
                    {
                        ReferenceExpression e = (ReferenceExpression)node.Arguments[0];
                        if (true)
                        {
                            MethodInvocationExpression methodInvocationExpression5 = new MethodInvocationExpression(LexicalInfo.Empty);
                            MethodInvocationExpression arg_63D_0 = methodInvocationExpression5;
                            GenericReferenceExpression genericReferenceExpression3 = new GenericReferenceExpression(LexicalInfo.Empty);
                            GenericReferenceExpression arg_60E_0 = genericReferenceExpression3;
                            MemberReferenceExpression memberReferenceExpression6 = new MemberReferenceExpression(LexicalInfo.Empty);
                            string text5 = memberReferenceExpression6.Name = "GetComponents";
                            Expression expression11 = memberReferenceExpression6.Target = Expression.Lift(target);
                            Expression expression12 = arg_60E_0.Target = memberReferenceExpression6;
                            TypeReferenceCollection typeReferenceCollection3 = genericReferenceExpression3.GenericArguments = TypeReferenceCollection.FromArray(new TypeReference[]
						{
							TypeReference.Lift(e)
						});
                            Expression expression13 = arg_63D_0.Target = genericReferenceExpression3;
                            this.ReplaceCurrentNode(methodInvocationExpression5);
                            return;
                        }
                    }
                }
            }
            if (node is MethodInvocationExpression && true && node.Target is ReferenceExpression)
            {
                ReferenceExpression referenceExpression5 = (ReferenceExpression)node.Target;
                if (true && referenceExpression5.Name == "GetComponents" && 1 == ((ICollection)node.Arguments).Count && node.Arguments[0] is ReferenceExpression)
                {
                    ReferenceExpression e = (ReferenceExpression)node.Arguments[0];
                    if (true)
                    {
                        MethodInvocationExpression methodInvocationExpression6 = new MethodInvocationExpression(LexicalInfo.Empty);
                        MethodInvocationExpression arg_75E_0 = methodInvocationExpression6;
                        GenericReferenceExpression genericReferenceExpression4 = new GenericReferenceExpression(LexicalInfo.Empty);
                        GenericReferenceExpression arg_72F_0 = genericReferenceExpression4;
                        ReferenceExpression referenceExpression6 = new ReferenceExpression(LexicalInfo.Empty);
                        string text6 = referenceExpression6.Name = "GetComponents";
                        Expression expression14 = arg_72F_0.Target = referenceExpression6;
                        TypeReferenceCollection typeReferenceCollection4 = genericReferenceExpression4.GenericArguments = TypeReferenceCollection.FromArray(new TypeReference[]
					{
						TypeReference.Lift(e)
					});
                        Expression expression15 = arg_75E_0.Target = genericReferenceExpression4;
                        this.ReplaceCurrentNode(methodInvocationExpression6);
                        return;
                    }
                }
            }
            if (node is MethodInvocationExpression && true && node.Target is MemberReferenceExpression)
            {
                MemberReferenceExpression memberReferenceExpression7 = (MemberReferenceExpression)node.Target;
                if (true)
                {
                    Expression target = memberReferenceExpression7.Target;
                    if (true && memberReferenceExpression7.Name == "GetComponentsInChildren" && 1 == ((ICollection)node.Arguments).Count && node.Arguments[0] is ReferenceExpression)
                    {
                        ReferenceExpression e = (ReferenceExpression)node.Arguments[0];
                        if (true)
                        {
                            MethodInvocationExpression methodInvocationExpression7 = new MethodInvocationExpression(LexicalInfo.Empty);
                            MethodInvocationExpression arg_8A2_0 = methodInvocationExpression7;
                            GenericReferenceExpression genericReferenceExpression5 = new GenericReferenceExpression(LexicalInfo.Empty);
                            GenericReferenceExpression arg_873_0 = genericReferenceExpression5;
                            MemberReferenceExpression memberReferenceExpression8 = new MemberReferenceExpression(LexicalInfo.Empty);
                            string text7 = memberReferenceExpression8.Name = "GetComponentsInChildren";
                            Expression expression16 = memberReferenceExpression8.Target = Expression.Lift(target);
                            Expression expression17 = arg_873_0.Target = memberReferenceExpression8;
                            TypeReferenceCollection typeReferenceCollection5 = genericReferenceExpression5.GenericArguments = TypeReferenceCollection.FromArray(new TypeReference[]
						{
							TypeReference.Lift(e)
						});
                            Expression expression18 = arg_8A2_0.Target = genericReferenceExpression5;
                            this.ReplaceCurrentNode(methodInvocationExpression7);
                            return;
                        }
                    }
                }
            }
            if (node is MethodInvocationExpression && true && node.Target is ReferenceExpression)
            {
                ReferenceExpression referenceExpression7 = (ReferenceExpression)node.Target;
                if (true && referenceExpression7.Name == "GetComponentsInChildren" && 1 == ((ICollection)node.Arguments).Count && node.Arguments[0] is ReferenceExpression)
                {
                    ReferenceExpression e = (ReferenceExpression)node.Arguments[0];
                    if (true)
                    {
                        MethodInvocationExpression methodInvocationExpression8 = new MethodInvocationExpression(LexicalInfo.Empty);
                        MethodInvocationExpression arg_9C3_0 = methodInvocationExpression8;
                        GenericReferenceExpression genericReferenceExpression6 = new GenericReferenceExpression(LexicalInfo.Empty);
                        GenericReferenceExpression arg_994_0 = genericReferenceExpression6;
                        ReferenceExpression referenceExpression8 = new ReferenceExpression(LexicalInfo.Empty);
                        string text8 = referenceExpression8.Name = "GetComponentsInChildren";
                        Expression expression19 = arg_994_0.Target = referenceExpression8;
                        TypeReferenceCollection typeReferenceCollection6 = genericReferenceExpression6.GenericArguments = TypeReferenceCollection.FromArray(new TypeReference[]
					{
						TypeReference.Lift(e)
					});
                        Expression expression20 = arg_9C3_0.Target = genericReferenceExpression6;
                        this.ReplaceCurrentNode(methodInvocationExpression8);
                        return;
                    }
                }
            }
            if (node is MethodInvocationExpression && true && node.Target is MemberReferenceExpression)
            {
                MemberReferenceExpression memberReferenceExpression9 = (MemberReferenceExpression)node.Target;
                if (true)
                {
                    Expression target = memberReferenceExpression9.Target;
                    if (true && memberReferenceExpression9.Name == "GetComponentInChildren" && 1 == ((ICollection)node.Arguments).Count && node.Arguments[0] is ReferenceExpression)
                    {
                        ReferenceExpression e = (ReferenceExpression)node.Arguments[0];
                        if (true)
                        {
                            MethodInvocationExpression methodInvocationExpression9 = new MethodInvocationExpression(LexicalInfo.Empty);
                            MethodInvocationExpression arg_B07_0 = methodInvocationExpression9;
                            GenericReferenceExpression genericReferenceExpression7 = new GenericReferenceExpression(LexicalInfo.Empty);
                            GenericReferenceExpression arg_AD8_0 = genericReferenceExpression7;
                            MemberReferenceExpression memberReferenceExpression10 = new MemberReferenceExpression(LexicalInfo.Empty);
                            string text9 = memberReferenceExpression10.Name = "GetComponentInChildren";
                            Expression expression21 = memberReferenceExpression10.Target = Expression.Lift(target);
                            Expression expression22 = arg_AD8_0.Target = memberReferenceExpression10;
                            TypeReferenceCollection typeReferenceCollection7 = genericReferenceExpression7.GenericArguments = TypeReferenceCollection.FromArray(new TypeReference[]
						{
							TypeReference.Lift(e)
						});
                            Expression expression23 = arg_B07_0.Target = genericReferenceExpression7;
                            this.ReplaceCurrentNode(methodInvocationExpression9);
                            return;
                        }
                    }
                }
            }
            if (node is MethodInvocationExpression && true && node.Target is ReferenceExpression)
            {
                ReferenceExpression referenceExpression9 = (ReferenceExpression)node.Target;
                if (true && referenceExpression9.Name == "GetComponentInChildren" && 1 == ((ICollection)node.Arguments).Count && node.Arguments[0] is ReferenceExpression)
                {
                    ReferenceExpression e = (ReferenceExpression)node.Arguments[0];
                    if (true)
                    {
                        MethodInvocationExpression methodInvocationExpression10 = new MethodInvocationExpression(LexicalInfo.Empty);
                        MethodInvocationExpression arg_C28_0 = methodInvocationExpression10;
                        GenericReferenceExpression genericReferenceExpression8 = new GenericReferenceExpression(LexicalInfo.Empty);
                        GenericReferenceExpression arg_BF9_0 = genericReferenceExpression8;
                        ReferenceExpression referenceExpression10 = new ReferenceExpression(LexicalInfo.Empty);
                        string text10 = referenceExpression10.Name = "GetComponentInChildren";
                        Expression expression24 = arg_BF9_0.Target = referenceExpression10;
                        TypeReferenceCollection typeReferenceCollection8 = genericReferenceExpression8.GenericArguments = TypeReferenceCollection.FromArray(new TypeReference[]
					{
						TypeReference.Lift(e)
					});
                        Expression expression25 = arg_C28_0.Target = genericReferenceExpression8;
                        this.ReplaceCurrentNode(methodInvocationExpression10);
                        return;
                    }
                }
            }
            if (node is MethodInvocationExpression && true && node.Target is MemberReferenceExpression)
            {
                MemberReferenceExpression memberReferenceExpression11 = (MemberReferenceExpression)node.Target;
                if (true)
                {
                    Expression target = memberReferenceExpression11.Target;
                    if (true && memberReferenceExpression11.Name == "AddComponent" && 1 == ((ICollection)node.Arguments).Count && node.Arguments[0] is StringLiteralExpression)
                    {
                        StringLiteralExpression stringLiteralExpression3 = (StringLiteralExpression)node.Arguments[0];
                        if (true)
                        {
                            string value = stringLiteralExpression3.Value;
                            if (true)
                            {
                                if (!this.isBinaryExp)
                                {
                                    MethodInvocationExpression methodInvocationExpression11 = new MethodInvocationExpression(LexicalInfo.Empty);
                                    MethodInvocationExpression arg_D49_0 = methodInvocationExpression11;
                                    MemberReferenceExpression memberReferenceExpression12 = new MemberReferenceExpression(LexicalInfo.Empty);
                                    string text11 = memberReferenceExpression12.Name = "AddComponent";
                                    Expression expression26 = memberReferenceExpression12.Target = Expression.Lift(target);
                                    Expression expression27 = arg_D49_0.Target = memberReferenceExpression12;
                                    ExpressionCollection expressionCollection3 = methodInvocationExpression11.Arguments = ExpressionCollection.FromArray(new Expression[]
								{
									Expression.Lift(value)
								});
                                    this.ReplaceCurrentNode(methodInvocationExpression11);
                                    this.isBinaryExp = false;
                                }
                                return;
                            }
                        }
                    }
                }
            }
            if (node is MethodInvocationExpression && true && node.Target is ReferenceExpression)
            {
                ReferenceExpression referenceExpression11 = (ReferenceExpression)node.Target;
                if (true && referenceExpression11.Name == "AddComponent" && 1 == ((ICollection)node.Arguments).Count && node.Arguments[0] is StringLiteralExpression)
                {
                    StringLiteralExpression stringLiteralExpression4 = (StringLiteralExpression)node.Arguments[0];
                    if (true)
                    {
                        string value = stringLiteralExpression4.Value;
                        if (true)
                        {
                            if (!this.isBinaryExp)
                            {
                                MethodInvocationExpression methodInvocationExpression12 = new MethodInvocationExpression(LexicalInfo.Empty);
                                MethodInvocationExpression arg_E70_0 = methodInvocationExpression12;
                                ReferenceExpression referenceExpression12 = new ReferenceExpression(LexicalInfo.Empty);
                                string text12 = referenceExpression12.Name = "AddComponent";
                                Expression expression28 = arg_E70_0.Target = referenceExpression12;
                                ExpressionCollection expressionCollection4 = methodInvocationExpression12.Arguments = ExpressionCollection.FromArray(new Expression[]
							{
								Expression.Lift(value)
							});
                                this.ReplaceCurrentNode(methodInvocationExpression12);
                                this.isBinaryExp = false;
                            }
                            return;
                        }
                    }
                }
            }
            if (node is MethodInvocationExpression && true && node.Target is MemberReferenceExpression)
            {
                MemberReferenceExpression memberReferenceExpression13 = (MemberReferenceExpression)node.Target;
                if (true)
                {
                    Expression target = memberReferenceExpression13.Target;
                    if (true && memberReferenceExpression13.Name == "AddComponent" && 1 == ((ICollection)node.Arguments).Count && node.Arguments[0] is ReferenceExpression)
                    {
                        ReferenceExpression e = (ReferenceExpression)node.Arguments[0];
                        if (true)
                        {
                            MethodInvocationExpression methodInvocationExpression13 = new MethodInvocationExpression(LexicalInfo.Empty);
                            MethodInvocationExpression arg_FDD_0 = methodInvocationExpression13;
                            GenericReferenceExpression genericReferenceExpression9 = new GenericReferenceExpression(LexicalInfo.Empty);
                            GenericReferenceExpression arg_FAE_0 = genericReferenceExpression9;
                            MemberReferenceExpression memberReferenceExpression14 = new MemberReferenceExpression(LexicalInfo.Empty);
                            string text13 = memberReferenceExpression14.Name = "AddComponent";
                            Expression expression29 = memberReferenceExpression14.Target = Expression.Lift(target);
                            Expression expression30 = arg_FAE_0.Target = memberReferenceExpression14;
                            TypeReferenceCollection typeReferenceCollection9 = genericReferenceExpression9.GenericArguments = TypeReferenceCollection.FromArray(new TypeReference[]
						{
							TypeReference.Lift(e)
						});
                            Expression expression31 = arg_FDD_0.Target = genericReferenceExpression9;
                            this.ReplaceCurrentNode(methodInvocationExpression13);
                            return;
                        }
                    }
                }
            }
            if (node is MethodInvocationExpression && true && node.Target is ReferenceExpression)
            {
                ReferenceExpression referenceExpression13 = (ReferenceExpression)node.Target;
                if (true && referenceExpression13.Name == "AddComponent" && 1 == ((ICollection)node.Arguments).Count && node.Arguments[0] is ReferenceExpression)
                {
                    ReferenceExpression e = (ReferenceExpression)node.Arguments[0];
                    if (true)
                    {
                        MethodInvocationExpression methodInvocationExpression14 = new MethodInvocationExpression(LexicalInfo.Empty);
                        MethodInvocationExpression arg_10FE_0 = methodInvocationExpression14;
                        GenericReferenceExpression genericReferenceExpression10 = new GenericReferenceExpression(LexicalInfo.Empty);
                        GenericReferenceExpression arg_10CF_0 = genericReferenceExpression10;
                        ReferenceExpression referenceExpression14 = new ReferenceExpression(LexicalInfo.Empty);
                        string text14 = referenceExpression14.Name = "AddComponent";
                        Expression expression32 = arg_10CF_0.Target = referenceExpression14;
                        TypeReferenceCollection typeReferenceCollection10 = genericReferenceExpression10.GenericArguments = TypeReferenceCollection.FromArray(new TypeReference[]
					{
						TypeReference.Lift(e)
					});
                        Expression expression33 = arg_10FE_0.Target = genericReferenceExpression10;
                        this.ReplaceCurrentNode(methodInvocationExpression14);
                        return;
                    }
                }
            }
            if (node is MethodInvocationExpression && true && node.Target is ReferenceExpression)
            {
                ReferenceExpression referenceExpression15 = (ReferenceExpression)node.Target;
                if (true && referenceExpression15.Name == "Instantiate" && 3 == ((ICollection)node.Arguments).Count)
                {
                    Expression expression34 = node.Arguments[0];
                    if (true)
                    {
                        Expression expression35 = node.Arguments[1];
                        if (true)
                        {
                            expression35 = node.Arguments[2];
                            if (true)
                            {
                                IType expressionType = expression34.ExpressionType;
                                if (expressionType != null)
                                {
                                    TryCastExpression tryCastExpression3 = new TryCastExpression(LexicalInfo.Empty);
                                    Expression expression36 = tryCastExpression3.Target = Expression.Lift(node);
                                    TypeReference typeReference3 = tryCastExpression3.Type = TypeReference.Lift(this.CodeBuilder.CreateTypeReference(expressionType));
                                    this.ReplaceCurrentNode(tryCastExpression3);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}