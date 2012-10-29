using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookBuilder
{
    class AvailableLanguages
    {
        public static IEnumerable<string>  Get()
        {
            yield return "English";
            yield return "Chinese";
        }
    }

	class Program
	{
		static void Main(string[] args)
		{
			var rootDirName = DocumentationRoot();
			Console.WriteLine("RootDirName: "+rootDirName);

		    var englishinputdir = rootDirName + "/content/english/book";

            foreach (var lang in AvailableLanguages.Get())
            {
                var inputdir = rootDirName + "/content/"+lang+"/book/";
                var pages = new List<BookPage>();
                //trying this out
                //trying this out//trying this out//trying this out

                var tocBuilder = new TOCBuilder(File.ReadAllText(rootDirName + "/content/toc.yaml"));

                var outputDir = OutputDir(lang);
                foreach (var file in Directory.GetFiles(englishinputdir, "*.md"))
                {
                    var languagefile = inputdir + "/" + Path.GetFileName(file);
                    string filecontents = null;
                    bool usingEnglishAsFallback = !File.Exists(languagefile);

                    string filetouse = usingEnglishAsFallback ? file : languagefile;

                    var page = new BookPage(filetouse, lang, usingEnglishAsFallback);
                    var outputfile = outputDir + Path.GetFileName(Path.GetFileNameWithoutExtension(file)) + ".html";
                    pages.Add(page);
                    page.WriteAsHtml(outputfile, tocBuilder);
                }

                CopyNonMDFilesFrom(englishinputdir, outputDir);
                CopyNonMDFilesFrom(inputdir, outputDir);

                File.Copy(DocumentationRoot() + "/layout/book.css", outputDir + "/book.css", true);
            }
		}

        private static void CopyNonMDFilesFrom(string inputdir, string outputDir)
	    {
	        foreach (var file in NonMDFilesIn(inputdir))
	        {
	            var outputfile = Path.Combine(outputDir, Path.GetFileName(file));
	            PathTools.EnsureDirectoryExists(Path.GetDirectoryName(outputfile));
	            File.Copy(file, outputfile, true);
	        }
	    }

	    private static IEnumerable<string> NonMDFilesIn(string inputdir)
	    {
	        return Directory.GetFiles(inputdir, "*").Where(file => Path.GetExtension(file).ToLower() != ".md");
	    }

	    private static string DocumentationRoot()
		{
			return Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "../../..");
		}

		private static string OutputDir(string lang)
		{
		    return DocumentationRoot() + "/output/book/" + lang.ToLower() + "/";
		}
	}
}
