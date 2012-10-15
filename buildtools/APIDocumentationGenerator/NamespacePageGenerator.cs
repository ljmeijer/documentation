using System.Linq;
using System.Text;
using Mono.Cecil;

namespace APIDocumentationGenerator2
{
	internal class NamespacePageGenerator : PageGeneratorBase
	{
		public string GeneratePageFor(string namespaze, AssemblyDefinition[] assemblyDefinitions)
		{
			var types =
				assemblyDefinitions.Select(a => a.MainModule).SelectMany(m => m.Types).Where(
					t => t.Namespace == namespaze && UnityDocumentation.IsDocumentedType(t));

			var sb = new StringBuilder();
			sb.Append(PageHeader());

			sb.AppendFormat(@"    <div class='text'>
      <article>");

			sb.Append("<h1>");
			var htmlbuilder = new HtmlBuilder();
			htmlbuilder.AddKeyword("namespace");
			htmlbuilder.Add(" ");
			htmlbuilder.AddNamespaceReference(namespaze, HtmlBuilder.NamespaceHyperlinkMode.LinkOnlyParentNamespaces);
			sb.Append(htmlbuilder);
			sb.Append("</h1>");
			sb.Append("<ul>");
			foreach(var type in types)
			{
				sb.Append("<li>");
				var memdoc = UnityDocumentation.MemDocFor(type);
				var html = new HtmlBuilder();
				html.AddTypeReference(type, true);
				sb.Append(html);
				sb.Append("   ");
				if (memdoc!=null)
					sb.Append(memdoc.Summary);
				sb.Append("<br>");
				sb.Append("</li>");
			}
			sb.Append("</ul>");
			sb.AppendFormat(@"    </div></article>");
			return sb.ToString();
		}
	}
}
