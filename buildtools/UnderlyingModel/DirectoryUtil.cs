using System;
using System.IO;
using System.Linq;


namespace UnderlyingModel
{
    static public class DirectoryUtil
    {
        public const string TxtExtensionMask = "*.txt";
    	public const string MemExtensionMask = "*.mem";
    	public const string MemExtension = "mem";

    	public static string RootDirName
    	{
    		get
    		{
    			var curDir = Path.GetDirectoryName(Directory.GetCurrentDirectory());
				if (curDir == null)
				{
					Console.Write("CURDIR = {0}", Directory.GetCurrentDirectory());
					return "notfound";
				}

    			var toolsIndex = curDir.IndexOf("buildtools", StringComparison.CurrentCultureIgnoreCase);

				if (toolsIndex < 0)
				{
					Console.WriteLine("could not find 'tools' inside directory name (curdir = {0})", curDir);
					return "notfound";
				}
    			var rootDir = curDir.Substring(0, toolsIndex);
    			return rootDir;
    		}
    	}

    	public static string RuntimeExportDir  = Path.Combine(RootDirName, "Runtime/Export");
        public static string EditorMonoDir = Path.Combine(RootDirName, "Editor/Mono");
        public static string RuntimeExportGeneratedDir = Path.Combine(RootDirName, "Runtime/ExportGenerated/Editor");
        public static string MemberDocsDir = Path.Combine(RootDirName, "content/english/api");
        public static string MemberDocsDirFullPath = Path.GetFullPath(MemberDocsDir);
        public static string ReassembledDir = Path.Combine(RootDirName, "Documentation/Reassembled");

	    public static string ScriptRefOutput = Path.Combine(RootDirName, "build/UserDocumentation/ActualDocumentation/Documentation/ScriptReference");
		public static string UnityAssembliesDir = Path.Combine(RootDirName, "content/");
		public static string EngineDllLocation = Path.Combine(UnityAssembliesDir, "UnityEngine.dll");
		public static string EditorDllLocation = Path.Combine(UnityAssembliesDir, "UnityEditor.dll");
		
		public static bool IsEditorMono(string fname)
		{
			return fname.Contains("Editor") && fname.Contains("Mono");
		}

        public static bool TryGetRuntimeExportTxtFiles(out string[] txtFiles)
        {
            txtFiles=null;
            try
            {
                txtFiles = GetRuntimeTxtFiles();
            }
            catch (DirectoryNotFoundException d)
            {
				Console.WriteLine(d);
                return false;
            }
            return txtFiles.Length > 0;
        }

        public static bool TryGetAllTxtFiles(out string[] txtFiles)
        {
            txtFiles = null;
            string[] engineTxtFiles;
            string[] editorTxtFiles;
            try
            {
                engineTxtFiles = GetRuntimeTxtFiles();
                editorTxtFiles = GetEditorMonoTxtFiles();
            }
            catch (DirectoryNotFoundException d)
            {
                Console.WriteLine(d);
                return false;
            }

            var lst = engineTxtFiles.ToList();
            lst.AddRange(editorTxtFiles.ToList());
            txtFiles = lst.ToArray();
            return txtFiles.Length > 0;
        }

        public static string[] GetRuntimeTxtFiles()
        {
            return Directory.GetFiles(RuntimeExportFullPath(), TxtExtensionMask).ToArray();
        }

        public static string[] GetEditorMonoTxtFiles()
        {
            return Directory.GetFiles(EditorMonoFullPath(), TxtExtensionMask).ToArray();
        }

        public static string RuntimeExportFullPath()
        {			
			var fullPath = Path.GetFullPath(RuntimeExportDir);
        	return fullPath;
        }

        public static string EditorMonoFullPath()
        {
            return Path.GetFullPath(EditorMonoDir);
        } 

    	public static void CreateDirectoryIfNeeded(string outputFolder)
    	{
			try
			{
				if (!Directory.Exists(outputFolder))
					Directory.CreateDirectory(outputFolder);
			}
			catch (DirectoryNotFoundException)
			{
				Console.Error.WriteLine("could not create directory {0}", outputFolder);
			}
    	}

        public static void DeleteAllFiles(string dir)
        {
            if (!Directory.Exists(dir))
                return;
            foreach (var f in Directory.GetFiles(dir))
                File.Delete(f);
        }

    	public static string MemberNameWithExtension(string memberName, string extMask)
    	{
    		return String.Format("{0}.{1}", memberName, extMask);
    	}

    	public static void CopyDirectory(string sourcePath, string destPath)
    	{
			CreateDirectoryIfNeeded(destPath);

    		foreach (var file in Directory.GetFiles(sourcePath))
    		{
    			var dest = Path.Combine(destPath, Path.GetFileName(file));
    			File.Copy(file, dest);
    		}

    		foreach (var folder in Directory.GetDirectories(sourcePath))
    		{
    			var dest = Path.Combine(destPath, Path.GetFileName(folder));
    			CopyDirectory(folder, dest);
    		}
    	}

		public static void CopyDirectoryFromScratch(string fullPathOrig, string fullPathDestin)
		{
			DeleteAllFiles(fullPathDestin);
			if (Directory.Exists(fullPathDestin))
				Directory.Delete(fullPathDestin, true);
			CreateDirectoryIfNeeded(fullPathDestin);
			CopyDirectory(fullPathOrig, fullPathDestin);
		}
    }
}
