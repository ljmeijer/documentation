using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Mono.Cecil;
using UnderlyingModel;

namespace APIDocumentationGenerator2
{
	internal class TypePageGenerator : PageGeneratorBase
	{
		private static readonly CSharpSignatureProvider _signatureProvider = new CSharpSignatureProvider();

		private IEnumerable<AssemblyDefinition> _assemblies;

		public void GeneratePageFor(TypeDefinition type, IEnumerable<AssemblyDefinition> assemblies, TextWriter tw)
		{
			_assemblies = assemblies;
			
			tw.Write(PageHeader());

			TypeEntry(type,tw);

			foreach (var method in DocumentedPropertiesFor(type))
			{
				MemberEntry(method,tw);
			}

			foreach (var method in DocumentedMethodGroupsFor(type).Select(g => g.First()))
			{
				MemberEntry(method,tw);
			}

			tw.Write(@"
	</body>
</html>
");
		}

		private static IEnumerable<IGrouping<string, MethodDefinition>> DocumentedMethodGroupsFor(TypeDefinition type)
		{
			return type.Methods.Where(UnityDocumentation.IsDocumentedMethod).OrderBy(m => m.IsStatic).ThenBy(m => m.Name).GroupBy(m => m.Name);
		}

		private static IEnumerable<PropertyDefinition> DocumentedPropertiesFor(TypeDefinition type)
		{
			return type.Properties.Where(UnityDocumentation.IsDocumentedProperty).OrderBy(m => m.IsStatic()).ThenBy(m => m.Name);
		}

		private void TypeEntry(TypeDefinition type,TextWriter tw)
		{
			var memdoc = UnityDocumentation.MemDocFor(type);
			if (memdoc == null)
				return ;
	
			var baseTypeName = (type.BaseType == null) ? "" : type.BaseType.Name;

			tw.Write(@"    <div class='text'>
      <article>
      <h1 class='type'>");
			WriteTypeSignature(tw,type);
			tw.Write("</h1>");
			WriteSummaryAndTextBlocksFor(tw,memdoc);

			tw.Write("<p>");
			TableOfContentsFor(tw, type);
			tw.Write("</p>");

			tw.Write(@"
      </article>
	</div>
");
		}

		private void WriteTypeSignature(TextWriter tw, TypeDefinition type)
		{
			//public class {0} : {1}
			tw.Write("public ");
			tw.Write(TypeKindFor(type));
			tw.Write(" {0}",type.Name);

			var baseThings = BaseThingsFor(type);
			if (!baseThings.Any())
				return;

			tw.Write(" : ");
			bool first = true;
			foreach(var baseThing in baseThings)
			{
				if (!first) tw.Write(", ");
				tw.Write(baseThing.Name);
				first = false;
			}
		}

		private IEnumerable<TypeReference> BaseThingsFor(TypeDefinition type)
		{
			if (type.BaseType != null)
				yield return type.BaseType;

			foreach (var i in type.Interfaces)
				yield return i;
		}

		private string TypeKindFor(TypeDefinition type)
		{
			if (type.IsClass)
				return "class";
			if (type.IsEnum)
				return "enum";
			if (type.IsValueType)
				return "struct";
			throw new ArgumentException();
		}

		private void TableOfContentsFor(TextWriter tw, TypeDefinition type)
		{
			tw.Write("<ul>");
			TableOfContentsFor(tw,DocumentedPropertiesFor(type), "Properties:");
			TableOfContentsFor(tw,DocumentedMethodGroupsFor(type).Select(g => g.First()), "Methods:");
			tw.Write("</ul>");
		}

		private void TableOfContentsFor(TextWriter tw,IEnumerable<MemberReference> methodDefinitions, string title)
		{
			var sb = new StringBuilder();
			if (!methodDefinitions.Any())
				return;
			tw.Write("<li>");
			tw.Write(title);
			tw.Write("<ul>");
			foreach (var method in methodDefinitions)
			{
				tw.Write(@"<li><a href=""#{0}"">{0}</a></li>", method.Name);
			}
			tw.Write("</ul>");
			tw.Write("</li>");
		}


		private void MemberEntry(MemberReference memberReference, TextWriter tw)
		{
			var memdoc = UnityDocumentation.MemDocFor(memberReference);

			if (memdoc == null)
				return;

			tw.Write(@"<a name='{0}'></a> <div class='text' ><article>", memberReference.Name,
			                CssTypeFor(memberReference));
			
			tw.Write(@"
        <h1 class='signature'>{0}</h1>
      ", _signatureProvider.SignatureFor(memberReference, true));

			WriteSummaryAndTextBlocksFor(tw, memdoc);

			WriteEditLink(tw, memberReference);

			tw.Write(@"
      </article>
    </div>
");
		}

		private void WriteEditLink(TextWriter tw, MemberReference memberReference)
		{
			tw.Write(@"<p><a style=""float:right; size:8pt;"" href=""{0}"">edit me</a>", EditUrlFor(memberReference));
		}

		private string EditUrlFor(MemberReference memberReference)
		{
			var name = memberReference.Name;
			if (char.IsLower(name[0]))
				name = "_" + name;
			
			return String.Format("https://github.com/ljmeijer/documentation/blob/master/content/english/api/{0}.{1}.mem",memberReference.DeclaringType.Name, name);
		}

		private void WriteSummaryAndTextBlocksFor(TextWriter tw, MemDocModel memdoc)
		{
			tw.Write(@"
        <p>{0}</p>
        
", ReplaceSpecialSyntaxWithProperTags(InjectLinksToApiReferences(memdoc.Summary)));

			foreach (var block in memdoc.TextBlocks)
			{
				var descriptionBlock = block as DescriptionBlock;
				if (descriptionBlock != null)
				{
					tw.Write("<p>{0}</P>",
					         ReplaceSpecialSyntaxWithProperTags(InjectLinksToApiReferences(descriptionBlock.Text)));
				}

				var exampleblock = block as ExampleBlock;
				if (exampleblock != null)
				{
					tw.Write(ExampleHtmlGenerator.ExamleHtmlFor(exampleblock));
				}
			}
		}

		private static string SeeAlsoBar()
		{
			return @"
			<aside>
			  <h2>
				See also:
			  </h2>
			  <ul>
				<li>
				  <a href='/commands/hdel'>
					active
				  </a>
				</li>
				<li>
				  <a href='/commands/hexists'>
					SetActiveRecursively
				  </a>
				</li>
			  </ul>
			</aside>";
		}

		private string ReplaceSpecialSyntaxWithProperTags(string text)
		{
			var pattern = @"@@(.+?)@@";
			var r = new Regex(pattern);
			text = r.Replace(text, match =>
				{
					var matchedName = match.Groups[1].ToString();

					return "<code>" + matchedName + "</code>";
				});

			/*
				var pattern2 = @"/(.+?)/";
				var r2 = new Regex(pattern2);
				text = r2.Replace(text, match =>
				{
					var matchedName = match.Groups[1].ToString();

					return "<i>" + matchedName + "</i>";
				});*/
			return text;
		}

		private string InjectLinksToApiReferences(string text)
		{
			var pattern = @"\[\[(.+?)\]\]";
			var r = new Regex(pattern);
			return r.Replace(text, match =>
				{
					var matchedName = match.Groups[1].ToString();
					var type = FindType(matchedName);
					if (type != null)
						return HtmlBuilder.HtmlFor(type);
					return matchedName;
				});
		}

		private TypeDefinition FindType(string typeName)
		{
			foreach (var assembly in _assemblies)
			{
				var t = (assembly.MainModule.GetType("UnityEngine." + typeName));
				if (t != null)
					return t;
			}
			return null;
		}

		private static string CssTypeFor(MemberReference memberReference)
		{
			if (memberReference is MethodDefinition)
				return "member";

			if (memberReference is PropertyDefinition)
				return "property";

			throw new ArgumentException();
		}
	}
}
