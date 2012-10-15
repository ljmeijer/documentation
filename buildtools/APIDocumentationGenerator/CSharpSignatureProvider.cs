using System;
using Mono.Cecil;

namespace APIDocumentationGenerator2
{
	class CSharpSignatureProvider
	{
		public string SignatureFor(MemberReference member, bool hyperLinked)
		{
			var method = member as MethodDefinition;
			if (method != null)
				return SignatureForMethod(method, hyperLinked);

			var property = member as PropertyDefinition;
			if (property != null)
				return SignatureForProperty(property, hyperLinked);
		
			throw new ArgumentException();
		}

		private static string SignatureForProperty(PropertyDefinition property, bool hyperLinked)
		{
			var hb = new HtmlBuilder();
			if (property.IsStatic())
			{
				hb.AddKeyword("static");
				hb.Add(" ");
			}
			hb.AddKeyword("public");
			hb.Add(" ");
			hb.AddTypeReference(property.PropertyType, hyperLinked);
			hb.Add(" ");
			hb.AddMemberReferenceName(property, false);
			hb.Add(" {");
			if (property.GetMethod != null)
			{
				hb.Add(" ");
				hb.AddKeyword("get");
				hb.Add(";");
			}
			if (property.SetMethod != null)
			{
				hb.Add(" ");
				hb.AddKeyword("set");
				hb.Add(";");
			}
			hb.Add(" }");

			return hb.ToString();
		}

		private static string SignatureForMethod(MethodDefinition method, bool hyperLinked)
		{
			var hb = new HtmlBuilder();
			if (method.IsStatic)
			{
				hb.AddKeyword("static");
				hb.Add(" ");
			}
			hb.AddKeyword("public");
			hb.Add(" ");
			hb.AddTypeReference(method.ReturnType, hyperLinked);
			hb.Add(" ");
			hb.AddMemberReferenceName(method, false);
			hb.Add(" (");

			bool first = true;
			foreach(var param in method.Parameters)
			{
				if (!first)
					hb.Add(", ");

				hb.AddTypeReference(param.ParameterType,hyperLinked);
				hb.Add(" ");
				hb.Add(param.Name);
				first = false;
			}

			hb.Add(")");
			return hb.ToString();
		}
	}
}
