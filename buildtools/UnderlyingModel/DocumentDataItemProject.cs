/**
 * @(#) DocumentDataItemProject.cs
 * main document model to save document structure data
 */

using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace UnderlyingModel
{
    public enum Presence
    {
    	DontCare,
    	Present,
    	Absent
    }
    
    [Serializable]
    public class DocumentDataItemProject
    {
        [NonSerialized()]
        [XmlIgnore()]
        public DocumentDataItemSet docSet;

        [NonSerialized()]
        [XmlIgnore()]
        public AssemblyDataItemSet asmset;

        [NonSerialized()]
        [XmlIgnore()]
        private readonly List<IDataItemOld> _allItems;

		public List<IDataItemOld> GetAllItems()
		{
			return _allItems;
		}
		
		public List<IDataItemOld> GetFilteredItems (Presence api, Presence docs)
		{
			IEnumerable<IDataItemOld> items = new List<IDataItemOld>(_allItems);
			if (api == Presence.Absent)
				items = items.Where (elem => elem.GetAssemblyDataItem () == null);
			else if (api == Presence.Present)
				items = items.Where (elem => elem.GetAssemblyDataItem () != null);
			
			if (docs == Presence.Absent)
				items = items.Where (elem => elem.GetDocumentDataItem () == null);
			else if (docs == Presence.Present)
				items = items.Where (elem => elem.GetDocumentDataItem () != null);
			
			return items.ToList ();
		}

        /// <summary>
        /// Constructor
        /// </summary>
        public DocumentDataItemProject()
        {
            _allItems = new List<IDataItemOld>();
        }

		

        /// <summary>
        /// ReloadAllProjectData
        /// </summary>
        public void ReloadAllProjectData()
        {
            asmset = AssemblyDataBuilder.BuildAssemblyDataItemsMonoCecil();
            docSet = DocumentDataBuilder.BuildDocumentDataItems();

            asmset.Bind(docSet);
			PopulateAllItems(asmset, docSet);
        }

    	private void PopulateAllItems(AssemblyDataItemSet asmSet, DocumentDataItemSet docSet)
    	{
			var apiMissingList = docSet.GetAPIMissingDocumentDataItems(); //documents with no APIs => shouldn't really happen. 

    		_allItems.Clear();
    		_allItems.AddRange(asmSet.Items.ToArray());

    		var lst = apiMissingList.ToList();
    		_allItems.AddRange(lst.ToArray());

    		Console.WriteLine("|docSet| = {1}; |asmSet| = {0}; |apiMissingList| = {2}; |allItems| = {3}", asmSet.Items.Count,
    		                  docSet._documentList.Count, lst.Count, _allItems.Count);

    		Debug.Assert(_allItems.Count == lst.Count + asmSet.Items.Count);
    	}


    	/// <summary>
        /// Open file and read project data
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DocumentDataItemProject Load(String path)
        {
            var serializer = new XmlSerializer(typeof(DocumentDataItemProject));

            var fs = new FileStream(path, FileMode.Open);
            var project = (DocumentDataItemProject)serializer.Deserialize(fs);
            fs.Close();

        	return project;
        }

        public void Save()
        {
            String parentDir = Path.GetDirectoryName(DirectoryUtil.MemberDocsDirFullPath);
            SaveToFile(parentDir);
        }

        /// <summary>
        /// Save to File.
        /// </summary>
        /// <param name="path"></param>
        private void SaveToFile(String path)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(DocumentDataItemProject));

                var filename = path + "\\project.udp";

                var fs = new FileStream(filename, FileMode.OpenOrCreate);
                serializer.Serialize(fs, this);
                fs.Close();
            }
            catch (ReflectionTypeLoadException le)
            {
                Console.Out.WriteLine("DLL Load Exception: {0}", le.Message);
                Console.Out.WriteLine("Descriptions:");
                foreach (var e in le.LoaderExceptions)
                {
                    Console.Out.WriteLine("   {0}", e.Message);
                }
            }
            catch (Exception e)
            {
                // TODO: plz fix this if happens...
                Console.Out.WriteLine("DLL Load Exception:{0}", e.Message);
            }
        }

        public SuccessCode AssignDocToAsm(string asmName, string docName, string rootMemberDocs)
        {
            SuccessCode success = 0;

            //make sure the Asm Item exists, has assembly, but no doc
            if (_allItems.Exists(m => m.ItemName() == asmName))
                success |= SuccessCode.AsmItemExists;
            var properAsmItem = _allItems.Find(m => m.ItemName() == asmName);
            if (properAsmItem.GetAssemblyDataItem()!=null)
                success |= SuccessCode.AsmItemHasAsm;
            if (properAsmItem.GetDocumentDataItem() == null)
                success |= SuccessCode.AsmItemHasNoDoc;

            //make sure the doc item exists, has a doc, but no assembly
            if (_allItems.Exists(m => m.ItemName() == docName))
                success |= SuccessCode.DocItemExists;

            var properDocItem = _allItems.Find(m => m.ItemName() == docName);
            if (properDocItem.GetDocumentDataItem() != null)
                success |= SuccessCode.DocItemHasDoc;
            if (properDocItem.GetAssemblyDataItem() == null)
                success |= SuccessCode.DocItemHasNoAsm;

            DirectoryWithLangUtil.RenameMemFile(docName, asmName, rootMemberDocs);

            var actualDoc = properDocItem.GetDocumentDataItem();
			
            properAsmItem.SetDocumentDataItem(actualDoc);
            //remove the dead doc item.
            _allItems.Remove(properDocItem);

            return success;
        }

        [Flags]
        public enum SuccessCode
        {
            AsmItemExists = 0,
            AsmItemHasAsm = 1,
            AsmItemHasNoDoc = 2,
            DocItemExists = 4,
            DocItemHasDoc = 8,
            DocItemHasNoAsm = 16, 
        }
    }

}
