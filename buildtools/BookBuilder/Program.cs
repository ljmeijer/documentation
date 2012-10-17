using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using UnderlyingModel;

namespace BookBuilder
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("RootDirName: "+DirectoryUtil.RootDirName);
			var inputdir = DirectoryUtil.RootDirName + "/content/english/book/";
			foreach(var file in Directory.GetFiles(inputdir,"*.md"))
			{
				var outputfile = OutputDir() + Path.GetFileName(Path.GetFileNameWithoutExtension(file))+".html";
				
				ProduceHtmlFromMarkdown(file, outputfile);
			}

			foreach (var file in Directory.GetFiles(inputdir, "*").Where(file => Path.GetExtension(file).ToLower()!=".md"))
			{
				var outputfile = Path.Combine(OutputDir(), Path.GetFileName(file));
				Console.WriteLine("outputfile: "+outputfile);
				EnsureDirectoryExists(Path.GetDirectoryName(outputfile));
				File.Copy(file, outputfile,true);
			}

		}

		private static string OutputDir()
		{
			return DirectoryUtil.RootDirName + "/output/book/english/";
		}

		private static void ProduceHtmlFromMarkdown(string file, string outputfile)
		{
			string input = File.ReadAllText(file);
			var output = new MarkdownSharp.Markdown().Transform(input);
			output = PostProcessHtml(output);
			EnsureDirectoryExists(Path.GetDirectoryName(outputfile));
			File.WriteAllText(outputfile,output);
		}

		private static string PostProcessHtml(string html)
		{
			var regex = new Regex(@"<pre><code>(.*?)</code></pre>", RegexOptions.Singleline);
			return regex.Replace(html, match => DocBuilderTools.ExampleHtmlGenerator.ExamleHtmlFor(match.Groups[1].ToString()));
		}


		private static void EnsureDirectoryExists(string dir)
		{
			if (Directory.Exists(dir))
				return;

			var parent = Path.GetDirectoryName(dir);
			EnsureDirectoryExists(parent);

			Directory.CreateDirectory(dir);
		}
	}
}
