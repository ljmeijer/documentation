using System.IO;
using UnderlyingModel;

namespace BookBuilder
{
	class Program
	{
		static void Main(string[] args)
		{
			var content = DirectoryUtil.RootDirName + "/content/english/book/";
			foreach(var file in Directory.GetFiles(content,"*.md"))
			{
				var outputfile = DirectoryUtil.RootDirName + "/output/book/" + Path.GetFileName(Path.GetFileNameWithoutExtension(file))+".html";
				
				ConvertMarkdownToHtml(file, outputfile);
			}
		}

		private static void ConvertMarkdownToHtml(string file, string outputfile)
		{
			string input = File.ReadAllText(file);
			var output = new MarkdownSharp.Markdown().Transform(input);

			EnsureDirectoryExists(Path.GetDirectoryName(outputfile));
			File.WriteAllText(outputfile,output);
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
