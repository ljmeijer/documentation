using System;
using System.IO;
using System.Linq;
using System.Text;
using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.IO;
using UnderlyingModel;
using UnityExampleConverter;

namespace APIDocumentationGenerator2
{
	class ExampleHtmlGenerator
	{
		public static string ExamleHtmlFor(ExampleBlock exampleblock)
		{
			var sb = new StringBuilder();
			sb.Append("<p>");
			sb.Append("<p>Javascript:<br>");
			var converter = new UnityScriptConverter();

			var javascript = RemoveGlobalIndenting(exampleblock.Text).Trim();
			sb.AppendFormat(@"<div class='example'><pre>{0}</pre></div>", javascript);

			converter.Input.Add(new StringInput("example", javascript));
			converter.References.Add(typeof(UnityEngine.MonoBehaviour).Assembly);
			converter.References.Add(typeof(UnityEditor.MenuItem).Assembly);
			
			CompileUnit[] covertedCode = null;
			try
			{
				covertedCode = converter.Run();
			}
			catch
			{
				return sb.ToString();
			}

			var csharp = new StringWriter();
			covertedCode[0].Accept(new CSharpPrinter(csharp));

			sb.Append("<p>C#<br>");
			sb.AppendFormat(@"<div class='example'><pre>{0}</pre></div>", csharp);

			sb.Append("<p>Boo<br>");
			sb.AppendFormat(@"<div class='example'><pre>{0}</pre></div>", covertedCode[1].ToCodeString());
			return sb.ToString();
		}

		public static string RemoveGlobalIndenting(string text)
		{
			var lines = text.SplitLines();
			while (NoLineHasNonWhitespaceFirstCharacter(lines))
			{
				for (int i = 0; i != lines.Count(); i++)
				{
					if (lines[i].Length == 0)
						continue;
					lines[i] = lines[i].Substring(1);
				}
			}

			var result = new StringBuilder();
			foreach (var l in lines)
				result.AppendLine(l);
			return result.ToString();
		}

		public static bool NoLineHasNonWhitespaceFirstCharacter(string[] lines)
		{
			return lines.Where(l => l.Length > 0).All(l => Char.IsWhiteSpace(l[0]));
		}
	}
}
