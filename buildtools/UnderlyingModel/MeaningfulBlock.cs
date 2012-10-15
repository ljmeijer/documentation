using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Collections.Generic;
using NUnit.Framework;

namespace UnderlyingModel
{
	//a collection of signatures which have a common description
	internal class MeaningfulBlock
	{
		//the list of signatures that all the docs for this block apply to
		public List<string> SignatureList;
	
		//union of all parameters for this meaningful block, derived from the signature list
		public List<ParameterWithDoc> Parameters { set; get; }

		//the return type for this meaningful block (there must be only 1 return type in such a block
		public ReturnWithDoc ReturnDoc { set; get; }


		public string Summary { set; get; }
		public List<TextBlock> TextBlocks { set; get; }

		//the state we get into when we get out of another and don't know any better
		private const MemFileState DefaultMemFileState = MemFileState.Description;


		public MeaningfulBlock(IDataItemOld memberData)
		{
			string memberDoc = null;
			DocumentDataItem docItem = memberData.GetDocumentDataItem();
			if (docItem != null)
				memberDoc = docItem.LoadEnglishDocument();

			Init(memberData.GetAssemblyDataItem(), memberDoc);
		}

		public MeaningfulBlock(IDataItemOld memberData, LanguageUtil.ELanguage language)
		{
			string memberDoc = null;
			DocumentDataItem docItem = memberData.GetDocumentDataItem();
			if (docItem != null)
				memberDoc = docItem.LoadDocumentOfLocale(language);

			Init(memberData.GetAssemblyDataItem(), memberDoc);
		}

		public MeaningfulBlock(string memberDoc)
		{
		    InitBasics();
		    ProcessDoc(memberDoc);
		}

		public MeaningfulBlock(AssemblyDataItem asmData, string memberDoc)
		{
			Init(asmData, memberDoc);
		}

		private void Init(AssemblyDataItem asmData, string memberDoc)
		{
			InitBasics();

			if (asmData != null)
				ProcessAsm(asmData);
			if (memberDoc != null)
				ProcessDoc(memberDoc);
		}

	    private void InitBasics()
		{
			Parameters = new List<ParameterWithDoc>();
			ReturnDoc = null;
			Summary = "";
			TextBlocks = new List<TextBlock>();
			SignatureList = new List<string>();
		}

		enum MemFileState
		{
            Description,
			Signatures,
			Example,
			ExampleMarkup,
			Param,
			Return 
		}

		private bool _isSummaryFound = false;
		private MemFileState _currentState;

	    public MeaningfulBlock()
	    {
	        InitBasics();
	    }

	    private ParameterWithDoc GetOrCreateParameter (string name)
		{
			ParameterWithDoc p = Parameters.FirstOrDefault (m => m.Name == name);
			if (p == null)
			{
				p = new ParameterWithDoc ();
				p.Name = name;
				Parameters.Add (p);
			}
			return p;
		} 
		
		private ReturnWithDoc GetOrCreateReturnDoc ()
		{
			if (ReturnDoc == null)
				ReturnDoc = new ReturnWithDoc ();
			return ReturnDoc;
		}
		
		public override string ToString()
		{
			var sb = new StringBuilder();
			if (SignatureList.Any())
			{
				sb.AppendUnixLine(ParserToken.SignatureOpen);
				foreach (var sig in SignatureList)
					sb.AppendUnixLine(sig);
				sb.AppendUnixLine(ParserToken.SignatureClose);
			}
			return sb + ContentWithoutSignatures();
		}

		private string ContentWithoutSignatures(bool prependSlashes = false)
		{
			var sb = new StringBuilder();
			if (!Summary.IsEmpty())
			{
				if (prependSlashes)
					sb.Append(ParserToken.DocComment);
				sb.AppendUnixLine(Summary);
			}

			foreach (var textOrExample in TextBlocks)
			{
				string str = textOrExample.ToString().TrimEndAndNewlines();
				if (!str.IsEmpty())
				{

					if (textOrExample is DescriptionBlock && prependSlashes)
					{
						var multiLine = str.SplitLines();
						foreach (var line in multiLine)
						{
							sb.Append(ParserToken.DocComment);
							sb.AppendUnixLine(line);
						}
					}
					else
					{
						//note, we do not prepend slashes to examples regardless
						sb.AppendUnixLine(str);
					}
				}
			}
			foreach (var param in Parameters)
			{
				if (param.HasDoc)
				{
					if (prependSlashes)
						sb.Append(ParserToken.DocComment);

					sb.AppendUnixLine(param.ToString());
				}
			}
			if (ReturnDoc != null && ReturnDoc.HasDoc)
			{
				if (prependSlashes)
					sb.Append(ParserToken.DocComment);
			
				sb.AppendUnixLine(ReturnDoc.ToString());
			}

			return sb.ToString().Trim();
		}

