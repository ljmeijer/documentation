using NUnit.Framework;

namespace UnderlyingModel.Tests
{
	[TestFixture]
	public class MeaningfulBlockTests
	{
		[Test]
		public void EmptyMember()
		{
			const string inputString = "";
			var expectedModel = new MeaningfulBlock(inputString);
			Assert.IsTrue(expectedModel.IsEmpty());
		}

		[Test]
		public void MemberWithOnlySummary()
		{
			const string inputString = "This is our summary";
			var derivedModel = new MeaningfulBlock(inputString);
			Assert.AreEqual(inputString, derivedModel.Summary);
			Assert.AreEqual(0, derivedModel.TextBlocks.Count);
			Assert.AreEqual(0, derivedModel.Parameters.Count);
		}

		[Test, Timeout(5000)]
		public void MemberWithOnlyReturnValue()
		{
			const string inputString = "@return retval";
			var derivedModel = new MeaningfulBlock(inputString);
			Assert.IsNotNull(derivedModel.ReturnDoc);
			Assert.AreEqual("retval", derivedModel.ReturnDoc.Doc);
		}

		[Test]
		public void MemberWithSummaryAndDescription()
		{
			const string inputString = @"This is our summary
Some more text";
			var derivedModel = new MeaningfulBlock(inputString);
			Assert.AreEqual("This is our summary", derivedModel.Summary);
			Assert.AreEqual(1, derivedModel.TextBlocks.Count);
			Assert.AreEqual("Some more text", derivedModel.TextBlocks[0].Text);
		}

