using System.Text;

namespace UnderlyingModel
{
	public abstract class TextBlock
	{
		public string Text { set; get; }

	    protected TextBlock(string txt)
		{
			Text = txt;
		}

		public override string ToString()
		{
			return Text;
		}
	}
	
	public class DescriptionBlock : TextBlock
	{
		public DescriptionBlock(string txt) : base(txt) { }
	}
	
	public class ExampleBlock : TextBlock
	{
		public bool IsConvertExample { set; get; }
		public bool IsNoCheck { set; get; }
		 
		public ExampleBlock(string txt) : base (txt) {
			var lines = txt.SplitLines();
			var exampleNoMarkup = new StringBuilder();
			foreach (var line in lines)
			{
				if (line.StartsWith(ParserToken.ConvertExample))
					IsConvertExample = true;
				if (line.StartsWith(ParserToken.NoCheck))
					IsNoCheck = true;
				exampleNoMarkup.AppendUnixLine(line);
			}
			Text = exampleNoMarkup.ToString();
		}
		
		public override string ToString()
		{
			var sb = new StringBuilder();
			if (IsConvertExample)
				sb.AppendUnixLine(ParserToken.ConvertExample);
			var nocheckString = IsNoCheck ? " "+ParserToken.NoCheck : "";
			//note that the last line of text will terminate in an endline 
			sb.Append(ParserToken.BeginEx + nocheckString + "\n" + Text + ParserToken.EndEx);
			return sb.ToString();
		}
	}

}
