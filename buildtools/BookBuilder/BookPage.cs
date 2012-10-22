using System;
using System.IO;
using System.Text.RegularExpressions;
using DocBuilderTools;
using MarkdownSharp;

namespace BookBuilder
{
	internal class BookPage
	{
		private readonly string _file;

		public BookPage(string file)
		{
			_file = file;
		}

		public string Title
		{
			get { return Path.GetFileNameWithoutExtension(_file); }
		}

		public void WriteAsHtml(string outputfile)
		{
			ProduceHtmlFromMarkdown(_file, outputfile);
		}

		private static void ProduceHtmlFromMarkdown(string file, string outputfile)
		{
			string input = File.ReadAllText(file);
			var output = new Markdown().Transform(input);
			output = PostProcessHtml(output);
			PathTools.EnsureDirectoryExists(Path.GetDirectoryName(outputfile));
			File.WriteAllText(outputfile, output);
		}

		private static string PostProcessHtml(string html)
		{
			var regex = new Regex(@"<pre><code>(.*?)</code></pre>", RegexOptions.Singleline);

			var postprocessed = regex.Replace(html, match => ExampleHtmlGenerator.ExamleHtmlFor(match.Groups[1].ToString()));

			var final = String.Format(@"<!DOCTYPE html>
<html>
  <head>
    <meta charset='utf-8' />
    <link href='book.css' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Droid+Sans+Mono' rel='stylesheet' type='text/css'>
  </head>
  <body>
<div class='text'>
{0}
</div></body></html>", postprocessed);

			return final;
		}

		public string GetTOCParent()
		{
			return null;
		}
	}
}
