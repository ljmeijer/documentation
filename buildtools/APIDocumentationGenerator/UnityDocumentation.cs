using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using UnderlyingModel;

namespace APIDocumentationGenerator2
{
	class UnityDocumentation
	{
		public static bool IsDocumentedMethod(MethodDefinition m)
		{
			return m.IsPublic && !m.IsGetter && !m.IsSetter && HasMemDoc(m);
		}

		public static bool IsDocumentedProperty(PropertyDefinition p)
		{
			return HasPublicMethod(p) && HasMemDoc(p);
		}
			
		private static bool HasPublicMethod(PropertyDefinition propertyDefinition)
		{
			var getter = propertyDefinition.GetMethod;
			if (getter != null)
				if (getter.IsPublic)
					return true;

			var setter = propertyDefinition.SetMethod;
			if (setter != null)
				if (setter.IsPublic)
					return true;

			return false;
		}

		static readonly Dictionary<TypeDefinition, bool> _documentedTypesCache = new Dictionary<TypeDefinition, bool>();

		public static bool IsDocumentedType(TypeDefinition t)
		{
			bool result;
			if (_documentedTypesCache.TryGetValue(t, out result))
				return result;

			result = CalculateIsDocumentedType(t);
			_documentedTypesCache.Add(t, result);
			return result;
		}

		private static bool CalculateIsDocumentedType(TypeDefinition t)
		{
			if (!t.IsPublic)
				return false;

			if (!t.Namespace.StartsWith("Unity"))
				return false;

			if (!HasMemDoc(t))
				return false;

			var readAllText = File.ReadAllText(MemFileNameFor(t));
			if (readAllText.Contains("undocumented") && readAllText.SplitLines().Length < 2)
				return false;

			return t.Methods.Any(IsDocumentedMethod) || t.Properties.Any(IsDocumentedProperty);
		}

		public static bool HasMemDoc(MemberReference m)
		{
			return File.Exists(MemFileNameFor(m));
		}

		public static MemDocModel MemDocFor(MemberReference memberReference)
		{
			try
			{
				var inputFromMem = File.ReadAllText(MemFileNameFor(memberReference));
				var memDoc = new MemDocModel(inputFromMem);
				return memDoc;
			}
			catch
			{
				return null;
			}
		}

		public static string MemFileNameFor(MemberReference memberReference)
		{
			var middle = Char.IsLower(memberReference.Name[0]) ? "._" : ".";

			if (memberReference is TypeReference)
			{
				return Path.Combine(DirectoryUtil.MemberDocsDirFullPath, memberReference.Name + ".mem");
			}

			return Path.Combine(DirectoryUtil.MemberDocsDirFullPath,
			                    memberReference.DeclaringType.Name + middle + memberReference.Name + ".mem");
		}

		public static string HtmlNameFor(TypeReference typeReference)
		{
			return (typeReference.FullName+".html");
		}

		public static string HtmlNameFor(string namespaze)
		{
			return namespaze + ".html";
		}

		public static bool IsDocumentedNamespace(string namespaze)
		{
			return true;
		}
	}
}
