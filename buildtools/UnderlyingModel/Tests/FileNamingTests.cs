using System.Collections.Generic;
using NUnit.Framework;

namespace UnderlyingModel.Tests
{
	[TestFixture]
	public class FileNamingTests
	{

		[Test]
		public void BasicFunctionNoModifiers()
		{
			const string memberSignature = "Touch GetSecondaryTouch (int index)";
			const string expectedMemberName = "GetSecondaryTouch_int";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
        public void BasicFunctionWithModifiers()
		{
			const string memberSignature = "static Touch GetSecondaryTouch (int index)";
			const string expectedMemberName = "GetSecondaryTouch_int";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void BasicFunctionRefOutParams()
		{
			const string memberSignature = "static Touch GetSecondaryTouch (ref int index, out float f)";
			const string expectedMemberName = "GetSecondaryTouch_int_float";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}
		
		[Test]
		public void BasicFunctionNoArgs()
		{
			const string memberSignature = "Touch GetSecondaryTouch ()";
			const string expectedMemberName = "GetSecondaryTouch";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void BasicFunctionNoArgsExtraSpace()
		{
			const string memberSignature = "Touch GetSecondaryTouch ( )";
			const string expectedMemberName = "GetSecondaryTouch";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void DestructorFromTxtNoArgs()
		{
			const string memberSignature = "~Vector3()";
			const string expectedMemberName = "dtor";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void ConstructorFromTxtNoArgs()
		{
			const string memberSignature = "Vector3()";
			const string expectedMemberName = "ctor";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void ConstructorFromTxt3Args()
		{
			const string memberSignature = "Vector3(float a, float b, float c)";
			const string expectedMemberName = "ctor_float_float_float";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void ConstructorFromTxt3ArgsSimplified()
		{
			const string memberSignature = "Vector3(float a, float b, float c)";
			const string expectedMemberName = "ctor";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature, true);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void ConstructorFromAssemblyNoArgs()
		{
			const string memberSignature = "Void .ctor()";
			const string expectedMemberName = "ctor";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}
		
		[Test]
		public void ConstructorFromAssembly1Arg()
		{
			const string memberSignature = "Void .ctor(String)";
			const string expectedMemberName = "ctor_string";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void ConstructorFromAssemblyReduceArgs()
		{
			const string memberSignature = "Void .ctor(String, Boolean, System.Int32)";
			const string expectedMemberName = "ctor_string_bool_int";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void ConstructorFromAssembly2Args()
		{
			const string memberSignature = "Void .ctor(int, float)";
			const string expectedMemberName = "ctor_int_float";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void ConstructorFromAssemblyArr()
		{
			const string memberSignature = "Void .ctor(System.String, Byte[])";
			const string expectedMemberName = "ctor_string_byteArray";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}


		[Test]
		public void ConstructorFromAssemblyComplicated()
		{
			const string memberSignature = "Void .ctor(System.String, System.String, UnityEngine.Texture2D, System.String, System.String, Boolean, Int32)";
			const string expectedMemberName = "ctor_string_string_Texture2D_string_string_bool_int";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}


		[Test]
		public void ReducePrimitivesInt32()
		{
			const string memberSignature = "Touch GetSecondaryTouch (Int32 index)";
			const string expectedMemberName = "GetSecondaryTouch_int";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void ReducePrimitivesFloat()
		{
			const string memberSignature = "Touch GetSecondaryTouch (System.Float)";
			const string expectedMemberName = "GetSecondaryTouch_float";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void ReducePrimitivesDouble()
		{
			const string memberSignature = "Touch GetSecondaryTouch (System.Double)";
			const string expectedMemberName = "GetSecondaryTouch_double";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void ReducePrimitivesSingle()
		{
			const string memberSignature = "Touch GetSecondaryTouch (System.Single)";
			const string expectedMemberName = "GetSecondaryTouch_float";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void ReducePrimitivesObject()
		{
			const string memberSignature = "Object GetSecondaryTouch (System.Object index)";
			const string expectedMemberName = "GetSecondaryTouch_object";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void ReducePrimitivesUnityEngineObject()
		{
			const string memberSignature = "Object GetSecondaryTouch (UnityEngine.Object index)";
			const string expectedMemberName = "GetSecondaryTouch_object";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void ReducePrimitivesStringArray()
		{
			const string memberSignature = "Touch GetSecondaryTouch (String[] arr)";
			const string expectedMemberName = "GetSecondaryTouch_stringArray";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void ReducePrimitivesObjectArray()
		{
			const string memberSignature = "Touch GetSecondaryTouch (Object[] arr)";
			const string expectedMemberName = "GetSecondaryTouch_objectArray";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void ReducePrimitivesByte()
		{
			const string memberSignature = "Touch GetSecondaryTouch (System.Byte)";
			const string expectedMemberName = "GetSecondaryTouch_byte";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void GenericFunction()
		{
			const string memberSignature = "FieldType Get<FieldType>(string fieldName)";
			const string expectedMemberName = "Get_FieldType__string";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void SimpleDelegate()
		{
			const string memberSignature = "public delegate void AndroidJavaRunnable();";
			const string expectedMemberName = "AndroidJavaRunnable";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

        [Test]
        public void AutoProp()
        {
            const string codeContent = "Matrix4x4 worldToLocalMatrix GetWorldToLocalMatrix";
            var memberName = MemberNameGenerator.GetUniqueMemberID(codeContent, TypeKind.AutoProp);
            const string expectedMemberName = "_worldToLocalMatrix";
            Assert.AreEqual(expectedMemberName, memberName);
        }

        [Test]
        public void AutoPropPtr()
        {
            const string codeContent = "Transform parent GetParent SetParent";
            var memberName = MemberNameGenerator.GetUniqueMemberID(codeContent, TypeKind.AutoProp);
            const string expectedMemberName = "_parent";
            Assert.AreEqual(expectedMemberName, memberName);
        }

		[Test]
		public void NameWithTab()
		{
			const string codeContent = "void					RemoveStateMachine(StateMachine	stateMachine)";
			var memberName = MemberNameGenerator.GetMemberNameFromPureSignature(codeContent);
			const string expectedMemberName = "RemoveStateMachine_StateMachine";
			Assert.AreEqual(expectedMemberName, memberName);
		}

	    [Test]
		public void SimplePropertyLowercase()
		{
			const string memberSignature = "static int touchCountSecondary";
			const string expectedMemberName = "_touchCountSecondary";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		
		[Test]
		public void ConstructorWithObjectArray()
		{
			const string memberSignature = "public AndroidJavaObject(string className, params object[] args)";
			const string expectedMemberName = "ctor_string_objectArray";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void FunctionWithObjectArray()
		{
			const string memberSignature = "public void Foo(string className, params object[] args)";
			const string expectedMemberName = "Foo_string_objectArray";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void FunctionWithObjectArraySimple()
		{
			const string memberSignature = "public void Foo(string className, params object[] args)";
			const string expectedMemberName = "Foo";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature, true);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}
		

		[Test]
		public void FunctionArrayArgument()
		{
			const string memberSignature = "public void Fun(float[] args)";
			const string expectedMemberName = "Fun_floatArray";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void FunctionArrayArgumentWithoutParam()
		{
			const string memberSignature = "public void Fun(float[])";
			const string expectedMemberName = "Fun_floatArray";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void SimpleArgumentWithoutParam()
		{
			const string memberSignature = "public void Fun(float)";
			const string expectedMemberName = "Fun_float";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void FunctionWith2DArray()
		{
			const string memberSignature = "void SetHeights (int xBase, int yBase, float[,] heights)";
			const string expectedMemberName = "SetHeights_int_int_floatArray";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void FunctionWith3DArray()
		{
			const string memberSignature = "void SetAlphaMaps (int x, int y, float[,,] map)";
			const string expectedMemberName = "SetAlphaMaps_int_int_floatArray";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		/// <summary>
		/// this is to make sure we strip the initializer
		/// </summary>
		[Test]
		public void FunctionWithObjectArrayAndInitizer()
		{
			const string memberSignature = "public bool Foo(string className, params object[] args) : this()";
			const string expectedMemberName = "Foo_string_objectArray";
			var actualMemberFileName = MemberNameGenerator.GetMemberNameFromPureSignature(memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

		[Test]
		public void BasicFunctionWithType()
		{
			const string type = "TouchyFeely";
			const string memberSignature = "Touch GetSecondaryTouch (int index)";
			const string expectedMemberName = "TouchyFeely.GetSecondaryTouch_int";
			Stack<string> typeStack = TypeStackFromOneType(type);
			var actualMemberFileName = MemberNameGenerator.PureNameWithTypeStack(memberSignature, TypeKind.PureSignature, typeStack); //GetMemberNameFromTypeAndSignature(type, memberSignature);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);  
		}

		[Test]
		public void BasicFunctionWithEmptyType()
		{
			const string type = "";
			const string memberSignature = "Touch GetSecondaryTouch (int index)";
			const string expectedMemberName = "GetSecondaryTouch_int";
			Stack<string> typeStack = TypeStackFromOneType(type);
			var actualMemberFileName = MemberNameGenerator.PureNameWithTypeStack(memberSignature, TypeKind.PureSignature, typeStack);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
		}

        [Test]
        [Ignore ("the problem may be that this is not a function we need to parse")]
        public void ComplexFunction()
        {
            const string type = "";
			const string memberSignature = "TrackedReferenceBaseToScriptingObject_GetAnimationEvent(self)->stateSender_animationState";
			const string expectedMemberName = "GetSecondaryTouch_int";
			Stack<string> typeStack = TypeStackFromOneType(type);
			var actualMemberFileName = MemberNameGenerator.PureNameWithTypeStack(memberSignature, TypeKind.PureSignature, typeStack);
			Assert.AreEqual(expectedMemberName, actualMemberFileName);
        }

		private static Stack<string> TypeStackFromOneType(string sType)
		{
			var typeStack = new Stack<string>();
			if (!sType.IsEmpty())
				typeStack.Push(sType);
			return typeStack;
		}
	}
}
