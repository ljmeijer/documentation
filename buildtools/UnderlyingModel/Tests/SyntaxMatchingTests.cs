using NUnit.Framework;

namespace UnderlyingModel.Tests
{
	[TestFixture]
	public class SyntaxMatchingTests
	{

		[Test]
		public void BasicMethod()
		{
			const string memberSignature = "Touch GetSecondaryTouch (int index)";
			RegexMatcher matcher;
			
			bool found = MemberNameGenerator.TryMatchSignature(memberSignature, out matcher);

			Assert.AreEqual(found, true);
			Assert.AreEqual(matcher.Name, "METHOD");
		}

		[Test]
		public void BasicConstructor()
		{
			const string memberSignature = "AndroidJavaRunnable()";
			RegexMatcher matcher;

			bool found = MemberNameGenerator.TryMatchSignature(memberSignature, out matcher);

			Assert.AreEqual(found, true);
			Assert.AreEqual(matcher.Name, "CONSTRUCTOR");
		}

		[Test]
		public void ConstructorAssemblyNoArgs()
		{
			const string memberSignature = "Void .ctor()";
			RegexMatcher matcher;

			bool found = MemberNameGenerator.TryMatchSignature(memberSignature, out matcher);

			Assert.AreEqual(found, true);
			Assert.AreEqual("CONSTRUCTOR_ASSEMBLY", matcher.Name);
		}

		[Test]
		public void ConstructorAssembly1Arg()
		{
			const string memberSignature = "Void .ctor(String)";
			RegexMatcher matcher;

			bool found = MemberNameGenerator.TryMatchSignature(memberSignature, out matcher);

			Assert.AreEqual(found, true);
			Assert.AreEqual("CONSTRUCTOR_ASSEMBLY", matcher.Name);
		}

		[Test]
		public void ConstructorAssembly2Args()
		{
			const string memberSignature = "Void .ctor(String, Boolean)";
			RegexMatcher matcher;

			bool found = MemberNameGenerator.TryMatchSignature(memberSignature, out matcher);

			Assert.AreEqual(found, true);
			Assert.AreEqual("CONSTRUCTOR_ASSEMBLY", matcher.Name);
		}

		[Test]
		public void ConstructorAssembly3Args()
		{
			const string memberSignature = "Void .ctor(String, Boolean, Int32)";
			RegexMatcher matcher;

			bool found = MemberNameGenerator.TryMatchSignature(memberSignature, out matcher);

			Assert.AreEqual(found, true);
			Assert.AreEqual("CONSTRUCTOR_ASSEMBLY", matcher.Name);
		}

		[Test]
		public void ConstructorAssembly1ArgSystem()
		{
			const string memberSignature = "Void .ctor(System.String)";
			RegexMatcher matcher;

			bool found = MemberNameGenerator.TryMatchSignature(memberSignature, out matcher);

			Assert.AreEqual(found, true);
			Assert.AreEqual("CONSTRUCTOR_ASSEMBLY", matcher.Name);
		}

		[Test]
		public void ConstructorAssembly2ArgSystem()
		{
			const string memberSignature = "Void .ctor(System.String, System.Int32)";
			RegexMatcher matcher;

			bool found = MemberNameGenerator.TryMatchSignature(memberSignature, out matcher);

			Assert.AreEqual(found, true);
			Assert.AreEqual("CONSTRUCTOR_ASSEMBLY", matcher.Name);
		}

		[Test]
		public void ConstructorAssemblyArray1stParam()
		{
			const string memberSignature = "Void .ctor(int[])";
			RegexMatcher matcher;

			bool found = MemberNameGenerator.TryMatchSignature(memberSignature, out matcher);

			Assert.AreEqual(found, true);
			Assert.AreEqual("CONSTRUCTOR_ASSEMBLY", matcher.Name);
		}

		[Test]
		public void ConstructorAssemblyArray2ndParam()
		{
			const string memberSignature = "Void .ctor(System.String, Byte[])";
			RegexMatcher matcher;

			bool found = MemberNameGenerator.TryMatchSignature(memberSignature, out matcher);

			Assert.AreEqual(found, true);
			Assert.AreEqual("CONSTRUCTOR_ASSEMBLY", matcher.Name);
		}

		[Test]
		public void EnumEntryAssignment()
		{
			const string memberSignature = "White = 0,";
			RegexMatcher matcher;

			bool found = MemberNameGenerator.TryMatchSignature(memberSignature, out matcher);

			Assert.AreEqual(found, true);
			Assert.AreEqual(matcher.Name, "ENUM_ENTRY");
		}
	}

}
