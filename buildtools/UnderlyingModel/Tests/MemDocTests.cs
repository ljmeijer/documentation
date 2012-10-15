using NUnit.Framework;

namespace UnderlyingModel.Tests
{
	[TestFixture]
	public class MemDocTests
	{
		[Test]
		public void MemberWithOnlySummary()
		{
			const string inputString = "This is our summary";
			var derivedModel = new MemDocModel(inputString);
			Assert.AreEqual(inputString, derivedModel.Summary);
			Assert.AreEqual(0, derivedModel.TextBlocks.Count);
			Assert.AreEqual(0, derivedModel.Parameters.Count);
			Assert.AreEqual(0, derivedModel.SignatureList.Count);
		}

		[Test]
		public void MemberWithSignatureListAndSummary()
		{
			const string inputString = ParserToken.SignatureOpen + @"
sig1
sig2
sig3
sig4
" + ParserToken.SignatureClose + @"
Summary for all sigs";
			var derivedModel = new MemDocModel(inputString);
			Assert.AreEqual("Summary for all sigs", derivedModel.Summary);
			Assert.AreEqual(0, derivedModel.TextBlocks.Count);
			Assert.AreEqual(0, derivedModel.Parameters.Count);
			Assert.AreEqual(4, derivedModel.SignatureList.Count);
		}

		[Test]
		public void MemberWith2MeaningfulBlocks()
		{
			const string inputString = ParserToken.SignatureOpen + @"
sig1
sig2
" + ParserToken.SignatureClose + @"
Summary for first sigs
"+ParserToken.SignatureOpen + @"
sig3
sig4
" + ParserToken.SignatureClose + @"
Summary for second sigs
";
			var derivedModel = new MemDocModel(inputString);
			Assert.AreEqual(2, derivedModel.MeaningfulBlocks.Count);
			Assert.AreEqual("Summary for first sigs", derivedModel.MeaningfulBlocks[0].Summary);
			Assert.AreEqual("Summary for second sigs", derivedModel.MeaningfulBlocks[1].Summary);
		}
	}
}
