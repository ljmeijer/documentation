using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;

namespace APIDocumentationGenerator2
{
	internal class HtmlBuilder
	{
		readonly StringBuilder _sb = new StringBuilder();

		public HtmlBuilder()
		{
		}

		public void AddKeyword(string s)
		{
			_sb.Append(s);
		}

		public void Add(string s)
		{
			_sb.Append(s);
		}

		public void AddTypeReference(TypeReference t, bool hyperLinked)
		{
			bool haveDocsFor = HaveDocsFor(t);
			AddHyperlinkedReference(t, "typereference",haveDocsFor && hyperLinked);
		}

		private static bool HaveDocsFor(TypeReference t)
		{
			if (!t.Namespace.StartsWith("Unity"))
				return false;

			return UnityDocumentation.MemDocFor(t) != null;
		}

		private void AddHyperlinkedReference(MemberReference t, string kind, bool hyperLinked)
		{
			_sb.AppendFormat(@"<span class=""{0}"">", kind);

			if (hyperLinked)
				_sb.AppendFormat(@"<a href=""{0}"">", UrlFor(t));

			_sb.Append(HyperlinkablePartOfNameOf(t));
			if (hyperLinked)
				_sb.Append("</a>");

			_sb.Append(NonHyperlinkablePartOfNameOf(t));
				
			_sb.Append("</span>");
		}

		private string HyperlinkablePartOfNameOf(MemberReference memberReference)
		{
			var arrayType = memberReference as ArrayType;
			if (arrayType != null)
				return HyperlinkablePartOfNameOf(arrayType.GetElementType());

			return UsePrimitiveNameFor(memberReference);
		}

		private string UsePrimitiveNameFor(MemberReference memberReference)
		{
			if (memberReference.FullName == "System.Single")
				return "float";
			if (memberReference.FullName == "System.Double")
				return "double";
			if (memberReference.FullName == "System.Int32")
				return "int";
			if (memberReference.FullName == "System.Boolean")
				return "bool";
			if (memberReference.FullName == "System.String")
				return "string";
			if (memberReference.FullName == "System.Void")
				return "void";

			return memberReference.Name;
		}

		private string NonHyperlinkablePartOfNameOf(MemberReference memberReference)
		{
			var arrayType = memberReference as ArrayType;
			if (arrayType == null)
				return "";
			return memberReference.Name.Substring(HyperlinkablePartOfNameOf(memberReference).Length);
		}

		public void AddMemberReferenceName(MemberReference memberReference, bool hyperLinked)
		{
			AddHyperlinkedReference(memberReference, "memberreference", hyperLinked);
		}

		private object UrlFor(MemberReference memberReference)
		{
			var arrayType = memberReference as ArrayType;
			if (arrayType != null)
				return UrlFor(arrayType.GetElementType());

			if (memberReference is TypeDefinition)
				return UnityDocumentation.HtmlNameFor((TypeDefinition)memberReference);

			var declaringType = memberReference.DeclaringType;
			if (declaringType == null)
				return "nourl";
			return UrlFor(declaringType) + "#" + memberReference.Name;
		}

		private string UrlForNamespace(string namespaze)
		{
			return UnityDocumentation.HtmlNameFor(namespaze);
		}

		public override string ToString()
		{
			return _sb.ToString();
		}

		public static string HtmlFor(TypeReference typeReference)
		{
			var hb = new HtmlBuilder();
			hb.AddTypeReference(typeReference, true);
			return hb.ToString();
		}

		public enum NamespaceHyperlinkMode
		{
			None,
			LinkOnlyParentNamespaces,
		}

		public void AddNamespaceReference(string namespaze, NamespaceHyperlinkMode mode)
		{
			_sb.AppendFormat(@"<span class=""{0}"">", "namespace");

			var parentNamespaces = GetParentNamespaces(namespaze);

			if (mode == NamespaceHyperlinkMode.LinkOnlyParentNamespaces)
			{
				bool first = true;
				foreach (var ns in parentNamespaces)
				{
					if (!first)
						_sb.Append(".");
					if (ns.Item2)
						_sb.AppendFormat(@"<a href=""{0}"">", UrlForNamespace(ns.Item1));
					_sb.Append(BottomLevel(ns.Item1));
					if (ns.Item2)
						_sb.Append("</a>");
					first = false;
				}
			}
			else _sb.Append(namespaze);


			_sb.Append("</span>");
		}

		private string BottomLevel(string item1)
		{
			return item1.Split('.').Last();
		}

		private IEnumerable<Tuple<string,bool>> GetParentNamespaces(string namespaze)
		{
			var accumulated = "";
			bool first = true;
			foreach (string s in namespaze.Split('.'))
			{
				if (!first) accumulated += ".";
				accumulated += s;
				yield return new Tuple<string, bool>(accumulated, UnityDocumentation.IsDocumentedNamespace(s));
				first = false;
			}
		}
	}
}