		private void ProcessAsm (AssemblyDataItem data)
		{
			Collection<ParameterDefinition> parameters = null;
			TypeDefinition returnType = null;
			switch (data.assemblyType)
			{
				case AssemblyType.Method:
					{
						parameters = data.MInfo.Parameters;
						if (data.MInfo.ReturnType.ToString() != "System.Void")
						{
							try
							{
								returnType = (TypeDefinition)data.MInfo.ReturnType;
							}
							catch(InvalidCastException)
							{
								Console.WriteLine("RHS returntype = {0}", data.MInfo.ReturnType);
							}
						}
						
						break;
					}
				case AssemblyType.Constructor:
					{
						parameters = data.MInfo.Parameters;
						break;
					}
			}
			
			// Handle parameters
			if (parameters != null)
			{
				foreach (var pInfo in parameters)
					GetOrCreateParameter(pInfo.Name).Info = pInfo;
			}
			
			// Handle return type
			if (returnType != null)
				GetOrCreateReturnDoc().ReturnType = returnType;
			Console.WriteLine("Full signature = {0}", this.ToString());
					
		}

		private void ProcessDoc (string memInput)
		{
		    var remainingLines = new List<string>(memInput.SplitLines());
			ProcessOneMeaningfulBlock(ref remainingLines);
            Assert.IsFalse(remainingLines.Any(), "memInput="+ memInput);
		}
		

	    public void ProcessOneMeaningfulBlock(ref List<string> remainingLines)
	    {
            var accumulator = new StringBuilder();

	        bool convertExample = false;
	        bool noCheck = false;
		    int nSigBlocksFound = 0;
	        _currentState = DefaultMemFileState;
		   
            while (remainingLines.Any() && nSigBlocksFound < 2)
            {
                var line = remainingLines.First();
                var shortLine = line.TrimStart();
                
                if (shortLine.StartsWith(ParserToken.SignatureOpen))
                {
	                nSigBlocksFound++;

					//if we detect a second SignatureOpen token, this is the beginning of a new block, 
					//so we don't consume this line
                    if (nSigBlocksFound == 2)
						continue;
					
                    remainingLines.RemoveAt(0);
                    TerminateChunk(accumulator, MemFileState.Signatures);
                    continue;
                }
                remainingLines.RemoveAt(0);

                if (shortLine.StartsWith(ParserToken.SignatureClose))
                {
                    Assert.AreEqual(MemFileState.Signatures, _currentState);
                    TerminateChunk(accumulator, DefaultMemFileState);
                    continue;
                }
                if (shortLine.StartsWith(ParserToken.ConvertExample) || shortLine.StartsWith(ParserToken.NoCheck))
                {
                    convertExample = shortLine.StartsWith(ParserToken.ConvertExample);
                    noCheck = shortLine.StartsWith(ParserToken.NoCheck);
                    Assert.IsFalse(convertExample && noCheck);
                    if (_currentState != MemFileState.Example)
                        TerminateChunk(accumulator, MemFileState.ExampleMarkup, convertExample, noCheck);
                    continue;
                }
                 
                if (shortLine.StartsWith(ParserToken.BeginEx))
	            {
	                if (shortLine.Contains(ParserToken.NoCheck))
	                    noCheck = true;
	                //Assert.AreNotEqual(MemFileState.Example, m_CurrentState);
		            if (_currentState == MemFileState.ExampleMarkup)
			            _currentState = MemFileState.Example;
		            TerminateChunk(accumulator, MemFileState.Example);
	                continue;
	            }
	            if (shortLine.StartsWith(ParserToken.EndEx))
	            {
	                Assert.AreEqual(MemFileState.Example, _currentState);
                    TerminateChunk(accumulator, DefaultMemFileState, convertExample, noCheck);
	                convertExample = noCheck = false;
	                continue;
	            }
	            if (shortLine.StartsWith(ParserToken.Param))
	            {
	                Assert.AreNotEqual(MemFileState.ExampleMarkup, _currentState);
	                TerminateChunk(accumulator, MemFileState.Param);
	            }
	            if (shortLine.StartsWith(ParserToken.Return))
	            {
	                Assert.AreNotEqual(MemFileState.ExampleMarkup, _currentState);
                    TerminateChunk(accumulator, MemFileState.Return);
	            }
	           
	            accumulator.AppendUnixLine(line);
            }

            //make sure we're not in the middle of an example when we reached EOF or next signature marker
            Assert.AreNotEqual(MemFileState.Example, _currentState);

            TerminateChunk(accumulator, DefaultMemFileState);
	    }

