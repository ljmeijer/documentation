using NUnit.Framework;

namespace UnderlyingModel.Tests
{
	[TestFixture]
	public class OperatorNamingTests
	{	
		[Test]
		public void OperatorEquals()
		{
			const string memberSignature = "bool operator == (BoneWeight lhs, BoneWeight rhs)";
			const string expectedMemberName = "Equal_BoneWeight_BoneWeight";
            VerifySignature(memberSignature, expectedMemberName);
		}

		[Test]
		public void OperatorNotEquals()
		{
			const string memberSignature = "public static bool operator != (BoneWeight lhs, BoneWeight rhs)";
			const string expectedMemberName = "NotEqual_BoneWeight_BoneWeight";
            VerifySignature(memberSignature, expectedMemberName);
        }
		
		[Test]
		public void OperatorMultiply()
		{
			const string memberSignature = "static public Vector4 operator * (Matrix4x4 lhs, Vector4 v)";
			const string expectedMemberName = "Times_Matrix4x4_Vector4";
            VerifySignature(memberSignature, expectedMemberName);
		}

		[Test]
		public void OperatorDivide()
		{
			const string memberSignature = "Vector2 operator / (Vector2 a, float d)";
			const string expectedMemberName = "Divide_Vector2_float";
            VerifySignature(memberSignature, expectedMemberName);
		}

		[Test]
		public void OperatorPlus()
		{
			const string memberSignature = "Vector2 operator + (Vector2 a, Vector2 b)";
			const string expectedMemberName = "Plus_Vector2_Vector2";
            VerifySignature(memberSignature, expectedMemberName);
		}

		[Test]
		public void OperatorMinus()
		{
			const string memberSignature = "Vector2 operator - (Vector2 a, Vector2 b)";
			const string expectedMemberName = "Minus_Vector2_Vector2";
            VerifySignature(memberSignature, expectedMemberName);
		}

        [Test]
        public void OperatorPlusFromAssembly()
        {
            const string memberSignature = "UnityEngine.Vector2 op_Addition(UnityEngine.Vector2, UnityEngine.Vector2)";
            const string expectedMemberName = "Plus_Vector2_Vector2";

            VerifySignature(memberSignature, expectedMemberName);
        }
         
        [Test]
        public void OperatorMinusFromAssembly()
        {
            const string memberSignature = "UnityEngine.Vector2 op_Subtraction(UnityEngine.Vector2, UnityEngine.Vector2)";
            const string expectedMemberName = "Minus_Vector2_Vector2";

            VerifySignature(memberSignature, expectedMemberName);
        }

        [Test]
        public void OperatorUnaryNegation()
        {
            const string memberSignature = "UnityEngine.Vector2 op_UnaryNegation(UnityEngine.Vector2)";
            const string expectedMemberName = "Minus_Vector2";
            VerifySignature(memberSignature, expectedMemberName);
        }

        [Test]
        public void OperatorEqualsFromAssembly()
        {
            const string memberSignature = "Boolean op_Equality(UnityEngine.Vector2, UnityEngine.Vector2)";
            const string expectedMemberName = "Equal_Vector2_Vector2";
            VerifySignature(memberSignature, expectedMemberName);
        }   

        [Test]
        public void OperatorNotEqualsFromAssembly()
        {
            const string memberSignature = "Boolean op_Inequality(UnityEngine.Vector2, UnityEngine.Vector2)";
            const string expectedMemberName = "NotEqual_Vector2_Vector2";
            VerifySignature(memberSignature, expectedMemberName);
        }   

         [Test]
        public void OperatorMultiplyFromAssembly()
        {
            const string memberSignature = "UnityEngine.Vector2 op_Multiply(UnityEngine.Vector2, Single)";
            const string expectedMemberName = "Multiply_Vector2_float";
            VerifySignature(memberSignature, expectedMemberName);
        }   

        [Test]
        public void OperatorDivideFromAssembly()
        {
            const string memberSignature = "UnityEngine.Vector2 op_Division(UnityEngine.Vector2, Single)";
            const string expectedMemberName = "Divide_Vector2_float";
            VerifySignature(memberSignature, expectedMemberName);
        }   

		[Test]
		public void ImplicitOperator()
		{
			const string memberSignature = "public static implicit operator Color32(Color c);";
			const string expectedMemberName = "implop_Color32_Color";
            VerifySignature(memberSignature, expectedMemberName);
		}

		[Test]
		public void ImplicitOperatorFromAssembly()
		{
			const string memberSignature = "UnityEngine.Color32 op_Implicit(UnityEngine.Color)";
			const string expectedMemberName = "implop_Color32_Color";
            VerifySignature(memberSignature, expectedMemberName);
		}

        private void VerifySignature(string memberSignature, string expectedMemberName)
        {
            var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
            Assert.AreEqual(expectedMemberName, actualMemberFileName);
        }
	}
}