		[Test]
		public void MemberWithSummaryAndOneExample()
		{
			const string inputString = @"This is our summary
BEGIN EX
function foo()
{ int k=0;}
END EX";
			var derivedModel = new MeaningfulBlock(inputString);
			Assert.AreEqual("This is our summary", derivedModel.Summary);
			Assert.AreEqual(1, derivedModel.TextBlocks.Count);
			VerifyExample(derivedModel, 0, @"function foo()
{ int k=0;}
");
		}

		[Test]
		public void MemberWithSummaryDescriptionAndOneExample()
		{
			const string inputString = @"This is our summary
hello hello
BEGIN EX
	function foo()
	{ int k=0;}
END EX";
			var derivedModel = new MeaningfulBlock(inputString);
			Assert.AreEqual("This is our summary", derivedModel.Summary);
			Assert.AreEqual(2, derivedModel.TextBlocks.Count);


			VerifyDescription(derivedModel, 0, "hello hello");
			VerifyExample(derivedModel, 1, @"	function foo()
	{ int k=0;}
");
		}

		[Test]
		public void MemberWithSummaryDescriptionAndConvertExample()
		{
			const string inputString = @"This is our summary
hello hello
CONVERTEXAMPLE
BEGIN EX
	function foo()
	{ int k=0;}
END EX";
			var derivedModel = new MeaningfulBlock(inputString);
			Assert.AreEqual("This is our summary", derivedModel.Summary);
			Assert.AreEqual(2, derivedModel.TextBlocks.Count);

			VerifyExample(derivedModel, 1, @"	function foo()
	{ int k=0;}
");
			var example = derivedModel.TextBlocks[1] as ExampleBlock;
			Assert.IsTrue(example.IsConvertExample);
			Assert.IsFalse(example.IsNoCheck);
		}

		[Test]
		public void MemberWithSummaryDescriptionAndNoCheckExample()
		{
			const string inputString = @"This is our summary
hello hello
BEGIN EX NOCHECK
	function foo()
	{ int k=0;}
END EX";
			var derivedModel = new MeaningfulBlock(inputString);
			Assert.AreEqual("This is our summary", derivedModel.Summary);
			Assert.AreEqual(2, derivedModel.TextBlocks.Count);

			VerifyExample(derivedModel, 1, @"	function foo()
	{ int k=0;}
");
			var example = derivedModel.TextBlocks[1] as ExampleBlock;
			Assert.IsTrue(example.IsNoCheck);
			Assert.IsFalse(example.IsConvertExample);
		}

		[Test]
		public void MemberWithSummaryDescriptionAndNoCheckNextLine()
		{
			const string inputString = @"This is our summary
hello hello
BEGIN EX 
NOCHECK
	function foo()
	{ int k=0;}
END EX";
			var derivedModel = new MeaningfulBlock(inputString);
			Assert.AreEqual("This is our summary", derivedModel.Summary);
			Assert.AreEqual(2, derivedModel.TextBlocks.Count);

			VerifyExample(derivedModel, 1, @"	function foo()
	{ int k=0;}
");
			var example = derivedModel.TextBlocks[1] as ExampleBlock;
			Assert.IsTrue(example.IsNoCheck);
			Assert.IsFalse(example.IsConvertExample);
		}


		[Test]
		public void NoCheckFollowedByConvertExample()
		{
			const string inputString =
				@"This is our summary
	BEGIN EX NOCHECK
	 weight  name   layer   lower   upper
	END EX
	 Blend weights blah blah 
	CONVERTEXAMPLE
	BEGIN EX
		animation.weight = 0.5;
	END EX";
			var derivedModel = new MeaningfulBlock(inputString);
			Assert.AreEqual("This is our summary", derivedModel.Summary);
			Assert.AreEqual(3, derivedModel.TextBlocks.Count);

			var example1 = derivedModel.TextBlocks[0];
			
			Assert.IsTrue(example1 is ExampleBlock);
			Assert.IsTrue((example1 as ExampleBlock).IsNoCheck);
			VerifyExample(derivedModel, 0, @"	 weight  name   layer   lower   upper
");
			VerifyDescription(derivedModel, 1, @"	 Blend weights blah blah");

			var example2 = derivedModel.TextBlocks[2];
			Assert.IsTrue(example2 is ExampleBlock);
			Assert.IsFalse((example2 as ExampleBlock).IsNoCheck);
			VerifyExample(derivedModel, 2, @"		animation.weight = 0.5;
");
		}

		void VerifyExample(MeaningfulBlock model, int index, string expectedText)
		{
			Assert.IsTrue(model.TextBlocks[index] is ExampleBlock);
			Assert.AreEqual(expectedText, model.TextBlocks[index].Text);
		}

		void VerifyDescription(MeaningfulBlock model, int index, string expectedText)
		{
			Assert.IsFalse(model.TextBlocks[index] is ExampleBlock);
			Assert.AreEqual(expectedText, model.TextBlocks[index].Text);
		}

		[Test]
		public void MemberWithSummaryDescriptionAfterOneExample()
		{
			const string inputString = @"This is our summary
BEGIN EX
function foo()
{ int k=0;}
END EX
hello hello";
			var derivedModel = new MeaningfulBlock(inputString);
			Assert.AreEqual("This is our summary", derivedModel.Summary);
			Assert.AreEqual(2, derivedModel.TextBlocks.Count);

			VerifyExample(derivedModel, 0, @"function foo()
{ int k=0;}
");
			
			VerifyDescription(derivedModel, 1, "hello hello");	
		}

		[Test]
		public void MemberWithSummaryAndParam()
		{
			const string inputString = @"This is our summary
@param label Label in front of the label field";
			var derivedModel = new MeaningfulBlock(inputString);
			Assert.AreEqual("This is our summary",  derivedModel.Summary);
			Assert.AreEqual(1, derivedModel.Parameters.Count);
			Assert.IsTrue(derivedModel.Parameters[0].Equals("label", "Label in front of the label field"));
		}

		[Test]
		public void MemberWithSummaryAndMultilineParam()
		{
			const string inputString = @"This is our summary
@param label Label in 
front of the label field";
			var derivedModel = new MeaningfulBlock(inputString);
			Assert.AreEqual("This is our summary", derivedModel.Summary);
			Assert.AreEqual(1, derivedModel.Parameters.Count);
			Assert.IsTrue(derivedModel.Parameters[0].Equals("label", @"Label in 
front of the label field"));
			Assert.IsNull(derivedModel.ReturnDoc);
		}

		[Test]
		public void MemberWithSummaryAndReturn()
		{
			const string inputString = @"This is our summary
@return stupid stuff";
			var derivedModel = new MeaningfulBlock(inputString);
			Assert.AreEqual("This is our summary", derivedModel.Summary);
			Assert.AreEqual(0, derivedModel.Parameters.Count);
			Assert.AreEqual("stupid stuff", derivedModel.ReturnDoc.Doc);
		}

		[Test]
        [Timeout(10000)]
		public void MeaningfulBlockWithSignatures()
		{
			const string inputString = ParserToken.SignatureOpen+@"
sig1
sig2
sig3
sig4
"+ParserToken.SignatureClose+@"
Summary for all sigs";
			var derivedModel = new MeaningfulBlock(inputString);
			Assert.AreEqual("Summary for all sigs", derivedModel.Summary);
			Assert.AreEqual(0, derivedModel.TextBlocks.Count);
			Assert.AreEqual(0, derivedModel.Parameters.Count);
			Assert.AreEqual(4, derivedModel.SignatureList.Count);
		}
	}
}
