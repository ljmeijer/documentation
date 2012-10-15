 /**
 * @(#) DocumentDataItem.cs
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace UnderlyingModel
{
    /// <summary>
    /// Object represents each document fragment.
    /// </summary>
    [Serializable]
    public class DocumentDataItem : IDataItemOld, IComparable
    {
        internal String baseDocDirPath;
        internal String signature;
        internal AssemblyDataItem asm;
        internal SortedDictionary<LanguageUtil.ELanguage, String> FileMap;


        public DocumentDataItem()
        {
            FileMap = new SortedDictionary<LanguageUtil.ELanguage, String>();
        }

        /// <summary>
        /// Read file of given locale.
        /// If file is missing, it crosses out that document and set it to missing satus.
        /// </summary>
        /// <param name="locale">locale to read</param>
        /// <returns>contents of the document</returns>
        public String LoadDocumentOfLocale(LanguageUtil.ELanguage locale)
        {
            if (FileMap.ContainsKey(locale))
            {
                try
                {
                    var reader = File.OpenText(FileMap[locale]);
                    var content = reader.ReadToEnd();
                    reader.Close();
                    return content;
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("File Save Failed:{0}", e.Message);
                    FileMap.Remove(locale);
                }
            }

            return null;
        }

        public String LoadEnglishDocument()
        {
            return LoadDocumentOfLocale(LanguageUtil.ELanguage.English);
        }

        /// <summary>
        /// Saves content to given locale
        /// </summary>
        /// <param name="content">content to save into file</param>
        /// <param name="locale">locale to save</param>
        /// <returns>true if succeeds</returns>
        public bool SaveDocumentOfLocale(String content, LanguageUtil.ELanguage locale)
        {
            String savingPath = null;

            if (FileMap.ContainsKey(locale))
            {
                savingPath = FileMap[locale];
            }
            else
            {
                var filename = DirectoryUtil.MemberNameWithExtension(signature, DirectoryUtil.MemExtension);

				if (LanguageUtil.IsEnglish(locale))
					savingPath = Path.Combine(baseDocDirPath, filename);
				else
					savingPath = string.Concat(Path.Combine(baseDocDirPath, locale.ToString()), Path.DirectorySeparatorChar, filename);
            }

            try
            {
                File.WriteAllText(savingPath, content);
                if (!FileMap.ContainsKey(locale))
                {
                    FileMap.Add(locale, savingPath);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("saveDocumentOfLocale failed:{0}", e.Message);
                FileMap.Remove(locale);
            }

            return false;
        }

        /// <summary>
        /// Adding locale to this DocumentDataItem
        /// </summary>
        /// <param name="path">file path to locale obj</param>
        /// <param name="locale">locale to add</param>
        internal void AddLocaleFile(String path, LanguageUtil.ELanguage locale)
        {
            if (FileMap.ContainsKey(locale))
                FileMap[locale] = path;
            else
                FileMap.Add(locale, path);
        }

        // check if given locale's document exists
        public bool HasDocForLocale(LanguageUtil.ELanguage locale)
        {
            return FileMap.ContainsKey(locale);
        }

        public bool HasDocForEnglish()
        {
            return FileMap.ContainsKey(LanguageUtil.ELanguage.English);
        }

        public bool IsUndoc()
        {
            var docString = LoadEnglishDocument();
            return docString.Contains("*undoc");
        }

        public String ItemName()
        {
            return signature;
        }

        public String ItemType()
        {
            return "memberdoc only";
        }

		public AssemblyDataItem GetAssemblyDataItem()
        {
            return asm;
        }

        public DocumentDataItem GetDocumentDataItem()
        {
            return this;
        }

		public void SetDocumentDataItem(DocumentDataItem other)
		{
			//do nothing
		}

        public int CompareTo(object obj)
        {
            var item = (IDataItemOld)obj;
            return signature.CompareTo(item.ItemName());
        }
    }

}
