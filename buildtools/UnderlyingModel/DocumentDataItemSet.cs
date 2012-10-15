using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace UnderlyingModel
{
    /// <summary>
    /// Holds Document Data Item sets read from given directory.
    /// </summary>
    public class DocumentDataItemSet
    {
        /// <summary>
        /// List of DocumentDataItem read from given directory.
        /// </summary>
        internal readonly HashSet<DocumentDataItem>  _documentList;

        /// <summary>
        /// Hashtable of DocumentDataItem for speeding up search.
        /// </summary>
        private readonly Dictionary<String, DocumentDataItem> _hashtable;

        /// <summary>
        /// Directory of MemberDoc
        /// </summary>
        public String baseDocDirPath;

        /// <summary>
        /// Constructor
        /// </summary>
        public DocumentDataItemSet()
        {
            _documentList = new HashSet<DocumentDataItem>();
            _hashtable = new Dictionary<String, DocumentDataItem>();
        }

        /// <summary>
        /// Add document locale files
        /// </summary>
        /// <param name="files">list of pathes in given locale</param>
        /// <param name="locale">locale of files</param>
        public void AddLocaleFileList(string[] files, LanguageUtil.ELanguage locale)
        {
            foreach (string file in files)
            {
                var sig = Path.GetFileNameWithoutExtension(file);
				Debug.Assert(sig != null, "sig != null");
				
				DocumentDataItem docItem = null;
            	
            	if (_hashtable.ContainsKey(sig))
                {
                    docItem = _hashtable[sig];
                    Debug.Assert(docItem.signature.Equals(sig));
                }
                else
                {
                	docItem = new DocumentDataItem
                	          	{
                	          		signature = sig, 
									baseDocDirPath = baseDocDirPath
                	          	};
                	_hashtable.Add(sig, docItem);
                    _documentList.Add(docItem);
                }

                docItem.AddLocaleFile(file, locale);
            }
        }

        /// <summary>
        /// Returns list of DocumentDataItems which its assembly info is missing.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DocumentDataItem> GetAPIMissingDocumentDataItems()
        {
        	return _documentList.Where(item => item.asm == null);
        }

        private IEnumerable<DocumentDataItem> ValidEnglishDocs()
        {
            return _documentList.Where(item => item.HasDocForEnglish() && !item.IsUndoc());
        }

		public IEnumerable<DocumentDataItem> GetUntranslatedAPIs(LanguageUtil.ELanguage currentDocumentLocale)
		{
			return ValidEnglishDocs().Where(item => !item.HasDocForLocale(currentDocumentLocale));
		}

		public IEnumerable<DocumentDataItem> GetTranslatedAPIs(LanguageUtil.ELanguage currentDocumentLocale)
		{
			return ValidEnglishDocs().Where(item => item.HasDocForLocale(currentDocumentLocale));
		}

    	/// <summary>
        /// Find DocumentDataItem by signature name
        /// </summary>
        /// <param name="name">signature name format by MemberDoc</param>
        /// <returns>DocumentDataItem if there is a corresponding object. null if not.</returns>
        public DocumentDataItem FindByName(String name)
        {
    		if (_hashtable.ContainsKey(name))
    			return _hashtable[name];
    		return null;
        }

        /// <summary>
        /// Create DocumentDataItem for corresponding AssemblyDataItem and add it to DocumentDataItemSet
        /// </summary>
        /// <param name="asm"></param>
        public DocumentDataItem CreateDocumentDataItemFor(AssemblyDataItem asm) {

        	var docItem = new DocumentDataItem
        	              	{
        	              		signature = asm.SimplifiedName, 
								baseDocDirPath = baseDocDirPath
        	              	};
        	_hashtable.Add(docItem.signature, docItem);
            _documentList.Add(docItem);
            asm.DocDataItem = docItem;
            
            return docItem;
        }
    }

    /// <summary>
    /// Buidler class for various DataItems
    /// </summary>
    public class DocumentDataBuilder
    {
        public static DocumentDataItemSet BuildDocumentDataItems()
        {
	        var docDirectoryPath = DirectoryUtil.MemberDocsDirFullPath;
        	var docset = new DocumentDataItemSet {baseDocDirPath = docDirectoryPath};

        	foreach (var loc in LanguageUtil.GetAllLanguages())
			{
                CreateLocaleDirectory(docDirectoryPath, loc);

                var files = GetDocumentPathListOf(docDirectoryPath, loc);
                docset.AddLocaleFileList(files, loc);
            }

            return docset;
        }

        private static void CreateLocaleDirectory(String path, LanguageUtil.ELanguage locale)
        {
            var destinDir = DirectoryWithLangUtil.LocalizedDir(path, locale);
            try
            {
                //create a base dir based on language            
                Directory.CreateDirectory(destinDir);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.Out.WriteLine("createLocaleDirectory failed:{0}", e.Message);
                Console.Error.WriteLine("Could not create directory {0}", Path.GetFullPath(destinDir));
            }
        }


    	private static string[] GetDocumentPathListOf(String path, LanguageUtil.ELanguage locale)
    	{
    		var destinDir = DirectoryWithLangUtil.LocalizedDir(path, locale);

            string[] sourceMemFiles = null;
            try
            {
                sourceMemFiles = Directory.GetFiles(destinDir);
            }
            catch (DirectoryNotFoundException)
            {
                Console.Error.WriteLine("Could not read from directory {0}. Please run DocDissector first!", path);
            }

            return sourceMemFiles;
        }
    }
}
