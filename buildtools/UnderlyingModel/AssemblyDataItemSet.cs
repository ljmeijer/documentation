/**
 * @(#) AssemblyDataItemSet.cs
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using Mono.Cecil;

namespace UnderlyingModel
{

    [Serializable]
    public class AssemblyDataItemSet
    {
        public float unityVersion;
        public String name;

        [NonSerialized()]
        [System.Xml.Serialization.XmlIgnore()]
        public Assembly engineAsm;

        [NonSerialized()]
        [System.Xml.Serialization.XmlIgnore()]
        public Assembly editorAsm;

    	public ModuleDefinition engineModule;
    	public ModuleDefinition editorModule;

		public int EngineAssemblySize { get; set; }
		public int EditorAssemblySize { get; set; }

    	private DocumentDataItemSet _documentItemSet;

    	public HashSet<AssemblyDataItem> Items { get; private set; }

    	/// <summary>
        /// Constructor
        /// </summary>
        public AssemblyDataItemSet()
        {
            Items = new HashSet<AssemblyDataItem>();
            new SortedDictionary<String, AssemblyDataItem>();
        }

    	/// <summary>
        /// Add list of items to AssemblyDataItemSet.
        /// </summary>
        /// <param name="items"></param>
        public void AddDataItems(List<AssemblyDataItem> items)
        {
    		foreach (var item in items)
    			if (!Items.Contains(item))
    				Items.Add(item);
        }

        /// <summary>
        /// Get Collection of Documented APIs
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public List<AssemblyDataItem> GetDocumentedAPIs(LanguageUtil.ELanguage locale)
        {
            var list = new List<AssemblyDataItem>();

            foreach (var item in Items)
            {
                if (item.DocDataItem != null)
                {
                    if(locale == LanguageUtil.ELanguage.Any) 
                        list.Add(item);
                    else if (item.DocDataItem.HasDocForLocale(locale))
                        list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// Get Collection of Undocumented APIs
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        public List<AssemblyDataItem> GetUndocumentedAPIs(LanguageUtil.ELanguage locale)
        {
            var list = new List<AssemblyDataItem>();

            foreach (var item in Items)
            {
            	if (item.DocDataItem == null)
            		list.Add(item);
            	else if (locale != LanguageUtil.ELanguage.Any)
            		if (!item.DocDataItem.HasDocForLocale(locale))
            			list.Add(item);
            }
            return list;
        }
        
        /// <summary>
        /// Bind givend DocumentDataItemSet to this AssemblyDataItemSet.
        /// By This process, AssemblyDataItems are matched up with its documents.
        /// </summary>
        /// <param name="documentItemSet"></param>
        internal void Bind(DocumentDataItemSet documentItemSet)
        {
            Debug.Assert(documentItemSet != null);

            _documentItemSet = documentItemSet;

            foreach (var item in Items)
            {
                // if matching document is there, _documentItemSet should return valid docitemdata
                var docItem = _documentItemSet.FindByName(item.SimplifiedName);
                item.DocDataItem = docItem;
            	if (docItem != null)
            		docItem.asm = item;
            }
        }
    }
}
