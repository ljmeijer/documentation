using NUnit.Framework;

namespace UnderlyingModel.Tests
{
	[TestFixture]
	public class MemberDocReverseTests
	{
        [Test]
        public void EmptyMember()
        {
        	VerifyReassembly("");
        }

		[Test]
		public void MemberWithOnlySummary()
		{
			VerifyReassembly("This is our summary");
		}

		[Test]
		public void MemberWithSummaryAndDescription()
		{
			VerifyReassembly(@"This is our summary
Some more text");
		}

		[Test]
		public void MemberWithSummaryAndMultilineDescription()
		{
			VerifyReassembly(@"This is our summary
Some more text
Even more text");
		}

		[Test]
		public void MemberWithSummaryAndOneExample()
		{
			VerifyReassembly(@"This is our summary
BEGIN EX
	function foo()
	{ int k=0;}
END EX");
		}

		[Test]
		public void MemberWithSummaryAndOneConvertExample()
		{
			VerifyReassembly(@"This is our summary
CONVERTEXAMPLE
BEGIN EX
	function foo()
	{ int k=0;}
END EX");
		}

		[Test]
		public void MemberWithSummaryAndOneNoCheckExample()
		{
			VerifyReassembly(@"This is our summary
BEGIN EX NOCHECK
	function foo()
	{ int k=0;}
END EX");
		}

		[Test]
		public void MemberWithSummaryDescriptionAndOneExample()
		{
			VerifyReassembly(@"This is our summary
hello hello
BEGIN EX
	function foo()
	{ int k=0;}
END EX");
		}


		[Test]
		public void MemberWithSummaryDescriptionAfterOneExample()
		{
			VerifyReassembly(@"This is our summary
BEGIN EX
	function foo()
	{ int k=0;}
END EX
hello hello");
		}

		[Test]
		public void MemberWithSummaryAndParam()
		{
			VerifyReassembly(@"This is our summary
@param label Label in front of the label field");
		}

		[Test]
		public void MemberWithSummaryAndMultilineParam()
		{
			VerifyReassembly(@"This is our summary
@param label Label in 
front of the label field");
		}

		[Test]
		public void MemberWithSummaryAndReturn()
		{
			VerifyReassembly(@"This is our summary
@return stupid stuff");
		}

		[Test]
		public void MemberWithSignaturesSummaryOneExample()
		{
			VerifyReassembly(@"<signature>
sig1
sig2
</signature>
This is our summary
BEGIN EX
	function foo()
	{ int k=0;}
END EX");
		}

		[Test]
		public void MemberWith2MeaningfulBlocks()
		{
			VerifyReassembly(@"<signature>
sig1
sig2
</signature>
This is our summary
BEGIN EX
	function foo()
	{ int k=0;}
END EX
<signature>
sig3
sig4
</signature>
Summary for 2nd block
");
		}


		[Test]
		public void ModifyReturnValue()
		{
			const string input = @"This is our summary
@return stupid stuff";
			var model = new MeaningfulBlock(input);

			Assert.AreEqual("This is our summary", model.Summary);
			Assert.AreEqual("stupid stuff", model.ReturnDoc.Doc);

			model.ReturnDoc.Doc = "smart stuff";
			
			var actualOutput = model.ToString();
			Assert.AreEqual(@"This is our summary
@return smart stuff", actualOutput);
		}

		private static void VerifyReassembly(string inputString)
		{
			var expectedModel = new MemDocModel(inputString);
			Assert.AreEqual(inputString.TrimEndAndNewlines(), expectedModel.ToString().TrimEndAndNewlines());
		}
	}
}
