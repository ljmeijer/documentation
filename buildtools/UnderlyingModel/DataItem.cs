using System;
using System.Collections.Generic;

namespace UnderlyingModel
{
    public interface IDataItemOld
    {
        String ItemName();
        String ItemType();
        
        AssemblyDataItem GetAssemblyDataItem();
        DocumentDataItem GetDocumentDataItem();
    	void SetDocumentDataItem(DocumentDataItem other);
    }

	public interface IDataItem
	{
		DataItemKind GetDataItemKind { get; }
		List<string> GetSignatureList();
	}

	//the Cecil-independent representation of an assembly entry, populated from Cecil
	public class AsmDataItem : IDataItem
	{
		public DataItemKind GetDataItemKind
		{
			get { return DataItemKind.Assembly; }
		}

		public List<string> GetSignatureList()
		{
			//TODO: populate from assembly
			return new List<string>();
		}
	}

	//the mem-doc format independent  representation of a doc entry, populated form .mem files
	public class DocDataItem : IDataItem
	{
		public DataItemKind GetDataItemKind {
			get {return DataItemKind.Doc;}
		}
		public List<string> GetSignatureList()
		{
			//TODO: return the list of all signatures
			return new List<string>();
		}
	}

	//a combined entry 
	public class CombinedDataItem: IDataItem
	{
		public DataItemKind GetDataItemKind
		{
			get { return DataItemKind.Combined; }
		}
		public List<string> GetSignatureList()
		{
			//TODO: return the union of signatures contained in asmData and docData
			return new List<string>();
		}

		Dictionary<string, DataItemKind> GetCombinedEntries()
		{
			var dict = new Dictionary<string, DataItemKind>();
			foreach (var asmSig in asmData.GetSignatureList())
			{
				if (!dict.ContainsKey(asmSig))
				{
					dict[asmSig] = DataItemKind.Assembly;
				}
				else
				{
					Console.WriteLine("something fishy going on");
				}
			}
			foreach (var docSig in docData.GetSignatureList())
			{
				if (!dict.ContainsKey(docSig))
					dict[docSig] = DataItemKind.Doc;
				else
					dict[docSig] = DataItemKind.Combined;
			}
			return dict;
		}

		private AsmDataItem asmData;
		private DocDataItem docData;
	}

	public abstract class GlorifiedDataItem
	{
		private string ShortID;
		private List<string> signatureList;
	}
}