		private void TerminateChunk(StringBuilder accumulator, MemFileState futureState, bool convertExample = false, bool noCheck = false)
		{
			string consumeAndTrim = accumulator.ConsumeAndTrimEndAndNewlines();
			if (consumeAndTrim.Length > 0)
			{
				switch (_currentState)
				{
					case MemFileState.Signatures:
						{
							var sigs = consumeAndTrim.SplitLines();
							foreach (var sig in sigs)
								SignatureList.Add(sig);
							break;
						}
					case MemFileState.Example:
						{
							var oneExample = new ExampleBlock(consumeAndTrim)
								                 {
									                 IsNoCheck = noCheck, 
									                 IsConvertExample = convertExample
								                 };
							TextBlocks.Add(oneExample);
							break;
						}

					case MemFileState.Description:
						{
							if (!_isSummaryFound)
							{
								var lines = consumeAndTrim.SplitLines();
								Summary = lines[0];
								consumeAndTrim = consumeAndTrim.Replace(Summary, "");
								consumeAndTrim = consumeAndTrim.TrimEndAndNewlines();
								_isSummaryFound = true;
								if (consumeAndTrim.Length == 0)
									break;
							}
							var oneText = new DescriptionBlock(consumeAndTrim);
							TextBlocks.Add(oneText);
							break;
						}
					case MemFileState.Param:
						{
							consumeAndTrim = consumeAndTrim.Replace("@param ", "");
							int index = consumeAndTrim.IndexOfAny(new char[] {' ', '\t'});
							string name = consumeAndTrim.Substring(0, index).Trim ();
							string doc = consumeAndTrim.Substring(index + 1).Trim ();
							ParameterWithDoc paramDoc = GetOrCreateParameter (name);
							paramDoc.Doc = doc;
							break;
						}
					case MemFileState.Return:
						{
							consumeAndTrim = consumeAndTrim.Replace("@returns ", "");
							consumeAndTrim = consumeAndTrim.Replace("@return ", "");

							GetOrCreateReturnDoc ().Doc = consumeAndTrim;
							break;
						}
				}
			}
			_currentState = futureState;
		}

		public bool IsEmpty()
		{
			Assert.IsNotNull(Parameters);
			Assert.IsNotNull(TextBlocks);
			return Summary == "" && ReturnDoc == null && Parameters.Count == 0 && TextBlocks.Count == 0;
		}
		
		public void SanitizeForEditing ()
		{
			// If there's no text or example, add one
			if (TextBlocks.Count == 0)
				TextBlocks.Add (new DescriptionBlock (""));
			
			// If the last text or example is not a text, add one
			if (!(TextBlocks[TextBlocks.Count-1] is DescriptionBlock))
				TextBlocks.Add (new DescriptionBlock (""));
			
			// Make sure there's a text before each example
			for (int i=TextBlocks.Count-1; i>=0; i--)
			{
				if (TextBlocks[i] is ExampleBlock && (i==0 || !(TextBlocks[i-1] is DescriptionBlock)))
					TextBlocks.Insert (i, new DescriptionBlock (""));
			}
			
			// When there's two descriptions after each other, merge them together
			for (int i=TextBlocks.Count-2; i>=0; i--)
			{
				if (TextBlocks[i] is DescriptionBlock && TextBlocks[i+1] is DescriptionBlock)
				{
					TextBlocks[i].Text += "\n\n" + TextBlocks[i+1].Text;
					TextBlocks.RemoveAt (i+1);
				}
			}
		}

		public string GetUniqueSigContent(string uniqueSig)
		{
			var sigListSize = SignatureList.Count;
			var index = SignatureList.FindIndex(m => m==uniqueSig);
			if (index == sigListSize - 1)
				return ContentWithoutSignatures(prependSlashes: true);
			if (index >= 0 && index < sigListSize)
				return "///*listonly*";
			return "";
		}
	}
}
