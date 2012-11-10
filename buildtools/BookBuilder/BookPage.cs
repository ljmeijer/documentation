using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using DocBuilderTools;
using MarkdownSharp;

namespace BookBuilder
{
	internal class BookPage
	{
		private readonly string _file;
	    private readonly string _language;
	    private readonly bool _usingEnglishAsFallback;

	    public BookPage(string file, string language, bool usingEnglishAsFallback)
		{
		    _file = file;
		    _language = language;
	        _usingEnglishAsFallback = usingEnglishAsFallback;
		}

	    public string Title
		{
			get { return Path.GetFileNameWithoutExtension(_file); }
		}

		public void WriteAsHtml(string outputfile, TOCBuilder tocBuilder)
		{
			ProduceHtmlFromMarkdown(_file, outputfile, tocBuilder);
		}

		private void ProduceHtmlFromMarkdown(string file, string outputfile, TOCBuilder tocBuilder)
		{
			string input = File.ReadAllText(file);
			var output = new Markdown().Transform(input);
			output = PostProcessHtml(output, tocBuilder, outputfile);
			PathTools.EnsureDirectoryExists(Path.GetDirectoryName(outputfile));
			File.WriteAllText(outputfile, output);
		}

		private string PostProcessHtml(string html, TOCBuilder tocBuilder, string outputfile)
		{
			var regex = new Regex(@"<pre><code>(.*?)</code></pre>", RegexOptions.Singleline);

			var postprocessed = regex.Replace(html, match => ExampleHtmlGenerator.ExamleHtmlFor(match.Groups[1].ToString()));

		    postprocessed = postprocessed.Replace(".md", ".html");

		    var prefixmessage = _usingEnglishAsFallback
		                        ? "<p>This page has not been translated into this language yet.  You'll find the english version of this document below.</p>"
		                        : "";

		    var final = String.Format(@"<!DOCTYPE html>
<html>
  <head>
    <meta charset='utf-8' />
    <link href='book.css' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Droid+Sans+Mono' rel='stylesheet' type='text/css'>
  </head>
  <body>
  <div class='languagebar'>
  Choose language:
{0}
</div>
  <div style=""float:left; width=350px;"" class='toc'>
  {1}  
</div>
<div class='text'>
{2}
{3}
</div></body></html>", LanguageSelector(outputfile), tocBuilder.Build(), prefixmessage, postprocessed);

			return final;
		}

	    private string LanguageSelector(string outputfile)
	    {
	        var languages = AvailableLanguages.Get();
            var sb = new StringBuilder();
	        sb.Append(@"<select id='languageselector' onclick='window.open(languageselector.options[languageselector.selectedIndex].value)'>");
            foreach(var lang in languages)
            {
                string selectedstr = lang == _language ? "selected='selected';" : "";
                sb.AppendFormat("<option value='../{0}/{2}' {3}>{1}</option>",lang.ToLower(),lang,Path.GetFileName(outputfile), selectedstr);
            }
            sb.Append("</select>");
	        return sb.ToString();
	    }
	}
}
