using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace BookBuilder
{
	class Program
	{
		static void Main(string[] args)
		{
			var rootDirName = DocumentationRoot();
			Console.WriteLine("RootDirName: "+rootDirName);
			var inputdir = rootDirName + "/content/english/book/";
			var pages = new List<BookPage>();
			foreach(var file in Directory.GetFiles(inputdir,"*.md"))
			{
				var page = new BookPage(file);
				var outputfile = OutputDir() + Path.GetFileName(Path.GetFileNameWithoutExtension(file))+".html";
				pages.Add(page);
				page.WriteAsHtml(outputfile);
			}

			foreach (var file in Directory.GetFiles(inputdir, "*").Where(file => Path.GetExtension(file).ToLower()!=".md"))
			{
				var outputfile = Path.Combine(OutputDir(), Path.GetFileName(file));
				Console.WriteLine("outputfile: "+outputfile);
				PathTools.EnsureDirectoryExists(Path.GetDirectoryName(outputfile));
				File.Copy(file, outputfile,true);
			}

			var tocBuilder = new TOCBuilder(pages);
			File.WriteAllText(OutputDir()+"/toc.html",tocBuilder.Build());
			File.Copy(DocumentationRoot() + "/layout/book.css", OutputDir() + "/book.css", true);
		}

		private static string DocumentationRoot()
		{
			return Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "../../..");
		}

		private static string OutputDir()
		{
			return DocumentationRoot() + "/output/book/english/";
		}
	}
}
