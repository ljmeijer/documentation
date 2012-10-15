using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderlyingModel
{
	public class MemDocModel
	{
		internal  List<MeaningfulBlock> MeaningfulBlocks = new List<MeaningfulBlock>();
		public MemDocModel(IDataItemOld memberData, LanguageUtil.ELanguage language)
		{
			var block = new MeaningfulBlock(memberData, language);
			MeaningfulBlocks.Add(block);
		}

		//used in MemberSession
		public MemDocModel(AssemblyDataItem memberData, string Text)
		{
		    var block = new MeaningfulBlock(memberData, Text);
		    MeaningfulBlocks.Add(block);
		}

		public MemDocModel(string st)
		{
		    var remainingLines = new List<string>(st.SplitLines());
            while (remainingLines.Any())
            {
                var block = new MeaningfulBlock();
		   
                block.ProcessOneMeaningfulBlock(ref remainingLines);
                MeaningfulBlocks.Add(block);
            }
		}

		public void SanitizeForEditing()
		{
			if (MeaningfulBlocks.Count > 0)
				MeaningfulBlocks[0].SanitizeForEditing();
		}

		public ReturnWithDoc ReturnDoc { 
			get {
				return MeaningfulBlocks.Count > 0 ? MeaningfulBlocks[0].ReturnDoc : new ReturnWithDoc();
			}	
		}

		public string Summary
		{
			get { return MeaningfulBlocks.Count > 0 ? MeaningfulBlocks[0].Summary : ""; }
			set {
				if (MeaningfulBlocks.Count > 0)
					MeaningfulBlocks[0].Summary = value;
			}
		}

		public List<ParameterWithDoc> Parameters
		{
			get { return MeaningfulBlocks.Count > 0 ? MeaningfulBlocks[0].Parameters : new List<ParameterWithDoc>(); }
		}

		public List<string> SignatureList
		{
			get { return MeaningfulBlocks.Count > 0 ? MeaningfulBlocks[0].SignatureList : new List<string>(); }
		}
		

		public List<TextBlock> TextBlocks { 
			set
			{
				if (MeaningfulBlocks.Count > 0)
					MeaningfulBlocks[0].TextBlocks = value;
			}  
			get { return MeaningfulBlocks.Count > 0 ? MeaningfulBlocks[0].TextBlocks : new List<TextBlock>(); } 
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (var block in MeaningfulBlocks)
			{
				sb.Append(block.ToString());
				if (block != MeaningfulBlocks.Last())
					sb.AppendUnixLine();
			}

			return sb.ToString();
		}

		public string GetUniqueSigContent(string uniqueSig)
		{
			foreach (var block in MeaningfulBlocks)
			{
				var content = block.GetUniqueSigContent(uniqueSig);
				if (!content.IsEmpty())
					return content;
			}
			return "NOTHING FOUND!!! for "+uniqueSig;
		}
	}
}
