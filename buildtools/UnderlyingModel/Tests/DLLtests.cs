using System.Linq;
using NUnit.Framework;

namespace UnderlyingModel.Tests
{
	[TestFixture]
	public class DLLtests
	{
		AssemblyDataItemSet _assemblyDataItemSet = null;		
		//readonly AssemblyLocation _assemblyLocation = new AssemblyLocation {name = "Test", engineDllPath = DirectoryUtil.EngineDllLocation, editorDllPath = DirectoryUtil.EditorDllLocation};
		
		[TestFixtureSetUp]
		public void Init()
		{
			_assemblyDataItemSet = AssemblyDataBuilder.BuildAssemblyDataItemsMonoCecil();
			Assert.IsNotNull(_assemblyDataItemSet);
		}
		
		[Test]
		public void EngineDLLHasSomething()
		{
			Assert.IsTrue(_assemblyDataItemSet.EngineAssemblySize > 0);
		}
		
		[Test]
		public void EditorDLLHasSomething()
		{
			Assert.IsTrue(_assemblyDataItemSet.EditorAssemblySize > 0);
		}
		
		[Test]
		public void AccelerationEventClassInAssembly()
		{
			VerifyPresentInAssembly("AccelerationEvent");
		}
		
		[Test]
		public void AccelerationEventPropertyInAssembly()
		{
			VerifyPresentInAssembly("AccelerationEvent._deltaTime");
		}

		[Test]
		public void AccelerationEventNoPrivatePropertyInAssembly()
		{
			VerifyAbsentFromAssembly("AccelerationEvent._m_TimeDelta");
		}

		[Test]
		public void AndroidJavaObjectNoPrivatePropertyInAssembly()
		{
			VerifyAbsentFromAssembly("AndroidJavaObject._m_jobject");
		}

		[Test]
		public void AndroidJavaObjectSetNoArgsNotInAssembly()
		{
			VerifyAbsentFromAssembly("AndroidJavaObject.Set");
		}

		[Test]
		public void AndroidJavaObjectSetWithoutGenericsNotInAssembly()
		{
			VerifyAbsentFromAssembly("AndroidJavaObject.Set_string_FieldType");
		}

		[Test]
		public void AndroidJavaObjectSetGenericInAssembly()
		{
			VerifyPresentInAssembly("AndroidJavaObject.Set_FieldType__string_FieldType");
		}
		
		[Test]
		public void AndroidClassInAssembly()
		{
			VerifyPresentInAssembly("PlayerSettings.Android");
		}
		
		[Test]
		public void AndroidPropertyInAssembly()
		{
			VerifyPresentInAssembly("PlayerSettings.Android._bundleVersionCode");
		}

		[Test]
		public void ColorConstructorInAssembly()
		{
			VerifyPresentInAssembly("Color.ctor_float_float_float");
		}

		[Test]
		public void ColorFieldInAssembly()
		{
			VerifyPresentInAssembly("Color._g");
		}

		[Test]
		public void EnumInAssembly()
		{
			VerifyPresentInAssembly("ADErrorCode");
		}

		[Test]
		public void EnumMemberInAssembly()
		{
			VerifyPresentInAssembly("ADErrorCode.ServerFailure");
		}

		[Test]
		public void AndroidInputMethodInAssembly()
		{
			VerifyPresentInAssembly("AndroidInput.GetSecondaryTouch_int");
		}

		[Test]
		public void AnimationMethodInAssembly()
		{
			VerifyPresentInAssembly("Animation.AddClip_AnimationClip_string_int_int");
		}

		[Test]
		public void ConstructorWithArrayInAssembly()
		{
			VerifyPresentInAssembly("AndroidJavaObject.ctor_string_objectArray");
		}

		[Test]
		public void ArgumentlessMethodInAssembly()
		{
			VerifyPresentInAssembly("AndroidJavaObject.Dispose");
		}

		[Test]
		public void MethodFromEditorInAssembly()
		{
			VerifyPresentInAssembly("EditorGUIUtility.SetIconSize_Vector2");
		}

		[Test]
		public void AnotherMethodFromEditorInAssembly()
		{
			VerifyPresentInAssembly("EditorGUI.DropShadowLabel_Rect_string");
		}

		[Test]
		public void GenericMethodInAssembly()
		{
			VerifyPresentInAssembly("AndroidJavaObject.Set_FieldType__string_FieldType");
		}

		[Test]
		public void OperatorBinaryMinusPresent()
		{
			VerifyPresentInAssembly("Vector2.Minus_Vector2_Vector2");
		}

		[Test]
		public void OperatorUnaryMinusPresent()
		{
			VerifyPresentInAssembly("Vector2.Minus_Vector2");
		}

		[Test]
		public void OperatorEqualPresent()
		{
			VerifyPresentInAssembly("Vector2.Equal_Vector2_Vector2");
		}

		[Test]
		public void OperatorNotEqualPresent()
		{
			VerifyPresentInAssembly("Vector2.NotEqual_Vector2_Vector2");
		}

		[Test]
		public void OperatorPlusPresent()
		{
			VerifyPresentInAssembly("Vector2.Plus_Vector2_Vector2");
		}

		[Test]
		public void OperatorMultiplylPresent()
		{
			VerifyPresentInAssembly("Vector2.Multiply_Vector2_float");
		}


		[Test]
		public void OperatorDividePresent()
		{
			VerifyPresentInAssembly("Vector2.Divide_Vector2_float");
		}

		[Test]
		public void ImplOpPresent()
		{
			VerifyPresentInAssembly("LayerMask.implop_int_LayerMask");
		}

		[Test]
		public void ImplOp2Present()
		{
			VerifyPresentInAssembly("LayerMask.implop_LayerMask_int");
		}

		[Test]
		public void SdkVersionsPresent()
		{
			VerifyPresentInAssembly("AndroidSdkVersions");
		}

		[Test]
		public void iOSTargetVersionsEnumPresent()
		{
			VerifyPresentInAssembly("iOSTargetOSVersion");
		}

		[Test]
		public void iOSTargetVersionsEnumMemberPresent()
		{
			VerifyPresentInAssembly("iOSTargetOSVersion._iOS_4_0");
		}

		[Test]
		public void iOSTargetVersionsWrongEnumMemberAbsent()
		{
			VerifyAbsentFromAssembly("iOSTargetOSVersion.iOS_4_0");
		}

		[Test]
		public void SdkVersionsMemberPresent()
		{
			VerifyPresentInAssembly("AndroidSdkVersions.AndroidApiLevel9");
		}
		

		private void VerifyPresentInAssembly(string st)
		{
			bool success = _assemblyDataItemSet.Items.Any(item => item.SimplifiedName.Equals(st));
			Assert.IsTrue(success);
		}

		private void VerifyAbsentFromAssembly(string st)
		{
			bool contains = _assemblyDataItemSet.Items.Any(item => item.SimplifiedName.Equals(st));
			Assert.IsFalse(contains);
		}
	}
}
