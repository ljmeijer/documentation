using System.Collections.Generic;
using Mono.Cecil;

namespace UnderlyingModel
{
	public class ReturnWithDoc
	{
		public string Doc { set; get; }
		public TypeDefinition ReturnType = null;
		public bool HasDoc { get { return !string.IsNullOrEmpty (Doc); } }
		public bool HasAsm { get { return ReturnType != null; } }
		
		public ReturnWithDoc () { Doc = ""; }
		
		public bool Equals(string doc)
		{
			return Doc == doc;
		}

		//note: both @return and @returns are valid syntax, we had to pick one here
		public override string ToString()
		{
			return "@return " + Doc;
		}
	}

	public class ParameterWithDoc
	{
		public string Name { set; get; }
		public string Doc { set; get; }
		public ParameterDefinition Info = null;
		public bool HasDoc { get { return !string.IsNullOrEmpty (Doc); } }
		public bool HasAsm { get { return Info != null; } }
		
		public ParameterWithDoc () { Doc = ""; Name = ""; }
		
		public bool Equals(string name, string doc)
		{
			return Name == name && Doc == doc;
		}

		public override string ToString()
		{
			return "@param " + Name + " " + Doc;
		}
	}

	public class SignatureModel
	{
		SignatureModel(string st)
		{
			_internalString = st;
		}

		public override string ToString()
		{
			return _internalString;
		}
		private readonly string _internalString;
	}
}
